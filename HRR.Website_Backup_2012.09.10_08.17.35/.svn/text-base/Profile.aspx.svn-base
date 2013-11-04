<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="HRR.Website.Profile" %>
<%@ Register TagPrefix="idea" TagName="CommentListView" Src="~/Views/CommentListView.ascx" %>
<%@ MasterType VirtualPath="~/MasterPages/Main.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<telerik:RadAjaxManagerProxy ID="rampProfile" runat="server" >
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="rtsProfile">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rmpProfile" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="rtsProfile">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rtsProfile"/>
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server"  Skin="Simple" Transparency="15" />
    <div class="three_fourth last_column">
        <div class="containerouter">
            <div class="containerinner">
                <div>
                    <h3>
                        <idea:Label
                        runat="server"
                        ID="lblName" />&nbsp;
                        <span runat="server" id="divEditProfile" style="font-size: 10px;">
                        <idea:LinkButton
                        runat="server"
                        OnClick="EditClicked"
                        ID="lbSave">
                            Manage Profile
                        </idea:LinkButton>
                        </span>
                    </h3>
                </div>
                <div>
                    <span>
                        Title:
                    </span>
                    <idea:Label
                    runat="server"
                    class="blueText"
                    ID="lblTitle" /> | 
                    <span>
                        Department:
                    </span>
                    <idea:Label
                    runat="server"
                    class="blueText"
                    ID="lblDepartment" /> | 
                    <span>
                        Hire Date: 
                    </span>
                    <idea:Label
                    runat="server"
                    class="blueText"
                    ID="lblHireDate" /> | 
                    <span>
                        Birthdate:
                    </span>
                    <idea:Label
                    runat="server"
                    class="blueText"
                    ID="lblBirthdate" /> <%--|
                    <span>
                        Company Score:
                    </span>
                    <idea:Label
                    runat="server"
                    class="blueText"
                    ID="lblCompanyScore" />--%>
                </div>
            </div>
        </div>
    </div>
    <br />

    <div class="three_fourth last_column">
            <div>
                <telerik:RadTabStrip runat="server"
                 ID="rtsProfile" 
                 MultiPageID="rmpProfile" 
                 SelectedIndex="0"
                 Skin="Metro">
                    <Tabs>
                        <telerik:RadTab runat="server" Value="0" Text="Teams">
                        </telerik:RadTab>
                        <telerik:RadTab runat="server" Value="1" Text="Reviews">
                        </telerik:RadTab>
                        <telerik:RadTab runat="server" Value="2" Text="Goals">
                        </telerik:RadTab>
                        <telerik:RadTab runat="server" Value="3" Text="Comments">
                        </telerik:RadTab>
                        <telerik:RadTab runat="server" Value="4" Text="Documents">
                        </telerik:RadTab>
                        <telerik:RadTab runat="server" Value="5" Text="Absence Tracking">
                        </telerik:RadTab>
                    </Tabs>
                </telerik:RadTabStrip>
                <telerik:RadMultiPage ID="rmpProfile" runat="server" SelectedIndex="0">
                    <telerik:RadPageView ID="pvTeams" runat="server">
                        <div class="containerouter">
                            <div class="containerinner">
                                <h3 style="display:inline !important;">Teams</h3>
                                <br /><br />
                                    <telerik:RadGrid
                                    runat="server"
                                    ID="rgTeams"
                                    AllowPaging="True"
                                    AutoGenerateColumns="false"
                                    AllowSorting="True" 
                                    GridLines="None" 
                                    ShowStatusBar="true"
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
                                        NoMasterRecordsText="No Teams Found.">
                                            <Columns>
                                                <telerik:GridTemplateColumn 
                                                DataField="TeamRef.Name" 
                                                HeaderText="Team" 
                                                SortExpression="TeamRef.Name"
                                                UniqueName="TeamRef.Name">
                                                    <ItemTemplate>
                                                        <%#  Eval("TeamRef.Name")%> 
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn 
                                                DataField="IsManager" 
                                                HeaderText="Manager" 
                                                SortExpression="IsManager"
                                                UniqueName="IsManager">
                                                    <ItemTemplate>
                                                        <%#  Eval("IsManager").ToString().Equals("True") ? "Yes" : "No" %>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn 
                                                DataField="RecievesNotifications" 
                                                HeaderText="Receives Notifications" 
                                                SortExpression="RecievesNotifications"
                                                UniqueName="RecievesNotifications">
                                                    <ItemTemplate>
                                                        <%# Eval("RecievesNotifications").ToString().Equals("True") ? "Yes" : "No"%>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <PagerStyle Mode="NextPrevAndNumeric"  AlwaysVisible="true" Position="Bottom" />
                                        </MasterTableView>
                                    </telerik:RadGrid>
                            </div>
                        </div>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="pvReviews" runat="server">
                        <div class="containerouter">
                            <div class="containerinner">
                                <h3 style="display:inline !important;">Reviews</h3>
                                <br /><br />
                                    <telerik:RadGrid
                                    runat="server"
                                    ID="rgReviews"
                                    AllowPaging="True"
                                    AutoGenerateColumns="false"
                                    AllowSorting="True" 
                                    GridLines="None" 
                                    ShowStatusBar="true"
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
                                        NoMasterRecordsText="No Reviews Found.">
                                            <Columns>
                                                <telerik:GridTemplateColumn 
                                                DataField="Title" 
                                                HeaderText="Title" 
                                                SortExpression="Title"
                                                UniqueName="Title">
                                                    <ItemTemplate>
                                                        <%#  Eval("Title")%> 
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn 
                                                DataField="DueDate" 
                                                HeaderText="Due Date" 
                                                SortExpression="DueDate"
                                                UniqueName="DueDate">
                                                    <ItemTemplate>
                                                        <%# DateTime.Parse(Eval("DueDate").ToString()).ToShortDateString()%>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn 
                                                DataField="Status" 
                                                HeaderText="Status" 
                                                SortExpression="Status"
                                                UniqueName="Status">
                                                    <ItemTemplate>
                                                        <%# Enum.GetName(typeof(HRR.Core.Domain.GoalStatus), Eval("Status")).Replace("_or_", @"/").Replace("_", " ").ToLower()%>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <PagerStyle Mode="NextPrevAndNumeric"  AlwaysVisible="true" Position="Bottom" />
                                        </MasterTableView>
                                    </telerik:RadGrid>
                            </div>
                        </div>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="pvGoals" runat="server">
                        <div class="containerouter">
                            <div class="containerinner">
                                <h3 style="display:inline !important;">Goals</h3>
                                <br /><br />
                                    <telerik:RadGrid
                                    runat="server"
                                    ID="rgGoals"
                                    AllowPaging="True"
                                    AutoGenerateColumns="false"
                                    AllowSorting="True" 
                                    GridLines="None" 
                                    ShowStatusBar="true"
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
                                        NoMasterRecordsText="No Goals Found.">
                                            <Columns>
                                                <telerik:GridTemplateColumn 
                                                DataField="Title" 
                                                HeaderText="Title" 
                                                SortExpression="Title"
                                                UniqueName="Title">
                                                    <ItemTemplate>
                                                        <%#  Eval("Title")%> 
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn 
                                                DataField="Description" 
                                                HeaderText="Description" 
                                                SortExpression="Description"
                                                UniqueName="Description">
                                                    <ItemTemplate>
                                                        <%# Eval("Description")%>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn 
                                                DataField="DueDate" 
                                                HeaderText="Due Date" 
                                                SortExpression="DueDate"
                                                UniqueName="DueDate">
                                                    <ItemTemplate>
                                                        <%# DateTime.Parse(Eval("DueDate").ToString()).ToShortDateString()%>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn 
                                                DataField="StatusID" 
                                                HeaderText="Status" 
                                                SortExpression="StatusID"
                                                UniqueName="StatusID">
                                                    <ItemTemplate>
                                                        <%# Enum.GetName(typeof(HRR.Core.Domain.GoalStatus), Eval("StatusID")).Replace("_or_", @"/").Replace("_", " ").ToLower()%>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <PagerStyle Mode="NextPrevAndNumeric"  AlwaysVisible="true" Position="Bottom" />
                                        </MasterTableView>
                                    </telerik:RadGrid>
                            </div>
                        </div>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="pvComments" runat="server">
                        <div class="containerouter">
                            <div class="containerinner">
                                <h3 style="display:inline !important;">Comments</h3>
                                <br />
                                <br />
                                <asp:DataList
                                runat="server"
                                OnItemDataBound="CommentsItemDataBound"
                                ID="dlComments">
                                    <ItemTemplate>
                                        <div runat="server" id="divContainer">
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
                                        <div style="margin-left: 65px;">
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
                            </div>
                        </div>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="pvDocuments" runat="server">
                        <div class="containerouter">
                            <div class="containerinner">
                                <h3 style="display:inline !important;">Documents</h3>
                                    <br /><br />
                                    <telerik:RadGrid
                                    runat="server"
                                    ID="rgDocuments"
                                    AllowPaging="True"
                                    AutoGenerateColumns="false"
                                    AllowSorting="True" 
                                    GridLines="None" 
                                    ShowStatusBar="true"
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
                                        NoMasterRecordsText="No Documents Found.">
                                            <Columns>
                                                <telerik:GridTemplateColumn 
                                                DataField="Title" 
                                                HeaderText="Title" 
                                                SortExpression="Title"
                                                UniqueName="Title">
                                                    <ItemTemplate>
                                                        <asp:HyperLink
                                                        runat="server"
                                                        ID="lbPath"
                                                        style="color: #000000 !important;"
                                                        Target="_blank"
                                                        NavigateUrl='<%# Eval("Path").ToString() %>'
                                                        Text='<%#  Eval("Title")%>' />
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn 
                                                DataField="Description" 
                                                HeaderText="Description" 
                                                SortExpression="Description"
                                                UniqueName="Description">
                                                    <ItemTemplate>
                                                        <%# Eval("Description")%>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <PagerStyle Mode="NextPrevAndNumeric"  AlwaysVisible="true" Position="Bottom" />
                                        </MasterTableView>
                                    </telerik:RadGrid>
                            </div>
                        </div>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="pvAbsenceTracking" runat="server">
                        <div class="containerouter">
                            <div class="containerinner">
                                <h3 style="display:inline !important;">Absence Tracking</h3>
                                <br /><br />
                                <div>
                                    <telerik:RadGrid
                                    runat="server"
                                    ID="rgAbsences"
                                    AllowPaging="True"
                                    AutoGenerateColumns="false"
                                    AllowSorting="True" 
                                    GridLines="None" 
                                    ShowStatusBar="true"
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
                                        NoMasterRecordsText="No Absences Found.">
                                            <Columns>
                                                <telerik:GridTemplateColumn 
                                                DataField="AbsentCategoryID" 
                                                HeaderText="Reason" 
                                                SortExpression="AbsentCategoryID"
                                                UniqueName="AbsentCategoryID">
                                                    <ItemTemplate>
                                                        <%#  Enum.GetName(typeof(HRR.Core.Domain.AbsenceTypes), Eval("AbsentCategoryID")).Replace("_or_", @"/").Replace("_", " ").ToLower()%> 
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn 
                                                DataField="FromDate" 
                                                HeaderText="Dates" 
                                                SortExpression="FromDate"
                                                UniqueName="FromDate">
                                                    <ItemTemplate>
                                                        <%# DateTime.Parse(Eval("FromDate").ToString()).ToShortDateString() + " - " + DateTime.Parse(Eval("ToDate").ToString()).ToShortDateString()%>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn 
                                                DataField="Note" 
                                                HeaderText="Note" 
                                                SortExpression="Note"
                                                UniqueName="Note">
                                                    <ItemTemplate>
                                                        <%#  Eval("Note")%>
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
    </div>
</asp:Content>
