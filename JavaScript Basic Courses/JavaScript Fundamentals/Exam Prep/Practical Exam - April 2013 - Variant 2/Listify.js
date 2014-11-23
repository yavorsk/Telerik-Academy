function Solve(params) {

	// var inVariable = false;
	// var inOperator = false;

	var variables = [];
	var answer;

	for (var commandRow = 0; commandRow < params.length; commandRow++) {
		var currentRow = params[commandRow].trim();
		var inDefinition = false;
		var inList = false;
		var endWord = false;
		var currentWord = '';
		var currentVariable = '';
		var currentOperator = '';
		var list = [];

		for (var i = 0; i < currentRow.length; i++) {

			if (!inList) {
				if (currentRow[i] == ' ') {
					continue;
				} else if (currentRow[i] == '[') {
					inList = true;
					continue;
				} else {
					currentWord += currentRow[i];
					if (currentRow[i + 1] == ' ' || currentRow[i + 1] == '[') {
						endWord = true;
					}

					if (endWord) {
						switch (currentWord) {
							case 'def':
								inDefinition = true;
								break;
							case 'sum':
								currentOperator = currentWord;
								break;
							case 'min':
								currentOperator = currentWord;
								break;
							case 'max':
								currentOperator = currentWord;
								break;
							case 'avg':
								currentOperator = currentWord;
								break;
							default:
								currentVariable = currentWord;
								break;
						}

						endWord = false;
						currentWord = '';
					}
				}
			} else {
				if (currentRow[i] == ' ' || currentRow[i] == ',') {
					continue;
				} else if (currentRow[i] == ']') {
					inList = false;
				} else {
					currentWord += currentRow[i];
					if (currentRow[i + 1] == ' ' || currentRow[i + 1] == ',' || currentRow[i + 1] == ']') {
						endWord = true;

						if (endWord) {
							if (isNumeric(currentWord)) {
								list.push(Number(currentWord));

							} else {
								list.push(variables[currentWord]);
							}

							endWord = false;
							currentWord = '';
						}
					}
				}

				if (!inList) {
					if (inDefinition) {
						if (currentOperator != '') {
							switch (currentOperator) {
								case 'sum':
									variables[currentVariable] = calculateSum(list);
									break;
								case 'min':
									variables[currentVariable] = getMin(list);
									break;
								case 'max':
									variables[currentVariable] = getMax(list);
									break;
								case 'avg':
									variables[currentVariable] = calculateAverage(list);
									break;
							}
						} else {
							variables[currentVariable] = list;
						}
					} else {
						switch (currentOperator) {
							case 'sum':
								answer = calculateSum(list);
								break;
							case 'min':
								answer = getMin(list);
								break;
							case 'max':
								answer = getMax(list);
								break;
							case 'avg':
								answer = calculateAverage(list);
								break;
							default:
								answer = list[0];
								break;
						}
					}
				}
			}

		};
	}

	function isNumeric(n) {
		return !isNaN(parseFloat(n)) && isFinite(n) && !Array.isArray(n);
	}

	function calculateSum(list) {
		var sum = 0;
		for (var i = 0; i < list.length; i++) {
			if (isNumeric(list[i])) {
				sum += list[i];
			} else {
				for (var j = 0; j < list[i].length; j++) {
					sum += list[i][j];
				}
			}
		}

		return sum;
	}

	function getMin(list) {
		var min = 90000000000000;

		for (var i = 0; i < list.length; i++) {
			if (isNumeric(list[i])) {
				if (min > list[i]) {
					min = list[i];
				}
			} else {
				for (var j = 0; j < list[i].length; j++) {
					if (min > list[i][j]) {
						min = list[i][j];
					}
				}
			}
		}

		return min;
	}

	function getMax(list) {
		var max = -90000000000000;

		for (var i = 0; i < list.length; i++) {
			if (isNumeric(list[i])) {
				if (max < list[i]) {
					max = list[i];
				}
			} else {
				for (var j = 0; j < list[i].length; j++) {
					if (max < list[i][j]) {
						max = list[i][j];
					}
				}
			}
		}

		return max;
	}

	function calculateAverage(list) {
		var sum = 0;
		var count = 0;

		for (var i = 0; i < list.length; i++) {
			if (isNumeric(list[i])) {
				sum += list[i];
				count++;
			} else {
				for (var j = 0; j < list[i].length; j++) {
					sum += list[i][j];
					count++;
				}
			}
		}

		return Math.floor(sum / count);
	}
	return answer;
}
