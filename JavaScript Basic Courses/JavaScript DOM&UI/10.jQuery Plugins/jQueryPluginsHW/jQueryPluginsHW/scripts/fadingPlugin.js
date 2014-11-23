//*Create a jQuery plugin for fading in/fading out message box
//    Creates a message box
//var msgBox = $('#message-box').messageBox();
//Show a success/error message in the box
//Showing is done by setting the opacity of the message from 0 to 1 in an interval of 1 second
//The message disappears after 3 seconds
//msgBox.success('Success message');
//msgBox.error('Error message');

(function ($) {
    $.fn.fadeMessageBox = function () {
        var $this = $(this);

        return {
            success: function (message) {
                $this.css('background-color', 'green').text(message);

                $this.animate({ opacity: 1 }, 1000);

                setTimeout(function () {
                    $this.animate({ opacity: 0 }, 1000)
                }, 3000);

                return $this;
            },

            error: function (message) {
                $this.css('background-color', 'red').text(message);

                $this.animate({ opacity: 1 }, 1000);

                setTimeout(function () {
                    $this.animate({ opacity: 0 }, 1000)
                }, 3000);

                return $this;
            }
        };
    };
}(jQuery));

$('#error-btn').on('click', function () {
    $('#message-box').fadeMessageBox().error('Some error message...');
});

$('#success-btn').on('click', function () {
    $('#message-box').fadeMessageBox().success('It\'s time to drink beer!');
});