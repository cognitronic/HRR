<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="People.aspx.cs" Inherits="HRR.Website.People" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<telerik:RadCodeBlock runat="server" ID="rcbGoalListView">
    <script language="javascript" type="text/javascript">
        $(window).load(function () {
            $("#expander").click(function () {

                $(".collapsibleContainerContent").slideToggle();
                $(this).toggleClass("acc_triggercollapse acc_triggerexpand");
            });
            $("#expander").hover(function () {
                $(this).css('cursor', 'pointer');
            });
            loadProgress();
        });

        function loadProgress() {
            $(".progress").each(function () {
                var v = eval($(this).attr("goalid"));
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
            $('a[class*="newemployee"]').each(function () {
                // We make use of the .each() loop to gain access to each element via the "this" keyword...
                $(this).qtip(
		            {
		                content: {
		                    text: '<img class="throbber" src="/Images/loading.gif" alt="Loading..." />', // Set the text to an image HTML string with the correct src URL to the loading image you want to use

		                    ajax: {
		                        url: '/Wizards/NewEmployee'
		                    },
		                    title: {
		                        text: 'New Employee Wizard', // + $(this).text(), // Give the tooltip a title using each elements text
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
</telerik:RadCodeBlock>
<script language="javascript" type="text/javascript">
    $(window).load(function () {
        //$(".collapsibleContainerContent").slideToggle();
    });
</script>  
<div class="three_fourth last_column">
     <img src='/Images/icon_users.png' style="margin-top: 5px;" height="48px" width="48px" border="0" alt="" /><h3 style="display:inline !important;">Company Staffing Profile</h3>
    <div style="margin-left: 450px; margin-top: -45px !important; margin-bottom: 50px;">
        <idea:LinkButton
        runat="server"
        ID="lbAddEmployee"
        class="newemployee"
        OnClick="AddEmployeeClicked">
            <img src="/Images/add.png" title="Add New Employee" alt="" /> New Employee
        </idea:LinkButton>&nbsp;&nbsp;
        <idea:LinkButton
        runat="server"
        ID="lbInactiveEmployees"
        OnClick="InactiveEmployeeClicked">
            <img src="/Images/delete_user.png" title="Inactive Employees" alt="" /> Inactive Employees
        </idea:LinkButton>
    </div>
    <div style=" margin-top: 5px !important;">
        <span id="expander" class="acc_triggercollapse" style="padding-top: 2px; color:#333333; ">Click to collapse/expand ALL departments</span>
    </div>  
    <div id="divPeople" runat="server" style=" margin-top: 5px !important;"/>
    </div>

    <div class="three_fourth last_column" style="margin-bottom: 50px;">
            <asp:Repeater
            runat="server"
            OnItemDataBound="MasterItemDataBound"
            ID="dlPeople">
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
                                        <div style="float: left; width: 50px; margin-left: 5px; margin-right: 5px;">
                                            <telerik:RadBinaryImage ID="rbiProfile"
                                            runat="server"
                                            AutoAdjustImageControlSize="false"
                                            ResizeMode="None"
                                            ImageUrl='<%# HRR.Core.ResourceStrings.AvatarBasePath + "thumb_" + Eval("AvatarPath") %>'
                                            style="padding: 0px 0px 5px 0px;"/>
                                        </div>
                                        <div style="float: left; margin-left: 0px; margin-bottom: 10px; width: 620px; margin-top: -5px;">
                                            <span style="font-size: 12pt;">
                                                <a href="/People/<%# Eval("Email").ToString() %>">
                                                    <%# Eval("Name").ToString() %>
                                                </a>
                                            </span> - 
                                            <span style="font-size: 10pt; color: #333333;">
                                                <%# Eval("Title") %>
                                            </span>
                                            <div>
                                                <table style='font-size: 8pt; color: #000000;padding: 15px; width: 580px; '>
                                                    <tr>
                                                        <td style='width: 350px;'>
                                                            email: <a href='mailto:<%# Eval("Email").ToString() %>'>
                                                            <%# Eval("Email") %>
                                                            </a>
                                                        </td>
                                                        <td>
                                                            manager: <a href='/People/<%# Eval("Manager.Email").ToString() %>'>
                                                            <%# Eval("Manager.Name") %>
                                                            </a>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
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
</asp:Content>
