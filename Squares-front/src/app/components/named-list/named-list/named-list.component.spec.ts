import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NamedListComponent } from './named-list.component';

describe('NamedListComponent', () => {
  let component: NamedListComponent;
  let fixture: ComponentFixture<NamedListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NamedListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NamedListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
