import {ModuleWithProviders } from '@angular/core';
import {Routes, RouterModule } from '@angular/router';

import {AppComponent} from './app.component';
import {HomeComponent} from './home/home.component';
import {RegistrationComponent} from './registration/registration.component';
import {ObservablesComponent} from './observables/observables.component';
import {DataBindingComponent} from './data-binding/data-binding.component';
import {ClusterComponent} from './cluster/cluster.component';
import {Observable1Component} from './observable1/observable1.component';
import { EasingComponent } from './easing/easing.component';
import {PiechartComponent} from './piechart/piechart.component';
import {ServiceComponent} from './service/service.component';
import {BarchartComponent} from './barchart/barchart.component';
import {TreeComponent} from './tree/tree.component';
import{CrudComponent} from './crud/crud.component';
import {CrudproductComponent} from './crudproduct/crudproduct.component';
import {CrudUpdateComponent} from './crud-update/crud-update.component';
import{BubblechartComponent} from './bubblechart/bubblechart.component';
import {LifecycleComponent} from './lifecycle/lifecycle.component';



export const router: Routes = [
    {path:'index', component:AppComponent},
    {path:'home', component:HomeComponent},
    {path:'registration', component:RegistrationComponent},
    {path:'observables', component:ObservablesComponent},
    {path:'data-binding', component:DataBindingComponent},
    {path:'cluster', component:ClusterComponent},
    {path:'observable1', component:Observable1Component},
    {path:'easing', component:EasingComponent},
    {path:'piechart', component:PiechartComponent},
    {path:'services', component:ServiceComponent},
    {path:'barchart', component:BarchartComponent},
    {path:'tree', component:TreeComponent},
    {path:'crud', component:CrudComponent},
    {path:'crudproduct', component:CrudproductComponent},
    {path:'crudupdate/:id', component:CrudUpdateComponent},
    {path:'bubble', component:BubblechartComponent},
    {path:'lifecycle', component:LifecycleComponent}
    
];

export const routes : ModuleWithProviders=RouterModule.forRoot(router);
