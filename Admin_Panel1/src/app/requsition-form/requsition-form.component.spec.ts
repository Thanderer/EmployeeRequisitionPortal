import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RequsitionFormComponent } from './requsition-form.component';

describe('RequsitionFormComponent', () => {
  let component: RequsitionFormComponent;
  let fixture: ComponentFixture<RequsitionFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RequsitionFormComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RequsitionFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
