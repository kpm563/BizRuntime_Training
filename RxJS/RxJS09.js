var button = document.querySelector('button');

var observable = Rx.Observable.create(function (observer) {
	observer.next(1);
	observer.next(2);
	observer.next(3);
	setTimeout(() => {
		observer.next(4);
		observer.complete();
	}, 1000);
});

// Here we are subscribing

/*console.log('just before subscribe'); */document.getElementById('rxjs').innerHTML += 'just before subscribe' + "<br/>"
observable.subscribe({
	next: x => /*console.log('got value ' + x), */ document.getElementById('rxjs').innerHTML += `got value ` + `${x}` +"<br/>",
	error: err => /*console.error('something wrong occurred: ' + err),*/ document.getElementById('rxjs').innerHTML += 'something wrong occurred: ' + `${err}` + "<br/>",
	complete: () => /*console.log('done'),*/ocument.getElementById('rxjs').innerHTML += 'done'
});
/*console.log('just after subscribe'); */document.getElementById('rxjs').innerHTML += 'just after subscribe' + "<br/>"

