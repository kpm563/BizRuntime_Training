import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import {routes} from './app.router';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { RegistrationComponent } from './registration/registration.component';
import { ObservablesComponent } from './observables/observables.component';
import { ObservablesHttpComponent } from './observables-http/observables-http.component';
import { DataBindingComponent } from './data-binding/data-binding.component';
import { ClusterComponent } from './cluster/cluster.component';
import { Observable1Component } from './observable1/observable1.component';

import {FormsModule} from '@angular/forms';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    RegistrationComponent,
    ObservablesComponent,
    ObservablesHttpComponent,
    DataBindingComponent,    
    ClusterComponent, Observable1Component
  ],
  imports: [
    BrowserModule,
    routes,FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
