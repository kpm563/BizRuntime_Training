var C = /** @class */ (function () {
    function C() {
    }
    C.prototype.test = function (msg) {
        console.log("From C :" + msg.length);
    };
    return C;
}());
var refC = new C();
refC.test("Hello");
