import { Component } from "@angular/core";
import { Nutrition, Training } from "../../interfaces/entry.interface";
import { UserService } from "../../services/user.service";
import { User } from "../../interfaces/user.interface";
import { TrainingService } from "../../services/training.service";
import { NutritionService } from "../../services/nutrition.service";
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  standalone: false
})
export class HomeComponent {
    user: User | null = null;
    trainings: Training[] = [];
    nutritions: Nutrition[] = [];

    constructor(private route: ActivatedRoute,
                private trainingService: TrainingService,
                private nutritionService: NutritionService,
                private userService: UserService) {}

    ngOnInit(): void {
    var userId = 'kkorzun';
    
    if (userId != null) {
      this.trainingService.getTrainings(userId).subscribe({
      next: (data) => {
        this.trainings = data;
        console.log('loaded:', this.trainings);
      },
      error: (err) => {
        console.error('Failed to load:', err);
      }
    });

    this.userService.getUser(userId).subscribe({
      next: (data) => {
        this.user = data;
      },
      error: (err) => {
        console.error('Failed to load:', err);
      }
    });

    this.nutritionService.getNutrition(userId).subscribe({
      next: (data) => {
        this.nutritions = data;
      },
      error: (err) => {
        console.error('Failed to load:', err);
      }
    })
    }  
  }
}