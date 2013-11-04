<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="Poll.aspx.cs" Inherits="HRR.Website.Poll" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<telerik:RadAjaxManagerProxy ID="ramp" runat="server" >
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="rgList">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgList" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="divEditable">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="divEditable" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server"  Skin="Simple" Transparency="15" />

<div class="three_fourth last_column">
    <br />
    <div class="containerouter">
        <div class="containerinner">
            <h3 style="display:inline !important;">Manage Poll</h3>
            <%--<div>
                <div>Is Active:</div>
                <idea:CheckBox
                runat="server"
                Skin="Metro"
                ID="cbIsActive" />
            </div>--%>
            <div>
                <div>Question:</div>
                <idea:TextBox
                runat="server"
                TextMode="MultiLine"
                Height="30px"
                Skin="Metro"
                ID="tbQuestion"
                Width="690px" />
                <asp:RequiredFieldValidator
                runat="server"
                ID="RequiredFieldValidator2"
                CssClass="error"
                ControlToValidate="tbQuestion"
                InitialValue=""
                ErrorMessage="Enter a question"
                Display="Dynamic" />
            </div>
            <%--<div>
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
                ID="RequiredFieldValidator1"
                Display="Dynamic"
                CssClass="error"
                ErrorMessage="Select a date."
                InitialValue=""
                ControlToValidate="tbStartDate" />
            </div>
            <div>
                <div>End Date:</div>
                <telerik:RadDatePicker 
                ID="tbEndDate"
                Skin="Metro"
                Height="25px"
                width="150px"
                runat="server">
                    <DateInput ID="diEndDate" runat="server"
                        DateFormat="MM/dd/yyyy"></DateInput>
                </telerik:RadDatePicker>
                <asp:RequiredFieldValidator
                runat="server"
                ID="RequiredFieldValidator3"
                Display="Dynamic"
                CssClass="error"
                ErrorMessage="Select a date."
                InitialValue=""
                ControlToValidate="tbEndDate" />
            </div>--%><br />
            <div style="margin-bottom: 20px;">
                <span>
                    <idea:LinkButton
                    runat="server"
                    OnClick="SaveClicked"
                    ID="lbSave"
                    CssClass="button big round sky-blue">
                        Save Poll
                    </idea:LinkButton>
                </span>&nbsp;
                <span>
                    <idea:LinkButton
                    runat="server"
                    OnClick="CancelClicked"
                    ID="lbCancel"
                    CausesValidation="false"
                    CssClass="button big round sky-blue">
                        Cancel
                    </idea:LinkButton>
                </span>
            </div>
        </div>
    </div>
    <br />
    <div class="containerouter" id="divOptions" runat="server">
        <div class="containerinner">
            <h3>Options</h3>
            <div style="margin: 5px;">
                    <telerik:RadGrid
                    runat="server"
                    ID="rgList"
                    AllowPaging="True"
                    AutoGenerateColumns="false"
                    AllowSorting="True" 
                    OnItemCommand="ItemCommand"
                    OnItemCreated="ItemCreated"
                    OnItemDataBound="ItemDataBound"
                    GridLines="None"
                    Width="690px" 
                    ShowStatusBar="true"
                    OnNeedDataSource="NeedDataSource"
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
                        CommandItemSettings-AddNewRecordText="Add New Option"
                        NoMasterRecordsText="No Options Found.">
                            <Columns>
                                <telerik:GridTemplateColumn 
                                DataField="Title" 
                                HeaderText="Option Text" 
                                UniqueName="Title">
                                    <ItemTemplate>
                                        <%# Eval("Title")%>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <idea:TextBox
                                        runat="server"
                                        ID="tbTitle"
                                        TextMode="MultiLine"
                                        Height="40px"
                                        Text='<%# Eval("Title") %>'
                                        Width="600px" />
                                    <div style="margin: 10px 0px;" />
                                        <asp:RequiredFieldValidator
                                        runat="server"
                                        ID="rfvQuestion"
                                        InitialValue=""
                                        Display="Dynamic"
                                        CssClass="error"
                                        ControlToValidate="tbTitle"
                                        ErrorMessage="Enter Option Text" />
                                    </div>
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
                                            ToolTip="Edit Option"
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
                                            ToolTip="Delete Option"
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

    <div runat="server" id="divEditable" class="three_fourth last_column">
        <div style="clear: both;" />
        <div class="containerouter">
            <div class="containerinner">
                <h3>
                    Send Poll Notification
                </h3><br />
                <div>
                    Send To Everyone?:
                    <idea:CheckBox
                    runat="server"
                    AutoPostBack="true"
                    ID="cbSendToEveryone"
                    OnCheckedChanged="CheckChanged" />
                </div>
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
                                                <%# DataBinder.Eval(Container.DataItem, "Email").ToString().StartsWith("team:") ? DataBinder.Eval(Container.DataItem, "Name").ToString() + "<span style='font-weight: bold;'> - TEAM</span>" : DataBinder.Eval(Container.DataItem, "Name")%>
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
</asp:Content>
