import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TestModel } from '../../models/test-model';
import { TestService } from '../../services/test.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-test-category-details',
  templateUrl: './test-category-details.component.html',
  styleUrls: ['./test-category-details.component.css']
})
export class TestCategoryDetailsComponent implements OnInit {

  tests: TestModel = null;
  errorMessage: string = '';

  constructor(private testService: TestService,
              private route: ActivatedRoute,
              private location: Location) { }

  ngOnInit() {
    this.getCategoryTests();
  }

  getCategoryTests() {
    const id = +this.route.snapshot.paramMap.get('id');
    this.testService.getTestsByCategoryId(id)
      .subscribe(
        data => this.tests = data,
        error => this.errorMessage = error.message
      );
  }

  onBtnClickGoBack() {
    this.location.back();
  }

}
