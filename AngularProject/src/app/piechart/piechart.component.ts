import { Component, OnInit } from '@angular/core';
import * as d3 from 'd3';

import {Stats} from './dataFile';

@Component({
  selector: 'app-piechart',
  templateUrl: './piechart.component.html',
  styleUrls: ['./piechart.component.css']
})
export class PiechartComponent implements OnInit {  
  subtitle: string = 'Pie Chart';

  private margin = {top: 20, right: 20, bottom: 30, left: 50};
  private width: number;
  private height: number;
  private radius: number;

  private arc: any;
  private labelArc: any;
  private pie: any;
  private color: any;
  private svg: any;

  constructor() {
    this.width = 900 - this.margin.left - this.margin.right;
    this.height = 500 - this.margin.top - this.margin.bottom;
    this.radius = Math.min(this.width, this.height) / 2;
  }

  ngOnInit() {    
    this.createPieChart();
  }

  private createPieChart(){
    this.color = d3.scaleOrdinal()
        .range(["orange", "pink", "yello", "green", "tomato", "blue", "red"]);
    this.arc = d3.arc()
        .outerRadius(this.radius - 10)
        .innerRadius(0);
    this.labelArc = d3.arc()
        .outerRadius(this.radius - 40)
        .innerRadius(this.radius - 40);
    this.pie = d3.pie()
        .sort(null)
        .value((d: any) => d.population);
    this.svg = d3.select("svg")
        .append("g")
        .attr("transform", "translate(" + this.width / 2 + "," + this.height / 2 + ")");

    let g = this.svg.selectAll(".arc")
                    .data(this.pie(Stats))
                    .enter().append("g")
                    .attr("class", "arc");
    g.append("path").attr("d", this.arc)
                    .style("fill", (d: any) => this.color(d.data.age) );
    g.append("text").attr("transform", (d: any) => "translate(" + this.labelArc.centroid(d) + ")")
                    .attr("dy", ".35em")
                    .text((d: any) => d.data.age);
  }
 
}
