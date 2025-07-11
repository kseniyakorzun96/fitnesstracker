import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { LoginForm, User } from "../interfaces/user.interface";

@Injectable({
  providedIn: 'root'
})
export class AuthService {
    private apiUrl: string = 'http://localhost:5047';
    constructor(private http: HttpClient) {}
    
    login(username: string, password: string) {
        const user: LoginForm = {
            username: username,
            password: password,
        };
        return this.http.post(`${this.apiUrl}/api/Auth/login`, user);
  }
}