import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { TestModel } from '../models/test-model';

@Injectable({
  providedIn: 'root'
})
export class TestService {

  constructor(private http: HttpClient) { }

  authHeader: HttpHeaders = new HttpHeaders({
    'Authorization':'Bearer ' + localStorage.getItem('accessToken')
  });

  getTestsByCategoryId(id: number): Observable<TestModel> {
    return this.http.get<TestModel>(`api/Test/byCategory/${id}`, { headers: this.authHeader });
  }

  getTestById(id: number) : Observable<TestModel> {
    return this.http.get<TestModel>(`api/Test/${id}`, { headers: this.authHeader });
  }

}
