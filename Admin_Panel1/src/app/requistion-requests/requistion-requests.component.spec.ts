import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RequistionRequestsComponent } from './requistion-requests.component';

describe('RequistionRequestsComponent', () => {
  let component: RequistionRequestsComponent;
  let fixture: ComponentFixture<RequistionRequestsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RequistionRequestsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RequistionRequestsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
