import { AfterViewInit, Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInput, MatInputModule } from '@angular/material/input';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { Subject, takeUntil } from 'rxjs';
import { Book } from '../../../_models/book';
import { BooksService } from '../../../_services/books.service';
import { DatePipe } from '@angular/common';
import { MatCardModule } from '@angular/material/card';

@Component({
  selector: 'featured-books',
  standalone: true,
  imports: [MatTableModule, MatPaginatorModule, MatSortModule, MatFormFieldModule, ReactiveFormsModule, MatInputModule, MatSlideToggleModule, DatePipe, MatCardModule],
  providers: [BooksService],
  templateUrl: './featured-books.component.html',
  styleUrls: ['./featured-books.component.css']
})

export class FeaturedBooksComponent implements OnInit, AfterViewInit, OnDestroy {
  @ViewChild(MatPaginator) private paginator!: MatPaginator;
  @ViewChild(MatSort) private sort!: MatSort;
  @ViewChild(MatInput) private matInput!: MatSort;

  filter = new FormControl<string | null>('');

  books = new MatTableDataSource<Book>([]);
  unsubscribe: Subject<void> = new Subject();
  displayedColumns: (keyof Book)[] = [
    'title',
    'author',
    'description',
    'coverImage',
    'rating',
    'checkedOutUntil'
  ];

  constructor(private _booksService: BooksService) { }

  ngOnInit(): void {
    this._booksService.getRandom()
      .pipe(takeUntil(this.unsubscribe))
      .subscribe(response => this.books.data = response);
  }

  ngAfterViewInit(): void {
    this.books.paginator = this.paginator;
    this.books.sort = this.sort;

    this.books.filterPredicate = (book, filter) => {
      const cleanFilter = filter.trim().toLocaleLowerCase();
      if (cleanFilter.includes('#available')) {
        return book.checkedOutUntil == null;
      } else if (cleanFilter.includes('#unavailable')) {
        return book.checkedOutUntil != null;
      } else {
        return book.title.toLocaleLowerCase().includes(cleanFilter)
        || book.author.toLocaleLowerCase().includes(cleanFilter);
      }
    }

    this.filter.valueChanges
      .pipe(takeUntil(this.unsubscribe))
      .subscribe(filter => this.books.filter = filter ?? '')
  }

  ngOnDestroy(): void {
    this.unsubscribe.next();
    this.unsubscribe.complete();
  }
}
