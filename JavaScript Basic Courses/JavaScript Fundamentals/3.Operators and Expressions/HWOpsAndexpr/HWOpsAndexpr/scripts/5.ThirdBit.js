//5.Write a boolean expression for finding if the bit 3 (counting from 0) of a given integer is 1 or 0.

var number = 73;
var thirdBitIsOne = ((number >> 3) & 1) == 1;

jsConsole.writeLine("The number is " + number + ".");
jsConsole.writeLine("Binary representation of the number: " + number.toString(2) + ".");
jsConsole.writeLine("The third bit of the number is 1? ----> " + thirdBitIsOne);