<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="Reviews.aspx.cs" Inherits="HRR.Website.Reviews" %>
<%@ Register TagPrefix="idea" TagName="ReviewListView" Src="~/Views/ReviewListView.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="three_fourth last_column">
        <idea:ReviewListView
        runat="server"
        ID="reviewListView" />
    </div>
</asp:Content>
