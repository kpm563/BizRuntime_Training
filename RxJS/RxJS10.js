var observable = Rx.Observable.interval(1000);
var observer = {
	next: function (value) {
		console.log(value);
	}
};

observable.map(function (value) {
	return value * 2;  // 'hello';
}).throttleTime(1000)
	.subscribe(observer);