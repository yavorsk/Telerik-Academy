var stage = new Kinetic.Stage({
    container: 'canvas-container',
    width: 600,
    height: 400
});

var layer = new Kinetic.Layer();

var rectangle = new Kinetic.Rect({
    x: 239,
    y: 75,
    width: 100,
    height: 50,
    fill: 'green',
    stroke: 'black',
    strokeWidth: 4
});

var circle = new Kinetic.Circle({
    x: stage.getWidth() / 2,
    y: stage.getHeight() / 2,
    radius: 60,
    fill: 'red',
    stroke: 'grey',
    strokeWidth: 2
})

var wedge = new Kinetic.Wedge({
    x: 400,
    y: 200,
    radius: 40,
    angle: 60,
    fill: 'orange',
    stroke: 'black',
    strokeRidth: 7,
    rotation: -120
})

var line = new Kinetic.Line({
    points: [73, 70, 340, 23, 450, 60, 500, 20],
    stroke: 'blue',
    strokeWidth: 2,
    lineJoin: 'round',
    dash: [20, 7]
})

var polygon = new Kinetic.Line({
    points: [73, 192, 73, 160, 340, 23, 500, 109, 499, 139, 342, 93],
    fill: '#00D2FF',
    stroke: 'black',
    strokeWidth: 5,
    closed: true
})

var spline1 = new Kinetic.Line({
    points: [73, 160, 340, 23, 500, 109, 300, 109],
    stroke: 'blue',
    strokeWidth: 15,
    lineCap: 'butt',
    tension: 1
})

var spline2 = new Kinetic.Line({
    points: [73, 160, 340, 23, 500, 109, 300, 109],
    stroke: 'red',
    strokeWidth: 10,
    lineCap: 'round',
    tension: 0.5
});

var spline3 = new Kinetic.Line({
    points: [50, 300, 150, 250, 250, 300, 350, 350, 450, 300],
    stroke: 'yellow',
    strokeWidth: 10,
    tension: 0.5
})

var blueBlob = new Kinetic.Line({
    points: [73, 140, 340, 23, 500, 109, 300, 170],
    stroke: 'blue',
    strokeWidth: 10,
    fill: '#aaf',
    tension: 0.8,
    closed: true
});

var redBlob = new Kinetic.Line({
    points: [73, 140, 340, 23, 500, 109],
    stroke: 'red',
    strokeWidth: 10,
    fill: '#faa',
    tension: 1.2,
    closed: true,
    scale: {
        x: .5,
        y: .5
    },
    x: 100,
    y: 50
});

layer.add(polygon);
layer.add(wedge);
layer.add(circle);
layer.add(rectangle);
layer.add(line);

layer.add(blueBlob);
layer.add(redBlob);

layer.add(spline1);
layer.add(spline2);
layer.add(spline3);

stage.add(layer);