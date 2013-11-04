<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AlertsListView.ascx.cs" Inherits="HRR.Website.Views.AlertsListView" %>
<div style="float: left; width: 525px;  margin-bottom: 30px;">
    <div class="widgetouter">
        <div class="widgetinner">
            <h3 style="margin-left: 5px; margin-bottom: 10px;">Alerts</h3> 
            <div runat="server" id="divAlerts" style='float: left; margin-left: 35px; margin-right: 15px;'>
                No Alerts Found
            </div>
            <asp:DataList
            runat="server"
            OnItemDataBound="ItemDataBound"
            ID="dlAlerts">
                <HeaderTemplate>
                    <table style="width: 400px; padding: 10px;">
                </HeaderTemplate>
                <ItemTemplate>
                    <tr style="border-bottom: 1px solid #ddd; ">
                        <td style="vertical-align:top; padding: 5px 5px;">
                            <telerik:RadBinaryImage ID="rbiProfile"
                            runat="server"
                            Width="25px"
                            Height="25px"
                            AutoAdjustImageControlSize="true"
                            ResizeMode="Fit"
                            DataValue='<%# HRR.Web.Utils.ImageResize.GetImageBytes(Eval("PerformedByRef.AvatarPath").ToString())  %>'
                            style="padding: 0px 0px 5px 0px;"/>
                        </td>
                        <td>
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
            
            <div style="clear: both;" />