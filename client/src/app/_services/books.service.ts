import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Book } from '../_models/book';

@Injectable()
export class BooksService {
    baseUrl = environment.apiUrl;
    randomBooks: Book[] = [];

    constructor(private http: HttpClient) { }

    get(): Observable<Book[]> {
        return this.http.get<Book[]>(`${this.baseUrl}/Books`);
    }

    get(id: number): Observable<Book> {
        return this.http.get<Book>(`${this.baseUrl}/Books/${id}`);
    }
}
