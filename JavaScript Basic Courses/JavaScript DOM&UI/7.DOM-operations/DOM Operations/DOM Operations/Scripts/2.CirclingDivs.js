//Write a script that creates 5 div elements and moves them in circular path with interval of 100 milliseconds

var createDivsBtn = document.getElementById('create-divs-btn');
var rotateDivsBtn = document.getElementById('rotate-divs-btn');
var container = document.getElementById('container');
var path = {
    centerX: container.offsetWidth / 2,
    centerY: container.offsetHeight / 2,
    radius: container.offsetHeight / 4
}

createDivsBtn.addEventListener('click', function () {
    var divsCount = 5;
    onCreateDivsBtnClick(divsCount);
});

rotateDivsBtn.addEventListener('click', function () {
    onRotateDivsBtnClick(path);
});

function onCreateDivsBtnClick(divsCount) {
    RemoveDivs();
    var dFrag = document.createDocumentFragment();

    for (var i = 0; i < divsCount; i++) {
        var divItem = document.createElement('div');

        var divWidth = getRandomNumber(20, 100);
        var divHeight = getRandomNumber(20, 100);
        var divBackGroundColor = getRandomColour();
        var divFontColor = getRandomColour();

        var divInnerText = '<strong>div</strong>';

        var divBorderRadius = getRandomNumber(0, (divWidth < divHeight) ? (divWidth / 2) : (divHeight / 2));
        var divBorderColor = getRandomColour();
        var divBorderWidth = getRandomNumber(1, 20);

        var divCenterPosition = getRandomPointOnCircle(path);

        var divTopPos = divCenterPosition.y - (divHeight / 2);
        var divLeftPos = divCenterPosition.x - (divWidth / 2);

        divItem.style.width = divWidth + 'px';
        divItem.style.height = divHeight + 'px';
        divItem.style.background = divBackGroundColor;
        divItem.style.color = divFontColor;

        divItem.innerHTML = divInnerText;

        divItem.style.borderRadius = divBorderRadius + 'px';
        divItem.style.borderColor = divBorderColor;
        divItem.style.borderWidth = divBorderWidth + 'px';
        divItem.style.borderStyle = 'solid';

        divItem.style.position = 'absolute';
        divItem.display = 'block';
        divItem.style.top = divTopPos + 'px';
        divItem.style.left = divLeftPos + 'px';

        divItem.style.textAlign = 'center';

        dFrag.appendChild(divItem);
    }

    container.appendChild(dFrag);
}

function onRotateDivsBtnClick(path) {
    var divs = container.childNodes;

    frame();

    function frame() {
        for (var i = 0; i < divs.length; i++) {
            var divCurrentCenterX = divs[i].offsetLeft + divs[i].offsetWidth;
            var divCurrentCenterY = divs[i].offsetTop + divs[i].offsetHeight;
            var divCurrentAngle = Math.atan2(divCurrentCenterY - path.centerY, divCurrentCenterX - path.centerX);

            var divNewCenterX = path.centerX + Math.cos(divCurrentAngle + 0.01) * path.radius;
            var divNewCenterY = path.centerY + Math.sin(divCurrentAngle + 0.01) * path.radius;

            divs[i].style.top = (divNewCenterY - divs[i].offsetHeight) + 'px';
            divs[i].style.left =(divNewCenterX - divs[i].offsetWidth) + 'px';
        }

        requestAnimationFrame(frame);
        //setTimeout(frame, 100);
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

function getRandomPointOnCircle(path) {
    var angle = Math.random() * Math.PI * 2;

    var xCoord = path.centerX + Math.cos(angle) * path.radius;
    var yCoord = path.centerY + Math.sin(angle) * path.radius;

    return {
        x: xCoord,
        y: yCoord
    }
}

function RemoveDivs() {
    while (container.firstChild) {
        container.removeChild(container.firstChild);
    };
}
