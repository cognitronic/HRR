﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="HRR.Website.ForgotPassword" %>
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

    <!-- JQUERY --> 
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.6.4/jquery.min.js">
    </script>
    <script type="text/javascript" src="/Scripts/modernizr-2.0.6.js"></script>  
    <script type="text/javascript" src="/Scripts/jquery.quicksand.js"></script>  
    <script type="text/javascript" src="/Scripts/jquery.prettyPhoto.js"></script>
    <script type="text/javascript" src="/Scripts/jquery.cycle.all.js"></script>
    <script type="text/javascript" src="/Scripts/jquery.roundabout.min.js"></script>
    <script type="text/javascript" src="/Scripts/jquery.easing.1.3.js"></script>
    <script type="text/javascript" src="/Scripts/jquery.twitter.js"></script>
    <script type="text/javascript" src="/Scripts/jquery.quovolver.js"></script>
    <script type="text/javascript" src="/Scripts/hoverIntent.js"></script>
    <script type="text/javascript" src="/Scripts/supersubs.js"></script>
    <script type="text/javascript" src="/Scripts/superfish.js"></script>
    <script type="text/javascript" src="/Scripts/custom.js"></script>
</head>
<body>
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
        <!--HEADER WRAPPER ENDS-->
    <div  style="width: 300px; margin: 0 auto;">
    <div runat="server" id="divMessage">
        <idea:Label
        runat="server"
        ForeColor="Red"
        ID="lblMessage" />
    </div>
    <div runat="server" id="divEmail">
        <div>
            <div>Username:</div>
            <idea:TextBox
            runat="server"
            Width="175px"
            ID="tbEmail" />
        </div>
        <div>
            <idea:LinkButton
            runat="server"
            ID="lbVerifyEmail"
            OnClick="VerifyEmailClicked">
                Verify Username
            </idea:LinkButton>
        </div>
    </div>
    <div runat="server" id="divPasswordAnswer">
        <div>
            <div>Security Question:</div>
            <idea:Label
            runat="server"
            ID="lblQuestion" />
        </div>
        <div>
            <div>Answer:</div>
            <idea:TextBox
            runat="server"
            ID="tbAnswer"
            Width="175px" />
        </div>
        <div>
            <idea:LinkButton
            runat="server"
            ID="lbVerifyAnswer"
            OnClick="VerifyAnswerClicked">
                Verify Answer
            </idea:LinkButton>
        </div>
    </div>
    <div runat="server" id="divPassword">
        <div>
            <div>Password:</div>
            <idea:TextBox
            TextMode="Password"
            runat="server"
            ID="tbPassword"
            Width="175px" />
        </div>
        <div>
            <div>Confirm Password:</div>
            <idea:TextBox
            runat="server"
            TextMode="Password"
            ID="tbConfirmPassword"
            Width="175px" />
        </div>
        <div>
            <idea:LinkButton
            runat="server"
            ID="lbVerifyPasswords"
            OnClick="VerifyPasswordsClicked">
                Update Password
            </idea:LinkButton>
        </div>
    </div>
</div>
</form>
</body>
</html>

