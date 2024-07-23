import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { FeaturedBooksComponent } from './components/featured-books/featured-books/featured-books.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, FeaturedBooksComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'client';
}
