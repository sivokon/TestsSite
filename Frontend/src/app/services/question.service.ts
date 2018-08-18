import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from '../../../node_modules/rxjs';
import { QuestionModel } from '../models/question-model';

@Injectable({
  providedIn: 'root'
})
export class QuestionService {

  constructor(private http: HttpClient) { }

  authHeader: HttpHeaders = new HttpHeaders({
    'Authorization':'Bearer ' + localStorage.getItem('accessToken')
  });

  getQuestionsByTestId(id: number): Observable<QuestionModel> {
    return this.http.get<QuestionModel>(`api/Question/byTest/${id}`, { headers: this.authHeader });
  }

  getQuestionByIndexAndTestId(index: number, testId: number): Observable<QuestionModel> {
    return this.http.get<QuestionModel>(`api/Question/${index}/byTest/${testId}`, { headers: this.authHeader });
  }

  getQuestionsWithOptionsByTestId(id: number): Observable<QuestionModel> {
    return this.http.get<QuestionModel>(`api/Question/WithOptions/byTest/${id}`, { headers: this.authHeader });
  }

}
