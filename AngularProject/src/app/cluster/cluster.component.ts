import { Component, OnInit } from '@angular/core';
import * as d3 from "d3";


@Component({
  selector: 'app-cluster',
  templateUrl: './cluster.component.html',
  styleUrls: ['./cluster.component.css']
})

export class ClusterComponent implements OnInit {

  private svg:any;
  private width:number;
  private height:number;
  private group:any;
  private tree:any;
  private stratify:any;
  private root:any;

  private createCluster(){
    this.svg = d3.select("svg");
    this.width = + this.svg.attr("width");
    this.height = + this.svg.attr("height");
    this.group = this.svg.append("g").attr("transform", "translate(40,0)");

    this.tree = d3.cluster()
    .size([this.height, this.width - 160]);

    this.stratify = d3.stratify()
    .parentId(function(d) { return d.id.substring(0, d.id.lastIndexOf(".")); });

    d3.csv("flare.csv", function(error, data) {
      if (error) throw error;

      this.root= this.stratify(data)
      .sort(function(a, b) { return (a.height - b.height) || a.id.localeCompare(b.id); });

      this.tree(this.root);

      let link = this.group.selectAll(".link")
      .data(this.root.descendants().slice(1))
      .enter().append("path")
      .attr("class", "link")
      .attr("d", function(d) {
        return "M" + d.y + "," + d.x
            + "C" + (d.parent.y + 100) + "," + d.x
            + " " + (d.parent.y + 100) + "," + d.parent.x
            + " " + d.parent.y + "," + d.parent.x;
      });

    let node = this.group.selectAll(".node")
      .data(this.root.descendants())
      .enter().append("g")
      .attr("class", function(d) { return "node" + (d.children ? " node--internal" : " node--leaf"); })
      .attr("transform", function(d) { return "translate(" + d.y + "," + d.x + ")"; })

    node.append("circle")
      .attr("r", 2.5);

    node.append("text")
      .attr("dy", 3)
      .attr("x", function(d) { return d.children ? -8 : 8; })
      .style("text-anchor", function(d) { return d.children ? "end" : "start"; })
      .text(function(d) { return d.id.substring(d.id.lastIndexOf(".") + 1); });
      });
  }

  constructor() { }

  ngOnInit() {
    this.createCluster();
  }

}

