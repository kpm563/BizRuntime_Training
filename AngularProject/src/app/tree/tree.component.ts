import { Component, OnInit } from '@angular/core';
import * as d3 from 'd3';
//import { jsonServices } from './json.service';
import{Http, Response, Headers} from '@angular/http';
import 'rxjs/add/operator/toPromise';


@Component({
  selector: 'app-tree',
  templateUrl: './tree.component.html',
  styleUrls: ['./tree.component.css']
})
export class TreeComponent implements OnInit {
  

  constructor(private http:Http) { }

  ngOnInit() {  }

}
