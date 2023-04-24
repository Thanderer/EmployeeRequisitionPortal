import { Component, OnInit } from '@angular/core';
import { RequistionApiService } from '../services/requistion-api.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-acquisition-team',
  templateUrl: './acquisition-team.component.html',
  styleUrls: ['./acquisition-team.component.css']
})
export class AcquisitionTeamComponent implements OnInit {
  acquisition: any;

  constructor(private _apiservie:RequistionApiService,private router: Router) { }

  ngOnInit(): void {
    this._apiservie.getAll(`RequisitionForm/GetAllForm`).subscribe((res: any)=>{
      this.acquisition=res;
    })
  }
  navigate(id : number){
    this.router.navigate(['/view/' + id]);
  }
}
