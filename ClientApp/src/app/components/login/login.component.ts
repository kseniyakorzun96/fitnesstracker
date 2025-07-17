import { Component, OnInit } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { AuthService } from "../../services/auth.service";
import { Router } from "@angular/router";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  standalone: false
})
export class LoginComponent {
    errorMessage: string = '';
    constructor(private authService: AuthService, private router: Router){

    }
    
    loginForm = new FormGroup({
    username: new FormControl('', [Validators.required]),
    password: new FormControl('', Validators.required)
  });

  onSubmit() {
    if (this.loginForm.valid) {
      console.log('Login data:', this.loginForm.value);
    }
    const username = String(this.loginForm.get('username')?.value);
    const password = String(this.loginForm.get('password')?.value);
    this.authService.login(username, password).subscribe({
        next: (data) => {
            localStorage.setItem('user', JSON.stringify(data));
            //const user = JSON.parse(localStorage.getItem('user') || '{}');
            this.router.navigate(['home']);
        },
        error: (err) => {
            this.errorMessage = err.error.message || 'Login failed';
        }
})
  }
}