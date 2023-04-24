import { Component, OnInit } from '@angular/core';
import { RequistionApiService } from '../services/requistion-api.service';
import { ActivatedRoute, Router } from '@angular/router';
import { status } from '../models/status';


@Component({
  selector: 'app-registerd-form',
  templateUrl: './registerd-form.component.html',
  styleUrls: ['./registerd-form.component.css']
})
export class RegisterdFormComponent implements OnInit {
  title = "apidata";
  detail: any;
  Id!: any;
  route: any;
  isAddMode: boolean | undefined;
  data: any;
  stringJson: any;
  stringObject: any;
  status!: status;

  listUsers = []
  jsonResponse: any;
  constructor(private _apiservie:RequistionApiService, private activeParms: ActivatedRoute,private router: Router
    ) { }

  ngOnInit(): void {
    this.Id = this.activeParms.snapshot.paramMap.get("id");
    this.status.id = this.Id;
    this._apiservie.getById(this.Id).subscribe((res: any)=>{
      this.detail=res;

    })

  }

  onAccept(acceptId:number){
    this.status.statusId = acceptId;
    this._apiservie.update(`RequiitionForm/updateStatus`,this.status).subscribe(res=>{
      this.navigate('/budget');
    });
  }
  onClearify(){

  }
  onReject(){
    this.status.statusId = 1004;
    this._apiservie.update(`RequiitionForm/updateStatus`,this.status).subscribe(res=>{
      this.navigate('/requests');
    });
  }

  navigate(route:string) {
    this.router.navigate([route]);
  }
}
