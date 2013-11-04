<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="Polls.aspx.cs" Inherits="HRR.Website.Polls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<telerik:RadAjaxManagerProxy ID="ramScales" runat="server" >
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
        <div class="containerouter">
            <div class="containerinner">
                <h3 style="display:inline !important;">Manage Polls</h3>
                <div style="margin-bottom: 20px;">
                    <telerik:RadGrid
                    runat="server"
                    ID="rgList"
                    AllowPaging="True"
                    AutoGenerateColumns="false"
                    AllowSorting="True" 
                    OnItemDataBound="ItemDataBound"
                    OnItemCommand="ItemCommand"
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
                        CommandItemSettings-AddNewRecordText="Add New Poll"
                        NoMasterRecordsText="No Polls Found.">
                            <Columns>
                                <telerik:GridTemplateColumn 
                                DataField="Question" 
                                HeaderText="Question" 
                                UniqueName="Question">
                                    <ItemTemplate>
                                        <%# Eval("Question")%>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn 
                                DataField="TotalPolled" 
                                HeaderText="Total Polled" 
                                UniqueName="TotalPolled">
                                    <ItemTemplate>
                                        <%# Eval("TotalPolled")%>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn 
                                HeaderText="Total Responses" 
                                UniqueName="Results.Count">
                                    <ItemTemplate>
                                        <idea:Label
                                        runat="server"
                                        itemid='<%# Eval("ID") %>'
                                        ID="lblResponses" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <%--<telerik:GridTemplateColumn
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
                                            ToolTip="Edit Poll"
                                            ImageUrl="~/Images/pencil.png"
                                            Style="border: none;" />
                                        </idea:LinkButton>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>--%>
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
                                            ToolTip="Delete Poll"
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
