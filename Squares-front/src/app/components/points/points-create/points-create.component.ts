import { Component, OnInit } from '@angular/core';
import Point from 'src/app/models/point.model';
import { StateService } from 'src/app/services/state.service';

@Component({
  selector: 'app-points-create',
  templateUrl: './points-create.component.html',
  styleUrls: ['./points-create.component.css']
})
export class PointsCreateComponent implements OnInit {
  public xCoord: number = 0;
  public yCoord: number = 0;


  constructor(private stateService:StateService) { }

  ngOnInit(): void {
  }
  public addPoint(){ //cheap validation
    if(this.xCoord >= -5000 && this.xCoord <= 5000 &&
      this.yCoord >= -5000 && this.yCoord <= 5000){

      let point: Point = {
        xCoord: this.xCoord,
        yCoord: this.yCoord
      }
      this.stateService.add(point);
    }
  }

}
