function Solve(args) {
	var N_M_arr = args[0].split(' ');

	var N = parseInt(N_M_arr[0]);
	var M = parseInt(N_M_arr[1]);

	var startArr = args[1].split(' ');

	var startRow = parseInt(startArr[0]);
	var startCol = parseInt(startArr[1]);

	var lost = false;
	var escaped = false;
	var sum = 0;

	var arrOfVisited = new Array(N * M);
	for (var j = 0; j < arrOfVisited.length; j++) {
		arrOfVisited[j] = false;
	}

	var indexOfCurrentCommand = 2;
	var currentRow = startRow;
	var currentCol = startCol;
	var currentCellValue = calculateCellValue(currentRow, currentCol, M);
	var counterOfCells = 0;

	while (!lost && !escaped) {
		if ((currentRow < 0) || ((N - 1) < currentRow) || (currentCol < 0) || ((M - 1) < currentCol)) {
			escaped = true;
			break;
		}

		if (arrOfVisited[currentCellValue - 1]) {
			lost = true;
			break;
		} else {
			arrOfVisited[currentCellValue - 1] = true;
		}

		sum += currentCellValue;
		counterOfCells++;
		var currentDirrection = args[2 + currentRow][currentCol];

		switch (currentDirrection) {
			case 'l':
				currentCol--;
				break;
			case 'r':
				currentCol++;
				break;
			case 'u':
				currentRow--;
				break;
			case 'd':
				currentRow++;
				break;
		}
		currentCellValue = calculateCellValue(currentRow, currentCol, M);
	}

	function calculateCellValue(row, col, maxCol) {
		var result = row * maxCol + col + 1;
		return result;
	}

	if (escaped) {
		return 'out ' + sum;
	}
	if (lost) {
		return 'lost ' + counterOfCells;
	}
}

var args1 =[
 "3 4",
 "1 3",
 "lrrd",
 "dlll",
 "rddd"]


var args2 =[
 "5 8",
 "0 0",
 "rrrrrrrd",
 "rludulrd",
 "durlddud",
 "urrrldud",
 "ulllllll"] // ???

var args3 =[
 "5 8",
 "0 0",
 "rrrrrrrd",
 "rludulrd",
 "lurlddud",
 "urrrldud",
 "ulllllll"]



console.log(Solve(args2));
console.log([1,2,3,4,5])

