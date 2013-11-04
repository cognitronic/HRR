<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="ManagedLists.aspx.cs" Inherits="HRRV2.Website.ManagedLists" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:RadAjaxManagerProxy ID="rampComments" runat="server" >
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rgDepartment">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgDepartment" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rgCommentCategories">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgCommentCategories" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Simple" Transparency="15" />
    <script type="text/javascript">
        setCurrentMenuItem("nav-settings", "subnav-managedlists");
    </script>

    <div class="page-header">
        <h5><i class="icon-th-large"></i>Departments</h5>
    </div>
    <div class="body">
        <div>
            <telerik:RadGrid
            runat="server"
            ID="rgDepartment"
            AllowPaging="True"
            AutoGenerateColumns="false"
            AllowSorting="True" 
            OnItemCommand="ItemCommand"
            OnItemCreated="DepartmentItemCreated"
            GridLines="None"
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
                CommandItemSettings-AddNewRecordText="Add New Department"
                NoMasterRecordsText="No Departments Found.">
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
                                <asp:RequiredFieldValidator
                                runat="server"
                                ID="sdfsdf"
                                Display="Dynamic"
                                InitialValue=""
                                CssClass="error"
                                ControlToValidate="tbName"
                                ErrorMessage="Enter Department Name" />
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
                                    ToolTip="Edit Department"
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
                                    ToolTip="Delete Delete"
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

    <div class="page-header">
        <h5><i class="icon-th-large"></i>Comment Categories</h5>
    </div>
    <div class="body">
        <div>
            <telerik:RadGrid
            runat="server"
            ID="rgCommentCategories"
            AllowPaging="True"
            AutoGenerateColumns="false"
            AllowSorting="True" 
            OnItemCommand="CommentItemCommand"
            OnItemCreated="CommentItemCreated"
            GridLines="None"
            ShowStatusBar="true"
            OnNeedDataSource="CommentNeedDataSource"
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
                CommandItemSettings-AddNewRecordText="Add New Comment Category"
                NoMasterRecordsText="No Comment Categories Found.">
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
                                <asp:RequiredFieldValidator
                                runat="server"
                                ID="sdf"
                                InitialValue=""
                                Display="Dynamic"
                                CssClass="error"
                                ControlToValidate="tbName"
                                ErrorMessage="Enter Category Name" />
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
                                    ToolTip="Edit Category"
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
                                    ToolTip="Delete Category"
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

</asp:Content>
