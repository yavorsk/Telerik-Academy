var users = require('../data/users'),
    events = require('../data/events');

var CONTROLLER_NAME = 'profile';

module.exports = {
    getChangeInfo: function(req, res, next) {
        res.render('users/changeInfo');
    },
    changeInfo: function(req, res, next) {
        var info = {};
        info.newPhone = req.body.newPhone;
        info.fbProfile = req.body.fbProfile;
        info.twitterProfile = req.body.twitterProfile;
        info.linkedInProfile = req.body.linkedInProfile;
        info.googlePlusProfile = req.body.googlePlusProfile;

        users.updateById(req.user._id, info, function(err) {
            if (err) {
                console.log('Update failed!');
                res.redirect('users/profile');
            }

            res.redirect('/profile');
        });
    },
    getCreatedEvents: function(req, res, next) {
        events.getEvents(function(err, collection) {
            if (err) {
                console.log('Events could not be loaded: ' + err);
            };

            var events = {};
            events.type = 'Created events';
            events.collection = [];

            for (i=0; i < collection.length; i++) {
                var eventModel = {};
                if(collection[i].creatorName === req.user.username) {
                    eventModel.title = collection[i].title;
                    eventModel.description = collection[i].description;
                    eventModel.comments = [];

                    for (i=0; i < collection.comments.length; i++) {
                        eventModel.comments.push(collection.comments[i]);
                    }

                    events.collection.push(eventModel);
                }
            };

            res.render('users/events/listEvents', {events: events, currentUser: req.user });
        });
    },
    getJoinedEvents: function(req, res, next) {
        events.getEvents(function(err, collection) {
            if (err) {
                console.log('Events could not be loaded: ' + err);
            };

            var events = {};
            events.type = 'Joined events';
            events.collection = [];

            for (i=0; i < collection.length; i++) {
                var eventModel = {};
                if(collection[i].joinedUsers.contains(req.user._id)) {
                    eventModel.title = collection[i].title;
                    eventModel.description = collection[i].description;
                    eventModel.url = "events/" + collection[i]._id.toString();
                    eventModel.comments = [];

                    for (j=0; j < collection[i].comments.length; j++) {
                        eventModel.comments.push(collection[i].comments[j]);
                    }

                    events.collection.push(eventModel);
                }
            };

            res.render('users/events/listEvents', {events: events, currentUser: req.user });
        });
    },
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
    }
};