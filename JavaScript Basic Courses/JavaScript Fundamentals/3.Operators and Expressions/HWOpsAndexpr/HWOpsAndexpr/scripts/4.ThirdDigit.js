//4. Write an expression that checks for given integer if its third digit (right-to-left) is 7. E. g. 1732  true.

var number = 127973;
var thirdDigit = (Math.floor(number / 100)) % 10;

jsConsole.writeLine("The number is " + number + ".");
jsConsole.writeLine("The third digit of the number is " + (thirdDigit == 7 ? "" : "not ") + "equal to 7.");