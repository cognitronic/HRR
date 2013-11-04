<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="Goal.aspx.cs" Inherits="HRR.Website.Goal" %>
<%@ MasterType VirtualPath="~/MasterPages/Main.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
    <script language="javascript" type="text/javascript">
         $(document).ready(function () {
             loadProgress(<%= MilestoneProgress %>);
             $("#expander").hover(function () {
                $(this).css('cursor', 'pointer');
             });

             $("#expander").click(function () {

                 $(".collapsibleContainerContent").slideToggle();
                 $(this).toggleClass("acc_triggercollapse acc_triggerexpand");
             });
            });

            function onTabSelected(sender, args)
            {
       	        if(args.get_tab().get_text() == "details")
                {
                    var c = $("#<%= lblProgressText.ClientID %>");
                    var v = c.html().replace('% complete',''); 
                    loadProgress(parseInt(v));
                }
       	    }

       	    function loadProgress(val) { 
                $(".progress").each(function() {
                $(this).progressbar({
                    value: val
                }).children("span").appendTo(this);
            });
            }

           
    </script>
    </telerik:RadScriptBlock>

<telerik:RadAjaxManagerProxy ID="ramp" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="divver">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl UpdatePanelRenderMode="Block" ControlID="divver"  LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server"  Skin="Simple" Transparency="15" />

    <div class="three_fourth last_column">
        <div style="overflow:hidden; margin-right: 10px;">
            <div>
                <h3>
                    <idea:Label
                    runat="server"
                    ID="lblName" />
                </h3>
            </div>
            <hr style="clear: none; margin-top: 0px;" />
        <div runat="server" id="divver">
        <telerik:RadTabStrip 
        runat="server"
        ID="rtsGoal" 
        MultiPageID="rmpGoal"
        SelectedIndex="0"
        OnClientTabSelected="onTabSelected"
        CausesValidation="false"
        Skin="Metro">
        <Tabs>
            <telerik:RadTab runat="server" Value="0" Text="Details">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Value="1" Text="Milestones">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Value="2" Text="Subscribers">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Value="3" Text="Communication">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Value="4" Text="Results">
            </telerik:RadTab>
        </Tabs>
    </telerik:RadTabStrip>
        <telerik:RadMultiPage ID="rmpGoal" runat="server" SelectedIndex="0">
            <telerik:RadPageView ID="pvGoalDetails" runat="server">
                <div class="containerouter">
                    <div class="containerinner">
                        <h3 style="display:inline !important;">Details</h3>
                        <div style="float: right;">
                            <div style="font-weight: bold;">
                                Progress: 
                            </div>
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
                            <div style="font-weight: bold;">
                                Goal's Weight:
                            </div>
                            <telerik:RadNumericTextBox
                            runat="server"
                            ID="tbWeight"
                            ShowSpinButtons="false"
                            NumberFormat-DecimalDigits="0"
                            Width="75px" />
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
                            </div>
                            <%--<div>
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
                            </div><br />--%>
                            <div>
                                <div>Title:</div>
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
                            <div>
                                <div>Description:</div>
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
                            </span>&nbsp;
                           <%-- <span>
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
                            </span>--%>
                            <div style="margin-top: 10px;" runat="server" id="msgContainer">
                            </div>
                        </div>
                    </div>
                </div>
            </telerik:RadPageView>
            <telerik:RadPageView ID="pvMilestones" runat="server">
                <div class="containerouter" id="divMilestones" runat="server">
                    <div class="containerinner">
                        <h3 style="display:inline !important;">Add Milestone</h3>
                        <div>
                            <div>
                                <div>Due Date:</div>
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
                            <div>
                                <div>Title:</div>
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
                            <div>
                                <div>Description:</div>
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
                        <div style="margin: 20px 0px 15px 0px;">
                            <idea:LinkButton
                            runat="server"
                            ValidationGroup="vgNewMilestone"
                            CssClass="button big round sky-blue"
                            ID="lbAddNewMilestone"
                            OnClick="AddMilestoneClicked">
                                Add Milestone
                            </idea:LinkButton>
                        </div>
                    </div>
                </div>
                <div runat="server" id="divMilestoneContainer"/>
                <div style=" margin-top: 5px !important;">
                    <span id="expander" class="acc_triggercollapse" style="padding-top: 2px; color:#333333; ">Click to collapse/expand ALL Milestones</span>
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
                                <div runat="server" id="divTitle" class="collapsibleContainer" 
                    paneltitle="" style="margin-bottom: 5px;">
                      <div class="containerouter">
        <div class="containerinner" style="padding-bottom: 10px;">
            <div style="float: right;">
                <div>
                    <span style="font-weight: bold;">Milestone Completed:</span>
                    <span>
                    <idea:CheckBox
                    Checked='<%# Eval("IsComplete") %>'
                    ID="cbMileStoneCompleted"
                    runat="server" />
                    </span>
                </div>
            </div>
            <div>
                <div>Due Date:</div>
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
            <div>
                <div>Title:</div>
                <idea:TextBox
                runat="server"
                Skin="Metro"
                ID="tbMilestoneTitle"
                Text='<%# Eval("Title") %>'
                Width="690px" />
            </div>
            <div>
                <div>Description:</div>
                <idea:TextBox
                runat="server"
                Skin="Metro"
                TextMode="MultiLine"
                Height="100px"
                Text='<%# Eval("Description") %>'
                ID="tbMilestoneDescription"
                Width="690px" />
            </div>
            <div>
                <div>Self Evaluation:</div>
                <idea:TextBox
                runat="server"
                Skin="Metro"
                TextMode="MultiLine"
                Text='<%# Eval("EmployeeEvaluation") %>'
                Height="100px"
                ID="tbSelfEvaluation"
                Width="690px" />
            </div>
            <div>
                <div>Manager Evaluation:</div>
                <idea:TextBox
                runat="server"
                Skin="Metro"
                TextMode="MultiLine"
                Text='<%# Eval("ManagerEvaluation") %>'
                Height="100px"
                ID="tbManagerEvaluation"
                Width="690px" />
            </div>
            <div style="clear: both; margin-top: 35px; margin-bottom: 25px;">
                <span runat="server" id="spnUpdate">
                    <idea:LinkButton
                    runat="server"
                    itemid='<%# Eval("ID") %>'
                    CommandName="updatems"
                    OnClick="UpdateMilestoneClicked"
                    ValidationGroup="vgMilestones"
                    CausesValidation="false"
                    ID="lbUpdate"
                    CssClass="button big round sky-blue">
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
                    CssClass="button big round sky-blue">
                        Delete
                    </idea:LinkButton>
                </span>&nbsp;
            </div>
        </div>
    </div>
    </div>
                        </ItemTemplate>
                        <FooterTemplate>
                        </FooterTemplate>
                    </asp:DataList>
                </div>
            </telerik:RadPageView>
            <telerik:RadPageView ID="pvManagers" runat="server">
                        <div class="containerouter">
                            <div class="containerinner">
                                <h3 style="display:inline !important;">Subscribers</h3>
    
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
                            <div style="clear: both; margin-top: 35px;">
                                <span>
                                    <asp:LinkButton
                                    runat="server"
                                    ValidationGroup="vgCommunication"
                                    OnClick="SaveCommunicationClicked"
                                    ID="lbSaveComment"
                                    CssClass="button big round sky-blue">
                                        Save Comment
                                    </asp:LinkButton>
                                </span>&nbsp;
                                <span>
                                    <idea:LinkButton
                                    runat="server"
                                    ValidationGroup="vgCommunication"
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
                       <div style="width: 690px; overflow:hidden;" runat="server" id="divContainer">
                            <div style="float: left; margin-right: 5px;">
                            <telerik:RadBinaryImage ID="rbiProfile"
                            runat="server"
                            ResizeMode="Fit"
                                            ImageUrl='<%# HRR.Core.ResourceStrings.AvatarBasePath + "thumb_" + Eval("EnteredByRef.AvatarPath") %>'
                            style="padding: 0px 0px 5px 0px;"/>
                        </div>
                        <div style="float: left;">
                            <table style="width: 635px; padding: 10px 10px 10px 0px;">
                                <tr style="margin-bottom: 30px;">
                                    <td style="background-color: #30a9de; width: 650px; padding: 5px 5px; color: #ffffff; font-weight: bold; height: 20px;">
                                        <div style="float: right;">
                                             <%# DateTime.Parse(Eval("DateCreated").ToString()).ToString()%>
                                        </div>
                                        <div style="float: left;">
                                           <a class="topnavlink" href='/People/<%# Eval("EnteredByRef.Email").ToString() %>' > <%# Eval("EnteredByRef.Name") %></a>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 630px;">
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
        </telerik:RadPageView>
            <telerik:RadPageView ID="pvResults" runat="server">
                <div class="containerouter">
                    <div class="containerinner">
                        <h3 style="display:inline !important;">Results</h3>
                        <div>
                            <div>
                                <span style="font-weight: bold; margin-right: 5px;">
                                    Rate:
                                </span>
                                <div>
                                    <div>How well was this goal's expectations met?</div>
                                    <telerik:RadSlider 
                                    ID="rsQuestion"
                                    Skin="MetroTouch"
                                    Width="300px"
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
                                </div>
                            </div>
                        </div>
                        <div>
                            <div>Manager Evaluation:</div>
                            <idea:TextBox
                            runat="server"
                            ID="tbManagerEvaluation"
                            Skin="Metro"
                            TextMode="MultiLine"
                            Height="100px"
                            Width="690px" />
                        </div>
                        <div>
                            <div>Self Evaluation:</div>
                            <idea:TextBox
                            runat="server"
                            ID="tbSelfEvaluation"
                            Skin="Metro"
                            TextMode="MultiLine"
                            Height="100px"
                            Width="690px" />
                        </div>
                        <div style="clear: both; margin-top: 35px;">
                            <span>
                                <idea:LinkButton
                                runat="server"
                                OnClick="SaveResultsClicked"
                                ID="lbSaveResults"
                                CssClass="button big round sky-blue">
                                    Save Results
                                </idea:LinkButton>
                            </span>&nbsp;
                            <span>
                                <idea:LinkButton
                                runat="server"
                                OnClick="CancelCommentClicked"
                                ID="lbCancelResults"
                                CssClass="button big round sky-blue">
                                    Cancel
                                </idea:LinkButton>
                            </span>
                        </div><br /><br />
                    </div>
                </div>
            </telerik:RadPageView>
    </telerik:RadMultiPage>
        </div>  
        </div>
    </div>
</asp:Content>
