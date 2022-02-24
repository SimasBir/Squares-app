import { Component, OnInit } from '@angular/core';
import NamedList from 'src/app/models/named-list.model';
import { StateService } from 'src/app/services/state.service';

@Component({
  selector: 'app-named-list',
  templateUrl: './named-list.component.html',
  styleUrls: ['./named-list.component.css']
})
export class NamedListComponent implements OnInit {
  public namedLists: NamedList[] = [];
  public namedListId: number = 0;
  public namedListName: string = "";
  public showlist: boolean = false;

  constructor(private stateService: StateService) { }

  ngOnInit(): void {
    this.stateService.loadAll();
    this.stateService.lists$.subscribe((listData)=>{
      this.namedLists = listData;
    })
  }
  public getId(){
    let createNamedList: NamedList = {
      id: this.namedListId,
      name: this.namedListName,
    };
    this.stateService.loadByList(this.namedListId);
    this.showlist = true;
  } 
   public deleteId(){
    let createNamedList: NamedList = {
      id: this.namedListId,
      name: this.namedListName,
    };
    this.stateService.deleteList(this.namedListId);
    this.showlist = true;
  }
  public new(){
    this.stateService.clearAll();
    this.showlist = true;
  }

  public import(){
    alert("Vis dar neveikia, sorry")
  //   this.http.get('app/home/1.txt').subscribe(data => {
  //     console.log('data', data.text());
  // })
  }
}
