var subject = new Rx.Subject();

subject.subscribe({
	next: function (value) {
		console.log(value);
	},
	error: function (error) {
		console.log(error);
	},
	complete: function () {
		console.log('Completed');
	}
});

subject.subscribe({
	next: function (value) {
		console.log(value);
	}
});

subject.next('A next data');
subject.complete();