import { Component, OnInit,ElementRef, ComponentRef, ViewContainerRef, ViewChildDecorator } from '@angular/core';
import {Observable} from 'rxjs/Observable';
import {FormsModule} from '@angular/forms';
import 'rxjs/Rx';
import { ViewChild } from '@angular/core';

@Component({
  selector: 'app-observable1',
  templateUrl: './observable1.component.html',
  styleUrls: ['./observable1.component.css']
})
export class Observable1Component implements OnInit {

  @ViewChild('input' ) input: ElementRef;
  constructor(private data:ElementRef) {

  let input = document.querySelector('input');

  let observable1 = Observable.fromEvent(this.data.nativeElement as any, 'input');

  let subscriber1 = observable1.map(event=>event)
                    .debounceTime(500)
                    .distinctUntilChanged()
                    .subscribe((event)=>{
                      //console.log(this.input.nativeElement);
                      let data3 = this.data.nativeElement.querySelector('#page');
                    //console.log(data3);
                    const data1 = this.data.nativeElement.querySelector('#page');
                    data1.innerHTML = event.target.value;
                    }
                  );

  }

  ngOnInit() {
  }

}
