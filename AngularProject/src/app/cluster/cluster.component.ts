import { Component, OnInit } from '@angular/core';
import * as d3 from "d3";

import {clusterCreate} from './clusterjs';

@Component({
  selector: 'app-cluster',
  templateUrl: './cluster.component.html',
  styleUrls: ['./cluster.component.css']
})
export class ClusterComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  
}
