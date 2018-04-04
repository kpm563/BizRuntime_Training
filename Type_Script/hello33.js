var D = /** @class */ (function () {
    function D() {
    }
    D.prototype.test = function (msg) {
        console.log("From C :" + msg);
        return msg.length;
    };
    return D;
}());
var refD = new D();
console.log(refD.test("hello"));
