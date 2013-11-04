<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="GroupManagement.aspx.cs" Inherits="HRR.Website.GroupManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<telerik:RadAjaxManagerProxy ID="rampTeams" runat="server" >
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="lbSaveManager">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgManagement" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="lbSaveMember">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgMembers" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server"  Skin="Simple" Transparency="15" />

<div class="three_fourth last_column">
    <img src='/Images/process.png' style="margin-top: 0px;" height="48px" width="48px" border="0" alt="" />
    <h3 style="display:inline !important;">
        <idea:Label
        runat="server"
        ID="lblGroupTitle" />
    </h3>

    <div class="containerouter">
        <div class="containerinner">
            <h3 style="display:inline !important;">Managers</h3>
            
            <div style="margin-bottom: 15px;">
                <span>
                    Add Manager:
                </span>
                <span>
                    <idea:ManagersDDL
                    runat="server"
                    ID="ddlManager" />
                </span>
                <span>
                    <idea:LinkButton
                    runat="server"
                    OnClick="SaveManagerClicked"
                    ValidationGroup="vgManager"
                    ID="lbSaveManager"
                    CssClass="button big round sky-blue">
                        Add Manager
                    </idea:LinkButton>
                </span>
                <div style="margin-top: 10px;">
                    <asp:RequiredFieldValidator
                    runat="server"
                    ID="rfvManager"
                    InitialValue=""
                    Display="Dynamic"
                    CssClass="error"
                    ValidationGroup="vgManager"
                    ControlToValidate="ddlManager"
                    ErrorMessage="Select A Manager" />
                </div>
            </div>

            <div>
                <telerik:RadGrid
                runat="server"
                ID="rgManagement"
                AllowPaging="True"
                AutoGenerateColumns="false"
                AllowSorting="True" 
                OnItemCreated="ManagementItemCreated"
                OnItemCommand="ManagementItemCommand"
                GridLines="None"
                Width="690px" 
                ShowStatusBar="true"
                OnNeedDataSource="ManagementNeedDataSource"
                ShowFooter="true"
                Skin="Metro">
                    <ClientSettings EnableRowHoverStyle="true">
                    </ClientSettings>
                    <MasterTableView 
                    DataKeyNames="ID"
                    ItemStyle-VerticalAlign="Top"
                    AlternatingItemStyle-VerticalAlign="Top"
                    CommandItemDisplay="None"
                    EnableNoRecordsTemplate="true"
                    NoMasterRecordsText="No Management Assigned.">
                        <Columns>
                            <telerik:GridTemplateColumn 
                            DataField="LastName" 
                            HeaderText="Name" 
                            UniqueName="LastName">
                                <ItemTemplate>
                                    <%# Eval("PersonRef.FirstName").ToString() + " " + Eval("PersonRef.LastName").ToString()%>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn 
                            DataField="IsActive" 
                            HeaderText="Is Active" 
                            SortExpression="IsActive"
                            UniqueName="IsActive">
                                <ItemTemplate>
                                    <%# Eval("IsActive").ToString().Equals("True") ? "Yes" : "No"%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <idea:CheckBox
                                    runat="server"
                                    ID="cbIsActive"
                                    Checked='<%# Eval("IsActive") %>' />
                                </EditItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn 
                            DataField="RecievesNotifications" 
                            HeaderText="Receives Notifications" 
                            SortExpression="RecievesNotifications"
                            UniqueName="RecievesNotifications">
                                <ItemTemplate>
                                    <%# Eval("RecievesNotifications").ToString().Equals("True") ? "Yes" : "No"%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <idea:CheckBox
                                    runat="server"
                                    ID="cbRecievesNotifications"
                                    Checked='<%# Eval("RecievesNotifications") %>' />
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
    <br />
    <div class="containerouter">
        <div class="containerinner">
            <h3 style="display:inline !important;">Team Members</h3>
            
            <div style="margin-bottom: 15px;">
                <span>
                    Add Member:
                </span>
                <span>
                    <idea:UsersDDL
                    runat="server"
                    ID="ddlMembers" />
                </span>
                <span>
                    <idea:LinkButton
                    runat="server"
                    ValidationGroup="vgMember"
                    OnClick="SaveMemberClicked"
                    ID="lbSaveMember"
                    CssClass="button big round sky-blue">
                        Add Member
                    </idea:LinkButton>
                </span>
                <div style="margin-top: 10px;">
                    <asp:RequiredFieldValidator
                    runat="server"
                    ID="RequiredFieldValidator1"
                    InitialValue=""
                    Display="Dynamic"
                    CssClass="error"
                    ValidationGroup="vgMember"
                    ControlToValidate="ddlMembers"
                    ErrorMessage="Select A Member" />
                </div>
            </div>

            <div>
                <telerik:RadGrid
                runat="server"
                ID="rgMembers"
                AllowPaging="True"
                AutoGenerateColumns="false"
                AllowSorting="True" 
                OnItemCommand="MemberItemCommand"
                OnItemCreated="MemberItemCreated"
                GridLines="None"
                Width="690px" 
                ShowStatusBar="true"
                OnNeedDataSource="MemberNeedDataSource"
                ShowFooter="true"
                Skin="Metro">
                    <ClientSettings EnableRowHoverStyle="true">
                    </ClientSettings>
                    <MasterTableView 
                    DataKeyNames="ID"
                    ItemStyle-VerticalAlign="Top"
                    AlternatingItemStyle-VerticalAlign="Top"
                    CommandItemDisplay="None"
                    EnableNoRecordsTemplate="true"
                    NoMasterRecordsText="No Members Assigned.">
                        <Columns>
                            <telerik:GridTemplateColumn 
                            DataField="LastName" 
                            HeaderText="Name" 
                            UniqueName="LastName">
                                <ItemTemplate>
                                    <%# Eval("PersonRef.FirstName").ToString() + " " + Eval("PersonRef.LastName").ToString()%>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn 
                            DataField="IsActive" 
                            HeaderText="Is Active" 
                            SortExpression="IsActive"
                            UniqueName="IsActive">
                                <ItemTemplate>
                                    <%# Eval("IsActive").ToString().Equals("True") ? "Yes" : "No"%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <idea:CheckBox
                                    runat="server"
                                    ID="cbIsActive"
                                    Checked='<%# Eval("IsActive") %>' />
                                </EditItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn 
                            DataField="RecievesNotifications" 
                            HeaderText="Receives Notifications" 
                            SortExpression="RecievesNotifications"
                            UniqueName="RecievesNotifications">
                                <ItemTemplate>
                                    <%# Eval("RecievesNotifications").ToString().Equals("True") ? "Yes" : "No"%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <idea:CheckBox
                                    runat="server"
                                    ID="cbRecievesNotifications"
                                    Checked='<%# Eval("RecievesNotifications") %>' />
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
</div>
</asp:Content>
