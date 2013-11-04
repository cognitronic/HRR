<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="People.aspx.cs" Inherits="HRR.Website.People" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script language="javascript" type="text/javascript">
    $(window).load(function () {
        $(".collapsibleContainerContent").slideToggle();
    });
</script>  
<div class="three_fourth last_column">
     <img src='/Images/icon_users.png' style="margin-top: 5px;" height="48px" width="48px" border="0" alt="" /><h3 style="display:inline !important;">Company Staffing Profile</h3>
    <div style="margin-left: 450px; margin-top: -45px !important; margin-bottom: 50px;">
        <idea:LinkButton
        runat="server"
        ID="lbAddEmployee"
        OnClick="AddEmployeeClicked">
            <img src="/Images/add.png" title="Add New Employee" alt="" /> New Employee
        </idea:LinkButton>&nbsp;&nbsp;
        <idea:LinkButton
        runat="server"
        ID="lbInactiveEmployees"
        OnClick="InactiveEmployeeClicked">
            <img src="/Images/delete_user.png" title="Inactive Employees" alt="" /> Inactive Employees
        </idea:LinkButton>
    </div>
    <div>
        Click on a department to expand
    </div>
    <div id="divPeople" runat="server" style=" margin-top: 5px !important;"/>
    </div>
</asp:Content>
