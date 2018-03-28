var button = document.querySelector('button');

var observer = {
	next: function (value) {
		console.log(value);
	},
	error: function (value) {
		console.log(error);
	},
	complete: function (value) {
		console.log('completed');
	}
};

Rx.Observable.fromEvent(button, 'click')
	.subscribe(observer);
