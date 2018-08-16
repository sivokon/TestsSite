import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Response } from '@angular/http';
import { Observable } from 'rxjs';
import { Router } from '../../../node_modules/@angular/router';
import { UserRegistrationModel } from '../models/user-registration-model';
import { UserLoginModel } from '../models/user-login-model';
import { HttpErrorResponse } from '@angular/common/http';
import { catchError } from '../../../node_modules/rxjs/operators';
import 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient, private router: Router) { }

  registerUser(user: UserRegistrationModel) {
    return this.http.post('/api/Account/Register', user);
  }

  loginUser(user: UserLoginModel) {
    var data = "username=" + user.Username + "&password=" + user.Password + "&grant_type=password";
    var reqHeader = new HttpHeaders({'Content-Type':'application/x-www-form-urlencoded'});
    return this.http.post('/token', data, {headers: reqHeader});
  }

  isAuthenticated(): boolean {
    return localStorage.getItem('accessToken') != null;
  }

  logoutIfTokenExpired(err: HttpErrorResponse): void {
    if (err.status === 401  && this.isAuthenticated) {
      this.logout();
    }
  }

  logout(): void {
    localStorage.removeItem('accessToken');
    this.router.navigate(['/login']);
  }

}
