<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HRR.Website.Login" %>

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
    <script src="/Scripts/jquery.json-2.2.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.esn.autobrowse.js" type="text/javascript"></script>
    <script type="text/javascript" src="/Scripts/diQuery-collapsiblePanel.js"></script>
    <script type="text/javascript" src="/Scripts/json.js"></script>
    <script type="text/javascript" src="/Scripts/hrr.js"></script>
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
        <!--HEADER WRAPPER ENDS-->
        <div>
            <div  style="width: 325px; margin: 100px auto;">
                <div>
                    <div style="margin-bottom: 3px;">Username</div>
                    <idea:TextBox
                    runat="server"
                    Width="310px"
                    Skin="Windows7"
                    ID="tbUsername">
                    </idea:TextBox>
                </div><br />
                <div>
                    <div style="margin-bottom: 3px;">Password</div>
                    <idea:TextBox
                    runat="server"
                    Width="310px"
                    Skin="Windows7"
                    ID="tbPassword"
                    TextMode="Password">
                    </idea:TextBox>
                </div><br />
                <div style="margin-bottom: 5px;">
                    <idea:Label
                    runat="server"
                    ForeColor="#ff0000"
                    ID="lblLoginMessage"
                    Visible="false">
                    </idea:Label>
                </div>
                <div>
                    <span>
                        <asp:Button
                            CssClass="button huge round sky-blue"
                            runat="server"
                            ID="lbLogin"
                            Text="Login"
                            OnClick="LoginClicked" />
                    </span>
                    <span>
                        <asp:Button
                            CssClass="button huge round sky-blue"
                            runat="server"
                            ID="lbForgotPassword"
                            Text="Forgot Password?"
                            OnClick="ForgotPasswordClicked" />
                    </span>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
