<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="ReviewTemplates.aspx.cs" Inherits="HRR.Website.ReviewTemplates" %>
<%@ Register TagPrefix="idea" TagName="TemplateListView" Src="~/Views/ReviewTemplateListView.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="three_fourth last_column">
        <idea:TemplateListView
        runat="server"
        ID="templateListView" />
    </div>
</asp:Content>
