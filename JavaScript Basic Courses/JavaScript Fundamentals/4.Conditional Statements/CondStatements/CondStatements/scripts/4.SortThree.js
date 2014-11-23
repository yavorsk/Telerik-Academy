function onSortClick() {
    var first = jsConsole.readFloat("#firstNum");
    var second = jsConsole.readFloat("#secondNum");
    var third = jsConsole.readFloat("#thirdNum");

    var biggest = first;
    var middle = second;
    var smallest = third;

    if (second > biggest) {
        if (third > biggest) {
            smallest = first;
            if (third > second) {
                biggest = third;
                middle = second;
            }
            else {
                biggest = second;
                middle = third;
            }
        }
        else {
            biggest = second;
            if (first >= third) {
                middle = first;
                smallest = third;
            }
            else {
                middle = third;
                smallest = first;
            }
        }
    }
    else {
        if (third > biggest) {
            biggest = third;
            middle = first;
            smallest = second;
        }
        else {
            if (second >= third) {
                middle = second;
                smallest = third;
            }
            else {
                middle = third;
                smallest = second;
            }
        }
    }

    jsConsole.writeLine(biggest + "  " + middle + "  " + smallest);
}