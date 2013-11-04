<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReviewListView.ascx.cs" Inherits="HRR.Website.Views.ReviewListView" %>
<script language="javascript" type="text/javascript">
    $(window).load(function () {
        $(".collapsibleContainerContent").slideToggle();
    });
</script>  
<div class="three_fourth last_column">
    <img src='/Images/clipboard48.png' style="margin-top: 5px;" height="48px" width="48px" border="0" alt="" /> <h3 style="display:inline !important;">Current Review Activity </h3>
    <div style="margin-left: 390px; margin-top: -60px !important; margin-bottom: 50px;">
        <span>
            <idea:LinkButton
            runat="server"
            ID="lbRatingScales"
            OnClick="RatingScalesClicked">
                <img src="/images/star_full16.png" alt="" /> Manage Rating Scales
            </idea:LinkButton>
        </span>
        <span>
            <idea:LinkButton
            runat="server"
            ID="lbTemplates"
            OnClick="TemplatesClicked">
                <img src="/images/note16.png" alt="" /> Manage Review Templates
            </idea:LinkButton>
        </span>
    </div>
    <div style=" margin-top: 10px !important;">
        Click on a department to expand
    </div>  
<div id="divReview" runat="server"/>
</div>