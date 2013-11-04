<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" ValidateRequest="false" AutoEventWireup="true" CodeBehind="Message.aspx.cs" Inherits="HRR.Website.Message" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadAjaxManagerProxy ID="ramp" runat="server" >
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="divEditable">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="divReadOnly" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="divEditable">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="divEditable" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="divReadOnly">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="divReadOnly" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="divReadOnly">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="divEditable"/>
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server"  Skin="Simple" Transparency="15" />
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
                    ID="tbTo"
                    DataTextField="Name" 
                    DataValueField="Email"  
                    Width="690px" 
                    DropDownHeight="400"
                    DropDownWidth="375"
                    Skin="Metro" >
                        <DropDownItemTemplate>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td align="left" style="width: 50px; padding-left: 10px; padding-bottom: 10px;">
                                            <telerik:RadBinaryImage                                                                ID="RadBinaryImage1" 
                                            runat="server" 
                                            AlternateText="Profile Photo"
                                            ToolTip="Profile Photo" 
                                            Height="50px"
                                            Width="50px"
                                            ResizeMode="Fit"
                                            ImageUrl='<%# HRR.Core.ResourceStrings.AvatarBasePath + "thumb_" + DataBinder.Eval(Container.DataItem, "AvatarPath") %>'/>
                                        </td>
                                        <td align="left" style="width: 630px; padding-left: 10px; vertical-align: top;">
                                            <span style="color: #000000; font-weight: bold;">
                                            Name:
                                            </span>
                                                <%# DataBinder.Eval(Container.DataItem, "Email").ToString().StartsWith("team:") ? DataBinder.Eval(Container.DataItem, "Name").ToString() + "<span style='font-weight: bold;'> - TEAM</span>" : DataBinder.Eval(Container.DataItem, "Name") %>
                                            </span>
                                            <br />
                                            <span style="color: #000000; font-weight: bold;">
                                            Department:
                                            </span>
                                                <%# DataBinder.Eval(Container.DataItem, "DepartmentName")%>
                                            </span>
                                            <br />
                                            <span style="color: #000000; font-weight: bold;">
                                            Title:
                                            </span>
                                                <%# DataBinder.Eval(Container.DataItem, "Title")%>
                                            </span>
                                        </td>
                                    </tr>
                                </table>
                            </DropDownItemTemplate>
                    </telerik:RadAutoCompleteBox> 
                    
                </div>
                <div>
                    <div>Cc:</div>
                    <telerik:RadAutoCompleteBox 
                    runat="server" 
                    ID="tbCc"
                    DataTextField="Name" 
                    DataValueField="Email"  
                    Width="690px" 
                    DropDownHeight="400"
                    DropDownWidth="375"
                    Skin="Metro" >
                        <DropDownItemTemplate>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td align="left" style="width: 25%; padding-left: 10px;">
                                            <telerik:RadBinaryImage                                                                ID="RadBinaryImage1" 
                                            runat="server" 
                                            AlternateText="Profile Photo"
                                            ToolTip="Profile Photo"
                                            Height="50px"
                                            Width="50px"
                                            ResizeMode="Fit"
                                            ImageUrl='<%# HRR.Core.ResourceStrings.AvatarBasePath + "thumb_" + DataBinder.Eval(Container.DataItem, "AvatarPath") %>'/>
                                        </td>
                                        <td align="left" style="width: 75%; padding-left: 10px; vertical-align: top;">
                                            <span style="color: #000000; font-weight: bold;">
                                            Name:
                                            </span>
                                                <%# DataBinder.Eval(Container.DataItem, "Name")%>
                                            </span>
                                            <br />
                                            <span style="color: #000000; font-weight: bold;">
                                            Department:
                                            </span>
                                                <%# DataBinder.Eval(Container.DataItem, "DepartmentName")%>
                                            </span>
                                            <br />
                                            <span style="color: #000000; font-weight: bold;">
                                            Title:
                                            </span>
                                                <%# DataBinder.Eval(Container.DataItem, "Title")%>
                                            </span>
                                        </td>
                                    </tr>
                                </table>
                            </DropDownItemTemplate>
                    </telerik:RadAutoCompleteBox> 
                </div>
                <div>
                    <div>Bcc:</div>
                    <telerik:RadAutoCompleteBox 
                    runat="server" 
                    ID="tbBcc"
                    DataTextField="Name" 
                    DataValueField="Email"  
                    Width="690px" 
                    DropDownHeight="400"
                    DropDownWidth="375"
                    Skin="Metro" >
                        <DropDownItemTemplate>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td align="left" style="width: 25%; padding-left: 10px;">
                                            <telerik:RadBinaryImage                                                                ID="RadBinaryImage1" 
                                            runat="server" 
                                            AlternateText="Profile Photo"
                                            ToolTip="Profile Photo" 
                                            Height="50px"
                                            Width="50px"
                                            ResizeMode="Fit"
                                            ImageUrl='<%# HRR.Core.ResourceStrings.AvatarBasePath + "thumb_" + DataBinder.Eval(Container.DataItem, "AvatarPath") %>'/>
                                        </td>
                                        <td align="left" style="width: 75%; padding-left: 10px; vertical-align: top;">
                                            <span style="color: #000000; font-weight: bold;">
                                            Name:
                                            </span>
                                                <%# DataBinder.Eval(Container.DataItem, "Name")%>
                                            </span>
                                            <br />
                                            <span style="color: #000000; font-weight: bold;">
                                            Department:
                                            </span>
                                                <%# DataBinder.Eval(Container.DataItem, "DepartmentName")%>
                                            </span>
                                            <br />
                                            <span style="color: #000000; font-weight: bold;">
                                            Title:
                                            </span>
                                                <%# DataBinder.Eval(Container.DataItem, "Title")%>
                                            </span>
                                        </td>
                                    </tr>
                                </table>
                            </DropDownItemTemplate>
                    </telerik:RadAutoCompleteBox> 
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
                        ID="lbReplyAll"
                        OnClick="ReplyAllClicked">
                        <img src="/images/replyall.png" alt="" title="Reply" /> 
                            Reply All
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
                    <div style="font-weight: bold;">Cc:</div>
                    <idea:Label
                    runat="server"
                    ID="lblCc"/>
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
                <br /><br />
            </div>
        </div>
    </div>
</asp:Content>
