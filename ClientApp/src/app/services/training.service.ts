import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Nutrition, Training, Entry } from "../interfaces/entry.interface";

@Injectable({
  providedIn: 'root'
})
export class TrainingService {
    private apiUrl: string = 'http://localhost:5047';
    constructor(private http: HttpClient) {}
    
    getTrainings(userId: string): Observable<Training[]> {
        return this.http.get<Training[]>(`${this.apiUrl}/api/training/user/${userId}`);
    }

    getTrainingsForToday(userId: string): Observable<Training[]> {
        return this.http.get<Training[]>(`${this.apiUrl}/api/training/user/${userId}/today`);
    }
}