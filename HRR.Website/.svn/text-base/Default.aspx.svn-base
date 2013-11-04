<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HRR.Website.Default" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Charting" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<telerik:RadCodeBlock runat="server" ID="rcb">
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            loadProgress();
            $(function () {
                $('#ContentPlaceHolder1_divActivityFeed').slimScroll({
                    height: '324px',
                    allowPageScroll: false,
                    railVisible: true
                });
            });

            $(function () {
                $('#ContentPlaceHolder1_divAlertsFeed').slimScroll({
                    height: '163px',
                    allowPageScroll: false,
                    railVisible: true
                });
            });

            $(function () {
                $('#ContentPlaceHolder1_divUpcomingEventsFeed').slimScroll({
                    height: '162px',
                    allowPageScroll: false,
                    railVisible: true
                });
            });
        });
function loadProgress() {
            $(".progress").each(function () {
                var v = eval(<%= GoalProgress %>);
                if (v == 0)
                    v = 1;
                $(this).progressbar({
                    value: v
                }).children("span").appendTo(this);
            });
        }
    </script>
</telerik:RadCodeBlock>
    <div>
        <div style="float: right;">
        

        <div style="width: 200px; margin-right: 0px !important; padding-right: 0px !important; margin-bottom: 30px;  margin-top: 0px; margin-left: 5px; border-left: 1px solid #d0d0d0; border-bottom: 1px solid #d0d0d0;">
        <h3 style="margin-left: 5px; margin-bottom: 10px;">Alerts</h3> 
            <div runat="server" id="divAlertsFeed" style="background-color: #fff; ">
            
                <div runat="server" id="divAlertsMessage" style='margin-bottom: 30px; margin-left: 5px; margin-right: 0px; '>
                    No Alerts Found
                </div>
                <asp:DataList
                runat="server"
                OnItemDataBound="AlertsItemDataBound"
                ID="dlAlerts">
                    <HeaderTemplate>
                        <table style="width: 201px; padding: 10px;">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr class="rowOverlay" style="border-bottom: 1px solid #ddd; ">
                            <td style="vertical-align:top; padding: 5px 10px;">
                                <telerik:RadBinaryImage ID="rbiProfile"
                                runat="server"
                                Width="25px"
                                Height="25px"
                                AutoAdjustImageControlSize="true"
                                ResizeMode="Fit"
                                style="padding: 0px 0px 5px 0px;"/>
                            </td>
                            <td>
                                <idea:Label
                                runat="server"
                                ID="lblMessage" />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:DataList>
            </div>
        </div>
        

        <div style="width: 200px; margin-right: 0px !important; padding-right: 0px !important; margin-bottom: 30px;  margin-top: 0px; margin-left: 5px; border-left: 1px solid #d0d0d0; border-top: 1px solid #d0d0d0; border-bottom: 1px solid #d0d0d0;">
        <h3 style="margin-left: 5px; margin-bottom: 10px;">Celebrations</h3> 
            <div runat="server" id="divUpcomingEventsFeed" style="background-color: #fff; ">
            
                <div runat="server" id="divUpcomingEvents" style='margin-bottom: 30px; margin-left: 5px; margin-right: 0px;'>
                    No Upcoming Celebrations Found
                </div>
                <asp:DataList
            runat="server"
            OnItemDataBound="UpcomingEventsItemDataBound"
            ID="dlEvents">
                <HeaderTemplate>
                    <table style="width: 400px; padding: 10px;">
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="rowOverlay" style="border-bottom: 1px solid #ddd; ">
                        <td style="vertical-align:top; padding: 5px 5px; width: 30px;">
                            <telerik:RadBinaryImage ID="rbiProfile"
                            runat="server"
                            Width="25px"
                            Height="25px"
                            AutoAdjustImageControlSize="true"
                            style="padding: 0px 0px 5px 0px;"/>
                        </td>
                        <td style="width: 400px;">
                            <idea:Label
                            runat="server"
                            ID="lblMessage" />
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:DataList>
            </div>
        </div>

        
        <div style=" width: 200px; margin-right: 0px !important; padding-right: 0px !important; margin-bottom: 30px;  margin-top: 0px; margin-left: 5px; border-left: 1px solid #d0d0d0; border-top: 1px solid #d0d0d0; border-bottom: 1px solid #d0d0d0;">
        <h3 style="margin-left: 5px; margin-bottom: 10px;">Activity Feed</h3> 
            <div runat="server" id="divActivityFeed" style="background-color: #fff; ">
            
                <div runat="server" id="divActivity" style='margin-bottom: 30px; margin-left: 5px; margin-right: 0px;'>
                    No Recent Activity Found
                </div>
                <asp:DataList
                runat="server"
                Width="201px"
                OnItemDataBound="ItemDataBound"
                ID="dlComments">
                    <HeaderTemplate>
            
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="rowOverlay" runat="server" id="divContainer">
                        <div style="float: left; margin-left: 5px;">
                            <telerik:RadBinaryImage ID="rbiProfile"
                            runat="server"
                            Width="25px"
                            Height="25px"
                            AutoAdjustImageControlSize="true"
                            ResizeMode="Fit"
                            ImageUrl='<%# HRR.Core.ResourceStrings.AvatarBasePath + "thumb_" + Eval("PerformedByRef.AvatarPath") %>'
                            style="padding: 10px 0px 5px 0px;"/>
                        </div>
                        <div style="float: left; margin: 5px 5px 5px 5px; width: 160px;">
                            <span style="font-size: 8pt;">
                                <a href='<%# "/People/" + Eval("PerformedByRef.Email").ToString() %>'><%#Eval("PerformedByRef.Name") %></a>                 
                            </span>
                            <span>
                                <idea:Label
                                runat="server"
                                ID="lblMessage" />
                            </span>
                        </div>
                        <hr  style="margin: 5px 0px !important;"/>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </div>
        </div>
        <div style="float: left;">
            <div style="margin-top: 5px;">
                <div style="float: left; width: 265px;">
                    <div class="widgetouter">
                        <div class="widgetinner">
                            <h3 style="margin-left: 5px; margin-bottom: 10px;">My Stats</h3> 
                            <div>
                                <h6>
                                    Employee Score: 
                                </h6>
                                    <idea:Label
                                    runat="server"
                                    style="font-size: 22px; font-weight: bold;"
                                    ID="lblEmployeeScore" />
                            </div>
                            <div>
                                <h6>Comment Totals:</h6>
                                <div style="padding: 2px;">
                                    <span style="font-weight: bolder">Left for:  </span>
                                    <span runat="server" id="lblPositiveLeftFor" style="color: #000000; font-size: 22px; margin-right: 10px; ">
                                    </span>
                                    <span runat="server" id="lblConstructiveLeftFor" style="color: #ff0000; margin-right: 10px; font-size: 22px">
                                    </span>
                                </div>
                                <div style="padding: 2px;">
                                    <span style="font-weight: bolder">Left by :  </span>
                                    <span runat="server" id="lblPositiveLeftBy" style="color: #000000; font-size: 22px; margin-right: 10px; "></span>
                                    <span runat="server" id="lblConstructiveLeftBy" style="color: #ff0000; margin-right: 10px; font-size: 22px"> </span>
                                </div>
                            </div>
                            <div>
                                <h6>
                                    Total Goal Progress: 
                                </h6>
                                <div id="progressbar" 
                                class="progress" 
                                style="margin-left: 0px; 
                                margin-bottom: 5px; 
                                width:240px; 
                                height:2em; ">
                                    <idea:Label
                                        runat="server"
                                        ID="lblProgressText" />
                                </div>
                            </div><br />
                        </div>
                    </div>
                </div>
                <div style="float: left; margin-left: 10px;  width: 265px;">
                    <div class="widgetouter">
                        <div class="widgetinner">
                            <h3 style="margin-left: 5px; margin-bottom: 10px;">Current Poll</h3> 
                            <div>
                                <idea:Label
                                runat="server"
                                style="font-weight: bold;"
                                ID="lblCurrentPollQuestion" />
                            </div>
                            <div runat="server" id="divCurrentChart" style="margin-bottom: 20px;">
                                <telerik:RadChart 
                                 ID="rcCurrentPoll" 
                                 runat="server" 
                                 Width="245px" 
                                 Height="270" 
                                 DefaultType="Pie"
                                 OnItemDataBound="CurrentPollItemDataBound"
                                 Skin="Vista"
                                 AutoLayout="true"
                                 Legend-Appearance-Position-AlignedPosition="Bottom"
                                 ChartTitle-Visible="false"
                                 CreateImageMap="false">
                                 <Series>
                                    <telerik:ChartSeries Name="Series 1" Type="Pie" DataYColumn="TotalSelected" DataLabelsColumn="TotalSelected">
                                    <Appearance  LegendDisplayMode="ItemLabels" >
                                    </Appearance>
                                    </telerik:ChartSeries>
                                </Series>
                                <PlotArea Appearance-Dimensions-Width="100%">
                                    <Appearance></Appearance>
                                    <XAxis LayoutMode="Normal" AutoScale="true">
                                    </XAxis>
                                </PlotArea>
                            </telerik:RadChart>
                            </div>
                            <div runat="server" id="divCurrentOptions" style="margin-bottom: 20px;">
                                <asp:RadioButtonList
                                runat="server"
                                style="margin-left: 20px;"
                                RepeatDirection="Vertical"
                                TextAlign="Right"
                                RepeatLayout="OrderedList"
                                ID="rblCurrent">
                                </asp:RadioButtonList><br />
                                <idea:LinkButton
                                runat="server"
                                OnClick="SubmitPollClicked"
                                ID="lbSubmitPoll"
                                CssClass="button big round sky-blue">
                                    Submit
                                </idea:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            <div style="clear: left; margin-bottom: 10px;" />
            </div>
            <div style="margin-top: 5px;">
                <div style="float: left; width: 540px;  margin-bottom: 30px;">
                      <div class="widgetouter">
                        <div class="widgetinner">
                            <h3 style="margin-left: 5px; margin-bottom: 10px;">Blog</h3> 
                            <div runat="server" id="divBlog" style='margin-bottom: 20px; margin-left: 7px; margin-right: 15px;'>
                                No Posts Found
                            </div>
                            <asp:DataList
                            runat="server"
                            ID="dlBlog">
                                <HeaderTemplate>
                                    <!--BLOG STARTS-->
                                    <div id="blog">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <!--1ST BLOG POST STARTS-->
                                    <div class="blog-post">
                                        <!--POST TOP STARTS--> 
                                        <div class="post-top">
                                            <h2>
                                                <a href='<%# "/Blogs/" + Eval("ID").ToString() %>' ><%# Eval("Title") %></a>
                                            </h2>
                                            <div class="post-meta-data">
                                                <span class="meta-date"></span>
                                                <span><%# DateTime.Parse(Eval("StartDate").ToString()).ToString("MMM dd, yyyy") %></span>
                                                <span class="vertival-divider"></span>
                                                <span class="meta-author"></span>
                                               <a href='<%# "/People/" + Eval("EnteredByRef.Email") %>'><%# Eval("EnteredByRef.Name") %></a>
                                                <span class="vertival-divider"></span>
                                                <span class="meta-category"></span>
                                                <a href='#'><%# Eval("Category.Name") %></a>
                                                <span class="vertival-divider"></span>
                                                <span class="meta-comments"></span>
                                                <a href='<%# "/Blogs/" + Eval("ID").ToString() %>'><%# Eval("Responses.Count").ToString() %> Comments</a>
                                            </div>
                                        </div>
                                        <!--POST TOP ENDS--> 
                                        <!--POST CONTENT STARTS--> 
                                        <div class="post-content">
                                            <ul class="gallery clearfix">
                                                <li>
                                                    <p>
                                                        <%# IdeaSeed.Core.Utils.Utilities.FormatTextForCondensedDisplay(Eval("BlogContent"), 400) %><a href='<%# "/Blogs/" + Eval("ID").ToString() %>'>Read More</a>
                                                    </p>
                                                    <hr />
                                                </li>
                                            </ul>
                                        </div>
                                        <!--POST CONTENT ENDS--> 
                                    </div>
                
                                </ItemTemplate>
                                <FooterTemplate>
                                    <!--1ST BLOG POST ENDS-->
                                    </div>
                                </FooterTemplate>
                            </asp:DataList>
                        </div>
                    </div>
                </div>
            </div>
        <%--<div class="containerouter" style="float: left; width: 525px !important; margin-top: 5px;">
        <div class="containerinner">
            <h4 style="margin-left: 5px;">Comments For Employee </h4>
             <telerik:RadChart 
             ID="rcCommentTypes" 
             runat="server" 
             Width="415px" 
             DataGroupColumn="CommentType" 
             ChartTitle-TextBlock-Text=""
             AutoTextWrap="true"
             PlotArea-Appearance-Border-Visible="false"
             PlotArea-YAxis-Appearance-MinorGridLines-Visible="false"
             PlotArea-XAxis-Appearance-MajorGridLines-Visible="false"
             PlotArea-YAxis-Appearance-MajorGridLines-Visible="false"
             PlotArea-Appearance-Dimensions-Margins-Left="130px"
             SeriesOrientation="Horizontal" 
             Skin="Web20">
            <Legend Visible="false">
                <Appearance GroupNameFormat="#VALUE">
                </Appearance>
            </Legend>
            <PlotArea>
                <XAxis DataLabelsColumn="Name">
                </XAxis>
            </PlotArea>
        </telerik:RadChart>
            </div>
        </div>--%>
        </div>
        <br />
    </div>
</asp:Content>
