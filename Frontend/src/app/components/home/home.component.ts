import { Component, OnInit } from '@angular/core';
import { TestCategoryService } from '../../services/test-category.service';
import { TestCategoryModel } from '../../models/test-category-model';
import { TestService } from '../../services/test.service';
import { TestModel } from '../../models/test-model';
import { TestStatModel } from '../../models/test-statistic-model';
import { TestStatService } from '../../services/test-stat.service';
import { QuestionService } from '../../services/question.service';
import { QuestionModel } from '../../models/question-model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  testStatistics: TestStatModel;
  errorMessage: string = '';

  questions: QuestionModel;

  constructor(private testStatService: TestStatService) { }

  ngOnInit() {
    this.getTestStatsWithRelatedTestsOfCurrUser();
  }

  getTestStatsWithRelatedTestsOfCurrUser() {
    this.testStatService.getTestStatsWithRelatedTestsOfCurrUser().subscribe(
      res => {
        this.testStatistics = res      
      },
      error => this.errorMessage = error.message
    );
  }

}
