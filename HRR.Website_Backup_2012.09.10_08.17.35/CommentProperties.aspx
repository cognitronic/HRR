<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="CommentProperties.aspx.cs" Inherits="HRR.Website.CommentProperties" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<telerik:RadAjaxManagerProxy ID="rampComments" runat="server" >
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="lbSaveResponse">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="dlResponses"  LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server"  Skin="Simple" Transparency="15" />
    <div class="three_fourth last_column">
        <div style="clear: both;" />
        <div class="containerouter">
            <div class="containerinner">
                <h4>
                    Comment Entered For: <idea:LinkButton OnClick="EnteredForClicked" runat="server" ID ="lbEnteredFor" />
                </h4>
                <div>
                    <table id="tblComment" style="width: 700px; margin-bottom: 5px;">
                        <tr>
                            <td>
                                ID:
                            </td>
                            <td>
                                <idea:Label
                                runat="server"
                                ID="lblCommentID"
                                CssClass="orange" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Entered By:
                            </td>
                            <td>
                                <idea:Label
                                CssClass="blueText"
                                ID="lblEnteredBy"
                                runat="server" />
                            </td>
                            <td>
                                Date Created: 
                            </td>
                            <td>
                                <idea:Label
                                CssClass="blueText"
                                ID="lblDateCreated"
                                runat="server" />
                            </td>
                        </tr>
                        
                        <tr>
                            <td>
                                Changed By:
                            </td>
                            <td>
                                <idea:Label
                                CssClass="blueText"
                                ID="lblChangedBy"
                                runat="server" />
                            </td>
                            <td>
                                Last Updated: 
                            </td>
                            <td>
                                <idea:Label
                                CssClass="blueText"
                                ID="lblLastUpdated"
                                runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Comment Type:
                            </td>
                            <td>
                                <idea:Label
                                CssClass="blueText"
                                ID="lblCommentType"
                                runat="server" />
                            </td>
                            <td>
                                Team: 
                            </td>
                            <td>
                                <idea:Label
                                CssClass="blueText"
                                ID="lblTeam"
                                runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Category:
                            </td>
                            <td>
                                <idea:Label
                                CssClass="blueText"
                                ID="lblCategory"
                                runat="server" />
                            </td>
                            <td>
                                Is Flagged: 
                            </td>
                            <td>
                                <idea:Label
                                CssClass="blueText"
                                ID="lblFlagged"
                                runat="server" />&nbsp;&nbsp;
                                <idea:LinkButton
                                runat="server"
                                ID="lbReportPost"
                                CausesValidation="false"
                                OnClick="ReportPostClicked"
                                postid='<%# Eval("ID").ToString() %>'>
                                </idea:LinkButton>
                            </td>
                        </tr>
                        <tr runat="server" id="trFollowUp">
                            <td style="vertical-align: top;">
                                Follow Up Date:<br />
                                <span style="margin-top: -5px;">
                                    <idea:LinkButton
                                    runat="server"
                                    ID="lbExportDate"
                                    OnClick="ExportToCalendar">
                                        export to Outlook
                                    </idea:LinkButton>
                                </span>
                            </td>
                            <td>
                                <telerik:RadDatePicker 
                                ID="tbFollowUpDate"
                                Skin="Metro"
                                width="150px"
                                runat="server">
                                    <DateInput ID="diFollowUpDate" runat="server"
                                        DateFormat="MM/dd/yyyy"></DateInput>
                                </telerik:RadDatePicker>
                            </td>
                            <td style="vertical-align: top;">
                                Follow Up Resolution: 
                            </td>
                            <td >
                                <idea:TextBox
                                CssClass="blueText"
                                Width="200px"
                                Height="50px"
                                TextMode="MultiLine"
                                ID="tbFollowUpResolution"
                                runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>Comment:</td>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <idea:Label
                                runat="server"
                                ID="lblComment"
                                TextMode="MultiLine"
                                ReadOnly="true"
                                CssClass="blueText" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div runat="server" id="divUpdateComment" style="clear: both; margin-top: 35px;">
                    <span>
                        <idea:LinkButton
                        runat="server"
                        OnClick="UpdateCommentClicked"
                        ID="lbUpdateComment"
                        CssClass="button big round sky-blue">
                            Update Comment
                        </idea:LinkButton>
                    </span>&nbsp;&nbsp;
                    <span>
                        <idea:LinkButton
                        runat="server"
                        OnClick="CancelResponseClicked"
                        ID="lbCancelComment"
                        CssClass="button big round sky-blue">
                            Cancel
                        </idea:LinkButton>
                    </span>
                </div><br /><br />
                
            </div>
        </div>
    </div>
    <div class="three_fourth last_column">
        <div class="containerouter" id="divCommunication" runat="server">
            <div class="containerinner">
                <h3 style="display:inline !important;">Post A Response</h3>
                <div>
                    <div>
                        <idea:TextBox
                        runat="server"
                        ID="tbNewResponse"
                        TextMode="MultiLine"
                        Height="50px"
                        Width="690px" />
                        <asp:RequiredFieldValidator
                        runat="server"
                        ID="rfvNewResponse"
                        CssClass="error"
                        InitialValue=""
                        Display="Dynamic"
                        ErrorMessage="Enter a response."
                        ControlToValidate="tbNewResponse"
                        ValidationGroup="vgResponse">
                        </asp:RequiredFieldValidator>
                    </div>
                </div>
                <div style="clear: both; margin-top: 35px;">
                    <span>
                        <idea:LinkButton
                        runat="server"
                        OnClick="SaveResponseClicked"
                        ID="lbSaveResponse"
                        ValidationGroup="vgResponse"
                        CssClass="button big round sky-blue">
                            Save Response
                        </idea:LinkButton>
                    </span>&nbsp;&nbsp;
                    <span>
                        <idea:LinkButton
                        runat="server"
                        OnClick="CancelResponseClicked"
                        ID="lbCancelResponse"
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
                    OnItemDataBound="ResponseItemDataBound"
                    ID="dlResponses">
                        <HeaderTemplate>
                            <h3>Responses</h3>
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
    </div>
</asp:Content>
