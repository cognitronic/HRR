var webserver = 'http://hrr.localhost/';
//var webserver = 'http://demo.hrriver.com/';
//var webserver = 'http://beta.hrriver.com/';

//Comments

//Help & Documentation

//Alerts & Events
function loadAlerts() {
    //var userid = document.getElementById("hdnCurrentUser");
    $.ajax({
        type: "POST",
        url: webserver + "Comments.svc/GetAlertByDueDate",
        cache: false,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.d != '') {
                var alertpanel = document.getElementById("alertspanel");
                if (data.d == '') {
                    taskNote.value = '';
                }
                else {
                    alertpanel.innerHTML = "<div style='margin-left: 5px; font-weight: bold'>Alerts</div><hr style='margin: 5px 0 !important;' />";
                    $.each(jQuery.parseJSON(data), function (i, item) {
                        alertpanel.innerHTML += "<div style='margin-bottom: 10px; border-bottom: 1px solid #ddd;'><div style='float: left; margin-left: 5px; margin-right: 5px; vertical-align:top; padding: 0px 0px;'> <img src='" + item.avatar + "' alt='' width='25px' height='25px' /></div> <div style='vertical-align: top; margin-bottom: 5px;'>" + item.enteredfor + "'s " + item.alerttitle + " is due <span style='font-weight: bold;'>" + item.duedate + "</span></div></div>";
                        //taskNote.innerHTML += "<b>Message:</b> " + JSON.parse(data.d).message + "<br /><b>Last Updated On:</b> " + JSON.parse(data.d).enteredby;
                    });
                    alertpanel.innerHTML += "<div />";
                }
            }
        }
    });
}

function loadEvents() {
    $.ajax({
        type: "POST",
        url: webserver + "Comments.svc/GetUpcomingEvents",
        cache: false,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.d != '') {
                var eventpanel = document.getElementById("eventpanel");
                if (data.d == '') {
                    taskNote.value = '';
                }
                else {
                    eventpanel.innerHTML = "<div style='margin-left: 5px; font-weight: bold'>Upcoming Events</div><hr style='margin: 5px 0 !important;' />";
                    $.each(jQuery.parseJSON(data), function (i, item) {
                        eventpanel.innerHTML += "<div style='margin-bottom: 10px; border-bottom: 1px solid #ddd; min-height: 35px;'><div style='float: left; margin-left: 5px; margin-right: 5px; vertical-align:top; padding: 0px 0px;'> <img src='" + item.avatar + "' alt='' width='25px' height='25px' /></div> <div style='vertical-align: top; margin-bottom: 5px;'>" + item.eventfor + item.eventdate + "</div></div>";
                        //taskNote.innerHTML += "<b>Message:</b> " + JSON.parse(data.d).message + "<br /><b>Last Updated On:</b> " + JSON.parse(data.d).enteredby;
                    });
                    eventpanel.innerHTML += "<div />";
                }
            }
        }
    });
}