let s1 = "java tech";
let s2 = s1.substring(2,4);
console.log(s2);

let s3;
s3 = "java tech";
let s4 = (<string>s3).substring(3,5); // type assertions
let s5 = (s3 as string).substring(1,5); // type assertions, similar to type casting
console.log(s4);
console.log(s5);


