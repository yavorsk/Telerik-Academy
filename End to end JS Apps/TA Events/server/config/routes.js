var auth = require('./auth'),
    controllers = require('../controllers'),
    apicache = require('apicache').options({ debug: true }).middleware;

module.exports = function(app) {
    app.get('/home', apicache('10 minutes'), controllers.home.getHome);

    app.get('/register', controllers.users.getRegister);
    app.post('/register', controllers.users.postRegister);

    app.get('/login', controllers.users.getLogin);
    app.post('/login', auth.login);
    app.get('/logout', auth.isAuthenticated, auth.logout);

    app.get('/profile',auth.isAuthenticated, function(req, res) {
        //console.log(req.user);
        res.render('users/profile', {currentUser: req.user});
    });
    app.get('/profile/changeInfo', auth.isAuthenticated, controllers.profile.getChangeInfo);
    app.post('/profile/changeInfo', auth.isAuthenticated, controllers.profile.changeInfo);
    app.get('/profile/createdEvents', auth.isAuthenticated, controllers.profile.getCreatedEvents);
    app.get('/profile/joinedEvents', auth.isAuthenticated, controllers.profile.getJoinedEvents);
    app.get('/profile/pastEvents', auth.isAuthenticated, controllers.profile.getPastEvents);

    app.get('/activeEvents', auth.isAuthenticated, controllers.events.getActiveEvents);
    app.get('/pastEvents', auth.isAuthenticated, controllers.events.getPastEvents);
    //app.get('/createEvent', auth.isAuthenticated, controllers.events.getCreateEvents);

    app.get('/events/:id', auth.isAuthenticated, controllers.events.getEventDetails);

    app.get('/', function(req, res) {
        res.render('index', {currentUser: req.user});
    });

    app.get('*', function(req, res) {
        res.render('index', {currentUser: req.user});
    });
};