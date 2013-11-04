<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewEmployee.aspx.cs" Inherits="HRR.Website.Wizards.NewEmployee" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml"><head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
<title>HR River New Employee Wizard</title>

<link href="/styles/smart_wizard.css" rel="stylesheet" type="text/css"/>
    
    <script src="/Scripts/json.js" type="text/javascript"></script>
<script type="text/javascript" src="/Scripts/jquery.smartWizard-2.0.js"></script>
<script src="/Scripts/HRR.Domain.js" type="text/javascript"></script>
<script src="/Scripts/hrr.js" type="text/javascript"></script>
<script type="text/javascript">
    var _memberships = [];


    $(function () {
        $('#primaryinfocontainer').slimScroll({
            height: '200px',
            allowPageScroll: false,
            railVisible: true
        });

        $('#finalTeams').slimScroll({
            height: '200px',
            allowPageScroll: false,
            railVisible: true
        });
    });


    function wireupTeamDeletes() {
        $("#teamsList").on('click', 'span[class*="tempmembership"]', function (e) {
            _memberships.splice(parseInt($(this).attr("idx"), 10), 1);
            buildTeamOutput(teamsList, false);
        });
    }

    function buildTeamOutput(container, isfinal) {
        container.innerHTML = "";
        if (_memberships.length > 0) {
            var s = "<table id='testscroll' style='width: 690px; padding: 10px;'><tr><td style='font-weight: bold;'>Name</td><td style='font-weight: bold;'>Is Manager</td><td style='font-weight: bold;'>Has Access</td><td style='font-weight: bold;'>Receives Notifications</td></tr>"
            for (var i = 0; i < _memberships.length; i++) {
                s += "<tr><td style='width: 250px; padding-bottom: 10px;'>" + _memberships[i].Name + "</td><td style='width: 250px; padding-bottom: 10px;'>" + _memberships[i].IsManager + "</td><td style='width: 250px; padding-bottom: 10px;'>" + _memberships[i].HasAccess + "</td><td style='width: 350px; padding-bottom: 10px;'>" + _memberships[i].RecievesNotifications + "</td>";
                if (!isfinal) {
                    s += "<td><span idx='" + i + "' style='margin-left: 5px; cursor: pointer; color: #F6A828; text-decoration: underline;' class='tempmembership'  id='tempss_" + i + "'>remove</span></td></tr>";
                }
                else {
                    s += "</tr>";
                }
            }
            s += "</table>";
        }
        else {
            s += "No teams added.";
        }
        container.innerHTML = s;
    }



    $(document).ready(function () {
        $('#divloader').hide();
        wireupTeamDeletes();
        var _person = new Person();
        var _reviewsetup = new ReviewSetup();
        // Smart Wizard 	
        $('#wizard').smartWizard({ onLeaveStep: leavingStepCallback, onFinish: onFinishCallback, onShowStep: showStepCallback });

        function onFinishCallback() {
            var isStepValid = true;

            if ($("#reviewstartdate").val() == "" || $("#reviewstartdate").val() == 'undefined') {
                isStepValid = false;
                $('#wizard').smartWizard('showMessage', 'Review start date cannot be empty.');
                $('#wizard').smartWizard('setError', { stepnum: 4, iserror: true });
            }
            if ($("#reviewduedate").val() == "" || $("#reviewduedate").val() == 'undefined') {
                isStepValid = false;
                $('#wizard').smartWizard('showMessage', 'Review due date cannot be empty.');
                $('#wizard').smartWizard('setError', { stepnum: 4, iserror: true });
            }
            if ($("#ddlReviewTemplate option:selected").val() == "" || $("#ddlReviewTemplate option:selected").val() == 'undefined') {
                isStepValid = false;
                $('#wizard').smartWizard('showMessage', 'You must select a review template.');
            }

            if (isStepValid) {
                $(".buttonFinish").hide();
                $('#wizard').css('background', 'transparent').css('opacity', '0.5');
                $('#divloader').show();
                _reviewsetup.DueDate = dateToWcf($("#reviewduedate").val());
                _reviewsetup.StartDate = dateToWcf($("#reviewstartdate").val());
                _reviewsetup.TemplateID = $("#ddlReviewTemplates option:selected").val();
                if ($("#cbSendWelcomeNotification").is(":checked"))
                    _person.ReceiveCommentNotifications = true;
                else
                    _person.ReceiveCommentNotifications = false;
                saveEmployee(JSON.stringify({ person: _person, reviewsetup: _reviewsetup }));
                $('#wizard').smartWizard('showMessage', 'Employee Successfully Created!');
                $('#wizard').smartWizard('setError', { stepnum: 4, iserror: false });
            }
        }

        function showStepCallback(obj) {
            var step_num = obj.attr('rel'); //get the current step number
            if (step_num == 1) {
                $("#cbIsActive").prop('checked', true);
            }
            if (step_num == 3) {
                $("#cbHasAccess").prop('checked', true);
                $("#cbReceivesNotifications").prop('checked', true);
            }
            if (step_num == 4) {
                $(".buttonFinish").show();
                $("#reviewstartdate").focus();
                $("#finalIsActive").text(_person.IsActive);
                $("#finalIsManager").text(_person.IsManager);
                $("#finalFirstName").text($("#tbFirstName").val());
                $("#finalLastName").text($("#tbLastName").val());
                $("#finalEmail").text($("#tbEmail").val());
                $("#finalTitle").text($("#tbTitle").val());
                $("#finalDepartment").text($("#ddlDepartments option:selected").text());
                $("#finalManager").text($("#ddlManager option:selected").text());
                $("#finalSecurityRole").text($("#ddlSecurityRole option:selected").text());
                $("#finalHireDate").text($("#hiredate").val());
                $("#finalBirthdate").text($("#birthdate").val());
                $("#finalPassword").text($("#tbPassword").val());
                $("#finalSecurityQuestion").text($("#tbSecurityQuestion").val());
                $("#finalSecurityAnswer").text($("#tbSecurityAnswer").val());
                buildTeamOutput(finalTeams, true);

            }
        }

        function leavingStepCallback(obj) {
            var step_num = obj.attr('rel'); //get the current step number
            if (step_num == 1) {

                _person.IsActive = $("#cbIsActive").is(":checked");
                _person.Title = $("#tbTitle").val();
                _person.AccountID = "<%= HRR.Core.Security.SecurityContextManager.Current.CurrentAccount.ID %>";
                _person.ChangedBy = "<%= HRR.Core.Security.SecurityContextManager.Current.CurrentUser.ID %>";
                _person.EnteredBy = "<%= HRR.Core.Security.SecurityContextManager.Current.CurrentUser.ID %>";
                _person.AvatarPath = "<%= HRR.Core.ResourceStrings.DefaultImageNotFound %>";
                _person.Birthdate = dateToWcf($("#birthdate").val());
                _person.DepartmentID = $("#ddlDepartments option:selected").val();
                _person.Email = $("#tbEmail").val();
                _person.FirstName = $("#tbFirstName").val();
                _person.HireDate = dateToWcf($("#hiredate").val());
                _person.LastName = $("#tbLastName").val();
                if ($("#ddlManager option:selected").val() == "")
                    _person.ManagerID = -1;
                else
                    _person.ManagerID = $("#ddlManager option:selected").val();
                return validateSteps(step_num);
            }
            if (step_num == 2) {
                _person.IsManager = $("#cbIsManager").is(":checked");
                _person.RoleID = $("#ddlSecurityRole option:selected").val();
                _person.Password = $("#tbPassword").val();
                _person.PasswordQuestion = $("#tbSecurityQuestion").val();
                _person.PasswordAnswer = $("#tbSecurityAnswer").val();
                return validateSteps(step_num);
            }
            if (step_num == 3) {
                return validateSteps(step_num);
            }
            return true;
        }

        // Your Step validation logic
        function validateSteps(stepnumber) {
            var isStepValid = true;
            // validate step 1
            switch (stepnumber) {
                case "1":
                    if ($("#ddlDepartments option:selected").val() == "" || $("#ddlDepartments option:selected").val() == 'undefined') {
                        isStepValid = false;
                        $('#wizard').smartWizard('showMessage', 'You must select a department.');
                    }
                    if ($("#birthdate").val() == "" || $("#birthdate").val() == 'undefined') {
                        isStepValid = false;
                        $('#wizard').smartWizard('showMessage', 'Birthdate cannot be empty.');
                    }
                    if ($("#hiredate").val() == "" || $("#hiredate").val() == 'undefined') {
                        isStepValid = false;
                        $('#wizard').smartWizard('showMessage', 'Hire date cannot be empty.');
                    }
                    if ($("#tbTitle").val() == "" || $("#tbTitle").val() == 'undefined') {
                        isStepValid = false;
                        $('#wizard').smartWizard('showMessage', 'Title cannot be empty.');
                    }
                    if ($("#tbEmail").val() == "" || $("#tbEmail").val() == 'undefined') {
                        isStepValid = false;
                        $('#wizard').smartWizard('showMessage', 'Email cannot be empty.');
                    }
                    if ($("#tbLastName").val() == "" || $("#tbLastName").val() == 'undefined') {
                        isStepValid = false;
                        $('#wizard').smartWizard('showMessage', 'Last name cannot be empty.');
                    }
                    if ($("#tbFirstName").val() == "" || $("#tbFirstName").val() == 'undefined') {
                        isStepValid = false;
                        $('#wizard').smartWizard('showMessage', 'First name cannot be empty.');
                    }
                    break;
                case "2":
                    if ($("#tbSecurityAnswer").val() == "" || $("#tbSecurityAnswer").val() == 'undefined') {
                        isStepValid = false;
                        $('#wizard').smartWizard('showMessage', 'Security answer cannot be empty.');
                    }
                    if ($("#tbSecurityQuestion").val() == "" || $("#tbSecurityQuestion").val() == 'undefined') {
                        isStepValid = false;
                        $('#wizard').smartWizard('showMessage', 'Security question cannot be empty.');
                    }
                    if ($("#tbPassword").val() == "" || $("#tbPassword").val() == 'undefined') {
                        isStepValid = false;
                        $('#wizard').smartWizard('showMessage', 'Password cannot be empty.');
                    }
                    if ($("#ddlSecurityRole option:selected").val() == "" || $("#ddlSecurityRole option:selected").val() == 'undefined') {
                        isStepValid = false;
                        $('#wizard').smartWizard('showMessage', 'You must select a security role.');
                    }
                    break;
                case "3":
                    if (_memberships.length < 1) {
                        isStepValid = false;
                        $('#wizard').smartWizard('showMessage', 'You must add employee to at least one team.');
                    }
                    break;
            }

            if (isStepValid == false) {
                $('#wizard').smartWizard('setError', { stepnum: stepnumber, iserror: true });
            }
            else {
                $('#wizard').smartWizard('setError', { stepnum: stepnumber, iserror: false });
                $('#wizard').smartWizard('hideMessage', 'Validated!');
            }
            return isStepValid;
        }




        //Add to teams
        $("#lbAddMember").click(function () {
            var isStepValid = true;
            teamsList.innerHTML = "";

            if ($("#ddlTeams option:selected").val() == "" || $("#ddlTeams option:selected").val() == 'undefined') {
                isStepValid = false;
                $('#wizard').smartWizard('showMessage', 'You must select a team first!');
            }

            if (isStepValid == false) {
                $('#wizard').smartWizard('setError', { stepnum: 3, iserror: true });
                return isStepValid;
            }
            else {
                $('#wizard').smartWizard('setError', { stepnum: 3, iserror: false });
                $('#wizard').smartWizard('hideMessage', 'Validated!');
            }
            var newMember = new TeamMember();
            newMember.IsActive = true;
            newMember.HasAccess = $("#cbHasAccess").is(":checked");
            newMember.IsManager = $("#cbIsManager").is(":checked");
            newMember.TeamID = $("#ddlTeams option:selected").val();
            newMember.RecievesNotifications = $("#cbReceivesNotifications").is(":checked");
            newMember.Name = $("#ddlTeams option:selected").text();
            _memberships.push(newMember);
            _person.Memberships.push(newMember);
            buildTeamOutput(teamsList, false);
            return false;
        });




        $("#reviewstartdate").datepicker();
        $("#reviewduedate").datepicker();
        $("#hiredate").datepicker();
        $("#birthdate").datepicker();
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
                   Details <br />
                   <small>Add Primary Info</small>
                </span>
            </a></li>
  				<li><a href="#step-2">
                <label class="stepNumber">2</label>
                <span class="stepDesc">
                   Security<br />
                   <small>Add Security Settings </small>
                </span>                   
             </a></li>
  				<li><a href="#step-3">
                <label class="stepNumber">3</label>
                <span class="stepDesc">
                   Teams<br />
                   <small>Add Employee To Teams</small>
                </span>
            </a></li>
  				<li><a href="#step-4">
                <label class="stepNumber">4</label>
                <span class="stepDesc">
                   Review<br />
                   <small>Review Info And Save</small>
                </span>                   
            </a></li>
  			</ul>
  			<div id="step-1">	
            <h2 class="StepTitle">Add employee's primary information.</h2>
                <div id="primaryinfocontainer">
                    <div style="float: left; margin-right: 50px;">
                    <div>
                        <div>
                            Is Active?: 
                        </div>
                        <idea:CheckBox
                        runat="server"
                        ID="cbIsActive" />
                    </div>
                    <div>
                        <div>First Name:</div>
                        <idea:TextBox
                        runat="server"
                        ID="tbFirstName"
                        Width="350px" />
                    </div>
                    <div>
                        <div>Last Name:</div>
                        <idea:TextBox
                        runat="server"
                        ID="tbLastName"
                        Width="350px" />
                    </div>
                    <div>
                        <div>Email:</div>
                        <idea:TextBox
                        runat="server"
                        ID="tbEmail"
                        Width="350px" />
                        <asp:RegularExpressionValidator 
                        ID="valEmailAddress"
                        ControlToValidate="tbEmail"
                        CssClass="error"
                        ValidationExpression=".*@.*\..*" 
                        ErrorMessage="Email address is invalid." 
                        Display="Dynamic" 
                        EnableClientScript="true"
                        Runat="server"/>
                    </div>
                    <div>
                        <div>Title:</div>
                        <idea:TextBox
                        runat="server"
                        ID="tbTitle"
                        Width="350px" />
                        <asp:RequiredFieldValidator
                        runat="server"
                        ID="RequiredFieldValidator6"
                        Display="Dynamic"
                        CssClass="error"
                        ErrorMessage="Enter title."
                        InitialValue=""
                        ControlToValidate="tbTitle" />
                    </div>
                </div>
                    <div style="float: left;">
                    <div>
                        <div>Hire Date:</div>
                        <input type="text" id="hiredate" style="position: relative; z-index: 100000;" />
                    </div>
                    <div>
                        <div>Birth Date:</div>
                        <input type="text" id="birthdate" style="position: relative; z-index: 100000;" />
                    </div>
                    <div>
                        <div>Department:</div>
                        <idea:DepartmentsDDL
                        runat="server"
                        ID="ddlDepartments" />
                    </div>
                    <div>
                        <div>Manager:</div>
                        <idea:ManagersDDL
                        runat="server"
                        ID="ddlManager"/>
                    </div>
                </div>
                </div>
            </div>
            <div id="step-2">
            <h2 class="StepTitle">Configure security settings</h2>	
                <div id="securityContainer">
                    <div style="float: left;">
                        <h6>
                            If you have any questions regarding the abilities of the different security rules please click <a href="/Help/Comments#securityComment" target="_blank">here</a>. 
                        </h6>
                    </div>
                    <div style="float: left; margin-right: 50px;">
                        <div>
                            <div>
                                Is Manager?: 
                            </div>
                            <idea:CheckBox
                            runat="server"
                            ID="cbIsManager" />
                        </div>
                        <div>
                            <div>
                                Security Role:
                            </div>
                            <idea:SecurityRolesDDL
                            runat="server"
                            ID="ddlSecurityRole" />
                        </div>
                        <div>
                            <div>Password:</div>
                            <idea:TextBox
                            runat="server"
                            ID="tbPassword"
                            TextMode="Password"
                            Width="350px" />
                        </div>
                        <div>
                            <div>Security Question:</div>
                            <idea:TextBox
                            runat="server"
                            ID="tbSecurityQuestion"
                            Width="350px" />
                        </div>
                        <div>
                            <div>Security Answer:</div>
                            <idea:TextBox
                            runat="server"
                            ID="tbSecurityAnswer"
                            Width="350px" />
                        </div>
                    </div>
                </div> 
            </div>
  			<div id="step-3">
                <h2 class="StepTitle">Add employee to teams</h2>	
                <div id="teamscontainer">
                    <div style="float: left;">
                        <span>
                            Select Team:
                        </span>
                        <span>
                            <idea:TeamsDDL
                            runat="server"
                            ID="ddlTeams" />
                        </span>&nbsp;&nbsp;&nbsp;
                        <span>
                            Is Manager:
                        </span>
                        <span>
                            <idea:CheckBox
                            runat="server"
                            ID="CheckBox1" />
                        </span>&nbsp;&nbsp;
                        <span>
                            Has Access:
                        </span>
                        <span>
                            <idea:CheckBox
                            runat="server"
                            ID="cbHasAccess" />
                        </span>&nbsp;&nbsp;
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
                            ID="lbAddMember">
                                Add To Team
                            </idea:LinkButton>
                        </span>
                    </div><br />
                </div>
                <div id="teamsList">
                </div>	         
            </div>  
  			<div id="step-4">
                <h2 class="StepTitle">Set the inital employee review period and save</h2>	
                <h5>
                    Almost done!  Review the values and click finish to save employee or previous to go back and make changes. 
                 </h5><br />
                 <div id="finalcontainer">
                    <div style="float: left; margin-right: 50px;">
                        <div>
                            <span style="font-weight: bold;">Enter intial performance review period</span>
                            <div>Start Date:</div>
                            <input type="text" id="reviewstartdate" style="position: relative; z-index: 100000;" />
                        </div>
                        <div>
                            <div>Due Date:</div>
                            <input type="text" id="reviewduedate" style="position: relative; z-index: 100000;" />
                        </div>
                        <div>
                            <div>Review Template:</div>
                            <idea:ReviewTemplateDDL
                            runat="server"
                            ID="ddlReviewTemplates" />
                        </div>
                        <div>
                            <span>Do you want this employee to receive notifications? </span>
                            <idea:CheckBox
                            runat="server"
                            ID="cbSendWelcomeNotification" />
                        </div>
                    </div>
                    <div style="float: left; margin-right: 50px; padding-bottom: 5px;">
                        <div>
                            <span style="font-weight: bold;">
                               Is Active:
                            </span>
                            <span id="finalIsActive" />
                        </div>
                        <div>
                            <span style="font-weight: bold;">
                               First Name:
                            </span>
                            <span id="finalFirstName" />
                        </div>
                        <div>
                            <span style="font-weight: bold;">
                               Last Name:
                            </span>
                            <span id="finalLastName" />
                        </div>
                        <div>
                            <span style="font-weight: bold;">
                               Email:
                            </span>
                            <span id="finalEmail" />
                        </div>
                        <div>
                            <span style="font-weight: bold;">
                               Title:
                            </span>
                            <span id="finalTitle" />
                        </div>
                        <div>
                            <span style="font-weight: bold;">
                               Department:
                            </span>
                            <span id="finalDepartment" />
                        </div>
                        <div>
                            <span style="font-weight: bold;">
                               Security Question:
                            </span>
                            <span id="finalSecurityQuestion" />
                        </div>
                    </div>
                    <div style="float: left; padding-bottom: 5px;">
                        <div>
                            <span style="font-weight: bold;">
                               Is Manager:
                            </span>
                            <span id="finalIsManager" />
                        </div>
                        <div>
                            <span style="font-weight: bold;">
                               Hire Date:
                            </span>
                            <span id="finalHireDate" />
                        </div>
                        <div>
                            <span style="font-weight: bold;">
                               Birth Date:
                            </span>
                            <span id="finalBirthdate" />
                        </div>
                        <div>
                            <span style="font-weight: bold;">
                               Manager:
                            </span>
                            <span id="finalManager" />
                        </div>
                        <div>
                            <span style="font-weight: bold;">
                               Security Role:
                            </span>
                            <span id="finalSecurityRole" />
                        </div>
                        <div>
                            <span style="font-weight: bold;">
                               Password:
                            </span>
                            <span id="finalPassword" />
                        </div>
                        <div>
                            <span style="font-weight: bold;">
                               Security Answer:
                            </span>
                            <span id="finalSecurityAnswer" />
                        </div>
                    </div>
                </div>
                <div style="clear: both;" />
                <div>
                    <h6>
                       Teams:
                    </h6>
                    <div id="finalTeams" />
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
