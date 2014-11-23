//9. Write an expression that checks for given point (x, y) if it is within the circle K( (1,1), 3) 
// and out of the rectangle R(top=1, left=-1, width=6, height=2).

var coordX = 2;
var coordY = 3;

var circleCenterX = 1;
var circleCenterY = 1;
var circleRadius = 3;

var rectangleTopLeftX = -1;
var rectangleTopLeftY = 1;
var rectangleWidth = 6;
var rectangleHeight = 2;

var isWithinCircle = (Math.sqrt((circleCenterX - coordX) * (circleCenterX - coordX) + (circleCenterY - coordY) * (circleCenterY - coordY))) <= circleRadius;
var isOutOfRectangle = ((coordY < (rectangleTopLeftY - rectangleHeight)) || (rectangleTopLeftY < coordY)) && ((coordX < rectangleTopLeftX) || ((rectangleTopLeftX + rectangleWidth) < coordX));

jsConsole.writeLine("The point is within the circle and out of the rectangle ---> " + (isWithinCircle && isOutOfRectangle));
