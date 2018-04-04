class E{
    x : number;
    test() : number{
        return this.x;
        //return x;
    }
}
let refE = new E();
console.log(refE.test());
refE.x = 20;
console.log(refE.test());
