var canvas = document.getElementById("the-canvas");
var ctx = canvas.getContext("2d");
ctx.lineWidth = 2;
ctx.strokeStyle = "red";
ctx.fillStyle = "yellow";

var speed = 3;
var isMoving = true;

var points = [];

var startPoint = pointBuilder(100, 100);

var ball = ballBuilder(startPoint.x, startPoint.y, 20, 1, 1);

setInterval(animation, 10);

function animation() {
    if (isMoving == true) {
        ctx.clearRect(0, 0, 800, 500);
        ball.updateDirections();
        ball.move();
        ball.drawTrail();
        ball.draw();
    }

}

function ballBuilder(posX, posY, radius, dirX, dirY) {
    return {
        x: posX,
        y: posY,
        radius: radius,
        directionX: dirX,
        directionY: dirY,
        draw: function() {
            drawArcPath(this.x, this.y, this.radius, 0, 2 * Math.PI, false);
        },
        updateDirections: function() {
            if ((this.y + this.directionY * speed) < this.radius ||
                (this.y + this.directionY * speed) > canvas.height - this.radius) {
                this.directionY *= -1;
                points.push(pointBuilder(this.x, this.y));
            }
            if ((this.x + this.directionX * speed) < this.radius ||
                (this.x + this.directionX * speed) > canvas.width - this.radius) {
                this.directionX *= -1;
                points.push(pointBuilder(this.x, this.y));
            }
        },
        move: function() {
            this.x = this.x + this.directionX * speed;
            this.y = this.y + this.directionY * speed;
        },
        drawTrail: function() {
            ctx.save();
            ctx.strokeStyle = "red";
            ctx.setLineDash([6]);
            ctx.beginPath();
            ctx.moveTo(startPoint.x, startPoint.y);
            for (var i = 0; i < points.length; i++) {
                ctx.lineTo(points[i].x, points[i].y);
            }
            ctx.lineTo(this.x, this.y);
            ctx.stroke();
            ctx.restore();
        }
    };
}

function drawArcPath(x, y, r, from, to, isCounterClockwise) {
    ctx.save();
    ctx.beginPath();
    ctx.arc(x, y, r, from, to, isCounterClockwise);
    ctx.closePath();
    ctx.fill();
    ctx.stroke();
    ctx.restore();
}

function pointBuilder(pointX, pointY) {
    return {
        x: pointX,
        y: pointY
    }
}

document.getElementById('startBtn').addEventListener('click', function() {
    isMoving = true;
});
document.getElementById('stopBtn').addEventListener('click', function() {
    isMoving = false;
});