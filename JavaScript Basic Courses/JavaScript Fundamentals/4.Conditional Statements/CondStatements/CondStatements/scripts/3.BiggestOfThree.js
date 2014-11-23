function onShowBiggestClick() {
    var first = jsConsole.readFloat("#firstNum");
    var second = jsConsole.readFloat("#secondNum");
    var third = jsConsole.readFloat("#thirdNum");

    var biggest = first;

    if (second > biggest) {
        biggest = second;
        if (third > biggest) {
            biggest = third;
        }
    }
    else {
        if (third > biggest) {
            biggest = third;
        }
    }

    jsConsole.writeLine("The biggest of the numbers is: " + biggest);
}