//Create a dynamic select using Handlebars.js
//The options in the select should be generated based on a collection of JavaScript objects

var items = [{
    value: 1,
    text: 'one'
}, {
    value: 2,
    text: 'two'
}, {
    value: 3,
    text: 'three'
}, {
    value: 4,
    text: 'four'
}, {
    value: 5,
    text: 'five'
}, {
    value: 6,
    text: 'six'
}, {
    value: 7,
    text: 'seven'
}, {
    value: 8,
    text: 'eight'
}, {
    value: 9,
    text: 'nine'
}, {
    value: 10,
    text: 'ten'
}];

var selectTemplateHtml = document.getElementById('select-template').innerHTML;
var selectTemplate = Handlebars.compile(selectTemplateHtml);

document.getElementById('container').innerHTML = selectTemplate({items : items});