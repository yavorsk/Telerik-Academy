var mongoose = require('mongoose');

module.exports.init = function() {
    var eventSchema = mongoose.Schema({
        title: { type: String, require: '{PATH} is required'},
        description: { type: String, require: '{PATH} is required'},
        location: {
            longitude: Number,
            latitude: Number
        },
        category: { type: mongoose.Schema.ObjectId, ref: 'Category' },
        type: {
            initiative: { type: mongoose.Schema.ObjectId, ref: 'Initiative' },
            season: { type: mongoose.Schema.ObjectId, ref: 'Season' }
        },
        creator: { type: mongoose.Schema.ObjectId, ref: 'User' },
        creatorName: String,
        creatorPhoneNumber: String,
        comments: [ { type: String } ],
        joinedUsers: [ { type: mongoose.Schema.ObjectId, ref: 'User' } ],
        date: Date,
        eventPoints: { type: Number, default: 0 }
    });

    var Event = mongoose.model('Event', eventSchema);

    //seed initial events
    Event.find({}).exec(function (err, collection) {
        if (err) {
            console.log('Cannot find events: ' + err);
            return;
        };

        if (collection.length === 0) {
            var title;
            var description;
            var location = {};
            var creatorName;
            var creatorPhoneNumber;
            var date;
            var comments = [];

            title = 'Zapivka';
            description = 'sddsav dsf sdf adfs asffsdf ';
            location.longitude = 40.444;
            location.latitude = 40.444;
            creatorName = 'pesho.peshev';
            creatorPhoneNumber = '22222222';
            date = new Date();
            comments.push('da da da');
            comments.push('ne ne ne');

            Event.create({
                title: title,
                description: description,
                location: location,
                creatorName: creatorName,
                creatorPhoneNumber: creatorPhoneNumber,
                date: date,
                comments: comments
            });

            console.log('Adding events to database...');
        }
    });
};