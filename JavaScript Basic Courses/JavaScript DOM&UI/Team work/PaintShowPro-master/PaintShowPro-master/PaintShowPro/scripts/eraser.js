function eraser(e) {
    var stage = e.target.stage;
    var mainLayer = e.target.mainLayer;
    var isMouseDown = false;
    //var mouseClickX;
    //var mouseClickY;
    var eraserWeight = 1;
    //var strokeColor = 'white';
    //var fillColor = 'white';

    var paper = document.getElementById('canvas-container');

    paper.addEventListener('mousedown', handleMouseDown);
    paper.addEventListener('mouseup', handleMouseUp);
    paper.addEventListener('mousemove', handleMouseMove);

    function handleMouseDown(ev) {
        isMouseDown = true;
        //mouseClickX = ev.layerX
        //mouseClickY = ev.layerY
        eraserWeight = document.getElementById('strokeWeight').value;
    }

    function handleMouseMove(ev) {
        paper.style.cursor = 'crosshair';
        if (isMouseDown) {
            var mouseClickX = ev.layerX;
            var mouseClickY = ev.layerY;

            var eraserCircle = new Kinetic.Circle({
                x: mouseClickX,
                y: mouseClickY,
                radius: eraserWeight,
                fill: 'white',
                stroke: 'white',
                strokeWidth: 1,
                draggable: false
            })

            mainLayer.add(eraserCircle);
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