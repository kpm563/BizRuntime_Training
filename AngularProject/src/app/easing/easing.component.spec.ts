import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EasingComponent } from './easing.component';

describe('EasingComponent', () => {
  let component: EasingComponent;
  let fixture: ComponentFixture<EasingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EasingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EasingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
