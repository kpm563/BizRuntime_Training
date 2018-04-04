class G{
    constructor(x, y : number){ 
        console.log("From constructor :" + x + "," + y);        
    }
}
let refG1 = new G("abc", 20);
console.log("------------");
let refG2 = new G(30, 40);
console.log("------------");
let refG3 = refG1;
/*

There is no default access modifiers are there in typescript 
1. private
2. protected
3. public 
==> By default access scope is public.

*/