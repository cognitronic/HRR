<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="RatingScale.aspx.cs" Inherits="HRR.Website.RatingScale" %>
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
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server"  Skin="Simple" Transparency="15" />
<div class="three_fourth last_column">
    <br />
    <div class="containerouter" id="divQuestions" runat="server">
        <div class="containerinner">
            <h3>
                <idea:Label
                runat="server"
                ID="lblTitle" />
            </h3>
            <div style="margin: 5px;">
                <telerik:RadGrid
                runat="server"
                ID="rgList"
                AllowPaging="True"
                AutoGenerateColumns="false"
                AllowSorting="True" 
                OnItemCommand="ItemCommand"
                OnItemCreated="ItemCreated"
                GridLines="None"
                Width="680px" 
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
                    CommandItemSettings-AddNewRecordText="Add New Step"
                    NoMasterRecordsText="No Steps Found.">
                        <Columns>
                            <telerik:GridTemplateColumn 
                            DataField="Title" 
                            HeaderText="Title" 
                            UniqueName="Title">
                                <ItemTemplate>
                                    <%# Eval("Title")%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <idea:TextBox
                                    runat="server"
                                    ID="tbTitle"
                                    Text='<%# Eval("Title") %>'
                                    Width="600px" />
                                <div style="margin: 5px 0px;">
                                    <asp:RequiredFieldValidator
                                    runat="server"
                                    ID="rfvManager"
                                    InitialValue=""
                                    Display="Dynamic"
                                    CssClass="error"
                                    ControlToValidate="tbTitle"
                                    ErrorMessage="Enter Scale Title" />
                                </div>
                                </EditItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn 
                            DataField="Value" 
                            HeaderText="Value" 
                            SortExpression="Value"
                            UniqueName="Value">
                                <ItemTemplate>
                                    <%#Eval("Value")%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <idea:TextBox
                                    runat="server"
                                    ID="tbValue"
                                    Text='<%# Eval("Value") %>'
                                    Width="60px" />
                                    <div style="margin: 5px 0px;">
                                        <asp:RequiredFieldValidator
                                        runat="server"
                                        ID="rfvval"
                                        InitialValue=""
                                        Display="Dynamic"
                                        CssClass="error"
                                        ControlToValidate="tbValue"
                                        ErrorMessage="Enter Value As Integer" />
                                    </div>
                                    <div style="margin: 5px 0px;">
                                        <asp:RegularExpressionValidator
                                        runat="server"
                                        ID="rfvreg"
                                        InitialValue=""
                                        Display="Dynamic"
                                        CssClass="error"
                                        ControlToValidate="tbValue"
                                        ValidationExpression="\d*"
                                        ErrorMessage="Enter Valid Integer" />
                                    </div>
                                    <div style="margin-bottom: 20px;">&nbsp;</div>
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
                                        ToolTip="Edit Question"
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
                                        ToolTip="Delete Question"
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
</asp:Content>
