import { Component, OnInit } from '@angular/core';
import * as d3 from 'd3';

@Component({
  selector: 'app-easing',
  templateUrl: './easing.component.html',
  styleUrls: ['./easing.component.css']
})
export class EasingComponent implements OnInit {

  constructor() { }


  ngOnInit() {
      this.CreateEasing();
  }

  private CreateEasing(){
    let easing =[
      "easeElastic",
      "easeBounce",
      "easeLinear",
      "easeSin",
      "easeQuad",
      "easeCubic",
      "easePoly",
      "easeCircle",
      "easeExp",
      "easeBack"
    ];

    let svg = d3.select("body")
      .append("svg")
      .attr("width", 960)
        .attr("height", 500);

    function circleTransition(easement,yPos){
      let timeCircle = svg.append("circle")
        .attr("fill", "tomato")
        .attr("r", 20);
    repeat();
    
      function repeat(){
        timeCircle
        .attr('cx', 210)          // position the circle at 40 on the x axis
        .attr('cy', (yPos*45)+25) // position the circle at 250 on the y axis
        .transition()             // apply a transition
        .ease(easement)           // control the speed of the transition
        .duration(4000)           // apply it over 2000 milliseconds
        .attr('cx', 720)          // move the circle to 920 on the x axis
        .transition()             // apply a transition
        .ease(easement)           // control the speed of the transition
        .duration(4000)           // apply it over 2000 milliseconds
        .attr('cx', 210)          // return the circle to 40 on the x axis
        .on("end", repeat);
      };

      let easeType = svg.append("text")
        .attr("fill", "green")
        .attr("dy", ".35em") // set offset y position
        .attr("x", 650)
        .attr("text-anchor", "middle") // set anchor x justification
        .attr("y", (yPos*45)+25)
        .text(easing[yPos]);
    };

    circleTransition(d3.easeElastic,0);
    circleTransition(d3.easeBounce,1);
    circleTransition(d3.easeLinear,2);
    circleTransition(d3.easeSin,3);
    circleTransition(d3.easeQuad,4);
    circleTransition(d3.easeCubic,5);
    circleTransition(d3.easePoly,6);
    circleTransition(d3.easeCircle,7);
    circleTransition(d3.easeExp,8);
    circleTransition(d3.easeBack,9);
  }  
}
