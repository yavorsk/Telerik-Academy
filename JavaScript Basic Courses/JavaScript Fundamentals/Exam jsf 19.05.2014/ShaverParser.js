function Solve(args) {
    var keyValuePairs = {};
    var sections = {};

    var N = parseInt(args[0]);
    var M = parseInt(args[N + 1]);

    parsePairs();

    var result = [];

    var inSection = false;
    var inSectionDef = false;
    var inIfStatement = false;
    var positiveIf = false;
    var startIf = false;

    for (var j = N + 2; j < args.length; j++) {
        var inputLine = args[j];

        if (inIfStatement == true) {
            if (inputLine.indexOf('}') != -1) {
                inIfStatement = false;
                continue;
            }

            if (positiveIf) {

            } else {
                continue;
            }
        }

        if (inputLine.indexOf('@section') == 0) {
            inSectionDef = true;
            var sectionKey = getWord(inputLine, 8);

            var sectionValue = [];
            for (var k = j + 1; k < args.length; k++) {
                var sectionLine = args[k];
                if (sectionLine.indexOf('}') != -1) {
                    j = k;
                    break;
                }
                sectionValue.push(sectionLine);
            }

            sections[sectionKey] = sectionValue;
        }

        var resultLine = '';

        for (var k = 0; k < inputLine.length; k++) {
            if (inputLine[k] == '@') {

                var command = getWord(inputLine, k);

                if (command == 'renderSection') {
                    inSection = true;
                    var keyOfSection = getWord(inputLine, k + 15);
                    //console.log(keyOfSection);
                    for (var l = 0; l < sections[keyOfSection].length; l++) {
                        result.push(sections[keyOfSection][l]);
                    }

                } else if (command == 'if') {
                    var condition = getWord(inputLine, k + 4);

                    if (keyValuePairs[condition]) {
                        inIfStatement = true;
                        startIf = true;
                        positiveIf = true;
                    } else {
                        inIfStatement = true;
                        positiveIf = false;
                        startIf = true;
                    }
                } else {
                    resultLine += keyValuePairs[command];
                    k += command.length + 1;
                }

            } else {
                resultLine += inputLine[k];
            }
        }


        if (inSection) {
            inSection = false;
        } else if (inSectionDef) {
            inSectionDef = false;
        } else if (startIf) {
            startIf = false;
        } else {
            result.push(resultLine);
        }
    }

    for (var i = 0; i < result.length; i++) {
        console.log(result[i]);
    }
    //console.log(sections);

    function getWord(str, index) {
        var word = '';

        for (var i = index + 1; i < str.length; i++) {
            if (str[i] == ' ' || str[i] == '(' || str[i] == '<' || str[i] == '\"' || str[i] == ')') {
                break;
            }
            word += str[i];
        }

        return word;
    }

    function parsePairs() {
        for (var i = 1; i < N + 1; i++) {
            var pairsLine = args[i];
            var indexOfCollon = pairsLine.indexOf(':');
            var key = pairsLine.substring(0, indexOfCollon);
            var value = pairsLine.substring(indexOfCollon + 1, pairsLine.length);

            if (value.indexOf(',') == -1) {
                keyValuePairs[key] = value;
            } else {
                var values = value.split(',');
                keyValuePairs[key] = values;
            }
        }
    }
}
var test3 = [
    '2',
    'text:RandomText',
    'anotherText:RandomTextAgain',
    '10',
    '<div>',
    '    <div>',
    '        @text ',
    '    </div>',
    '    <ul>',
    '        <li>',
    '             <span>@anotherText</span>',
    '        </li>',
    '    </ul>',
    '</div>'
]



var myTest = [
    '3',
    'abv:zxy',
    'ttt:yyy',
    'mmm:ooo',
    '5',
    '</head>@ttt',
    '<body>',
    '    @mmm',
    '',
    '    <h1>@abv</h1>'
]

//Solve(myTest);

var test = [
    '6',
    'title:Telerik Academy',
    'showSubtitle:true',
    'subTitle:Free training',
    'showMarks:false',
    'marks:3,4,5,6',
    'students:Pesho,Gosho,Ivan',
    '42',
    '@section menu {',
    '<ul id="menu">',
    '    <li>Home</li>',
    '    <li>About us</li>',
    '</ul>',
    '}',
    '@section footer {',
    '<footer>',
    '    Copyright Telerik Academy 2014',
    '</footer>',
    '}',
    '<!DOCTYPE html>',
    '<html>',
    '<head>',
    '    <title>Telerik Academy</title>',
    '</head>',
    '<body>',
    '    @renderSection("menu")',
    '',
    '    <h1>@title</h1>',
    '    @if (showSubtitle) {',
    '        <h2>@subTitle</h2>',
    '        <div>@@JustNormalTextWithDoubleKliomba ;)</div>',
    '    }',
    '',
    '    <ul>',
    '        @foreach (var student in students) {',
    '            <li>',
    '                @student ',
    '            </li>',
    '            <li>Multiline @title</li>',
    '        }',
    '    </ul>',
    '    @if (showMarks) {',
    '        <div>',
    '            @marks ',
    '        </div>',
    '    }',
    '',
    '    @renderSection("footer")',
    '</body>',
    '</html>'
];

//Solve(test);

var test4 = [
    '2',
    'passTheIf:true',
    'doNotPassTheIf:false',
    '14',
    '<div>',
    '    <p>Some bulsh*t text</p>',
    '    <br />',
    '    @if (passTheIf) {',
    '        <span>Passed</span>',
    '    }',
    '    <br />',
    '    <div>',
    '        <span>More bulsh*t text</span>',
    '        @if (doNotPassTheIf) {',
    '            <span>if this passes this is error</span>',
    '        }',
    '    <div>',
    '</div>'
]

Solve(test3);
//Solve(test4);
for (var i = 4; i < test3.length; i++) {
    console.log(test3[i]);
}