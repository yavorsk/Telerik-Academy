function Solve(commands) {
	var answer = 0;
	var functions = {};

	for (var i = 0; i < commands.length; i++) {
		//mahame skobite
		var currentLine = commands[i].trim();
		currentLine = currentLine.substring(1, currentLine.length - 1);
		//ako ima nestnati izrazi, zamestvam nestnatia s revnoto mu:
		if (currentLine.indexOf('(') > -1) {
			var startBracket = currentLine.indexOf('(');
			var endBracket = currentLine.indexOf(')');
			var nestedExpr = currentLine.substring(startBracket + 1, endBracket);

			var resultFromNested = processNested(trimStr(nestedExpr));

			if (isNaN(resultFromNested) || !isFinite(resultFromNested)) {
				return 'Division by zero! At Line:' + (i + 1);
			}

			currentLine = currentLine.substring(0, startBracket) + resultFromNested + currentLine.substring(endBracket + 1, currentLine.length);
		}

		answer = processLine(trimStr(currentLine));
		if (isNaN(answer) || !isFinite(answer)) {
			return 'Division by zero! At Line:' + (i + 1);
		}

	}

	function trimStr(line) {
		var lineArr = line.split(' ');
		var trimmedArr = [];
		var result = 0;

		for (var i = 0; i < lineArr.length; i++) {
			if (lineArr[i]) {
				trimmedArr.push(lineArr[i]);
			}
		}

		return trimmedArr;
	}

	function processNested(trimmedArr) {
		var sign = trimmedArr[0];
		var result = 0;
		
		switch (sign) {
			case '+':
				if (isNumeric(trimmedArr[1])) {
					result = parseInt(trimmedArr[1]);
				} else {
					result = functions[trimmedArr[1]];
				}
				for (var i = 2; i < trimmedArr.length; i++) {
					if (isNumeric(trimmedArr[i])) {
						result += parseInt(trimmedArr[i]);
					} else {
						result += functions[trimmedArr[i]];
					}
				}
				break;
			case '-':
				if (isNumeric(trimmedArr[1])) {
					result = parseInt(trimmedArr[1]);
				} else {
					result = functions[trimmedArr[1]];
				}
				for (var i = 2; i < trimmedArr.length; i++) {
					if (isNumeric(trimmedArr[i])) {
						result -= parseInt(trimmedArr[i]);
					} else {
						result -= functions[trimmedArr[i]];
					}
				}
				break;
			case '*':
				if (isNumeric(trimmedArr[1])) {
					result = parseInt(trimmedArr[1]);
				} else {
					result = functions[trimmedArr[1]];
				}
				for (var i = 2; i < trimmedArr.length; i++) {
					if (isNumeric(trimmedArr[i])) {
						result *= parseInt(trimmedArr[i]);
					} else {
						result *= functions[trimmedArr[i]];
					}
				}
				break;
			case '/':
				if (isNumeric(trimmedArr[1])) {
					result = parseInt(trimmedArr[1]);
				} else {
					result = functions[trimmedArr[1]];
				}
				for (var i = 2; i < trimmedArr.length; i++) {
					if (isNumeric(trimmedArr[i])) {
						result = Math.floor(result / (parseInt(trimmedArr[i])));
					} else {
						result = Math.floor(result / (functions[trimmedArr[i]]));
					}
				}
				break;
		}

		return result;
	}

	function processLine(trimmedArr) {
		var sign = trimmedArr[0];
		var result = 0;

		switch (sign) {
			case 'def':
				if (isNumeric(trimmedArr[2])) {
					functions[trimmedArr[1]] = parseInt(trimmedArr[2]);
				} else {
					functions[trimmedArr[1]] = functions[trimmedArr[2]];
				}

				break;
			default:
				result = processNested(trimmedArr);
				break;
		}

		return result;
	}

	function isNumeric(n) {
		return !isNaN(parseFloat(n)) && isFinite(n);
	}

	return answer;
}