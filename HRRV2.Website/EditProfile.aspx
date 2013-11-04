<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="HRRV2.Website.EditProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<telerik:RadAjaxManagerProxy ID="rampComments" runat="server" >
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="lbSaveDocument">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgDocuments" LoadingPanelID="RadAjaxLoadingPanel1"/>
            </UpdatedControls>
        </telerik:AjaxSetting>
        <%--<telerik:AjaxSetting AjaxControlID="divtabs">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="divtabs" LoadingPanelID="RadAjaxLoadingPanel1"/>
            </UpdatedControls>
        </telerik:AjaxSetting>--%>
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
        <telerik:AjaxSetting AjaxControlID="rgNote">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgNote"/>
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
    <script type="text/javascript">
        setCurrentMenuItem("nav-people", "");
    </script>
    <div class="semi-block">
         <h5><i class="icon-th-large"></i>Staff Profile</h5>
        <div runat="server" id="divtabs" class="page-tabs"><!-- fade tabs -->
            <div class="tabbable">
                <ul class="nav nav-tabs">
                    <li class="active">
                        <a href="#tabinfo" data-toggle="tab">
                            <i class="icon-info-sign"></i>
                            Info
                        </a>
                    </li>
                    <li>
                        <a href="#tabdocuments" data-toggle="tab">
                            <i class="icon-file"></i>Documents</a>
                    </li>
                    <li>
                        <a href="#tababsences" data-toggle="tab">
                            <i class="icon-plane"></i>Absences</a>
                    </li>
                    <li>
                        <a href="#tabnotes" data-toggle="tab">
                            <i class="icon-pencil"></i>Notes</a>
                    </li>
                </ul>
                <div class="tab-content">
                    <div class="tab-pane active fade in" id="tabinfo">
                        <div id="divcontainer" class="row-fluid">
                            <div runat="server" id="divHROnly">
                                <div class="control-group clearfix">
                                    <div class="checkbox inline">
                                        <label class="control-label">
                                            Is Active?:
                                        </label>
                                        <div class="controls">
                                           <idea:CheckBox
                                            runat="server"
                                            ID="cbIsActive" />
                                        </div>
                                    </div>
                                    <div class="checkbox inline">
                                        <label class="control-label">
                                            Is Manager?:
                                        </label>
                                        <div class="controls">
                                            <idea:CheckBox
                                            runat="server"
                                            ID="cbIsManager" />
                                        </div>
                                    </div>
                                    <div class="checkbox inline">
                                        <label class="control-label">
                                            Can Receive Notifications?:
                                        </label>
                                        <div class="controls">
                                            <idea:CheckBox
                                            runat="server"
                                            ID="cbReceivesNotifications" />
                                        </div>
                                    </div>
                                </div>
                                <div class="control-group clearfix">
                                    <div class="span12">
                                        <label class="control-label">
                                            Hire Date:
                                            <span class="req">*</span>
                                        </label>
                                        <div class="controls">
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
                                    </div>
                                </div>
                                <div class="control-group clearfix">
                                    <div class="span12">
                                        <label class="control-label">
                                            Termination Date:
                                            <span class="req">*</span>
                                        </label>
                                        <div class="controls">
                                            <telerik:RadDatePicker 
                                            ID="tbTerminationDate"
                                            Skin="Metro"
                                            MinDate="1/1/1970"
                                            runat="server">
                                                <DateInput ID="diTerminationDate" runat="server"
                                                    DateFormat="MM/dd/yyyy"></DateInput>
                                            </telerik:RadDatePicker>
                                        </div>
                                    </div>
                                </div>
                                <div class="control-group clearfix">
                                    <div class="span12">
                                        <label class="control-label">
                                            Security Role:
                                            <span class="req">*</span>
                                        </label>
                                        <div class="controls">
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
                            <div class="control-group clearfix">
                                <div class="span12">
                                    <label class="control-label">
                                        First Name:
                                        <span class="req">*</span>
                                    </label>
                                    <div class="controls">
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
                                </div>
                            </div>
                            <div class="control-group clearfix">
                                <div class="span12">
                                    <label class="control-label">
                                        Last Name:
                                        <span class="req">*</span>
                                    </label>
                                    <div class="controls">
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
                                </div>
                            </div>
                            <div class="control-group clearfix">
                                <div class="span12">
                                    <label class="control-label">
                                        Email:
                                        <span class="req">*</span>
                                    </label>
                                    <div class="controls">
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
                                </div>
                            </div>
                            <div class="control-group clearfix">
                                <div class="span12">
                                    <label class="control-label">
                                        Birthdate:
                                    </label>
                                    <div class="controls">
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
                                </div>
                            </div>
                            <div class="control-group clearfix">
                                <div class="span12">
                                    <label class="control-label">
                                        Department:
                                    </label>
                                    <div class="controls">
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
                                </div>
                            </div>
                            <div class="control-group clearfix">
                                <div class="span6">
                                    <label class="control-label">
                                        Manager:
                                    </label>
                                    <div class="controls">
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
                                </div>
                            </div>
                            <div class="control-group clearfix">
                                <div class="span6">
                                    <label class="control-label">
                                        Password:
                                    </label>
                                    <div class="controls">
                                        <idea:TextBox
                                        runat="server"
                                        ID="tbPassword"
                                        Width="450px" />
                                    </div>
                                </div>
                            </div>
                            <div class="control-group clearfix">
                                <div class="span6">
                                    <label class="control-label">
                                        Security Question:
                                        <span class="req">*</span>
                                    </label>
                                    <div class="controls">
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
                                </div>
                            </div>
                            <div class="control-group clearfix">
                                <div class="span6">
                                    <label class="control-label">
                                        Security Answer:
                                    </label>
                                    <div class="controls">
                                        <idea:TextBox
                                        runat="server"
                                        ID="tbSecurityAnswer"
                                        Width="450px" />
                                    </div>
                                </div>
                            </div>
                            <div class="control-group clearfix">
                                <div class="span12">
                                    <label class="control-label">
                                        Profile Pic:
                                    </label>
                                    <div class="controls">
                                        <telerik:RadAsyncUpload 
                                        runat="server" 
                                        ID="radAsyncUpload" 
                                        AllowedFileExtensions="jpg,jpeg,png,gif"
                                        MaxFileSize="1048576"
                                        OverwriteExistingFiles="false" 
                                        OnValidatingFile="RadAsyncUpload1_ValidatingFile">
                                        </telerik:RadAsyncUpload>
                                    </div>
                                </div>
                            </div>
                            <div class="form-actions">
                                <span>
                                    <idea:LinkButton
                                    runat="server"
                                    OnClick="SaveClicked"
                                    ID="lbSave"
                                    CssClass="btn btn-small btn-info">
                                        Save
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
                            </div>
                        </div>
                    </div>
                    <div class="tab-pane fade" id="tabdocuments">
                        <div id="divDocumentsContainer" runat="server" class="row-fluid">
                            <div class="control-group clearfix">
                                <div class="checkbox inline">
                                    <label class="control-label">
                                        Is Document Private (HR Only):
                                    </label>
                                    <div class="controls">
                                        <idea:CheckBox
                                        runat="server"
                                        ID="cbIsPrivate" />
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
                                        ID="tbDocumentTitle"
                                        Width="400px" />
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
                                        ID="tbDocumentDescription"
                                        TextMode="MultiLine"
                                        Width="400px"
                                        Height="50px" />
                                    </div>
                                </div>
                            </div>
                            <div class="control-group clearfix">
                                <div class="span12">
                                    <label class="control-label">
                                        Upload File:
                                        <span class="req">*</span>
                                    </label>
                                    <div class="controls">
                                        <telerik:RadAsyncUpload 
                                        runat="server" 
                                        ID="rauDocument" 
                                        AllowedFileExtensions="jpg,jpeg,png,gif,doc,docx,xls,xlsx,pdf"
                                        MaxFileSize="10048576"
                                        OverwriteExistingFiles="false" 
                                        OnValidatingFile="RadAsyncUpload1_ValidatingFile">
                                        </telerik:RadAsyncUpload>
                                    </div>
                                </div>
                            </div>
                            <div class="form-actions">
                                <span>
                                    <idea:LinkButton
                                    runat="server"
                                    OnClick="SaveDocumentClicked"
                                    ID="lbSaveDocument"
                                    CssClass="btn btn-small btn-info">
                                        Save
                                    </idea:LinkButton>
                                </span>&nbsp;
                                <span>
                                    <idea:LinkButton
                                    runat="server"
                                    OnClick="CancelDocumentClicked"
                                    CausesValidation="false"
                                    ID="lb"
                                    CssClass="btn btn-small btn-danger">
                                        Cancel
                                    </idea:LinkButton>
                                </span>
                            </div>
                            <div class="control-group clearfix">
                                <div class="span12">
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
                                                        OnClientClick="return confirm('Are you sure you want to delete this record?')"
                                                        CssClass="btn btn-small btn-danger"
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
                    <div class="tab-pane fade" id="tababsences">
                        <div id="divAbsencesContent" runat="server" class="row-fluid">
                            <div class="control-group clearfix">
                                <div class="checkbox inline">
                                    <label class="control-label">
                                        Reason For Absence:
                                    </label>
                                    <div class="controls">
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
                                </div>
                            </div>
                            <div class="control-group clearfix">
                                <div class="span12">
                                    <label class="control-label">
                                        From:
                                    </label>
                                    <div class="controls">
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
                                </div>
                            </div>
                            <div class="control-group clearfix">
                                <div class="span12">
                                    <label class="control-label">
                                        To:
                                    </label>
                                    <div class="controls">
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
                                </div>
                            </div>
                            <div class="control-group clearfix">
                                <div class="span12">
                                    <label class="control-label">
                                        Note:
                                        <span class="req">*</span>
                                    </label>
                                    <div class="controls">
                                        <idea:TextBox
                                        runat="server"
                                        ID="tbAbsenceNote"
                                        TextMode="MultiLine"
                                        Width="400px"
                                        Height="50px" />
                                    </div>
                                </div>
                            </div>
                            <div class="form-actions">
                                <span>
                                    <idea:LinkButton
                                    runat="server"
                                    OnClick="SaveAbsenceClicked"
                                    ID="lbSaveAbsence"
                                    ValidationGroup="vgAbsence"
                                    CssClass="btn btn-small btn-info">
                                        Save
                                    </idea:LinkButton>
                                </span>&nbsp;
                                <span>
                                    <idea:LinkButton
                                    runat="server"
                                    OnClick="CancelAbsenceClicked"
                                    CausesValidation="false"
                                    ID="lbCancelAbsence"
                                    CssClass="btn btn-small btn-danger">
                                        Cancel
                                    </idea:LinkButton>
                                </span>
                            </div>
                            <div class="control-group clearfix">
                                <div class="span12">
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
                    <div class="tab-pane fade" id="tabnotes">
                        <div id="divNoteContent" runat="server" class="row-fluid">
                            <div class="control-group clearfix">
                                <div class="checkbox inline">
                                    <label class="control-label">
                                        Note Type:
                                    </label>
                                    <div class="controls">
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
                                </div>
                            </div>
                            <div class="control-group clearfix">
                                <div class="span12">
                                    <label class="control-label">
                                        Note:
                                    </label>
                                    <div class="controls">
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
                                </div>
                            </div>
                            <div class="form-actions">
                                <span>
                                    <idea:LinkButton
                                    runat="server"
                                    OnClick="SaveNoteClicked"
                                    ID="lbNoteSave"
                                    CssClass="btn btn-small btn-info">
                                        Save
                                    </idea:LinkButton>
                                </span>&nbsp;
                                <span>
                                    <idea:LinkButton
                                    runat="server"
                                    OnClick="CancelDocumentClicked"
                                    CausesValidation="false"
                                    ID="LinkButton3"
                                    CssClass="btn btn-small btn-danger">
                                        Cancel
                                    </idea:LinkButton>
                                </span>
                            </div>
                            <div class="control-group clearfix">
                                <div class="span12">
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
                                                            CssClass="btn btn-small btn-success"
                                                            CommandName="Edit"
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
                                                            CssClass="btn btn-small btn-danger"
                                                            CommandName="Delete"
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
                </div>
            </div>
        </div>
    </div>
</asp:Content>
