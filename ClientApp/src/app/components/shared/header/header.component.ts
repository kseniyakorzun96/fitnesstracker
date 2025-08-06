import { Component, OnInit } from "@angular/core";
import { User } from "../../../interfaces/user.interface";
import { Route, Router } from "@angular/router";

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  standalone: false
})
export class HeaderComponent implements OnInit{

  constructor(private router: Router) {
    
  }

  user: User | null | undefined;
  isAuth: boolean = false;
  
  ngOnInit(): void {
    var userJson = sessionStorage.getItem('user');
    this.isAuth = JSON.parse(sessionStorage.getItem('isAuthenticated') || 'false');
    
    if (userJson != null) {
      this.user = JSON.parse(userJson);
    }
  }

  logout() {
    sessionStorage.clear();
    this.router.navigate(['/home']);
  }
}