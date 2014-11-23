//Create a tag cloud:
//    Visualize a string of tags (strings) in a given container
//By given minFontSize and maxFontSize, generate the tags with different font-size, depending on the number of occurrences

var tags = ["cms", "javascript", "js", "ASP.NET MVC", ".net", ".net", "css",
    "wordpress", "xaml", "js", "http", "web", "asp.net", "asp.net MVC", "ASP.NET MVC", "wp",
    "javascript", "js", "cms", "html", "javascript", "http", "http", "CMS" , "http"]

var generateCloud = function () {
    console.log('entered');
    var minFont = document.getElementById('minFont').value | 0;
    var maxFont = document.getElementById('maxFont').value | 0;

    generateTagCloud(tags, minFont, maxFont);
}

var generateButton = document.getElementById('generateCloudBtn');
generateButton.addEventListener('click', generateCloud);

var wordOccurances = {};
var container = document.getElementById('container');

for (var i = 0; i < tags.length; i++) {
    if (wordOccurances[tags[i]]) {
        wordOccurances[tags[i]]++;
    } else {
        wordOccurances[tags[i]] = 1;
    }
}

function generateTagCloud(tags, minFontSize, maxFontSize) {
    removeSpans();

    var minCount = getMinMaxCount(wordOccurances).min;
    var maxCount = getMinMaxCount(wordOccurances).max;

    for (word in wordOccurances) {
        var currentFontSize = Math.floor((maxFontSize - minFontSize) * (wordOccurances[word] - minCount) / (maxCount - minCount)) + minFontSize;

        var spanEl = document.createElement('span');
        spanEl.innerText = word;
        spanEl.style.fontSize = currentFontSize + 'px';
        spanEl.style.margin = '5px';
        spanEl.style.display = 'inline-block';
        container.appendChild(spanEl);
    }
}




function getMinMaxCount(keyValuePair) {
    var minC = 1000000,
        maxC = -1;

    for (key in keyValuePair) {
        if (keyValuePair[key] > maxC) {
            maxC = keyValuePair[key];
        }
        if (keyValuePair[key] < minC) {
            minC = keyValuePair[key];
        }
    }

    return {
        min: minC,
        max: maxC
    }
}

function removeSpans() {
    while (container.firstChild) {
        container.removeChild(container.firstChild);
    };
}