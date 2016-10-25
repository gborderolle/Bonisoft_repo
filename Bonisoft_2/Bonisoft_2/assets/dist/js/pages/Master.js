$(document).ready(function () {
    initVariables();
    updateClock();
    check_admin();
});

function initVariables() {
    if (typeof globalUserName != 'undefined') {
        $('.usernameInfo').html(globalUserName);
    }
}

function timenow(){
    var now= new Date(), 
    ampm= 'am', 
    h= now.getHours(), 
    m= now.getMinutes(), 
    s= now.getSeconds();
    if(h>= 12){
        if(h>12) h -= 12;
        ampm= 'pm';
    }

    if(m<10) m= '0'+m;
    if(s<10) s= '0'+s;
    return now.toLocaleDateString()+ ' ' + h + ':' + m + ' ' + ampm;
}

function updateClock() {
    var datetime = timenow();
    $("#lblDatetime").text(datetime);

    // call this function again in 1000ms
    setTimeout(updateClock, 1000);
}

Sys.Browser.WebKit = {};
if (navigator.userAgent.indexOf('WebKit/') > -1) {
    Sys.Browser.agent = Sys.Browser.WebKit;
    Sys.Browser.version = parseFloat(navigator.userAgent.match(/WebKit\/(\d+(\.\d+)?)/)[1]);
    Sys.Browser.name = 'WebKit';
}


function check_admin() {

    var userID = globalUserID;
    if (userID != null && userID != "") {

        // Ajax call parameters
        console.log("Ajax call: Datos_configuracion.aspx/CheckUserAdmin. Params:");
        console.log("userID, type: " + type(userID) + ", value: " + userID);

        // Check user is Admin
        $.ajax({
            type: "POST",
            url: "Datos_configuracion.aspx/CheckUserAdmin",
            data: '{userID_str: "' + userID + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                var ok = response.d;
                if (ok) {
                    $("#aMenuLogs").show();
                }

            }, // end success
            failure: function (response) {
                show_message_info('Error_Datos');

            }
        }); // Ajax
    }
}
