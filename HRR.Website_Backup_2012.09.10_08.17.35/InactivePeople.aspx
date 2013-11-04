<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="InactivePeople.aspx.cs" Inherits="HRR.Website.InactivePeople" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="three_fourth last_column">
     <img src='/Images/icon_users.png' style="margin-top: 5px;" height="48px" width="48px" border="0" alt="" /><h3 style="display:inline !important;">Company Staffing Profile - INACTIVE</h3>
    <div style="margin-left: 600px; margin-top: -45px !important; margin-bottom: 50px;">
        <idea:LinkButton
        runat="server"
        ID="lbAddEmployee"
        OnClick="AddEmployeeClicked">
            <img src="/Images/add.png" title="Add New Employee" alt="" /> New Employee
        </idea:LinkButton>
    </div>
    
    <div id="divPeople" runat="server" style=" margin-top: 10px !important;"/>
    </div>
</asp:Content>
