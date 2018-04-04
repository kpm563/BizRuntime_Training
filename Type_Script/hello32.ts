class C{
    test(msg : string){
        console.log("From C :" + msg.length);        
    }
}
let refC = new C();
refC.test("Hello");
