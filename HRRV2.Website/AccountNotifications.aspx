<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="AccountNotifications.aspx.cs" Inherits="HRRV2.Website.AccountNotifications" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:RadAjaxManagerProxy ID="rampComments" runat="server" >
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rgNotifications">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgNotifications" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Simple" Transparency="15" />
    <script type="text/javascript">
        setCurrentMenuItem("nav-settings", "subnav-notifications");
    </script>

    <div class="page-header">
        <h5><i class="icon-th-large"></i>Notification Subscriptions</h5>
    </div>
    <div class="body">
        <div>
            <telerik:RadGrid
            runat="server"
            ID="rgNotifications"
            AllowPaging="True"
            AutoGenerateColumns="false"
            AllowSorting="True" 
            OnItemCommand="NotificationsItemCommand"
            OnItemCreated="NotificationsItemCreated"
            GridLines="None"
            ShowStatusBar="true"
            OnNeedDataSource="NotificationsNeedDataSource"
            ShowFooter="true"
            Skin="Metro">
                <ClientSettings EnableRowHoverStyle="true">
                </ClientSettings>
                <MasterTableView 
                DataKeyNames="ID"
                ItemStyle-VerticalAlign="Top"
                AlternatingItemStyle-VerticalAlign="Top"
                CommandItemDisplay="Top"
                EnableNoRecordsTemplate="true"
                CommandItemSettings-AddNewRecordText="Add New Subscriber"
                NoMasterRecordsText="No Notification Subscriptions Found.">
                    <Columns>
                        <telerik:GridTemplateColumn 
                        DataField="IsActive" 
                        HeaderText="Is Active" 
                        UniqueName="IsActive">
                            <ItemTemplate>
                                <%# Eval("IsActive").ToString().Equals("True") ? "Yes" : "No" %>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <idea:CheckBox
                                runat="server"
                                ID="cbIsActive"
                                Checked='<%# IdeaSeed.Core.Utils.Utilities.FormatCheckBox(Eval("IsActive"))%>' />
                                <div style="margin: 10px 0px;" />
                            </EditItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn 
                        DataField="Subscriber.Name" 
                        HeaderText="Subscriber" 
                        UniqueName="Subscriber.Name">
                            <ItemTemplate>
                                <%# Eval("Subscriber.Name")%>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <idea:ManagersDDL
                                runat="server"
                                ID="ddlSubscriber"
                                SelectedValue='<%# Eval("PersonID")%>' />
                                <div style="margin: 10px 0px;" />
                                <asp:RequiredFieldValidator
                                runat="server"
                                ID="sdfsdf"
                                Display="Dynamic"
                                InitialValue=""
                                CssClass="error"
                                ControlToValidate="ddlSubscriber"
                                ErrorMessage="Select a subscriber" />
                            </EditItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn 
                        DataField="NotificaionID" 
                        HeaderText="Notificaion" 
                        SortExpression="NotificaionID"
                        UniqueName="NotificaionID">
                            <ItemTemplate>
                                <%#System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Enum.GetName(typeof(HRR.Core.Domain.Notification), Eval("NotificationID"))).Replace("_or_", @"/").Replace("_", " ").ToLower()%>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <idea:NotificationsDDL
                                runat="server"
                                ID="ddlNotification"
                                SelectedValue='<%# Eval("NotificationID").ToString() %>' />
                                <div style="margin: 10px 0px;" />
                                <asp:RequiredFieldValidator
                                runat="server"
                                ID="rfvNotification"
                                Display="Dynamic"
                                InitialValue=""
                                CssClass="error"
                                ControlToValidate="ddlNotification"
                                ErrorMessage="Selecte a notification" />
                                <div style="margin-bottom: 20px;">&nbsp;</div>
                            </EditItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn
                        HeaderStyle-Width="20px">
                            <ItemTemplate>
                                <idea:LinkButton
                                runat="server"
                                ID="lbEdit"
                                CommandName="Edit"
                                itemid='<%# Eval("ID").ToString() %>'>
                                    <asp:Image
                                    runat="server"
                                    ID="imgEdit"
                                    ToolTip="Edit Subscription"
                                    ImageUrl="~/Images/pencil.png"
                                    Style="border: none;" />
                                </idea:LinkButton>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn
                        HeaderStyle-Width="20px">
                            <ItemTemplate>
                                <idea:LinkButton
                                runat="server"
                                ID="lbDelete"
                                CommandName="Delete"
                                OnClientClick="return confirm('Are you sure you want to delete this record?')"
                                itemid='<%# Eval("ID").ToString() %>'>
                                    <asp:Image
                                    runat="server"
                                    ID="imgDelete"
                                    ToolTip="Delete Subscription"
                                    ImageUrl="~/images/delete.png"
                                    Style="border: none;" />
                                </idea:LinkButton>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                    </Columns>
                    <PagerStyle Mode="NextPrevAndNumeric"  AlwaysVisible="true" Position="Bottom" />
                </MasterTableView>
            </telerik:RadGrid>
        </div>
    </div>
</asp:Content>
