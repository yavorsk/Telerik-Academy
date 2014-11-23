
function pointBuilder(pX, pY) {
    return {
        coordX: pX,
        coordY: pY,
        toString: function getCoords() {
            return 'coordX=' + this.coordX + '; ' + 'coordY=' + this.coordY + ';';
        }
    }
}

function segmentBuilder(firstPt, secondPt) {
    return {
        pt1: firstPt,
        pt2: secondPt,
        toString: function () {
            return 'First point coords: ' + this.pt1.toString() + '\n' + 'Second point coords: ' + this.pt2.toString();
        },
        length: function () {
            var length = distBetweenTwoPts(this.pt1, this.pt2);
            return length;
        }
    }
}

function distBetweenTwoPts(firstPt, secondPt) {
    var distX = firstPt.coordX - secondPt.coordX;
    var distY = firstPt.coordY - secondPt.coordY;

    var distance = Math.sqrt(Math.pow(distX, 2) + Math.pow(distY, 2));

    return roundTo(distance, 3);
}

function canFormTriangle(segmentA, segmentB, segmentC) {
    var result = (segmentA.length() < segmentB.length() + segmentC.length())
        && (segmentB.length() < segmentA.length() + segmentC.length())
        && (segmentC.length() < segmentB.length() + segmentA.length());

    return result;
}

function roundTo(num, decimals) {
    return +(Math.round(num + "e+" + decimals) + "e-" +decimals);
}