import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import {routes} from './app.router';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { RegistrationComponent } from './registration/registration.component';
import { ObservablesComponent } from './observables/observables.component';
import { DataBindingComponent } from './data-binding/data-binding.component';
import { ClusterComponent } from './cluster/cluster.component';
import { Observable1Component } from './observable1/observable1.component';

import {ExampleService} from './service/service.services';

import {FormsModule} from '@angular/forms';
import { EasingComponent } from './easing/easing.component';
import { PiechartComponent } from './piechart/piechart.component';
import { ServiceComponent } from './service/service.component';
import { BarchartComponent } from './barchart/barchart.component';
import { TreeComponent } from './tree/tree.component';
import {HttpModule} from '@angular/http';
import { CrudComponent } from './crud/crud.component';
import { CrudproductComponent } from './crudproduct/crudproduct.component';
import { CrudUpdateComponent } from './crud-update/crud-update.component';




@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    RegistrationComponent,
    ObservablesComponent,
    DataBindingComponent,
    ClusterComponent, 
    Observable1Component, 
    EasingComponent, 
    PiechartComponent, 
    ServiceComponent, 
    BarchartComponent, 
    TreeComponent, 
    CrudComponent, 
    CrudproductComponent, 
    CrudUpdateComponent
  ],
  imports: [
    BrowserModule,HttpModule,
    routes,FormsModule
  ],
  providers: [ExampleService],
  bootstrap: [AppComponent]
})
export class AppModule { }
