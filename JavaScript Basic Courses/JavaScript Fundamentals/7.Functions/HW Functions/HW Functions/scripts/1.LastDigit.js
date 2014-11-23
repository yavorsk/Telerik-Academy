function getLastDigitWord(num) {
    var lastDigit = getLastDigit(num);
    var lastDigitStr;

    switch (lastDigit) {
        case 0: lastDigitStr = "zero"; break;
        case 1: lastDigitStr = "one"; break;
        case 2: lastDigitStr = "two"; break;
        case 3: lastDigitStr = "three"; break;
        case 4: lastDigitStr = "four"; break;
        case 5: lastDigitStr = "five"; break;
        case 6: lastDigitStr = "six"; break;
        case 7: lastDigitStr = "seven"; break;
        case 8: lastDigitStr = "eight"; break;
        case 9: lastDigitStr = "nine"; break;
    }

    return lastDigitStr;
}

function getLastDigit(numb) {
    return numb % 10;
}