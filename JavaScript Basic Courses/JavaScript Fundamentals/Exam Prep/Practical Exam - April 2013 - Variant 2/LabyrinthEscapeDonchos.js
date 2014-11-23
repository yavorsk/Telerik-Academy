function Solve(args) {
	var sizes = args[0].split(' '),
		startPosition = args[1].split(' '),
		rows = parseInt(sizes[0]),
		cols = parseInt(sizes[1]),
		row = parseInt(startPosition[0]),
		col = parseInt(startPosition[1]),
		lab = args.slice(2),
		visited = {},
		sum,
		count,
		directions = {
			u: {
				row: -1,
				col: 0
			},
			r: {
				row: 0,
				col: +1
			},
			d: {
				row: +1,
				col: 0
			},
			l: {
				row: 0,
				col: -1
			}
		};

	function getValueAt(row, col, cols) {
		return row * cols + col + 1;
	}

	function inRange(value, border) {
		return 0 <= value && value < border;
	}

	sum = 0;
	count = 0;

	while (true) {
		if (!inRange(row, rows) || !inRange(col, cols)) {
			return 'out ' + sum;
		}

		var cellValue = getValueAt(row, col, cols);

		if (visited[cellValue]) {
			return 'lost ' + count;
		}

		sum += cellValue;
		count++;
		visited[cellValue] = true;

		var dir = lab[row][col];
		row +=directions[dir].row;
		col += directions[dir].col;
	};
}
