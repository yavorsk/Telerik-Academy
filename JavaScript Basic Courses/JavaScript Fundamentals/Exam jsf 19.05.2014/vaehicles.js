function solve(params) {
	//var s = parseInt(params[0]);
	var s = params;

	var count = 0;

	var cars = 4;
	var trikes = 3
	var trucks = 10;

	for (var i = 0; i < Math.floor(s / trucks)+1; i++) {
		for (var j = 0; j < Math.floor(s / cars)+1; j++) {
			for (var k = 0; k < Math.floor(s / trikes)+1; k++) {
				if ((i * trucks + j * cars + k * trikes) == s) {
					count++;
				}
			}
		}
	}


	console.log(count);
}

solve(7);
solve(10);
solve(40);