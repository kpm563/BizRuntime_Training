class Data3{
    x : number;
    y : string;
    z : boolean;
}
let f21 = (data : Data3) =>{
    console.log("from f21:" + data.x + "," + data.y + "," + data.z);    
    data.x = 400;
    console.log("from f21:" + data.x + "," + data.y + "," + data.z);    
}
f21({x:10,y:'abc',z:true});
f21({x:10,y:'abc',z:false});