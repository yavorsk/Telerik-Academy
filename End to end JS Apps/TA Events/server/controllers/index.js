var UsersController = require('./UsersController'),
    HomeController = require('./HomeController'),
    ProfileController = require('./ProfileController'),
    EventsController = require('./EventsController');

module.exports = {
    users: UsersController,
    home: HomeController,
    profile: ProfileController,
    events: EventsController
};