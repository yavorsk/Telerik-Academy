var mongoose = require('mongoose');

module.exports.init = function() {
    var initiativeSchema = mongoose.Schema({
        title: String
    });

    var Initiative = mongoose.model('Initiative', initiativeSchema);

    //seed initiatives
    Initiative.find({}).exec(function (err, collection) {
        if (err) {
            console.log('Cannot find initiatives: ' + err);
            return;
        }

        if (collection.length === 0) {
            Initiative.create({title: 'School Academy'});
            Initiative.create({title: 'Kids Academy'});
            Initiative.create({title: 'Software Academy'});
            Initiative.create({title: 'Algo Academy'});

            console.log('Adding initiatives to database...');
        }
    });
};
