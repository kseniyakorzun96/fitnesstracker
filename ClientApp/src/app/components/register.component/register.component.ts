import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { RegisteredUser } from '../../interfaces/user.interface';
import { Store } from '@ngrx/store';
import { AuthState } from '../../ngrx/auth.state';
import { register } from '../../ngrx/auth.actions';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register.component',
  standalone: false,
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  
  constructor(private store: Store<AuthState>, private router: Router) {}
  
  regForm = new FormGroup({
    username: new FormControl('', [Validators.required]),
    password: new FormControl('', Validators.required),
    email: new FormControl('', Validators.email)
  });

  onSubmit() {
    const username = String(this.regForm.get('username')?.value);
    const password = String(this.regForm.get('password')?.value);
    const email = String(this.regForm.get('email')?.value);
    
    var user: RegisteredUser = {
      username: username,
      password: password,
      email: email
    };
    
    this.store.dispatch(register({ user: user }));  
    this.router.navigate(['/home']);
  }
}
