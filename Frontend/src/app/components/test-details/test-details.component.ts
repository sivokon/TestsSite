import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TestModel } from '../../models/test-model';
import { TestService } from '../../services/test.service';
import { QuestionService } from '../../services/question.service';
import { forkJoin, timer, interval } from '../../../../node_modules/rxjs';
import { TestDetailsQuestionDataService } from '../../services/test-details-question-data.service';
import { takeWhile } from 'rxjs/operators';

@Component({
  selector: 'app-test-details',
  templateUrl: './test-details.component.html',
  styleUrls: ['./test-details.component.css']
})
export class TestDetailsComponent implements OnInit {

  test: TestModel = null;
  errorMessage: string = '';
  time = {
    min: 0,
    sec: 0
  }

  constructor(private testService: TestService,
              private route: ActivatedRoute,
              private questionService: QuestionService,
              public dataService: TestDetailsQuestionDataService) { }

  ngOnInit() {
    this.dataService.resetTest();
    this.getTest();
  }

  getTest() {
    const id = +this.route.snapshot.paramMap.get('id');    

    let getTestQuery = this.testService.getTestById(id);
    let getQuestionsQuery = this.questionService.getQuestionsByTestId(id);

    forkJoin([getTestQuery, getQuestionsQuery]).subscribe(
      (result: any) => {
        this.test = result[0],
        this.dataService.numOfQuestions = result[1].length
      },
      error => this.errorMessage = error.message
    );
  }

  onClickStartTest(): void {
    this.dataService.completedTest.TestId = +this.route.snapshot.paramMap.get('id');
    this.dataService.completedTest.StartTime = new Date();
    this.startTimer();
  }

  startTimer() {
    this.time.min = this.test.DurationMin;
    let testDurSec = this.time.min * 60;

    interval(1000)
      .pipe( takeWhile(val => val < testDurSec) )
      .subscribe(
        () => {
          if (this.time.sec == 0) {
            this.time.min--;
            this.time.sec = 59;
          } else {
            this.time.sec--;
          }
        },
        () => {
          this.dataService.completedTest.EndTime = new Date();
          this.dataService.sendCompletedTest();
        });
  }

  private testIsNotStarted(): boolean {
    return this.dataService.completedTest.StartTime == null && 
           this.dataService.completedTest.EndTime == null;
  }

  private testStarted(): boolean {
    return this.dataService.completedTest.StartTime != null && 
           this.dataService.completedTest.EndTime == null;
  }

  private testFinished(): boolean {
    return this.dataService.completedTest.StartTime != null && 
           this.dataService.completedTest.EndTime != null;
  }

}
