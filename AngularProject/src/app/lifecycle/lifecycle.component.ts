import { Component,Input, OnChanges,SimpleChanges } from '@angular/core';
import {FormsModule} from '@angular/forms';

@Component({
  selector: 'app-lifecycle',
  templateUrl: './lifecycle.component.html',
  styleUrls: ['./lifecycle.component.css']
})
export class LifecycleComponent implements OnChanges {

  @Input() userText:string; 

  ngOnChanges(changes:SimpleChanges){
    for(let properyName in changes){
      let change= changes[properyName];
      let current = JSON.stringify(change.currentValue);
      let previous = JSON.stringify(change.previousValue);
      console.log(properyName+ ': currentValue = '+current+', previousValue = ' +previous);
    }
  }
}
