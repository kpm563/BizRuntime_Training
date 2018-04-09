import { Injectable }     from '@angular/core';
import {Http, Response} from '@angular/http';
import 'rxjs/Rx';

@Injectable()

export class jsonServices{

    private _url :string = "flare.json";
    constructor(private _http: Http) { }
    
    getjsonData(){
        return this._http.get(this._url)
            .map((response:Response)=> response.json());
    }
}
