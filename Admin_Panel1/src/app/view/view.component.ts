import { Component, OnInit } from '@angular/core';
import { RequistionApiService } from '../services/requistion-api.service';
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
// import { addBudget } from '../models/status';


@Component({
  selector: 'app-view',
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.css']
})
export class ViewComponent implements OnInit {
  addBudget!: FormGroup
  Id!: any;
  detailview: any;
  // budget!: addBudget;
  constructor(private _apiservie: RequistionApiService, private activeParms: ActivatedRoute, private router: Router, private fb: FormBuilder) { }

  ngOnInit(): void {
    this.Id = this.activeParms.snapshot.paramMap.get("id");
    this.addBudget = this.fb.group({
      budgetLowerRange: ['', Validators.required],
      budgetUpperRange: ['', Validators.required],
      id: [this.Id],
    })
    this._apiservie.getById(this.Id).subscribe((res: any) => {
      this.detailview = res;
    })
  }
  onSubmit() {
    if (this.addBudget.valid) {
      // console.log(this.requisitionForm)
      this.addbudget();
      // this.navigate();
    }
    else {
      this.validateAllFormFileds(this.addBudget);
    }
  }
  addbudget() {
    this._apiservie.update(`RequisitionForm/addBudget`, this.addBudget.value).subscribe(res => {
      this.navigate();
    });
  }
  navigate() {
    this.router.navigate(['/acquistion']);
  }
  validateAllFormFileds(formGroup: FormGroup) {
    Object.keys(formGroup.controls).forEach(field => {
      const control = formGroup.get(field);
      if (control instanceof FormControl) {
        control.markAsDirty({ onlySelf: true });
      }
      else if (control instanceof FormGroup) {
        this.validateAllFormFileds(control);
      }
    }
    )
  }
}





