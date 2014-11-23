// Write a script that creates a number of div elements. Each div element must have the following
//   - Random width and height between 20px and 100px
//   - Random background color
//   - Random font color
//   - Random position on the screen (position:absolute)
//   - A strong element with text "div" inside the div
//   - Random border radius
//   - Random border color
//   - Random border width between 1px and 20px

var createDivsBtn = document.getElementById('create-divs-btn');
var removeDivsBtn = document.getElementById('remove-divs-btn');
var container = document.getElementById('container');

createDivsBtn.addEventListener('click', function () {
    var divsCount = document.getElementById('divs-count').value;
    onCreateDivsBtnClick(divsCount);
});
removeDivsBtn.addEventListener('click', onRemoveDivsBtnClick);

function onCreateDivsBtnClick(divsCount) {
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

        var divTopPos = getRandomNumber(divBorderWidth, container.offsetHeight - (divHeight + 2 * divBorderWidth));
        var divLeftPos = getRandomNumber(divBorderWidth, container.offsetWidth - (divWidth + 2 * divBorderWidth));

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

function onRemoveDivsBtnClick() {
    while (container.firstChild) {
        container.removeChild(container.firstChild);
    };
}