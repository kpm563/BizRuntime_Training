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

var subscriptions = Rx.Observable.create(function (obs) {
	//obs.next('A value');
	////obs.error('Error'); // After the error occurs the observer is finished.
	//obs.complete('Completed');
	////obs.next('Next value');
	//obs.next('A second value'); // We can't get the value bcoz the observer has finished before.

	button.onclick = function (event) {
		obs.next(event);
	}
})
	.subscribe(observer);


//Here we are unsubscribing after the timeout it will not be execute.
setTimeout(function () {
	subscriptions.unsubscribe();
}, 5000);