define(['tech-store-models/item'], function (Item) {
    'use strict';
    var Store;
    Store = (function () {

        var _itemTypes = {
            accessory: 'accessory',
            smartPhone: 'smart-phone',
            notebook: 'notebook',
            pc: 'pc',
            tablet: 'tablet'
        }

        function validateName() {
            if (!(typeof(this.name) === 'string')) {
                return false;
            }
            if (5 < this.name.length && this.name.length < 41) {
                return true;
            }

            return false;
        }

        function Store(name) {
            this.name = name;
            if (!validateName.call(this)) {
                throw new Error('Invalid Name!');
            }
            this.items = [];
        };

        var sortByItemName = function (item1, item2) {
            var name1 = item1.name.toUpperCase();
            var name2 = item2.name.toUpperCase();
            return (name1 < name2) ? -1 : (name1 > name2) ? 1 : 0;
        }

        var sortByItemPrice = function (item1, item2) {
            var price1 = item1.price;
            var price2 = item2.price;
            return price1 - price2;
        }

        Store.prototype = {
            addItem: function (item) {
                if (!(item instanceof Item)) {
                    throw new Error('Invalid Item!');
                }

                this.items.push(item);

                return this;
            },
            getAll: function () {
                var allItemsSorted = this.items.slice(0);
                allItemsSorted.sort(sortByItemName)
                return allItemsSorted;
            },
            getSmartPhones: function () {
                var sortedSmartPhones = [],
                    i,
                    len;

                for (i = 0; len = this.items.length,  i < len; i++) {
                    if (this.items[i].type === _itemTypes.smartPhone) {
                        sortedSmartPhones.push(this.items[i]);
                    };
                }
                sortedSmartPhones.sort(sortByItemName);
                return sortedSmartPhones;
            },
            getMobiles: function () {
                var sortedMobiles = [],
                    i,
                    len;

                for (i = 0; len = this.items.length, i < len; i++) {
                    if (this.items[i].type === _itemTypes.smartPhone || this.items[i].type === _itemTypes.tablet) {
                        sortedMobiles.push(this.items[i]);
                    };
                }
                sortedMobiles.sort(sortByItemName);
                return sortedMobiles;
            },
            getComputers: function () {
                var sortedComputers = [],
                    i,
                    len;

                for (i = 0; len = this.items.length, i < len; i++) {
                    if (this.items[i].type === _itemTypes.notebook || this.items[i].type === _itemTypes.pc) {
                        sortedComputers.push(this.items[i]);
                    };
                }
                sortedComputers.sort(sortByItemName);
                return sortedComputers;
            },
            filterItemsByType: function (filterType) {
                var filteredItems = [],
                    i,
                    len;

                for (i = 0; len = this.items.length, i < len; i++) {
                    if (this.items[i].type === filterType) {
                        filteredItems.push(this.items[i]);
                    };
                }
                filteredItems.sort(sortByItemName);
                return filteredItems;
            },
            filterItemsByPrice: function (options) {
                var filteredByPrice = [],
                    min,
                    max,
                    i,
                    len;

                if (options) {
                    min = options.min || 0;
                    max = options.max || 1.7976931348623157E+10308;
                } else {
                    min = 0;
                    max = 1.7976931348623157E+10308;
                }

                for (i = 0; len = this.items.length, i < len; i++) {
                    if (min < this.items[i].price && this.items[i].price < max) {
                        filteredByPrice.push(this.items[i]);
                    }
                }

                filteredByPrice.sort(sortByItemPrice);
                return filteredByPrice;
            },
            countItemsByType: function () {
                var numberOfItemsByType = {},
                    i,
                    len;

                for (i = 0; len = this.items.length, i < len; i++) {
                    if (numberOfItemsByType[this.items[i].type]) {
                        numberOfItemsByType[this.items[i].type]++;
                    } else {
                        numberOfItemsByType[this.items[i].type] = 1;
                    }
                }

                return numberOfItemsByType;
            },
            filterItemsByName: function (partOfName) {
                var itemsBypartOfname = [],
                    i,
                    len;
                partOfName = partOfName.toLowerCase();

                for (i = 0; len = this.items.length, i < len; i++) {
                    var currentName = this.items[i].name.toLowerCase();
                    if (currentName.indexOf(partOfName) > -1) {
                        itemsBypartOfname.push(this.items[i]);
                    }
                }

                itemsBypartOfname.sort(sortByItemName);
                return itemsBypartOfname;
            }
        }

        return Store;
    }())

    return Store;
});