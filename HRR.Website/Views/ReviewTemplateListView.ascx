<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReviewTemplateListView.ascx.cs" Inherits="HRR.Website.Views.ReviewTemplateListView" %>
<div class="three_fourth last_column">
<br />
    <div class="containerouter">
        <div class="containerinner">
            <h3 style="display:inline !important;">Manage Review Template List</h3>
            <span style="margin-left: 280px;">
                <idea:LinkButton
                runat="server"
                ID="lbAddTemplate"
                OnClick="NewTemplateClicked">
                    <img src="/Images/add.png" title="Add New Template" alt="" /> New Template
                </idea:LinkButton>
            </span>
            <div style="margin-bottom: 20px;">
                <telerik:RadGrid
                runat="server"
                ID="rgList"
                AllowPaging="True"
                AutoGenerateColumns="false"
                AllowSorting="True" 
                OnItemCommand="ItemCommand"
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
                    CommandItemDisplay="None"
                    EnableNoRecordsTemplate="true"
                    CommandItemSettings-AddNewRecordText="Add New Template"
                    NoMasterRecordsText="No Templates Found.">
                        <Columns>
                            <telerik:GridTemplateColumn 
                            DataField="Title" 
                            HeaderText="Title" 
                            UniqueName="Title">
                                <ItemTemplate>
                                    <%# Eval("Title")%>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn 
                            DataField="IsActive" 
                            HeaderText="Status" 
                            SortExpression="IsActive"
                            UniqueName="IsActive">
                                <ItemTemplate>
                                    <%# Eval("IsActive").ToString() == "True" ? "Active" : "Inactive" %>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn 
                            DataField="Questions.Count" 
                            HeaderText="# of Questions" 
                            SortExpression="Questions.Count"
                            UniqueName="Questions">
                                <ItemTemplate>
                                    <%# DataBinder.Eval(Container.DataItem, "Questions.Count") %>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn
                            HeaderStyle-Width="20px">
                                <ItemTemplate>
                                    <idea:LinkButton
                                    runat="server"
                                    ID="lbEdit"
                                    OnClick="EditClicked"
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