import { Component, OnInit } from '@angular/core';
import * as d3 from 'd3';
import { DATA } from './dataFile';

@Component({
  selector: 'app-barchart',
  templateUrl: './barchart.component.html',
  styleUrls: ['./barchart.component.css']
})
export class BarchartComponent implements OnInit {

  title = 'Bar Chart';
  private width: number;
  private height: number;
  private margin = {top: 20, right: 20, bottom: 30, left: 40};

  private x: any;
  private y: any;
  private svg: any;
  private group: any;


  constructor() { }

 ngOnInit() {
    this.createBarChart();
  }

  private createBarChart(){
    this.svg = d3.select("svg");
    this.width = +this.svg.attr("width") - this.margin.left - this.margin.right;
    this.height = +this.svg.attr("height") - this.margin.top - this.margin.bottom;
    this.group = this.svg.append("g")
                     .attr("transform", "translate(" + this.margin.left + "," + this.margin.top + ")");
    
    
    this.x = d3.scaleBand().rangeRound([0, this.width]).padding(0.1);
    this.y = d3.scaleLinear().rangeRound([this.height, 0]);
    this.x.domain(DATA.map((d) => d.letter));
    this.y.domain([0, d3.max(DATA, (d) => d.frequency)]);

    this.group.append("g")
      .attr("class", "axis axis--x")
      .attr("transform", "translate(0," + this.height + ")")
      .call(d3.axisBottom(this.x));
    this.group.append("g")
      .attr("class", "axis axis--y")
      .call(d3.axisLeft(this.y).ticks(10, "%"))
      .append("text")
      .attr("class", "axis-title")
      .attr("transform", "rotate(-90)")
      .attr("y", 6)
      .attr("dy", "0.71em")
      .attr("text-anchor", "end")
      .text("Frequency");

    this.group.selectAll(".bar")
      .data(DATA)
      .enter().append("rect")
      .attr("class", "bar")
      .attr("x", (d) => this.x(d.letter) )
      .attr("y", (d) => this.y(d.frequency) )
      .attr("width", this.x.bandwidth())
      .attr("height", (d) => this.height - this.y(d.frequency) );
  } 
}
