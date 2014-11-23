var mongoose = require('mongoose');
var ecryption = require('../utilities/encryption');

module.exports.init = function() {
    var userSchema = mongoose.Schema({
       username: { type: String, require: '{PATH} is required', unique: true },
       salt: String,
       hashPass: String
    });

    userSchema.method({
       authenticate: function(password) {
           if (ecryption.generateHashedPassword(this.salt, password) === this.hashPass) {
               return true;
           }
           else {
               return false;
           }
       }
    });

    var User = mogoose.model('User', userSchema);
};
