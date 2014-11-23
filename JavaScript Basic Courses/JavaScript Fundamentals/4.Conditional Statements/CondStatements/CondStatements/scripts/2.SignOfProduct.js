function onShowSignOfProductButtonClick() {
    var first = jsConsole.readFloat("#firstNum");
    var second = jsConsole.readFloat("#secondNum");
    var third = jsConsole.readFloat("#thirdNum");

    var productIsPositive = true;

    if (first < 0) {
        if (second < 0) {
            if (third < 0) {
                productIsPositive = false;
            }
            else {
                productIsPositive = true;
            }
        }
        else {
            if (third < 0) {
                productIsPositive = true;
            }
            else {
                productIsPositive = false;
            }
        }
    }
    else {
        if (second < 0) {
            if (third < 0) {
                productIsPositive = true;
            }
            else {
                productIsPositive = false;
            }
        }
        else {
            if (third < 0) {
                productIsPositive = false;
            }
            else {
                productIsPositive = true;
            }
        }
    }

    if (first == 0 || second == 0 || third == 0) {
        productIsPositive = true;
    }

    jsConsole.writeLine("The sign of the product of the three numbers is: " + (productIsPositive ? "+" : "-"));
}