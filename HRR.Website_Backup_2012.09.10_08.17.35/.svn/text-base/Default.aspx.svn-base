<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HRR.Website.Default" %>
<%@ Register TagPrefix="idea" TagName="ActivityView" Src="~/Views/ActivityFeedView.ascx" %>
<%@ Register TagPrefix="idea" TagName="BlogView" Src="~/Views/BlogFeedView.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div style="float: right;">
        <div style="float: right; width: 200px; margin-right: 0px !important; padding-right: 0px !important; margin-bottom: 30px;  margin-top: 0px; margin-left: 5px;">
             
                <idea:ActivityView
                runat="server"
                id="avFeed" />
        </div>
        </div>
        <div style="float: left;">
        <div style="margin-top: 5px;">
            <idea:BlogView
                runat="server"
                ID="blogView" />
        </div>
        <%--<div class="containerouter" style="float: left; width: 525px !important; margin-top: 5px;">
        <div class="containerinner">
            <h4 style="margin-left: 5px;">Comments For Employee </h4>
             <telerik:RadChart 
             ID="rcCommentTypes" 
             runat="server" 
             Width="415px" 
             DataGroupColumn="CommentType" 
             ChartTitle-TextBlock-Text=""
             AutoTextWrap="true"
             PlotArea-Appearance-Border-Visible="false"
             PlotArea-YAxis-Appearance-MinorGridLines-Visible="false"
             PlotArea-XAxis-Appearance-MajorGridLines-Visible="false"
             PlotArea-YAxis-Appearance-MajorGridLines-Visible="false"
             PlotArea-Appearance-Dimensions-Margins-Left="130px"
             SeriesOrientation="Horizontal" 
             Skin="Web20">
            <Legend Visible="false">
                <Appearance GroupNameFormat="#VALUE">
                </Appearance>
            </Legend>
            <PlotArea>
                <XAxis DataLabelsColumn="Name">
                </XAxis>
            </PlotArea>
        </telerik:RadChart>
            </div>
        </div>--%>
        </div>
        <br />
    </div>
</asp:Content>
