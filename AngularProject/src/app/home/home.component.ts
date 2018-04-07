import { Component, OnInit, Input } from '@angular/core';
import {FormsModule} from '@angular/forms';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }


  homeTitle = "Welcome to home page!!!...."

  employee = {
    fname : "Rohit",
    address : "Mumbai"
  };

  name = "Sachin Singh";
  city = "Bangalore";
  age = 20;
  gender = "male";

  alertMe(){
    alert("Welcome to angular2.....!!!!");
  }

}
