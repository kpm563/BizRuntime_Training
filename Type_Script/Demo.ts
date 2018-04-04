var name:string = "John"; 
var score1:number = 50;
var score2:number = 42.50;
var sum = score1 + score2; 
console.log("name"+name); 
console.log("first score: "+score1); 
console.log("second score: "+score2); 
console.log("sum of the scores: "+sum);


var global_num = 12          //global variable 
class Numbers { 
   num_val = 13;             //class variable 
   static sval = 10;         //static field 
   
   storeNum():void { 
      var local_num = 14;    //local variable 
   } 
} 
console.log("Global num: "+global_num)  
console.log(Numbers.sval)   //static variable  
var obj = new Numbers(); 
console.log("Global num: "+obj.num_val) 

var x:number = 4 
var y = -x; 
console.log("value of x: ",x);   //outputs 4 
console.log("value of y: ",y);   //outputs -4

var msg:string = "hello"+"world" 
console.log(msg)

var num:number = -2 
var result = num > 0 ?"positive":"non-positive" 
console.log(result)

var num = 12 
console.log(typeof num);

var  num:number = 5
if (num > 0) { 
   console.log("number is positive") 
}

var num:number = 12; 
if (num % 2==0) { 
   console.log("Even"); 
} else {
   console.log("Odd"); 
}

var num:number = 2 
if(num > 0) { 
   console.log(num+" is positive") 
} else if(num < 0) { 
   console.log(num+" is negative") 
} else { 
   console.log(num+" is neither positive nor negative") 
}

var grade:string = "A"; 
switch(grade) { 
   case "A": { 
      console.log("Excellent"); 
      break; 
   } 
   case "B": { 
      console.log("Good"); 
      break; 
   } 
   case "C": {
      console.log("Fair"); 
      break;    
   } 
   case "D": { 
      console.log("Poor"); 
      break; 
   }  
   default: { 
      console.log("Invalid choice"); 
      break;              
   } 
}


var num:number = 5; 
var i:number; 
var factorial = 1; 

for(i = num;i>=1;i--) {
   factorial *= i;
}
console.log(factorial)

var num:number = 5; 
var factorial:number = 1; 

while(num >=1) { 
   factorial = factorial * num; 
   num--; 
} 
console.log("The factorial  is "+factorial);  

var n:number = 10;
do { 
   console.log(n); 
   n--; 
} while(n>=0);

var i:number = 1 
while(i<=10) { 
   if (i % 5 == 0) {   
      console.log ("The first multiple of 5  between 1 and 10 is : "+i) 
      break     //exit the loop if the first multiple is found 
   } 
   i++ 
}


var num:number = 0
var count:number = 0;

for(num=0;num<=20;num++) {
   if (num % 2==0) {
      continue
   }
   count++
}
console.log (" The count of odd values between 0 and 20 is: "+count) 

function test() {   // function definition    
    console.log("function called") 
 } 
 test()              // function invocation


 //function defined 
function greet():string { //the function returns a string 
    return "Hello World" 
 } 
 
 function caller() { 
    var msg = greet() //function greet() invoked 
    console.log(msg) 
 } 
 
 //invoke function 
 caller()

 function test_param(n1:number,s1:string) { 
    console.log(n1) 
    console.log(s1) 
 } 
 test_param(123,"this is a string")


 //Optional Parameters
 function disp_details(id:number,name:string,mail_id?:string) { 
    console.log("ID:", id); 
    console.log("Name",name); 
    
    if(mail_id!=undefined)  
    console.log("Email Id",mail_id); 
 }
 disp_details(123,"John");
 disp_details(111,"mary","mary@xyz.com");


 //Rest Parameters
 function addNumbers(...nums:number[]) {  
    var i;   
    var sum:number = 0; 
    
    for(i = 0;i<nums.length;i++) { 
       sum = sum + nums[i]; 
    } 
    console.log("sum of the numbers",sum) 
 } 
 addNumbers(1,2,3) 
 addNumbers(10,10,10,10,10)


//Default parameters
function calculate_discount(price:number,rate:number = 0.50) { 
    var discount = price * rate; 
    console.log("Discount Amount: ",discount); 
 } 
 calculate_discount(1000) 
 calculate_discount(1000,0.30)

//Anonymous function
var abc = function() { 
    return "hello world";  
 };
 console.log(abc())


var res = function(a:number,b:number) { 
    return a*b;  
 }; 
 console.log(res(12,2)) 

//Function Constructor
var myFunction = new Function("a", "b", "return a * b"); 
var x1 = myFunction(4, 3); 
console.log(x);

//Recursion
function factorial1(number) {
    if (number <= 0) {         // termination case
       return 1; 
    } else {     
       return (number * factorial1(number - 1));     // function invokes itself
    } 
 }; 
 console.log(factorial1(6)); 

 //Lambda Functions
 var foo = (x:number)=>10 + x 
console.log(foo(100))

var foo1 = (x:number)=> {    
    x = 10 + x 
    console.log(x)  
 } 
 foo1(100)

 //Function Overloads
 function disp(s1:string):void; 
function disp(n1:number,s1:string):void; 

function disp(x:any,y?:any):void { 
   console.log(x); 
   console.log(y); 
} 
disp("abc") 
disp(1,"xyz");

//Number Properties
console.log("TypeScript Number Properties: "); 
console.log("Maximum value that a number variable can hold: " + Number.MAX_VALUE); 
console.log("The least value that a number variable can hold: " + Number.MIN_VALUE); 
console.log("Value of Negative Infinity: " + Number.NEGATIVE_INFINITY); 
console.log("Value of Negative Infinity:" + Number.POSITIVE_INFINITY);

