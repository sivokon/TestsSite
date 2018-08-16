import { TestBed, inject } from '@angular/core/testing';

import { TestDetailsQuestionDataService } from './test-details-question-data.service';

describe('TestDetailsQuestionDataService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TestDetailsQuestionDataService]
    });
  });

  it('should be created', inject([TestDetailsQuestionDataService], (service: TestDetailsQuestionDataService) => {
    expect(service).toBeTruthy();
  }));
});
