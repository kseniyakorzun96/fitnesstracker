import { Component } from "@angular/core";
import { CData, Nutrition, Training, TrainingType, Weigth } from "../../interfaces/entry.interface";
import { UserService } from "../../services/user.service";
import { User } from "../../interfaces/user.interface";
import { TrainingService } from "../../services/training.service";
import { NutritionService } from "../../services/nutrition.service";
import { ActivatedRoute, Router } from "@angular/router";
import { AuthService } from "../../services/auth.service";
import { WeigthService } from "../../services/weigth.service";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  standalone: false
})
export class HomeComponent {
  user: User | null = null;
  trainings: Training[] = [];
  nutritions: Nutrition[] = [];
  weigth: Weigth[] = [];

  trainingLineChartData: any[] = [];
  nutritionLineChartData: any[] = [];
  weigthLineChartData: any[] = [];

  pieChartData: any[] = [];
  dateTrack: Date[] = [];

  constructor(private route: ActivatedRoute,
    private trainingService: TrainingService,
    private nutritionService: NutritionService,
    private userService: UserService,
    private authService: AuthService,
    private weigthService: WeigthService,
    private router: Router) { }

  ngOnInit(): void {
    var userId = 'kkorzun';
    this.dateTrack = this.getLast7Days();

    if (userId != null) {
      this.trainingService.getTrainings(userId).subscribe({
        next: (data) => {
          this.trainings = data;
          this.initLineChartData();
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
          this.initPieChartData();
          this.initNutritionLineChartData();
        },
        error: (err) => {
          console.error('Failed to load:', err);
        }
      });

      this.weigthService.getWeigth(userId).subscribe({
        next: (data) => {
          this.weigth = data;
          console.log(this.weigth);
          this.initWeigthLineChartData();
        },
        error: (err) => {
          console.error('Failed to load:', err);
        }
      })
    }
  }

  initLineChartData() {
    this.trainingLineChartData = [
      {
        name: 'Calories Burned',
        series: this.trainings.map(t => ({
          name: t.entry.dateOfEntry,
          value: t.caloriesBurned
        }))
      },
      {
        name: 'Duration (min)',
        series: this.trainings.map(t => ({
          name: t.entry.dateOfEntry,
          value: t.duration
        }))
      }
    ];
  }

  initNutritionLineChartData() {
    this.nutritionLineChartData = [
      {
        name: 'Calories',
        series: this.nutritions.map(t => ({
          name: t.entry.dateOfEntry,
          value: t.calories
        }))
      },
      {
        name: 'Fats',
        series: this.nutritions.map(t => ({
          name: t.entry.dateOfEntry,
          value: t.fats
        }))
      },
      {
        name: 'Carbohydrates',
        series: this.nutritions.map(t => ({
          name: t.entry.dateOfEntry,
          value: t.carbohydrates
        }))
      },
      {
        name: 'Proteins',
        series: this.nutritions.map(t => ({
          name: t.entry.dateOfEntry,
          value: t.protein
        }))
      },
    ];
  }

  initWeigthLineChartData() {
    this.weigthLineChartData = [
      {
        name: 'Weigth',
        series: this.weigth.map(t => ({
          name: t.entry.dateOfEntry,
          value: t.value
        }))
      }
    ];

    console.log(this.weigthLineChartData)
  }

  initPieChartData() {

    var p = 0;
    var f = 0;
    var c = 0;

    this.nutritions.forEach(element => {
      p = p + element.protein;
      f = f + element.fats;
      c = c + element.carbohydrates;
    });

    this.pieChartData = [
      { name: 'Protein', value: p },
      { name: 'Carbohydrates', value: c },
      { name: 'Fats', value: f }
    ];

    console.log(this.pieChartData);
  }

  getLast7Days(): Date[] {
    const dates: Date[] = [];

    for (let i = -3; i < 4; i++) {
      const d = new Date();
      d.setDate(d.getDate() - i);
      dates.push(d);
    }
    return dates.reverse();
  }

  logout(event: MouseEvent) {
    this.authService.logout();
    this.router.navigate(['login']);
  }

  isToday(date: Date) {
    const today = new Date();
    return date.getDate() === today.getDate() &&
      date.getMonth() === today.getMonth() &&
      date.getFullYear() === today.getFullYear();
  }

  getStyles(d: Date) {
    const today = new Date();

    if (d === today) {
      return { borderColor: '#007bff' };
    }
    if (d > today) {
      return { borderColor: '#6c757d' };
    }
    else {
      return { borderColor: '#28a745' };
    }
  }
}