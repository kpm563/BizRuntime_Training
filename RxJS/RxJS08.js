var button = document.querySelector('button');
Rx.Observable.fromEvent(button, 'click')
	.throttleTime(1000)
	.map(event => event.clientX)
	.scan((count, clientX) => count + clientX, 0)
	.subscribe(count => console.log(count));

//var clicks = Rx.Observable.fromEvent(document, 'click');
//var delayedClicks = clicks.delay(1000); // each click emitted after 1 second
//delayedClicks.subscribe(x => console.log(x));