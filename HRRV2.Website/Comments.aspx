<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="Comments.aspx.cs" Inherits="HRRV2.Website.Comments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="Scripts/HRR.Domain.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<telerik:RadAjaxManagerProxy ID="rampComments" runat="server" >
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="ddlTeams">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="divComments" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="ddlSort">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="divComments" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="divComments">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="divComments" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Simple" Transparency="15" />
<script type="text/javascript">
    setCurrentMenuItem("nav-comments", "");
    </script>
    <div class="page-header">
        <h5><i class="icon-th-large"></i>Comments</h5>
        <span style="float: right; margin-top: -5px;">
        <b>Select Team:</b>
        <idea:UserTeamsDDL
        AutoPostBack="true"
        CausesValidation="false"
        OnSelectedIndexChanged="TeamSelectedIndexChanged"
        runat="server"
        ID="ddlTeams" />
        </span>
    </div>
    <div class="body">
        <div class="body align-center">
            <a data-toggle="modal" 
            href="#newPraise" 
            class="btn btn-large" 
            title="Leave Praise">
                <i class="icon-heart"></i> Praise
            </a>
            <a data-toggle="modal" 
            href="#newFeedback" 
            class="btn btn-large" 
            title="Leave Feedback">
                <i class="icon-comment"></i> Feedback
            </a>
            <a data-toggle="modal" 
            href="#newAnouncement" 
            class="btn btn-large" 
            title="Make An Announcement">
                <i class="icon-bullhorn"></i> Announcement
            </a>
            <a data-toggle="modal" 
            href="#newNote" 
            class="btn btn-large" 
            title="Enter A Note">
                <i class="icon-pencil"></i> Note
            </a>
        </div>
        <div>
            <asp:PlaceHolder ID="PlaceHolder1" runat="server">
                <span class="pull-left">
                    <b>Sort By: </b>
                    <idea:DropDownList
                    runat="server"
                    Skin="Metro"
                    AutoPostBack="true"
                    CausesValidation="false"
                    OnSelectedIndexChanged="SortSelectedIndexChanged"
                    ID="ddlSort">
                        <Items>
                            <telerik:RadComboBoxItem
                            Value="0"
                            Text="Date" />
                            <telerik:RadComboBoxItem
                            Value="1"
                            Text="Entered By" />
                            <telerik:RadComboBoxItem
                            Value="2"
                            Text="Entered For" />
                            <telerik:RadComboBoxItem
                            Value="3"
                            Text="Category" />
                            <telerik:RadComboBoxItem
                            Value="4"
                            Text="Type" />
                        </Items>
                    </idea:DropDownList>
                </span>
                <br /><br />
                <div style="clear:both;" />
                <div runat="server" id="divComments">
                    <asp:DataList
                    runat="server"
                    OnItemDataBound="ItemDataBound"
                    OnItemCommand="CommentsItemCommand"
                    style="width: 100%;"
                    ID="dlComments">
                        <ItemTemplate>
                            <div class="media" style=" border-bottom: 1px solid #dadada; margin-bottom: 20px;" runat="server" id="divRow">
                                <div class="pull-left">
                                    <a href="#" title="">
                                        <telerik:RadBinaryImage ID="rbiProfile"
                                        runat="server"
                                        AutoAdjustImageControlSize="true"
                                        ResizeMode="Fit"
                                        Height="75"
                                        Width="75"
                                        style="padding: 0px 0px 0px 0px;"/>
                            
                                    </a>
                        
                                    <div>
                                        <i runat="server" id="comment_type"></i>
                                        <span runat="server" style="cursor:default;" id="span_likes" class="label label-info" title="Likes"></span>
                                        <span runat="server" style="cursor:pointer;" id="span_responses" postid='<%# Eval("ID") %>' class="postreply label label-warning" title="Responses"></span>
                                        <br /><br />
                                    </div>
                                </div>
                                <div class="media-body">
                                    <h4 class="media-heading">
                                        <%# Eval("Title") %>
                                    </h4>
                                     <idea:Label
                                    runat="server"
                                    ID="lblMessage" />
                                    <div>
                                        <small>
                                            entered by <asp:HyperLink runat="server" ID="lbEnteredBy"></asp:HyperLink> for <asp:HyperLink runat="server" ID="lbEnteredFor"></asp:HyperLink> on <%#DateTime.Parse(Eval("DateCreated").ToString()).ToString("MMM d, yyyy @ HH:mm") %>.  This message is visible by <strong><idea:Label runat="server" ID="lblVisibleBy" /></strong>
                                        </small>
                                   </div>
                                    <div style="margin: 10px 0px 10px 0px;">
                                    <idea:LinkButton runat="server" OnClick="LikeClicked" id='lbLike'  postid='<%# Eval("ID") %>'  class="btn btn-small btn-info "><b class="icon-thumbs-up"></b> Like</idea:LinkButton>
                                        <a style="cursor: pointer;" id='lbReply_<%# Eval("ID") %>' postid='<%# Eval("ID") %>' class="postreply btn btn-small btn-warning "><b class="icon-share-alt"></b> Reply</a>
                                    <idea:LinkButton runat="server" onclick="ReportPostClicked" postid='<%# Eval("ID") %>'  class="btn btn-small btn-danger"><b class="icon-flag"></b> Flag For Removal</idea:LinkButton>
                                    </div>
                                    <div style="display: none;" id='divResponses_<%# Eval("ID") %>' class="body">
                                        <ul class="messages">
                                            <div
                                            runat="server"
                                            id="phResponses">
                                            </div>
                                        </ul>
                                        <div class="enter-message-divider"></div>
                                        <div class="enter-message">
                                            <asp:TextBox
                                            runat="server"
                                            ID="tbEnterResponse"
                                            placeholder="Enter comment response..."
                                            TextMode="MultiLine"
                                            style="height: 50px; width: 100% !important;"
                                            CssClass="auto">
                                            </asp:TextBox>
                                            <div class="message-actions">
                                                <div class="send-button">
                                                    <idea:LinkButton
                                                    runat="server"
                                                    CommandName="commentresponse"
                                                    postid='<%# Eval("ID") %>'
                                                    ID="lbPostReponse"
                                                    CssClass="btn btn-info"
                                                    OnClick="PostResponseClicked">
                                                        Post Response
                                                    </idea:LinkButton>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>

                    </asp:DataList>
                    <h6 class="subtitle">
                        <asp:label id="lblCurrentPage" runat="server"></asp:label>
                    </h6>
                    <div class="well-smoke well-small body">
                        <ul class="pager" runat="server" id="commentsPager">
                        <li class="previous">
                            <idea:LinkButton
                            runat="server"
                            OnClick="PrevClicked"
                            ID="cmdPrev">
                                Previous
                            </idea:LinkButton>
                        </li>
                        <li class="next">
                            <idea:LinkButton
                            OnClick="NextClicked"
                            runat="server"
                            ID="cmdNext">
                                Next
                            </idea:LinkButton>
                        </li>
                    </ul>
                    </div>
                </div>
            </asp:PlaceHolder>
        </div>
    </div>

    <div id="newPraise" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myPraiseLabel" aria-hidden="true">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h5 id="myPraiseLabel"><i class="icon-heart"></i> Leave Praise and Be Joyous!</h5>
                </div>
                <div class="modal-body">
                <div id="divSecurityContainer" class="row-fluid">
                        <div class="control-group clearfix">
                            <div class="span12">
                                <label class="control-label">
                                    Who am I praising?:
                                </label>
                                <div class="controls ui-widget">
                                    <telerik:RadAutoCompleteBox
                                    runat="server"
                                    ID="praise_name"
                                    DataTextField="Name"
                                    DataValueField="ID"
                                    Width="400px"
                                    DropDownHeight="400"
                                    DropDownWidth="375"
                                    Skin="Metro">
                                        <DropDownItemTemplate>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td align="left" style="width: 50px; padding-left: 10px; padding-bottom: 10px;">
                                                        <telerik:RadBinaryImage
                                                        ID="RadBinaryImage1"
                                                        runat="server"
                                                        AlternateText="Profile Photo"
                                                        ToolTip="Profile Photo"
                                                        Height="50px"
                                                        Width="50px"
                                                        ResizeMode="Fit"
                                                        ImageUrl='<%#  DataBinder.Eval(Container.DataItem, "AvatarPath").ToString().StartsWith("http://") ? DataBinder.Eval(Container.DataItem, "AvatarPath").ToString() + "50" : HRR.Core.ResourceStrings.AvatarBasePath  + DataBinder.Eval(Container.DataItem, "AvatarPath") %>' />
                                                    </td>
                                                    <td align="left" style="width: 430px; padding-left: 10px; vertical-align: top;">
                                                        <span style="color: #000000; font-weight: bold;">Name:
                                                        </span>
                                                        <%# DataBinder.Eval(Container.DataItem, "Email").ToString().StartsWith("team:") ? DataBinder.Eval(Container.DataItem, "Name").ToString() + "<span style='font-weight: bold;'> - TEAM</span>" : DataBinder.Eval(Container.DataItem, "Name") %>
                                                            </span>
                                                            <br />
                                                        <span style="color: #000000; font-weight: bold;">Department:
                                                        </span>
                                                        <%# DataBinder.Eval(Container.DataItem, "DepartmentName")%>
                                                            </span>
                                                            <br />
                                                        <span style="color: #000000; font-weight: bold;">Title:
                                                        </span>
                                                        <%# DataBinder.Eval(Container.DataItem, "Title")%>
                                                            </span>
                                                    </td>
                                                </tr>
                                            </table>
                                        </DropDownItemTemplate>
                                    </telerik:RadAutoCompleteBox>
                                </div>
                            </div>
                        </div>
                        <div class="control-group clearfix">
                            <div class="span12">
                                <label class="control-label">
                                    Title:
                                </label>
                                <div class="controls">
                                    <idea:TextBox
                                    runat="server"
                                    ID="praise_title"
                                    Width="400"
                                    Skin="Metro" />
                                </div>
                            </div>
                        </div>
                        <div class="control-group clearfix">
                            <div class="span12">
                                <label class="control-label">
                                    Message:
                                </label>
                                <div class="controls">
                                    <idea:TextBox
                                    runat="server"
                                    ID="praise_message"
                                    TextMode="MultiLine"
                                    Height="125"
                                    Width="530"
                                    CssClass="span12" />
                                </div>
                            </div>
                        </div>
                        <div class="control-group clearfix">
                            <div class="checkbox inline">
                                <label class="control-label">
                                    Category:
                                </label>
                                <div class="controls">
                                    <idea:CommentCategoryDDL
                                    runat="server"
                                    ID="praise_category" />
                                </div>
                            </div>
                            <div class="checkbox inline">
                                <label class="control-label">
                                    Keep Private?:
                                </label>
                                <div class="controls">
                                    <asp:CheckBox
                                    runat="server"
                                    ID="praise_isprivate"
                                    CssClass="yes_no" />
                                </div>
                            </div>
                            <div class="checkbox inline">
                                <label class="control-label">
                                    Post Anonymously?:
                                </label>
                                <div class="controls">
                                    <input 
                                    type="checkbox" 
                                    runat="server"
                                    id="praise_isanonymous"
                                    class="yes_no" />
                                </div>
                            </div>
                        </div>
                        <div class="form-actions modal-footer">
                            <button id="btnSavePraise" title="Save Security Info" class="btn btn-small btn-success">
                                <i class="icon-plus"></i> Save 
                            </button>
                            <a href='' title="Cancel" data-dismiss="modal" class="btn btn-small btn-danger">
                                <i class="icon-remove"></i> Cancel
                            </a>               
                        </div>
                    </div>
                </div>
            </div>

    <div id="newFeedback" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myFeedbackLabel" aria-hidden="true">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h5 id="myFeedbackLabel"><i class="icon-heart"></i> Feedback Is The Business</h5>
                </div>
                <div class="modal-body">
                <div id="div2" class="row-fluid">
                        <div class="control-group clearfix">
                            <div class="span12">
                                <label class="control-label">
                                    Select An Employee?:
                                </label>
                                <div class="controls ui-widget">
                                    <telerik:RadAutoCompleteBox
                                    runat="server"
                                    ID="feedback_name"
                                    DataTextField="Name"
                                    DataValueField="ID"
                                    Width="400px"
                                    DropDownHeight="400"
                                    DropDownWidth="375"
                                    Skin="Metro">
                                        <DropDownItemTemplate>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td align="left" style="width: 50px; padding-left: 10px; padding-bottom: 10px;">
                                                        <telerik:RadBinaryImage
                                                        ID="feedback_profilepic"
                                                        runat="server"
                                                        AlternateText="Profile Photo"
                                                        ToolTip="Profile Photo"
                                                        Height="50px"
                                                        Width="50px"
                                                        ResizeMode="Fit"
                                                        ImageUrl='<%#  DataBinder.Eval(Container.DataItem, "AvatarPath").ToString().StartsWith("http://") ? DataBinder.Eval(Container.DataItem, "AvatarPath").ToString() + "50" : HRR.Core.ResourceStrings.AvatarBasePath  + DataBinder.Eval(Container.DataItem, "AvatarPath") %>' />
                                                    </td>
                                                    <td align="left" style="width: 430px; padding-left: 10px; vertical-align: top;">
                                                        <span style="color: #000000; font-weight: bold;">Name:
                                                        </span>
                                                        <%# DataBinder.Eval(Container.DataItem, "Email").ToString().StartsWith("team:") ? DataBinder.Eval(Container.DataItem, "Name").ToString() + "<span style='font-weight: bold;'> - TEAM</span>" : DataBinder.Eval(Container.DataItem, "Name") %>
                                                            </span>
                                                            <br />
                                                        <span style="color: #000000; font-weight: bold;">Department:
                                                        </span>
                                                        <%# DataBinder.Eval(Container.DataItem, "DepartmentName")%>
                                                            </span>
                                                            <br />
                                                        <span style="color: #000000; font-weight: bold;">Title:
                                                        </span>
                                                        <%# DataBinder.Eval(Container.DataItem, "Title")%>
                                                            </span>
                                                    </td>
                                                </tr>
                                            </table>
                                        </DropDownItemTemplate>
                                    </telerik:RadAutoCompleteBox>
                                </div>
                            </div>
                        </div>
                        <div class="control-group clearfix">
                            <div class="span12">
                                <label class="control-label">
                                    Title:
                                </label>
                                <div class="controls">
                                    <idea:TextBox
                                    runat="server"
                                    ID="feedback_title"
                                    Width="400"
                                    Skin="Metro" />
                                </div>
                            </div>
                        </div>
                        <div class="control-group clearfix">
                            <div class="span12">
                                <label class="control-label">
                                    Message:
                                </label>
                                <div class="controls">
                                    <idea:TextBox
                                    runat="server"
                                    ID="feedback_message"
                                    TextMode="MultiLine"
                                    Height="125"
                                    Width="530"
                                    CssClass="span12" />
                                </div>
                            </div>
                        </div>
                        <div class="control-group clearfix">
                            <div class="checkbox inline">
                                <label class="control-label">
                                    Category:
                                </label>
                                <div class="controls">
                                    <idea:CommentCategoryDDL
                                    runat="server"
                                    ID="feedback_category" />
                                </div>
                            </div>
                            <div class="checkbox inline">
                                <label class="control-label">
                                    Keep Private?:
                                </label>
                                <div class="controls">
                                    <asp:CheckBox
                                    runat="server"
                                    ID="feedback_isprivate"
                                    CssClass="yes_no" />
                                </div>
                            </div>
                            <div class="checkbox inline">
                                <label class="control-label">
                                    Post Anonymously?:
                                </label>
                                <div class="controls">
                                    <input 
                                    type="checkbox" 
                                    runat="server"
                                    id="feedback_isanonymous"
                                    class="yes_no" />
                                </div>
                            </div>
                        </div>
                        <div class="form-actions modal-footer">
                            <button id="btnSaveFeedback" title="Save Security Info" class="btn btn-small btn-success">
                                <i class="icon-plus"></i> Save 
                            </button>
                            <a href='' title="Cancel" data-dismiss="modal" class="btn btn-small btn-danger">
                                <i class="icon-remove"></i> Cancel
                            </a>               
                        </div>
                    </div>
                </div>
            </div>

    <div id="newAnouncement" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myAnouncementLabel" aria-hidden="true">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h5 id="myAnouncementLabel"><i class="icon-heart"></i> Hark! Thou Hast An Anouncement!!</h5>
                </div>
                <div class="modal-body">
                <div id="div3" class="row-fluid">
                        <div class="control-group clearfix">
                            <div class="span12">
                                <label class="control-label">
                                    Title:
                                </label>
                                <div class="controls">
                                    <idea:TextBox
                                    runat="server"
                                    ID="announcement_title"
                                    Width="400"
                                    Skin="Metro" />
                                </div>
                            </div>
                        </div>
                        <div class="control-group clearfix">
                            <div class="span12">
                                <label class="control-label">
                                    Message:
                                </label>
                                <div class="controls">
                                    <idea:TextBox
                                    runat="server"
                                    ID="announcement_message"
                                    TextMode="MultiLine"
                                    Height="125"
                                    Width="530"
                                    CssClass="span12" />
                                </div>
                            </div>
                        </div>
                        <div class="control-group clearfix">
                            <div class="checkbox inline">
                                <label class="control-label">
                                    Category:
                                </label>
                                <div class="controls">
                                    <idea:CommentCategoryDDL
                                    runat="server"
                                    ID="announcement_category" />
                                </div>
                            </div>
                        </div>
                        <div class="form-actions modal-footer">
                            <button id="btnSaveAnnouncement" title="Save Announcement" class="btn btn-small btn-success">
                                <i class="icon-plus"></i> Save 
                            </button>
                            <a href='' title="Cancel" data-dismiss="modal" class="btn btn-small btn-danger">
                                <i class="icon-remove"></i> Cancel
                            </a>               
                        </div>
                    </div>
                </div>
            </div>


            <div id="newNote" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myNoteLabel" aria-hidden="true">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h5 id="myNoteLabel"><i class="icon-heart"></i> Hark! Thou Hast An Anouncement!!</h5>
                </div>
                <div class="modal-body">
                <div id="div4" class="row-fluid">
                    <div class="control-group clearfix">
                            <div class="span12">
                                <label class="control-label">
                                    Select An Employee?:
                                </label>
                                <div class="controls ui-widget">
                                    <telerik:RadAutoCompleteBox
                                    runat="server"
                                    ID="note_name"
                                    DataTextField="Name"
                                    DataValueField="ID"
                                    Width="400px"
                                    DropDownHeight="400"
                                    DropDownWidth="375"
                                    Skin="Metro">
                                        <DropDownItemTemplate>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td align="left" style="width: 50px; padding-left: 10px; padding-bottom: 10px;">
                                                        <telerik:RadBinaryImage
                                                        ID="feedback_profilepic"
                                                        runat="server"
                                                        AlternateText="Profile Photo"
                                                        ToolTip="Profile Photo"
                                                        Height="50px"
                                                        Width="50px"
                                                        ResizeMode="Fit"
                                                        ImageUrl='<%#  DataBinder.Eval(Container.DataItem, "AvatarPath").ToString().StartsWith("http://") ? DataBinder.Eval(Container.DataItem, "AvatarPath").ToString() + "50" : HRR.Core.ResourceStrings.AvatarBasePath  + DataBinder.Eval(Container.DataItem, "AvatarPath") %>' />
                                                    </td>
                                                    <td align="left" style="width: 430px; padding-left: 10px; vertical-align: top;">
                                                        <span style="color: #000000; font-weight: bold;">Name:
                                                        </span>
                                                        <%# DataBinder.Eval(Container.DataItem, "Email").ToString().StartsWith("team:") ? DataBinder.Eval(Container.DataItem, "Name").ToString() + "<span style='font-weight: bold;'> - TEAM</span>" : DataBinder.Eval(Container.DataItem, "Name") %>
                                                            </span>
                                                            <br />
                                                        <span style="color: #000000; font-weight: bold;">Department:
                                                        </span>
                                                        <%# DataBinder.Eval(Container.DataItem, "DepartmentName")%>
                                                            </span>
                                                            <br />
                                                        <span style="color: #000000; font-weight: bold;">Title:
                                                        </span>
                                                        <%# DataBinder.Eval(Container.DataItem, "Title")%>
                                                            </span>
                                                    </td>
                                                </tr>
                                            </table>
                                        </DropDownItemTemplate>
                                    </telerik:RadAutoCompleteBox>
                                </div>
                            </div>
                        </div>
                        <div class="control-group clearfix">
                            <div class="span12">
                                <label class="control-label">
                                    Title:
                                </label>
                                <div class="controls">
                                    <idea:TextBox
                                    runat="server"
                                    ID="note_title"
                                    Width="400"
                                    Skin="Metro" />
                                </div>
                            </div>
                        </div>
                        <div class="control-group clearfix">
                            <div class="span12">
                                <label class="control-label">
                                    Message:
                                </label>
                                <div class="controls">
                                    <idea:TextBox
                                    runat="server"
                                    ID="note_message"
                                    TextMode="MultiLine"
                                    Height="125"
                                    Width="530"
                                    CssClass="span12" />
                                </div>
                            </div>
                        </div>
                        <div class="control-group clearfix">
                            <div class="checkbox inline">
                                <label class="control-label">
                                    Category:
                                </label>
                                <div class="controls">
                                    <idea:CommentCategoryDDL
                                    runat="server"
                                    ID="note_category" />
                                </div>
                            </div>
                        </div>
                        <div class="form-actions modal-footer">
                            <button id="btnSaveNote" title="Save Announcement" class="btn btn-small btn-success">
                                <i class="icon-plus"></i> Save 
                            </button>
                            <a href='' title="Cancel" data-dismiss="modal" class="btn btn-small btn-danger">
                                <i class="icon-remove"></i> Cancel
                            </a>               
                        </div>
                    </div>
                </div>
            </div>

