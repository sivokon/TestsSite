import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { TestStatModel } from '../models/test-statistic-model';
import { AnswerModel } from '../models/answer-model';

@Injectable({
  providedIn: 'root'
})
export class TestStatService {

  constructor(private http: HttpClient) { }

  authHeader: HttpHeaders = new HttpHeaders({
    'Authorization':'Bearer ' + localStorage.getItem('accessToken')
  });

  getTestStatsOfCurrUser(): Observable<TestStatModel> {
    return this.http.get<TestStatModel>('api/TestStat/byUser', { headers: this.authHeader });
  }

  getAnswersByTestStatId(id: number): Observable<AnswerModel> {
    return this.http.get<AnswerModel>(`api/Answer/byTestStat/${id}`, { headers: this.authHeader });
  }

}
