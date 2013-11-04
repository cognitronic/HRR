<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="GoalTemplate.aspx.cs" Inherits="HRRV2.Website.GoalTemplate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        setCurrentMenuItem("nav-goals", "subnav-goaltemplates");
    </script>
    <div class="semi-block">
         <h5><i class="icon-th-large"></i>Goal Template</h5>
        <div runat="server" id="divtabs" class="page-tabs"><!-- fade tabs -->
            <div class="tabbable">
                <ul class="nav nav-tabs">
                    <li class="active">
                        <a href="#tabdetails" data-toggle="tab">
                            <i class="icon-info-sign"></i>Details</a>
                    </li>
                    <li>
                        <a href="#tabmilestones" data-toggle="tab">
                            <i class="icon-plane"></i>Milestones</a>
                    </li>
                    <li>
                        <a href="#tabsubscribers" data-toggle="tab">
                            <i class="icon-pencil"></i>Subscribers</a>
                    </li>
                </ul>
                <div class="tab-content">
                    <div class="tab-pane active fade in" id="tabdetails">
                        <div id="divDetails" class="row-fluid">
                            <div class="control-group clearfix">
                                <div class="span12">
                                    <label class="control-label">
                                        Due Date:
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
                                    ID="lbSave"
                                    CssClass="btn btn-small btn-info">
                                        Save
                                    </idea:LinkButton>
                                </span>&nbsp;
                                <span>
                                    <idea:LinkButton
                                    runat="server"
                                    CausesValidation="false"
                                    ID="lbCancel"
                                    CssClass="btn btn-small btn-danger">
                                        Cancel
                                    </idea:LinkButton>
                                </span>
                            </div>
                        </div>
                    </div>
                    <div class="tab-pane fade" id="tabmilestones">
                        <div id="divMilestones" runat="server" class="row-fluid">
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
                            <div class="form-actions">
                                <span>
                                    <idea:LinkButton
                                    runat="server"
                                    ID="lbSaveDocument"
                                    CssClass="btn btn-small btn-info">
                                        Save
                                    </idea:LinkButton>
                                </span>&nbsp;
                                <span>
                                    <idea:LinkButton
                                    runat="server"
                                    CausesValidation="false"
                                    ID="lb"
                                    CssClass="btn btn-small btn-danger">
                                        Cancel
                                    </idea:LinkButton>
                                </span>
                            </div>
                        </div>
                    </div>
                    <div class="tab-pane fade" id="tabsubscribers">
                        <div id="divSubscribers" runat="server" class="row-fluid">
                            
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
