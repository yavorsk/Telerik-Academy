//Create a text area and two inputs with type="color"
//    Make the font color of the text area as the value of the first color input
//Make the background color of the text area as the value of the second input

var textBox = document.getElementById('text-area');
var fontColorChanger = document.getElementById('font-color');
var backGroundColorChanger = document.getElementById('background-color');

fontColorChanger.addEventListener('change', function () {
    textBox.style.color = fontColorChanger.value;
})

backGroundColorChanger.addEventListener('change', function () {
    textBox.style.backgroundColor = backGroundColorChanger.value;
})