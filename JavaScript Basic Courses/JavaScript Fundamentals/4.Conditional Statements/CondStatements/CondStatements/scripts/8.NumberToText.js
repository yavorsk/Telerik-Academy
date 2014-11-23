function onNameOfNumberClick() {
    var number = jsConsole.readFloat("#number");

    var ones = number % 10;
    var tens = (Math.floor(number / 10)) % 10;
    var hundreds = (Math.floor(number / 100)) % 10;

    var onesText = "";
    var tensText = "";
    var hundredsText = "";

    switch (hundreds) {
        case 1: hundredsText = "one hundred"; break;
        case 2: hundredsText = "two hundred"; break;
        case 3: hundredsText = "three hundred"; break;
        case 4: hundredsText = "four hundred"; break;
        case 5: hundredsText = "five hundred"; break;
        case 6: hundredsText = "six hundred"; break;
        case 7: hundredsText = "seven hundred"; break;
        case 8: hundredsText = "eight hundred"; break;
        case 9: hundredsText = "nine hundred"; break;
        case 0: hundredsText = ""; break;
        default: hundredsText = ""; break;
    }

    switch (tens) {
        case 1: {
            switch (ones) {
                case 1: tensText = "eleven"; break;
                case 2: tensText = "twelve"; break;
                case 3: tensText = "thirteen"; break;
                case 4: tensText = "fourteen"; break;
                case 5: tensText = "fifteen"; break;
                case 6: tensText = "sixteen"; break;
                case 7: tensText = "seventeen"; break;
                case 8: tensText = "eighteen"; break;
                case 9: tensText = "nineteen"; break;
                case 0: tensText = "ten"; break;
            } break;
        }
        case 2: tensText = "twenty"; break;
        case 3: tensText = "thirty"; break;
        case 4: tensText = "fourty"; break;
        case 5: tensText = "fifty"; break;
        case 6: tensText = "sixty"; break;
        case 7: tensText = "seventy"; break;
        case 8: tensText = "eighty"; break;
        case 9: tensText = "ninety"; break;
        case 0: {
            if (ones != 0 && hundreds != 0) {
                tensText = "and";
            }
            else {
                tensText = "";
            }
        }; break;
    }

    if (tens != 1) {
        switch (ones) {
            case 1: onesText = "one"; break;
            case 2: onesText = "two"; break;
            case 3: onesText = "three"; break;
            case 4: onesText = "four"; break;
            case 5: onesText = "five"; break;
            case 6: onesText = "six"; break;
            case 7: onesText = "seven"; break;
            case 8: onesText = "eight"; break;
            case 9: onesText = "nine"; break;
            case 0: {
                if (hundreds == 0 && tens == 0) {
                    onesText = "zero";
                }
                else {
                    onesText = "";
                }
            } break;
        }
    }
    else {
        onesText = "";
    }

    jsConsole.writeLine(hundredsText + " " + tensText + " " + onesText);
}