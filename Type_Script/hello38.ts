class I{
    constructor(private x : number, public y : number){
        //Nothing
    }
    test(){
        console.log("from test() :" + this.x + "," + this.y);        
    }
}
let refI = new I(10, 20);
refI.test();
//console.log(refI.x);
console.log(refI.y);
// There is no constructor overloading in TS.
