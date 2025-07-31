import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Weigth as Weight } from "../interfaces/entry.interface";

@Injectable({
  providedIn: 'root'
})
export class WeigthService {
    private apiUrl: string = 'http://localhost:5047';
    constructor(private http: HttpClient) {}
    
    getWeigth(userId: string): Observable<Weight[]> {
        return this.http.get<Weight[]>(`${this.apiUrl}/api/weight/user/${userId}`);
    }
}