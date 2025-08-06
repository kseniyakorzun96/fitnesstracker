import { Component, OnInit } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { AuthService } from "../../services/auth.service";
import { Router } from "@angular/router";
import { AuthState } from "../../ngrx/auth.state";
import { Store } from "@ngrx/store";
import { login } from "../../ngrx/auth.actions";
import { LoginForm } from "../../interfaces/user.interface";
import { UserService } from "../../services/user.service";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  standalone: false
})
export class LoginComponent {
    errorMessage: string = '';
    constructor(private store: Store<AuthState>, private router: Router, private userService: UserService){

    }
    
    loginForm = new FormGroup({
    username: new FormControl('', [Validators.required]),
    password: new FormControl('', Validators.required)
  });

  onSubmit() {
    const username = String(this.loginForm.get('username')?.value);
    const password = String(this.loginForm.get('password')?.value);

    var userLogin: LoginForm = {
      username: username,
      password: password
    };

    this.store.dispatch(login({ login: userLogin }));

    this.userService.getUser(username).subscribe(data => {
      sessionStorage.setItem('user', JSON.stringify(data));
      sessionStorage.setItem('isAuthenticated', 'true');
    });

    this.router.navigate(['/home']);
  }
}

