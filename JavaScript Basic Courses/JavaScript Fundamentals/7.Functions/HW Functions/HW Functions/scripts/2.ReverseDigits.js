﻿function ReverseDigits(num) {
    var numStrReversed = reverseString(num.toString())

    var numReversed = parseInt(numStrReversed);

    return numReversed;
}

function reverseString(str) {
    var reversedStr = "";

    for (var i = str.length - 1; i >= 0; i--) {
        reversedStr += str[i];
    }

    return reversedStr;
}