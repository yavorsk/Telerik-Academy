define(['jquery', 'httpRequester', 'ui', 'Q', 'underscore'], function ($, httpRequester, ui, Q, _) {
    var controller = (function () {
        var loadMain, loadRegister, loadLogin, loadSession, attachEventHandlers, loadPosts, renderPosts;

        attachEventHandlers = function () {
            //$('#main-content').on('click', '#login-btn', function () {
            //    var userName = $('#username-tb').val();

            //    if (userName) {
            //        sessionStorage.setItem('username', userName);
            //        window.location = '#/chatroom';
            //    }
            //});

            $('#user-inter-content').on('click', '#register-btn', function () {
                window.location = '#/register';
            })

            $('#user-inter-content').on('click', '#login-btn', function () {
                window.location = '#/login';
            })

            $('#user-inter-content').on('click', '#submit-register-btn', function () {
                var username = $('#register-username-tb').val();
                var password = $('#register-pass-tb').val();
                var authCode = CryptoJS.SHA1(username + password).toString();

                var userData = {
                    username: username,
                    authCode: authCode
                };

                var url = 'http://localhost:3000/user';

                httpRequester.postJSON(url, userData)
                    .then(function (data) {
                        if (data) {
                            $('#register-message-box').html('User succesfully registered!');
                            setTimeout(function () { window.location = '#/main'; }, 1000);
                        }
                    }, function (err) {
                        $('#register-message-box').html('Username should have between 6 and 40 characters');
                    });
            })

            $('#user-inter-content').on('click', '#submit-login-btn', function () {
                var username = $('#login-username-tb').val();
                var password = $('#login-pass-tb').val();
                var authCode = CryptoJS.SHA1(username + password).toString();

                var userData = {
                    username: username,
                    authCode: authCode
                };

                var url = 'http://localhost:3000/auth';

                httpRequester.postJSON(url, userData)
                    .then(function (data) {
                        if (data) {
                            $('#login-message-box').html('User login successfull!');

                            sessionStorage.setItem('currentUser', data.username);
                            sessionStorage.setItem('sessionKey', data.sessionKey);

                            setTimeout(function () {
                                window.location = '#/session';
                            }, 500);

                            setTimeout(function () {
                                $('#welcome').html('Wecome ' + data.username + ' !')
                            }, 600);
                        }
                    }, function (err) {
                        $('#login-message-box').html('No such user!');
                    });
            });

            $('#user-inter-content').on('click', '#logout-btn', function () {
                var currentSessionKey = sessionStorage.getItem('sessionKey').toString();
                var url = 'http://localhost:3000/user'

                httpRequester.putReq(url, currentSessionKey)
                    .then(function (data) {
                        sessionStorage.removeItem('currentUser');
                        sessionStorage.removeItem('sessionKey');
                        window.location = '#/main';
                    }, function (err) {
                        console.log(err);
                    })
            })

            $('#user-inter-content').on('click', '#submit-post', function () {
                var currentSessionKey = sessionStorage.getItem('sessionKey').toString();
                var titleOfPost = $('#post-title-tb').val();
                var bodyOfPost = $('#post-body-tb').val();
                var url = 'http://localhost:3000/post';

                var postData = {
                    title: titleOfPost,
                    body: bodyOfPost
                }

                httpRequester.postPost(url, postData, currentSessionKey)
                    .then(function (data) {
                        //debugger;
                        $('#session-message-box').html('Post successfull!');
                    }, function (err) {
                    })
            })

            $('#user-inter-content').on('click', '#get-posts-bt', function () {
                var url = 'http://localhost:3000/post';

                httpRequester.getJSON(url)
                    .then(function (data) {
                        ui.renderPosts(data);
                    }, function (err) {
                        console.log(err);
                    });
            })

            $('#posts-content').on('click', '#by-title-asc-btn', function () {
                var url = 'http://localhost:3000/post';
                httpRequester.getJSON(url)
                    .then(function (data) {
                        var resultData = _.chain(data)
                                .sortBy('title')
                                .value();

                        ui.renderPosts(resultData);
                    }, function (err) {
                        console.log(err);
                    });
            })

            $('#posts-content').on('click', '#by-title-desc-btn', function () {
                var url = 'http://localhost:3000/post';
                httpRequester.getJSON(url)
                    .then(function (data) {
                        var resultData = _.chain(data)
                                .sortBy('title')
                                .value();

                        resultData.reverse();

                        ui.renderPosts(resultData);
                    }, function (err) {
                        console.log(err);
                    });
            })

            $('#posts-content').on('click', '#by-date-asc-btn', function () {
                var url = 'http://localhost:3000/post';
                httpRequester.getJSON(url)
                    .then(function (data) {
                        var resultData = _.chain(data)
                                .sortBy(function (a, b) {
                                    var dateA = new Date(a);
                                    var dateB = new Date(b);
                                    //debugger;
                                    return dateA.getTime() - dateB.getTime();
                                })
                                .value();

                        ui.renderPosts(resultData);
                    }, function (err) {
                        console.log(err);
                    });
            })
        }

        function getPosts() {
            var url = 'http://localhost:3000/post';

            httpRequester.getJSON(url)
                .then(function (data) {
                    ui.renderPosts(data);
                }, function (err) {
                    console.log(err);
                });
        }

        renderPosts = function () {
            var url = 'http://localhost:3000/post';

            httpRequester.getJSON(url)
                .then(function (data) {
                    ui.renderPosts(data);
                }, function (err) {
                    console.log(err);
                });
        }

        loadMain = function () {
            $('#user-inter-content').load('templates/main.html');
        }

        loadRegister = function () {
            $('#user-inter-content').load('templates/registerUser.html');
        }

        loadLogin = function () {
            $('#user-inter-content').load('templates/loginUser.html');
        }

        loadSession = function () {
            $('#user-inter-content').load('templates/loggedIn.html');
        }

        return {
            loadMain: loadMain,
            loadRegister: loadRegister,
            loadLogin: loadLogin,
            loadSession: loadSession,
            loadPosts: loadPosts,
            attachEventHandlers: attachEventHandlers,
            renderPosts: renderPosts
        };
    }());

    return controller;
})