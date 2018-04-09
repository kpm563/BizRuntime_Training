import { Component, OnInit } from '@angular/core';
import {ExampleService} from './service.services';

@Component({
  selector: 'app-service',
  templateUrl: './service.component.html',
  styleUrls: ['./service.component.css']
})
export class ServiceComponent implements OnInit {

  title:string;

  constructor(private _exampleService:ExampleService) { }

  ngOnInit() {
    this.title=this._exampleService.serviceMethod();
  }

}
