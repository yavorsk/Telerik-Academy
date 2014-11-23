function onNameOfDigitClick() {
    var digit = jsConsole.readFloat("#digit");
    var nameOfDigit = "";

    switch (digit) {
        case 0: nameOfDigit = "zero"; break;
        case 1: nameOfDigit = "one"; break;
        case 2: nameOfDigit = "two"; break;
        case 3: nameOfDigit = "three"; break;
        case 4: nameOfDigit = "four"; break;
        case 5: nameOfDigit = "five"; break;
        case 6: nameOfDigit = "six"; break;
        case 7: nameOfDigit = "seven"; break;
        case 8: nameOfDigit = "eight"; break;
        case 9: nameOfDigit = "nine"; break;
        default: nameOfDigit = "Error";

    }

    if (nameOfDigit == "Error") {
        jsConsole.writeLine("Please enter a digit!");
    }
    else {
        jsConsole.writeLine("The digit is " + nameOfDigit);
    }
}