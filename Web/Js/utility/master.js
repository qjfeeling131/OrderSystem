/// <reference path="jquery.min.js" />

function createDialog(url, parameters) {
    //closeLoading();
    //fakeLoading();
    $.get(url, parameters, function (data) {
        closeLoading();
        for (i = 0; i < $(data).length; i++) {
            var item = $(data)[i];
            //console.log(data);
            if ($(item).hasClass("modal")) {
                //console.log("get dialog");

                modal = $(item);
                $(modal).appendTo('#dialog_content');
                $(modal).modal({
                    keyboard: true,
                    show: true,
                    backdrop: 'static'
                });

                $(modal).on('hidden.bs.modal', function (e) {
                    $(this).remove();
                    $('button').removeClass("disabled");
                })
            }
        }
    }, "html");
}

function redirected(url, parameters) {
    window.location = url;
}


function alertInfo(title, msg) {
    var model = { 'Title': title, 'Message': msg };
    createDialog('../base/exception', model);
}

//exception wrapper
function getAsynData(path, data, func) {
    fakeLoading();
    $.post(path, data, function (json) {
        closeLoading();
        if (json.Code == -1)
            eval('(' + json.Data + ')');
        else
            func(json);
    }, "json");
}

function isNullorEmptyString(str) {
    return str.replace(/(^s*)|(s*$)/g, "").length == 0;
}


function fakeLoading() {
    $("#fakeloader").css("display", "block");
}

function closeLoading() {
    $("#fakeloader").css("display", "none");
}



