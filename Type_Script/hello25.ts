interface Data{
    x : number;
    y : string;
    z : boolean;
}
let f18 = (data : Data) =>{
    console.log("from f18:" + data.x + "," + data.y + "," + data.z);    
}
f18({x:10,y:'abc',z:true});
//f18({x:10,y:'abc});