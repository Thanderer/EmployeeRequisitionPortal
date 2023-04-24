import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { RequistionApiService } from '../services/requistion-api.service';

@Component({
  selector: 'app-requsition-form',
  templateUrl: './requsition-form.component.html',
  styleUrls: ['./requsition-form.component.css']
})
export class RequsitionFormComponent implements OnInit {

  requisitionForm!:FormGroup
  constructor(private fb:FormBuilder,private apiService:RequistionApiService
    ) { }

  ngOnInit(): void {
    this.requisitionForm = this.fb.group({
      jobTitle: ['', Validators.required],
      description: ['', Validators.required],
      department:['', Validators.required],
      primarySkills: ['', Validators.required],
      secondarySkills: ['', Validators.required],
      numberOfEmployees: ['', Validators.required],
      experienceNeeded: ['', Validators.required],

    });
  }

  onSubmit(){
    if(this.requisitionForm.valid){
      // console.log(this.requisitionForm)
      this.RaiseRequisition();

    }
    else{
      this.validateAllFormFileds(this.requisitionForm);
    }
  }
  RaiseRequisition(){
    this.apiService.create(`RequisitionForm`,this.requisitionForm.value).subscribe(res=>{
      this.requisitionForm.reset();
    });
  }

  validateAllFormFileds(formGroup:FormGroup){
    Object.keys(formGroup.controls).forEach(field =>{
      const control = formGroup.get(field);
      if(control instanceof FormControl){
        control.markAsDirty({onlySelf:true});
      }
      else if(control instanceof FormGroup){
        this.validateAllFormFileds(control);
      }
    }
  )}
}
