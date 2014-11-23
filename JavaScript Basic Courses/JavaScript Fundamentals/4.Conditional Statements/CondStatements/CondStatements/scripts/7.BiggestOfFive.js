function onShowBiggestClick() {
    var first = jsConsole.readFloat("#firstNum");
    var second = jsConsole.readFloat("#secondNum");
    var third = jsConsole.readFloat("#thirdNum");
    var fourth = jsConsole.readFloat("#fourthNum");
    var fifth = jsConsole.readFloat("#fifthNum");

    var numbers = new Array(first, second, third, fourth, fifth);

    var biggest = first;

    for (var i = 0; i < numbers.length; i++) { //niamah nervi...
        if (numbers[i] > biggest) {
            biggest = numbers[i];
        }
    }

    jsConsole.writeLine("The biggest of the numbers is: " + biggest);
}