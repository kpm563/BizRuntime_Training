var J = /** @class */ (function () {
    function J(x, y, z) {
        console.log("From constructor");
    }
    return J;
}());
var refJ1 = new J();
console.log("---------------");
var refJ2 = new J(10);
console.log("---------------");
var refJ3 = new J(20, 20);
console.log("---------------");
var refJ4 = new J(2, 70, 20);
console.log("---------------");
