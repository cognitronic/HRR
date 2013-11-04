<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GoalListView.ascx.cs" Inherits="HRR.Website.Views.GoalListView" %>
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
                $(this).progressbar({
                    value: v
                }).children("span").appendTo(this);
                $(this).find(".progresslabelingrid").html($(this).attr("goalid") + "% complete");
            });
        }
    </script>  
</telerik:RadCodeBlock>
<div class="three_fourth last_column">
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
                                                <a href="/Goals/New/<%# Eval("ID").ToString() %>">
                                                    <img src="/Images/add.png" title="Create New Goal" alt=""/>New Goal
                                                </a>
                                            </span>
                                        </div>
                                        <div style="float: left; margin-left: 5px; margin-right: 5px;">
                                            <telerik:RadBinaryImage ID="rbiProfile"
                                            runat="server"
                                            Width="50px"
                                            Height="50px"
                                            ResizeMode="Fit"
                                            DataValue='<%# HRR.Web.Utils.ImageResize.GetImageBytes(Eval("AvatarPath").ToString())  %>'
                                            style="padding: 0px 0px 5px 0px;"/>
                                        </div>
                                        <div style="float: left; margin-left: 0px; margin-bottom: 10px; width: 620px; margin-top: -28px;">
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
                                                    <td style="width: 275px; padding-left: 5px;">
                                                        <b>Title</b>
                                                    </td>
                                                    <td style="width:75px;">
                                                        Due Date
                                                    </td>
                                                    <td style="width:150px;">
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
                                                                <%# Eval("Title") %>
                                                            </td>
                                                            <td>
                                                                <%# DateTime.
                                                                Parse(Eval("DueDate").ToString()).ToShortDateString() %>
                                                            </td>
                                                            <td>
                                                                <div id="progressbar" 
                                                                class="progress" 
                                                                goalid="<%# Eval("Progress") %>"
                                                                title="<%# Eval("Progress") %>  % complete"
                                                                style="vertical-align: top; margin-left: 0px; 
                                                                margin-bottom: 5px; 
                                                                width:200px; 
                                                                height:1em; ">
                                                                    <idea:Label
                                                                        runat="server"
                                                                        ID="lblProgressText" class="progresslabelingrid"/>
                                                                </div>
                                                            </td>
                                                            <td style="width: 150px;">
                                                                <div style="float: left; margin-right: 15px;">
                                                                    <img src="/images/green_flag.png" border="0" alt="Milestones" title="<%# Eval("Milestones.Count") %> milestone(s) have been entered"/>
                                                                    </div>
                                                                    <div style="float: left; margin-left: -35px; margin-top: 3px; height: 24px !important; color: #ffffff; font-weight: bolder;" >
                                                                        <%# Eval("Milestones.Count") %>
                                                                    </div>
                                                                    <div style="float: left; margin-right: 15px; margin-top: 3px;">
                                                                        <img src="/images/comment.png" border="0" alt="Communication" title="<%# Eval("Communication.Count") %> comment(s) have been entered" />
                                                                        </div>
                                                                        <div style="float: left; margin-left: -35px; margin-top: 8px; height: 24px !important; color: #ffffff; font-weight: bolder;" >
                                                                        <%# Eval("Communication.Count") %>
                                                                    </div>
                                                                    <div style="float: left; margin-top: 10px;">
                                                                    <a href="/Goals/<%# Eval("ID") %>">
                                                                        <img src="/images/pencil.png" border="0" title="View Goal" alt="" />View</a></div></td></tr>
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