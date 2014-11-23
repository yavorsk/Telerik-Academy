function sprite(options) {
    var that = {},
        frameIndex = 0,
        tickCount = 0,
        ticksPerFrame = options.ticksPerFrame || 0,
        numberOfFrames = options.numberOfFrames || 1;

    that.context = options.context;
    that.width = options.width;
    that.height = options.height;
    that.image = options.image;

    that.render = function() {
        //clear the canvas
        that.context.clearRect(0, 0, that.width, that.height);

        that.context.drawImage(
            that.image,
            frameIndex * that.width / numberOfFrames,
            0,
            that.width / numberOfFrames,
            that.height,
            0,
            0,
            that.width / numberOfFrames,
            that.height);
    };

    that.update = function() {
        tickCount += 1;
        if (tickCount > ticksPerFrame) {
            tickCount = 0;

            //if the current frame index is in range
            if (frameIndex < numberOfFrames - 1) {
                //go to the next frame
                frameIndex += 1;
            } else {
                frameIndex = 0;
            }
        }
    }

    return that;
};

//get canvas
var canvas = document.getElementById("coinAnimation");
canvas.width = 100;
canvas.height = 100;

var coinImage = new Image();

var coin = sprite({
    context: canvas.getContext("2d"),
    width: 1000,
    height: 100,
    image: coinImage,
    numberOfFrames: 10,
    ticksPerFrame: 4
});

function gameLoop() {
    coin.update();
    coin.render();

    window.requestAnimationFrame(gameLoop);
};

coinImage.addEventListener('load', gameLoop);
coinImage.src = 'images/coin-sprite-animation-sprite-sheet.png';