import { Injectable } from '@angular/core';
import { AnswerModel } from '../models/answer-model';
import { CompletedTestModel } from '../models/completed-test-model';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { headersToString } from '../../../node_modules/@types/selenium-webdriver/http';

@Injectable({
  providedIn: 'root'
})
export class TestDetailsQuestionDataService {

  numOfQuestions: number = 3;
  completedTest: CompletedTestModel = {
    TestId: 0,
    StartTime: null,
    EndTime: null,
    Answers: []
  }

  //answers: AnswerModel[] = [];

  constructor(private http: HttpClient) { }

  // set setStartDate(currTime: Date) {
  //   if (this.startTime == null) {
  //     this.startTime = currTime;
  //   }
  // }

  // set setEndDate(currTime: Date) {
  //   if (this.endTime == null) {
  //     this.endTime = currTime;
  //   }
  // }

  addAnswerWithIndex(answer: AnswerModel, index: number): void {
    // console.log('SERVICE');
    // console.log(answer);
    // console.log('index: ' + index);
    // console.log('    before:');
    // console.log(this.completedTest.Answers);
    // console.log(this.completedTest.Answers[index]);
    // console.log(this.completedTest.Answers.length <= this.numOfQuestions &&
    //   this.completedTest.Answers.length >= index);
    // console.log(this.completedTest.Answers.length + '<=' + this.numOfQuestions);
    // console.log(this.numOfQuestions + '>=' + index);
    if (this.numOfQuestions >= index) {
      this.completedTest.Answers[index] = answer;
      // console.log('    after:')
      // console.log(this.completedTest.Answers);
      // console.log(this.completedTest.Answers[index]);
    }
    //console.log('SERVICE ENDS');
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
      StartTime: null,
      EndTime: null,
      Answers: []
    }
  }

  answerExists(quesInd: number, optIndex): boolean {
    if (!this.completedTest.Answers[quesInd - 1]) {
      console.log('false from service')
      return false;
    }      
    return this.completedTest.Answers[quesInd - 1].OptionIndex == optIndex;;
  }


  authHeader: HttpHeaders = new HttpHeaders({
    'Authorization':'Bearer ' + localStorage.getItem('accessToken')
  });

  sendCompletedTest() {
    console.log('send completed test');
    console.log(this.completedTest);
    return this.http.post('api/TestStat', this.completedTest, { headers: this.authHeader });
  }

}
