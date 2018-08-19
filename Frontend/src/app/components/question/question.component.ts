import { Component, OnInit, Renderer2, ElementRef, ViewChild, AfterViewInit, ViewChildren, AfterContentChecked, AfterViewChecked, AfterContentInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { QuestionService } from '../../services/question.service';
import { OptionService } from '../../services/option.service';
import { QuestionModel } from '../../models/question-model';
import { OptionModel } from '../../models/option-model';
import { Observable, forkJoin, pipe } from '../../../../node_modules/rxjs';
import { TestDetailsQuestionDataService } from '../../services/test-details-question-data.service';
import { AnswerModel } from '../../models/answer-model';
import { mergeMap, map } from '../../../../node_modules/rxjs/operators';
import { AnswerOption } from '../../models/answer-option';


@Component({
  selector: 'app-question',
  templateUrl: './question.component.html',
  styleUrls: ['./question.component.css']
})
export class QuestionComponent implements OnInit {
  
  question: QuestionModel = null;
  options: OptionModel = null;
  errorMessage: string = null;

  constructor(private route: ActivatedRoute,
              private questionService: QuestionService,
              private optionSerice: OptionService,
              public dataService: TestDetailsQuestionDataService) { }

  ngOnInit() {
    this.getQuestion();
  }

  getQuestion(index: number = 1): void {
    this.options = null;
    let testId = this.dataService.completedTest.TestId;

    this.questionService.getQuestionByIndexAndTestId(index, testId).subscribe(
      result => {
        this.question = result,
        console.log(this.question)
        this.optionSerice.getOptionsByQuestionId(this.question.Id).subscribe(
          result => {
            this.options = result,
            console.log(this.options)
          },
          err => this.errorMessage = err.message      
        );
      },
      err => this.errorMessage = err.message
    );
  }

  setRadioBtnValue(optionId: number) {
    let answer: AnswerModel = this.dataService.getAnswerByIndex(this.question.Index - 1);
    if (answer) {
      if (answer.AnswerOptions[0].OptionId == optionId) { 
        return true;
      }
    }
    return false;
  }

  onRadioChangeSaveAnswer(optionId: number): void {
    let answerOption: AnswerOption = {
      OptionId: optionId
    }
    const answer: AnswerModel = {
      QuestionId: this.question.Id,
      //OptionId: optionId,
      AnswerOptions: [answerOption],
      PointValue: 0
    }
    this.dataService.addAnswerWithIndex(answer, this.question.Index - 1);
  }

  onClickFinishTest() {
    this.dataService.endTime = new Date();
    this.dataService.sendFinishedTestData().subscribe();
  }

}
