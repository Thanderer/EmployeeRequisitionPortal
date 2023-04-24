import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BudgetAllocatorComponent } from './budget-allocator.component';

describe('BudgetAllocatorComponent', () => {
  let component: BudgetAllocatorComponent;
  let fixture: ComponentFixture<BudgetAllocatorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BudgetAllocatorComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BudgetAllocatorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
