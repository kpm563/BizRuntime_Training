class H{
    private x;
    public y : number;
    z : number;
    constructor(x, y : number, z : number){ 
        console.log("From constructor :" + x + "," + y + "," + z);        
        this.x = x;
        this.y = y;
        this.z = z;
    }
    test(){
        console.log("from test() :" + this.x + "," + this.y + "," + this.z);        
    }
}
let refH1 = new H("abc", 20, 30);
console.log("------------");
let refH2 = new H(30, 40, 50);
console.log("------------");
let refH3 = refH1;
refH3.test();
//console.log(refH1.x);
console.log(refH1.y);
console.log(refH1.z);


