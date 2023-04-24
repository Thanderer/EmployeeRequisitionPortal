import { Component, OnInit } from '@angular/core';
import { RequistionApiService } from '../services/requistion-api.service';
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';

@Component({
  selector: 'app-budget-allocator',
  templateUrl: './budget-allocator.component.html',
  styleUrls: ['./budget-allocator.component.css']
})
export class BudgetAllocatorComponent implements OnInit {
  budgets: any;



  constructor(private _apiservie:RequistionApiService,private router: Router) { }

  ngOnInit(): void {
    this._apiservie.getAll(`RequisitionForm/GetAllForm`).subscribe((res: any)=>{
      this.budgets=res;
    })

  }
  navigate(id : string){
    this.router.navigate(['/view/' + id]);
  }

}
