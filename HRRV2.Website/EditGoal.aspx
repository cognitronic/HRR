<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="EditGoal.aspx.cs" Inherits="HRRV2.Website.EditGoal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
    <script lang="javascript" type="text/javascript">
        $(document).ready(function () {
            loadProgress(<%= MilestoneProgress %>);
             
        });

         function onTabSelected(sender, args) {
             if (args.get_tab().get_text() == "details") {
                 var c = $("#<%= lblProgressText.ClientID %>");
       	            var v = c.html().replace('% complete', '');
       	            loadProgress(parseInt(v));
       	        }
               }

               function loadProgress(val) {
                   $(".progress").each(function () {
                       $(this).progressbar({
                           value: val
                       }).children("span").appendTo(this);
                   });
               }
    </script>

    
    </telerik:RadScriptBlock>

<telerik:RadAjaxManagerProxy ID="ramp" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="lbSave">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl UpdatePanelRenderMode="Block" ControlID="divcontainer"  LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="lbAddNewMilestone">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl UpdatePanelRenderMode="Block" ControlID="dlMilestones"  LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="rgManager">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl UpdatePanelRenderMode="Block" ControlID="rgManager"  LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="lbSaveComment">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl UpdatePanelRenderMode="Block" ControlID="divCommunicationContainer"  LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="lbSaveResults">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl UpdatePanelRenderMode="Block" ControlID="divResultsContainer"  LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnSaveNote">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl UpdatePanelRenderMode="Block" ControlID="dlMilestoneDueDates"  LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server"  Skin="Simple" Transparency="15" />
    <script type="text/javascript">
        setCurrentMenuItem("nav-goals", "");
    </script>
    <div class="semi-block">
        <div class="pull-right" style="margin-top: -10px;">
             <a data-toggle="modal" 
            href="#newNote" 
            class="btn btn-small btn-success" 
            title="Clone Goal">
                <i class="icon-pencil"></i> Clone Goal
            </a>
        </div>
        <h5><i class="icon-th-large"></i>
            <idea:Label
            runat="server"
            ID="lblName" />
        </h5>
        <div runat="server" id="divtabs" class="page-tabs"><!-- fade tabs -->
            <div class="tabbable">
                <ul class="nav nav-tabs">
                    <li class="active">
                        <a href="#tabdetails" data-toggle="tab">
                            <i class="icon-info-sign"></i>
                            Details
                        </a>
                    </li>
                    <li>
                        <a href="#tabmilestones" data-toggle="tab">
                            <i class="icon-file"></i><idea:Label Text="Milestones" runat="server" ID="lblTabMilestone" /></a>
                    </li>
                    <li>
                        <a href="#tabsubscribers" data-toggle="tab">
                            <i class="icon-plane"></i><idea:Label Text="Subscribers" runat="server" ID="lblTabSubscribers" /></a>
                    </li>
                    <li>
                        <a href="#tabcommunication" data-toggle="tab">
                            <i class="icon-pencil"></i><idea:Label Text="Communication" runat="server" ID="lblTabCommunication" /></a>
                    </li>
                    <li>
                        <a href="#tabresults" data-toggle="tab" >
                            <i class="icon-pencil"></i>Results</a>
                    </li>
                    <li runat="server" id="li360">
                        <a href="#tab360" data-toggle="tab" >
                            <i class="icon-pencil"></i>360s</a>
                    </li>
                </ul>
                <div class="tab-content">
                    <div class="tab-pane active fade in" id="tabdetails">
                        <div id="divcontainer" class="row-fluid">
                            <div class="control-group clearfix">
                                <div class="span12">
                                    <label class="control-label">
                                        Progress:
                                    </label>
                                    <div class="controls">
                                        <div id="progressbar" 
                                        class="progress" 
                                        style="margin-left: 0px; 
                                        margin-bottom: 5px; 
                                        width:320px; 
                                        height:2em; ">
                                            <idea:Label
                                                runat="server"
                                                ID="lblProgressText" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="control-group clearfix">
                                <div class="span12">
                                    <label class="control-label">
                                        Goal's Weight: 
                                    </label>
                                    <div class="controls">
                                        <telerik:RadNumericTextBox
                                        runat="server"
                                        ID="tbWeight"
                                        ShowSpinButtons="false"
                                        NumberFormat-DecimalDigits="0"
                                        Width="75px" />
                                    </div>
                                </div>
                            </div>
                            <div class="control-group clearfix">
                                <div class="span12">
                                    <label class="control-label">
                                        Due Date: 
                                        <span>
                                            <idea:LinkButton
                                            runat="server"
                                            ID="lbExportDate"
                                            OnClick="ExportToCalendar">
                                                export to Outlook
                                            </idea:LinkButton>
                                        </span>
                                    </label>
                                    <div class="controls">
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
                                    </div>
                                </div>
                            </div>
                            <div class="control-group clearfix">
                                <div class="span12">
                                    <label class="control-label">
                                        Title: 
                                    </label>
                                    <div class="controls">
                                        <idea:TextBox
                                        runat="server"
                                        ID="tbTitle"
                                        Skin="Metro"
                                        Width="690px" />
                                        <asp:RequiredFieldValidator
                                        runat="server"
                                        ID="RequiredFieldValidator3"
                                        Display="Dynamic"
                                        CssClass="error"
                                        ErrorMessage="<br />Enter title."
                                        InitialValue=""
                                        ControlToValidate="tbTitle" />
                                    </div>
                                </div>
                            </div>
                            <div class="control-group clearfix">
                                <div class="span12">
                                    <label class="control-label">
                                        Description: 
                                    </label>
                                    <div class="controls">
                                        <idea:TextBox
                                        runat="server"
                                        ID="tbDescription"
                                        Skin="Metro"
                                        TextMode="MultiLine"
                                        Height="100px"
                                        Width="690px" />
                                        <asp:RequiredFieldValidator
                                        runat="server"
                                        ID="RequiredFieldValidator4"
                                        Display="Dynamic"
                                        CssClass="error"
                                        ErrorMessage="<br />Enter a description."
                                        InitialValue=""
                                        ControlToValidate="tbDescription" />
                                    </div>
                                </div>
                            </div>
                            <div class="form-actions">
                                <span>
                                    <idea:LinkButton
                                    runat="server"
                                    OnClick="SaveClicked"
                                    ID="lbSaveGoal"
                                    CssClass="btn btn-small btn-info">
                                        Save Goal
                                    </idea:LinkButton>
                                </span>&nbsp;
                                <span>
                                    <idea:LinkButton
                                    runat="server"
                                    OnClick="CancelClicked"
                                    CausesValidation="false"
                                    ID="lbCancel"
                                    CssClass="btn btn-small btn-danger">
                                        Cancel
                                    </idea:LinkButton>
                                </span>
                                <div style="margin-top: 10px;" runat="server" id="msgContainer">
                            </div>
                            </div>
                        </div>
                    </div>
                    <div class="tab-pane fade" id="tabmilestones">
                        <div id="divMilestonesContainer" runat="server" class="row-fluid">
                           <div style="margin-left: 15px;">
                                 <h5>Add New Milestone</h5>
                           </div>
                            <div class="control-group clearfix">
                                <div class="span12">
                                    <label class="control-label">
                                        Due Date:
                                    </label>
                                    <div class="controls">
                                        <telerik:RadDatePicker 
                                        ID="tbMilestoneDueDate"
                                        Skin="Metro"
                                        Height="25px"
                                        width="150px"
                                        runat="server">
                                            <DateInput ID="diMilestoneDueDate" runat="server"
                                                DateFormat="MM/dd/yyyy"></DateInput>
                                        </telerik:RadDatePicker>
                                        <asp:RequiredFieldValidator
                                        runat="server"
                                        ID="rfvMilestonduedate"
                                        Display="Dynamic"
                                        ValidationGroup="vgNewMilestone"
                                        CssClass="error"
                                        ErrorMessage="Select a date."
                                        InitialValue=""
                                        ControlToValidate="tbMilestoneDueDate" />
                                    </div>
                                </div>
                            </div>
                            <div class="control-group clearfix">
                                <div class="span12">
                                    <label class="control-label">
                                        Title:
                                    </label>
                                    <div class="controls">
                                        <idea:TextBox
                                        runat="server"
                                        Skin="Metro"
                                        ID="tbMilestoneTitle"
                                        Width="690px" />
                                        <asp:RequiredFieldValidator
                                        runat="server"
                                        ID="RequiredFieldValidator1"
                                        Display="Dynamic"
                                        ValidationGroup="vgNewMilestone"
                                        CssClass="error"
                                        ErrorMessage="Enter a title."
                                        InitialValue=""
                                        ControlToValidate="tbMilestoneTitle" />
                                    </div>
                                </div>
                            </div>
                            <div class="control-group clearfix">
                                <div class="span12">
                                    <label class="control-label">
                                        Description:
                                    </label>
                                    <div class="controls">
                                        <idea:TextBox
                                        runat="server"
                                        Skin="Metro"
                                        TextMode="MultiLine"
                                        Height="100px"
                                        ID="tbMilestoneDescription"
                                        Width="690px" />
                                        <asp:RequiredFieldValidator
                                        runat="server"
                                        ID="RequiredFieldValidator5"
                                        Display="Dynamic"
                                        ValidationGroup="vgNewMilestone"
                                        CssClass="error"
                                        ErrorMessage="Enter a description."
                                        InitialValue=""
                                        ControlToValidate="tbMilestoneDescription" />
                                    </div>
                                </div>
                            </div>
                             <div class="form-actions">
                                <idea:LinkButton
                                runat="server"
                                ValidationGroup="vgNewMilestone"
                                CssClass="btn btn-small btn-success"
                                ID="lbAddNewMilestone"
                                OnClick="AddMilestoneClicked">
                                    Add Milestone
                                </idea:LinkButton>
                            </div>
                            <div>
                                <asp:DataList
                                runat="server"
                                OnItemCommand="MilestonesItemCommand"
                                OnItemDataBound="MilestonesItemDataBound"
                                Width="100%"
                                ID="dlMilestones">
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <hr class="thickhr" />
                                        <div class="control-group clearfix">    
                                            <div class="span12">
                                                <h5><%# Eval("Title") %></h5>
                                            </div>
                                        </div>
                                        <div class="control-group clearfix">
                                            <div class="span12">
                                                <label class="control-label">
                                                    Milestone Completed:
                                                </label>
                                                <div class="controls">
                                                    <idea:CheckBox
                                                    Checked='<%# Eval("IsComplete") %>'
                                                    ID="cbMileStoneCompleted"
                                                    runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="control-group clearfix">
                                            <div class="span12">
                                                <label class="control-label">
                                                    Due Date:
                                                </label>
                                                <div class="controls">
                                                    <telerik:RadDatePicker 
                                                    ID="tbMilestoneDueDate"
                                                    Skin="Metro"
                                                    Height="25px"
                                                    SelectedDate='<%# Eval("DueDate") %>'
                                                    width="150px"
                                                    runat="server">
                                                        <DateInput ID="diMilestoneDueDate" runat="server"
                                                            DateFormat="MM/dd/yyyy"></DateInput>
                                                    </telerik:RadDatePicker>
                                                    <asp:RequiredFieldValidator
                                                    runat="server"
                                                    ID="rfvMilestonduedate"
                                                    ValidationGroup="vgMilestones"
                                                    Display="Dynamic"
                                                    CssClass="error"
                                                    ErrorMessage="Select a date."
                                                    InitialValue=""
                                                    ControlToValidate="tbMilestoneDueDate" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="control-group clearfix">
                                            <div class="span12">
                                                <label class="control-label">
                                                    Title:
                                                </label>
                                                <div class="controls">
                                                    <idea:TextBox
                                                    runat="server"
                                                    Skin="Metro"
                                                    ID="tbMilestoneTitle"
                                                    Text='<%# Eval("Title") %>'
                                                    Width="690px" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="control-group clearfix">
                                            <div class="span12">
                                                <label class="control-label">
                                                    Description:
                                                </label>
                                                <div class="controls">
                                                    <idea:TextBox
                                                    runat="server"
                                                    Skin="Metro"
                                                    TextMode="MultiLine"
                                                    Height="100px"
                                                    Text='<%# Eval("Description") %>'
                                                    ID="tbMilestoneDescription"
                                                    Width="690px" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="control-group clearfix">
                                            <div class="span12">
                                                <label class="control-label">
                                                    Self Evaluation:
                                                </label>
                                                <div class="controls">
                                                    <idea:TextBox
                                                    runat="server"
                                                    Skin="Metro"
                                                    TextMode="MultiLine"
                                                    Text='<%# Eval("EmployeeEvaluation") %>'
                                                    Height="100px"
                                                    ID="tbSelfEvaluation"
                                                    Width="690px" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="control-group clearfix">
                                            <div class="span12">
                                                <label class="control-label">
                                                    Manager Evaluation:
                                                </label>
                                                <div class="controls">
                                                    <idea:TextBox
                                                    runat="server"
                                                    Skin="Metro"
                                                    TextMode="MultiLine"
                                                    Text='<%# Eval("ManagerEvaluation") %>'
                                                    Height="100px"
                                                    ID="tbManagerEvaluation"
                                                    Width="690px" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-actions">
                                            <span runat="server" id="spnUpdate">
                                                <idea:LinkButton
                                                runat="server"
                                                itemid='<%# Eval("ID") %>'
                                                CommandName="updatems"
                                                OnClick="UpdateMilestoneClicked"
                                                ValidationGroup="vgMilestones"
                                                CausesValidation="false"
                                                ID="lbUpdate"
                                                CssClass="btn btn-small btn-info">
                                                    Update
                                                </idea:LinkButton>
                                            </span>&nbsp;
                                            <span runat="server" id="spnDelete">
                                                <idea:LinkButton
                                                runat="server"
                                                itemid='<%# Eval("ID") %>'
                                                ValidationGroup="vgMilestones"
                                                CommandName="delete"
                                                CausesValidation="false"
                                                OnClientClick="return confirm('Are you sure you want to delete this milestone?')"
                                                ID="lbDeleteMilestone"
                                                CssClass="btn btn-small btn-danger">
                                                    Delete
                                                </idea:LinkButton>
                                            </span>&nbsp;
                                        </div>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                    </FooterTemplate>
                                </asp:DataList>
                            </div>
                        </div>
                    </div>
                    <div class="tab-pane fade" id="tabsubscribers">
                        <div id="divSubscribersContainer" class="row-fluid">
                            <div class="control-group clearfix">
                                <div class="span12">
                                    <telerik:RadGrid
                                    runat="server"
                                    ID="rgManager"
                                    AutoGenerateColumns="false"
                                    AllowSorting="True" 
                                    OnItemCommand="ManagerItemCommand"
                                    OnItemCreated="ManagerItemCreated"
                                    OnItemDataBound="ManagerItemDataBound"
                                    GridLines="None"
                                    OnNeedDataSource="ManagerNeedDataSource"
                                    Skin="Metro">
                                        <ClientSettings EnableRowHoverStyle="true">
                                        </ClientSettings>
                                        <MasterTableView 
                                        DataKeyNames="ID"
                                        ItemStyle-VerticalAlign="Top"
                                        AlternatingItemStyle-VerticalAlign="Top"
                                        CommandItemDisplay="Top"
                                        EnableNoRecordsTemplate="true"
                                        CommandItemSettings-AddNewRecordText="Add Subscriber"
                                        NoMasterRecordsText="No Subscriptions Found.">
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
                                                        <div style="margin: 10px 0px;" />
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
                                                        CssClass="btn btn-small btn-success"
                                                        itemid='<%# Eval("ID").ToString() %>'>
                                                           Edit
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
                                                        CssClass="btn btn-small btn-danger"
                                                        OnClientClick="return confirm('Are you sure you want to delete this record?')"
                                                        itemid='<%# Eval("ID").ToString() %>'>
                                                            Delete
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
                    <div class="tab-pane fade" id="tabcommunication">
                        <div id="divCommunicationContainer" runat="server" class="row-fluid">
                            <div class="control-group clearfix">
                                <div class="span12">
                                    <h5>Post A Comment</h5>
                                    <div class="controls">
                                        <idea:TextBox
                                        runat="server"
                                        ID="tbNewComment"
                                        TextMode="MultiLine"
                                        Height="100px"
                                        Width="690px" />
                                        <asp:RequiredFieldValidator
                                        runat="server"
                                        ID="RequiredFieldValidator6"
                                        Display="Dynamic"
                                        ValidationGroup="vgCommunication"
                                        CssClass="error"
                                        ErrorMessage="Enter a comment."
                                        InitialValue=""
                                        ControlToValidate="tbNewComment" />
                                    </div>
                                </div>
                            </div>
                            <div class="form-actions">
                                <span>
                                    <idea:LinkButton
                                    runat="server"
                                    ValidationGroup="vgCommunication"
                                    OnClick="SaveCommunicationClicked"
                                    ID="lbSaveComment"
                                    CssClass="btn btn-small btn-info">
                                        Save Comment
                                    </idea:LinkButton>
                                </span>&nbsp;
                                <span>
                                    <idea:LinkButton
                                    runat="server"
                                    ValidationGroup="vgCommunication"
                                    OnClick="CancelCommentClicked"
                                    ID="lbCancelComment"
                                    CausesValidation="false"
                                    CssClass="btn btn-small btn-danger">
                                        Cancel
                                    </idea:LinkButton>
                                </span>
                            </div>
                            <div style="margin-left: 15px;">
                                <asp:DataList
                                runat="server"
                                OnItemDataBound="CommentItemDataBound"
                                Width="100%"
                                ID="dlComments">
                                    <HeaderTemplate>
                                        <h5>Comments</h5>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div style="width: 100%; overflow:hidden;" runat="server" id="divContainer">
                                            <div style="float: left; margin-right: 5px;">
                                                <telerik:RadBinaryImage ID="rbiProfile"
                                                runat="server"
                                                ResizeMode="Fit"
                                                ImageUrl='<%# HRR.Core.ResourceStrings.AvatarBasePath + "thumb_" + Eval("EnteredByRef.AvatarPath") %>'
                                                style="padding: 0px 0px 5px 0px;"/>
                                            </div>
                                            <div style="float: left; width: 85%;">
                                                <table style="width: 100%; padding: 10px 10px 10px 0px;">
                                                    <tr style="margin-bottom: 30px;">
                                                        <td style="background-color: #30a9de; width: 100%; padding: 5px 5px; color: #ffffff; font-weight: bold; height: 20px;">
                                                            <div style="float: right;">
                                                                    <%# DateTime.Parse(Eval("DateCreated").ToString()).ToString()%>
                                                            </div>
                                                            <div style="float: left;">
                                                                <a class="topnavlink" href='/People/<%# Eval("EnteredByRef.Email").ToString() %>' > <%# Eval("EnteredByRef.Name") %></a>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%;">
                                                            <div style="margin-left: 10px;">
                                                                <%# Eval("Message") %>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
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
                    <div class="tab-pane fade" id="tabresults">
                        <div id="divResultsContainer" class="row-fluid">
                            <div class="control-group clearfix">
                                <div class="span12">
                                    <label class="control-label">
                                        Rate:
                                    </label>
                                    <div>How well was this goal's expectations met?</div>
                                        <telerik:RadSlider 
                                        ID="rsQuestion"
                                        Skin="MetroTouch"
                                        Width="400px"
                                        ItemType="Item"
                                        Height="50px"
                                        itemid='<%# Eval("ID").ToString() %>'
                                        TrackPosition="TopLeft"
                                        runat="server">
                                        <Items>
                                            <telerik:RadSliderItem Text="Below" Value="0" />
                                            <telerik:RadSliderItem Text="Meets" Value="50" />
                                            <telerik:RadSliderItem Text="Exceeds" Value="100" />
                                        </Items>
                                        </telerik:RadSlider>
                                    <div class="controls">
                                        
                                    </div>
                                </div>
                            </div>
                            <div class="control-group clearfix">
                                <div class="span12">
                                    <label class="control-label">
                                        Manager Evaluation:
                                    </label>
                                    <div class="controls">
                                        <idea:TextBox
                                        runat="server"
                                        ID="tbManagerEvaluation"
                                        Skin="Metro"
                                        TextMode="MultiLine"
                                        Height="100px"
                                        Width="690px" />
                                    </div>
                                </div>
                            </div>
                            <div class="control-group clearfix">
                                <div class="span12">
                                    <label class="control-label">
                                        Self Evaluation:
                                    </label>
                                    <div class="controls">
                                        <idea:TextBox
                                        runat="server"
                                        ID="tbSelfEvaluation"
                                        Skin="Metro"
                                        TextMode="MultiLine"
                                        Height="100px"
                                        Width="690px" />
                                    </div>
                                </div>
                            </div>
                            <div class="form-actions">
                                <span>
                                    <idea:LinkButton
                                    runat="server"
                                    OnClick="SaveResultsClicked"
                                    ID="lbSaveResults"
                                    CssClass="btn btn-small btn-info">
                                        Save Comment
                                    </idea:LinkButton>
                                </span>&nbsp;
                                <span>
                                    <idea:LinkButton
                                     runat="server"
                                     OnClick="CancelCommentClicked"
                                     ID="lbCancelResults"
                                     CausesValidation="false"
                                    CssClass="btn btn-small btn-danger">
                                        Cancel
                                    </idea:LinkButton>
                                </span>
                            </div>
                        </div>
                    </div>
                    <div class="tab-pane fade" id="tab360">
                        <div id="div360Container" class="row-fluid">
                            
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="newNote" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myNoteLabel" aria-hidden="true">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h5 id="myNoteLabel"><i class="icon-heart"></i>Clone Goal</h5>
                </div>
                <div class="modal-body">
                <div id="div4" class="row-fluid">
                    <div class="control-group clearfix">
                            <div class="span12">
                                <label class="control-label">
                                    Select An Employee Or A Team:
                                </label>
                                <div class="controls ui-widget">
                                    <telerik:RadAutoCompleteBox
                                    runat="server"
                                    ID="note_name"
                                    DataTextField="Name"
                                    DataValueField="ID"
                                    Width="400px"
                                    DropDownHeight="400"
                                    DropDownWidth="375"
                                    Skin="Metro">
                                        <DropDownItemTemplate>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td align="left" style="width: 50px; padding-left: 10px; padding-bottom: 10px;">
                                                        <telerik:RadBinaryImage
                                                        ID="feedback_profilepic"
                                                        runat="server"
                                                        AlternateText="Profile Photo"
                                                        ToolTip="Profile Photo"
                                                        Height="50px"
                                                        Width="50px"
                                                        ResizeMode="Fit"
                                                        ImageUrl='<%#  DataBinder.Eval(Container.DataItem, "AvatarPath").ToString().StartsWith("http://") ? DataBinder.Eval(Container.DataItem, "AvatarPath").ToString() + "50" : HRR.Core.ResourceStrings.AvatarBasePath  + DataBinder.Eval(Container.DataItem, "AvatarPath") %>' />
                                                    </td>
                                                    <td align="left" style="width: 430px; padding-left: 10px; vertical-align: top;">
                                                        <span style="color: #000000; font-weight: bold;">Name:
                                                        </span>
                                                        <%# DataBinder.Eval(Container.DataItem, "Email").ToString().StartsWith("team:") ? DataBinder.Eval(Container.DataItem, "Name").ToString() + "<span style='font-weight: bold;'> - TEAM</span>" : DataBinder.Eval(Container.DataItem, "Name") %>
                                                            </span>
                                                            <br />
                                                        <span style="color: #000000; font-weight: bold;">Department:
                                                        </span>
                                                        <%# DataBinder.Eval(Container.DataItem, "DepartmentName")%>
                                                            </span>
                                                            <br />
                                                        <span style="color: #000000; font-weight: bold;">Title:
                                                        </span>
                                                        <%# DataBinder.Eval(Container.DataItem, "Title")%>
                                                            </span>
                                                    </td>
                                                </tr>
                                            </table>
                                        </DropDownItemTemplate>
                                    </telerik:RadAutoCompleteBox>
                                </div>
                            </div>
                        </div>
                        <div class="control-group clearfix">
                            <div class="span12">
                                <label class="control-label">
                                    Goal Due Date: 
                                </label>
                                <div class="controls">
                                    <telerik:RadDatePicker 
                                    ID="tbCloneGoalDueDate"
                                    Skin="Metro"
                                    Height="25px"
                                    width="150px"
                                    runat="server">
                                        <DateInput ID="diCloneGoalDueDate" runat="server"
                                            DateFormat="MM/dd/yyyy"></DateInput>
                                    </telerik:RadDatePicker>
                            
                                    <asp:RequiredFieldValidator
                                    runat="server"
                                    ID="RequiredFieldValidator7"
                                    Display="Dynamic"
                                    CssClass="error"
                                    ErrorMessage="Select a date."
                                    InitialValue=""
                                    ControlToValidate="tbCloneGoalDueDate" />
                                </div>
                            </div>
                        </div>
                        <div class="control-group clearfix">
                            <div class="span12">
                                <div class="controls">
                                    <asp:DataList
                                    runat="server"
                                    OnItemDataBound="MilestoneDueDatesItemDataBound"
                                    Width="100%"
                                    ID="dlMilestoneDueDates">
                                        <HeaderTemplate>
                                            <h5>Milestone Due Dates</h5>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div>
                                                <%# Eval("Title") %>
                                            </div>
                                            <div>
                                                <telerik:RadDatePicker 
                                                ID="tbDueDate"
                                                Skin="Metro"
                                                Height="25px"
                                                milestoneid='<%# Eval("ID") %>'
                                                width="150px"
                                                runat="server">
                                                    <DateInput ID="diDueDate" runat="server"
                                                        DateFormat="MM/dd/yyyy"></DateInput>
                                                </telerik:RadDatePicker>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                    </asp:DataList>
                                </div>
                            </div>
                        </div>
                        <div class="form-actions modal-footer">
                            <idea:LinkButton 
                            id="btnSaveNote"
                            runat="server"
                            OnClick="SaveCloneGoalClicked" 
                            Text="Assign Goal" 
                            CssClass="btn btn-small btn-success">
                                <i class="icon-plus"></i> Save 
                            </idea:LinkButton>
                            <a href='' title="Cancel" data-dismiss="modal" class="btn btn-small btn-danger">
                                <i class="icon-remove"></i> Cancel
                            </a>               
                        </div>
                    </div>
                </div>
            </div>

</asp:Content>
