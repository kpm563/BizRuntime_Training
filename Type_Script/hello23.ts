let f16 = (data : any[])=> {
    data.forEach(singleData => {
        console.log(singleData);        
    });
}
f16([2,4,5,6,9,false,"abc","hello"]);