<script type="text/javascript">
    function pageLoad() {
        $(".postreply").unbind();
        $(".postreply").click(function (e) {
            e.preventDefault();  //prevent default form submit behaviour
            $("#divResponses_" + $(this).attr("postid")).toggle("slow");
        });
    }
</script>
    <script type="text/javascript">

        $(".postreply").click(function (e) {
            e.preventDefault();  //prevent default form submit behaviour
            $("#divResponses_" + $(this).attr("postid")).toggle("slow");
        });

            $("#btnSavePraise").click(function (e) {

                e.preventDefault();  //prevent default form submit behaviour

                var autoCompleteBox = $find("<%= praise_name.ClientID %>");
                var entriesCount = autoCompleteBox.get_entries().get_count();
                var label = "";
                if (entriesCount > 0)
                {
                    for (var i = 0; i < entriesCount; i++)
                    {
                        label += autoCompleteBox.get_entries().getEntry(i).get_text() + " - " + autoCompleteBox.get_entries().getEntry(i).get_value() + ", ";

                        var _comment = new Comment();
                        _comment.CategoryID = $find("<%= praise_category.ClientID %>").get_value();
                        _comment.CommentType = 1;
                        _comment.SecurityType = 1;
                        _comment.EnteredFor = autoCompleteBox.get_entries().getEntry(i).get_value();
                        _comment.TeamID = $find("<%= ddlTeams.ClientID %>").get_value();
                        _comment.Message = $("#ctl00_MainContent_praise_message").val();
                        _comment.Title = $("#ctl00_MainContent_praise_title").val();
                        _comment.IsPrivate = $("#MainContent_praise_isprivate").is(":checked");
                        _comment.IsAnonymous = $("#MainContent_praise_isanonymous").is(":checked");
                        $.ajax({
                            url: 'http://hrrv2.localhost/api/Comment/CreateComment',
                            type: 'POST',
                            data: JSON.stringify(_comment),
                            dataType: "json",
                            contentType: "application/json;charset=utf-8",
                            success: function (data) {
                                window.location = data.split(':')[2];
                                var notice = "<div class='notice closing'><div class='note note-success'><button type='button' class='close'>×</button><strong>Praise Successfully Created!!</strong></div></div>";
                                //alert(notice);
                                $("#mainwrapper").before(notice);
                                $('#mainwrapper').effect("highlight", { color: "#7fd658" }, 1000);
                            },
                            error: function (x, y, z) {
                                alert(x + '\n' + y + '\n' + z);
                            }
                        });
                    }
                }
            });

            $("#btnSaveFeedback").click(function (e) {

                e.preventDefault();  //prevent default form submit behaviour
                var autoCompleteBox = $find("<%= feedback_name.ClientID %>");
                var entriesCount = autoCompleteBox.get_entries().get_count();
                var label = "";
                if (entriesCount > 0) {
                    for (var i = 0; i < entriesCount; i++) {
                        label += autoCompleteBox.get_entries().getEntry(i).get_text() + " - " + autoCompleteBox.get_entries().getEntry(i).get_value() + ", ";

                        var _comment = new Comment();
                        _comment.CategoryID = $find("<%= feedback_category.ClientID %>").get_value();
                        _comment.CommentType = -1;
                        _comment.SecurityType = 1;
                        _comment.EnteredFor = autoCompleteBox.get_entries().getEntry(i).get_value();
                        _comment.TeamID = $find("<%= ddlTeams.ClientID %>").get_value();
                        _comment.Message = $("#ctl00_MainContent_feedback_message").val();
                        _comment.Title = $("#ctl00_MainContent_feedback_title").val();
                        _comment.IsPrivate = $("#MainContent_feedback_isprivate").is(":checked");
                        _comment.IsAnonymous = $("#MainContent_feedback_isanonymous").is(":checked");
                        $.ajax({
                            url: 'http://hrrv2.localhost/api/Comment/CreateComment',
                            type: 'POST',
                            data: JSON.stringify(_comment),
                            dataType: "json",
                            contentType: "application/json;charset=utf-8",
                            success: function (data) {
                                window.location = data.split(':')[2];
                                var notice = "<div class='notice closing'><div class='note note-success'><button type='button' class='close'>×</button><strong>Feedback Successfully Created!!</strong></div></div>";
                                //alert(notice);
                                $("#mainwrapper").before(notice);
                                $('#mainwrapper').effect("highlight", { color: "#7fd658" }, 1000);
                            },
                            error: function (x, y, z) {
                                alert(x + '\n' + y + '\n' + z);
                            }
                        });
                    }
                }
            });

        $("#btnSaveAnnouncement").click(function (e) {

            e.preventDefault();  //prevent default form submit behaviour
            var label = "";
            var _comment = new Comment();
            _comment.CategoryID = $find("<%= announcement_category.ClientID %>").get_value();
            _comment.CommentType = 2;
            _comment.SecurityType = 4;
            _comment.EnteredFor = -10;
            _comment.TeamID = 999999;
            _comment.Message = $("#ctl00_MainContent_announcement_message").val();
            _comment.Title = $("#ctl00_MainContent_announcement_title").val();
            _comment.IsPrivate = false;
            _comment.IsAnonymous = false;
            $.ajax({
                url: 'http://hrrv2.localhost/api/Comment/CreateComment',
                type: 'POST',
                data: JSON.stringify(_comment),
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                success: function (data) {
                    window.location = data.split(':')[2];
                    var notice = "<div class='notice closing'><div class='note note-success'><button type='button' class='close'>×</button><strong>Announcement Successfully Created!!</strong></div></div>";
                    //alert(notice);
                    $("#mainwrapper").before(notice);
                    $('#mainwrapper').effect("highlight", { color: "#7fd658" }, 1000);
                },
                error: function (x, y, z) {
                    alert(x + '\n' + y + '\n' + z);
                }
            });
        });

        $("#btnSaveNote").click(function (e) {

            e.preventDefault();  //prevent default form submit behaviour
            var autoCompleteBox = $find("<%= note_name.ClientID %>");
                var entriesCount = autoCompleteBox.get_entries().get_count();
                var label = "";
                if (entriesCount > 0) {
                    for (var i = 0; i < entriesCount; i++) {
                        label += autoCompleteBox.get_entries().getEntry(i).get_text() + " - " + autoCompleteBox.get_entries().getEntry(i).get_value() + ", ";

                        var _comment = new Comment();
                        _comment.CategoryID = $find("<%= note_category.ClientID %>").get_value();
                        _comment.CommentType = 3;
                        _comment.SecurityType = 3;
                        _comment.EnteredFor = autoCompleteBox.get_entries().getEntry(i).get_value();
                        _comment.TeamID = $find("<%= ddlTeams.ClientID %>").get_value();
                        _comment.Message = $("#ctl00_MainContent_note_message").val();
                        _comment.Title = $("#ctl00_MainContent_note_title").val();
                        _comment.IsPrivate = true;
                        _comment.IsAnonymous = false;
                        $.ajax({
                            url: 'http://hrrv2.localhost/api/Comment/CreateComment',
                            type: 'POST',
                            data: JSON.stringify(_comment),
                            dataType: "json",
                            contentType: "application/json;charset=utf-8",
                            success: function (data) {
                                window.location = data.split(':')[2];
                                var notice = "<div class='notice closing'><div class='note note-success'><button type='button' class='close'>×</button><strong>Note Successfully Created!!</strong></div></div>";
                                //alert(notice);
                                $("#mainwrapper").before(notice);
                                $('#mainwrapper').effect("highlight", { color: "#7fd658" }, 1000);
                            },
                            error: function (x, y, z) {
                                alert(x + '\n' + y + '\n' + z);
                            }
                        });
                    }
                }
        });

    </script>

</asp:Content>
