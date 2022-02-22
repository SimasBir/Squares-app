import { Component, OnInit } from '@angular/core';
import Point from 'src/app/models/point.model';
import CreateNamedList from 'src/app/models/create-named-list.model';
import { StateService } from 'src/app/services/state.service';
import { saveAs } from 'file-saver';

@Component({
  selector: 'app-points-list',
  templateUrl: './points-list.component.html',
  styleUrls: ['./points-list.component.css']
})
export class PointsListComponent implements OnInit {
  public pointsList: Point[] = [];
  public listName: string = "";

  currentPage = 1;
  itemsPerPage = 5;
  pageSize: number = 0;

  constructor(private stateService: StateService) {
  }

  public onPageChange(pageNum: number): void {
    this.pageSize = this.itemsPerPage * (pageNum - 1);
  }

  public changePagesize(num: number): void {
    this.itemsPerPage = this.pageSize + num;
  }


  ngOnInit(): void {
    this.stateService.loadAll();
    this.stateService.points$.subscribe((pointsData) => {
      this.pointsList = pointsData;
    })
  }
  public removePoint(xCoord: number, yCoord: number) {
    this.stateService.clear(xCoord, yCoord);
  }
  public saveList() {
    let newListName: CreateNamedList = {
      name: this.listName
    }
    this.stateService.saveList(this.pointsList, newListName);
  }
  public clearList() {
    this.stateService.clearAll();
  }
  public exportList() {
    let data = "";
    for (var i = 0; i < this.pointsList.length; i++) {
      data += this.pointsList[i].xCoord.toString() +" "+ this.pointsList[i].yCoord.toString() + '\r';
    }
    // let data2 = JSON.stringify(this.pointsList, null, "/r");
    const blob = new Blob([data], { type: "text/plain;charset=utf-8" });
    if (this.listName != "") {
      saveAs(blob, `${this.listName}.txt`);
    }
    else{
      saveAs(blob, `PointList.txt`);
    }
  }

  // public squareCount(){
  //   let count = 0;
  //   for (var i = 0; i < this.pointsList.length; i++) {

  //   }
  // }
}
