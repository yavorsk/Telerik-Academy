function Solve(args) {
	function parseOperationStart(operationStart) {
		var indexOfWhitespace = operationStart.trim().indexOf(' ') !== -1;
		var name;
		var func;

		if (indexOfWhitespace === -1) {
			name = operationStart;
			func = '';
		} else {
			name = operationStart.substring(0, indexOfWhitespace);
			func = operationStart.substring(indexOfWhitespace).trim();
		}
		return {
			name: name.trim(),
			func: func.trim()
		}
	}

	function parseValue(valueString) {
		valueString = valueString.trim();
		valueString = valueString.substring(0, valueString.length - 1);
		var parts = valueString.split(',').map(function(item) {
			item = item.trim();
			if (isFinite(item)) {
				return parseInt(item);
			} else {
				return item.trim();
			}
		});
		return parts;
	}

	function parseOperations(lines) {
		var operations = [];

		for (var i = 0; i < lines.length; i++) {
			var line = lines[i];
			//parts[0] -> variable + function
			//parts[1] -> values
			var parts = line.split('[');
			var operation = parseOperationStart(parts[0]);
			var value = parseValue(parts[1]);
			operation.value = value;
			operations.push(operation);
		}
		// return [{
		// 	operation: 'sum',
		// 	value: '[1,2,3]',
		// 	name: 'func2'
		// }]

		return operations;
	}

	function evaluateOperation(name, scope) {
		var operation = scope[name];
		var newValues = [];
		for (var i = 0; i < operation.value.length; i++) {
			var item = operation.value[i];
			if (!isFinite(item) && item != '') {
				var variableValue = scope[item].value;
				if (variableValue instanceof Array) {
					Array.prototype.push.apply(newValues, variableValue);
					// for (var j = 0; j < variableValue.length; j++) {
					// 	newValues.push(variableValue[j]);
					// }
				} else {
					newValues.push(variable.value)
				}
			} else {
				newValues.push(item);
			}

			// switch(operation.func) {
			// 	case '':
			// 		break;
			// 	case 'sum':
					
			// 		break;
			// }
		}

		operation.values =

		for (i = 0; i < mewValues.length; i++) {
			operation.value.push(newValues);
		}
	}


	var lines = args.map(function(item)) {
		item = item.trim();
		if (item.indexOf('def ') !== 0) {
			return item;
		}
		item = item.substr('def '.length).trim();
		return item;
	}

	var operations = parseOperations(lines);
	var scope = {};
	for (var i = 0; i < operations.length; i++) {
		var operaion = operations[i]
		scope[operation.name] = operation;
		evaluateOperation(operation.name, scope);
	}
}