function onSolveEquationClick() {
    var a = jsConsole.readFloat("#a");
    var b = jsConsole.readFloat("#b");
    var c = jsConsole.readFloat("#c");

    if (a == 0) {
        jsConsole.writeLine("The equation is not quadratic!");
    }
    else {
        var discriminant = b * b - 4 * a * c;

        if (discriminant < 0) {
            jsConsole.writeLine("The equation has no real roots.");
        }
        else {
            if (discriminant == 0) {
                var x = -b / (2 * a);
                jsConsole.writeLine("The root of the equation is x=" + x);
            }
            else {
                var x1 = (-b + Math.sqrt(discriminant)) / (2 * a);
                var x2 = (-b - Math.sqrt(discriminant)) / (2 * a);
                jsConsole.writeLine("The roots of the equation are: x1=" + x1 + " x2=" + x2);
            }
        }
    }
}