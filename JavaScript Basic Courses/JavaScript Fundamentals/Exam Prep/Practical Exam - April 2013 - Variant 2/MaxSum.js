function Solve(params) {
	var N = parseInt(params[0]);

	var arr = params.map(Number);

	var answer = arr[1];

	for (var i = 1; i < arr.length; i++) {
		var currentSum = 0;

		for (var j = i; j < arr.length; j++) {
			currentSum += arr[j];
			if (currentSum > answer) {
				answer = currentSum;
			}
		}
	}

	return answer;
}

var testArr = [8, 1, 6, -9, 4, 4, -2, 10, -1];
var testArr2 = [6, 1, 3, -5, 8, 7, -6];
var testArr3 = [9,-9,-8,-8,-7,-6,-5,-1,-7,-7,-6];

console.log(Solve(testArr3));