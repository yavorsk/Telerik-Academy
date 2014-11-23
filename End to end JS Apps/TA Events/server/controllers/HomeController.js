var events = require('../data/events'),
    users = require('../data/users');

var CONTROLLER_NAME = 'home';

module.exports = {
    getHome: function(req, res, next) {
        events.getPastEvents(function(err, collection) {
            if (err) {
                console.log('Events could not be loaded: ' + err);
            };

            var passedEvents = [];

            for (i=0; i < collection.length; i++) {
                var eventModel = {};

                eventModel.eventPoints = collection[i].eventPoints;
                eventModel.title = collection[i].title;
                eventModel.description = collection[i].description;
                eventModel.url = "events/" + collection[i]._id.toString();
                eventModel.comments = [];

                for (j=0; j < collection[i].comments.length; j++) {
                    eventModel.comments[j] = collection[i].comments[j];
                }

                passedEvents.push(eventModel);
            };
                //console.log(passedEvents[0].comments);
            res.render(CONTROLLER_NAME, {passedEvents: passedEvents, currentUser: req.user  });
        });
    }
};