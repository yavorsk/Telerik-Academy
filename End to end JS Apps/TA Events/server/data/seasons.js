var Season = require('mongoose').model('Season');

module.exports = {
    getSeasons: function(callback) {
        return Season.find({}, callback);
    }
};