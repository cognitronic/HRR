<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PageHelp.aspx.cs" Inherits="HRR.Website.PageHelp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <!--Meta-->
    <meta name="description" content="HRRiver - where the beer flows like wine!"/>
    <meta name="keywords" content=""/>
    <meta name="author" content=""/>

    <!--Google Fonts-->
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700,800' rel='stylesheet' type='text/css'/>

    <!--CSS Files Starts-->
    <link rel="stylesheet" href="/Styles/reset.css" type="text/css" />
    <link rel="stylesheet" href="/Styles/text.css" type="text/css" />
    <link rel="stylesheet" href="/Styles/prettyPhoto.css" type="text/css" />
    <link rel="stylesheet" href="/Styles/style.css" type="text/css" />
    <link rel="stylesheet" href="/Styles/jquery.qtip.min.css" type="text/css" />

    <!-- JQUERY --> 
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.6.4/jquery.min.js">
    </script>
    <script src="/Scripts/jquery.json-2.2.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.esn.autobrowse.js" type="text/javascript"></script>
    <script type="text/javascript" src="/Scripts/diQuery-collapsiblePanel.js"></script>
    <script type="text/javascript" src="/Scripts/json.js"></script>
    <script type="text/javascript" src="/Scripts/hrr.js"></script>
    <script type="text/javascript" src="/Scripts/jquery.qtip.min.js"></script>
