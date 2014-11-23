/// <reference path="_reference.js" />

var snakeGame = snakeGame || {};
snakeGame.gameObjects = (function () {
    var OBJECT_SIZE = 10;

    var directions = {
        'right': {
            dx: 1,
            dy: 0
        },
        'left': {
            dx: -1,
            dy: 0
        },
        'up': {
            dx: 0,
            dy: -1
        },
        'down': {
            dx: 0,
            dy: 1
        }
    };

    function GameObject(x, y, size) {
        this.x = x;
        this.y = y;
        this.size = size;
    }

    GameObject.prototype = {
        getPosition: function () {
            return {
                x: this.x,
                y: this.y
            };
        },
        getSize: function () {
            return this.size;
        }
    };

    function SnakeLink(x, y, size) {
        GameObject.call(this, x, y, size);
    }

    SnakeLink.prototype = new GameObject();
    SnakeLink.prototype.constructor = SnakeLink;
    SnakeLink.prototype.changePosition = function (x, y) {
        this.x = x;
        this.y = y;
    };

    function SnakeHead(x, y, size) {
        SnakeLink.call(this, x, y, size);
    }

    SnakeHead.prototype = new SnakeLink();
    SnakeHead.prototype.constructor = SnakeHead;

    function Snake(x, y, size) {
        var link,
            linkX,
            linkY;
        this.links = [];
        this.direction = 'right';
        for (var i = 0; i < size; i++) {
            linkX = x - i * OBJECT_SIZE;
            linkY = y;
            link = new SnakeLink(linkX, linkY, OBJECT_SIZE);
            this.links.push(link);
        }
    }

    Snake.prototype = new GameObject();
    Snake.prototype.constructor = Snake;
    Snake.prototype.head = function () {
        return this.links[0];
    };
    Snake.prototype.getPosition = function () {
        return this.head().getPosition();
    };
    Snake.prototype.changePosition = function (x, y) {
        this.head().changePosition(x, y);
    };
    Snake.prototype.move = function () {
        for (var i = this.links.length - 1; i > 0; i--) {
            var newLinkPosition = this.links[i - 1].getPosition();
            this.links[i].changePosition(newLinkPosition.x, newLinkPosition.y);
        }
        var currentHeadPosition = this.head().getPosition();
        var newHeadPositionX = currentHeadPosition.x + directions[this.direction].dx * OBJECT_SIZE;
        var newHeadPositionY = currentHeadPosition.y + directions[this.direction].dy * OBJECT_SIZE;
        this.head().changePosition(newHeadPositionX, newHeadPositionY);
    };
    Snake.prototype.changeDirection = function (newDirection) {
        if (this.direction != newDirection) {
            this.direction = newDirection;
        }
    };

    function Apple(x, y) {
        GameObject.call(this, x, y, OBJECT_SIZE);
    }

    Apple.prototype = new GameObject();
    Apple.prototype.constructor = Apple;
    Apple.prototype.changePosition = function (x, y) {
        this.x = x;
        this.y = y;
    }

    function Obstacle(x, y, size) {
        GameObject.call(this, x, y, size);
    }

    Obstacle.prototype = new GameObject();
    Obstacle.prototype.constructor = Obstacle;

    return {
        getSnake: function (x, y, size) {
            return new Snake(x, y, size);
        },
        getApple: function (x, y) {
            return new Apple(x, y);
        },
        getSnakeLink: function (x, y) {
            return new SnakeLink(x, y, OBJECT_SIZE);
        },
        getObstacle: function (x, y) {
            return new Obstacle(x, y, OBJECT_SIZE);
        }
    };
}());