var button = document.querySelector('button');

var observer = {
	next: function (value) {
		//console.log(value);
		document.getElementById('rxjs').innerHTML = value + " ";
	},
	error: function (value) {
		console.log(error);
	},
	complete: function (value) {
		//console.log('completed');
		document.getElementById('rxjs').innerHTML += 'Completed';
	}
};

Rx.Observable.create(function (obs) {
	obs.next('A value');

	setTimeout(function () {
		//obs.error('Error'); // After the error occurs the observer is finished.
		obs.complete('Completed');	
	}, 2000);
	
	
	obs.next('A second value'); // We can't get the value bcoz the observer has finished before.
})
	.subscribe(observer);