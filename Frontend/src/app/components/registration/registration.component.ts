import { Component, OnInit, Input } from '@angular/core';
import { UserRegistrationModel } from '../../models/user-registration-model';
import { NgForm } from '../../../../node_modules/@angular/forms';
import { AuthService } from '../../services/auth.service';
import { Router } from '../../../../node_modules/@angular/router';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  user: UserRegistrationModel;
  errorMessage: string = '';

  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit() {
    this.resetForm();
  }  

  resetForm(form?: NgForm) : void {
    if (form != null) {
      form.reset();
    }
    this.user = {
      Email: '',
      Password: '',
      ConfirmPassword: ''
    }
  }

  registerUser(form: NgForm) : void {
    this.errorMessage = '';
    this.authService.registerUser(form.value)
      .subscribe(
        () => this.router.navigate(['/login']),
        (err => {
          this.errorMessage = err.message;
          this.resetForm(form);
        })
      );    
  }

}
