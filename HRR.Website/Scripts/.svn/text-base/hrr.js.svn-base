var webserver = 'http://hrr.localhost/';
//var webserver = 'http://demo.hrriver.com/';
//var webserver = 'http://beta.hrriver.com/';

//Interface Class
var Interface = function (name, methods) {
    if (arguments.length != 2) {
        throw new Error("Interface constructor called with" + arguments.length + "arguments, but expected exactly 2.");
    }
    this.name = name;
    this.methods = [];
    for (var i = 0, len = methods.length; i < len; i++) {
        if (typeof methods[i] !== 'string') {
            throw new Error("Interface constructor expects method names to be passed in as a string.");
        }
        this.methods.push(methods[i]);
    }
};

Interface.ensureImplements = function (object) {
    if (arguments.length < 2) {
        throw new Error("Function Interface.ensureImplements called with " + arguments.length + " arguments, but expected at least 2.");
    }
    for (var i = 1, len = arguments.length; i < len; i++) {
        var interface = arguments[i];
        if (interface.constructor !== Interface) {
            throw new Error("Function Interface.ensureImplements expects arguments two and above to be instances of Interface");
        }
        for (var j = 0, methodsLen = interface.methods.length; j < methodsLen; j++) {
            var method = interface.methods[j];
            if (!object[method] || typeof object[method] !== 'function') {
                throw new Error("Function Interface.ensureImplements: object does not implement the " + interface.name + " interface.  Method " + method + " was not found.");
            }
        }
    }
};

function FormatCheckboxValue(val) {
    if (val == "on")
        return true;
    else
        return false;
}



var DateUtil = {
    convert: function (d) {
        // Converts the date in d to a date-object. The input can be:
        //   a date object: returned without modification
        //  an array      : Interpreted as [year,month,day]. NOTE: month is 0-11.
        //   a number     : Interpreted as number of milliseconds
        //                  since 1 Jan 1970 (a timestamp) 
        //   a string     : Any format supported by the javascript engine, like
        //                  "YYYY/MM/DD", "MM/DD/YYYY", "Jan 31 2009" etc.
        //  an object     : Interpreted as an object with year, month and date
        //                  attributes.  **NOTE** month is 0-11.
        return (
            d.constructor === Date ? d :
            d.constructor === Array ? new Date(d[0], d[1], d[2]) :
            d.constructor === Number ? new Date(d) :
            d.constructor === String ? new Date(d) :
            typeof d === "object" ? new Date(d.year, d.month, d.date) :
            NaN
        );
    },
    compare: function (a, b) {
        // Compare two dates (could be of any type supported by the convert
        // function above) and returns:
        //  -1 : if a < b
        //   0 : if a = b
        //   1 : if a > b
        // NaN : if a or b is an illegal date
        // NOTE: The code inside isFinite does an assignment (=).
        return (
            isFinite(a = this.convert(a).valueOf()) &&
            isFinite(b = this.convert(b).valueOf()) ?
            (a > b) - (a < b) :
            NaN
        );
    },
    inRange: function (d, start, end) {
        // Checks if date in d is between dates in start and end.
        // Returns a boolean or NaN:
        //    true  : if d is between start and end (inclusive)
        //    false : if d is before start or after end
        //    NaN   : if one or more of the dates is illegal.
        // NOTE: The code inside isFinite does an assignment (=).
        return (
            isFinite(d = this.convert(d).valueOf()) &&
            isFinite(start = this.convert(start).valueOf()) &&
            isFinite(end = this.convert(end).valueOf()) ?
            start <= d && d <= end :
            NaN
        );
    }
}
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

function loadGoalWeights(userid, container, callback) {
    $.ajax({
        type: "POST",
        url: webserver + "Comments.svc/GetGoalsForWeightingByPersonID",
        cache: false,
        data: '{ "userID": "' + userid + '" }',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.d != '') {
                var totalWeights = 0;
                var s = "<table style='width: 325px; padding: 1px;'><tr><td style='font-weight: bold;'>Title</td><td style='font-weight: bold;'>Weight</td></tr>";
                $.each(jQuery.parseJSON(data), function (i, item) {
                    s += "<tr><td style='width: 250px; padding-bottom: 1px;'> " + item.title + "</td><td style='width: 60px; padding-bottom: 1px;'><input type='text' id='goal_" + item.id + "' goalid='" + item.id + "' style='width: 50px;' value='" + item.weight + "'/></td></tr>";
                    totalWeights += parseInt(item.weight, 10);
                });
                s += "</table>";
                container.innerHTML += s;
                callback.call(totalWeights);
            }
        }
    });
}

function saveGoal(goalJson) {
    
    $.ajax({
        type: "POST",
        url: webserver + "Comments.svc/SaveGoal",
        data: goalJson,
        contentType: "application/json;",
        dataType: "json",
        success: function (data) {
            window.location = webserver + data.split(':')[2];
        }
    });
}

function saveEmployee(person) {

    $.ajax({
        type: "POST",
        url: webserver + "Comments.svc/SavePerson",
        data: person,
        contentType: "application/json;",
        dataType: "json",
        success: function (data) {
            window.location = webserver + data.SavePersonResult.split(':')[2];
        }
    });
}

function closeReview(review) {
    $.ajax({
        type: "POST",
        url: webserver + "Comments.svc/CloseReview",
        data: review,
        contentType: "application/json;",
        dataType: "json",
        success: function (data) {
            window.location = webserver + data.CloseReviewResult.split(':')[2];
        }
    });
}

function saveWeights(weights) {
    $.ajax({
        type: "POST",
        url: webserver + "Comments.svc/UpdateGoalWeight",
        data: weights,
        contentType: "application/json;",
        dataType: "json",
        success: function (data) {
            
        }
    });
}