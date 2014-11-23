// 3. Crеate a function that gets the value of <input type="color"> and sets the background of the body to this value

function setBackGroundColor(colorBox) {
    var backgroundColor = colorBox.value;

    document.body.style.backgroundColor = backgroundColor;;
}