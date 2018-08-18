import { Component, OnInit } from '@angular/core';
import { QuestionService } from '../../services/question.service';
import { QuestionModel } from '../../models/question-model';
import { Route, ActivatedRoute } from '../../../../node_modules/@angular/router';
import { TestStatService } from '../../services/test-stat.service';
import { AnswerModel } from '../../models/answer-model';
import { Location } from '@angular/common';

@Component({
  selector: 'app-extended-stat',
  templateUrl: './extended-stat.component.html',
  styleUrls: ['./extended-stat.component.css']
})
export class ExtendedStatComponent implements OnInit {

  questions: QuestionModel;
  answers: AnswerModel;
  errorMessage: string;

  constructor(private questionService: QuestionService,
              private route: ActivatedRoute,
              private testStatService: TestStatService,
              private location: Location) { }

  ngOnInit() {
    this.getQuestionsWithOptionsByTestId();
    this.getAnswersByTestStatId();
  }

  getQuestionsWithOptionsByTestId() {
    let testId = +this.route.snapshot.paramMap.get('testId');
    this.questionService.getQuestionsWithOptionsByTestId(testId).subscribe(
      res =>{
        this.questions = res;
      },
      err => this.errorMessage = err.message
    );
  }
  
  getAnswersByTestStatId() {
    let statId = +this.route.snapshot.paramMap.get('statId');
    this.testStatService.getAnswersByTestStatId(statId).subscribe(
      res => {
        this.answers = res;
      },
      err => this.errorMessage = err.message
    );
  }

  onBtnClickGoBack() {
    this.location.back();
  }

}
