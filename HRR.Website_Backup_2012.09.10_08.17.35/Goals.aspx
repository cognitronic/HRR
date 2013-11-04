<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="Goals.aspx.cs" Inherits="HRR.Website.Goals" %>
<%@ Register TagPrefix="idea" TagName="GoalListView" Src="~/Views/GoalListView.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="three_fourth last_column">
    <idea:GoalListView
    runat="server"
    ID="goalListView" />
</div>
</asp:Content>
