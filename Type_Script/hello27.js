var f20 = function (data) {
    console.log("from f20:" + data.x + "," + data.y + "," + data.z);
    //data.x = 400;
    console.log("from f20:" + data.x + "," + data.y + "," + data.z);
};
f20({ x: 10, y: 'abc', z: true });
f20({ x: 10, y: 'abc' });
