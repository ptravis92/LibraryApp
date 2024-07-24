import { Routes } from '@angular/router';
import { FeaturedBooksComponent } from './components/featured-books/featured-books.component';
import { RegisterComponent } from './components/register/register.component';

export const routes: Routes = [
    { path: '', component: RegisterComponent },
    {
        path: '',
        runGuardsAndResolvers: 'always',
        //canActivate: [authGuard],
        children: [
            { path: 'featured', component: FeaturedBooksComponent },
            // { path: 'messages', component: MessagesComponent },
            // { path: 'admin', component: AdminPanelComponent, canActivate: [adminGuard] }
        ]
    }
];
