import { TestBed, inject } from '@angular/core/testing';

import { TestCategoryService } from './test-category.service';

describe('TestCategoryService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TestCategoryService]
    });
  });

  it('should be created', inject([TestCategoryService], (service: TestCategoryService) => {
    expect(service).toBeTruthy();
  }));
});
