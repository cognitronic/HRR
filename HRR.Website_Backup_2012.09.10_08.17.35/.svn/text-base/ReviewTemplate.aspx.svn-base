<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="ReviewTemplate.aspx.cs" Inherits="HRR.Website.ReviewTemplate" %>
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
    <div class="containerouter">
        <div class="containerinner">
            <h3 style="display:inline !important;">Manage Review Template List</h3>
            <div>
                <div>Is Active:</div>
                <idea:CheckBox
                runat="server"
                Skin="Metro"
                ID="cbIsActive" />
            </div>
            <div>
                <div>Title:</div>
                <idea:TextBox
                runat="server"
                Skin="Metro"
                ID="tbTitle"
                Width="690px" />
                <asp:RequiredFieldValidator
                runat="server"
                ID="RequiredFieldValidator2"
                CssClass="error"
                ControlToValidate="tbTitle"
                InitialValue=""
                ErrorMessage="Enter a title"
                Display="Dynamic" />
            </div>
            <br />
            <div style="margin-bottom: 20px;">
                <span>
                    <idea:LinkButton
                    runat="server"
                    OnClick="SaveClicked"
                    ID="lbSave"
                    CssClass="button big round sky-blue">
                        Save Template
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
    <div class="containerouter" id="divQuestions" runat="server">
        <div class="containerinner">
            <h3>Questions</h3>
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
                        CommandItemSettings-AddNewRecordText="Add New Question"
                        NoMasterRecordsText="No Questions Found.">
                            <Columns>
                                <telerik:GridTemplateColumn 
                                DataField="Question" 
                                HeaderText="Question" 
                                UniqueName="Question">
                                    <ItemTemplate>
                                        <%# Eval("Question") %>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <idea:TextBox
                                        runat="server"
                                        ID="tbQuestion"
                                        TextMode="MultiLine"
                                        Height="75px"
                                        Text='<%# Eval("Question") %>'
                                        Width="600px" />
                                    <div style="margin: 5px 0px;">
                                        <asp:RequiredFieldValidator
                                        runat="server"
                                        ID="rfvQuestion"
                                        InitialValue=""
                                        Display="Dynamic"
                                        CssClass="error"
                                        ControlToValidate="tbQuestion"
                                        ErrorMessage="Enter Question" />
                                    </div>
                                    </EditItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn 
                                DataField="RatingScale.Title" 
                                HeaderText="Scale" 
                                UniqueName="RatingScale.Title">
                                    <ItemTemplate>
                                        <%# Eval("RatingScale.Title")%>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <idea:QuestionRatingScalesDDL
                                        runat="server"
                                        ID="ddlScale"
                                        SelectedValue='<%# Eval("RatingScale.ID") %>'/>
                                        
                                    <div style="margin: 5px 0px;">
                                        <asp:RequiredFieldValidator
                                        runat="server"
                                        ID="rfvScale"
                                        InitialValue=""
                                        Display="Dynamic"
                                        CssClass="error"
                                        ControlToValidate="ddlScale"
                                        ErrorMessage="Select Scale" />
                                    </div>
                                    </EditItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn 
                                DataField="CategoryID" 
                                HeaderText="Category" 
                                SortExpression="CategoryID"
                                UniqueName="CategoryID">
                                    <ItemTemplate>
                                        <%#Eval("Category.Name") %>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <idea:CommentCategoryDDL
                                        runat="server"
                                        ID="ddlCategory"
                                        SelectedValue='<%# Eval("CategoryID") %>' />
                                        
                                    <div style="margin: 5px 0px;">
                                        <asp:RequiredFieldValidator
                                        runat="server"
                                        ID="rfvval"
                                        InitialValue=""
                                        Display="Dynamic"
                                        CssClass="error"
                                        ControlToValidate="ddlCategory"
                                        ErrorMessage="Select Category" />
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
