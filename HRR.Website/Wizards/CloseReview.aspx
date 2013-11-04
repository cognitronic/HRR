<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CloseReview.aspx.cs" Inherits="HRR.Website.Wizards.CloseReview" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml"><head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
<title>HR River Close Review Wizard</title>

<link href="/styles/smart_wizard.css" rel="stylesheet" type="text/css"/>
    
    <script src="/Scripts/json.js" type="text/javascript"></script>
<script type="text/javascript" src="/Scripts/jquery.smartWizard-2.0.js"></script>
<script src="/Scripts/HRR.Domain.js" type="text/javascript"></script>
<script src="/Scripts/hrr.js" type="text/javascript"></script>
<script type="text/javascript">

    $(document).ready(function () {
        var _reviewsetup = new ReviewSetup();
        // Smart Wizard 	
        $('#wizard').smartWizard({ onLeaveStep: leavingStepCallback, onFinish: onFinishCallback, onShowStep: showStepCallback });

        function onFinishCallback() {
            var isStepValid = true;

            if ($("#reviewstartdate").val() == "" || $("#reviewstartdate").val() == 'undefined') {
                isStepValid = false;
                $('#wizard').smartWizard('showMessage', 'Review start date cannot be empty.');
                $('#wizard').smartWizard('setError', { stepnum: 1, iserror: true });
            }
            if ($("#reviewduedate").val() == "" || $("#reviewduedate").val() == 'undefined') {
                isStepValid = false;
                $('#wizard').smartWizard('showMessage', 'Review due date cannot be empty.');
                $('#wizard').smartWizard('setError', { stepnum: 1, iserror: true });
            }
            if ($("#ddlReviewTemplate option:selected").val() == "" || $("#ddlReviewTemplate option:selected").val() == 'undefined') {
                isStepValid = false;
                $('#wizard').smartWizard('showMessage', 'You must select a review template.');
            }

            if (isStepValid) {
                $(".buttonFinish").hide();
                $('#wizard').css('background', 'transparent').css('opacity', '0.5');
                _reviewsetup.DueDate = dateToWcf($("#reviewduedate").val());
                _reviewsetup.StartDate = dateToWcf($("#reviewstartdate").val());
                _reviewsetup.TemplateID = $("#ddlReviewTemplates option:selected").val();
                closeReview(JSON.stringify({ oldreview: $("#reviewID").val(), reviewsetup: _reviewsetup }));
                $('#wizard').smartWizard('showMessage', 'Employee Successfully Created!');
                $('#wizard').smartWizard('setError', { stepnum: 1, iserror: false });
            }
        }

        function showStepCallback(obj) {
            
        }

        function leavingStepCallback(obj) {
           
        }

        // Your Step validation logic
        function validateSteps(stepnumber) {

        }
        $("#reviewstartdate").datepicker();
        $("#reviewduedate").datepicker();
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
  				    <li>
                        <a href="#step-1">
                            <label class="stepNumber">1</label>
                            <span class="stepDesc">
                               Details<br />
                               <small>Create Goal Details</small>
                            </span>
                        </a>
                    </li>
  			    </ul>
  			    <div id="step-1">	
                    <h2 class="StepTitle">Assign new review period and save.</h2>
                    <div>
                        <div>
                            <span style="font-weight: bold;">Enter performance review period</span>
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
                    </div>
                </div>
  		    </div>
    <!-- End SmartWizard Content -->  		
        </div>
 		
</td></tr>
</table>
        <input type="hidden" name="stepindex" id="stepindex" runat="server" />
        <input type="hidden" name="reviewID" id="reviewID" runat="server" />
    </form>    		
</body>
</html>

