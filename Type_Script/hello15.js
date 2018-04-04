var f4 = function (msg) {
    console.log("from test1:" + msg);
    return msg.length;
};
var f5 = f4("hello");
console.log(f5);
var f6 = f4(2345);
console.log(f6);
