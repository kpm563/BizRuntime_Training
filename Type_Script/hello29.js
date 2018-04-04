var Data4 = /** @class */ (function () {
    function Data4() {
    }
    return Data4;
}());
var f22 = function (data) {
    console.log("from f21:" + data.x + "," + data.y + "," + data.z);
    //data.z = false;
    console.log("from f21:" + data.x + "," + data.y + "," + data.z);
};
f22({ x: 10, y: 'abc', z: true });
f22({ x: 10, z: false });
