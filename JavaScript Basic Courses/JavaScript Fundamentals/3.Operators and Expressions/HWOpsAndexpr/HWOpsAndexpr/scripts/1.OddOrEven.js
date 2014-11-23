//1. Write an expression that checks if given integer is odd or even.

var number = 622;
var oddOrEven = (number % 2 == 0) ? "even." : "odd.";
jsConsole.writeLine("The number is " + oddOrEven);