import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TestCategoryDetailsComponent } from './test-category-details.component';

describe('TestCategoryDetailsComponent', () => {
  let component: TestCategoryDetailsComponent;
  let fixture: ComponentFixture<TestCategoryDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TestCategoryDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TestCategoryDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
