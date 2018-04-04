class F{
    constructor(){ // NO need to create a constructor
        console.log("From constructor");        
    }
}
let refF1 = new F();
console.log("------------");
let refF2 = new F();
console.log("------------");
let refF3 = refF1;
