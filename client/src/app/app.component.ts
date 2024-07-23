import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { FeaturedBooksComponent } from './components/featured-books/featured-books/featured-books.component';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatToolbarModule } from '@angular/material/toolbar';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, FeaturedBooksComponent, MatToolbarModule, MatButtonModule, MatIconModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'client';
}
