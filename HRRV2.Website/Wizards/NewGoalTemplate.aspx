<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewGoalTemplate.aspx.cs" Inherits="HRRV2.Website.Wizards.NewGoalTemplate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml"><head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
<title>HR River New Goal Wizard</title>

<link href="/Content/smart_wizard.css" rel="stylesheet" type="text/css"/>
    
    <script src="/Scripts/json.js" type="text/javascript"></script>
<script type="text/javascript" src="/Scripts/jquery.smartWizard-2.0.js"></script>
<script src="/Scripts/HRR.Domain.js" type="text/javascript"></script>
<script src="/Scripts/hrr.js" type="text/javascript"></script>
<script type="text/javascript">
    var _subscribers = [];
    var _milestones = [];
    var _goalweights = [];
    var weightTotalNumber = 0;
    var finalTotalWeight = 0;
    var _goal = new Goal();


    $(function () {
        $('#milestonesList').slimScroll({
            height: '200px',
            allowPageScroll: false,
            railVisible: true
        });
    });

    $(function () {
        $('#finalSubscribers').slimScroll({
            height: '200px',
            allowPageScroll: false,
            railVisible: true
        });
    });


    function wireupMilestoneDeletes() {
        $("#milestonesList").on('click', 'span[class*="tempmilestone"]', function (e) {
            _milestones.splice(parseInt($(this).attr("idx"), 10), 1);
            _goal.Milestones = null;
            _goal.Milestones = _milestones;
            buildMilestoneOutput(milestonesList);
        });
    }

    function wireupSubscriberDeletes() {
        $("#subscribersList").on('click', 'span[class*="tempsubscriber"]', function (e) {
            _subscribers.splice(parseInt($(this).attr("idx"), 10), 1);
            _goal.Managers = null;
            _goal.Managers = _subscribers;
            buildSubscribersOutput(subscribersList);
        });
    }

    function buildMilestoneOutput(container, isfinal) {
        container.innerHTML = "";
        var s = "<table id='testscroll' style='width: 690px; padding: 10px;'><tr><td style='font-weight: bold;'>Title</td><td style='font-weight: bold;'>Description</td><td style='font-weight: bold;'>DueDate</td></tr>"
        for (var i = 0; i < _milestones.length; i++) {
            s += "<tr><td style='width: 300px; padding-bottom: 10px;'>" + _milestones[i].Title + "</td><td style='width: 350px; padding-bottom: 10px;'>" + _milestones[i].Description + "</td><td style='width: 30px; padding-bottom: 10px;'>" + _milestones[i].Name + "</td>";
            if (!isfinal) {
                s += "<td><span idx='" + i + "' style='margin-left: 5px; cursor: pointer; color: #F6A828; text-decoration: underline;' class='tempmilestone'  id='tempms_" + i + "'>remove</span></td></tr>";
            }
            else {
                s += "</tr>";
            }
        }
        s += "</table>";
        container.innerHTML = s;
    }

    function buildSubscribersOutput(container, isfinal) {
        container.innerHTML = "";
        if (_subscribers.length > 0) {
            var s = "<table id='testscroll' style='width: 690px; padding: 10px;'><tr><td style='font-weight: bold;'>Name</td><td style='font-weight: bold;'>Receives Notifications</td></tr>"
            for (var i = 0; i < _subscribers.length; i++) {
                s += "<tr><td style='width: 250px; padding-bottom: 10px;'>" + _subscribers[i].Name + "</td><td style='width: 350px; padding-bottom: 10px;'>" + _subscribers[i].RecievesNotifications + "</td>";
                if (!isfinal) {
                    s += "<td><span idx='" + i + "' style='margin-left: 5px; cursor: pointer; color: #F6A828; text-decoration: underline;' class='tempsubscriber'  id='tempss_" + i + "'>remove</span></td></tr>";
                }
                else {
                    s += "</tr>";
                }
            }
            s += "</table>";
        }
        else {
            s += "No subscribers added.";
        }
        container.innerHTML = s;
    }



    $(document).ready(function () {
        $('#divloader').hide();
        wireupMilestoneDeletes();
        wireupSubscriberDeletes();
        // Smart Wizard 	
        $('#wizard').smartWizard({ onLeaveStep: leavingStepCallback, onFinish: onFinishCallback, onShowStep: showStepCallback });

        function onFinishCallback() {
            var isStepValid = true;
            $('input[id*="goal_"]').each(function () {
                if ($(this).val() == "" || $(this).val() == 'undefined' || !$.isNumeric($(this).val())) {
                    isStepValid = false;
                    $('#wizard').smartWizard('showMessage', 'You must enter a valid integer.');
                    $('#wizard').smartWizard('setError', { stepnum: 4, iserror: true });
                }
                else {
                    var newWeight = new GoalWeight();
                    newWeight.ID = $(this).attr("goalid");
                    newWeight.Weight = $(this).val();
                    newWeight.Title = "";
                    _goalweights.push(newWeight);
                }
            });
            if ($("#currentGoalWeight").val() == "" || $("#currentGoalWeight").val() == 'undefined' || !$.isNumeric($("#currentGoalWeight").val())) {
                isStepValid = false;
                $('#wizard').smartWizard('showMessage', 'Current goal weight must be a valid integer.');
                $('#wizard').smartWizard('setError', { stepnum: 4, iserror: true });
            }
            if (finalTotalWeight > 100) {
                isStepValid = false;
                $('#wizard').smartWizard('showMessage', 'Total weight cannot exceed 100');
                $('#wizard').smartWizard('setError', { stepnum: 4, iserror: true });
            }

            if (isStepValid) {
                _goal.Weight = $("#currentGoalWeight").val();
                $(".buttonFinish").hide();
                $('#wizard').css('background', 'transparent').css('opacity', '0.5');
                $('#divloader').show();
                alert(JSON.stringify(_goal));
                //saveWeights(JSON.stringify(_goalweights));
                saveGoal(JSON.stringify(_goal));
                $('#wizard').smartWizard('showMessage', 'Goal Successfully Created!');
                $('#wizard').smartWizard('setError', { stepnum: 4, iserror: false });
            }
        }

        function showStepCallback(obj) {
            var step_num = obj.attr('rel'); //get the current step number
            if (step_num == 4) {
                $(".buttonFinish").show();
                $("#finalDueDate").text($("#duedate").val());
                $("#finalGoalTitle").text($("#tbTitle").val());
                $("#finalGoalDescription").text($("#tbDescription").val());
                buildMilestoneOutput(finalMilestones, true);
                buildSubscribersOutput(finalSubscribers, true);
                //if (finalGoalWeights.innerHTML == "") {
                //    loadGoalWeights($("#enteredForID").val(), finalGoalWeights, function () {
                //        $("#weightTotalsLabel").text(this);
                //        weightTotalNumber = this;
                //        FormatWeightTotalLabel();
                //    });
                //    wireUpWeights();
                //}
                //$("#currentGoalWeight").change(function () {
                //    CalculateTotalWeight();
                //});
                //CalculateTotalWeight();
            }

        }

        function leavingStepCallback(obj) {
            var step_num = obj.attr('rel'); //get the current step number
            if (step_num == 1) {

                _goal.DueDate = dateToWcf($("#duedate").val());
                _goal.Title = $("#tbTitle").val();
                _goal.Description = $("#tbDescription").val();
                _goal.AccountID = "<%= HRR.Core.Security.SecurityContextManager.Current.CurrentAccount.ID %>";
                _goal.ChangedBy = "<%= HRR.Core.Security.SecurityContextManager.Current.CurrentUser.ID %>";
                _goal.EnteredBy = "<%= HRR.Core.Security.SecurityContextManager.Current.CurrentUser.ID %>";
                _goal.EnteredFor = $("#enteredForID").val();
                _goal.GoalType = 1;
                _goal.IsAccepted = true;
                _goal.IsApproved = true;
                _goal.IsTemplate = true;
                //_goal.ReviewID
                _goal.StatusID = 2;
                return validateSteps(step_num);
            }
            if (step_num == 2) {
                return validateSteps(step_num);
            }
            if (step_num == 3) {

            }
            return true;
        }

        // Your Step validation logic
        function validateSteps(stepnumber) {
            var isStepValid = true;
            // validate step 1
            switch (stepnumber) {
                case "1":
                    var date = new Date($("#duedate").val());
                    if (DateUtil.compare(date, CurrentDate()) == -1) {
                        isStepValid = false;
                        $('#wizard').smartWizard('showMessage', 'You cannot create a goal that is due in the past.');
                    }
                    if ($("#duedate").val() == "" || $("#duedate").val() == 'undefined') {
                        isStepValid = false;
                        $('#wizard').smartWizard('showMessage', 'Due date cannot be empty.');
                    }
                    if ($("#tbTitle").val() == "" || $("#tbTitle").val() == 'undefined') {
                        isStepValid = false;
                        $('#wizard').smartWizard('showMessage', 'Title cannot be empty.');
                    }
                    if ($("#tbDescription").val() == "" || $("#tbDescription").val() == 'undefined') {
                        isStepValid = false;
                        $('#wizard').smartWizard('showMessage', 'Description cannot be empty.');
                    }
                    break;
                case "2":
                    if (_milestones.length < 1) {
                        isStepValid = false;
                        $('#wizard').smartWizard('showMessage', 'You must create at least one milestone.');
                    }
                    break;
            }

            if (isStepValid == false) {
                $('#wizard').smartWizard('setError', { stepnum: stepnumber, iserror: true });
                //$('#wizard').smartWizard('showMessage', 'Step Has Invalid Data.');
            }
            else {
                $('#wizard').smartWizard('setError', { stepnum: stepnumber, iserror: false });
                $('#wizard').smartWizard('hideMessage', 'Validated!');
            }
            return isStepValid;
        }

        function wireUpWeights() {
            CalculateTotalWeight();
            $("#finalGoalWeights").on('change', 'input[id*="goal_"]', function () {
                $(this).each(function () {
                    CalculateTotalWeight();
                });
            });
        }



        function CalculateTotalWeight() {
            weightTotalNumber = 0;
            finalTotalWeight = 0;
            $('input[id*="goal_"]').each(function () {
                if ($(this).val() == "" || $(this).val() == 'undefined' || !$.isNumeric($(this).val())) {
                }
                else {
                    weightTotalNumber += parseInt($(this).val(), 10);
                }
            });
            weightTotalNumber += parseInt($("#currentGoalWeight").val(), 10);
            $('input[id*="goal_"]').each(function () {
                if ($(this).val() == "" || $(this).val() == 'undefined' || !$.isNumeric($(this).val())) {
                }
                else {
                    var retval = parseInt($(this).val(), 10) / (weightTotalNumber - parseInt($("#currentGoalWeight").val(), 10)) * (100 - parseInt($("#currentGoalWeight").val(), 10));
                    $(this).val(parseInt(retval, 10));
                    finalTotalWeight += parseInt(retval, 10);
                }
            });
            finalTotalWeight += parseInt($("#currentGoalWeight").val(), 10);
            $("#weightTotalsLabel").text(finalTotalWeight);
            FormatWeightTotalLabel();
        }

        function FormatWeightTotalLabel() {
            if (finalTotalWeight > 100) {
                $("#weightTotalsLabel").css("color", "#ff0000");
                $('#wizard').smartWizard('setError', { stepnum: 4, iserror: true });
                $('#wizard').smartWizard('showMessage', 'Total weight of all goals cannot exceed 100.');
            }
            else {
                $("#weightTotalsLabel").css("color", "#ffffff");
                $('#wizard').smartWizard('setError', { stepnum: 4, iserror: false });
                $('#wizard').smartWizard('hideMessage', 'Validated!');
            }
        }


        //Subscribers
        $("#lbAddSubscriber").click(function () {
            var isStepValid = true;
            subscribersList.innerHTML = "";

            if ($("#ddlManagers option:selected").val() == "" || $("#ddlManagers option:selected").val() == 'undefined') {
                isStepValid = false;
                $('#wizard').smartWizard('showMessage', 'You must select a manager first!');
            }

            if (isStepValid == false) {
                $('#wizard').smartWizard('setError', { stepnum: 3, iserror: true });
                //$('#wizard').smartWizard('showMessage', 'Step Has Invalid Data.');
                return isStepValid;
            }
            else {
                $('#wizard').smartWizard('setError', { stepnum: 3, iserror: false });
                $('#wizard').smartWizard('hideMessage', 'Validated!');
            }
            var newSubscriber = new GoalManager();
            newSubscriber.PersonID = $("#ddlManagers option:selected").val();
            newSubscriber.RecievesNotifications = $("#cbReceivesNotifications").is(":checked");
            newSubscriber.Name = $("#ddlManagers option:selected").text();
            _subscribers.push(newSubscriber);
            _goal.Managers.push(newSubscriber);
            buildSubscribersOutput(subscribersList, false);
            return false;
        });

        //Milestones
        $("#lbAddMilestone").click(function () {
            //validation
            var isStepValid = true;
            var goaldate = new Date($("#duedate").val());
            var milestonedate = new Date($("#milestoneduedate").val());

            if (DateUtil.compare(goaldate, milestonedate) == -1) {
                isStepValid = false;
                $('#wizard').smartWizard('showMessage', 'Milestone cannot be due after goal due date.');
            }
            if ($("#milestoneduedate").val() == "" || $("#milestoneduedate").val() == 'undefined') {
                isStepValid = false;
                $('#wizard').smartWizard('showMessage', 'Due date cannot be empty.');
            }
            if ($("#tbMilestoneTitle").val() == "" || $("#tbMilestoneTitle").val() == 'undefined') {
                isStepValid = false;
                $('#wizard').smartWizard('showMessage', 'Title cannot be empty.');
            }
            if ($("#tbMilestoneDescription").val() == "" || $("#tbMilestoneDescription").val() == 'undefined') {
                isStepValid = false;
                $('#wizard').smartWizard('showMessage', 'Description cannot be empty.');
            }

            if (isStepValid == false) {
                $('#wizard').smartWizard('setError', { stepnum: 2, iserror: true });
                return isStepValid;
            }
            else {
                $('#wizard').smartWizard('setError', { stepnum: 2, iserror: false });
                $('#wizard').smartWizard('hideMessage', 'Validated!');
            }

            milestonesList.innerHTML = "";
            var newMilestone = new GoalMilestone();
            newMilestone.DueDate = dateToWcf($("#milestoneduedate").val());
            newMilestone.Title = $("#tbMilestoneTitle").val();
            newMilestone.Name = $("#milestoneduedate").val();
            newMilestone.Description = $("#tbMilestoneDescription").val();
            newMilestone.AccountID = "<%= HRR.Core.Security.SecurityContextManager.Current.CurrentAccount.ID %>";
            newMilestone.ChangedBy = "<%= HRR.Core.Security.SecurityContextManager.Current.CurrentUser.ID %>";
            newMilestone.EnteredBy = "<%= HRR.Core.Security.SecurityContextManager.Current.CurrentUser.ID %>";
            newMilestone.EnteredFor = $("#enteredForID").val();
            newMilestone.IsAccepted = true;
            newMilestone.Status = 2;
            _milestones.push(newMilestone);
            _goal.Milestones.push(newMilestone);
            buildMilestoneOutput(milestonesList, false);
            $("#tbMilestoneTitle").val("");
            $("#milestoneduedate").val("");
            $("#milestoneduedate").focus();
            $("#tbMilestoneDescription").val("");
            return false;
        });






        $("#duedate").datepicker();
        $("#milestoneduedate").datepicker();
    });
