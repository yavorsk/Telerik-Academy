//2. Write a boolean expression that checks for given integer if it can be divided (without remainder) 
// by 7 and 5 in the same time.

var number = 35;
var isDivisible = (number % 5 == 0) && (number % 7 == 0);

jsConsole.writeLine("The number " + number + " is " + (isDivisible ? "" : "not ") + "divisible by 5 and 7 in the same time.");
