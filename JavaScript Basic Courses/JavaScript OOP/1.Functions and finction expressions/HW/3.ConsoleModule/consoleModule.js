//Create a module to work with the console object.Implement functionality for:
// - Writing a line to the console 
// - Writing a line to the console using a format
// - Writing to the console should call toString() to each element
// - Writing errors and warnings to the console with and without format

var specialConsole = (function (){

    function writeLine(message) {
        var outputMessage;

        if (arguments.length === 1) {
            outputMessage = message;
        } else {
            outputMessage = formatMessage(arguments);
        }

        console.log(outputMessage);
    }

    function writeError() {
        var outputMessage = formatMessage(arguments);
        console.log(outputMessage);
    }

    function writeWarning() {
        var outputMessage = formatMessage(arguments);
        console.log(outputMessage);
    }

    function formatMessage(params){
        var formatedMessage = params[0];

        for (var i = 1; i < params.length; i++) {

            formatedMessage = formatedMessage.replace('{' + (i - 1) + '}', params[i]);
        }

        return formatedMessage;
    }

    return {
        writeLine: writeLine,
        writeError: writeError,
        writeWarning: writeWarning
    }
})()


specialConsole.writeLine("Message: hello");
//logs to the console "Message: hello"
specialConsole.writeLine("Message: {0}", "hello");
//logs to the console "Message: hello"
specialConsole.writeError("Error: {0}", "Something happened");
specialConsole.writeWarning("Warning: {0}", "A warning");
