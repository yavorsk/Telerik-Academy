function drawPen(e) {
    var stage = e.target.stage;
    var mainLayer = e.target.mainLayer;
    var isMouseDown = false;
    var mouseClickX;
    var mouseClickY;
    var lineWeight = 1;
    var strokeColor = 'black';

    var paper = document.getElementById('canvas-container');

    paper.addEventListener('mousedown', handleMouseDown);

    paper.addEventListener('mouseup', handleMouseUp);

    paper.addEventListener('mousemove', handleMouseMove);

    function handleMouseDown(ev) {
        isMouseDown = true;
        mouseClickX = ev.layerX
        mouseClickY = ev.layerY
        lineWeight = document.getElementById('strokeWeight').value;
        strokeColor = document.getElementById('strokeColor').value;
    }

    function handleMouseMove(ev) {
        paper.style.cursor = 'crosshair';
        if (isMouseDown) {
            var freeLine = new Kinetic.Line({
                points: [mouseClickX, mouseClickY, ev.layerX, ev.layerY],
                stroke: strokeColor,
                strokeWidth: lineWeight,
                lineCap: 'round',
                lineJoin: 'round'
            })

            mouseClickX = ev.layerX
            mouseClickY = ev.layerY

            mainLayer.add(freeLine);
            stage.add(mainLayer);
        }
    }

    function handleMouseUp() {
        isMouseDown = false;

        paper.removeEventListener('mousedown', handleMouseDown);
        paper.removeEventListener('mouseup', handleMouseUp);
        paper.removeEventListener('mousemove', handleMouseMove);
    }
}