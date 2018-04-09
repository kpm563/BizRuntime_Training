import { Component, OnInit } from '@angular/core';
import {Observable} from 'rxjs/Observable';
import * as d3 from 'd3';


@Component({
  selector: 'app-observables',
  templateUrl: './observables.component.html',
  styleUrls: ['./observables.component.css']
})
export class ObservablesComponent implements OnInit {

  private data:any;

  constructor() {

   this.data = new Observable(observer=>{
    setTimeout(()=>{
      observer.next(21);
    },2000);

    setTimeout(()=>{
      observer.next(22);
    },2000);

    setTimeout(()=>{
      observer.complete();
    },2000);

   });

   let subscriber = this.data.subscribe(
    value=> console.log(value),
    err=>console.log(err),
    ()=>console.log("done")
   );

   let obs = Observable.interval(1000).take(10);
   let firstSub = obs.subscribe(x=>console.log("First Sub :: " + x));
   //let secondSub = obs.subscribe(x=>console.log("Second Sub :: " + x));
   let newObs = Observable.interval(1000).take(5).flatMap(x=>Observable.timer(500).map(()=>x*5));

  }

  ngOnInit() {
  }






}
