import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import CreateNamedList from 'src/app/models/create-named-list.model';
import NamedList from '../models/named-list.model';
import Point from '../models/point.model';
import { NamedListService } from './named-list.service';
import { PointsService } from './points.service';

@Injectable({
  providedIn: 'root'
})
export class StateService {
  public points$ = new BehaviorSubject<Point[]>([]);
  public lists$ = new BehaviorSubject<NamedList[]>([]);

  private points: Point[] = [];
  private lists: NamedList[] = [];

  constructor(private pointsService: PointsService, 
    private namedListService: NamedListService) { }

  public loadAll() {
      this.namedListService.getAll().subscribe((lists) => {
      this.lists = lists;
      this.lists$.next(this.lists);
    })
  }
  
  public loadByList(id: number) {
    this.pointsService.getByList(id).subscribe((points)=>{
      this.points = points;
      this.points$.next(this.points);
    })
  }  
  public deleteList(listId: number) {
    this.namedListService.deleteList(listId).subscribe(result => {
      console.log(result)
    },
    () => {
    });
      this.lists = this.lists.filter((t) => t.id != listId);
      this.lists$.next(this.lists);
    
  }

  public add(point: Point) {

    if (!this.points.find(a => a.xCoord === point.xCoord && a.yCoord === point.yCoord) && this.points.length <=10000) {
      this.points.push(point);
      this.points$.next(this.points);
    }
  }

  public clear(xCoord: number, yCoord: number) {
    this.points = this.points.filter((t) => t.xCoord != xCoord || t.yCoord != yCoord);
    this.points$.next(this.points);
  }
  public clearAll() {
    this.points.splice(0, this.points.length)
    this.points$.next(this.points);
  }

  public saveList(pointList: Point[], listname:CreateNamedList) {
    this.namedListService.create(listname).subscribe((listId) => {
      let list: NamedList={
        id: listId,
        name: listname.name
      }
      this.lists = this.lists.filter((t) => t.name != listname.name);
      this.lists.push(list); 
      this.lists$.next(this.lists);
      this.namedListService.update(listId, pointList).subscribe(()=>{
      });
    })
  }
}
