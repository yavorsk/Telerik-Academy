var Initiative = require('mongoose').model('Initiative');

module.exports = {
    getInitiatives: function(callback) {
        return Initiative.find({}, callback);
    }
};