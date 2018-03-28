var button = document.querySelector('button');

Rx.Observable.fromEvent(button, 'click')
	.throttleTime(1000)
	.subscribe(
	(event) => console.log(event.clientX)
	);

