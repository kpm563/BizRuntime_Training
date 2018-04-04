class J{
    constructor(x? : number, y? : number, z? : number){ // If there is one argument is optional then all the arguements
        console.log("From constructor");        
    }
}
let refJ1 = new J();
console.log("---------------");
let refJ2 = new J(10);
console.log("---------------");
let refJ3 = new J(20, 20);
console.log("---------------");
let refJ4 = new J(2, 70, 20);
console.log("---------------");
