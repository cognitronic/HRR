<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="Goal.aspx.cs" Inherits="HRR.Website.Goal" %>
<%@ MasterType VirtualPath="~/MasterPages/Main.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<telerik:RadAjaxManagerProxy ID="ramp" runat="server" >
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="rgMilestones">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgMilestones" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="rgManager">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgManager" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="lbSaveComment">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="divCommunication"  LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server"  Skin="Simple" Transparency="15" />

    <div class="three_fourth last_column">
    <div style="overflow:auto; margin-right: 10px;">
            <div>
                <h3>
                    <idea:Label
                    runat="server"
                    ID="lblName" />
                </h3>
            </div>
                <hr style="clear: none; margin-top: -5px;" />
        </div>
        <div>
    <telerik:RadTabStrip runat="server"
        ID="rtsGoal" 
        MultiPageID="rmpGoal"
        SelectedIndex="0"
        Skin="Metro">
        <Tabs>
            <telerik:RadTab runat="server" Value="0" Text="Details">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Value="1" Text="Managers">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Value="2" Text="Milestones">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Value="3" Text="Communication">
            </telerik:RadTab>
        </Tabs>
    </telerik:RadTabStrip>
    <telerik:RadMultiPage ID="rmpGoal" runat="server" SelectedIndex="0">
        <telerik:RadPageView ID="pvGoalDetails" runat="server">
            <div class="containerouter">
                <div class="containerinner">
                    <h3 style="display:inline !important;">Details</h3>
                    <div style="clear: both; margin-top: 0px; margin-bottom: 0px;">
                        <span>
                            <idea:LinkButton
                            runat="server"
                            OnClick="ApproveClicked"
                            ID="lbApprove"
                            CssClass="button big round sky-blue">
                                Approve
                            </idea:LinkButton>
                        </span>&nbsp;
                        <span>
                            <idea:LinkButton
                            runat="server"
                            OnClick="AcceptClicked"
                            ID="lbAccept"
                            CssClass="button big round sky-blue">
                                Accept
                            </idea:LinkButton>
                        </span>
                    </div>
                    <div>
                        <div>
                            <div>
                                Due Date: 
                                <span>
                                    <idea:LinkButton
                                    runat="server"
                                    ID="lbExportDate"
                                    OnClick="ExportToCalendar">
                                        export to Outlook
                                    </idea:LinkButton>
                                </span>
                            </div>
                            <telerik:RadDatePicker 
                            ID="tbDueDate"
                            Skin="Metro"
                            Height="25px"
                            width="150px"
                            runat="server">
                                <DateInput ID="diDueDate" runat="server"
                                    DateFormat="MM/dd/yyyy"></DateInput>
                            </telerik:RadDatePicker>
                            
                            <asp:RequiredFieldValidator
                            runat="server"
                            ID="RequiredFieldValidator2"
                            Display="Dynamic"
                            CssClass="error"
                            ErrorMessage="Select a date."
                            InitialValue=""
                            ControlToValidate="tbDueDate" />
                        </div><br />
                        <div>
                            <div>Title:</div>
                            <idea:TextBox
                            runat="server"
                            ID="tbTitle"
                            Skin="Metro"
                            Width="600px" />
                            <asp:RequiredFieldValidator
                            runat="server"
                            ID="RequiredFieldValidator3"
                            Display="Dynamic"
                            CssClass="error"
                            ErrorMessage="<br />Enter title."
                            InitialValue=""
                            ControlToValidate="tbTitle" />
                        </div>
                        <div>
                            <div>Description:</div>
                            <idea:TextBox
                            runat="server"
                            ID="tbDescription"
                            Skin="Metro"
                            TextMode="MultiLine"
                            Height="100px"
                            Width="600px" />
                            <asp:RequiredFieldValidator
                            runat="server"
                            ID="RequiredFieldValidator4"
                            Display="Dynamic"
                            CssClass="error"
                            ErrorMessage="<br />Enter a description."
                            InitialValue=""
                            ControlToValidate="tbDescription" />
                        </div>
                        <div>
                            <div>Type:</div>
                            <idea:GoalTypeDDL
                            runat="server"
                            ID="ddlType" />
                            <asp:RequiredFieldValidator
                            runat="server"
                            ID="RequiredFieldValidator5"
                            Display="Dynamic"
                            CssClass="error"
                            ErrorMessage="Select a goal type."
                            InitialValue=""
                            ControlToValidate="ddlType" />
                        </div>
                        <div>
                            <div>Status:</div>
                            <idea:GoalStatusDDL
                            runat="server"
                            ID="ddlStatus" />
                            <asp:RequiredFieldValidator
                            runat="server"
                            ID="RequiredFieldValidator6"
                            Display="Dynamic"
                            CssClass="error"
                            ErrorMessage="Select a status."
                            InitialValue=""
                            ControlToValidate="ddlStatus" />
                        </div>
                    </div>
                    <br /><br />
                    <div style="clear: both; margin-top: 35px; margin-bottom: 25px;">
                        <span>
                            <idea:LinkButton
                            runat="server"
                            OnClick="SaveClicked"
                            ID="lbSave"
                            CssClass="button big round sky-blue">
                                Save Goal
                            </idea:LinkButton>
                        </span>&nbsp;
                        <span>
                            <idea:LinkButton
                            runat="server"
                            OnClick="CancelClicked"
                            CausesValidation="false"
                            ID="lbCancel"
                            CssClass="button big round sky-blue">
                                Cancel
                            </idea:LinkButton>
                        </span>
                        <div style="margin-top: 10px;" runat="server" id="msgContainer">
                        </div>
                    </div>
                </div>
            </div>
        </telerik:RadPageView>
        <telerik:RadPageView ID="pvManagers" runat="server">
                        <div class="containerouter">
                            <div class="containerinner">
                                <h3 style="display:inline !important;">Managers</h3>
    
                                <div>
                            <telerik:RadGrid
                            runat="server"
                            ID="rgManager"
                            AllowPaging="True"
                            AutoGenerateColumns="false"
                            AllowSorting="True" 
                            OnItemCommand="ManagerItemCommand"
                            OnItemCreated="ManagerItemCreated"
                            OnItemDataBound="ManagerItemDataBound"
                            GridLines="None"
                            Width="690px" 
                            ShowStatusBar="true"
                            OnNeedDataSource="ManagerNeedDataSource"
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
                                CommandItemSettings-AddNewRecordText="Add Manager"
                                NoMasterRecordsText="No Managers Found.">
                                    <Columns>
                                        <telerik:GridTemplateColumn 
                                        DataField="PersonRef.LastName" 
                                        HeaderText="Name" 
                                        UniqueName="PersonRef.LastName">
                                            <ItemTemplate>
                                                <%# Eval("PersonRef.FirstName").ToString() + " " + Eval("PersonRef.LastName").ToString() %>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <idea:ManagersDDL
                                                runat="server"
                                                ID="ddlPerson"
                                                personid='<%# Eval("ID")%>'/>
                                            </EditItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn 
                                        DataField="RecievesNotifications" 
                                        HeaderText="Receives Notifications" 
                                        SortExpression="RecievesNotifications"
                                        UniqueName="RecievesNotifications">
                                            <ItemTemplate>
                                                <%#Eval("RecievesNotifications")%>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <idea:CheckBox
                                                runat="server"
                                                ID="cbRecievesNotifications"
                                                Checked='<%#  (DataBinder.Eval(Container.DataItem,"RecievesNotifications") is DBNull ?false:Eval("RecievesNotifications")) %>' />
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
                                                    ToolTip="Edit Manager"
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
                                                    ToolTip="Delete Manager"
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
        <telerik:RadPageView ID="pvMilestones" runat="server">
                <div class="containerouter" id="divMilestones" runat="server">
                    <div class="containerinner">
                        <h3 style="display:inline !important;">Milestones</h3>
    
                        <div>
                    <telerik:RadGrid
                    runat="server"
                    ID="rgMilestones"
                    AllowPaging="True"
                    AutoGenerateColumns="false"
                    AllowSorting="True" 
                    OnItemCommand="ItemCommand"
                    OnItemDataBound="ItemDataBound"
                    OnItemCreated="MilestonesItemCreated"
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
                        CommandItemSettings-AddNewRecordText="Add New Milestone"
                        NoMasterRecordsText="No Questions Found.">
                            <Columns>
                                <telerik:GridTemplateColumn 
                                DataField="Title" 
                                HeaderText="Title" 
                                UniqueName="Title">
                                    <ItemTemplate>
                                        <%# Eval("Title") %>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <idea:TextBox
                                        runat="server"
                                        ID="tbTitle"
                                        Text='<%# DataBinder.Eval(Container.DataItem, "Title") %>'
                                        Width="480px" />
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
                                    </EditItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn 
                                DataField="DueDate" 
                                HeaderText="Due Date" 
                                SortExpression="DueDate"
                                UniqueName="DueDate">
                                    <ItemTemplate>
                                        <%# DateTime.Parse(Eval("DueDate").ToString()).ToShortDateString()%>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <telerik:RadDatePicker 
                                        ID="tbMilestoneDueDate"
                                        Skin="Metro"
                                        Height="25px"
                                        width="150px"
                                        DbSelectedDate='<%# Bind("DueDate") %>'
                                        runat="server">
                                            <DateInput ID="diMilestoneDueDate" runat="server"
                                                DateFormat="MM/dd/yyyy"></DateInput>
                                        </telerik:RadDatePicker>
                                        <asp:RequiredFieldValidator
                                        runat="server"
                                        ID="RequiredFieldValidator1"
                                        Display="Dynamic"
                                        CssClass="alert"
                                        ErrorMessage="Select a date."
                                        InitialValue=""
                                        ControlToValidate="tbMilestoneDueDate" />
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
                                            ToolTip="Edit Question"
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
                                            ToolTip="Delete Question"
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
        <telerik:RadPageView ID="pvCommunication" runat="server">
                <div class="containerouter" id="divCommunication" runat="server">
                    <div class="containerinner">
                        <h3 style="display:inline !important;">Post A Comment</h3>
                        <div>
                            <div>
                                <idea:TextBox
                                runat="server"
                                ID="tbNewComment"
                                TextMode="MultiLine"
                                Height="100px"
                                Width="690px" />
                            </div>
                        </div>
                        <div style="clear: both; margin-top: 35px;">
                            <span>
                                <idea:LinkButton
                                runat="server"
                                OnClick="SaveCommentClicked"
                                ID="lbSaveComment"
                                CssClass="button big round sky-blue">
                                    Save Comment
                                </idea:LinkButton>
                            </span>&nbsp;
                            <span>
                                <idea:LinkButton
                                runat="server"
                                OnClick="CancelCommentClicked"
                                ID="lbCancelComment"
                                CssClass="button big round sky-blue">
                                    Cancel
                                </idea:LinkButton>
                            </span>
                        </div><br /><br />
                    </div>
                </div>
                <br />
                        <div>
                            <asp:DataList
                            runat="server"
                            OnItemDataBound="CommentItemDataBound"
                            ID="dlComments">
                                <HeaderTemplate>
                                    <h3>Comments</h3>
                                </HeaderTemplate>
                                <ItemTemplate>
                                        <div class="containerouter">
                    <div class="containerinner">
                       <div style="width: 705px; overflow:hidden;" runat="server" id="divContainer">
                            <div style="float: left; margin-right: 5px;">
                            <telerik:RadBinaryImage ID="rbiProfile"
                            runat="server"
                            Width="50px"
                            Height="50px"
                            ImageUrl='<%# Eval("EnteredByRef.AvatarPath") %>'
                            AutoAdjustImageControlSize="true"
                            style="padding: 0px 0px 5px 0px;"/>
                        </div>
                        <div style="float: left;">
                            <table style="width: 650px; padding: 10px 10px 10px 0px;">
                                <tr style="margin-bottom: 30px;">
                                    <td style="background-color: #30a9de; width: 650px; padding: 5px 5px; color: #ffffff; font-weight: bold; height: 20px;">
                                        <div style="float: right;">
                                             <%# DateTime.Parse(Eval("DateCreated").ToString()).ToShortDateString() %>
                                        </div>
                                        <div style="float: left;">
                                           <a class="topnavlink" href='/People/<%# Eval("EnteredByRef.Email").ToString() %>' > <%# Eval("EnteredByRef.Name") %></a>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 645px;">
                                        <div style="margin-left: 10px;">
                                            <%# Eval("Message") %>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                       </div>
                    </div>
                </div>
                <br />
                                </ItemTemplate>
                                <FooterTemplate>
                                </FooterTemplate>
                            </asp:DataList>
                        </div>
                    </div>
                </div>
        </telerik:RadPageView>
    </telerik:RadMultiPage>
        </div>  
    </div>
</asp:Content>
