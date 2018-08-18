import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { Http, Response } from '@angular/http';
import { TestCategoryModel } from '../models/test-category-model';

@Injectable({
  providedIn: 'root'
})
export class TestCategoryService {

  constructor(private http: HttpClient) { }

  authHeader: HttpHeaders = new HttpHeaders({
    'Authorization':'Bearer ' + localStorage.getItem('accessToken')
  });

  getTestCategories(): Observable<TestCategoryModel> {
    return this.http.get<TestCategoryModel>('api/TestCategory', { headers: this.authHeader });
  }

}
