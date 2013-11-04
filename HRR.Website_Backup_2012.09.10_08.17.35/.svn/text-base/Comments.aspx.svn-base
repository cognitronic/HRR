<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="Comments.aspx.cs" Inherits="HRR.Website.Comments" %>
<%@ Register TagPrefix="idea" TagName="CommentListView" Src="~/Views/CommentListView.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<telerik:RadAjaxManagerProxy ID="rampComments" runat="server" >
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="lbPost">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="dlComments" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="divFilters">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="dlComments" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="ddlSort">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="dlComments" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="ddlTeams">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="dlComments" LoadingPanelID="RadAjaxLoadingPanel1" />
                <telerik:AjaxUpdatedControl UpdatePanelRenderMode="Inline" ControlID="ddlCommentFor" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="ratingBinary">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl UpdatePanelRenderMode="Inline" ControlID="divFollowUp" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Simple" Transparency="15" />
<script type="text/javascript">
    function ClientValidate(source, arguments) {
        var ratingValue = $find("<%= ratingBinary.ClientID %>").get_value();
        if (ratingValue == 0) {
            arguments.IsValid = false;
        } else {
            arguments.IsValid = true;
        }
    }

    function getNote(userid) 
    {
        alert(userid);
        $.ajax({
            type: "POST",
            url: "http://hrr.localhost/" + "Comments.svc/GetCommentListByFilters",
            cache: false,
            data: '{ "userID": "' + userid + '" }',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                alert("inside success" + data);
                if (data.d != '') {
                    alert("inside data.d");
                    var taskNote = document.getElementById("test");
                    if (data.d == '') {
                        taskNote.value = '';
                        alert("data.d is empty");
                    }
                    else {
                        alert("data.d is not empty");
                        alert(jQuery.parseJSON(data).toString());
                        $.each(jQuery.parseJSON(data), function (i, item) {
                            taskNote.innerHTML += "<b>Message:</b> " + item.message;
                            //taskNote.innerHTML += "<b>Message:</b> " + JSON.parse(data.d).message + "<br /><b>Last Updated On:</b> " + JSON.parse(data.d).enteredby;
                        });
                    }
                }
            }
        });
   }
 
