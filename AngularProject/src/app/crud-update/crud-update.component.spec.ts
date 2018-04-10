import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CrudUpdateComponent } from './crud-update.component';

describe('CrudUpdateComponent', () => {
  let component: CrudUpdateComponent;
  let fixture: ComponentFixture<CrudUpdateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CrudUpdateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CrudUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
