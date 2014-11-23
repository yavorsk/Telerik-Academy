function Solve(args) {

	var N_M_Jarr = args[0].split(' ');

	var N = parseInt(N_M_Jarr[0]);
	var M = parseInt(N_M_Jarr[1]);
	var J = parseInt(N_M_Jarr[2]);

	var startArr = args[1].split(' ');

	var startRow = parseInt(startArr[0]);
	var startCol = parseInt(startArr[1]);

	var caught = false;
	var escaped = false;
	var indexOfCurrentJump = 2;
	var sum = 0;

	var arrOfVisited = new Array(M * N);
	for (var j = 0; j < arrOfVisited.length; j++) {
		arrOfVisited[j] = false;
	}

	var currentRow = startRow;
	var currentCol = startCol;
	var currentCellValue = calculateCellValue(currentRow, currentCol, M);
	arrOfVisited[currentCellValue-1] = true;

	while (!caught && !escaped) {
		sum += currentCellValue;

		var newJumpArr = args[indexOfCurrentJump].split(' ');
		currentRow += parseInt(newJumpArr[0]);
		currentCol += parseInt(newJumpArr[1]);
		if (indexOfCurrentJump === args.length - 1) {
			indexOfCurrentJump = 2;
		} else {
			indexOfCurrentJump++
		}

		currentCellValue = calculateCellValue(currentRow, currentCol, M);

		if (arrOfVisited[currentCellValue - 1]) {
			caught = true;
		} else {
			arrOfVisited[currentCellValue - 1] = true;
		}

		if ((currentRow < 0) || ((N - 1) < currentRow) || (currentCol < 0) || ((M - 1) < currentCol)) {
			escaped = true;
		}
	}

	function calculateCellValue(row, col, maxCol) {
		var result = row * maxCol + col + 1;
		return result;
	}

	if (escaped) {
		return 'escaped ' + sum;
	}
	if (caught) {
		return 'caught ' + sum;
	}

}



//console.log(calculateCellValue(2, 4, 5));

function test2() {
	var testArr = [
		'6 7 3',
		'0 0',
		'+1 +1',
		'-1 -1',
		'3 -1'
	]

	console.log(Solve(testArr));
}

function test() {
	var testArr = [
		'6 7 3',
		'0 0',
		'2 2',
		'-2 2',
		'3 -1'
	]

	console.log(Solve(testArr));
}

function test3() {
	var testArr = [
		'5 5 10',
		'0 0',
		'+1 0',
		'+1 0',
		'+1 0',
		'+1 0',
		'0 1',
		'-1 0',
		'-1 0', 
		'-1 0', 
		'-1 0', 
		'0, 1'
	]

	console.log(Solve(testArr));
}


test3();