<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="GoalTemplates.aspx.cs" Inherits="HRRV2.Website.GoalTemplates" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<telerik:RadAjaxManagerProxy ID="rampComments" runat="server" >
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="rgTemplates">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgTemplates" LoadingPanelID="RadAjaxLoadingPanel1"/>
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server"  Skin="Simple" Transparency="15" />
<telerik:RadCodeBlock runat="server" ID="rcbGoalListView">
    <script lang="javascript" type="text/javascript">
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
            $('a[class*="newtemplate"]').each(function () {
                // We make use of the .each() loop to gain access to each element via the "this" keyword...
                $(this).qtip(
		            {
		                content: {
		                    text: '<img class="throbber" src="/Images/loading.gif" alt="Loading..." />', // Set the text to an image HTML string with the correct src URL to the loading image you want to use

		                    ajax: {
		                        url: '/Wizards/NewGoalTemplate',
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
    <script type="text/javascript">
        setCurrentMenuItem("nav-goals", "subnav-goaltemplates");
    </script>
    <div class="page-header">
        <h5><i class="icon-th-large"></i>Goal Templates</h5>
        <span style="float: right; margin-top: -5px;">
            <a style="cursor: pointer;"
            class="btn btn-normal btn-success newtemplate" 
            title="Add New Template">
                <i class="icon-plus"></i> Add New Template
            </a>
        </span>
    </div>
    <div class="body">
        <div>
            <div runat="server" id="divStaff">
                <asp:DataList
                runat="server"
                style="width: 100%;"
                ID="dlPeople">
                    <HeaderTemplate>
                        <table style="width: 100%;">
                            <tr>
                                <td style="border-bottom: 1px solid #dadada; margin-bottom: 20px;">
                                    <b>Title</b>
                                </td>
                                <td style="border-bottom: 1px solid #dadada; margin-bottom: 20px;">
                                    <b>Entered By</b>
                                </td>
                                <td style="border-bottom: 1px solid #dadada; margin-bottom: 20px;">
                                </td>
                                <td style="border-bottom: 1px solid #dadada; margin-bottom: 20px;">
                                </td>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr >
                            <td>
                                <%# Eval("Title") %>
                            </td>
                            <td>
                                <%# Eval("EnteredByRef.Name") %>
                            </td>
                            <td>
                                <idea:LinkButton
                                runat="server"
                                ID="lbEdit"
                                OnClick="EditClicked"
                                itemid='<%# Eval("ID").ToString() %>'>
                                    <asp:Image
                                    runat="server"
                                    ID="imgEdit"
                                    ToolTip="Edit Group"
                                    ImageUrl="~/Images/pencil.png"
                                    Style="border: none;" />
                                </idea:LinkButton>
                            </td>
                            <td>
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
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
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
        </div>
    </div>
</asp:Content>
