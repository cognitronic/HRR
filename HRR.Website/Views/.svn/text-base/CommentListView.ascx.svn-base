<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CommentListView.ascx.cs" Inherits="HRR.Website.Views.CommentListView" %>
<telerik:RadAjaxManagerProxy ID="rampComments" runat="server" >
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="dlComments">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="dlComments" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server"  Skin="Simple" Transparency="15" />
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
                        Width="50px"
                        Height="50px"
                        AutoAdjustImageControlSize="true"
                        ResizeMode="Fit"
                        DataValue='<%# HRR.Web.Utils.ImageResize.GetImageBytes(Eval("EnteredByRef.AvatarPath").ToString())  %>'
                        style="padding: 0px 0px 5px 0px;"/>
                    </div>
                    <div runat="server" style="float: left; margin-left: 10px; margin-top: 0px; width: 600px;">
                        <span style="font-size: 14pt;">
                            <span style="float: right;">
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
                    <div runat="server" style="margin-left: 60px;">
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