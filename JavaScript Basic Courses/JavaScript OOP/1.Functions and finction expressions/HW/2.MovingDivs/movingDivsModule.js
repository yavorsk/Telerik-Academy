//Create a module that works with moving div nodes. Implement functionality for:
// - Add new moving div element to the DOM
// - The module should generate random background, font and border colors for the div element
// - All the div elements are with the same width and height
// - The movements of the div nodes can be either circular or rectangular
// - The elements should be moving all the time


var movingShapes = (function () {
    var DIV_HEIGHT = 50;
    var DIV_WIDTH = 80;
    var STEP = 5;
    var container = document.getElementById('container');

    var ellipsePath = {
        centerX: container.offsetWidth / 2,
        centerY: container.offsetHeight / 2,
        radius: container.offsetHeight / 3
    }

    var rectPath = {
        bottomLeftX: container.offsetWidth / 2 - 250,
        bottomLeftY: container.offsetHeight / 2 + 100,
        topRightX: container.offsetWidth / 2 + 250,
        topRightY: container.offsetHeight / 2 - 100
    }

    var divsOnEllipsePath = [];
    var divsOnRectangularPath = [];
    //var divsOnRectDirections = {};

    var direction = {
        right: 'right',
        down: 'down',
        left: 'left',
        up: 'up'
    }

    var started = false;

    function add(trajectory) {
        var newDiv = createDiv();

        switch (trajectory) {
            case 'rect': addDivToRectPath(newDiv); break;
            case 'ellipse': addDivToEllipsePath(newDiv); break;
        }

        if (!started) {
            started = true;
            moveDivsOnEllipsePath();
            moveDivsOnRectPath();
        }
    }

    function createDiv() {
        var divItem = document.createElement('div');

        var divBackGroundColor = getRandomColour();
        var divFontColor = getRandomColour();
        var divBorderColor = getRandomColour();

        divItem.style.width = DIV_WIDTH + 'px';
        divItem.style.height = DIV_HEIGHT + 'px';
        divItem.style.background = divBackGroundColor;
        divItem.style.color = divFontColor;
        divItem.innerHTML = 'div';
        divItem.style.borderColor = divBorderColor;
        divItem.style.borderStyle = 'solid';
        divItem.style.position = 'absolute';
        divItem.display = 'block';
        divItem.style.textAlign = 'center';

        return divItem;
    }

    function addDivToRectPath(divElement) {
        var divCenterPosition = getRandomPointOnRect();
        
        var divTopPos = divCenterPosition.y - (DIV_HEIGHT / 2);
        var divLeftPos = divCenterPosition.x - (DIV_WIDTH / 2);

        divElement.style.top = divTopPos + 'px';
        divElement.style.left = divLeftPos + 'px';

        divsOnRectangularPath.push({
            element: divElement,
            direction: direction.right
        });

        container.appendChild(divElement);
    }

    function addDivToEllipsePath(divElement) {
        var divCenterPosition = getRandomPointOnCircle();

        var divTopPos = divCenterPosition.y - (DIV_HEIGHT / 2);
        var divLeftPos = divCenterPosition.x - (DIV_WIDTH / 2);

        divElement.style.top = divTopPos + 'px';
        divElement.style.left = divLeftPos + 'px';

        divsOnEllipsePath.push(divElement);
        container.appendChild(divElement);
    }

    function moveDivsOnEllipsePath() {
        frame();

        function frame() {
            for (var i = 0; i < divsOnEllipsePath.length; i++) {
                var divCurrentCenterX = divsOnEllipsePath[i].offsetLeft + divsOnEllipsePath[i].offsetWidth;
                var divCurrentCenterY = divsOnEllipsePath[i].offsetTop + divsOnEllipsePath[i].offsetHeight;
                var divCurrentAngle = Math.atan2(divCurrentCenterY - ellipsePath.centerY, divCurrentCenterX - ellipsePath.centerX);

                var divNewCenterX = ellipsePath.centerX + Math.cos(divCurrentAngle + 0.03) * ellipsePath.radius;
                var divNewCenterY = ellipsePath.centerY + Math.sin(divCurrentAngle + 0.03) * ellipsePath.radius;

                divsOnEllipsePath[i].style.top = (divNewCenterY - divsOnEllipsePath[i].offsetHeight) + 'px';
                divsOnEllipsePath[i].style.left = (divNewCenterX - divsOnEllipsePath[i].offsetWidth) + 'px';
            }

            requestAnimationFrame(frame);
        }
    }

    function moveDivsOnRectPath() {
        frame();

        function frame() {
            for (var i = 0; i < divsOnRectangularPath.length; i++) {
                var divCurrentCenterX = divsOnRectangularPath[i].element.offsetLeft + divsOnRectangularPath[i].element.offsetWidth / 2;
                var divCurrentCenterY = divsOnRectangularPath[i].element.offsetTop + divsOnRectangularPath[i].element.offsetHeight / 2;
                var divNewCenterX;
                var divNewCenterY;

                if (divsOnRectangularPath[i].direction == direction.right) {
                    divNewCenterX = divCurrentCenterX + STEP;
                    divNewCenterY = divCurrentCenterY;
                    if (divNewCenterX >= rectPath.topRightX) {
                        divNewCenterX = rectPath.topRightX;
                        divsOnRectangularPath[i].direction = direction.down;
                    } 
                } else if (divsOnRectangularPath[i].direction == direction.down) {
                    divNewCenterX = divCurrentCenterX;
                    divNewCenterY = divCurrentCenterY + STEP;
                    if (divNewCenterY >= rectPath.bottomLeftY) {
                        divNewCenterY = rectPath.bottomLeftY;
                        divsOnRectangularPath[i].direction = direction.left;
                    }
                } else if (divsOnRectangularPath[i].direction == direction.left) {
                    divNewCenterX = divCurrentCenterX - STEP;
                    divNewCenterY = divCurrentCenterY;
                    if (divNewCenterX <= rectPath.bottomLeftX) {
                        divNewCenterX = rectPath.bottomLeftX;
                        divsOnRectangularPath[i].direction = direction.up;
                    }
                } else if (divsOnRectangularPath[i].direction == direction.up) {
                    divNewCenterX = divCurrentCenterX;
                    divNewCenterY = divCurrentCenterY - STEP;
                    if (divNewCenterY <= rectPath.topRightY) {
                        divNewCenterY = rectPath.topRightY;
                        divsOnRectangularPath[i].direction = direction.right;
                    }
                }

                divsOnRectangularPath[i].element.style.top = (divNewCenterY - divsOnRectangularPath[i].element.offsetHeight / 2) + 'px';
                divsOnRectangularPath[i].element.style.left = (divNewCenterX - divsOnRectangularPath[i].element.offsetWidth / 2) + 'px';
            }

            requestAnimationFrame(frame);
        }
    }

    function getRandomNumber(min, max) {
        var result = Math.floor((Math.random() * (max + 1 - min)) + min);
        return result;
    }

    function getRandomColour() {
        var r = getRandomNumber(0, 255);
        var g = getRandomNumber(0, 255);
        var b = getRandomNumber(0, 255);

        var result = 'rgb(' + r + ', ' + g + ', ' + b + ')';

        return result;
    }

    function getRandomPointOnCircle() {
        var angle = Math.random() * Math.PI * 2;

        var xCoord = ellipsePath.centerX + Math.cos(angle) * ellipsePath.radius;
        var yCoord = ellipsePath.centerY + Math.sin(angle) * ellipsePath.radius;

        return {
            x: xCoord,
            y: yCoord
        }
    }

    function getRandomPointOnRect() {
        return {
            x: getRandomNumber(rectPath.bottomLeftX, rectPath.topRightX),
            y: rectPath.topRightY
        }
    }

    return {
        add: add
    }
})()

document.getElementById('add-on-rect').addEventListener('click', function () {
    movingShapes.add('rect');
})

document.getElementById('add-on-ellipse').addEventListener('click', function () {
    movingShapes.add('ellipse');
})

////add element with rectangular movement
//movingShapes.add("rect");
////add element with ellipse movement
//movingShapes.add("ellipse");
