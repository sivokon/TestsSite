import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ExtendedStatComponent } from './extended-stat.component';

describe('ExtendedStatComponent', () => {
  let component: ExtendedStatComponent;
  let fixture: ComponentFixture<ExtendedStatComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ExtendedStatComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ExtendedStatComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
