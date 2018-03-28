//var count = 0;
//var rate = 1000;
//var lastClick = Date.now() - rate;
//var button = document.querySelector('button');
//button.addEventListener('click', () => {
//	if (Date.now() - lastClick >= rate) {
//		console.log(`Clicked ${++count} times`);
//		lastClick = Date.now();
//	}
//});


var button = document.querySelector('button');
Rx.Observable.fromEvent(button, 'click')
	.throttleTime(1000)
	.scan(count => count + 1, 0)
	.subscribe(count => console.log(`Clicked ${count} times`));