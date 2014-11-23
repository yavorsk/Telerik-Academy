var canvas = document.getElementById("the-canvas");
var ctx = canvas.getContext("2d");

ctx.lineWidth = 2;
ctx.strokeStyle = "#337c8e";
ctx.fillStyle = "#90cad7";

//bike
drawArcPath(100, 400, 50, 0, 2 * Math.PI, false, true);
drawArcPath(280, 400, 50, 0, 2 * Math.PI, false, true);

ctx.moveTo(180, 400);
ctx.lineTo(198, 418);
ctx.moveTo(180, 400);
ctx.lineTo(162, 382);
ctx.stroke();

ctx.fillStyle = "#4f4f4f";
drawArcPath(180, 400, 12, 0, 2 * Math.PI, false, true);

ctx.moveTo(100, 400);
ctx.lineTo(180, 400);
ctx.lineTo(265, 340);
ctx.lineTo(160, 340);
ctx.closePath();
ctx.stroke();

ctx.moveTo(180, 400);
ctx.lineTo(155, 320);
ctx.moveTo(135, 320);
ctx.lineTo(175, 320);
ctx.stroke();

ctx.moveTo(280, 400);
ctx.lineTo(260, 310);
ctx.moveTo(230, 320);
ctx.lineTo(260, 310);
ctx.moveTo(280, 290);
ctx.lineTo(260, 310);
ctx.stroke();

//head with wings
ctx.fillStyle = "#90cad7";
drawArcPath(150, 200, 50, 0, 2 * Math.PI, false, true);

ctx.save();
ctx.scale(1, 0.6);
drawArcPath(120, 300, 10, 0, 2 * Math.PI, false, false);
drawArcPath(160, 300, 10, 0, 2 * Math.PI, false, false);
ctx.restore();

ctx.fillStyle = "#337c8e"; //22545f
ctx.save();
ctx.scale(0.5, 1);
drawArcPath(234, 180, 4, 0, 2 * Math.PI, false, true);
drawArcPath(314, 180, 4, 0, 2 * Math.PI, false, true);
ctx.restore();

ctx.moveTo(140, 180);
ctx.lineTo(125, 210);
ctx.lineTo(140, 210);
ctx.stroke();

//mouth
ctx.save();
ctx.setTransform(1, 0.1, 0, 0.2, 0, 0);
drawArcPath(140, 1060, 20, 0, 2 * Math.PI, false, false);
ctx.stroke();
ctx.restore();

//hat bottom
ctx.fillStyle = "#396693";
ctx.strokeStyle = "#25211f";
ctx.lineWidth = 5;
ctx.save();
ctx.setTransform(1, 0, 0, 0.2, 0, 0);
drawArcPath(145, 760, 55, 0, 2 * Math.PI, false, true);
ctx.stroke();
ctx.fill();
ctx.restore();

ctx.lineWidth = 1;

ctx.save();
ctx.setTransform(1, 0, 0, 0.35, 0, 0);
drawArcPath(145, 410, 30, 0, Math.PI, false, true);
ctx.stroke();
ctx.fill();
ctx.restore();

//hat side surface
ctx.moveTo(115, 143.5);
ctx.lineTo(115, 92);
ctx.lineTo(175, 92);
ctx.lineTo(175, 143.5);
ctx.fill();
ctx.stroke();

//hat top
ctx.save();
ctx.setTransform(1, 0, 0, 0.35, 0, 0);
drawArcPath(145, 260, 30, 0, 2 * Math.PI, false, true);
ctx.stroke();
ctx.fill();
ctx.restore();

//house walls
ctx.lineWidth = 2;
ctx.fillStyle = "#975b5b";
ctx.strokeStyle = "#000000";
ctx.fillRect(450, 220, 260, 210);
ctx.strokeRect(450, 220, 260, 210);

//house roof
ctx.lineWidth = 3;
ctx.beginPath();
ctx.moveTo(450, 220);
ctx.lineTo(580, 80);
ctx.lineTo(710, 220);
ctx.closePath()
ctx.stroke();
ctx.fill();

//windows
drawWindows(470, 245, 45, 30, "#000000", "#975b5b");
drawWindows(600, 245, 45, 30, "#000000", "#975b5b");
drawWindows(600, 330, 45, 30, "#000000", "#975b5b");

//door
ctx.strokeStyle = "#000000";
ctx.lineWidth = 2;
ctx.save();
ctx.setTransform(1, 0, 0, 0.5, 0, 0);
drawArcPath(515, 695, 35, Math.PI, Math.PI * 2, false, false);
ctx.stroke();
ctx.restore();

ctx.moveTo(480, 430);
ctx.lineTo(480, 347.5);
ctx.moveTo(515, 430);
ctx.lineTo(515, 330);
ctx.moveTo(550, 430);
ctx.lineTo(550, 347.5);
ctx.stroke();

drawArcPath(505, 390, 3, 0, 2 * Math.PI, true, false);
drawArcPath(525, 390, 3, 0, 2 * Math.PI, true, false);

//chimney
ctx.fillStyle = "#975b5b";
ctx.strokeStyle = "#000000";

ctx.moveTo(640, 190);
ctx.lineTo(640, 110);
ctx.lineTo(670, 110);
ctx.lineTo(670, 190);
ctx.fill();
ctx.stroke();

ctx.save();
ctx.lineWidth = 4;
ctx.setTransform(1, 0, 0, 0.2, 0, 0);
drawArcPath(655, 550, 14, 0, 2 * Math.PI, false, true);
ctx.stroke();
ctx.fill();
ctx.restore();


function drawArcPath(x, y, r, from, to, isCounterClockwise, isFilled) {
    ctx.beginPath();
    ctx.arc(x, y, r, from, to, isCounterClockwise);
    if (isFilled) {
        ctx.fill();
    }
    ctx.stroke();
}

function drawWindows(startX, startY, innerWidth, innerHeigth, fillColor, strokeColor) {
    ctx.strokeStyle = strokeColor;
    ctx.fillStyle = fillColor;
    ctx.lineWidth = 3;

    ctx.strokeRect(startX, startY, innerWidth, innerHeigth);
    ctx.fillRect(startX, startY, innerWidth, innerHeigth);

    ctx.strokeRect(startX + innerWidth, startY, innerWidth, innerHeigth);
    ctx.fillRect(startX + innerWidth, startY, innerWidth, innerHeigth);

    ctx.strokeRect(startX, startY + innerHeigth, innerWidth, innerHeigth);
    ctx.fillRect(startX, startY + innerHeigth, innerWidth, innerHeigth);

    ctx.strokeRect(startX + innerWidth, startY + innerHeigth, innerWidth, innerHeigth);
    ctx.fillRect(startX + innerWidth, startY + innerHeigth, innerWidth, innerHeigth);
}