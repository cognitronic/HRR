<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HRRV2.Website.Login" %>

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
        <!-- Main wrapper -->
<div class="login-wrapper">

    <div class="login">

        <a href="#" title="" class="login-logo"><img src="/images/logo_color_small.png" alt="" /></a>

        <!-- Login block -->
        <div class="well">
            <div class="navbar">
                <div class="navbar-inner">
                    <h6><i class="font-user"></i>Login page</h6>
                    <div class="nav pull-right">
                        <a href="#" class="dropdown-toggle just-icon" data-toggle="dropdown"><i class="font-cog"></i></a>
                        <ul class="dropdown-menu pull-right">
                            <li><a href="#"><i class="font-plus"></i>Register</a></li>
                            <li><a href="#"><i class="font-refresh"></i>Recover password</a></li>
                        </ul>
                    </div>
                </div>
            </div>
          
                <div class="control-group">
                    <idea:Label runat="server" for="email" CssClass="control-label">Username (email address)</idea:Label>
                    <div class="controls span12">
                        <idea:TextBox
                        runat="server"
                        id="email"
                        name="email"
                        class="span12"
                        placeholder="username" />
                    </div>
                    
                </div>
                
                <div class="control-group">
                  <idea:Label runat="server" for="password" CssClass="control-label">Password</idea:Label>
                    <div class="controls">
                        <idea:TextBox
                        runat="server"
                        TextMode="Password"
                        id="password"
                        name="password"
                        class="span12"
                        placeholder="password" />
                    </div>
                </div>
                 <div runat="server" id="divMessage" class="note note-danger">
                     <button type="button" class="close">x</button>
                     <idea:Label runat="server" id="lblMessage" />
                 </div>   

                <div class="login-btn">
                    <asp:Button
                    CssClass="btn btn-info btn-block btn-large"
                    runat="server"
                    ID="lbLogin"
                    Text="Login"
                    OnClick="LoginClicked" />

                </div>
        </div>
        <!-- /login block -->

    </div>
    <script type="text/javascript">
        $(".notice .close").click(function () {
            $(this).parent().parent('.notice').fadeTo(200, 0.00, function () { //fade
                $(this).slideUp(200, function () { //slide up
                    $(this).remove(); //then remove from the DOM
                });
            });
        });

        window.setTimeout(function () {
            $(".closing").fadeTo(200, 0).slideUp(200, function () {
                $(this).remove();
            });
        }, 5000);
    </script>
</div>
<!-- /main wrapper -->
    </form>
</body>
</html>
