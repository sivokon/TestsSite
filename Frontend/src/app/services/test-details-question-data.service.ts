import { Injectable } from '@angular/core';
import { AnswerModel } from '../models/answer-model';
import { CompletedTestModel } from '../models/completed-test-model';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { headersToString } from '../../../node_modules/@types/selenium-webdriver/http';

@Injectable({
  providedIn: 'root'
})
export class TestDetailsQuestionDataService {

  numOfQuestions: number;
  completedTest: CompletedTestModel = {
    TestId: 0,
    Answers: []
  }

  startTime: Date = null;
  endTime: Date = null;

  constructor(private http: HttpClient) { }

  addAnswerWithIndex(answer: AnswerModel, index: number): void {
    if (this.numOfQuestions >= index) {
      this.completedTest.Answers[index] = answer;
    }
  }

  getAnswerByIndex(index: number): AnswerModel {
    return this.completedTest.Answers[index];
  }

  getAnswers(): AnswerModel[] {
    return this.completedTest.Answers;
  }

  allQuestionsAreAnswered(): boolean {
    return this.numOfQuestions == this.completedTest.Answers.length
  }

  resetTest() {
    this.completedTest = {
      TestId: 0,
      Answers: []
    }
    this.startTime = null;
    this.endTime = null;
  }

  authHeader: HttpHeaders = new HttpHeaders({
    'Authorization':'Bearer ' + localStorage.getItem('accessToken')
  });

  sendStartedTestData() {
    console.log(this.completedTest);
    return this.http.post('api/TestStat', this.completedTest, { headers: this.authHeader });
  }

  sendFinishedTestData() {
    console.log(this.completedTest);
    return this.http.put('api/TestStat', this.completedTest, { headers: this.authHeader });
  }

}
