<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="Blogs.aspx.cs" Inherits="HRR.Website.Blogs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<telerik:RadAjaxManagerProxy ID="ramBlogs" runat="server" >
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="rtsBlog">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rmpBlog" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="rtsBlog">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rtsBlog"/>
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="rgList">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgList" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server"  Skin="Simple" Transparency="15" />
    <div class="three_fourth last_column">
        <img src='/Images/rss.png' style="margin-top: 0px;" height="48px" width="48px" border="0" alt="" />
        <h3 style="display:inline !important;">Blog Management</h3>
        <div>
            <telerik:RadTabStrip runat="server"
                ID="rtsBlog" 
                MultiPageID="rmpBlog" 
                SelectedIndex="0"
                Skin="Metro">
                <Tabs>
                    <telerik:RadTab runat="server" Text="Posts">
                    </telerik:RadTab>
                    <telerik:RadTab runat="server" Text="Manage Categories">
                    </telerik:RadTab>
                </Tabs>
            </telerik:RadTabStrip>
            <telerik:RadMultiPage ID="rmpBlog" runat="server" SelectedIndex="0">
                <telerik:RadPageView ID="pvPosts" runat="server">
                    <br />
                    <div class="containerouter">
                        <div class="containerinner">
                            <h3 style="display:inline !important;">Posts</h3>
                            <div style="margin-bottom: 20px;">
                                <telerik:RadGrid
                                runat="server"
                                ID="rgList"
                                AllowPaging="True"
                                AutoGenerateColumns="false"
                                AllowSorting="True" 
                                OnItemCommand="ItemCommand"
                                OnItemCreated="ItemCreated"
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
                                    CommandItemSettings-AddNewRecordText="Add New Post"
                                    NoMasterRecordsText="No Posts Found.">
                                        <Columns>
                                            <telerik:GridTemplateColumn 
                                            DataField="IsActive" 
                                            HeaderText="Active" 
                                            UniqueName="IsActive">
                                                <ItemTemplate>
                                                    <%# Eval("IsActive").ToString().Equals("True") ? "Yes" : "No"%>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <idea:CheckBox
                                                    runat="server"
                                                    ID="cbIsActive"
                                                    Checked='<%# IdeaSeed.Core.Utils.Utilities.FormatCheckBox(Eval("IsActive")) %>' />
                                                </EditItemTemplate>
                                            </telerik:GridTemplateColumn>
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
                                                        ID="rfvval"
                                                        InitialValue=""
                                                        Display="Dynamic"
                                                        CssClass="error"
                                                        ControlToValidate="tbTitle"
                                                        ErrorMessage="Enter Title" />
                                                    </div>
                                                </EditItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn 
                                            DataField="Category.Name" 
                                            HeaderText="Category" 
                                            UniqueName="Category.Name">
                                                <ItemTemplate>
                                                    <%# Eval("Category.Name")%>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <idea:BlogCategoryDDL
                                                    runat="server"
                                                    SelectedValue='<%# Eval("BlogCategoryID") %>'
                                                    ID="ddlCategory"/>
                                                    <div style="margin: 5px 0px;">
                                                        <asp:RequiredFieldValidator
                                                        runat="server"
                                                        ID="rfvvasdfl"
                                                        InitialValue=""
                                                        Display="Dynamic"
                                                        CssClass="error"
                                                        ControlToValidate="ddlCategory"
                                                        ErrorMessage="Selecte A Category" />
                                                    </div>
                                                </EditItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn 
                                            DataField="BlogContent" 
                                            HeaderText="Content"
                                            Visible="false"
                                            UniqueName="BlogContent">
                                                <EditItemTemplate>
                                                    <telerik:RadEditor
                                                    runat="server"
                                                    ID="reContent"
                                                    ContentFilters="MakeUrlsAbsolute"
                                                    EditModes="Design"
                                                    ToolbarMode="ShowOnFocus"
                                                    ToolsFile="~/ToolsFile.xml"
                                                    Skin="Metro"
                                                    Content='<%# Eval("BlogContent") %>'
                                                    Width="600px">
                                                    </telerik:RadEditor>
                                                    <div style="margin-bottom: 20px;">&nbsp;</div>
                                                </EditItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn 
                                            DataField="StartDate" 
                                            HeaderText="Start Date" 
                                            SortExpression="StartDate"
                                            UniqueName="StartDate">
                                                <ItemTemplate>
                                                    <%# DateTime.Parse(Eval("StartDate").ToString()).ToShortDateString() %>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <telerik:RadDatePicker 
                                                    ID="tbStartDate"
                                                    Skin="Metro"
                                                    DbSelectedDate='<%# Bind("StartDate") %>'
                                                    Height="25px"
                                                    width="150px"
                                                    runat="server">
                                                        <DateInput ID="diStartDate" runat="server"
                                                            DateFormat="MM/dd/yyyy"></DateInput>
                                                    </telerik:RadDatePicker>
                                                    <asp:RequiredFieldValidator
                                                    runat="server"
                                                    ID="RequiredFieldValidator2"
                                                    Display="Dynamic"
                                                    CssClass="error"
                                                    ErrorMessage="<br />Select a date."
                                                    InitialValue=""
                                                    ControlToValidate="tbStartDate" />
                                                    <div style="margin-bottom: 20px;">&nbsp;</div>
                                                </EditItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn 
                                            DataField="EndDate" 
                                            HeaderText="End Date" 
                                            SortExpression="EndDate"
                                            UniqueName="EndDate">
                                                <ItemTemplate>
                                                    <%# DateTime.Parse(Eval("EndDate").ToString()).ToShortDateString()%>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <telerik:RadDatePicker 
                                                    ID="tbEndDate"
                                                    width="150px"
                                                    DbSelectedDate='<%# Bind("EndDate") %>'
                                                    Height="25px"
                                                    Skin="Metro"
                                                    runat="server">
                                                        <DateInput ID="diEndDate" runat="server"
                                                            DateFormat="MM/dd/yyyy"></DateInput>
                                                    </telerik:RadDatePicker>
                                                    <asp:RequiredFieldValidator
                                                    runat="server"
                                                    ID="RequiredFieldValidator1"
                                                    Display="Dynamic"
                                                    CssClass="error"
                                                    ErrorMessage="<br />Select a date."
                                                    InitialValue=""
                                                    ControlToValidate="tbEndDate" />
                                                    <div style="margin-bottom: 20px;">&nbsp;</div>
                                                </EditItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn 
                                            DataField="EnteredByRef.Name" 
                                            HeaderText="Entered By" 
                                            UniqueName="EnteredByRef.Name">
                                                <ItemTemplate>
                                                    <%# Eval("EnteredByRef.Name")%>
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
                                                        ToolTip="Edit Blog"
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
                                                        ToolTip="Delete Blog"
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
                </telerik:RadPageView>
                <telerik:RadPageView ID="pvManageCategories" runat="server">
                    <br />
                    <div class="containerouter">
                        <div class="containerinner">
                            <h3 style="display:inline !important;">Manage Categories</h3>
                            <div style="margin: 5px;">
                                <telerik:RadGrid
                                runat="server"
                                ID="rgCategories"
                                AllowPaging="True"
                                AutoGenerateColumns="false"
                                AllowSorting="True" 
                                OnItemCommand="CategoryItemCommand"
                                OnItemCreated="CategoryItemCreated"
                                GridLines="None"
                                Width="680px" 
                                ShowStatusBar="true"
                                OnNeedDataSource="CategoryNeedDataSource"
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
                                    CommandItemSettings-AddNewRecordText="Add New Category"
                                    NoMasterRecordsText="No Categories Found.">
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
                                                    Text='<%# Eval("Name") %>'
                                                    Width="200px" />
                                                <div style="margin: 5px 0px;">
                                                    <asp:RequiredFieldValidator
                                                    runat="server"
                                                    ID="rfvName"
                                                    InitialValue=""
                                                    Display="Dynamic"
                                                    CssClass="error"
                                                    ControlToValidate="tbName"
                                                    ErrorMessage="Enter Category Name" />
                                                </div>
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
                                                    Height="50px"
                                                    Text='<%# Eval("Description") %>'
                                                    Width="200px" />
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
                    </div>
                </telerik:RadPageView>
            </telerik:RadMultiPage>
        </div> 
    </div>
</asp:Content>
