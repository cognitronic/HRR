<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="Messages.aspx.cs" Inherits="HRR.Website.Messages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<telerik:RadAjaxManagerProxy ID="ramp" runat="server" >
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="ddlActions">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="divList" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server"  Skin="Simple" Transparency="15" />
    <div>
        <div style="float: right;">
            <div style="float: right; width: 140px; margin-right: 0px !important; padding-right: 0px !important; margin-bottom: 30px;  margin-top: 0px; margin-left: 5px;">
                <div style="background-color: #fff; border-left: 1px solid #d0d0d0; border-bottom: 1px solid #d0d0d0;">
                    <h3 style="margin-left: 5px; margin-bottom: 5px;">Mailbox</h3> 
                    <div style="padding: 5px 0px 10px 0px;">
                        <div runat="server" id="divInboxNav" class="mailbox-items">
                            <idea:LinkButton
                            runat="server"
                            OnClick="InboxClicked"
                            style="vertical-align: top;"
                            ID="lbInbox">
                            <img src="/images/inbox.png" alt="Inbox" title="Inbox" />     Inbox
                            </idea:LinkButton>
                        </div>
                        <div runat="server" id="divSentNav" class="mailbox-items">
                            <idea:LinkButton
                            runat="server"
                            OnClick="SentClicked"
                            style="vertical-align: top;"
                            ID="lbSent">
                                <img src="/images/mail_send.png" alt="Sent" title="Sent" />Sent
                            </idea:LinkButton>
                        </div>
                        <div runat="server" id="divArchivedNav" class="mailbox-items">
                            <idea:LinkButton
                            runat="server"
                            OnClick="ArchivedClicked"
                            style="vertical-align: top;"
                            ID="lbArchive">
                                <img src="/images/zip-icon.png" alt="Archive" title="Archive" />Archived
                            </idea:LinkButton>
                        </div>
                        <div runat="server" id="divTrashNav" class="mailbox-items">
                            <idea:LinkButton
                            runat="server"
                            OnClick="TrashClicked"
                            style="vertical-align: top;"
                            ID="lbTrash">
                                <img src="/images/trash_can.png" alt="Trash" title="Trash" />Trash
                            </idea:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div style="float: left;">
        <div style="margin-top: 5px;">                                                           <div style="float: left; width: 600px;  margin-bottom: 30px;">
                <div style="margin-left: 275px; margin-bottom: 5px;">
                    <span style="vertical-align: top;">
                        <idea:LinkButton
                        runat="server"
                        OnClick="NewMessageClicked"
                        ID="lbNewMessage">
                            <img src="/images/add.png" alt="" />Compose New Message
                        </idea:LinkButton>
                    </span> | 
                    <span runat="server" id="spnActions" style="vertical-align: top;">
                       <idea:DropDownList
                       runat="server"
                       ID="ddlActions"
                       OnSelectedIndexChanged="ActionSelectedIndexChanged"
                       EmptyMessage="Actions"
                       Skin="Metro"
                       AutoPostBack="true">
                        <Items>
                            <telerik:RadComboBoxItem
                            Value=""
                            Text="" />
                            <telerik:RadComboBoxItem
                            Value="0"
                            Text="Mark As Read" />
                            <telerik:RadComboBoxItem
                            Value="1"
                            Text="Mark As Unread" />
                            <telerik:RadComboBoxItem
                            Value="2"
                            Text="Archive" />
                            <telerik:RadComboBoxItem
                            Value="3"
                            Text="Delete" />
                            <telerik:RadComboBoxItem
                            Value="4"
                            Text="Report To HR" />
                        </Items>
                       </idea:DropDownList>
                    </span>
                </div>
                <div class="widgetouter">
                    <div runat="server" id="divList" class="widgetinner">
                        <h3 style="display:inline !important; margin-bottom: 10px;">
                            Messages - 
                            <idea:Label
                            runat="server"
                            ID="lblCurrentFolder" />
                        </h3>
                        <br /><br />
                        <idea:Label
                        runat="server"
                        ID="lblNoMessages" />
                        <asp:DataList
                        runat="server"
                        OnItemDataBound="MessagesItemDataBound"
                        ID="dlMessages">
                            <ItemTemplate>
                                <div runat="server" id="divContainer">
                                <div style="float: left; margin-right: 5px;">
                                    <idea:CheckBox
                                    runat="server"
                                    itemid='<%# Eval("ID") %>'
                                    ID="cbSelected" />
                                </div>
                                <div style="float: left; margin-right: 5px;">
                                    <telerik:RadBinaryImage ID="rbiProfile"
                                    runat="server"
                                    Width="50px"
                                    Height="50px"
                                    ToolTip='<%# Eval("MessageRef.SentByRef.Name").ToString()%>'
                                    AutoAdjustImageControlSize="true"
                                    ImageUrl='<%# Eval("MessageRef.SentByRef.AvatarPath").ToString() %>'
                                    style="padding: 0px 0px 0px 0px;"/>
                                </div>
                                <div style="float: left; margin-left: 10px; margin-top: -5px; width: 450px;">
                                    <span runat="server" id="spnTitle" style="font-size: 10pt; font-weight: bold;">
                                        <a href='<%# "/Messages/" + Eval("MessageRef.ID").ToString() %>'>
                                            <%#Eval("MessageRef.Subject")%>
                                        </a>
                                    </span><br />
                                    <span>
                                        <%# IdeaSeed.Core.Utils.Utilities.FormatTextForCondensedDisplay(Eval("MessageRef.Body"), 150) %>
                                    </span><br />
                                </div>
                                <div style="float: right; margin-left: 15px; width: 20px;">
                                    <img id="imgDelete" src="/images/delete.png" title="Delete Message" alt="" />
                                </div>
                                <div style="clear: both;" />
                                <div style="margin-left: 90px;">
                                    <span runat="server" id="lblEnteredBy" style="font-size: 8pt; color: #000000;">entered by <a href='<%# "/People/" + Eval("MessageRef.SentByRef.Email").ToString() %>'><i><%# Eval("MessageRef.SentByRef.Name").ToString()%></i></a> on </span>
                                        <span style="font-size: 8pt; color: #cc6600;"><%#DateTime.Parse(Eval("MessageRef.DateCreated").ToString()).ToString("MMM d, yyyy @ HH:mm")%></span>
                                </div>
                                <hr />
                                </div>
                            </ItemTemplate>
                        </asp:DataList>
                        <div style="margin-bottom: 30px;" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    </div>
</asp:Content>
