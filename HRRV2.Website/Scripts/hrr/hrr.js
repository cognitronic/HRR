var baseUrl = "http://hrrv2.localhost/";

function loadEvaluationTemplateQuestions(templateID) {
    $.ajax({
        url: baseUrl + 'api/Evaluation/GetEvaluationTemplateQuestions?templateID=' + templateID,
        type: 'POST',
        dataType: "json",
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            var container = document.getElementById("divQuestions");
            container.innerHTML = "";
            var i = 0;
            $.each(jQuery.parseJSON(data), function (i, item) {
                i++;
                container.innerHTML += "<tr><td> " + i + "</td><td style='width: 75%;'>" + item.Question + "</td><td>" + item.IsSlider + "</td><td><a href='" + baseUrl + "api/Evaluation/DeleteEvaluationTemplateQuestion?questionID=" + item.ID + "' class='btn btn-small btn-danger'><i class='icon-remove'></i> Delete</a></td></tr>";
                //taskNote.innerHTML += "<b>Message:</b> " + JSON.parse(data.d).message + "<br /><b>Last Updated On:</b> " + JSON.parse(data.d).enteredby;
            });
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}
/*          BEGIN PERFORMANCE EVALUATION FUNCTIONS         */

function saveEvaluationQuestion(question, container) {
    $.ajax({
        url: baseUrl + 'api/Evaluation/CreateTemplateQuestion',
        type: 'POST',
        data: JSON.stringify(question),
        dataType: "json",
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            //window.location = data.split(':')[2];
            loadEvaluationTemplateQuestions(question.PerformanceEvaluationTemplateID, container);
            $('#mainwrapper').effect("highlight", { color: "#7fd658" }, 1000);
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}

function saveEvaluationSliderQuestion(question, container) {
    $.ajax({
        url: baseUrl + 'api/Evaluation/CreateTemplateSliderQuestion',
        type: 'POST',
        data: JSON.stringify(question),
        dataType: "json",
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            //window.location = data.split(':')[2];
            loadEvaluationTemplateQuestions(question.PerformanceEvaluationTemplateID, container);
            $('#mainwrapper').effect("highlight", { color: "#7fd658" }, 1000);
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}


/*          END PERFORMANCE EVALUATION FUNCTIONS         */

