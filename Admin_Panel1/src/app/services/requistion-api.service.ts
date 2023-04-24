import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { requisitionForm } from '../models/requistionform';

const baseUrl = `https://localhost:7113/api`;
@Injectable({
  providedIn: 'root'
})


export class RequistionApiService {
  constructor(private http: HttpClient) {

  }

  getdata() {
    throw new Error('Method not implemented.');
  }



  getAll(apiName:string) {
    return this.http.get<requisitionForm[]>(`${baseUrl}/${apiName}`);
  }

  getById(id: number) {
    return this.http.get<requisitionForm>(`${baseUrl}/RequisitionForm/${id}`);
  }

  create(apiName: string,params: any) {
    return this.http.post(`${baseUrl}/${apiName}`, params);
  }

  update(apiName:string, params: any) {
    return this.http.put<any>(`${baseUrl}/${apiName}`, params);
  }

  delete(apiName:string,id: string) {
    return this.http.delete(`${baseUrl}/${apiName}/${id}`);
  }
}
