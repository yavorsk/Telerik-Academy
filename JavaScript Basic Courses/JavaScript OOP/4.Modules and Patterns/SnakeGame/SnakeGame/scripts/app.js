/// <reference path="_reference.js" />
(function () {
    var renderer = snakeGame.renderer.getCanvasRenderer('#the-canvas');
    var theGame = snakeGame.game.getNewGame(renderer);

    theGame.start();
}())