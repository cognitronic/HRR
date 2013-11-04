<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="HRRV2.Website.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <asp:PlaceHolder ID="pcHead" runat="server">     
        <%: Styles.Render("~/Content/css") %>
          <%: Scripts.Render("~/bundles/modernizr") %>
         <%: Scripts.Render("~/bundles/jquery") %>
         <%: Scripts.Render("~/bundles/jqueryui") %>
         <%: Scripts.Render("~/bundles/jqueryval") %>
        <%: Scripts.Render("~/bundles/WebFormsJs") %>
    </asp:PlaceHolder>  
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <meta name="viewport" content="width=device-width" />

    <script type="text/javascript">

        $(document).ready(function () {

            

        });



        



        // Email Validation

        function isValidEmailAddress(emailAddress) {

            var pattern = new RegExp(/^(("[\w-\s]+")|([\w-]+(?:\.[\w-]+)*)|("[\w-\s]+")([\w-]+(?:\.[\w-]+)*))(@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$)|(@\[?((25[0-5]\.|2[0-4][0-9]\.|1[0-9]{2}\.|[0-9]{1,2}\.))((25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\.){2}(25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\]?$)/i);

            return pattern.test(emailAddress);

        }





</script>


</head>
<body>
    <form id="wizard2" method="post" action="#" class="form-horizontal row-fluid" runat="server">
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
        <section id="topnav">
            <div id="top">
                <div class="top-wrapper">
                    <a href="/" title="">
                        <img src="/images/logo.png" class="logo" alt="" />
                    </a>
                </div>
            </div>
        </section>
        <div id="mainwrapper" class="wrapper">
	        <!-- Left sidebar -->
            <section id="sidebar">
                <div class="sidebar">
                </div>
            </section>
            <!-- /left sidebar -->

            <!-- Main content -->
            <div class="content">
                <div id="body">
                   <!-- Wizard with validation -->
            <!-- /wizard with validation --> 

                    <div class="block row-fluid">
                       <h4>
                        Enter some basic info and you're off!
                       </h4>
                       <div>
                            <div class="separator-doubled"></div>
                            <h6>
                                Create Admin User
                            </h6>
                            <div class="control-group clearfix">
                                <div class="span12">
                                    <label class="control-label">
                                        First Name:
                                    </label>
                                    <div class="controls">
                                        <idea:TextBox
                                        runat="server"
                                        ID="tbFirstName"
                                        Width="400"
                                        Skin="Metro" />
                                    </div>
                                </div>
                            </div>
                            <div class="control-group clearfix">
                                <div class="span12">
                                    <label class="control-label">
                                        Last Name:
                                    </label>
                                    <div class="controls">
                                        <idea:TextBox
                                        runat="server"
                                        ID="tbLastName"
                                        Width="400"
                                        Skin="Metro" />
                                    </div>
                                </div>
                            </div>
                            <div class="control-group clearfix">
                                <div class="span12">
                                    <label class="control-label">
                                        Company Name:
                                    </label>
                                    <div class="controls">
                                        <idea:TextBox
                                        runat="server"
                                        ID="tbCompany"
                                        Width="400"
                                        Skin="Metro" />
                                    </div>
                                </div>
                            </div>
                            <div class="control-group clearfix">
                                <div class="span12">
                                    <label class="control-label">
                                        Job Title:
                                    </label>
                                    <div class="controls">
                                        <idea:TextBox
                                        runat="server"
                                        ID="tbTitle"
                                        Width="400"
                                        Skin="Metro" />
                                    </div>
                                </div>
                            </div>
                            <div class="control-group clearfix">
                                <div class="span12">
                                    <label class="control-label">
                                        Work Phone:
                                    </label>
                                    <div class="controls">
                                        <idea:TextBox
                                        runat="server"
                                        ID="tbPhone"
                                        Width="400"
                                        Skin="Metro" />
                                    </div>
                                </div>
                            </div>
                            <div class="separator-doubled"></div>
                            <h6>
                                Account Info
                            </h6>
                            <div class="control-group clearfix">
                                <div class="span12">
                                    <label class="control-label">
                                        Work Email:
                                    </label>
                                    <div class="controls">
                                        <idea:TextBox
                                        runat="server"
                                        ID="tbEmail"
                                        Width="400"
                                        Skin="Metro" />
                                    </div>
                                </div>
                            </div>
                            <div class="control-group clearfix">
                                <div class="span12">
                                    <label class="control-label">
                                        Password:
                                    </label>
                                    <div class="controls">
                                        <idea:TextBox
                                        runat="server"
                                        ID="tbPassword"
                                        Width="400"
                                        Skin="Metro" />
                                    </div>
                                </div>
                            </div>
                            <div class="control-group clearfix">
                                <div class="span12">
                                    <label class="control-label">
                                        Re-enter Password:
                                    </label>
                                    <div class="controls">
                                        <idea:TextBox
                                        runat="server"
                                        ID="tbReenterPassword"
                                        Width="400"
                                        Skin="Metro" />
                                    </div>
                                </div>
                            </div>
                            <div class="control-group clearfix">
                                <div class="span12">
                                    <label class="control-label">
                                        Site Address:
                                    </label>
                                    <div class="controls">
                                        <idea:TextBox
                                        runat="server"
                                        ID="tbSiteAddress"
                                        Width="400"
                                        Skin="Metro" /> .hrriver.com
                                    </div>
                                </div>
                            </div>
                            <div class="separator-doubled"></div>
                            <div class="control-group clearfix">
                                <div class="span12">
                                    <div>
                                        <idea:CheckBox
                                        runat="server"
                                        ID="cbTermsofService"
                                        Skin="Metro" />&nbsp;&nbsp;
                                        <label>
                                            I agree to the <a href="#">Terms of Service</a> and <a href="#">Privacy Policy</a>:
                                        </label>
                                    </div>
                                    <div >
                                        <idea:LinkButton
                                        CssClass="btn btn-info btn-large"
                                        runat="server"
                                        ID="lbRegister"
                                        OnClick="SaveClicked"
                                        Text="Get Started!" />

                                    </div>
                                </div>
                            </div>
                       </div>
                    </div>
                </div>
            </div>
            <!-- /Main content -->
        </div>
    </form>
</body>
</html>
