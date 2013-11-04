<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="Review.aspx.cs" Inherits="HRR.Website.Review" %>
<%@ Register TagPrefix="idea" TagName="GoalListView" Src="~/Views/ReviewGoalListView.ascx" %>
<%@ Register TagPrefix="idea" TagName="CommentListView" Src="~/Views/CommentListView.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<telerik:RadAjaxManagerProxy ID="ramp" runat="server" >
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="rgManager">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgManager" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="rgNotes">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgNotes" LoadingPanelID="RadAjaxLoadingPanel1" />
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
    <telerik:RadTabStrip runat="server"
        ID="rtsReview" 
        MultiPageID="rmpReview" 
        SelectedIndex="0"
        Skin="Metro">
        <Tabs>
            <telerik:RadTab runat="server" Value="0" Text="Review Details">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Value="1" Text="Managers">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Value="2" Text="Questions">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Value="3" Text="Goals">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Value="4" Text="Comments">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Value="5" Text="Notes">
            </telerik:RadTab>
        </Tabs>
    </telerik:RadTabStrip>
    <telerik:RadMultiPage ID="rmpReview" runat="server" SelectedIndex="0">
        <telerik:RadPageView ID="pvReviewDetails" runat="server">
            <div class="containerouter">
                <div class="containerinner">
                    <h3>Details</h3>
                    <div>
                        <div style="float: left; margin-left: 10px; margin-right: 15px;">
                            <div>Review Template:</div>
                            <idea:ReviewTemplateDDL
                            runat="server"
                            ID="ddlTemplate">
                            </idea:ReviewTemplateDDL>
                            <asp:RequiredFieldValidator
                            runat="server"
                            ID="RequiredFieldValidator3"
                            Display="Dynamic"
                            CssClass="error"
                            ErrorMessage="<br />Select a template."
                            InitialValue=""
                            ControlToValidate="ddlTemplate" />
                        </div>
                        <div style="float: left; margin-right: 15px;">
                            <div>Start Date:</div>
                            <telerik:RadDatePicker 
                            ID="tbStartDate"
                            Skin="Metro"
                            Height="25px"
                            width="150px"
                            runat="server">
                                <DateInput ID="diStartDate" runat="server"
                                    DateFormat="MM/dd/yyyy"></DateInput>
                            </telerik:RadDatePicker>
                            <asp:RequiredFieldValidator
                            runat="server"
                            ID="RequiredFieldValidator2"
                            Display="Dynamic"
                            CssClass="error"
                            ErrorMessage="<br />Select a date."
                            InitialValue=""
                            ControlToValidate="tbStartDate" />
                        </div>
                        <div style="float: left;">
                            <div>End Date: 
                                <span style="margin-top: -6px !important; vertical-align: top !important;">
                                <idea:LinkButton
                                runat="server"
                                ID="lbExportDate"
                                OnClick="ExportToCalendar">
                                    export to Outlook
                                </idea:LinkButton>
                            </span>
                            </div>
                            <telerik:RadDatePicker 
                            ID="tbEndDate"
                            width="150px"
                            Height="25px"
                            Skin="Metro"
                            runat="server">
                                <DateInput ID="diEndDate" runat="server"
                                    DateFormat="MM/dd/yyyy"></DateInput>
                            </telerik:RadDatePicker>
                            
                            <asp:RequiredFieldValidator
                            runat="server"
                            ID="RequiredFieldValidator1"
                            Display="Dynamic"
                            CssClass="error"
                            ErrorMessage="<br />Select a date."
                            InitialValue=""
                            ControlToValidate="tbEndDate" />
                        </div>
                    </div>
                    <div runat="server" id="divSaveReview" style="margin-left: 10px; margin-top: 85px; margin-bottom: 20px;">
                        <span>
                            <idea:LinkButton
                            runat="server"
                            OnClick="SaveClicked"
                            ID="lbSave"
                            CssClass="button big round sky-blue">
                                Save Review
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
                        <span>
                            <idea:LinkButton
                            runat="server"
                            CausesValidation="false"
                            OnClick="ExportClicked"
                            ID="lbExport"
                            CssClass="button big round sky-blue">
                                Export To PDF
                            </idea:LinkButton>
                        </span>
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
                OnItemCreated="ManagerItemCreated"
                OnItemCommand="ManagerItemCommand"
                OnItemDataBound="ManagerItemDataBound"
                GridLines="None"
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
        <telerik:RadPageView ID="pvQuestions" runat="server">
            <div class="containerouter">
                <div class="containerinner">
                    <h3 style="display:inline !important;">Questions</h3>
                    <br /><br />
                    <asp:DataList
                    runat="server"
                    OnItemCreated="ItemCreated"
                    OnItemDataBound="ItemDataBound"
                    ID="dlQuestions">
                        <ItemTemplate>
                            <div style="margin-bottom: 30px;">
                                <%# Eval("Question.Question") %><br />
                                <telerik:RadSlider 
                                ID="rsQuestion"
                                Skin="Metro"
                                Width="710px"
                                ItemType="Item"
                                Height="30px"
                                itemid='<%# Eval("ID").ToString() %>'
                                TrackPosition="TopLeft"
                                SelectionStart="1"
                                runat="server">
                                </telerik:RadSlider><br />

                                <idea:TextBox
                                runat="server"
                                ID="tbComment"
                                Text='<%# Eval("Comment") %>'
                                TextMode="MultiLine"
                                Height="100px"
                                Width="700px" />
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                    <div style="margin-left: 10px; margin-top: 85px; margin-bottom: 20px;">
                        <span>
                            <idea:LinkButton
                            runat="server"
                            OnClick="SaveQuestionsClicked"
                            ID="lbSaveQuestions"
                            CssClass="button big round sky-blue">
                                Save Ratings
                            </idea:LinkButton>
                        </span>&nbsp;
                        <span>
                            <idea:LinkButton
                            runat="server"
                            OnClick="CancelClicked"
                            CausesValidation="false"
                            ID="lbCancelQuestions"
                            CssClass="button big round sky-blue">
                                Cancel
                            </idea:LinkButton>
                        </span>
                    </div>
                </div>
            </div>
        </telerik:RadPageView>
        <telerik:RadPageView ID="pvGoals" runat="server">
            <idea:GoalListView
            runat="server"
            id="goalListView" />
        </telerik:RadPageView>
        <telerik:RadPageView ID="pvComments" runat="server">
            <div class="containerouter">
                <div class="containerinner">
                    <h3>Comments Totals</h3>
                    <div style="padding: 5px;">
                        <span style="font-weight: bolder">Comments left for:  </span>
                        <span runat="server" id="lblPositiveLeftFor" style="color: #000000; font-size: 22px; margin-right: 10px; ">
                        </span>
                        <span runat="server" id="lblConstructiveLeftFor" style="color: #ff0000; margin-right: 10px; font-size: 22px">
                        </span>
                    </div>
                    <div style="padding: 5px;">
                        <span style="font-weight: bolder">Comments left by:  </span>
                        <span runat="server" id="lblPositiveLeftBy" style="color: #000000; font-size: 22px; margin-right: 10px; "></span>
                        <span runat="server" id="lblConstructiveLeftBy" style="color: #ff0000; margin-right: 10px; font-size: 22px"> </span>
                    </div>
                </div>
            </div>
            <br />
            <div class="containerouter">
                <div class="containerinner">
                    <h3 style="display:inline !important;">Comments</h3>
                    <br />
                    <p>
                        Only selected comments are included in the review score.
                    </p>
                    <br />
                    <asp:DataList
                    runat="server"
                    OnItemDataBound="CommentsItemDataBound"
                    ID="dlComments">
                        <ItemTemplate>
                            <div runat="server" id="divContainer">
                            <div style="float: left; margin-right: 5px;">
                                <idea:CheckBox
                                runat="server"
                                itemid='<%# Eval("ID") %>'
                                Checked='<%#Eval("IncludedInReview") %>'
                                ID="cbSelected" />
                            </div>
                            <div style="float: left; margin-right: 5px;">
                                <telerik:RadBinaryImage ID="rbiProfile"
                                runat="server"
                                Width="50px"
                                Height="50px"
                                AutoAdjustImageControlSize="true"
                                ImageUrl='<%# Eval("EnteredForRef.AvatarPath").ToString() %>'
                                style="padding: 0px 0px 5px 0px;"/>
                            </div>
                            <div style="float: left; margin-left: 10px; margin-top: 0px; width: 610px;">
                                <span style="font-size: 14pt;">
                                    <a href='<%# "/People/" + Eval("EnteredForRef.Email").ToString() %>'><%#Eval("EnteredForRef.Name") %></a> &nbsp;&nbsp;
                                    <%# Eval("CommentType").ToString().Equals("-1") ? "<img src='/images/downh.png' alt='Negative' title='Negative Comment' /><br />" : "<img src='/images/uph.png' alt='Positive' title='Positive Comment' /><br />" %>
                            
                                </span>
                                <span>
                                    <idea:Label
                                    runat="server"
                                    ID="lblMessage" />
                                </span>
                            </div>
                            <div style="margin-left: 90px;">
                                <span runat="server" id="lblEnteredBy" style="font-size: 8pt;">entered by <a href='<%# "/People/" + Eval("EnteredByRef.Email").ToString() %>'><i><%# Eval("EnteredByRef.Name").ToString() %></i></a> on </span>
                                <span style="font-size: 8pt; color: #000000;"><%#DateTime.Parse(Eval("DateCreated").ToString()).ToString("MMM d, yyyy @ HH:mm") %></span>
                                <span style="font-size: 8pt; color: #000000;"> under <span style="font-size: 8pt; color: #cc6600;"><%# DataBinder.Eval(Container.DataItem, "Category.Name") %></span></span> | 
                        <span>
                            <idea:LinkButton
                            CausesValidation="false"
                            runat="server"
                            ID="lbResponseCount"
                            itemid='<%# Eval("ID").ToString() %>'
                            OnClick="ResponseCountClicked">
                            </idea:LinkButton>
                        </span>
                            </div>
                            <hr />
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                    <div style="margin-left: 10px; margin-top: 85px; margin-bottom: 20px;">
                        <span>
                            <idea:LinkButton
                            runat="server"
                            OnClick="SaveCommentsClicked"
                            ID="lbSaveComments"
                            CssClass="button big round sky-blue">
                                Save Comments
                            </idea:LinkButton>
                        </span>&nbsp;
                        <span>
                            <idea:LinkButton
                            runat="server"
                            OnClick="CancelClicked"
                            CausesValidation="false"
                            ID="LinkButton2"
                            CssClass="button big round sky-blue">
                                Cancel
                            </idea:LinkButton>
                        </span>
                    </div>
                </div>
            </div>
        </telerik:RadPageView>
        <telerik:RadPageView ID="pvNotes" runat="server">
            <div class="containerouter">
                <div class="containerinner">
                    <h3 style="display:inline !important;">Notes</h3>
    
                    <div>
                <telerik:RadGrid
                runat="server"
                ID="rgNotes"
                AllowPaging="True"
                AutoGenerateColumns="false"
                AllowSorting="True" 
                OnItemCommand="NotesItemCommand"
                OnItemDataBound="NotesItemDataBound"
                OnItemCreated="NotesItemCreated"
                GridLines="None"
                ShowStatusBar="true"
                OnNeedDataSource="NotesNeedDataSource"
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
                    CommandItemSettings-AddNewRecordText="Add Note"
                    NoMasterRecordsText="No Notes Found.">
                        <Columns>
                            <telerik:GridTemplateColumn 
                            DataField="Message" 
                            HeaderText="Note" 
                            HeaderStyle-Width="400px"
                            UniqueName="Message">
                                <ItemTemplate>
                                    <%# Eval("Message") %>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <idea:TextBox
                                    runat="server"
                                    ID="tbNote"
                                    Width="600px"
                                    Height="100px"
                                    TextMode="MultiLine"
                                    Text='<%# Eval("Message") %>' />
                                    <div style="margin-bottom: 20px;">&nbsp;</div>
                                </EditItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn 
                            DataField="EnteredByRef.Name" 
                            HeaderText="Entered By" 
                            UniqueName="EnteredByRef.Name">
                                <ItemTemplate>
                                    <%# Eval("EnteredByRef.Name")%>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn 
                            DataField="DateCreated" 
                            HeaderText="Date Created" 
                            UniqueName="DateCreated">
                                <ItemTemplate>
                                    <%# DateTime.Parse(Eval("DateCreated").ToString()).ToString()%>
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
                                        ToolTip="Edit Note"
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
                                        ToolTip="Delete Note"
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
    </telerik:RadMultiPage>

</div>
</asp:Content>
