var Category = require('mongoose').model('Category');

module.exports = {
    getCategories: function(callback) {
        return Category.find({}, callback);
    }
};