</head>
<body style="background-color: #ffffff !important;">
    <form id="form1" runat="server">
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
        
        <div style="border: 2px solid #30a9de;">
        <!--HEADER WRAPPER ENDS-->
        <div style="margin: 20px 0px; font-size: 13px; padding: 20px;">
            <h3>Comments Documentation</h3><br />
            <div>
                Comments are one of the most effective ways for everyone in the organization to understand how they are doing on the job, not to mention one of the most efficient ways of linking performance to compensation.  That's why we've made entering comments extremely simple!  <br /><br />The following help topics will guide you through all you need to know to track employee performance!
            </div><br /><br />
            <div>
                <ul class="pagehelp">
                    <li>
                        <a href="#createComment">
                            How To Create A Comment
                        </a>
                        <br /><br />
                    </li>
                    <li>
                        <a href="#viewComment">
                            How To View A Comment
                        </a>
                        <br /><br />
                    </li>
                    <li>
                        <a href="#flagComment">
                            Flagging Inappropriate Comments
                        </a>
                        <br /><br />
                    </li>
                    <li>
                        <a href="#securityComment">
                            How Security Works For Comments
                        </a>
                    </li>
                </ul>
            </div>
            <br /><br />
            <div style="padding: 20px 0px;">
                <div id="createComment">
                    <h5 class="helptitle">How To Create A Comment</h5><br />
                    <ul class="pagehelp">
                        <li>
                            1. First you must select a team:<br />
                            <img src="/Images/Help/Comments_SelectTeam.png" alt="Select a Team" /><br /><br />
                        </li>
                        <li>
                            2.  Select whether the comment type is Positive or Constructive.  Click <a href="#commentTypes">here</a> if you have questions regarding which type to choose.<br />
                            <img src="/Images/Help/Comments_SelectType.png" alt="Select Comment Type" /><br /><br />
                        </li>
                        
                        <li>
                            3.  Select who you want to enter the comment for.<br />
                            <img src="/Images/Help/Comments_SelectEmployee.png" alt="Select Employee" /><br /><br />
                        </li>
                        
                        <li>
                            4.  Select the appropriate category that most closely matches the comment and click post.  It's that easy!!<br />
                            <img src="/Images/Help/Comments_SelectCategory.png" alt="Select Category" /><br /><br />
                        </li>
                    </ul>
                </div>
            </div>
            <br /><br />
            <div style="padding: 20px 0px;">
                <div id="viewComment" style="padding-top: 10px;">
                    <h5 class="helptitle">How To View A Comment</h5><br />
                    <ul class="pagehelp">
                        <li>
                            1. To get to the comment properties page you can either select the view button 
                            <img src="/Images/view.png" alt="View Icon" /> or you can click the responses link.<br /><br />
                        </li>
                        <li>
                            2.  From the properties page you can view when and by whom the comment was created, the type and category of the comment, as well as the team it is under.  <br />
                            <img src="/Images/Help/Comments_Properties.png" alt="The Comment Properties Page" /><br /><br />
                        </li>
                        
                        <li>
                            3.  <span style="font-weight: bold;">Only the comment recipient, their manager, and HR can view a comment's properties if it is</span> <span style="font-weight: bold; color: #ff0000;">constructive.</span>.<br /><br />
                        </li>
                        
                        <li>
                            4.  Managers and above have the ability to schedule a follow up date if the comment is marked constructive, along with a field for entering the resolution.  The follow up date can be automatically exported as an .ics file which can be automatically imported to many modern email clients.<br /><br />
                        </li>
                        <li>
                            5.  Any user who has access to the comment can leave a response.  Just type your message and hit post!<br /><img src="/Images/Help/Comments_Responses.png" alt="Comment Properties Responses" /><br /><br />
                        </li>
                    </ul>
                </div>
            </div>

            <br /><br />
            <div style="padding: 20px 0px;">
                <div id="flagComment" style="padding-top: 10px;">
                    <h5 class="helptitle">Flagging Inappropriate Comments</h5><br />
                    <ul class="pagehelp">
                        <li>
                            1.  Anyone can flag a comment as inappropriate by selecting the red flag from the list.  When flagged, the comment is immediately removed from the feed and a notification is sent to HR alerting them to review the post.  Only HR can remove the flag.  <br />
                            <img src="/Images/Help/Comments_Flagged.png" alt="The Comment Properties Page" /><br /><br />
                        </li>
                    </ul>
                </div>
            </div>

            <br /><br />
            <div style="padding: 20px 0px;">
                <div id="securityComment" style="padding-top: 10px;">
                    <h5 class="helptitle">How Security Works For Comments</h5><br />
                    <p>
                        Comment security is base on a combination of application level roles and team membership roles.  Here is a list of roles and their abilities:
                    </p>
                    <ul class="pagehelp">
                        <li>
                            1.  READ ONLY<br /> - It's just that, read only!  This role allows for a user to see all communication left for them, and them alone.  Read only cannot enter any comments or modify comments.<br /> <br />
                        </li>
                        <li>
                            2.  EMPLOYEE <br /> 
                            <span style="margin-left: 10px;"> - View all positive comments left for themselves and all their team members.
                            </span><br /> 
                            <span style="margin-left: 10px;"> - See constructive comments only left for them. 
                            </span><br /> 
                            <span style="margin-left: 10px;"> - Can leave comments for any employee on their team(s). 
                            </span><br /> 
                            <span style="margin-left: 10px;"> - Can leave comment responses for any employee on their team(s). 
                            </span>   <br /> <br />
                        </li>
                        <li>
                            3.  MANAGER <br /> 
                            <span style="margin-left: 10px;"> - View all positive comments left for themselves and all their team members.
                            </span><br /> 
                            <span style="margin-left: 10px;"> - See constructive comments left for all of their team members. 
                            </span><br /> 
                            <span style="margin-left: 10px;"> - Can leave comments for any employee on their team(s). 
                            </span><br /> 
                            <span style="margin-left: 10px;"> - Can leave comment responses for any employee on their team(s). 
                            </span><br /> 
                            <span style="margin-left: 10px;"> - Can schedule follow up face-to-face meetings to resolve constructive comments for any employee on their team(s). 
                            </span>   <br /> <br />
                        </li>
                        <li>
                            3.  EXECUTIVE MANAGEMENT <br /> 
                            <span style="margin-left: 10px;"> - View all comments entered into the system.
                            </span><br /> 
                            <span style="margin-left: 10px;"> - Can leave comments for any active employee. 
                            </span><br /> 
                            <span style="margin-left: 10px;"> - Can leave comment responses for any comment. 
                            </span><br /> 
                            <span style="margin-left: 10px;"> - Can schedule follow up face-to-face meetings to resolve constructive comments for any employee. 
                            </span>   <br /> <br />
                        </li>
                        <li>
                            4.  HR <br /> 
                            <span style="margin-left: 10px;"> - View all comments entered into the system.
                            </span><br /> 
                            <span style="margin-left: 10px;"> - Can leave comments for any active employee. 
                            </span><br /> 
                            <span style="margin-left: 10px;"> - Can leave comment responses for any comment. 
                            </span><br /> 
                            <span style="margin-left: 10px;"> - Can schedule follow up face-to-face meetings to resolve constructive comments for any employee. 
                            </span><br /> 
                            <span style="margin-left: 10px;"> - Can remove flag status from comment and insert back into feed. 
                            </span>   <br /> <br />
                        </li>
                    </ul>
                    <p>
                        The rules above are controlled in the employee's profile and can only be updated by HR<br /><br />
                        <img src="/Images/Help/Comments_SecurityRole.png" alt="Security Roles" /><br /><br />
                    </p>
                    <p>
                        In addition, there is also security on the Team Management section found underneath Settings.  Team Management works as follows: 
                    </p><br />
                    <ul class="pagehelp">
                        <li>
                            1.  ADD MANAGERS<br />
                            <span style="margin-left: 10px;"> - Teams can have multiple managers, and managers can be apart of multiple teams.</span>  
                            <span style="margin-left: 10px;"> - In order for a user to show up in the managers drop down list, they must have the option "Is Manager" selected in their profile.</span>
                            <span style="margin-left: 10px;"> - You can select whether or not the manager will receive new comment or update email notifications.
                            </span><br />
                            <img src="/Images/Help/Comments_AddManager.png" alt="Add Managers To A Team" /><br /><br />
                        </li>
                        <li>
                            2.  ADD MEMBERS<br />
                            <span style="margin-left: 10px;"> - All employees can be members and an employee can be a member of multiple teams.</span>  
                            <span style="margin-left: 10px;"> - If the "Has Access" field is not selected, then the team's managers will be able to track performance via the comments, but that employee will not be able to see or interact with that team at all.  This function is useful if you'd like upper management to track performance of middle and lower management in a more private, secure way.</span>
                            <span style="margin-left: 10px;"> - You can select whether or not the member will receive new comment or update email notifications.
                            </span><br />
                            <img src="/Images/Help/Comments_AddMember.png" alt="Add Members To A Team" /><br /><br />
                        </li>
                    </ul>
                </div>
            </div>

        </div>
        </div>
    </form>
</body>
</html>
