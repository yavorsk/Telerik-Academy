var mongoose = require('mongoose');

module.exports.init = function() {
    var categorySchema = mongoose.Schema({
        name: String
    });

    var Category = mongoose.model('Category', categorySchema);

    //seed categories
    Category.find({}).exec(function (err, collection) {
        if (err) {
            console.log('Cannot find categories: ' + err);
            return;
        }

        if (collection.length === 0) {
            Category.create({name: 'Academy Initiative'});
            Category.create({name: 'Free time'});
            Category.create({name: 'Drinkin and smokin'});
            Category.create({name: 'Hackaton'});
            Category.create({name: 'Conference'});

            console.log('Adding categories to database...');
        }
    });
};