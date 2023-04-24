import { Component, OnInit } from '@angular/core';
import { RequistionApiService } from '../services/requistion-api.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
@Component({
  selector: 'app-requistion-requests',
  templateUrl: './requistion-requests.component.html',
  styleUrls: ['./requistion-requests.component.css']
})
export class RequistionRequestsComponent implements OnInit {
  title = "apidata";
  newdata: any;

  constructor(private _apiservie:RequistionApiService, private router: Router
    ) { }

  ngOnInit(): void {
    this._apiservie.getAll(`RequisitionForm/GetAllForm`).subscribe((res: any)=>{
      this.newdata=res;
    })

  }
    navigate(id : number){
      this.router.navigate(['/details/' + id]);
    }
}
