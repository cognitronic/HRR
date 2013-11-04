<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ActivityFeedView.ascx.cs" Inherits="HRR.Website.Views.ActivityFeedView" %>
<div style="background-color: #fff; border-left: 1px solid #d0d0d0; border-bottom: 1px solid #d0d0d0;">
<h3 style="margin-left: 5px; margin-bottom: 10px;">Activity Feed</h3> 
    <div runat="server" id="divActivity" style='margin-bottom: 30px; margin-left: 5px; margin-right: 0px;'>
        No Recent Activity Found
    </div>
    <asp:DataList
    runat="server"
    Width="201px"
    OnItemDataBound="ItemDataBound"
    ID="dlComments">
        <HeaderTemplate>
            
        </HeaderTemplate>
        <ItemTemplate>
            <div runat="server" id="divContainer">
            <div style="float: left; margin-left: 5px;">
                <telerik:RadBinaryImage ID="rbiProfile"
                runat="server"
                Width="25px"
                Height="25px"
                AutoAdjustImageControlSize="true"
                ImageUrl='<%# Eval("PerformedByRef.AvatarPath").ToString() %>'
                style="padding: 10px 0px 5px 0px;"/>
            </div>
            <div style="float: left; margin: 5px 5px 5px 5px; width: 160px;">
                <span style="font-size: 8pt;">
                    <a href='<%# "/People/" + Eval("PerformedByRef.Email").ToString() %>'><%#Eval("PerformedByRef.Name") %></a>                 
                </span>
                <span>
                    <idea:Label
                    runat="server"
                    ID="lblMessage" />
                </span>
            </div>
            <hr  style="margin: 5px 0px !important;"/>
            </div>
        </ItemTemplate>
    </asp:DataList>
</div>