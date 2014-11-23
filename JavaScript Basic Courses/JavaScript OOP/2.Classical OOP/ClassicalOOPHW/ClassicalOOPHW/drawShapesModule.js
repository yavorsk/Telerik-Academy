//Create a module for drawing shapes using Canvas. Implement the following shapes:
//  - Rect, by given position (X, Y) and size (Width, Height)
//  - Circle, by given center position (X, Y) and radius (R)
//  - Line, by given from (X1, Y1) and to (X2, Y2) positions

var CanvasDrawer = (function () {

    function CanvasDrawer(selector) {
        var canvas = document.querySelector(selector);

        this._ctx = canvas.getContext("2d");
    }

    CanvasDrawer.prototype = {
        drawRectangle: function (topLeftX, topLeftY, width, height) {
            this._ctx.strokeRect(topLeftX, topLeftY, width, height);
        },
        drawCircle: function (centerX, centerY, radius) {
            this._ctx.beginPath();
            this._ctx.arc(centerX, centerY, radius, 0, 2 * Math.PI, true);
            this._ctx.stroke();
        },
        drawLine: function (startX, startY, endX, endY) {
            this._ctx.beginPath();
            this._ctx.moveTo(startX, startY);
            this._ctx.lineTo(endX, endY);
            this._ctx.stroke();
        }
    }

    return CanvasDrawer;
}())

////////////////////////////////////
// The following are Rect, Circle and Line objects which draw themselves on the given canvas
////////////////////////////////////

//var canvas = document.getElementById("the-canvas");
//var context = canvas.getContext("2d");

//var Rect = (function (ctx) {
    
//    function Rect(topLeftX, topLeftY, width, height) {
//        this._topLeftX = topLeftX;
//        this._topLeftY = topLeftY;
//        this._width = width;
//        this._height = height;
//    }

//    Rect.prototype.draw = function () {
//        ctx.strokeRect(this._topLeftX, this._topLeftY, this._width, this._height);
//    }

//    return Rect;
//}(context))

//var Circle = (function (ctx) {

//    function Circle(centerX, centerY, radius) {
//        this._centerX = centerX;
//        this._centerY = centerY;
//        this._radius = radius;
//    }

//    Circle.prototype.draw = function () {
//        ctx.beginPath();
//        ctx.arc(this._centerX, this._centerY, this._radius, 0, 2*Math.PI, true);
//        ctx.stroke();
//    }

//    return Circle;
//}(context))

//var Line = (function (ctx) {

//    function Line(startX, startY, endX, endY) {
//        this._startX = startX;
//        this._startY = startY;
//        this._endX = endX;
//        this._endY = endY;
//    }

//    Line.prototype.draw = function () {
//        ctx.beginPath();
//        ctx.moveTo(this._startX, this._startY);
//        ctx.lineTo(this._endX, this._endY);
//        ctx.stroke();
//    }

//    return Line;
//}(context))

//var rectangle = new Rect(50, 50, 100, 200);
//rectangle.draw();

//var circle = new Circle(200, 200, 150);
//circle.draw();

//var line = new Line(150, 50, 450, 300);
//line.draw();

//var line2 = new Line(700, 450, 13, 15);
//line2.draw();

//var circle2 = new Circle(500, 150, 200);
//circle2.draw();