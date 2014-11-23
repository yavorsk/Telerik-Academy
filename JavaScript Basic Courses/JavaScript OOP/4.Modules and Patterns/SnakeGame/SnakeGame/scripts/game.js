/// <reference path="_reference.js" />
var snakeGame = snakeGame || {};
snakeGame.game = (function () {
    var OBJECT_SIZE = 10;
    var COUNT_OF_OBSTACLES = 30;
    var snakeEnlargement = 8;

    function Game(renderer) {
        this.renderer = renderer;
        this.snake = snakeGame.gameObjects.getSnake(250, 250, 20);
        this.apple = snakeGame.gameObjects.getApple(Math.random() * this.renderer.getCanvasSize().width,
                                                    Math.random() * this.renderer.getCanvasSize().height);
        this.obstacles = [];
        while (this.obstacles.length < COUNT_OF_OBSTACLES) {
            var obst = snakeGame.gameObjects.getObstacle(Math.random() * this.renderer.getCanvasSize().width,
                                                    Math.random() * this.renderer.getCanvasSize().height);
            //TODO: check if position of the obstacle is free!!!
            this.obstacles.push(obst);
        }

        this.bindKeyEvents();
        this.state = 'running';
    }

    function animationFrame() {
        var appleEaten;

        thisGame.renderer.clear();

        var lastLinkPosition = thisGame.snake.links[thisGame.snake.links.length - 1].getPosition();

        thisGame.snake.move();

        checkCollisionWithSelf();
        checkCollisionWithBoundaries();
        checkCollisionWithObstacles();

        appleEaten = checkAppleEating();

        if (appleEaten || snakeEnlargement != 5) {
            if (snakeEnlargement > 0) {
                var newLink = snakeGame.gameObjects.getSnakeLink(lastLinkPosition.x, lastLinkPosition.y);
                thisGame.snake.links.push(newLink);
                snakeEnlargement--;
            } else {
                appleEaten = false;
                snakeEnlargement = 5;
            }
        };

        thisGame.renderer.drawSnake(thisGame.snake);
        thisGame.renderer.drawApple(thisGame.apple);
        for (var i = 0; i < thisGame.obstacles.length; i++) {
            thisGame.renderer.drawObstacle(thisGame.obstacles[i]);
        }

        if (thisGame.state === 'running') {
            setTimeout(animationFrame, 100);
        } else {
            thisGame.renderer.drawEndGame();
        }
    }

    function checkAppleEating() {
        var currentPosition = thisGame.snake.getPosition();
        var applePosition = thisGame.apple.getPosition();
        var distanceX = currentPosition.x - applePosition.x;
        var distanceY = currentPosition.y - applePosition.y;
        var result = false;

        if ((0 - (1.5 * OBJECT_SIZE)) < distanceX && distanceX < (0.5 * OBJECT_SIZE) &&
             (0 - (1.5 * OBJECT_SIZE)) < distanceY && distanceY < (0.5 * OBJECT_SIZE)) {

            thisGame.apple.changePosition(Math.random() * thisGame.renderer.getCanvasSize().width,
                                          Math.random() * thisGame.renderer.getCanvasSize().height);
            result = true;
        }

        return result;
    }

    function checkCollisionWithSelf() {
        var currentPosition = thisGame.snake.getPosition();

        for (var i = 1; i < thisGame.snake.links.length; i++) {
            var currentLink = thisGame.snake.links[i];

            if (currentPosition.x == currentLink.getPosition().x && currentPosition.y == currentLink.getPosition().y) {
                thisGame.state = 'stopped';
            }
        }
    }

    function checkCollisionWithObstacles() {
        var currentPosition = thisGame.snake.getPosition();
        for (var i = 0; i < thisGame.obstacles.length; i++) {
            var obstPosition = thisGame.obstacles[i].getPosition();
            var distanceX = currentPosition.x - obstPosition.x;
            var distanceY = currentPosition.y - obstPosition.y;

            if ((0 - (0.8 * OBJECT_SIZE)) < distanceX && distanceX < (0.8 * OBJECT_SIZE) &&
             (0 - (0.8 * OBJECT_SIZE)) < distanceY && distanceY < (0.8 * OBJECT_SIZE)) {
                thisGame.state = 'stopped';
            }
        }
    }

    function checkCollisionWithBoundaries() {
        var currentPosition = thisGame.snake.getPosition();

        if (currentPosition.x < 0 && thisGame.snake.direction == 'left' ||
            currentPosition.x >= thisGame.renderer.getCanvasSize().width && thisGame.snake.direction == 'right' ||
            currentPosition.y < 0 && thisGame.snake.direction == 'up' ||
            currentPosition.y >= thisGame.renderer.getCanvasSize().height && thisGame.snake.direction == 'down') {
            thisGame.state = 'stopped';
        }
    }

    Game.prototype = {
        start: function () {
            thisGame = this;
            animationFrame();
        },
        bindKeyEvents: function () {
            var self = this;
            document.body.addEventListener('keydown', function (ev) {
                var keyCode = ev.keyCode;
                switch (keyCode) {
                    case 37: if (self.snake.direction != 'right') {
                        self.snake.changeDirection('left');
                    } break;
                    case 38: if (self.snake.direction != 'down') {
                        self.snake.changeDirection('up');
                    }; break;
                    case 39: if (self.snake.direction != 'left') {
                        self.snake.changeDirection('right');
                    }; break;
                    case 40: if (self.snake.direction != 'up') {
                        self.snake.changeDirection('down');
                    }; break;
                    default: break;
                }
            })
        }
    }
    //var snake = snakeGame.gameObjects.getSnake(250, 250, 15);
    //var renderer = snakeGame.renderer.getCanvasRenderer('#the-canvas');

    return {
        getNewGame: function (renderer) {
            return new Game(renderer);
        }
    }
}())