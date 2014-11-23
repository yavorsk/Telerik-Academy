(function () {
    var startBtn = document.getElementById('start-btn');
    var viewHighScoreBtn = document.getElementById('view-high-score-btn');
    var clearHighScoreBtn = document.getElementById('clear-high-score-btn');
    var inputBox = document.getElementById('input-field');
    var submitBtn = document.getElementById('submit-btn');
    var messageBox = document.getElementById('message-box');
    var logList = document.getElementById('log-list');
    var highScoreBox = document.getElementById('high-score-box');
    var deleteHighScoreBtn = document.getElementById('delete-high-score-btn');
    var gameRunning = false;

    var loadAndViewHighScore = function () {
        var highScore = [];

        for (var i = 0; i < localStorage.length; i++) {
            var currentNick = localStorage.key(i);
            var currentScore = localStorage.getItem(currentNick);

            highScore.push({
                nick: currentNick,
                score: currentScore
            })
        }

        highScore.sort(function (a, b) {
            return a.score - b.score;
        })

        var dFrag = document.createDocumentFragment();

        for (var i = 0; i < highScore.length; i++) {
            var li = document.createElement('li');
            li.innerHTML = highScore[i].nick + ': ' + highScore[i].score + ' turns';
            dFrag.appendChild(li);
        }

        highScoreBox.innerHTML = '';
        highScoreBox.appendChild(dFrag);
    }

    startBtn.addEventListener('click', function () {
        if (!gameRunning) {
            gameInit();
        }
    });
    viewHighScoreBtn.addEventListener('click', loadAndViewHighScore);
    deleteHighScoreBtn.addEventListener('click', function () { localStorage.clear();})
    clearHighScoreBtn.addEventListener('click', function () {
        highScoreBox.innerHTML = '';
    })

    function gameInit() {
        var secretNumber = generateSecretNumber();
        console.log(secretNumber);
        gameRunning = true;
        gameRun(secretNumber);
    }

    function gameRun(secretNumber) {
        var userInput;
        var turnCounter = 0;

        var handleInput = function () {
            userInput = inputBox.value;

            if (inputIsCorrect(userInput)) {
                messageBox.innerHTML = '';
                messageBox.style.color = 'black';

                turnCounter++;
                handleGameTurn();
            } else {
                messageBox.style.color = 'red';
                messageBox.innerHTML = 'you should submit a number with four different digits and is greater than 999!';
            }
        }

        submitBtn.addEventListener('click', handleInput);
        
        function handleGameTurn() {
            var currentResult = getCountOfRamsAndSheeps(userInput, secretNumber);
            messageBox.innerHTML = 'You have ' + currentResult.rams + ' rams and ' + currentResult.sheep + ' sheep.';

            var currentTurnLogLI = document.createElement('li');
            currentTurnLogLI.innerHTML = userInput + ' ---> ' + currentResult.rams + ' rams, ' + currentResult.sheep + ' sheep.';
            logList.appendChild(currentTurnLogLI);

            if (currentResult.rams === 4) {
                var winMessasge = 'Congratulations, you won in ' + turnCounter + ' turns!\nPlease enter your nickname:';
                var nickName = prompt(winMessasge, 'anonymous');
                gameRunning = false;
                messageBox.innerHTML = 'You WON!';
                logList.innerHTML = '';
                submitBtn.removeEventListener('click', handleInput);
                savePlayerResult(nickName, turnCounter);
            }
        }
    }

    function savePlayerResult(nickName, result) {
        localStorage.setItem(nickName, result);
    }



    function inputIsCorrect(inputString) {
        var num = parseInt(inputString)
        if (num) {
            if (1000 <= num && num <= 9999 && isCorrectNumber(num)) {
                return true;
            } else {
                return false;
            }
        } else {
            return false;
        }
    }

    function getCountOfRamsAndSheeps(number, secretNumber) {
        var result = {
            rams: 0,
            sheep: 0
        }

        var numberStr = number.toString();
        var secretNumberStr = secretNumber.toString();

        for (var i = 0; i < numberStr.length; i++) {
            if (numberStr[i] === secretNumberStr[i]) {
                result.rams++;
            }
        }

        for (var i = 0; i < numberStr.length; i++) {
            for (var j = 0; j < secretNumberStr.length; j++) {
                if (i !== j) {
                    if (numberStr[i] === secretNumberStr[j]) {
                        result.sheep++;
                    }
                }
            }
        }

        return result;
    }

    function generateSecretNumber() {
        var secretNumber = getRandomFourDigitNumber();

        while (!isCorrectNumber(secretNumber)) {
            secretNumber = getRandomFourDigitNumber();
        }

        return secretNumber;
    }

    function isCorrectNumber(number) {
        var numberStr = number.toString();

        for (var i = 0; i < numberStr.length - 1; i++) {
            for (var j = i + 1; j < numberStr.length; j++) {
                if (numberStr[i] === numberStr[j]) {
                    return false;
                }
            }
        }

        return true;
    }

    function getRandomFourDigitNumber() {
        return Math.floor(Math.random() * (9999 - 1000 + 1) + 1000);
    }
}())