import { TestBed, inject } from '@angular/core/testing';

import { TestStatService } from './test-stat.service';

describe('TestStatService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TestStatService]
    });
  });

  it('should be created', inject([TestStatService], (service: TestStatService) => {
    expect(service).toBeTruthy();
  }));
});
