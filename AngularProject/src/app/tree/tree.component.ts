import { Component, OnInit } from '@angular/core';
import * as d3 from 'd3';
//import { jsonServices } from './json.service';


@Component({
  selector: 'app-tree',
  templateUrl: './tree.component.html',
  styleUrls: ['./tree.component.css']
})
export class TreeComponent implements OnInit {

  private margin :any;
  private i:number;
  private diagonal:any;
  private svg:any;
  private width:number;
  private height :number;
  private barHeight:number;
  private barWidth:number;
  private duration :any;
  private root:any;
  private nodes :any;
  private index:number;
  private node:any;
  private nodeEnter :any;
  private link:any;


  private createCollapsibleTree(){
    this.margin={top: 30, right: 20, bottom: 30, left: 20};
    this.width = 960;
    this.barHeight = 20;
    this.barWidth = (this.width - this.margin.left - this.margin.right) * 0.8;

    this.i = 0;
    this.duration = 400;

    this.diagonal = d3.linkHorizontal()
      .x(function(d) { return d.y; })
      .y(function(d) { return d.x; });

    this.svg = d3.select("body").append("svg")
      .attr("width", this.width) // + margin.left + margin.right)
      .append("g")
      .attr("transform", "translate(" + this.margin.left + "," + this.margin.top + ")");

    d3.json("flare.json", function(error, flare) {
      if (error) throw error;

      this.root = d3.hierarchy(flare);
      this.root.x0 = 0;
      this.root.y0 = 0;
      this.update(this.root);
    });
  }

  
  private update(source){
    // Compute the flattened node list.
    this.nodes = this.root.descendants();
    this.height = Math.max(500, this.nodes.length * this.barHeight + this.margin.top + this.margin.bottom);
    d3.select("svg").transition()
      .duration(this.duration)
      .attr("height", this.height);

    d3.select(self.frameElement).transition()
      .duration(this.duration)
      .style("height", this.height + "px");
    
    // Compute the "layout"
    this.index = -1;
    this.root.eachBefore(function(n) {
      n.x = ++this.index * this.barHeight;
      n.y = n.depth * 20;
    });

    // Update the nodes…
    this.node = this.svg.selectAll(".node")
      .data(this.nodes, function(d) { return d.id || (d.id = ++this.i); });

    this.nodeEnter = this.node.enter().append("g")
      .attr("class", "node")
      .attr("transform", function(d) { return "translate(" + source.y0 + "," + source.x0 + ")"; })
      .style("opacity", 0);
    
    // Enter any new nodes at the parent's previous position.
    this.nodeEnter.append("rect")
      .attr("y", -this.barHeight / 2)
      .attr("height", this.barHeight)
      .attr("width", this.barWidth)
      .style("fill", this.color)
      .on("click", this.click);

    this.nodeEnter.append("text")
      .attr("dy", 3.5)
      .attr("dx", 5.5)
      .text(function(d) { return d.data.name; });

    // Transition nodes to their new position.
    this.nodeEnter.transition()
      .duration(this.duration)
      .attr("transform", function(d) { return "translate(" + d.y + "," + d.x + ")"; })
      .style("opacity", 1);
    
    this.node.transition()
      .duration(this.duration)
      .attr("transform", function(d) { return "translate(" + d.y + "," + d.x + ")"; })
      .style("opacity", 1)
      .select("rect")
      .style("fill", this.color);

    // Transition exiting nodes to the parent's new position.
    this.node.exit().transition()
      .duration(this.duration)
      .attr("transform", function(d) { return "translate(" + source.y + "," + source.x + ")"; })
      .style("opacity", 0)
      .remove();

    //update the link
    this.link = this.svg.selectAll(".link")
      .data(this.root.links(), function(d) { return d.target.id; });
    
    //Enter any new links at the parent's previous position
    this.link.enter().insert("path", "g")
      .attr("class", "link")
      .attr("d", function(d) {
        var o = {x: source.x0, y: source.y0};
        return this.diagonal({source: o, target: o});
      })
      .transition()
      .duration(this.duration)
      .attr("d", this.diagonal);
    
    // Transition links to their new position.
    this.link.transition()
      .duration(this.duration)
      .attr("d", this.diagonal);

    //Transition existing nodes to the parent's new position
    this.link.exit().transition()
      .duration(this.duration)
      .attr("d", function(d){
        let o = {x:source.x,y:source.y};
        return this.diagonal({source:o, target:o});
      })
      .remove();

    //stash the old position for transition
    this.root.each(function(d) {
      d.x0 = d.x;
      d.y0 = d.y;
    });

  }

  
  private color(d){
    return d._children ? "#3182bd" : d.children ? "#c6dbef" : "#fd8d3c";
  }

  //Toggle children on click
  private click(d){
    if (d.children) {
      d._children = d.children;
      d.children = null;
    } else {
      d.children = d._children;
      d._children = null;
    }
    this.update(d);
  }


  constructor() { }

  ngOnInit() {

    this.createCollapsibleTree();
  }

}
//private _jsonService:jsonServices