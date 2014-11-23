var chatDb = require('./chat-db');

chatDb.init('localhost:27017/chat');

//inserts a new user records into the DB
chatDb.registerUser({name: 'DonchoMinkov', pass: '123456q'});
chatDb.registerUser({name: 'PeshoPeshev', pass: '123456qq'});
debugger;
//inserts a new message record into the DB
//the message has two references to users (from and to)
chatDb.sendMessage({
    from: 'DonchoMinkov',
    to: 'PeshoPeshev',
    text: 'ascvsacsa!'
});
//returns an array with all messages between two users
chatDb.getMessages({
    with: 'DonchoMinkov',
    and: 'PeshoPeshev'
}, function(data) {
    console.log(data);
});

