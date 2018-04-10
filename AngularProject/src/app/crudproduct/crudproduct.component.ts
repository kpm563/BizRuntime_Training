import { Component, OnInit } from '@angular/core';
import{Http, Response, Headers} from '@angular/http';

@Component({
  selector: 'app-crudproduct',
  templateUrl: './crudproduct.component.html',
  styleUrls: ['./crudproduct.component.css']
})
export class CrudproductComponent implements OnInit {

  constructor(private http:Http) { }

  confirmationString:string = "New product has been added!";
  isAdded:boolean=false;

  productObj:object = {};


  addNewProduct = function(product){
    this.productObj={
      "name":product.name,
      "color":product.color
    }
    this.http.post("http://localhost:5555/products", this.productObj).subscribe((res:Response)=>{
      this.isAdded=true;
    })
  }
  ngOnInit() {
  }

}
