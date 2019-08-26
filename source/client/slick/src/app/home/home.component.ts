import { Component, OnInit } from '@angular/core';
import { ConsultantService } from '../services/consultant.service';
import Consultant from '../models/consultant';
import { Router } from '@angular/router';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  consultants:Consultant[];

  constructor(
    private consultantService:ConsultantService,
    private router: Router
    ) { }

  ngOnInit() {
    this.consultantService.loadConsultants()
    .subscribe((response) =>{
      this.consultants = response;
    })
  }

  onClickConsultant(c){
    this.router.navigate([`/consultant/${c.id}`])
  }
}
