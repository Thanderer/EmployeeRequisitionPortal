import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AcquisitionTeamComponent } from './acquisition-team.component';

describe('AcquisitionTeamComponent', () => {
  let component: AcquisitionTeamComponent;
  let fixture: ComponentFixture<AcquisitionTeamComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AcquisitionTeamComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AcquisitionTeamComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
