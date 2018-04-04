class Data4{
    x : number;
    y? : string;
    readonly z : boolean;
}
let f22 = (data : Data4) =>{
    console.log("from f21:" + data.x + "," + data.y + "," + data.z);    
    //data.z = false;
    console.log("from f21:" + data.x + "," + data.y + "," + data.z);    
}
f22({x:10,y:'abc',z:true});
f22({x:10,z:false});