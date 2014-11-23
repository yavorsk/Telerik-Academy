var events = require('../data/events'),
    users = require('../data/users');

module.exports = {
    getPastEvents:  function(req, res, next) {
        events.getPastEvents(function(err, collection) {
            if (err) {
                console.log('Events could not be loaded: ' + err);
            };
            var events = {};
            events.type = 'Past events';
            events.collection = [];

            for (i=0; i < collection.length; i++) {
                var eventModel = {};

                eventModel.eventPoints = collection[i].eventPoints;
                eventModel.title = collection[i].title;
                eventModel.description = collection[i].description;
                eventModel.url = "events/" + collection[i]._id.toString();
                eventModel.comments = [];

                for (j=0; j < collection[i].comments.length; j++) {
                    eventModel.comments.push(collection[i].comments[j]);
                }

                events.collection.push(eventModel);
            };

            res.render('users/events/listEvents', {events: events, currentUser: req.user });
        });
    },
    getActiveEvents: function (req, res, next) {
        events.getActiveEvents(function(err, collection) {
            if (err) {
                console.log('Events could not be loaded: ' + err);
            };
            var events = {};
            events.type = 'Active events';
            events.collection = [];

            for (i=0; i < collection.length; i++) {
                var eventModel = {};

                eventModel.eventPoints = collection[i].eventPoints;
                eventModel.title = collection[i].title;
                eventModel.description = collection[i].description;
                eventModel.url = "events/" + collection[i]._id.toString();
                eventModel.comments = [];

                for (j=0; j < collection[i].comments.length; j++) {
                    eventModel.comments.push(collection[i].comments[j]);
                }

                events.collection.push(eventModel);
            };

            res.render('users/events/listEvents', {events: events, currentUser: req.user });
        });
    },
    getEventDetails: function (req, res, next) {
        var id = req.params.id;

        events.findById(id, function(err, event) {
            var eventModel = {};

            eventModel.eventPoints = event.eventPoints;
            eventModel.title = event.title;
            eventModel.description = event.description;
            eventModel.comments = [];

            for (j=0; j < event.comments.length; j++) {
                eventModel.comments[j] = event.comments[j];
            }

            res.render('events/eventDetails', {eventModel: eventModel, currentUser: req.user });
        });
    }
};