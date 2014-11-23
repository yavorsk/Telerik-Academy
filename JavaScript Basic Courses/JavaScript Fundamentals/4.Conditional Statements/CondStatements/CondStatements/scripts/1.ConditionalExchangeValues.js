function onFindBiggerButtonClick() {
    var first = jsConsole.readFloat("#firstNum");
    var second = jsConsole.readFloat("#secondNum");

    if (first > second) {
        first = first + second;
        second = first - second;
        first = first - second;
    }

    jsConsole.writeLine("first number: " + first);
    jsConsole.writeLine("second number: " + second);
}