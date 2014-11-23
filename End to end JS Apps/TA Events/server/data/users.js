var User = require('mongoose').model('User');

module.exports = {
    create: function(user, callback) {
        User.create(user, callback);
    },
    findById: function(id, callback) {
        return User.findOne({"_id" : id}).exec(callback);
    },
    updateById: function(id, info, callback) {

        console.log(info);

        if(info.newPhone) {
            User.update({_id: id}, { phoneNumber: info.newPhone}, function (err) {
                if (err) {
                    console.log('Phone number could not be changed!: ' + err);
                }
            });
        }
        if(info.fbProfile) {
            User.update({_id: id}, { fbProfile: info.fbProfile}, function (err) {
                if (err) {
                    console.log('Facebook Profile could not be changed!: ' + err);
                }
            });
        }
        if(info.twitterProfile) {
            User.update({_id: id}, { twitterProfile: info.twitterProfile}, function (err) {
                if (err) {
                    console.log('Twitter Profile could not be changed!: ' + err);
                }
            });
        }
        if(info.linkedInProfile) {
            User.update({_id: id}, { linkedInProfile: info.linkedInProfile}, function (err) {
                if (err) {
                    console.log('LinkedIn Profile could not be changed!: ' + err);
                }
            });
        }
        if(info.googlePlusProfile) {
            User.update({_id: id}, { googlePlusProfile: info.googlePlusProfile}, function (err) {
                if (err) {
                    console.log('GooglePlus Profile could not be changed!: ' + err);
                }
            });
        }

        callback();
    }
};