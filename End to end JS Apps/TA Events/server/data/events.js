var Event = require('mongoose').model('Event');

module.exports = {
    getEvents: function(callback) {
        return Event.find({}, callback);
    },
    getPastEvents: function(callback) {
        return Event.find({})
            .where('date')
            .lt(new Date())
            .exec((callback));
    },
    getActiveEvents: function(callback) {
        return Event.find({})
            .where('date')
            .gt(new Date())
            .exec((callback));
    },
    findById: function(id, callback) {
        return Event.findOne({"_id" : id}).exec(callback);
    }
};