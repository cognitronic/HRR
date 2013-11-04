<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="HRR.Website.Reports" %>

<%@ Register Assembly="Telerik.ReportViewer.WebForms, Version=4.2.11.204, Culture=neutral, PublicKeyToken=a9d7983dfcc261be"
    Namespace="Telerik.ReportViewer.WebForms" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<div runat="server" id="divFilter" class="three_fourth last_column">
<div style="clear: both;"/>
        <h5>Select Filters For Report: </h5>
        <div style="float: right; margin-top: -20px; " class="normal-button-holder">
            <table style="width: 710px;">
                <tr>
                    <td>
                        <div>Entered For: </div>
                        <idea:UsersDDL
                        runat="server"
                        ID="ddlEnteredFor" /> 
                    </td>
                    <td>     
                        <div>Comment Type: </div>
                        <idea:DropDownList
                        runat="server"
                        Skin="Metro"
                        ID="ddlCommentType">
                            <Items>
                                <telerik:RadComboBoxItem
                                runat="server"
                                Text="-- Select --"
                                Value="" />
                                <telerik:RadComboBoxItem
                                runat="server"
                                Text="Positive"
                                Value="1" />
                                <telerik:RadComboBoxItem
                                runat="server"
                                Text="Constructive"
                                Value="-1" />
                            </Items>
                        </idea:DropDownList>
                    </td>
                    <td>
                        <div>Category: </div>
                        <idea:CommentCategoryDDL
                        runat="server"
                        ID="ddlCommentCategory" />  
                    </td>
                </tr>
                <tr>
                    <td>
                        <div>Entered By: </div>
                        <idea:UsersDDL
                        runat="server"
                        ID="ddlEnteredBy" />      
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
        </div>
    <hr />
    </div>
    <div runat="server" id="divRunReport" style="float: right; margin-right: 30px;">
        <idea:LinkButton
        runat="server"
        OnClick="RunClicked"
        ID="lbRun"
        CssClass="button big round sky-blue">
            Run Report
        </idea:LinkButton>
    </div>
    <div style="float: right; margin-right: 30px; margin-top: 25px; overflow: hidden;">
        <telerik:ReportViewer 
        ID="ReportViewer1"
        Width="715" 
        Height="650px"
        runat="server">
        </telerik:ReportViewer>
    </div>
</asp:Content>
