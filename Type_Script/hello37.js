var H = /** @class */ (function () {
    function H(x, y, z) {
        console.log("From constructor :" + x + "," + y + "," + z);
        this.x = x;
        this.y = y;
        this.z = z;
    }
    H.prototype.test = function () {
        console.log("from test() :" + this.x + "," + this.y + "," + this.z);
    };
    return H;
}());
var refH1 = new H("abc", 20, 30);
console.log("------------");
var refH2 = new H(30, 40, 50);
console.log("------------");
var refH3 = refH1;
refH3.test();
//console.log(refH1.x);
console.log(refH1.y);
console.log(refH1.z);
