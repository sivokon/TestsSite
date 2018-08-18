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

  getAnswersByTestStatId(id: number): Observable<AnswerModel> {
    return this.http.get<AnswerModel>(`api/Answers/byTestStat/${id}`, { headers: this.authHeader });
  }

  getTestStatsWithRelatedTestsOfCurrUser(): Observable<TestStatModel> {
    return this.http.get<TestStatModel>('api/TestStat/WithTests/byUser', { headers: this.authHeader })
  }

}
