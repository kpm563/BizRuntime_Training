class B{
    test(msg){
        console.log("From B :" + msg);        
    }
}
let refB = new B();
refB.test("Hello");
