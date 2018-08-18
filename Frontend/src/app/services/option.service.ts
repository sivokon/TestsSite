import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from '../../../node_modules/rxjs';
import { QuestionModel } from '../models/question-model';
import { OptionModel } from '../models/option-model';

@Injectable({
  providedIn: 'root'
})
export class OptionService {

  constructor(private http: HttpClient) { }

  authHeader: HttpHeaders = new HttpHeaders({
    'Authorization':'Bearer ' + localStorage.getItem('accessToken')
  });

  getOptionsByQuestionId(id: number): Observable<OptionModel> {
    return this.http.get<OptionModel>(`api/Option/byQuestion/${id}`, { headers: this.authHeader });
  }

}