</script>

</head><body>
    <form runat="server" id="form1">
    <telerik:radscriptmanager 
    ID="RadScriptManager1" 
    runat="server">
        <Scripts>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
        </Scripts>
    </telerik:radscriptmanager>
    <telerik:radajaxmanager 
    ID="RadAjaxManager1" 
    runat="server">
    </telerik:radajaxmanager>
    <!--HEADER WRAPPER STARTS-->
        <div id="header-wrapper" >
    	    <!--HEADER CONTAINER STARTS-->
            <div id="header-container" class="container">
        	    <!--LOGO STARTS-->
        	    <div id="header-logo">
              	    <a href="/Default.aspx"><img src="/images/logo.png" width="128" height="31" alt="HRRiver" /></a>
                </div>
                <!--LOGO ENDS-->
            </div> 
            <!--HEADER CONTAINER ENDS-->
        </div> 
            <table align="center" border="0" cellpadding="0" cellspacing="0">
            <tr><td>
            
        <div runat="server" id="divWizard"> 
<!-- Smart Wizard -->
  		<div id="wizard" class="swMain">
  			<ul>
  				<li><a href="#step-1">
                <label class="stepNumber">1</label>
                <span class="stepDesc">
                   Details<br />
                   <small>Create Goal Details</small>
                </span>
            </a></li>
  				<li><a href="#step-2">
                <label class="stepNumber">2</label>
                <span class="stepDesc">
                   Milestones<br />
                   <small>Add Milestones</small>
                </span>                   
             </a></li>
  				<li><a href="#step-3">
                <label class="stepNumber">3</label>
                <span class="stepDesc">
                   Notifications<br />
                   <small>Add Subscribers</small>
                </span>
            </a></li>
  				<li><a href="#step-4">
                <label class="stepNumber">4</label>
                <span class="stepDesc">
                   Review<br />
                   <small>Configure Weight and Save</small>
                </span>                   
            </a></li>
  			</ul>
  			<div id="step-1">	
            <h2 class="StepTitle">Add details and give a thorough description of what is to be accomplish.</h2>
                <div>
                <div>
                    <div>
                        Due Date: 
                    </div>
                    <input type="text" id="duedate" style="position: relative; z-index: 100000;" />
                </div>
                <%--<div>
                    <div>Type:</div>
                    <idea:GoalTypeDDL
                    runat="server"
                    ID="ddlType" />
                    <asp:RequiredFieldValidator
                    runat="server"
                    ID="RequiredFieldValidator5"
                    Display="Dynamic"
                    CssClass="error"
                    ErrorMessage="Select a goal type."
                    InitialValue=""
                    ControlToValidate="ddlType" />
                </div>--%>
                <div>
                    <div>Title:</div>
                    <idea:TextBox
                    runat="server"
                    ID="tbTitle"
                    Skin="Metro"
                    Width="690px" />
                    <asp:RequiredFieldValidator
                    runat="server"
                    ID="RequiredFieldValidator3"
                    Display="Dynamic"
                    CssClass="error"
                    ErrorMessage="Enter title."
                    InitialValue=""
                    ControlToValidate="tbTitle" />
                </div>
                <div>
                    <div>Description:</div>
                    <idea:TextBox
                    runat="server"
                    ID="tbDescription"
                    Skin="Metro"
                    TextMode="MultiLine"
                    Height="100px"
                    Width="690px" />
                    <asp:RequiredFieldValidator
                    runat="server"
                    ID="RequiredFieldValidator4"
                    Display="Dynamic"
                    CssClass="error"
                    ErrorMessage="Enter a description."
                    InitialValue=""
                    ControlToValidate="tbDescription" />
                </div>
                </div>
            </div>
            <div id="step-2">
            <h2 class="StepTitle">Add clearly defined milestones that will help track the goal's progress</h2>	
                <div>
                    <div>
                        <div>
                            Due Date: 
                        </div>
                        <input type="text" id="milestoneduedate" style="position: relative; z-index: 100000;" />
                    </div>
                    <div>
                        <div>Title:</div>
                        <idea:TextBox
                        runat="server"
                        ID="tbMilestoneTitle"
                        Skin="Metro"
                        Width="690px" />
                        <asp:RequiredFieldValidator
                        runat="server"
                        ID="RequiredFieldValidator7"
                        Display="Dynamic"
                        CssClass="error"
                        ErrorMessage="Enter title."
                        InitialValue=""
                        ControlToValidate="tbMilestoneTitle" />
                    </div>
                    <div>
                        <div>Description:</div>
                        <idea:TextBox
                        runat="server"
                        ID="tbMilestoneDescription"
                        Skin="Metro"
                        TextMode="MultiLine"
                        Height="75px"
                        Width="690px" />
                        <asp:RequiredFieldValidator
                        runat="server"
                        ID="RequiredFieldValidator8"
                        Display="Dynamic"
                        CssClass="error"
                        ErrorMessage="Enter a description."
                        InitialValue=""
                        ControlToValidate="tbMilestoneDescription" />
                    </div>
                    <div>
                        <idea:LinkButton
                        runat="server"
                        CssClass="wizardbutton"
                        ID="lbAddMilestone">
                            Add Milestone
                        </idea:LinkButton>
                    </div>
                </div>
                <div id="milestonesList">
                </div>	          
            </div>
  			<div id="step-3">
                <h2 class="StepTitle">Subscribe others to receive access to and notifications regarding this goal</h2>	
                <div>
                    <span>
                        Select Manager:
                    </span>
                    <span>
                        <idea:ManagersDDL
                        runat="server"
                        ID="ddlManagers" />
                    </span>&nbsp;&nbsp;&nbsp;
                    <span>
                        Receives Notifications:
                    </span>
                    <span>
                        <idea:CheckBox
                        runat="server"
                        ID="cbReceivesNotifications" />
                    </span>&nbsp;&nbsp;
                    <span>
                        <idea:LinkButton
                        runat="server"
                        CssClass="wizardbutton"
                        ID="lbAddSubscriber">
                            Add Subscriber
                        </idea:LinkButton>
                    </span>
                </div>
                <div>
                    
                </div><br />
                <div id="subscribersList">
                </div>
            </div>  
  			<div id="step-4">
            <h2 class="StepTitle">Configure goal weighting scale and save</h2>	
            <h5>
                Almost done!  Review the values and click finish to save goal or previous to go back and make changes. 
            </h5><br />
            <div class="goalWeights" style="float: right; margin-right: 20px;">
                <div>
                    <span style="font-weight: bold;">
                        Adjust your goal weights accordingly.  The total of all weights should not exceed 100.
                    </span>
                </div>
                <div id="finalGoalWeights" />
                <table style='width: 325px; padding: 1px;'>
                    <tr>
                        <td style='font-weight: bold; width: 250px; padding-bottom: 1px; padding-right: 15px;' align="right">Total Goals Weight</td>
                        <td style='font-weight: bold; width: 60px; padding-bottom: 1px;'>
                            <span id="weightTotalsLabel" />
                        </td>
                    </tr>
               </table>
            </div>
            <div style="float: left; padding-bottom: 20px; max-width: 275px;">
                <div>
                    <span style="font-weight: bold;">
                        Due Date:
                    </span>
                    <span id="finalDueDate" />
                </div>
                <div>
                    <span style="font-weight: bold;">
                       Title:
                    </span>
                    <span id="finalGoalTitle" />
                </div>
                <div>
                    <span style="font-weight: bold;">
                       Description:
                    </span>
                    <span id="finalGoalDescription" />
                </div>
                <div class="currentGoalWeight">
                    <div>
                        <span style="font-weight: bold;">
                           Enter the current goal's weight.
                        </span>
                    </div>
                    <span style="font-weight: bold;">
                        Weight:
                    </span>
                    <span style="margin-left: 5px;">
                        <input id="currentGoalWeight" type="text" style="width:50px;" value="0" />
                    </span>
                </div>
            </div>
            <div style="clear: both;" />
            <div>
                <h6>
                   Milestones:
                </h6>
                <div id="finalMilestones" />
            </div>
            <div>
                <h6>
                   Subscribers:
                </h6>
                <div id="finalSubscribers" />
            </div>
        </div>
  		</div>
<!-- End SmartWizard Content -->  		
        </div>
 		
</td></tr>
</table>
    <div id="divloader" style="z-index: 65000; position: fixed; top: 30%; left: 50%;">
        <img src="/images/loading.gif" alt="Loading..." style="border:none;"/>
    </div>
        <input type="hidden" name="stepindex" id="stepindex" runat="server" />
        <input type="hidden" name="enteredForID" id="enteredForID" runat="server" />
    </form>    		
</body>
</html>
