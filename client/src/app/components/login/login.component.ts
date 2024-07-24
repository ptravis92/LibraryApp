import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { AccountService } from '../../_services/account.service';
import { Router } from '@angular/router';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  standalone: true,
  imports: [MatFormFieldModule, MatSelectModule, MatCardModule]
})
export class LoginComponent {

  registerForm = new FormGroup({
    userName: new FormControl<string>('', Validators.required),
    password: new FormControl<string>('', Validators.required)
  });

  constructor(private accountService: AccountService, private router: Router) { }

  login() {
    this.accountService.login(this.registerForm.value).subscribe({
      next: _ => {
        this.router.navigateByUrl('/members')
      },
      error: error => console.error(error)
    })
  }

}
