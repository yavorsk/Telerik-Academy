function Solve(args) {
	var R_C_arr = args[0].split(' ');

	var R = parseInt(R_C_arr[0]);
	var C = parseInt(R_C_arr[1]);

	var field = [];

	for (var i = 1; i < R + 1; i++) {
		field[i - 1] = args[i].split(' ');
	}

	var startRow = 0;
	var startCol = 0;

	var success = false;
	var fail = false;
	var sum = 0;

	var arrOfVisited = [];
	for (var i = 0; i < R; i++) {
		arrOfVisited[i] = [];
		for (var j = 0; j < C; j++) {
			arrOfVisited[i][j] = false
		}
	}

	var currentRow = startRow;
	var currentCol = startCol;
	var currentCellValue = calculateCellValue(currentRow, currentCol);

	while (!success && !fail) {
		if ((currentRow < 0) || ((R - 1) < currentRow) || (currentCol < 0) || ((C - 1) < currentCol)) {
			success = true;
			console.log('successed with ' + sum);
			break;
		}

		if (arrOfVisited[currentRow][currentCol] == true) {
			fail = true;
			console.log('failed at (' + currentRow + ', ' + currentCol + ')');
			break;
		} else {
			arrOfVisited[currentRow][currentCol] = true;
		}

		sum += currentCellValue;
		var currentDirrection = field[currentRow][currentCol];

		switch (currentDirrection) {
			case 'dr':
				currentRow++;
				currentCol++;
				break;
			case 'ur':
				currentRow--;
				currentCol++;
				break;
			case 'ul':
				currentRow--;
				currentCol--;
				break;
			case 'dl':
				currentRow++;
				currentCol--;
				break;
		}

		currentCellValue = calculateCellValue(currentRow, currentCol);
	};

	function calculateCellValue(row, col) {
		var result = Math.pow(2, row) + col;
		return result;
	}
}

args1 = [
	'3 5',
	'dr dl dr ur ul',
	'dr dr ul ur ur',
	'dl dr ur dl ur'
]

args2 = [
  '3 5',
  'dr dl dl ur ul',
  'dr dr ul ul ur',
  'dl dr ur dl ur'   
]

Solve(args2);