<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="Message.aspx.cs" Inherits="HRR.Website.Message" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div runat="server" id="divEditable" class="three_fourth last_column">
        <div style="clear: both;" />
        <div class="containerouter">
            <div class="containerinner">
                <h3>
                    <idea:Label
                    runat="server"
                    ID="lblTitle" />
                </h3><br />
                <div>
                    <div>To:</div>
                    <telerik:RadAutoCompleteBox 
                    runat="server" 
                    ID="RadAutoCompleteBox1" 
                    Width="375" 
                    ="SqlDataSource1" 
                    DataTextField="ContactName" 
                    DataValueField="Email" 
                    Filter="StartsWith" 
                    Skin="Metro" 
                    DropDownHeight="400" 
                    DropDownWidth="375">
                        <DropDownItemTemplate>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td align="left" style="width: 25%; padding-left: 10px;">
                                        <telerik:RadBinaryImage ID="RadBinaryImage1" runat="server" AlternateText="Contact Photo"
                                            ToolTip="Contact Photo" Width="60px" Height="90px" ResizeMode="Fit" DataValue='<%# DataBinder.Eval(Container.DataItem, "Photo")%>' />
                                    </td>
                                    <td align="left" style="width: 75%; padding-left: 10px;">
                                        <%# DataBinder.Eval(Container.DataItem, "ContactName")%>
                                        <br />
                                        <%# DataBinder.Eval(Container.DataItem, "City")%>
                                        ,
                                        <%# DataBinder.Eval(Container.DataItem, "Country")%>
                                    </td>
                                </tr>
                            </table>
                        </DropDownItemTemplate>
                    </telerik:RadAutoCompleteBox> 
                    <idea:TextBox
                    runat="server"
                    ID="tbTo"
                    Width="690px" />
                </div>
                <div>
                    <div>Cc:</div>
                    <idea:TextBox
                    runat="server"
                    ID="tbCc"
                    Width="690px" />
                </div>
                <div>
                    <div>Bcc:</div>
                    <idea:TextBox
                    runat="server"
                    ID="tbBcc"
                    Width="690px" />
                </div>
                <div>
                    <div>Subject:</div>
                    <idea:TextBox
                    runat="server"
                    ID="tbSubject"
                    Width="690px" />
                </div>
                <div>
                    <div>Message:</div>
                    <telerik:RadEditor
                    runat="server"
                    ID="reContent"
                    ContentFilters="MakeUrlsAbsolute,RemoveScripts"
                    EditModes="Design"
                    ToolbarMode="ShowOnFocus"
                    ToolsFile="~/ToolsFile.xml"
                    Skin="Metro"
                    style="overflow: hidden;"
                    Height="250px"
                    Width="695px">
                    <CssFiles>
                        <telerik:EditorCssFile Value="/Styles/editorcontentarea.css" />
                    </CssFiles>
                    </telerik:RadEditor>
                </div>
                <div runat="server" id="divSendMessage" style="clear: both; margin: 35px 0px;">
                    <span>
                        <idea:LinkButton
                        runat="server"
                        OnClick="SendMessageClicked"
                        ID="lbUSendComment"
                        CssClass="button big round sky-blue">
                            Send
                        </idea:LinkButton>
                    </span>&nbsp;&nbsp;
                    <span>
                        <idea:LinkButton
                        runat="server"
                        OnClick="CancelMessageClicked"
                        ID="lbCancelMessage"
                        CssClass="button big round sky-blue">
                            Cancel
                        </idea:LinkButton>
                    </span>
                </div>
            </div>
        </div>
    </div>

    <div runat="server" id="divReadonly" class="three_fourth last_column">
        <div style="clear: both;" />
        <div class="containerouter">
            <div class="containerinner">
                <h3>
                    <idea:Label
                    runat="server"
                    ID="lblReadOnlyTitle" />
                </h3><br />
                <div>
                    <span style="margin-right: 25px;">
                        <idea:LinkButton
                        runat="server"
                        ID="lbReplyMessage"
                        OnClick="ReplyMessageClicked">
                        <img src="/images/mail_send32.png" alt="" title="Reply" /> 
                            Reply
                        </idea:LinkButton>
                    </span>
                    <span style="margin-right: 25px;">
                        <idea:LinkButton
                        runat="server"
                        ID="lbForwardMessage"
                        OnClick="ForwardMessageClicked">
                        <img src="/images/next.png" alt="" title="Forward" /> 
                            Forward
                        </idea:LinkButton>
                    </span>
                    <span style="margin-right: 25px;">
                        <idea:LinkButton
                        runat="server"
                        ID="lbDeleteMessage"
                        OnClick="DeleteMessageClicked">
                        <img src="/images/trash_can32.png" alt="" title="Delete" /> 
                            Delete
                        </idea:LinkButton>
                    </span>
                    <span style="margin-right: 25px;">
                        <idea:LinkButton
                        runat="server"
                        ID="lbArchiveMessage"
                        OnClick="ArchiveMessageClicked">
                        <img src="/images/zip-icon32.png" alt="" title="Archive" />
                            Archive
                        </idea:LinkButton>
                    </span>
                </div>
                <br />
                <div style="padding-bottom: 5px;">
                    <div style="font-weight: bold;">From:</div>
                    <idea:Label
                    runat="server"
                    ID="lblFrom"/>
                </div>
                <div style="padding-bottom: 5px;">
                    <div style="font-weight: bold;">To:</div>
                    <idea:Label
                    runat="server"
                    ID="lblTo"/>
                </div>
                <div style="padding-bottom: 5px;">
                    <div style="font-weight: bold;">Sent:</div>
                    <idea:Label
                    runat="server"
                    ID="lblSent" />
                </div>
                <div style="padding-bottom: 5px;">
                    <div style="font-weight: bold;">Subject:</div>
                    <idea:Label
                    runat="server"
                    ID="lblSubject"/>
                </div>
                <div style="padding-bottom: 5px;">
                    <div style="font-weight: bold;">Message:</div>
                    <idea:Label
                    runat="server"
                    ID="lblMessage"/>>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
