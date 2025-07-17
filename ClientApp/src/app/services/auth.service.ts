import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { LoginForm, User } from "../interfaces/user.interface";
import { Router } from "@angular/router";

@Injectable({
  providedIn: 'root'
})
export class AuthService {
    private apiUrl: string = 'http://localhost:5047';
    constructor(private http: HttpClient, private router: Router) {}
    
    login(username: string, password: string) {
        const user: LoginForm = {
            username: username,
            password: password,
        };
        return this.http.post(`${this.apiUrl}/api/Auth/login`, user);
  }

  getUserRole(){
    return this.http.get(`${this.apiUrl}/api/Auth/role`);
  }

  isLoggedIn(){
    const user = JSON.parse(localStorage.getItem('user') || '{}');
    if (user != null) return true;
    else return false;
  }

  logout() {
    this.http.post('/api/logout', {}).subscribe(() => {
      localStorage.removeItem('authToken');
      this.router.navigate(['/login']);
    });
  }
}