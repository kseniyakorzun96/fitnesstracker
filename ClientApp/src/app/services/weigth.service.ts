import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Weigth } from "../interfaces/entry.interface";

@Injectable({
  providedIn: 'root'
})
export class WeigthService {
    private apiUrl: string = 'http://localhost:5047';
    constructor(private http: HttpClient) {}
    
    getWeigth(userId: string): Observable<Weigth[]> {
        return this.http.get<Weigth[]>(`${this.apiUrl}/api/weigth/user/${userId}`);
    }
}