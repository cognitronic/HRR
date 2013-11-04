<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GoalMilestoneView.ascx.cs" Inherits="HRR.Website.Views.GoalMilestoneView" %>
<telerik:RadAjaxManagerProxy ID="ramp" runat="server" >
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="divMSVContainer">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="divMSVContainer" LoadingPanelID="RadAjaxLoadingPanel1"/>
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server"  Skin="Simple" Transparency="15" />
<div runat="server" id="divMSVContainer" style="overflow:auto;">
    <div class="containerouter">
        <div class="containerinner" style="padding-bottom: 10px;">
            <h3 style="display:inline !important;">
                <idea:Label
                runat="server"
                ID="lblTitle" />
            </h3>
            <div style="float: right;">
                <div>
                    <span style="font-weight: bold;">Milestone Completed:</span>
                    <span>
                    <idea:CheckBox

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
                width="150px"
                runat="server">
                    <DateInput ID="diMilestoneDueDate" runat="server"
                        DateFormat="MM/dd/yyyy"></DateInput>
                </telerik:RadDatePicker>
                <asp:RequiredFieldValidator
                runat="server"
                ID="rfvMilestonduedate"
                Display="Dynamic"
                CssClass="alert"
                ErrorMessage="Select a date."
                InitialValue=""
                ControlToValidate="tbMilestoneDueDate" />
            </div>
            <div>
                <div>Title:</div>
                <idea:TextBox
                runat="server"
                Skin="Metro"
                ID="tbTitle"
                Width="690px" />
            </div>
            <div>
                <div>Description:</div>
                <idea:TextBox
                runat="server"
                Skin="Metro"
                TextMode="MultiLine"
                Height="100px"
                ID="tbDescription"
                Width="690px" />
            </div>
            <div>
                <div>Self Evaluation:</div>
                <idea:TextBox
                runat="server"
                Skin="Metro"
                TextMode="MultiLine"
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
                Height="100px"
                ID="tbManagerEvaluation"
                Width="690px" />
            </div>
            <div style="clear: both; margin-top: 35px; margin-bottom: 25px;">
                <span runat="server" id="spnSave">
                    <idea:LinkButton
                    runat="server"
                    OnClick="SaveMilestoneClicked"
                    ID="lbSaveMilestone"
                    CssClass="button big round sky-blue">
                        Save 
                    </idea:LinkButton>
                </span>&nbsp;
                <span runat="server" id="spnUpdate">
                    <idea:LinkButton
                    runat="server"
                    OnClick="SaveMilestoneClicked"
                    CausesValidation="false"
                    ID="lbUpdate"
                    CssClass="button big round sky-blue">
                        Update
                    </idea:LinkButton>
                </span>&nbsp;
                <span>
                    <idea:LinkButton
                    runat="server"
                    OnClick="CancelMilestoneClicked"
                    CausesValidation="false"
                    ID="lbCancelMilestone"
                    CssClass="button big round sky-blue">
                        Cancel
                    </idea:LinkButton>
                </span>
            </div>
        </div>
    </div>
</div>