import { Component, OnInit, Input } from '@angular/core';
import { UserLoginModel } from '../../models/user-login-model';
import { NgForm } from '../../../../node_modules/@angular/forms';
import { AuthService } from '../../services/auth.service';
import { Router } from '../../../../node_modules/@angular/router';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  user: UserLoginModel;
  errorMessage: string = '';

  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit() {
    this.resetForm();
    //localStorage.removeItem('accessToken');
  }

  resetForm(form?: NgForm) {
    if (form != null) {
      form.reset();
    }
    this.user = {
      Username: '',
      Password: ''
    }
  }

  loginUser(form: NgForm): void {
    this.errorMessage = '';
    this.authService.loginUser(form.value)
      .subscribe(
        (data: any) => {
          localStorage.setItem('accessToken', data.access_token),
          localStorage.setItem('userName', data.userName),
          //localStorage.setItem("tokenData", JSON.stringify(data));
          this.router.navigate(['/testCategories']);
        },
        (err => {
          this.errorMessage = err.message;
          this.resetForm(form);
        })
      );
  }

}
