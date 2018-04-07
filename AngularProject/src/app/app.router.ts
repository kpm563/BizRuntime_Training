import {ModuleWithProviders } from '@angular/core';
import {Routes, RouterModule } from '@angular/router';

import {AppComponent} from './app.component';
import {HomeComponent} from './home/home.component';
import {RegistrationComponent} from './registration/registration.component';
import {ObservablesComponent} from './observables/observables.component';
import {DataBindingComponent} from './data-binding/data-binding.component';
import {ClusterComponent} from './cluster/cluster.component';
import {Observable1Component} from './observable1/observable1.component'


export const router : Routes=[
    {path:'index', component:AppComponent},
    {path:'home', component:HomeComponent}, 
    {path:'registration', component:RegistrationComponent},
    {path:'observables', component:ObservablesComponent},
    {path:'data-binding', component:DataBindingComponent},  
    {path:'cluster', component:ClusterComponent},
    {path:'observable1', component:Observable1Component}
];

export const routes : ModuleWithProviders=RouterModule.forRoot(router);