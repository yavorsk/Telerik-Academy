//Create a module for working with DOM. The module should have the following functionality
//  -   Add DOM element to parent element given by selector
//  -   Remove element from the DOM  by given selector
//  -   Attach event to given selector by given event type and event hander
//  -   Add elements to buffer, which appends them to the DOM when their count for some selector becomes 100
//      The buffer contains elements for each selector it gets
//  -   Get elements by CSS selector
//The module should reveal only the methods

var domModule = (function () {
    var buffer = {};

    function appendChild(element, parentSelector) {
        var parent = document.querySelector(parentSelector);
        parent.appendChild(element);
    }

    function removeChild(parentSelector, childSelector) {
        var elementsToRemove = document.querySelectorAll(childSelector);
        var parent = document.querySelector(parentSelector)

        for (var i = 0; i < elementsToRemove.length; i++) {
            parent.removeChild(elementsToRemove[i]);
        }
    }

    function addHandler(selector, eventType, eventHandler) {
        var element = document.querySelector(selector);
        element.addEventListener(eventType, eventHandler, false);
    }

    function appendToBuffer(selector, element) {
        if (!buffer[selector]) {
            buffer[selector] = document.createDocumentFragment();
        }

        buffer[selector].appendChild(element);

        if (buffer[selector].childNodes.length >= 100) {
            document.querySelector(selector).appendChild(buffer[selector]);
            
            while (buffer[selector].firstChild) {
                buffer[selector].removeChild(buffer[selector].firstChild);
            }
        }
    }

    function getElements(selector) {
        return document.querySelectorAll(selector);
    }

    //function getBuffer() {
    //    return buffer;
    //}

    return {
        appendChild: appendChild,
        removeChild: removeChild,
        addHandler: addHandler,
        appendToBuffer: appendToBuffer,
        getElements: getElements
        //getBuffer: getBuffer
    }
})();

var div = document.createElement("div");
div.innerHTML = 'new Div';
//appends div to #wrapper
domModule.appendChild(div,"#wrapper"); 
//removes li:first-child from ul
domModule.removeChild("ul","li:first-child"); 
//add handler to each a element with class button
domModule.addHandler("a.button", 'click',        
                     function(){alert("Clicked")});
domModule.appendToBuffer("container", div.cloneNode(true));
var navItem = document.createElement('nav');
domModule.appendToBuffer("#main-nav ul", navItem);

//console.log(domModule.getBuffer());

