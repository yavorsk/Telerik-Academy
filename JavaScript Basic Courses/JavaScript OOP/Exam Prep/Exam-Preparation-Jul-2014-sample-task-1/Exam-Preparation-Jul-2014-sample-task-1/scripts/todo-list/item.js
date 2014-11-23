define(function () {
    'use strict';
    var Item;
    Item = (function () {
        function Item(content) {
            this.content = content;
        }

        Item.prototype.getData = function () {
            return this.content;
        }

        return Item;
    })();
    return Item;
});