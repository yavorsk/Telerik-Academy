var mongoose = require('mongoose'),
    encryption = require('../../utilities/encryption');

function validator (v) {
    return  5 < v.length && v.length < 21;
};

module.exports.init = function() {
    var userSchema = mongoose.Schema({
        username: { type: String, require: '{PATH} is required', unique: true, validate: [validator, 'Username must be between 6 and 20 characters long'] },
        salt: String,
        hashPass: String,
        eventPoints: { type: String, default: 0 },
        firstName: { type: String, require: '{PATH} is required'},
        lastName: { type: String, require: '{PATH} is required'},
        phoneNumber: String,
        email: { type: String, require: '{PATH} is required'},
        taInitiatives: [
            {type: mongoose.Schema.ObjectId, ref: 'Initiative'}
        ],
        seasons: [
            {type: mongoose.Schema.ObjectId, ref: 'Sason'}
        ],
        profileImage: { type: String, default: 'http://blogs.telerik.com/images/default-source/miroslav-miroslav/super_ninja.png?sfvrsn=2'},
        fbProfile: String,
        twitterProfile: String,
        linkedInProfile: String,
        googlePlusProfile: String
    });

    userSchema.method({
        authenticate: function(password) {
            if (encryption.generateHashedPassword(this.salt, password) === this.hashPass) {
                return true;
            }
            else {
                return false;
            }
        }
    });

    var User = mongoose.model('User', userSchema);

    //seed initial users
    User.find({}).exec(function (err, collection) {
        if (err) {
            console.log('Cannot find users: ' + err);
            return;
        };

        if (collection.length === 0) {
            var salt;
            var hashedPwd;
            var firstName;
            var lastName;
            var phoneNumber;
            var email;

            salt = encryption.generateSalt();
            hashedPwd = encryption.generateHashedPassword(salt, 'georgi');
            firstName = 'Georgi';
            lastName = 'Georgiev';
            phoneNumber = '999 22 66';
            email = 'gogo@gogo.com';
            User.create({
                username: 'georgi.georgiev',
                salt: salt,
                hashPass: hashedPwd,
                firstName: firstName,
                lastName: lastName,
                phoneNumber: phoneNumber,
                email: email
            });

            salt = encryption.generateSalt();
            hashedPwd = encryption.generateHashedPassword(salt, 'pesho');
            firstName = 'Pesho';
            lastName = 'Peshev';
            email = 'pepo@pepo.com';
            User.create({
                username: 'pesho.peshev',
                salt: salt,
                hashPass: hashedPwd,
                firstName: firstName,
                lastName: lastName,
                email: email
            });

            console.log('Adding users to database...');
        }
    });
};


