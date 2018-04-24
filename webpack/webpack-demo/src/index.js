import _ from 'lodash';
import './style.css';
import Data from './data.xml';
import printMe from './print.js';

function component() {
    var element = document.createElement('div');
    var btn  = document.createElement('button');
  
    // Lodash, now imported by this script
    element.innerHTML = _.join(['Hello', 'webpack'], ' ');
    // element.classList.add('hello');

    btn.innerHTML = 'Click me';
    btn.onclick = printMe;
    
    // console.log(Data);
  
    return element;
  }
  
  document.body.appendChild(component());