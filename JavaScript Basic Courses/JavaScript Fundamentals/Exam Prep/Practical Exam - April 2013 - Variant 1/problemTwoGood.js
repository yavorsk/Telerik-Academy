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

	while (!caught && !escaped) {

		if ((currentRow < 0) || ((N - 1) < currentRow) || (currentCol < 0) || ((M - 1) < currentCol)) {
			escaped = true;
			break;
		}

		if (arrOfVisited[currentCellValue - 1]) {
			caught = true;
			break;
		} else {
			arrOfVisited[currentCellValue - 1] = true;
		}

		sum += currentCellValue;

		var newJumpArr = args[indexOfCurrentJump].split(' ');

		currentRow += parseInt(newJumpArr[0]);
		currentCol += parseInt(newJumpArr[1]);
		currentCellValue = calculateCellValue(currentRow, currentCol, M);

		if (indexOfCurrentJump === args.length - 1) {
			indexOfCurrentJump = 2;
		} else {
			indexOfCurrentJump++
		}
	}

	function calculateCellValue(row, col, maxCol) {
		var result = row * maxCol + col + 1;
		return result;
	}

	if (caught) {
		return 'caught ' + sum;
	}
	if (escaped) {
		return 'escaped ' + sum;
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

test();