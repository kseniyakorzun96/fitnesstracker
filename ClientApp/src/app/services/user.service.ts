import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { User } from "../interfaces/user.interface";
import { Observable } from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class UserService {
    private apiUrl: string = 'http://localhost:5047';
    constructor(private http: HttpClient) {}
    
    getUser(userId: string): Observable<User> {
    return this.http.get<User>(`${this.apiUrl}/api/users/${userId}`);
  }
}