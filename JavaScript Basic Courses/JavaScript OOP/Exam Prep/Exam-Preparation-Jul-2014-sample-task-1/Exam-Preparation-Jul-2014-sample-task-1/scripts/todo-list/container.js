define(function () {
    'use strict';
    var Container;
    Container = (function () {
        function Container() {
            this.sections = [];
        }

        Container.prototype.add = function (section) {
            this.sections.push(section);
        }

        Container.prototype.getData = function () {
            var data = [];

            for (var i = 0; i < this.sections.length; i++) {

                data.push(this.sections[i].getData());
            }

            return data
        }

        return Container;
    }());
    return Container;
});