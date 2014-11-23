function Solve(args) {
    var keyValuePairs = {};
    var sections = {};

    var N = parseInt(args[0]);
    var M = parseInt(args[N + 1]);
    var startRow = N + 2;

    var inIfStatement = false;
    var ifIsTrue = false;

    var inForeacheLoop = false;
    var item = '';
    var collectionName = '';
    var collectionCounter = 0;
    var loopStartIndex = 0;


    parsePairs();
    //console.log(keyValuePairs); //test parsePairs

    parseSections();
    //console.log(sections); // test parseSections

    var result = [];

    for (var j = startRow; j < args.length; j++) {

        var inputLine = args[j];
        var resultLine = inputLine;

        if (inIfStatement) {
            if (inputLine.indexOf('}') != -1) {
                inIfStatement = false;
                ifIsTrue = false;
                continue;
            }
            if (!ifIsTrue) {
                continue;
            }
        }

        if (inForeacheLoop) {
            if ((inputLine.indexOf('}') != -1) && collectionCounter == keyValuePairs[collectionName].length) {
                inForeacheLoop = false;
                item = '';
                collectionName = '';
                collectionCounter = 0;
                continue;
            }
            if (inputLine.indexOf('}') != -1) {
                j = loopStartIndex;
                continue;
            }

            var strToReplace = '@' + item;
            var replacement = keyValuePairs[collectionName][collectionCounter];

            if (inputLine.indexOf(strToReplace) != -1) {
                resultLine = inputLine.replace(strToReplace, replacement);
                collectionCounter++;
            }
        }

        //escape @
        if (inputLine.indexOf('@@') != -1) {
            resultLine = inputLine.replace('@@', '@');
            result.push(resultLine);
            continue;
        }

        //render sections
        if (inputLine.indexOf('@renderSection(') != -1) {
            var sectKey = getWord(inputLine, (inputLine.indexOf('@renderSection(') + 16));

            for (var k = 0; k < sections[sectKey].length; k++) {
                result.push(sections[sectKey][k]);
            }

            continue;
        }

        //if statement
        if ((inputLine.indexOf('@if ') != -1) && (inputLine.indexOf('{') != -1)) {
            inIfStatement = true;
            var ifCondition = getWord(inputLine, (inputLine.indexOf('@if ') + 5));

            if (keyValuePairs[ifCondition] == 'true') {
                ifIsTrue = true;
                continue;
            } else {
                ifIsTrue = false;
                continue;
            }
        }

        //foreach loop
        if (inputLine.indexOf('@foreach ' != -1) && (inputLine.indexOf('{') != -1)) {
            inForeacheLoop = true;

            item = getWord(inputLine, (inputLine.indexOf('var ') + 4));
            collectionName = getWord(inputLine, (inputLine.indexOf(' in ') + 4));
            loopStartIndex = j;

            continue;
        }

        //key - value replace
        var indexOfAt = resultLine.indexOf('@');
        if (indexOfAt != -1) {
            while (indexOfAt != -1) {

                var wordForKeyReplace = getWord(resultLine, (indexOfAt + 1));

                if (wordForKeyReplace in keyValuePairs) {
                    resultLine = resultLine.replace(('@' + wordForKeyReplace), keyValuePairs[wordForKeyReplace]);
                }

                indexOfAt = resultLine.indexOf('@', (indexOfAt + 1))
            };

            result.push(resultLine);
            continue;
        }

        //regular line
        //resultLine = inputLine;
        result.push(resultLine);
    }


    //print final result
    for (var i = 0; i < result.length; i++) {
        console.log(result[i]);
    }

    function parseSections() {
        for (var i = startRow; i < args.length; i++) {
            if (args[i].indexOf('@section') == 0) {
                var sectionKey = getWord(args[i], 9);
                var sectionValue = [];
                for (var j = i + 1; j < args.length; j++) {
                    var sectionLine = args[j];
                    if (sectionLine.indexOf('}') != -1) {
                        i = j;
                        break;
                    }
                    sectionValue.push(sectionLine);
                }

                sections[sectionKey] = sectionValue;
            } else {
                startRow = i;
                break;
            }
        }
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

    function getWord(str, index) {
        var word = '';

        for (var i = index; i < str.length; i++) {
            if (str[i] == ' ' || str[i] == '(' || str[i] == '<' || str[i] == '\"' || str[i] == ')') {
                break;
            }
            word += str[i];
        }

        return word;
    }
}

var test0 = [
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

var test1 = [
    '0',
    '15',
    '<div>',
    '    <p>',
    '    @@if (pesho)',
    '        @@escaped dude',
    '    </p>',
    '    <p>',
    '    @@renderSection("pesho")',
    '    </p>',
    '    <p>',
    '    @@foreach(var pesho in peshos)',
    '        @@escaped in comment',
    '    </p>',
    '</div>'
]

var test2 = [
    '0',
    '21',
    '@section first {',
    '<ul>',
    '    <li>',
    '        In section UL',
    '    </li>',
    '    <li>',
    '        Still in section UL',
    '    </li>',
    '</ul>',
    '}',
    '@section second {',
    '<div>',
    '    Second section :)',
    '</div>',
    '}',
    '<div>',
    '    @renderSection("first")',
    '    @renderSection("second")',
    '</div>'
]

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

var test5 = [
    '4',
    'passTheIf:true',
    'doNotPassTheIf:false',
    'pesho:na peshlqka modela',
    'gosho:i gosho e tuka brato',
    '14',
    '<div>',
    '    <p>Some bulsh*t text + @pesho & @gosho</p>',
    '    <br />',
    '    @if (passTheIf) {',
    '        <span>Passed @pesho and @gosho</span>',
    '    }',
    '    <br />',
    '    <div>',
    '        <span>More bulsh*t text</span>',
    '        @if (doNotPassTheIf) {',
    '            <span>if this passes this is error @pesho and @gosho</span>',
    '        }',
    '    <div>',
    '</div>'
]

var test9 = [
    '5',
    'pesho:gosho',
    'gosho:pesho',
    'if:gadno',
    'foreach:hackvane',
    'renderSection:ivaylo sucks ;D',
    '8',
    '<div>',
    '    @@if (pesho)',
    '    @if (pesho)',
    '    @foreach (var nqma in nikoi)',
    '    @pesho ',
    '    @gosho ',
    '    @renderSection ',
    '</div>'
]

var test10 = [
    '5',
    'peshov:goshoviq',
    'goshov:peshoviq',
    'ifaylo:gadno a?',
    'foreachable:hackvane ima tuk',
    'renderSectionirane:ivaylo sucks more ;D',
    '8',
    '<div>',
    '    @@if (peshov)',
    '    @ifaylo (peshov)',
    '    @foreachable (var nqma in nikoi)',
    '    @peshov ',
    '    @goshov ',
    '    @renderSectionirane ',
    '</div>'
]

Solve(test0);