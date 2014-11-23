//7. Write an expression that checks if given positive integer number n (n ≤ 100) is prime. E.g. 37 is prime.

var number = 73;

var isPrime = true;

for (var i = 2; i <= 10; i++) {
    if (number % i == 0) {
        isPrime = false;
    }
}

jsConsole.writeLine("The number " + number + " is " + (isPrime ? "" : "not ") + "prime.");