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
        console.log('question getted')
        this.optionSerice.getOptionsByQuestionId(this.question.Id).subscribe(
          result => {
            this.options = result,
            console.log('options getted')
          },
          err => this.errorMessage = err.message      
        );
      },
      err => this.errorMessage = err.message
    );

    // forkJoin([questionQuery, optionsQuery])
    //   .subscribe(results => {
    //     this.question = results[0],
    //     this.options = results[1]        
    //   });
  }

  setRadioBtnValue(index: number) {
    let answer: AnswerModel = this.dataService.getAnswerByIndex(this.question.Index - 1);
    if (answer) {
      if (answer.OptionIndex == index) { 
        return true;
      }
    }
    return false;
  }

  onRadioChangeSaveAnswer(optIndex: number): void {
    console.log('saved');
    console.log(optIndex);
    const answer: AnswerModel = {
      QuestionId: this.question.Id,
      OptionIndex: optIndex,
    }
    console.log(answer);
    // console.log('index: ' + (this.question.Index-1));
    //console.log(this.dataService.answers[this.question.Index-1]);
    this.dataService.addAnswerWithIndex(answer, this.question.Index - 1);
    // console.log(this.dataService.completedTest.Answers[this.question.Index -1 ]);
    // console.log(this.dataService.completedTest.Answers);
  }

  onClickFinishTest() {
    this.dataService.completedTest.EndTime = new Date();
    this.dataService.sendCompletedTest().subscribe(
      res => console.log('sent')
    );
  }

}
