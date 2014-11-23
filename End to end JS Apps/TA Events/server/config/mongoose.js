var mongoose = require('mongoose'),
    InitiativeModel = require('../data/models/Initiative'),
    CategoryModel = require('../data/models/Category'),
    SeasonModel = require('../data/models/Season'),
    UserModel = require('../data/models/User'),
    EventModel = require('../data/models/Event');

    module.exports = function(config) {
    mongoose.connect(config.db);
    var db = mongoose.connection;

    db.once('open', function(err) {
        if (err) {
            console.log('Database could not be opened: ' + err);
            return;
        }

        console.log('Database up and running...')
    });

    db.on('error', function(err){
        console.log('Database error: ' + err);
    });

    InitiativeModel.init();
    CategoryModel.init();
    SeasonModel.init();
    UserModel.init();
    EventModel.init();
};