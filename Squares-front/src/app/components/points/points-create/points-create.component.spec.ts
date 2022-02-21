import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PointsCreateComponent } from './points-create.component';

describe('PointsCreateComponent', () => {
  let component: PointsCreateComponent;
  let fixture: ComponentFixture<PointsCreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PointsCreateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PointsCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
