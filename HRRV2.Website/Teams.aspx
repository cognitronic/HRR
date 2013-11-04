<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="Teams.aspx.cs" Inherits="HRRV2.Website.Teams" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:RadAjaxManagerProxy ID="rampComments" runat="server" >
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rgGroups">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgGroups" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Simple" Transparency="15" />
    <script type="text/javascript">
        setCurrentMenuItem("nav-settings", "subnav-teams");
    </script>

    <div class="page-header">
        <h5><i class="icon-th-large"></i>Teams</h5>
    </div>
    <div class="body">
        <div>
            <div runat="server" id="divTeam">
                <div>
                    <telerik:RadGrid
                    runat="server"
                    ID="rgGroups"
                    AllowPaging="True"
                    AutoGenerateColumns="false"
                    AllowSorting="True"
                    OnItemCreated="GroupsItemCreated" 
                    OnItemCommand="GroupsItemCommand"
                    GridLines="None"
                    ShowStatusBar="true"
                    OnNeedDataSource="GroupsNeedDataSource"
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
                        CommandItemSettings-AddNewRecordText="Add New Team"
                        NoMasterRecordsText="No Teams Found.">
                            <Columns>
                                <telerik:GridTemplateColumn 
                                DataField="Name" 
                                HeaderText="Name" 
                                UniqueName="Name">
                                    <ItemTemplate>
                                        <%# Eval("Name")%>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <idea:TextBox
                                        runat="server"
                                        ID="tbName"
                                        Text='<%# Eval("Name")%>'
                                        Width="480px" />
                                        <div style="margin: 10px 0px;" />
                                    </EditItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn 
                                DataField="Description" 
                                HeaderText="Description" 
                                SortExpression="Description"
                                UniqueName="Description">
                                    <ItemTemplate>
                                        <%#Eval("Description")%>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <idea:TextBox
                                        runat="server"
                                        ID="tbDescription"
                                        TextMode="MultiLine"
                                        Height="75px"
                                        Text='<%# Eval("Description") %>'
                                        Width="480px" />
                                        <div style="margin: 10px 0px;" />
                                    </EditItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn 
                                DataField="Members.Count" 
                                HeaderStyle-Width="100px"
                                HeaderText="# of Members" 
                                SortExpression="Members.Count"
                                UniqueName="Members.Count">
                                    <ItemTemplate>
                                        <%#Eval("Members.Count")%>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn
                                HeaderStyle-Width="20px">
                                    <ItemTemplate>
                                        <idea:LinkButton
                                        runat="server"
                                        ID="lbMembers"
                                        OnClick="AddMemberClicked"
                                        itemname='<%# Eval("Name").ToString() %>'
                                        itemid='<%# Eval("ID").ToString() %>'>
                                            <asp:Image
                                            runat="server"
                                            ID="imgMembers"
                                            ToolTip="Manage Team Members"
                                            ImageUrl="~/Images/edit_profile.png"
                                            Style="border: none;" />
                                        </idea:LinkButton>
                                    </ItemTemplate>
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
                                            ToolTip="Edit Group"
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
                                            ToolTip="Delete Group"
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
