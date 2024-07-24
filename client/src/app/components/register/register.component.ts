import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { Router } from '@angular/router';
import { AccountService } from '../../_services/account.service';

@Component({
  selector: 'register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
  standalone: true,
  imports: [MatFormFieldModule, MatSelectModule, MatCardModule]
})
export class RegisterComponent {

  registerForm = new FormGroup({
    userName: new FormControl<string>('', Validators.required),
    roleId: new FormControl<number|null>(null, Validators.required),
    password: new FormControl<string>('', Validators.required)
  });
  
  constructor(private accountService: AccountService, private router: Router) { }

  register() {
    this.accountService.register(this.registerForm.value).subscribe({
      next: _ => this.router.navigateByUrl('/featured') ,
      error: error => console.error(error)
    })
  }
}
