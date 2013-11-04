<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="HRRV2.Website.Staff" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:RadAjaxManagerProxy ID="rampComments" runat="server" >
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="ddlStatus">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="divStaff" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Simple" Transparency="15" />
    <script type="text/javascript">
        setCurrentMenuItem("nav-people", "subnav-staff");
    </script>
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
<script lang="javascript" type="text/javascript">
    $(window).load(function () {
        //$(".collapsibleContainerContent").slideToggle();
    });
</script>  

    <div class="page-header">
        <h5><i class="icon-th-large"></i>Staff List</h5>
        <span style="float: right; margin-top: -5px; margin-left: 5px;">
            <a style="cursor: pointer;"
            href="/People/ImportStaff"
            class="btn btn-normal btn-success" 
            title="Import Employees">
                <i class="icon-share"></i> Import Employees
            </a>
        </span>
        <span style="float: right; margin-top: -5px;">
            <a style="cursor: pointer;"
            class="btn btn-normal btn-success newemployee" 
            title="Add New Employee">
                <i class="icon-plus"></i> Add New Employee
            </a>
        </span>
        <span style="float: right; margin-top: 2px;">
            <b>Employment: </b>
            <idea:DropDownList
            runat="server"
            Skin="Metro"
            AutoPostBack="true"
            CausesValidation="false"
            OnSelectedIndexChanged="StatusSelectedIndexChanged"
            ID="ddlStatus">
                <Items>
                    <telerik:RadComboBoxItem
                    Value="true"
                    Text="Current" />
                    <telerik:RadComboBoxItem
                    Value="false"
                    Text="Terminated" />
                </Items>
            </idea:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;
        </span>
    </div>
    <div class="body">
        <div>
            <div runat="server" id="divStaff">
                <asp:DataList
                runat="server"
                OnItemDataBound="ItemDataBound"
                OnItemCommand="StaffItemCommand"
                style="width: 100%;"
                ID="dlPeople">
                    <ItemTemplate>
                        <div class="media" style=" border-bottom: 1px solid #dadada; margin-bottom: 20px;" runat="server" id="divRow">
                            <div class="pull-left">
                                <a href="#" title="">
                                    <telerik:RadBinaryImage ID="rbiProfile"
                                    runat="server"
                                    AutoAdjustImageControlSize="true"
                                    ResizeMode="Fit"
                                    Height="25"
                                    Width="25"
                                    style="padding: 0px 0px 0px 0px;"/>
                            
                                </a>
                            </div>
                            <div class="media-body">
                                <div style="float:left; width: 400px;">
                                <b class="media-heading">
                                    <a href="/People/<%# Eval("Email") %>/Edit">
                                    <%# Eval("Name") %></a> -
                                </b> <%# Eval("Title") %>
                                </div>
                                <div >
                                    <b>manager:</b> <%# Eval("Manager.Name") %>
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
        </div>
    </div>
</asp:Content>
