(function () {
    require.config({
        paths: {
            "jquery": "../libs/jquery-2.1.1",
            "Q": "../libs/q.min"
        }
    });

    require(['httpRequestModule'], function (httpRequester) {
        var url = "http://localhost:3000/students"
        //var headers = {
        //    'contentType': 'application/json',
        //    'accept': 'application/json',
        //    'X-customHeader': 'some-value' //doesnt work for some reason...
        //};

        var studentSasho = {
            name: "Sasho Sashev",
            grade: 4
        };

        var studentKatso = {
            name: "Katso Katsov",
            grade: 2
        };

        var studentShosho = {
            name: "Shosho Shoshev",
            grade: 6
        };

        var studentJoro = {
            name: "Joro Jorev",
            grade: 10
        };

        httpRequester.postJSON(url, studentSasho)
            .then(httpRequester.postJSON(url, studentKatso))
            .then(httpRequester.postJSON(url, studentShosho))
            .then(httpRequester.postJSON(url, studentJoro))

        httpRequester.getJSON(url)
            .then(function (data) {
                console.log(data);
            },
            function (error) {
                console.log(error)
            })
    })
}())