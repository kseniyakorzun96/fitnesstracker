import { Component } from "@angular/core";
import { Nutrition, Training, Weigth } from "../../interfaces/entry.interface";
import { UserService } from "../../services/user.service";
import { User } from "../../interfaces/user.interface";
import { TrainingService } from "../../services/training.service";
import { NutritionService } from "../../services/nutrition.service";
import { ActivatedRoute, Router } from "@angular/router";
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

  trainingDurationLineChartData: any[] = [];
  trainingCaloriesLineChartData: any[] = [];

  nutritionCaloriesLineChartData: any[] = [];
  nutritionFPCLineChartData: any[] = [];

  weigthLineChartData: any[] = [];

  pieChartData: any[] = [];
  dateTrack: Date[] = [];

  constructor(private route: ActivatedRoute,
    private trainingService: TrainingService,
    private nutritionService: NutritionService,
    private userService: UserService,
    private weigthService: WeigthService,
    private router: Router) { }

  ngOnInit(): void {
    var userJson = sessionStorage.getItem('user');
    var userId : string | undefined = '';
    var isAuth = JSON.parse(sessionStorage.getItem('isAuthenticated') || 'false');
    
    if (userJson != null) {
      this.user = JSON.parse(userJson);
      userId = this.user?.username;
    }

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
      });

      this.userService.getUser(userId).subscribe({
        next: (data) => {
          this.user = data;
        },
        error: (err) => {
          console.error('Failed to load:', err);
        }
      });
    }
    else this.router.navigate(['/login']);
  }

  initLineChartData() {
    this.trainingDurationLineChartData = [
      {
        name: 'Duration (min)',
        series: this.trainings.map(t => ({
          name: t.dateOfEntry,
          value: t.duration
        }))
      }
    ];

    this.trainingCaloriesLineChartData = [
      {
        name: 'Calories Burned',
        series: this.trainings.map(t => ({
          name: t.dateOfEntry,
          value: t.caloriesBurned
        }))
      },
    ]
  }

  initNutritionLineChartData() {
    this.nutritionCaloriesLineChartData = [
      {
        name: 'Calories',
        series: this.nutritions.map(t => ({
          name: t.dateOfEntry,
          value: t.calories
        }))
      }
    ];

    this.nutritionFPCLineChartData = [
      {
        name: 'Fats',
        series: this.nutritions.map(t => ({
          name: t.dateOfEntry,
          value: t.fats
        }))
      },
      {
        name: 'Carbohydrates',
        series: this.nutritions.map(t => ({
          name: t.dateOfEntry,
          value: t.carbohydrates
        }))
      },
      {
        name: 'Proteins',
        series: this.nutritions.map(t => ({
          name: t.dateOfEntry,
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
          name: t.dateOfEntry,
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