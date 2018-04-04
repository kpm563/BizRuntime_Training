class D{
    test(msg : string) : number{
        console.log("From C :" + msg);        
        return msg.length;
    }
}
let refD = new D();
console.log(refD.test("hello"));
