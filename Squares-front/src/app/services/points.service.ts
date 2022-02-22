import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import Point from '../models/point.model';

@Injectable({
  providedIn: 'root'
})
export class PointsService {

  constructor(private httpClient: HttpClient) { }

  public getAll(): Observable<Point[]> {
    return this.httpClient.get<Point[]>('https://localhost:44368/point');
  }

  // public getByList(id: number):Observable<Point[]> {
  //   return this.httpClient.get<Point[]>(`https://localhost:44368/point/${id}`);
  // }

  public create(pointlist: Point[]): Observable<number> {
    return this.httpClient.post<number>('https://localhost:44368/point', pointlist);
  }

  public delete(Id: number): Observable<any> {
    return this.httpClient.delete<any>(`https://localhost:44368/point/${Id}`);
  }
}