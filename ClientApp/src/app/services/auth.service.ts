import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, map } from 'rxjs';
import { LoginForm, RegisteredUser, User } from '../interfaces/user.interface';

interface AuthResponse {
  token: string;
  user: User;
}

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private readonly API_URL = 'http://localhost:5047/api/auth';

  constructor(private http: HttpClient) {}

  login(login: LoginForm): Observable<AuthResponse> {
    return this.http.post<AuthResponse>(`${this.API_URL}/login`, login);
  }

  register(user: RegisteredUser): Observable<AuthResponse> {
    console.log('register ' + user.username);
    return this.http.post<AuthResponse>(`${this.API_URL}/register`, user);
  }

  logout(): void {
    localStorage.removeItem('token');
    sessionStorage.clear();
  }

  getToken(): string | null {
    return localStorage.getItem('token');
  }

  isLoggedIn(): boolean {
    var user = sessionStorage.getItem('user');
    if (user != null) {
      return true;
    }
    else return false;
  }
}
