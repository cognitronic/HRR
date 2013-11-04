<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="Comments.aspx.cs" Inherits="HRR.Website.Comments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadAjaxManagerProxy ID="rampComments" runat="server" >
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="lbPost">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="divCommentsContainer" LoadingPanelID="RadAjaxLoadingPanel1" />
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
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Simple" Transparency="15" />
   <telerik:RadCodeBlock
    runat="server"
    ID="rsb">
        <script type="text/javascript">
            function ClientValidate(source, arguments) {
                var ratingValue = $find("<%= ratingBinary.ClientID %>").get_value();
                if (ratingValue == 0) {
                    arguments.IsValid = false;
                } else {
                    arguments.IsValid = true;
                }
            }
            function getNote(userid) {
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

        <script type="text/javascript">
            $(document).ready(function () {
                // Make sure to only match links to wikipedia with a rel tag
                $('a[class*="help"]').each(function () {
                    // We make use of the .each() loop to gain access to each element via the "this" keyword...
                    $(this).qtip(
		            {
		                content: {
		                    text: '<img class="throbber" src="/Images/loading.gif" alt="Loading..." />', // Set the text to an image HTML string with the correct src URL to the loading image you want to use

		                    ajax: {
		                        url: '/PageHelp/FAQ' // Use the rel attribute of each element for the url to load
		                    },
		                    title: {
		                        text: 'Comments Documentation ', // + $(this).text(), // Give the tooltip a title using each elements text
		                        button: true
		                    }
		                },
		                position: {
		                    at: 'center', // Position the tooltip above the link
		                    my: 'center',
		                    target: $(window), // Keep the tooltip on-screen at all times
		                    effect: false // Disable positioning animation
		                },
		                show: {
		                    event: 'click',
		                    modal: true,
		                    solo: true // Only show one tooltip at a time
		                },
		                hide: 'click',
		                style: {
		                    classes: 'ui-tooltip-wiki ui-tooltip-light ui-tooltip-shadow'
		                },
		                events: {
		                    hide: function (event, api) {
		                        window.location = "<%= HRR.Core.Security.SecurityContextManager.Current.CurrentURL %>";
		                    }
		                }
		            })
                })
                // Make sure it doesn't follow the link when we click it
	            .click(function (event) { event.preventDefault(); });



		        

            });
        </script>
    </telerik:RadCodeBlock>

    <div class="three_fourth last_column">
        <div style="float: right;">
            <a href="" class="help">
                Need Help<img src="/Images/help.png" alt="" title="Help Is On The Way!" />
            </a>
        </div>
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
                <p style="margin-bottom: 5px;">
                    <idea:TextBox
                    runat="server"
                    ID="tbNewComment"
                    TextMode="MultiLine"
                    Height="50px"
                    Width="705px" />
                </p>
                <div id="divtest" style="float: right; margin-top: -20px; " class="normal-button-holder">
                    <span style=" float: left; margin-top: 5px;" onclick='return getNote(1);' >
                        Comment Type:  
                    </span>
                    <span>
                        <telerik:RadRating 
                        ID="ratingBinary"
                        runat="server" 
                        Orientation="Horizontal" 
                        SelectionMode="Single"
                        OnRate="RateClicked"
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
                    ControlToValidate="ratingBinary"
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
                    InitialValue=""
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
        <div runat="server" id="divCommentsContainer" style="padding: 2px; background-color: #eeeeee; margin-top: 15px;">
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
                
                <div runat="server" id="divCommentsList" style="margin-top: 10px;">
                    <telerik:RadCodeBlock
                     runat="server"
                     ID="rcblistview">
                        <script type="text/javascript">
                            $(function () {
                                if (document.URL.indexOf("/Flagged") != -1) {
                                    $("[id^='imgFlagged']").attr("src", "/images/green_flag.png");
                                    $("[id^='imgFlagged']").attr("title", "Remove Flag and Add Back To Feed.");
                                }
                            });
                        </script>
                     </telerik:RadCodeBlock>
                    <div style="overflow:auto;">
                                <asp:DataList
                                runat="server"
                                OnItemDataBound="ItemDataBound"
                                ID="dlComments">
                                    <ItemTemplate>
                                        <div runat="server" id="divContainer">
                                        <div style="float: left;">
                                            <telerik:RadBinaryImage ID="rbiProfile"
                                            runat="server"
                                            AutoAdjustImageControlSize="true"
                                            ResizeMode="Fit"
                                            ImageUrl='<%# HRR.Core.ResourceStrings.AvatarBasePath + "thumb_" + Eval("EnteredByRef.AvatarPath") %>'
                                            style="padding: 0px 0px 5px 0px;"/>
                                        </div>
                                        <div id="Div1" runat="server" style="float: left; margin-left: 10px; margin-top: 0px; width: 640px;">
                                            <span style="font-size: 14pt;">
                                                <span style="float: right;">
                                                    <idea:LinkButton
                                                    runat="server"
                                                    ID="lbDeleteComment"
                                                    OnClientClick="return confirm('This will permanently delete the comment and all associated records.  Are you sure you want to do this?')"
                                                    CausesValidation="false"
                                                    OnClick="DeleteCommentClicked"
                                                    ToolTip="Delete Comment"
                                                    itemid='<%# Eval("ID").ToString() %>'>
                                                        <img src="/images/delete.png" alt="Delete Comment" />
                                                    </idea:LinkButton>&nbsp;&nbsp;
                                                    <idea:LinkButton
                                                    runat="server"
                                                    ID="lbViewComment"
                                                    CausesValidation="false"
                                                    OnClick="ViewCommentClicked"
                                                    ToolTip="View Comment Details"
                                                    itemid='<%# Eval("ID").ToString() %>'>
                                                        <img src="/images/view.png" alt="View Comment Details" />
                                                    </idea:LinkButton>&nbsp;&nbsp;
                                                    <idea:LinkButton
                                                    runat="server"
                                                    ID="lbReportPost"
                                                    OnClientClick="return confirm('Are you sure you want to perform this action?')"
                                                    CausesValidation="false"
                                                    OnClick="ReportPostClicked"
                                                    postid='<%# Eval("ID").ToString() %>'>
                                                        <img id="imgFlagged" src="/images/flag_red.png" title="Report Post To HR" alt="" />
                                                    </idea:LinkButton>
                                                </span>
                                                <a href='<%# "/People/" + Eval("EnteredByRef.Email").ToString() %>'><%#Eval("EnteredByRef.Name") %></a> &nbsp;&nbsp;
                                                <%# Eval("CommentType").ToString().Equals("-1") ? "<img src='/images/downh.png' alt='Negative' title='Negative Comment' /><br />" : "<img src='/images/uph.png' alt='Positive' title='Positive Comment' /><br />" %>
                            
                                            </span>
                                            <span>
                                                <idea:Label
                                                runat="server"
                                                ID="lblMessage" />
                                            </span>
                                        </div>
                                        <div style="clear: both;" />
                                        <div id="Div2" runat="server" style="margin-left: 60px; width: 640px;">
                                            <span runat="server" id="lblEnteredBy" style="font-size: 8pt;">entered for <a href='<%# "/People/" + Eval("EnteredForRef.Email").ToString() %>'><i><%# Eval("EnteredForRef.Name").ToString() %></i></a> on </span>
                                            <span style="font-size: 8pt; color: #000000;"><%#DateTime.Parse(Eval("DateCreated").ToString()).ToString("MMM d, yyyy @ HH:mm") %></span>
                                            <span style="font-size: 8pt; color: #000000;"> under <span style="font-size: 8pt; color: #cc6600;"><%# DataBinder.Eval(Container.DataItem, "Category.Name") %></span></span> | 
                                            <span>
                                                <idea:LinkButton
                                                CausesValidation="false"
                                                runat="server"
                                                ID="lbResponseCount"
                                                itemid='<%# Eval("ID").ToString() %>'
                                                OnClick="ResponseCountClicked">
                                                </idea:LinkButton>
                                            </span>
                                        </div>
                                        <%--<div style="margin-left: 60px;">
                                            <idea:LinkButton
                                            runat="server"
                                            ID="lbResponse"
                                            OnClientClick="ShowResponses">
                                                Leave Response
                                            </idea:LinkButton>
                                        </div>
                                        <div id="divResponses" style="margin-left: 60px; background-color:#e9e9e9;">
                                            <idea:TextBox
                                            runat="server"
                                            ID="tbResponse"
                                            Width="400px">
                                            </idea:TextBox>&nbsp;
                                            <idea:LinkButton
                                            runat="server"
                                            ID="lbSaveResponse">
                                                Post
                                            </idea:LinkButton>
                                        </div>--%>
                                        <hr />
                                        </div>
                                    </ItemTemplate>
                                </asp:DataList>
                            </div>
                </div>
            </div>
        </div>
    </div>
    
</asp:Content>
