var paper = Raphael(10, 10, 800, 500);

var logo = paper.path('M52 62 l 12.98 -12.98 l 33.23 33.23 l -16.77 16.77 l -16.77 -16.77 l 33.23 -33.23 l 12.98 12.98');
logo.attr({
    'stroke-width': 7,
    stroke: '#5ce600'
})
logo.transform('s0.85,0.85,80,98t5,0');

paper.text(120, 80, 'Telerik').attr({
    'text-anchor': 'start',
    'font-weight': 'bold',
    'font-size': '60',
    'font-family': 'Calibri',
});

paper.text(128, 115, 'Develop experiences').attr({
    'text-anchor': 'start',
    'font-weight': '100',
    'font-size': '25',
    'font-family': 'Calibri',
});

paper.circle(295, 78, 5);

paper.text(295, 78, 'R').attr({
    'font-size': '7'
});


//youtube

var you = paper.text(60, 200, 'You');
you.attr({
    'font-size': '80',
    'font-family': 'Arial Narrow',
    'font-weight': 'bold',
    'text-anchor': 'start',
    fill: '#4b4b4b'
}).transform('s0.8,1');

var monitor = paper.rect(175, 158, 145, 84, 20)
monitor.attr({
    fill: '#ec2828',
    stroke: 'none'
})

var tube = paper.text(170, 200, 'Tube');
tube.attr({
    'font-size': '80',
    'font-family': 'Arial Narrow',
    'font-weight': 'bold',
    "text-anchor": "start",
    fill: 'white'
}).transform('s0.8,1');