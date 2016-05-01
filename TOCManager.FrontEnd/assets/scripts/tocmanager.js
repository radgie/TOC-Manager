$(function () {
    var form = $(".register-form");

    form.css({
        opacity: 1,
        "-webkit-transform": "scale(1)",
        "transform": "scale(1)",
        "-webkit-transition": ".5s",
        "transition": ".5s"
    });
});

$(function () {
    var form = $(".login-form");

    form.css({
        opacity: 1,
        "-webkit-transform": "scale(1)",
        "transform": "scale(1)",
        "-webkit-transition": ".5s",
        "transition": ".5s"
    });
});

function sidebarOnLoad() {
    $('.sidebar').on('click', 'li', function () {
        if (!$(this).hasClass('active')) {
            $('.sidebar li').removeClass('active');
            $(this).addClass('active');
        }
    })
};

function sidebarItemClick(item) {
    if (!$(item).hasClass('active')) {
        $('.sidebar li').removeClass('active');
        $(item).addClass('active');
    }
}
function showDialog(id) {
    debugger;
    var dialog = $("#" + id).data('dialog');
    if (!dialog.element.data('opened')) {
        dialog.open();
    } else {
        dialog.close();
    }
}

function notifyOnServerError(input) {
    var message = input.data('errorMessage');
    $.Notify({
        caption: 'Error',
        content: message,
        type: 'alert'
    });
}

function pushMessage(type, caption, content) {
    $.Notify({
        caption: caption,
        content: content,
        type: type
    });
}

