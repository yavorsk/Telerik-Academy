var paper = Raphael(10, 10, 500, 500);
var x, y, angle;
var path = 'M260 260';

for (i = 0; i < 360; i++) {
    angle = 0.1 * i;
    x = 260 + (1 + 4 * angle) * Math.cos(angle);
    y = 260 + (1 + 4 * angle) * Math.sin(angle);
    path += ' L ' + x + ' ' + y;
}

paper.path(path);