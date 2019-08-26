import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import AppSettings from '../appSettings';
import Consultant from '../models/consultant';
import {map} from 'rxjs/operators'

@Injectable({
  providedIn: 'root'
})
export class ConsultantService {

  constructor(
    private http: HttpClient) { }


  loadConsultants() {
    return this.http.get<Consultant>(AppSettings.CONSULTANTS_API_URL)
      .pipe(
        map((response: any) => {
          let consultants:Consultant[] = [];

          for(let i = 0, l = response.length; i < l; i++){
            let c = response[i];
            let newC = new Consultant(c.id, `${c.firstname} ${c.lastname}`, c.email);
            consultants.push(newC);
          }
          return consultants;
        })
      )
  }

  getById(id:string){
    return this.http.get(`${AppSettings.CONSULTANTS_API_URL}/${id}`)
    .pipe(
      map((response:any)=>{
        console.log(response);
        return new Consultant(id, `${response.firstName} ${response.lastName}`, response.email);
      })
    )
  }

}