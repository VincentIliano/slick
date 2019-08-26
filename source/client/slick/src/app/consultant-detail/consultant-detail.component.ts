import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import Consultant from '../models/consultant';
import { ConsultantService } from '../services/consultant.service';

@Component({
  selector: 'app-consultant-detail',
  templateUrl: './consultant-detail.component.html',
  styleUrls: ['./consultant-detail.component.scss']
})
export class ConsultantDetailComponent implements OnInit {

  consultantId:string;
  consultant:Consultant;

  constructor(
    private route:ActivatedRoute,
    private consultantService:ConsultantService
  ) { }

  ngOnInit() {

    this.route.params.subscribe(params => {
      this.consultantId = params['id'];
      
      this.consultantService.getById(this.consultantId)
      .subscribe(response => {
        this.consultant = response;
        console.log(this.consultant);
      })
    })
  }

}
