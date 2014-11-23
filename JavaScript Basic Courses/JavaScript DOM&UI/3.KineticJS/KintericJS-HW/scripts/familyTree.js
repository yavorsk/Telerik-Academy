var stage = new Kinetic.Stage({
    container: 'canvas-container',
    width: 600,
    height: 400
});

var layer = new Kinetic.Layer();

var familyMembers = [{
    mother: 'Maria Petrova',
    father: 'Georgi Petrov',
    children: ['Teodora Petrova', 'Peter Petrov']
}, {
    mother: 'Petra Stamatova',
    father: 'Todor Stamatov ',
    children: ['Maria Petrova']
}]

var personName = new Kinetic.Text({
    x: 100,
    y: 60,
    text: familyMembers[0].mother,
    fontSize: 18,
    fontFamily: 'Calibri',
    fill: 'black',
    padding: 15,
    align: 'center'
});

var textWrap = new Kinetic.Rect({
    x: 100,
    y: 60,
    stroke: '#555',
    strokeWidth: 3,
    fill: '#ddd',
    width: personName.width(),
    height: personName.height(),
    cornerRadius: 10
});

layer.add(textWrap);
layer.add(personName);

stage.add(layer);