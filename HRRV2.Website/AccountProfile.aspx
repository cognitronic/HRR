<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="AccountProfile.aspx.cs" Inherits="HRRV2.Website.AccountProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:RadAjaxManagerProxy ID="rampComments" runat="server" >
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="lbSaveAccount">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="divcontainer" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Simple" Transparency="15" />
    <script type="text/javascript">
        setCurrentMenuItem("nav-settings", "subnav-accountprofile");
    </script>

    <div class="page-header">
        <h5><i class="icon-th-large"></i>Account Profile</h5>
    </div>
    <div class="body">
        <div runat="server" id="divcontainer">
            <div class="control-group clearfix">
                <div class="span12">
                    <label class="control-label">
                        Company Name:
                        <span class="req">*</span>
                    </label>
                    <div class="controls">
                        <idea:TextBox
                        runat="server"
                        ID="tbCompanyName"
                        Width="500"
                        Skin="Metro" />
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
            </div>
            <div class="control-group clearfix">
                <div class="span12">
                    <label class="control-label">
                        Domain Name:
                        <span class="req">*</span>
                    </label>
                    <div class="controls">
                        <idea:TextBox
                        runat="server"
                        ID="tbDomain"
                        Width="500"
                        Skin="Metro" />
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
            </div>
            <div class="control-group clearfix">
                <div class="span12">
                    <div class="controls">
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
                </div>
            </div>
            <div class="page-header">
                <h5><i class="icon-th-large"></i>Default Weighted Review Values</h5>
            </div>
            <div class="control-group clearfix">
                <div class="span12">
                    <label class="control-label">
                        Goals:
                    </label>
                    <div class="controls">
                        <telerik:RadNumericTextBox
                        runat="server"
                        ShowSpinButtons="false"
                        NumberFormat-DecimalDigits="0"
                        ID="tbGoalsWeight"/>
                    </div>
                </div>
            </div>
            <div class="control-group clearfix">
                <div class="span12">
                    <label class="control-label">
                        Comments:
                    </label>
                    <div class="controls">
                        <telerik:RadNumericTextBox
                        runat="server"
                        ShowSpinButtons="false"
                        NumberFormat-DecimalDigits="0"
                        ID="tbCommentsWeight"/>
                    </div>
                </div>
            </div>
            <div class="control-group clearfix">
                <div class="span12">
                    <label class="control-label">
                        Questions:
                    </label>
                    <div class="controls">
                        <telerik:RadNumericTextBox
                        runat="server"
                        ShowSpinButtons="false"
                        NumberFormat-DecimalDigits="0"
                        ID="tbQuestionsWeight"/>
                    </div>
                </div>
            </div>
            <div class="form-actions">
                <span>
                    <idea:LinkButton
                    runat="server"
                    ValidationGroup="vgProfile"
                    OnClick="SaveAccountClicked"
                    ID="lbSaveAccount"
                    CssClass="btn btn-small btn-info">
                        Save
                    </idea:LinkButton>
                </span>&nbsp;
                <span>
                    <idea:LinkButton
                    runat="server"
                    OnClick="CancelAccountClicked"
                    CausesValidation="false"
                    ID="lbCancelAccount"
                    CssClass="btn btn-small btn-danger">
                        Cancel
                    </idea:LinkButton>
                </span>
            </div>
        </div>
    </div>
</asp:Content>