//NaN
var month = 0 
if( month<=0 || month >12) { 
   month = Number.NaN 
   console.log("Month is "+ month) 
} else { 
   console.log("Value Accepted..") 
}

//prototype
function employee(id:number,name:string) { 
    this.id = id 
    this.name = name 
 } 
 
 var emp = new employee(123,"Smith") 
 employee.prototype.email = "smith@abc.com" 
 
 console.log("Employee 's Id: "+emp.id) 
 console.log("Employee's name: "+emp.name) 
 console.log("Employee's Email ID: "+emp.email)

 //String charAt()
 var str = new String("This is string"); 
 console.log("str.charAt(0) is:" + str.charAt(0)); 
 console.log("str.charAt(1) is:" + str.charAt(1)); 
 console.log("str.charAt(2) is:" + str.charAt(2)); 
 console.log("str.charAt(3) is:" + str.charAt(3)); 
 console.log("str.charAt(4) is:" + str.charAt(4)); 
 console.log("str.charAt(5) is:" + str.charAt(5));

 //String charCodeAt()
 var str = new String("This is string"); 
console.log("str.charAt(0) is:" + str.charCodeAt(0)); 
console.log("str.charAt(1) is:" + str.charCodeAt(1)); 
console.log("str.charAt(2) is:" + str.charCodeAt(2)); 
console.log("str.charAt(3) is:" + str.charCodeAt(3)); 
console.log("str.charAt(4) is:" + str.charCodeAt(4)); 
console.log("str.charAt(5) is:" + str.charCodeAt(5));

//String concat()
var str1 = new String( "This is string one" ); 
var str2 = new String( "This is string two" ); 
var str3 = str1.concat(str2); 
console.log("str1 + str2 : "+str3)

//String slice()
var str4 = "Apples are round, and apples are juicy."; 
var sliced = str.slice(3, -2); 
console.log(sliced);

//String split()
var str6 = "Apples are round, and apples are juicy."; 
var splitted = str6.split(" ", 3); 
console.log(splitted);

//Arrays
var alphas:string[]; 
alphas = ["1","2","3","4"] 
console.log(alphas[0]); 
console.log(alphas[1]);

//Array Object
var arr_names:number[] = new Array(4)  

for(var i = 0;i<arr_names.length;i++) { 
   arr_names[i] = i * 2 
   console.log(arr_names[i]) 
}


//Traversal  for…in loop
var j:any; 
var nums:number[] = [1001,1002,1003,1004] 

for(j in nums) { 
   console.log(nums[j]) 
} 

//Array concat()
var alpha = ["a", "b", "c"]; 
var numeric = [1, 2, 3];

var alphaNumeric = alpha.concat(numeric); 
console.log("alphaNumeric : " + alphaNumeric );

//Array every()
function isBigEnough(element, index, array) { 
    return (element >= 10); 
 } 
           
 var passed = [12, 5, 8, 130, 44].every(isBigEnough); 
 console.log("Test Value : " + passed );

 //Array pop()
 var numbers = [1, 4, 9]; 
          
var element = numbers.pop(); 
console.log("element is : " + element );  
          
var element = numbers.pop(); 
console.log("element is : " + element );

//Array push()
var numbers = new Array(1, 4, 9); 
var length = numbers.push(10); 
console.log("new numbers is : " + numbers );  
length = numbers.push(20); 
console.log("new numbers is : " + numbers );

//Tuples
var mytuple = [10,"Hello"]; //create a  tuple 
console.log(mytuple[0]) 
console.log(mytuple[1])

//Tupple operation
var mytuple = [10,"Hello","World","typeScript"]; 
console.log("Items before push "+mytuple.length)    // returns the tuple size 

mytuple.push(12)                                    // append value to the tuple 
console.log("Items after push "+mytuple.length) 
console.log("Items before pop "+mytuple.length) 
console.log(mytuple.pop()+" popped from the tuple") // removes and returns the last item
  
console.log("Items after pop "+mytuple.length)

//Union
var val:string|number 
val = 12 
console.log("numeric value of val "+val) 
val = "This is a string" 
console.log("string value of val "+val)

//Union Type and Array
var arr:number[]|string[]; 
var i:number; 
arr = [1,2,4] 
console.log("**numeric array**")  

for(i = 0;i<arr.length;i++) { 
   console.log(arr[i]) 
}  

arr = ["Mumbai","Pune","Delhi"] 
console.log("**string array**")  

for(i = 0;i<arr.length;i++) { 
   console.log(arr[i]) 
} 


//Interface Inheritance
interface Person { 
    age:number 
 } 
 
 interface Musician extends Person { 
    instrument:string 
 } 
 
 var drummer = <Musician>{}; 
 drummer.age = 27 
 drummer.instrument = "Drums" 
 console.log("Age:  "+drummer.age) 
 console.log("Instrument:  "+drummer.instrument)

//Multiple inheritance
interface IParent1 { 
    v1:number 
 } 
 
 interface IParent2 { 
    v2:number 
 } 
 
 interface Child extends IParent1, IParent2 { } 
 var Iobj:Child = { v1:12, v2:23} 
 console.log("value 1: "+this.v1+" value 2: "+this.v2)


 //class
 class Car { 
    //field 
    engine:string; 
    
    //constructor 
    constructor(engine:string) { 
       this.engine = engine 
    }  
    
    //function 
    display():void { 
       console.log("Function displays Engine is  :   "+this.engine) 
    } 
 } 
 
 //create an object 
 var obj1 = new Car("XXSY1")
 
 //access the field 
 console.log("Reading attribute value Engine as :  "+obj1.engine)  
 
 //access the function
 //obj.display();

 //
