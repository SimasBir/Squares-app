import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import CreateNamedList from 'src/app/models/create-named-list.model';
import NamedList from '../models/named-list.model';
import Point from '../models/point.model';

@Injectable({
  providedIn: 'root'
})
export class NamedListService {

  constructor(private httpClient: HttpClient) { }

  public getAll(): Observable<NamedList[]> {
    return this.httpClient.get<NamedList[]>('https://localhost:44368/namedList');
  }

  public getByList(id: number):Observable<Point[]> {
    return this.httpClient.get<Point[]>(`https://localhost:44368/namedList/${id}/point`);
  }

  public create(listName: CreateNamedList): Observable<number> {
    return this.httpClient.post<number>('https://localhost:44368/namedList', listName);
  }
  public update(listId: number, pointlist: Point[] ): Observable<any> {
    return this.httpClient.put<any>(`https://localhost:44368/namedList/${listId}`, pointlist);
  }

  public deleteList(Id: number): Observable<any> {
    return this.httpClient.delete<any>(`https://localhost:44368/namedList/${Id}`);
  }
}