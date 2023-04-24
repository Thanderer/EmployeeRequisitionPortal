import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisterdFormComponent } from './registerd-form.component';

describe('RegisterdFormComponent', () => {
  let component: RegisterdFormComponent;
  let fixture: ComponentFixture<RegisterdFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RegisterdFormComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RegisterdFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
