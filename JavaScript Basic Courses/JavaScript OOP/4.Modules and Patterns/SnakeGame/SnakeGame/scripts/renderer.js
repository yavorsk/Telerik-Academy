/// <reference path="_reference.js" />

var snakeGame = snakeGame || {};
snakeGame.renderer = (function () {

    function drawSnakeLink(canvas, snakeLink) {
        var ctx = canvas.getContext('2d');

        ctx.fillStyle = 'green';
        //ctx.strokeStyle = 'black';

        var position = snakeLink.getPosition();

        ctx.fillRect(position.x, position.y, snakeLink.getSize(), snakeLink.getSize());
        //ctx.strokeRect(position.x, position.y, snakeLink.getSize(), snakeLink.getSize());
    }

    function Renderer(canvasSelector) {
        this.canvas = document.querySelector(canvasSelector);
    }

    Renderer.prototype = {
        drawSnake: function (snake) {
            for (var i = 0; i < snake.links.length; i++) {
                drawSnakeLink(this.canvas, snake.links[i]);
            }
        },
        drawApple: function (apple) {
            var ctx = this.canvas.getContext('2d');

            ctx.fillStyle = 'red';
            ctx.strokeStyle = 'black';

            ctx.beginPath();
            ctx.arc(apple.getPosition().x, apple.getPosition().y, 5, 0, 2 * Math.PI);
            ctx.fill();
            ctx.stroke();
        },
        drawObstacle: function (obstacle) {
            var ctx = this.canvas.getContext('2d');
            ctx.fillStyle = 'gray';
            ctx.strokeStyle = 'black';
            var position = obstacle.getPosition();
            ctx.fillRect(position.x, position.y, obstacle.getSize(), obstacle.getSize());
        },
        drawEndGame: function () {
            var ctx = this.canvas.getContext('2d');
            ctx.strokeStyle = "black";
            ctx.fillStyle = "red";
            ctx.font = '80px san-serif';
            ctx.textBaseline = 'bottom';
            ctx.strokeText('GAME OVER', 180, 200);
            ctx.fillText('GAME OVER', 180, 200);
        },
        clear: function () {
            var ctx = this.canvas.getContext('2d');
            ctx.clearRect(0, 0, this.canvas.width, this.canvas.height);
        },
        getCanvasSize: function () {
            return {
                width: this.canvas.width,
                height: this.canvas.height
            };
        }
    };

    return {
        getCanvasRenderer: function (selector) {
            return new Renderer(selector);
        }
    };
}());