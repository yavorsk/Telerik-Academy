define(['jquery', 'httpRequester', 'ui', 'Q'], function ($, httpRequester, ui, Q) {
    var controller = (function () {
        var attachEventHandlers, loadChatroom, loadLogin, reloadChatRoom;
        var serviceUrl = 'http://crowd-chat.herokuapp.com/posts';

        attachEventHandlers = function () {
            $('#main-content').on('click', '#login-btn', function () {
                var userName = $('#username-tb').val();

                if (userName) {
                    sessionStorage.setItem('username', userName);
                    window.location = '#/chatroom';
                }
            });

            $('#main-content').on('click', '#sign-out-btn', function () {
                sessionStorage.removeItem('username');
                window.location = '#/login';
            });

            $('#main-content').on('click', '#send-btn', function () {
                var message = $('#input-message').val();
                var postData = {
                    user: sessionStorage.getItem('username'),
                    text: message
                    };
                httpRequester.postJSON(serviceUrl, postData)
                    .then(function () { reloadChatRoom() });
            })
        }

        loadLogin = function () {
            $('#main-content').load('../templates/login.html');
        }

        reloadChatRoom = function () {
            var chats;
            httpRequester.getJSON(serviceUrl)
                .then(function (data) {
                    var deferred = Q.defer();
                    chats = ui.renderChat(data)
                    deferred.resolve(chats);
                    return deferred.promise;
                })
            .then(function (toDisplay) {
                var $contentDiv = $("#chat-holder");
                $contentDiv.html(toDisplay);
                $contentDiv.scrollTop($contentDiv[0].scrollHeight);
            }, function (err) { console.log(err) });
        };

        loadChatroom = function () {
            $('#main-content').load('../templates/chatroom.html');
            reloadChatRoom();
            setInterval(reloadChatRoom, 4000);
        }

        return {
            loadLogin: loadLogin,
            loadChatroom: loadChatroom,
            attachEventHandlers: attachEventHandlers
        };
    }());

    return controller;
})