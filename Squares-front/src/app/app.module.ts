import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule} from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PointsComponent } from './components/points/points/points.component';
import { FormsModule } from '@angular/forms';
import { PointsListComponent } from './components/points/points-list/points-list.component';
import { PointsCreateComponent } from './components/points/points-create/points-create.component';
import { NamedListComponent } from './components/named-list/named-list/named-list.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';


@NgModule({
  declarations: [
    AppComponent,
    PointsComponent,
    PointsListComponent,
    PointsCreateComponent,
    NamedListComponent    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    NgbModule,     
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
