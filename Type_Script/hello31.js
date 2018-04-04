var B = /** @class */ (function () {
    function B() {
    }
    B.prototype.test = function (msg) {
        console.log("From B :" + msg);
    };
    return B;
}());
var refB = new B();
refB.test("Hello");
