define(function () {
    'use strict';
    var Item;
    Item = (function () {

        var _itemTypes = {
            accessory: 'accessory',
            smartPhone: 'smart-phone',
            notebook: 'notebook',
            pc: 'pc',
            tablet: 'tablet'
        }

        function validateType() {
            var result = false;

            for (var type in _itemTypes) {
                if (_itemTypes[type] === this.type) {
                    result = true;
                }
            }
            
            return result;
        }

        function validateName() {
            if (!(typeof(this.name) === 'string')) {
                return false;
            }
            if ( 5 < this.name.length && this.name.length < 41) {
                return true;
            }

            return false;
        }

        function Item(type, name, price) {
            this.type = type;
            if (!validateType.call(this)) {
                throw new Error('Invalid Type!');
            }
            this.name = name;
            if (!validateName.call(this)) {
                throw new Error('Invalid Name!');
            }
            this.price = price;
            if (!(typeof(this.price) === 'number')) {
                throw new Error('Invalid Price!');
            }
        };

        return Item;
    }())

    return Item;
});