function solve(params) {
	var N = parseInt(params[0]);

	var answer = 0;

	for (var i = 1; i <= N - 1; i++) {
		if (parseInt(params[i]) <= parseInt(params[i + 1])) {
			if (i === N - 1) {
				answer++;
			}
			continue;
		} else {
			answer++;
			if (i === N - 1) {
				answer++;
			}
		}
	}

	return answer;
}

function testSolve() {
	var test1 = [7, 1, 2, -3, 4, 4, 0, 1];
	var test2 = [7, 1, 2, -3, 4, 4, 0, 1];
	var test3 = [6, 1, 3, -5, 8, 7, -6];
	var test4 = [9, 1, 8, 8, 7, 6, 5, 7, 7, 6];

	console.log(solve(test1));
	console.log(solve(test2));
	console.log(solve(test3));
	console.log(solve(test4));
}

testSolve();