</script>

    <div class="three_fourth last_column">
        <div style="margin-top: 15px; font-weight: bold !important;">
            Select A Team:
            <idea:UserTeamsDDL
            AutoPostBack="true"
            CausesValidation="false"
            OnSelectedIndexChanged="TeamSelectedIndexChanged"
            runat="server"
            ID="ddlTeams" />
        </div>
        <div runat="server" id="divAddComment" style="padding: 2px; background-color: #eeeeee;  margin-top: 5px;">
            <div style="overflow:auto; background-color: #ffffff; padding: 10px;" >
                <h5><img src="/images/follow-us.png" alt="Add Comment" /> Comment: </h5>
                <p style="margin-top: -10px;">
                    <idea:TextBox
                    runat="server"
                    ID="tbNewComment"
                    TextMode="MultiLine"
                    Height="50px"
                    Width="700px" />
                </p>
                <div style="float: right; margin-top: -20px; " class="normal-button-holder">
                    <span style=" float: left; margin-top: 5px;" >
                        Comment Type:  
                    </span>
                    <span>
                        <telerik:RadRating 
                        ID="ratingBinary" 
                        runat="server" 
                        Orientation="Horizontal" 
                        SelectionMode="Single"
                        OnRate="RateClicked"
                        AutoPostBack="true"
                        ItemHeight="20px" 
                        ItemWidth="20px" 
                        style=" float: left; margin-top: 5px;">
                        <Items>
                            <telerik:RadRatingItem Value="-1" HoveredImageUrl="/Images/downh.png" HoveredSelectedImageUrl="/Images/downh.png"
                                SelectedImageUrl="/Images/downh.png" ImageUrl="/Images/down.png"
                                ToolTip="Constructive Comment" />
                            <%--<telerik:RadRatingItem Value="0" HoveredImageUrl="/Images/0h.png" HoveredSelectedImageUrl="/Images/0h.png"
                                SelectedImageUrl="/Images/0.png" ImageUrl="/Images/0.png" ToolTip="Reset Current Rating" />--%>
                            <telerik:RadRatingItem Value="1" HoveredImageUrl="/Images/uph.png" HoveredSelectedImageUrl="/Images/uph.png"
                                SelectedImageUrl="/Images/uph.png" ImageUrl="/Images/up.png" ToolTip="Positive Comment" />
                        </Items>
                    </telerik:RadRating>
                    </span>
                    <span>Who: 
                        <idea:TeamUsersDDL
                        runat="server"
                        ID="ddlCommentFor" />
                    </span>
                    <span>Category: 
                        <idea:CommentCategoryDDL
                        runat="server"
                        ID="ddlCommentCategory" />
                    </span>
                    <idea:LinkButton
                    runat="server"
                    OnClick="PostClicked"
                    ID="lbPost"
                    CssClass="button big round sky-blue">
                        Post
                    </idea:LinkButton>
                </div>
                <div runat="server" id="divFollowUp">
                    
                </div>
                <div style="padding-bottom: 15px; width: 680px; float: right;">
                    <asp:CustomValidator 
                    ID="CustomValidator1" 
                    runat="server" 
                    CssClass="error"
                    ClientValidationFunction="ClientValidate"
                    Display="Dynamic" 
                    ErrorMessage="Select Comment Type">
                    </asp:CustomValidator>
                    <asp:RequiredFieldValidator
                    runat="server"
                    ID="rfvuser"
                    CssClass="error"
                    InitialValue=""
                    ControlToValidate="ddlCommentFor"
                    ErrorMessage="Select an employee"
                    Display="Dynamic" />
                    <asp:RequiredFieldValidator
                    runat="server"
                    ID="RequiredFieldValidator1"
                    CssClass="error"
                    ControlToValidate="ddlCommentCategory"
                    InitialValue="0"
                    ErrorMessage="Select a comment category"
                    Display="Dynamic" />
                    <asp:RequiredFieldValidator
                    runat="server"
                    ID="RequiredFieldValidator2"
                    CssClass="error"
                    ControlToValidate="tbNewComment"
                    InitialValue=""
                    ErrorMessage="Enter a comment"
                    Display="Dynamic" />
                    <asp:RequiredFieldValidator
                    runat="server"
                    ID="RequiredFieldValidator3"
                    CssClass="error"
                    ControlToValidate="ddlTeams"
                    InitialValue="0"
                    ErrorMessage="Select a team"
                    Display="Dynamic" />
                </div>
            </div>
        </div>
        <div runat="server" id="div1" style="padding: 2px; background-color: #eeeeee; margin-top: 15px;">
            <div style="overflow:auto; background-color: #ffffff; padding: 10px; ">
                <div style="float: left;">
                    <span style="font-weight: bold !important;">
                        Sort:
                    </span>
                    <span>
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
                </div>
                <div runat="server" id="divFilters" style="float: right; padding-bottom: 25px; ">
                    <span><a id="lnkMine" class="button small round sky-blue" href="/Comments/Mine"><span>My Comments</span></a></span>
                   <%-- <span ><a id="lnkTeam" class="small-button" href="/Comments/Team"><span>Team Comments</span></a></span>--%>
                    <span ><a id="lnkAll" class="button small round sky-blue" href="/Comments/All"><span>All Comments</span></a></span>
                    <span runat="server" id="spanFlagged"><a id="lnkFlagged" class="button small round sky-blue" href="/Comments/Flagged"><span>Flagged</span></a></span>
                </div>

                <div id="test" class="grandpoobah" style="float: left;">
                    <div class="pics" />
                </div>
                

                <script type="text/javascript">
                    $(function () {
                        if (document.URL.indexOf("/Mine") != -1) {
                            $("#lnkMine").toggleClass("button small round sky-blue:active");
                        }
                        else if (document.URL.indexOf("/Flagged") != -1) {
                            $("#lnkFlagged").toggleClass("button small round sky-blue:active");
                        }
                        else {
                            $("#lnkAll").toggleClass("button small round sky-blue:active");
                        }
                    });
    </script>
                
                <div runat="server" id="divCommentsList">
                <idea:CommentListView
                runat="server"
                id="clv" />
                </div>
            </div>
        </div>
    </div>
    
</asp:Content>
