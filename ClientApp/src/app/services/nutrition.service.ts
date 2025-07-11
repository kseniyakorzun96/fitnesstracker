import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Nutrition, Training, Entry } from "../interfaces/entry.interface";

@Injectable({
  providedIn: 'root'
})
export class NutritionService {
    private apiUrl: string = 'http://localhost:5047';
    constructor(private http: HttpClient) {}


    getNutrition(userId: string): Observable<Nutrition[]> {
        return this.http.get<Nutrition[]>(`${this.apiUrl}/api/Nutrition/user/${userId}`);
    }

     getNutritionForToday(userId: string): Observable<Nutrition[]> {
        return this.http.get<Nutrition[]>(`${this.apiUrl}/api/Nutrition/user/${userId}/today`);
    }
}