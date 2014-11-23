var mongoose = require('mongoose');
var User = require('./models/user');
var Message = require('./models/message');

function init(connectionString) {
    mongoose.connect(connectionString);
    var db = mongoose.connection;

    db.once('open', function(err) {
        if(err){
            console.log(err.message);
        };

        console.log('Mongoose connected to: ' + connectionString);
    });
};

function registerUser(user) {
    var newUser = new User({
       userName: user.name,
        pass: user.pass
    });

//    console.log(user.name);
//    console.log(user.pass);
//    console.log(newUser.userName);
//    console.log(newUser.pass);

    return newUser.save(function(err,res){
        if (err) {
            return err;
        };
        //console.log(res);
        return res;
    });
};

function sendMessage(message) {
    User.findOne({userName: message.from}, function(err, result){
        var from = result;

        User.findOne({userName: message.to}, function(err, result){
            var to = result;

            var newMessage = new Message({
                from: from._id,
                to: to._id,
                text: message.text
            });

            newMessage.save(function(err, result){
                if (err) {
                    return err;
                };

                return result;
            });
        });
    });
};

function getMessages(users, cb) {

    User.findOne({userName: users.with})
        .exec(function (err, result) {
            if (err) {
                console.log(err.message);
            };

            var from = result;
            console.log(from);

            User.findOne({userName: users.and})
                .exec(function (err, result) {
                    if (err) {
                        console.log(err.message);
                    };

                    var to = result;
                    console.log(to);

                    Message.find({from: from, to: to})
                        .exec(function(err, result) {
                            if (err) {
                                console.log(err.message);
                                result;
                            };

                            cb(result);
                        });
                });
        });
};

module.exports = {
    init: init,
    registerUser: registerUser,
    sendMessage: sendMessage,
    getMessages: getMessages
}
