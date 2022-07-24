import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LecturersListComponent } from './lecturers-list.component';

describe('LecturersListComponent', () => {
  let component: LecturersListComponent;
  let fixture: ComponentFixture<LecturersListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LecturersListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LecturersListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
