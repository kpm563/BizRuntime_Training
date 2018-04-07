import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ObservablesHttpComponent } from './observables-http.component';

describe('ObservablesHttpComponent', () => {
  let component: ObservablesHttpComponent;
  let fixture: ComponentFixture<ObservablesHttpComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ObservablesHttpComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ObservablesHttpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
