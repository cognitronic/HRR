<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="HRR.Website.EditProfile" %>
<%@ MasterType VirtualPath="~/MasterPages/Main.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<telerik:RadAjaxManagerProxy ID="rampComments" runat="server" >
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
        <telerik:AjaxSetting AjaxControlID="lbSaveDocument">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgDocuments" LoadingPanelID="RadAjaxLoadingPanel1"/>
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="lbSaveNote">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgNote" LoadingPanelID="RadAjaxLoadingPanel1"/>
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="rgDocuments">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgDocuments"/>
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="lbSaveAbsence">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgAbsences" LoadingPanelID="RadAjaxLoadingPanel1"/>
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="rgAbsences">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgAbsences"/>
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="lbSave">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="divEmpInfo" LoadingPanelID="RadAjaxLoadingPanel1"/>
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
                 ID="rtsProfile" 
                 MultiPageID="rmpProfile" 
                 SelectedIndex="0"
                 Skin="Metro">
                    <Tabs>
                        <telerik:RadTab runat="server" Value="0" Text="Info">
                        </telerik:RadTab>
                        <telerik:RadTab runat="server" Value="1" Text="Documents">
                        </telerik:RadTab>
                        <telerik:RadTab runat="server" Value="2" Text="Absence Tracking">
                        </telerik:RadTab>
                        <telerik:RadTab runat="server" Value="3" Text="Notes">
                        </telerik:RadTab>
                    </Tabs>
                </telerik:RadTabStrip>
                <telerik:RadMultiPage ID="rmpProfile" runat="server" SelectedIndex="0">
                    <telerik:RadPageView ID="pvInfo" runat="server">
                        <div runat="server" id="divHROnly" style="margin-top: 5px; margin-bottom: 5px;">                             <div class="containerouter">
                                <div class="containerinner">
                                <h5>HR Only</h5>
                                <div>
                                    <div>Is Active?</div>
                                    <idea:CheckBox
                                    runat="server"
                                    ID="cbIsActive" />
                                </div>
                                <div>
                                    <div>Is Manager?</div>
                                    <idea:CheckBox
                                    runat="server"
                                    ID="cbIsManager" />
                                </div>
                                <%--<div>
                                    <div>Receives Comment Notifications?</div>
                                    <idea:CheckBox
                                    runat="server"
                                    ID="cbCommentNotifications" />
                                </div>--%>
                                <div>
                                    <div>Hire Date</div>
                                    <telerik:RadDatePicker 
                                    ID="tbHireDate"
                                    Skin="Metro"
                                    MinDate="1/1/1970"
                                    runat="server">
                                        <DateInput ID="diHireDate" runat="server"
                                            DateFormat="MM/dd/yyyy"></DateInput>
                                    </telerik:RadDatePicker>
                                    <asp:RequiredFieldValidator
                                    runat="server"
                                    ID="RequiredFieldValidator2"
                                    Display="Dynamic"
                                    CssClass="error"
                                    ErrorMessage="Select a date."
                                    InitialValue=""
                                    ControlToValidate="tbHireDate" />
                                </div>
                                <div>
                                    <div>Termination Date</div>
                                    <telerik:RadDatePicker 
                                    ID="tbTerminationDate"
                                    Skin="Metro"
                                    MinDate="1/1/1970"
                                    runat="server">
                                        <DateInput ID="diTerminationDate" runat="server"
                                            DateFormat="MM/dd/yyyy"></DateInput>
                                    </telerik:RadDatePicker>
                                </div>
                                <div>
                                    <div>Security Role:</div>
                                    <idea:SecurityRolesDDL
                                    runat="server"
                                    id="ddlSecurityRole" />
                                    <asp:RequiredFieldValidator
                                    runat="server"
                                    ID="RequiredFieldValidator1"
                                    Display="Dynamic"
                                    CssClass="error"
                                    ErrorMessage="Select a security role."
                                    InitialValue=""
                                    ControlToValidate="ddlSecurityRole" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div runat="server" id="divEmpInfo">
                            <div class="containerouter">
                                <div class="containerinner">
                                    <div>
                                        <span>Can Receive Notifications?</span>
                                        <idea:CheckBox
                                        runat="server"
                                        ID="cbReceivesNotifications" />
                                    </div>
                                    <div>
                                        <div>First Name:</div>
                                        <idea:TextBox
                                        runat="server"
                                        ID="tbFirstName"
                                        Width="450px" />
                                        <asp:RequiredFieldValidator
                                        runat="server"
                                        ID="RequiredFieldValidator3"
                                        Display="Dynamic"
                                        CssClass="error"
                                        ErrorMessage="Enter first name."
                                        InitialValue=""
                                        ControlToValidate="tbFirstName" />
                                    </div>
                                    <div>
                                        <div>Last Name:</div>
                                        <idea:TextBox
                                        runat="server"
                                        ID="tbLastName"
                                        Width="450px" />
                                        <asp:RequiredFieldValidator
                                        runat="server"
                                        ID="RequiredFieldValidator4"
                                        Display="Dynamic"
                                        CssClass="error"
                                        ErrorMessage="Enter last name."
                                        InitialValue=""
                                        ControlToValidate="tbLastName" />
                                    </div>
                                    <div>
                                        <div>Email:</div>
                                        <idea:TextBox
                                        runat="server"
                                        ID="tbEmail"
                                        Width="450px" />
                                        <asp:RequiredFieldValidator
                                        runat="server"
                                        ID="RequiredFieldValidator5"
                                        Display="Dynamic"
                                        CssClass="error"
                                        ErrorMessage="Enter email address."
                                        InitialValue=""
                                        ControlToValidate="tbEmail" />
                                        <asp:RegularExpressionValidator 
                                        ID="valEmailAddress"
                                        ControlToValidate="tbEmail"
                                        CssClass="error"
                                        ValidationExpression=".*@.*\..*" 
                                        ErrorMessage="Email address is invalid." 
                                        Display="Dynamic" 
                                        EnableClientScript="true"
                                        Runat="server"/>
                                    </div>
                                    <div>
                                        <div>Title:</div>
                                        <idea:TextBox
                                        runat="server"
                                        ID="tbTitle"
                                        Width="450px" />
                                        <asp:RequiredFieldValidator
                                        runat="server"
                                        ID="RequiredFieldValidator6"
                                        Display="Dynamic"
                                        CssClass="error"
                                        ErrorMessage="Enter title."
                                        InitialValue=""
                                        ControlToValidate="tbTitle" />
                                    </div>
                                    <div>
                                        <div>Birth Date</div>
                                        <telerik:RadDatePicker 
                                        ID="tbBirthdate"
                                        Skin="Metro"
                                        MinDate="1/1/1920"
                                        runat="server">
                                            <DateInput ID="diBirthdate" runat="server"
                                                DateFormat="MM/dd/yyyy"></DateInput>
                                        </telerik:RadDatePicker>
                                        <asp:RequiredFieldValidator
                                        runat="server"
                                        ID="RequiredFieldValidator7"
                                        Display="Dynamic"
                                        CssClass="error"
                                        ErrorMessage="Enter birth date."
                                        InitialValue=""
                                        ControlToValidate="tbBirthdate" />
                                    </div>
                                    <div>
                                        <div>Department:</div>
                                        <idea:DepartmentsDDL
                                        runat="server"
                                        ID="ddlDepartments" />
                                        <asp:RequiredFieldValidator
                                        runat="server"
                                        ID="RequiredFieldValidator8"
                                        Display="Dynamic"
                                        CssClass="error"
                                        ErrorMessage="Select department."
                                        InitialValue=""
                                        ControlToValidate="ddlDepartments" />
                                    </div>
                                    <div>
                                        <div>Manager:</div>
                                        <idea:ManagersDDL
                                        runat="server"
                                        ID="ddlManager"/>
                                        <asp:RequiredFieldValidator
                                        runat="server"
                                        ID="RequiredFieldValidator9"
                                        Display="Dynamic"
                                        CssClass="error"
                                        ErrorMessage="Select manager."
                                        InitialValue=""
                                        ControlToValidate="ddlManager" />
                                    </div>
                                    <div>
                                        <div>Password:</div>
                                        <idea:TextBox
                                        runat="server"
                                        ID="tbPassword"
                                        Width="450px" />
                                    </div>
                                    <div>
                                        <div>Security Question:</div>
                                        <idea:TextBox
                                        runat="server"
                                        ID="tbSecurityQuestion"
                                        Width="450px" />
                                        <asp:RequiredFieldValidator
                                        runat="server"
                                        ID="RequiredFieldValidator10"
                                        Display="Dynamic"
                                        CssClass="error"
                                        ErrorMessage="Enter security question."
                                        InitialValue=""
                                        ControlToValidate="tbEmail" />
                                    </div>
                                    <div>
                                        <div>Security Answer:</div>
                                        <idea:TextBox
                                        runat="server"
                                        ID="tbSecurityAnswer"
                                        Width="450px" />
                                    </div>
                                    <div>
                                        <div>Profile Pic:</div>
                                        <telerik:RadAsyncUpload 
                                        runat="server" 
                                        ID="radAsyncUpload" 
                                        AllowedFileExtensions="jpg,jpeg,png,gif"
                                        MaxFileSize="1048576"
                                        OverwriteExistingFiles="false" 
                                        OnValidatingFile="RadAsyncUpload1_ValidatingFile">
                                        </telerik:RadAsyncUpload>
                                    </div>
                                    <div>
                                        <div>Facebook URL:</div>
                                        <idea:TextBox
                                        runat="server"
                                        ID="tbFacebookURL"
                                        Width="450px" />
                                    </div>
                                    <div>
                                        <div>Twitter URL:</div>
                                        <idea:TextBox
                                        runat="server"
                                        ID="tbTwitterURL"
                                        Width="450px" />
                                    </div>
                                    <div>
                                        <div>LinkedIn URL:</div>
                                        <idea:TextBox
                                        runat="server"
                                        ID="tbLinkedInURL"
                                        Width="450px" />
                                    </div>
                                    <div style="height: 100px; margin-top: 10px;">
                                        <span>
                                            <idea:LinkButton
                                            runat="server"
                                            OnClick="SaveClicked"
                                            ID="lbSave"
                                            CssClass="button big round sky-blue">
                                                Save
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
                                    </div>
                                </div>
                            </div>
                        </div>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="pvDocuments" runat="server">
                        <div style="margin-top: 5px;">
                            <div class="containerouter">
                                <div class="containerinner">
                                    <h5>Add Document</h5>
                                    <div>
                                        <div>Is Document Private (HR Only):</div>
                                        <idea:CheckBox
                                        runat="server"
                                        ID="cbIsPrivate" />
                                    </div>
                                    <div>
                                        <div>Title:</div>
                                        <idea:TextBox
                                        runat="server"
                                        ID="tbDocumentTitle"
                                        Width="400px" />
                                    </div>
                                    <div>
                                        <div>Description:</div>
                                        <idea:TextBox
                                        runat="server"
                                        ID="tbDocumentDescription"
                                        TextMode="MultiLine"
                                        Width="400px"
                                        Height="50px" />
                                    </div>
                                    <div>
                                        <div>Upload File: </div>
                                        <telerik:RadAsyncUpload 
                                        runat="server" 
                                        ID="rauDocument" 
                                        AllowedFileExtensions="jpg,jpeg,png,gif,doc,docx,xls,xlsx,pdf"
                                        MaxFileSize="10048576"
                                        OverwriteExistingFiles="false" 
                                        OnValidatingFile="RadAsyncUpload1_ValidatingFile">
                                        </telerik:RadAsyncUpload>
                                    </div>
                                    <hr style="clear: none;" />
                                    <div style="height: 40px;">
                                        <span>
                                            <idea:LinkButton
                                            runat="server"
                                            OnClick="SaveDocumentClicked"
                                            ID="lbSaveDocument"
                                            CssClass="button big round sky-blue">
                                                Save
                                            </idea:LinkButton>
                                        </span>&nbsp;
                                        <span>
                                            <idea:LinkButton
                                            runat="server"
                                            OnClick="CancelDocumentClicked"
                                            CausesValidation="false"
                                            ID="lb"
                                            CssClass="button big round sky-blue">
                                                Cancel
                                            </idea:LinkButton>
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="containerouter">
                                <div class="containerinner">
                                    <div>
                                        <telerik:RadGrid
                                        runat="server"
                                        ID="rgDocuments"
                                        AllowPaging="True"
                                        AutoGenerateColumns="false"
                                        AllowSorting="True" 
                                        GridLines="None" 
                                        ShowStatusBar="true"
                                        OnItemCommand="DocumentsItemCommand"
                                        OnItemCreated="DocumentsItemCreated"
                                        OnNeedDataSource="DocumentsNeedDataSource"
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
                                                    DataField="IsPrivate" 
                                                    HeaderText="Is Private" 
                                                    SortExpression="IsPrivate"
                                                    UniqueName="IsPrivate">
                                                        <ItemTemplate>
                                                            <%#  Eval("IsPrivate").ToString().Equals("True") ? "Yes" : "No" %>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <idea:CheckBox
                                                            ID="cbIsPrivate"
                                                            runat="server"
                                                            Checked='<%# IdeaSeed.Core.Utils.Utilities.FormatCheckBox(Eval("IsPrivate")) %>' />
                                                        </EditItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn 
                                                    DataField="Title" 
                                                    HeaderText="Title" 
                                                    SortExpression="Title"
                                                    UniqueName="Title">
                                                        <ItemTemplate>
                                                            <asp:HyperLink
                                                            runat="server"
                                                            ID="lbPath"
                                                            Target="_blank"
                                                            NavigateUrl='<%# Eval("Path").ToString() %>'
                                                            Text='<%#  Eval("Title")%>' />
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <idea:TextBox
                                                            runat="server"
                                                            ID="tbTitle"
                                                            Width="400px"
                                                            Text='<%# Eval("Title") %>' />
                                                            <div style="margin-bottom: 10px;" />
                                                        </EditItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn 
                                                    DataField="Description" 
                                                    HeaderText="Description" 
                                                    SortExpression="Description"
                                                    UniqueName="Description">
                                                        <ItemTemplate>
                                                            <%# Eval("Description")%>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <idea:TextBox
                                                            runat="server"
                                                            ID="tbDescription"
                                                            TextMode="MultiLine"
                                                            Height="50px"
                                                            Width="400px"
                                                            Text='<%# Eval("Description") %>' />
                                                            <div style="margin-bottom: 20px;" />
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
                                                                ToolTip="Edit Document"
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
                                                                ToolTip="Delete Document"
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
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="pvAbsence" runat="server">
                        <div style="margin-top: 5px;">
                            <div class="containerouter" runat="server" id="divAbsenceTracking">
                                <div class="containerinner">
                                    <h5>Track Absence</h5>
                                    <div>
                                        <div>Reason For Absence:</div>
                                        <idea:AbsenceTypeDDL
                                        runat="server"
                                        ID="ddlType" />
                                        <div style="margin: 10px 0px;">
                                            <asp:RequiredFieldValidator
                                            runat="server"
                                            ID="RequiredFieldValidator12"
                                            ValidationGroup="vgAbsence"
                                            Display="Dynamic"
                                            Width="300px"
                                            CssClass="error"
                                            ErrorMessage="Select a reason."
                                            InitialValue=""
                                            ControlToValidate="ddlType" />
                                        </div>
                                    </div>
                                    <div>
                                        <div>From:</div>
                                        <telerik:RadDatePicker 
                                        ID="tbFromDate"
                                        Skin="Metro"
                                        width="150px"
                                        runat="server">
                                            <DateInput ID="diFromDate" runat="server"
                                                DateFormat="MM/dd/yyyy"></DateInput>
                                        </telerik:RadDatePicker>
                                        <div style="margin: 10px 0px; width: 300px;">
                                            <asp:RequiredFieldValidator
                                            runat="server"
                                            ID="RequiredFieldValidator11"
                                            ValidationGroup="vgAbsence"
                                            Display="Dynamic"
                                            Width="300px"
                                            CssClass="error"
                                            ErrorMessage="Select a date."
                                            InitialValue=""
                                            ControlToValidate="tbFromDate" />
                                        </div>
                                    </div>
                                    <div>
                                        <div>To:</div>
                                        <telerik:RadDatePicker 
                                        ID="tbToDate"
                                        Skin="Metro"
                                        width="150px"
                                        runat="server">
                                            <DateInput ID="diToDate" runat="server"
                                                DateFormat="MM/dd/yyyy"></DateInput>
                                        </telerik:RadDatePicker>
                                        <div style="margin: 10px 0px; width: 300px;">
                                            <asp:RequiredFieldValidator
                                            runat="server"
                                            ID="RequiredFieldValidator13"
                                            ValidationGroup="vgAbsence"
                                            Display="Dynamic"
                                            Width="300px"
                                            CssClass="error"
                                            ErrorMessage="Select a date."
                                            InitialValue=""
                                            ControlToValidate="tbToDate" />
                                        </div>
                                    </div>
                                    <div>
                                        <div>Note:</div>
                                        <idea:TextBox
                                        runat="server"
                                        ID="tbAbsenceNote"
                                        TextMode="MultiLine"
                                        Width="400px"
                                        Height="50px" />
                                    </div>
                                    <hr style="clear: none;" />
                                    <div style="height: 40px;">
                                        <span>
                                            <idea:LinkButton
                                            runat="server"
                                            OnClick="SaveAbsenceClicked"
                                            ID="lbSaveAbsence"
                                            ValidationGroup="vgAbsence"
                                            CssClass="button big round sky-blue">
                                                Save
                                            </idea:LinkButton>
                                        </span>&nbsp;
                                        <span>
                                            <idea:LinkButton
                                            runat="server"
                                            OnClick="CancelAbsenceClicked"
                                            CausesValidation="false"
                                            ID="lbCancelAbsence"
                                            CssClass="button big round sky-blue">
                                                Cancel
                                            </idea:LinkButton>
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="containerouter">
                                <div class="containerinner">
                                    <div>
                                        <telerik:RadGrid
                                        runat="server"
                                        ID="rgAbsences"
                                        AllowPaging="True"
                                        AutoGenerateColumns="false"
                                        AllowSorting="True" 
                                        GridLines="None" 
                                        ShowStatusBar="true"
                                        OnNeedDataSource="AbsenceNeedDataSource"
                                        OnItemCreated="AbsenceItemCreated"
                                        OnItemCommand="AbsenceItemCommand"
                                        OnItemDataBound="AbsenceItemDataBound"
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
                                                        <EditItemTemplate>
                                                            <idea:AbsenceTypeDDL
                                                            runat="server"
                                                            ID="ddlAbsence"
                                                            SelectedValue='<%# IdeaSeed.Core.Utils.Utilities.FormatDropDown(Eval("AbsentCategoryId"))%>'>
                                                            </idea:AbsenceTypeDDL>
                                                            <div style="margin-bottom: 10px;">&nbsp;</div>
                                                        </EditItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn 
                                                    DataField="FromDate" 
                                                    HeaderText="Dates" 
                                                    SortExpression="FromDate"
                                                    UniqueName="FromDate">
                                                        <ItemTemplate>
                                                            <%# DateTime.Parse(Eval("FromDate").ToString()).ToShortDateString() + " - " + DateTime.Parse(Eval("ToDate").ToString()).ToShortDateString()%>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <div>
                                                                <div>From:</div>
                                                                <telerik:RadDatePicker 
                                                            ID="tbFromAbsent"
                                                            Skin="Metro"
                                                            DbSelectedDate='<%# Bind("FromDate") %>'
                                                            Height="25px"
                                                            width="150px"
                                                            runat="server">
                                                                <DateInput ID="diFromAbsent" runat="server"
                                                                    DateFormat="MM/dd/yyyy"></DateInput>
                                                            </telerik:RadDatePicker>
                                                            <asp:RequiredFieldValidator
                                                            runat="server"
                                                            ID="RequiredFieldValidator2"
                                                            Display="Dynamic"
                                                            CssClass="error"
                                                            ErrorMessage="Select a date."
                                                            InitialValue=""
                                                            ControlToValidate="tbFromAbsent" />
                                                            </div>
                                                            <div style="margin-bottom: 10px;">&nbsp;</div>
                                                            <div>
                                                                <div>To:</div>
                                                                <telerik:RadDatePicker 
                                                            ID="tbToAbsent"
                                                            Skin="Metro"
                                                            DbSelectedDate='<%# Bind("ToDate") %>'
                                                            Height="25px"
                                                            width="150px"
                                                            runat="server">
                                                                <DateInput ID="diToAbsent" runat="server"
                                                                    DateFormat="MM/dd/yyyy"></DateInput>
                                                            </telerik:RadDatePicker>
                                                            <asp:RequiredFieldValidator
                                                            runat="server"
                                                            ID="RequiredFieldValidator14"
                                                            Display="Dynamic"
                                                            CssClass="error"
                                                            ErrorMessage="Select a date."
                                                            InitialValue=""
                                                            ControlToValidate="tbToAbsent" />
                                                            </div>
                                                            <div style="margin-bottom: 10px;">&nbsp;</div>
                                                        </EditItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn 
                                                    DataField="Note" 
                                                    HeaderText="Note" 
                                                    SortExpression="Note"
                                                    UniqueName="Note">
                                                        <ItemTemplate>
                                                            <%#  Eval("Note")%>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <idea:TextBox
                                                            runat="server"
                                                            Width="500px"
                                                            TextMode="MultiLine"
                                                            Height="50px"
                                                            ID="tbNote"
                                                            Text='<%# Eval("Note")%>'>
                                                            </idea:TextBox>
                                                            <div style="margin-bottom: 20px;" />
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
                                                                ToolTip="Edit Absence"
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
                                                                ToolTip="Delete Absence"
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
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="pvNotes" runat="server">
                        <div style="margin-top: 5px;">
                            <div class="containerouter">
                                <div class="containerinner">
                                    <h5>Add Note</h5>
                                    <div>
                                        <div>Type:</div>
                                        <idea:NoteTypeDDL
                                        runat="server"
                                        ID="ddlNoteType" />
                                        <div style="margin: 10px 0px;">
                                            <asp:RequiredFieldValidator
                                            runat="server"
                                            ID="RequiredFieldValidator15"
                                            ValidationGroup="vgNotes"
                                            Display="Dynamic"
                                            Width="300px"
                                            CssClass="error"
                                            ErrorMessage="Select a type."
                                            InitialValue=""
                                            ControlToValidate="ddlNoteType" />
                                        </div>
                                    </div>
                                    <div>
                                        <div>Title:</div>
                                        <idea:TextBox
                                        runat="server"
                                        ID="tbNoteTitle"
                                        Width="400px" />
                                        <div style="margin: 10px 0px;">
                                            <asp:RequiredFieldValidator
                                            runat="server"
                                            ID="RequiredFieldValidator16"
                                            ValidationGroup="vgNotes"
                                            Display="Dynamic"
                                            Width="300px"
                                            CssClass="error"
                                            ErrorMessage="Enter a title."
                                            InitialValue=""
                                            ControlToValidate="tbNoteTitle" />
                                        </div>
                                    </div>
                                    <div>
                                        <div>Description:</div>
                                        <idea:TextBox
                                        runat="server"
                                        ID="tbNoteBody"
                                        TextMode="MultiLine"
                                        Width="400px"
                                        Height="50px" />
                                        <div style="margin: 10px 0px;">
                                            <asp:RequiredFieldValidator
                                            runat="server"
                                            ID="RequiredFieldValidator17"
                                            ValidationGroup="vgNotes"
                                            Display="Dynamic"
                                            Width="300px"
                                            CssClass="error"
                                            ErrorMessage="Enter a description"
                                            InitialValue=""
                                            ControlToValidate="tbNoteBody" />
                                        </div>
                                    </div>
                                    <hr style="clear: none;" />
                                    <div style="height: 40px;">
                                        <span>
                                            <idea:LinkButton
                                            runat="server"
                                            OnClick="SaveNoteClicked"
                                            ID="lbNoteSave"
                                            CssClass="button big round sky-blue">
                                                Save
                                            </idea:LinkButton>
                                        </span>&nbsp;
                                        <span>
                                            <idea:LinkButton
                                            runat="server"
                                            OnClick="CancelDocumentClicked"
                                            CausesValidation="false"
                                            ID="LinkButton2"
                                            CssClass="button big round sky-blue">
                                                Cancel
                                            </idea:LinkButton>
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="containerouter">
                                <div class="containerinner">
                                    <div>
                                        <telerik:RadGrid
                                        runat="server"
                                        ID="rgNote"
                                        AllowPaging="True"
                                        AutoGenerateColumns="false"
                                        AllowSorting="True" 
                                        GridLines="None" 
                                        ShowStatusBar="true"
                                        OnItemCommand="NotesItemCommand"
                                        OnItemCreated="NotesItemCreated"
                                        OnNeedDataSource="NotesNeedDataSource"
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
                                            NoMasterRecordsText="No Notes Found.">
                                                <Columns>
                                                    <telerik:GridTemplateColumn 
                                                    DataField="NoteType" 
                                                    HeaderText="Type" 
                                                    SortExpression="NoteType"
                                                    UniqueName="NoteType">
                                                        <ItemTemplate>
                                                            <%#  Enum.GetName(typeof(HRR.Core.Domain.NoteType), Eval("NoteType")).Replace("_or_", @"/").Replace("_", " ").ToLower()%> 
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <idea:NoteTypeDDL
                                                            runat="server"
                                                            id="ddlNoteType"
                                                            SelectedValue='<%# IdeaSeed.Core.Utils.Utilities.FormatDropDown(Eval("NoteType"))%>'/>
                                                            <asp:RequiredFieldValidator
                                                            runat="server"
                                                            ID="RequiredFieldValidator12"
                                                            Display="Dynamic"
                                                            CssClass="error"
                                                            ErrorMessage="Select a type."
                                                            InitialValue=""
                                                            ControlToValidate="ddlNoteType" />
                                                            <div style="margin-bottom: 10px;" />
                                                        </EditItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn 
                                                    DataField="Title" 
                                                    HeaderText="Title" 
                                                    SortExpression="Title"
                                                    UniqueName="Title">
                                                        <ItemTemplate>
                                                            <%#  Eval("Title")%>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <idea:TextBox
                                                            runat="server"
                                                            ID="tbTitle"
                                                            Width="400px"
                                                            Text='<%# Eval("Title") %>' />
                                                            <asp:RequiredFieldValidator
                                                            runat="server"
                                                            ID="RequiredFieldValidator2"
                                                            Display="Dynamic"
                                                            CssClass="error"
                                                            ErrorMessage="Enter a title"
                                                            InitialValue=""
                                                            ControlToValidate="tbTitle" />
                                                            <div style="margin-bottom: 10px;" />
                                                        </EditItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn 
                                                    DataField="Body" 
                                                    HeaderText="Description" 
                                                    SortExpression="Body"
                                                    UniqueName="Body">
                                                        <ItemTemplate>
                                                            <%# Eval("Body")%>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <idea:TextBox
                                                            runat="server"
                                                            ID="tbDescription"
                                                            TextMode="MultiLine"
                                                            Height="50px"
                                                            Width="400px"
                                                            Text='<%# Eval("Body") %>' />
                                                            <asp:RequiredFieldValidator
                                                            runat="server"
                                                            ID="RequiredFieldValidator22"
                                                            Display="Dynamic"
                                                            CssClass="error"
                                                            ErrorMessage="Enter a description."
                                                            InitialValue=""
                                                            ControlToValidate="tbDescription" />
                                                            <div style="margin-bottom: 20px;" />
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
                        </div>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </div>
    </div>
</asp:Content>
