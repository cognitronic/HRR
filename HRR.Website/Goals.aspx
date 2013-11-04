<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="Goals.aspx.cs" Inherits="HRR.Website.Goals" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<telerik:RadAjaxManagerProxy ID="rampGoals" runat="server" >
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="divtest">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="divtest" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Simple" Transparency="15" />
<telerik:RadCodeBlock runat="server" ID="rcbGoalListView">
    <script language="javascript" type="text/javascript">
        $(window).load(function () {
            //$(".collapsibleContainerContent").slideToggle();

            $("#expander").hover(function () {
                $(this).css('cursor', 'pointer');
            });
            loadProgress();

            $("#expander").click(function () {

                $(".collapsibleContainerContent").slideToggle();
                $(this).toggleClass("acc_triggercollapse acc_triggerexpand");
            });
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



//            function dialogue(content, title) {
//                /* 
//                * Since the dialogue isn't really a tooltip as such, we'll use a dummy
//                * out-of-DOM element as our target instead of an actual element like document.body
//                */
//                $('<div />').qtip(
//		        {
//		            content: {
//		                text: content,
//		                title: title
//		            },
//		            position: {
//		                my: 'center', at: 'center', // Center it...
//		                target: $(window) // ... in the window
//		            },
//		            show: {
//		                ready: true, // Show it straight away
//		                modal: {
//		                    on: true, // Make it modal (darken the rest of the page)...
//		                    blur: false // ... but don't close the tooltip when clicked
//		                }
//		            },
//		            hide: false, // We'll hide it maunally so disable hide events
//		            style: 'ui-tooltip-light ui-tooltip-rounded ui-tooltip-dialogue', // Add a few styles
//		            events: {
//		                // Hide the tooltip when any buttons in the dialogue are clicked
//		                render: function (event, api) {
//		                    $('button', api.elements.content).click(api.hide);
//		                },
//		                // Destroy the tooltip once it's hidden as we no longer need it!
//		                hide: function (event, api) { api.destroy(); }
//		            }
//		        });
//            }

//            // Our Confirm method
//            function Confirm(question, callback) {
//                // Content will consist of the question and ok/cancel buttons
//                var message = $('<p />', { text: question }),
//			ok = $('<button />', {
//			    text: 'Ok',
//			    click: function () { callback(true); }
//			}),
//			cancel = $('<button />', {
//			    text: 'Cancel',
//			    click: function () { callback(false); }
//			});

//                dialogue(message.add(ok).add(cancel), 'Do you agree?');
//            }

//            $('.confirm').click(function (e) {
//                var item = $(this).attr("itemid");
//                Confirm('Click Ok if you love qTip2', function (yes) {
//                    return yes;
//                });
//            });

        });
        </script>
</telerik:RadCodeBlock>
<div class="three_fourth last_column" runat="server" id="divtest">
    <img src='/Images/diagram48.png' height="48px" width="48px" border="0" alt="" /> <h3 style="display:inline !important;">Goal Management</h3>  
    <div style=" margin-top: 5px !important;">
        <span id="expander" class="acc_triggercollapse" style="padding-top: 2px; color:#333333; ">Click to collapse/expand ALL departments</span>
    </div>  
<div id="divGoals" runat="server"/>

    <div style="margin-bottom: 50px;">
            <asp:Repeater
            runat="server"
            OnItemDataBound="MasterItemDataBound"
            ID="dlGoals">
                <HeaderTemplate>
                    <div style="overflow:auto;">
                </HeaderTemplate>
                <ItemTemplate>
                    <div runat="server" id="divTitle" class="collapsibleContainer" 
                    paneltitle="" style="margin-bottom: 5px;">
                        <asp:Repeater 
                        ID="nestedDataList" 
                        OnItemDataBound="NestedItemDataBound"
                        runat="server">
                            <ItemTemplate>

                                <div runat="server" id="divPerson" 
                                style="padding: 3px; background-color: #eeeeee; margin-top: 15px;">
                                    <div style="overflow:auto; background-color: #ffffff; padding: 10px;">
                                        <div style="float: right;">
                                            <span runat="server" id="spnAddNewGoal">
                                                <a enteredfor='<%# Eval("ID").ToString() %>' class="newgoal" href="/Goals/New/<%# Eval("ID").ToString() %>">
                                                    <img src="/Images/add.png" title="Create New Goal" alt=""/>New Goal
                                                </a>
                                            </span>
                                        </div>
                                        <div style="float: left; margin-left: 5px; margin-right: 5px;">
                                            <telerik:RadBinaryImage ID="rbiProfile"
                                            runat="server"
                                            ResizeMode="Fit"
                                            ImageUrl='<%# HRR.Core.ResourceStrings.AvatarBasePath + "thumb_" + Eval("AvatarPath") %>'
                                            style="padding: 0px 0px 5px 0px;"/>
                                        </div>
                                        <div style="float: left; margin-left: 0px; margin-bottom: 10px; width: 570px; margin-top: -5px;">
                                            <span style="font-size: 12pt;">
                                                <a href="/People/<%# Eval("Email").ToString() %>">
                                                    <%# Eval("Name").ToString() %>
                                                </a>
                                            </span> - 
                                            <span style="font-size: 10pt; color: #333333;">
                                                <%# Eval("Title") %>
                                            </span>
                                        </div>
                                        <div style="clear: both;float:left; margin-top: 3px;margin-left: 5px; margin-right: 5px; width: 700px;">
                                            <table style="font-size: 8pt; color: #000000;padding: 15px; width: 700px; margin-bottom: 25px;">
                                                <tr style="background-color: #51C9FF; color: #ffffff; padding: 25px; height: 25px; font-size: 14px;">
                                                    <td style="width: 375px; padding-left: 5px;">
                                                        <b>Title</b>
                                                    </td>
                                                    <td style="width:100px;">
                                                        Due Date
                                                    </td>
                                                    <td style="width:175px;">
                                                        Status
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
                                                                    <div style="float: left; margin-left: -35px; margin-top: 6px; height: 24px !important; color: #ffffff; font-weight: bolder;" >
                                                                        <%# Eval("Milestones.Count") %>
                                                                    </div>
                                                                    <div style="float: left; margin-right: 15px; margin-top: 3px;">
                                                                        <img src="/images/comment.png" border="0" alt="Communication" title="<%# Eval("Communication.Count") %> comment(s) have been entered" />
                                                                        </div>
                                                                        <div style="float: left; margin-left: -35px; margin-top: 8px; height: 24px !important; color: #ffffff; font-weight: bolder;" >
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
                        </asp:Repeater>
                    </div>
                </ItemTemplate>
                <FooterTemplate>
                    </div>
                </FooterTemplate>
            </asp:Repeater>
        </div>
</div>
</asp:Content>
