function findOccurancesOfWord(text, word, isCaseSensitive) {

    function numOfOccCaseInsensitive(text, word) {
        var numOfOcc = 0;
        word = word.toLowerCase();
        text = text.toLowerCase();

        for (var i = 0; i < text.length; i++) {
            for (var j = 0; j < word.length; j++) {
                if (word[j] == text[i + j]) {
                    if (j == word.length - 1) {
                        numOfOcc++;
                    }
                }
                else {
                    break;
                }
            }
        }

        return numOfOcc;
    }

    function numOfOccCaseSensitive(text, word) {
        var numOfOcc = 0;

        for (var i = 0; i < text.length; i++) {
            for (var j = 0; j < word.length; j++) {
                if (word[j] == text[i + j]) {
                    if (j == word.length - 1) {
                        numOfOcc++;
                    }
                }
                else {
                    break;
                }
            }
        }

        return numOfOcc;
    }

    var numberOfOccurances = 0;

    switch (arguments.length) {
        case 2: numberOfOccurances = numOfOccCaseInsensitive(text, word); break;
        case 3: numberOfOccurances = numOfOccCaseSensitive(text, word); break;
    }

    return numberOfOccurances;
}