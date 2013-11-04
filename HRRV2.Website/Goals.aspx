<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="Goals.aspx.cs" Inherits="HRRV2.Website.Goals" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:RadCodeBlock runat="server" ID="rcbGoalListView">
    <script lang="javascript" type="text/javascript">
        $(window).load(function () {
            //$(".collapsibleContainerContent").slideToggle();

           
            loadProgress();
        });

        function loadProgress() {
            $(".progress").each(function () {
                var v = eval($(this).attr("goalid"));
                if (v == 0)
                    v = 1;
                $(this).progressbar({
                    value: v
                }).children("span").appendTo(this);
                $(this).find(".progresslabelingrid").html($(this).attr("goalid") + "% complete");
            });
        }
    </script> 
    
    <script type="text/javascript">
        $(document).ready(function () {
            // Make sure to only match links to wikipedia with a rel tag
            $('a[class*="newgoal"]').each(function () {
                // We make use of the .each() loop to gain access to each element via the "this" keyword...
                $(this).qtip(
		            {
		                content: {
		                    text: '<img class="throbber" src="/Images/loading.gif" alt="Loading..." />', // Set the text to an image HTML string with the correct src URL to the loading image you want to use

		                    ajax: {
		                        url: '/Wizards/NewGoal',
		                        data: { 'enteredfor': $(this).attr('enteredfor') }
		                    },
		                    title: {
		                        text: 'New Goal Wizard', // + $(this).text(), // Give the tooltip a title using each elements text
		                        button: true
		                    }
		                },
		                position: {
		                    at: 'top center', // Position the tooltip above the link
		                    my: 'top center',
		                    target: $(window), // Keep the tooltip on-screen at all times
		                    effect: false // Disable positioning animation
		                },
		                show: {
		                    event: 'click',
		                    modal: {
		                        on: true,
		                        blur: false
		                    },
		                    solo: true // Only show one tooltip at a time
		                },
		                hide: 'click',
		                style: {
		                    classes: 'ui-tooltip-wizard ui-tooltip-light ui-tooltip-shadow'
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
        <script type="text/javascript">
            setCurrentMenuItem("nav-goals", "subnav-goallist");
    </script>
</telerik:RadCodeBlock>

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
                                    <span runat="server" id="spnAddNewGoal" class="pull-right" style="margin-right: 20px;">
                                        <a enteredfor='<%# Eval("ID").ToString() %>' class="newgoal btn btn-small btn-success" href="/Goals/New/<%# Eval("ID").ToString() %>">
                                            New Goal
                                        </a>
                                    </span>
                                    <h4 class="media-heading">
                                        <%# Eval("Name") %>
                                    </h4>
                                    
                                     <idea:Label
                                    runat="server"
                                    ID="lblMessage" />
                                   <div runat="server" id="divcontent">
                                    <table style="font-size: 8pt; color: #000000;padding: 15px; width: 100%; margin-bottom: 25px;">
                                                <tr style="background-color: #30a9de; color: #ffffff; padding: 25px; height: 25px; font-size: 14px;">
                                                    <td style="width: 375px; padding-left: 5px;">
                                                        <b>Title</b>
                                                    </td>
                                                    <td style="width:100px; padding-left: 5px;">
                                                        <b>Due Date</b>
                                                    </td>
                                                    <td style="width:175px; padding-left: 5px;">
                                                        <b>Status</b>
                                                    </td>
                                                    <td style="width:125px;">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <asp:Repeater 
                                                ID="nestedGoalsDataList" 
                                                OnItemDataBound="NestedGoalsItemDataBound"
                                                runat="server">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td style="padding-left: 5px;">
                                                                <a href="/Goals/<%# Eval("ID") %>"><%# Eval("Title") %></a>
                                                            </td>
                                                            <td>
                                                                <%# DateTime.
                                                                Parse(Eval("DueDate").ToString()).ToShortDateString() %>
                                                            </td>
                                                            <td>
                                                                <div id="progressbar" 
                                                                class="progress" 
                                                                goalid="<%# Eval("Progress") %>"
                                                                title="<%# Eval("Progress") %>% complete"
                                                                style="vertical-align: bottom; margin-left: 0px; 
                                                                margin-bottom: 5px; margin-top: 5px; 
                                                                width:150px; 
                                                                height:2em; ">
                                                                    <idea:Label
                                                                        runat="server"
                                                                        ID="lblProgressText" class="progresslabelingrid"/>
                                                                </div>
                                                            </td>
                                                            <td style="width: 200px; vertical-align:bottom;">
                                                                <div style="float: left; margin-right: 15px; margin-top: 3px;">
                                                                    <img src="/images/green_flag.png" border="0" alt="Milestones" title="<%# Eval("Milestones.Count") %> milestone(s) have been entered"/>
                                                                    </div>
                                                                    <div style="float: left; margin-left: -35px; margin-top: 3px; height: 24px !important; color: #ffffff; font-weight: bolder;" >
                                                                        <%# Eval("Milestones.Count") %>
                                                                    </div>
                                                                    <div style="float: left; margin-right: 15px; margin-top: 3px;">
                                                                        <img src="/images/comment.png" border="0" alt="Communication" title="<%# Eval("Communication.Count") %> comment(s) have been entered" />
                                                                        </div>
                                                                        <div style="float: left; margin-left: -35px; margin-top: 5px; height: 24px !important; color: #ffffff; font-weight: bolder;" >
                                                                        <%# Eval("Communication.Count") %>
                                                                    </div>
                                                                    <div style="float: left; margin-top: 10px;">
                                                                       <idea:LinkButton
                                                                        runat="server"
                                                                        ID="lbDelete"
                                                                        class="confirm"
                                                                        OnClientClick="return confirm('This will permanently remove goal and all associated data.  Are you sure you want to do this?');"
                                                                        OnClick="DeleteGoalClicked"
                                                                        itemid = '<%# Eval("ID") %>'>
                                                                            <img src="/images/delete.png" border="0" title="Delete Goal" alt="" />Delete
                                                                        </idea:LinkButton>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </table>
                                   </div>
                                </div>
                            </div>
                        </ItemTemplate>

                    </asp:DataList>
</asp:Content>
