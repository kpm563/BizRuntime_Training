var G = /** @class */ (function () {
    function G(x, y) {
        console.log("From constructor :" + x + "," + y);
    }
    return G;
}());
var refG1 = new G("abc", 20);
console.log("------------");
var refG2 = new G(30, 40);
console.log("------------");
var refG3 = refG1;
