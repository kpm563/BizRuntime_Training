var A = /** @class */ (function () {
    function A() {
    }
    A.prototype.test = function () {
        console.log("From A");
    };
    return A;
}());
var refA = new A();
refA.test();
