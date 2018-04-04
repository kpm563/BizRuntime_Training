var E = /** @class */ (function () {
    function E() {
    }
    E.prototype.test = function () {
        return this.x;
        //return x;
    };
    return E;
}());
var refE = new E();
console.log(refE.test());
refE.x = 20;
console.log(refE.test());
