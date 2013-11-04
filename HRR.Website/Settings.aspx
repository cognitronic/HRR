<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="HRR.Website.Settings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<telerik:RadAjaxManagerProxy ID="rampComments" runat="server" >
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="rtsSettings">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rmpSettings" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="rtsSettings">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rtsSettings"/>
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="lbSaveAccount">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="divProfile" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server"  Skin="Simple" Transparency="15" />
    <div class="three_fourth last_column">
        <img src='/Images/process.png' style="margin-top: 0px;" height="48px" width="48px" border="0" alt="" /><h3 style="display:inline !important;">Application Settings</h3>
        <div>
            <telerik:RadTabStrip runat="server"
             ID="rtsSettings" 
             OnTabClick="TabClicked" 
             MultiPageID="rmpSettings" 
             SelectedIndex="0"
             Skin="Metro">
                <Tabs>
                    <%--<telerik:RadTab runat="server" Text="Company Profile">
                    </telerik:RadTab>--%>
                    <telerik:RadTab runat="server" Text="Teams">
                    </telerik:RadTab>
                    <telerik:RadTab runat="server" Text="Account Profile">
                    </telerik:RadTab>
                    <telerik:RadTab runat="server" Text="Managed Lists">
                    </telerik:RadTab>
                    <telerik:RadTab runat="server" Text="Notifications">
                    </telerik:RadTab>
                </Tabs>
            </telerik:RadTabStrip>
            <telerik:RadMultiPage ID="rmpSettings" runat="server" SelectedIndex="0">
                <telerik:RadPageView ID="pvManageTeams" runat="server">
                    <br />
                    <div class="containerouter">
                        <div class="containerinner">
                            <h3 style="display:inline !important;">Teams</h3>
    
                            <div>
                                <telerik:RadGrid
                                runat="server"
                                ID="rgGroups"
                                AllowPaging="True"
                                AutoGenerateColumns="false"
                                AllowSorting="True"
                                OnItemCreated="GroupsItemCreated" 
                                OnItemCommand="GroupsItemCommand"
                                GridLines="None"
                                Width="690px" 
                                ShowStatusBar="true"
                                OnNeedDataSource="GroupsNeedDataSource"
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
                                    CommandItemSettings-AddNewRecordText="Add New Team"
                                    NoMasterRecordsText="No Teams Found.">
                                        <Columns>
                                            <telerik:GridTemplateColumn 
                                            DataField="Name" 
                                            HeaderText="Name" 
                                            UniqueName="Name">
                                                <ItemTemplate>
                                                    <%# Eval("Name")%>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <idea:TextBox
                                                    runat="server"
                                                    ID="tbName"
                                                    Text='<%# Eval("Name")%>'
                                                    Width="480px" />
                                                    <div style="margin: 10px 0px;" />
                                                </EditItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn 
                                            DataField="Description" 
                                            HeaderText="Description" 
                                            SortExpression="Description"
                                            UniqueName="Description">
                                                <ItemTemplate>
                                                    <%#Eval("Description")%>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <idea:TextBox
                                                    runat="server"
                                                    ID="tbDescription"
                                                    TextMode="MultiLine"
                                                    Height="75px"
                                                    Text='<%# Eval("Description") %>'
                                                    Width="480px" />
                                                    <div style="margin: 10px 0px;" />
                                                </EditItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn 
                                            DataField="Members.Count" 
                                            HeaderStyle-Width="100px"
                                            HeaderText="# of Members" 
                                            SortExpression="Members.Count"
                                            UniqueName="Members.Count">
                                                <ItemTemplate>
                                                    <%#Eval("Members.Count")%>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn
                                            HeaderStyle-Width="20px">
                                                <ItemTemplate>
                                                    <idea:LinkButton
                                                    runat="server"
                                                    ID="lbMembers"
                                                    OnClick="AddMemberClicked"
                                                    itemname='<%# Eval("Name").ToString() %>'
                                                    itemid='<%# Eval("ID").ToString() %>'>
                                                        <asp:Image
                                                        runat="server"
                                                        ID="imgMembers"
                                                        ToolTip="Manage Group Members"
                                                        ImageUrl="~/Images/edit_profile.png"
                                                        Style="border: none;" />
                                                    </idea:LinkButton>
                                                </ItemTemplate>
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
                                                        ToolTip="Edit Group"
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
                                                        ToolTip="Delete Group"
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
                    </div>
                </telerik:RadPageView>
                <telerik:RadPageView ID="pvCompanyProfile" runat="server">
                <br />

                    <div runat="server" id="divProfile" class="containerouter">
                        <div class="containerinner">
                            <div style="margin-top: 15px;">
                                <div>Company Name:</div>
                                <idea:TextBox
                                runat="server"
                                ID="tbCompanyName"
                                Width="500"
                                Skin="Metro" />
                                <div style="margin: 5px 0px;">
                                    <asp:RequiredFieldValidator
                                    runat="server"
                                    ID="rfvManager"
                                    InitialValue=""
                                    Display="Dynamic"
                                    CssClass="error"
                                    ValidationGroup="vgProfile"
                                    ControlToValidate="tbCompanyName"
                                    ErrorMessage="Enter Company Name" />
                                </div>
                            </div>
                            <div style="">
                                <div>Domain Name:</div>
                                <idea:TextBox
                                runat="server"
                                ID="tbDomain"
                                Width="500"
                                Skin="Metro" />
                                <div style="margin-top: 10px;">
                                    <asp:RequiredFieldValidator
                                    runat="server"
                                    ID="RequiredFieldValidator1"
                                    InitialValue=""
                                    Display="Dynamic"
                                    CssClass="error"
                                    ValidationGroup="vgProfile"
                                    ControlToValidate="tbDomain"
                                    ErrorMessage="Enter Company Domain" />
                                </div>
                            </div>
                            <div style="">
                                <telerik:RadBinaryImage ID="rbiProfile"
                                runat="server"
                                Width="250px"
                                AutoAdjustImageControlSize="true"
                                Height="150px"
                                style="padding: 0px 0px 5px 0px;"/>
                                <div>Logo Path:</div>
                                <telerik:RadAsyncUpload 
                                runat="server" 
                                ID="radAsyncUpload" 
                                AllowedFileExtensions="jpg,jpeg,png,gif"
                                MaxFileSize="1048576"
                                ResizeMode="crop"
                                OnValidatingFile="RadAsyncUpload1_ValidatingFile">
                                </telerik:RadAsyncUpload>
                            </div>
                            <div>
                                <h5>Review Weights</h5>
                                <div>
                                    <div>Goals:</div>
                                    <telerik:RadNumericTextBox
                                    runat="server"
                                    ShowSpinButtons="false"
                                    NumberFormat-DecimalDigits="0"
                                    ID="tbGoalsWeight"/>
                                </div>
                                <div>
                                    <div>Comments:</div>
                                    <telerik:RadNumericTextBox
                                    runat="server"
                                    ShowSpinButtons="false"
                                    NumberFormat-DecimalDigits="0"
                                    ID="tbCommentsWeight"/>
                                </div>
                                <div>
                                    <div>Questions:</div>
                                    <telerik:RadNumericTextBox
                                    runat="server"
                                    ShowSpinButtons="false"
                                    NumberFormat-DecimalDigits="0"
                                    ID="tbQuestionsWeight"/>
                                </div>
                            </div>
                            <div style="height: 100px; margin-top: 30px;">
                                <span>
                                    <idea:LinkButton
                                    runat="server"
                                    ValidationGroup="vgProfile"
                                    OnClick="SaveAccountClicked"
                                    ID="lbSaveAccount"
                                    CssClass="button big round sky-blue">
                                        Save
                                    </idea:LinkButton>
                                </span>&nbsp;
                                <span>
                                    <idea:LinkButton
                                    runat="server"
                                    OnClick="CancelAccountClicked"
                                    CausesValidation="false"
                                    ID="lbCancelAccount"
                                    CssClass="button big round sky-blue">
                                        Cancel
                                    </idea:LinkButton>
                                </span>
                            </div>
                        </div>
                    </div>
                </telerik:RadPageView>
                <telerik:RadPageView ID="pvManagedLists" runat="server">
                    <br />
                    <div class="containerouter">
                        <div class="containerinner">
                            <h3 style="display:inline !important;">Departments</h3>
                            <div>
                            <telerik:RadGrid
                        runat="server"
                        ID="rgDepartment"
                        AllowPaging="True"
                        AutoGenerateColumns="false"
                        AllowSorting="True" 
                        OnItemCommand="ItemCommand"
                        OnItemCreated="DepartmentItemCreated"
                        GridLines="None"
                        Width="690px" 
                        ShowStatusBar="true"
                        OnNeedDataSource="NeedDataSource"
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
                            CommandItemSettings-AddNewRecordText="Add New Department"
                            NoMasterRecordsText="No Departments Found.">
                                <Columns>
                                    <telerik:GridTemplateColumn 
                                    DataField="Name" 
                                    HeaderText="Name" 
                                    UniqueName="Name">
                                        <ItemTemplate>
                                            <%# Eval("Name")%>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <idea:TextBox
                                            runat="server"
                                            ID="tbName"
                                            Text='<%# Eval("Name")%>'
                                            Width="480px" />
                                            <div style="margin: 10px 0px;" />
                                            <asp:RequiredFieldValidator
                                            runat="server"
                                            ID="sdfsdf"
                                            Display="Dynamic"
                                            InitialValue=""
                                            CssClass="error"
                                            ControlToValidate="tbName"
                                            ErrorMessage="Enter Department Name" />
                                        </EditItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn 
                                    DataField="Description" 
                                    HeaderText="Description" 
                                    SortExpression="Description"
                                    UniqueName="Description">
                                        <ItemTemplate>
                                            <%#Eval("Description")%>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <idea:TextBox
                                            runat="server"
                                            ID="tbDescription"
                                            TextMode="MultiLine"
                                            Height="75px"
                                            Text='<%# Eval("Description") %>'
                                            Width="480px" />
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
                                                ToolTip="Edit Department"
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
                                                ToolTip="Delete Delete"
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
                    </div>
                    <br />

                    <div class="containerouter">
                        <div class="containerinner">
                            <h3 style="display:inline !important;">Comment Categories</h3>
    
                            <div>
                        <telerik:RadGrid
                        runat="server"
                        ID="rgCommentCategories"
                        AllowPaging="True"
                        AutoGenerateColumns="false"
                        AllowSorting="True" 
                        OnItemCommand="CommentItemCommand"
                        OnItemCreated="CommentItemCreated"
                        GridLines="None"
                        Width="690px" 
                        ShowStatusBar="true"
                        OnNeedDataSource="CommentNeedDataSource"
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
                            CommandItemSettings-AddNewRecordText="Add New Comment Category"
                            NoMasterRecordsText="No Comment Categories Found.">
                                <Columns>
                                    <telerik:GridTemplateColumn 
                                    DataField="Name" 
                                    HeaderText="Name" 
                                    UniqueName="Name">
                                        <ItemTemplate>
                                            <%# Eval("Name")%>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <idea:TextBox
                                            runat="server"
                                            ID="tbName"
                                            Text='<%# Eval("Name")%>'
                                            Width="480px" />
                                            <div style="margin: 10px 0px;" />
                                            <asp:RequiredFieldValidator
                                            runat="server"
                                            ID="sdf"
                                            InitialValue=""
                                            Display="Dynamic"
                                            CssClass="error"
                                            ControlToValidate="tbName"
                                            ErrorMessage="Enter Category Name" />
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
                                                ToolTip="Edit Category"
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
                                                ToolTip="Delete Category"
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
                    </div>
                </telerik:RadPageView>
                <telerik:RadPageView ID="RadPageView1" runat="server">
                    <br />
                    <div class="containerouter">
                        <div class="containerinner">
                            <h3 style="display:inline !important;">Notification Subscriptions</h3>
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
                                Width="690px" 
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
                    </div>
                    <br />
                </telerik:RadPageView>
            </telerik:RadMultiPage>
        </div>
    </div>
</asp:Content>
