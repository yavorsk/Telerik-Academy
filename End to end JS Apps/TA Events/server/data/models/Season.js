var mongoose = require('mongoose');

module.exports.init = function() {
    var seasonSchema = mongoose.Schema({
        started: String
    });

    var Season = mongoose.model('Season', seasonSchema);

    //seed initiatives
    Season.find({}).exec(function (err, collection) {
        if (err) {
            console.log('Cannot find initiatives: ' + err);
            return;
        }

        if (collection.length === 0) {
            Season.create({started: '2010'});
            Season.create({started: '2011'});
            Season.create({started: '2012'});
            Season.create({started: '2013'});

            console.log('Adding seasons to database...');
        }
    });
};