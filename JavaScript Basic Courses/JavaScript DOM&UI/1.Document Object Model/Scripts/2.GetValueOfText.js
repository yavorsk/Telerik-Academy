// 2. Create a function that gets the value of <input type="text"> ands prints its value to the console

function onPrintValueOfTextClick() {
    var textBox = document.getElementById('inputText');

    var text = textBox.value;

    console.log(text);
}