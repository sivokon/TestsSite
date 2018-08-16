import { Component, OnInit } from '@angular/core';
import { TestCategoryModel } from '../../models/test-category-model';
import { TestCategoryService } from '../../services/test-category.service';
import { TestService } from '../../services/test.service';

@Component({
  selector: 'app-test-categories',
  templateUrl: './test-categories.component.html',
  styleUrls: ['./test-categories.component.css']
})
export class TestCategoriesComponent implements OnInit {

  testCategories: TestCategoryModel = null;
  errorMessage: string = '';

  constructor(private testCategoryService: TestCategoryService) { }

  ngOnInit() {
    this.testCategoryService.getTestCategories()
    .subscribe(
        data => this.testCategories = data,
        error => this.errorMessage = error.message
    )
  }

}
