//6. Write an expression that checks if given print (x,  y) is within a circle K(O, 5).

var pointX = -3.5;
var pointY = 4;
var circleRadius = 5;

var isWithinCircle = (Math.sqrt(pointX * pointX + pointY * pointY)) <= circleRadius;

jsConsole.writeLine("Point coordinate X: " + pointX);
jsConsole.writeLine("Point coordinate Y: " + pointY);

if (isWithinCircle) {
    jsConsole.writeLine("The point is within the circle");
}
else {
    jsConsole.writeLine("The point is out of the circle");
}