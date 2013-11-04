<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UpcomingEventsListView.ascx.cs" Inherits="HRR.Website.Views.UpcomingEventsListView" %>
<div style="width: 525px; margin-bottom: 30px;">
    <div class="widgetouter">
        <div class="widgetinner">
            <h3 style="margin-left: 5px; margin-bottom: 10px;">Upcoming Events</h3>
            <div runat="server" id="divEvents" style='float: left; margin-left: 35px; margin-right: 15px;'>
                No Upcoming Events
            </div>
            <asp:DataList
            runat="server"
            OnItemDataBound="ItemDataBound"
            ID="dlEvents">
                <HeaderTemplate>
                    <table style="width: 400px; padding: 10px;">
                </HeaderTemplate>
                <ItemTemplate>
                    <tr style="border-bottom: 1px solid #ddd; ">
                        <td style="vertical-align:top; padding: 5px 5px; width: 30px;">
                            <telerik:RadBinaryImage ID="rbiProfile"
                            runat="server"
                            Width="25px"
                            Height="25px"
                            AutoAdjustImageControlSize="true"
                            style="padding: 0px 0px 5px 0px;"/>
                        </td>
                        <td style="width: 400px;">
                            <idea:Label
                            runat="server"
                            ID="lblMessage" />
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:DataList>
        </div>
    </div>
</div>