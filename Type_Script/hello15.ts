let f4 = function(msg){
    console.log("from test1:" +msg);
    return msg.length;
};

let f5 = f4("hello");
console.log(f5);

let f6 = f4(2345);
console.log(f6);
