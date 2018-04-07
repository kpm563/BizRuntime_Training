import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { Observable1Component } from './observable1.component';

describe('Observable1Component', () => {
  let component: Observable1Component;
  let fixture: ComponentFixture<Observable1Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ Observable1Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(Observable1Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
