<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="Blog.aspx.cs" Inherits="HRR.Website.Blog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<telerik:RadAjaxManagerProxy ID="rampComments" runat="server" >
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="lbPost">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="dlResponses" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="lbPost">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="tbBlogComment"/>
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Simple" Transparency="15" />
    <div class="three_fourth last_column"> 
    <br />
        <!--BLOG STARTS-->
        <div id="blog">
            <!--1ST BLOG POST STARTS-->
            <div class="blog-post">
                <!--POST TOP STARTS--> 
                <div class="post-top">
                    <h2>
                        <idea:Label
                        runat="server"
                        ID="lblTitle" />
                    </h2>
                    <div class="post-meta-data">
                        <span class="meta-date"></span>
                        <span>
                            <idea:Label
                            runat="server"
                            ID="lblDate" />
                        </span>
                        <span class="vertival-divider"></span>
                        <span class="meta-author"></span>
                        <idea:LinkButton
                        runat="server"
                        OnClick="AuthorClicked"
                        ID="lbAuthor" />
                        <span class="vertival-divider"></span>
                        <span class="meta-category"></span>
                        <a href="#">
                            <idea:Label
                            runat="server"
                            ID="lblCategory" />
                        </a>
                        <span class="vertival-divider"></span>
                        <span class="meta-comments"></span>
                        <a href="#">
                            <idea:Label
                            runat="server"
                            ID="lblResponses" />
                        </a>
                    </div>
                </div>
                <!--POST TOP ENDS--> 
                <!--POST CONTENT STARTS--> 
                <div class="post-content">
                    <ul class="gallery clearfix">
                        <li>
                           <%-- <div class="blog-post-image-wrapper">
                                <a href="images/blog-post1-huge.jpg" rel="prettyPhoto" title="">
                                <img src="images/blog-post1.jpg" alt="Audi R8: History" />
                                <div class="zoom" style="background: url(images/zoom-image.png)"></div></a>
                            </div>
                            <div class="three-fourth-image-shadow"></div>--%>
                            <p>
                                <idea:Label
                                runat="server"
                                ID="lblContent" />
                            </p>
                            <hr />
                        </li>
                    </ul>
                </div>
                <!--POST CONTENT ENDS--> 
            </div>
            <!--1ST BLOG POST ENDS-->
        </div>
        
        <div>
            <div class="containerouter">
                <div class="containerinner">
                    <h3>Post A Comment</h3>
                    <div style="margin-bottom: 2px;">
                        <idea:TextBox
                        runat="server"
                        ID="tbBlogComment"
                        TextMode="MultiLine"
                        Width="700px"
                        Height="50px" />
                        <div style="margin: 10px; 0">
                            <asp:RequiredFieldValidator
                            runat="server"
                            ID="rfvPost"
                            InitialValue=""
                            CssClass="error"
                            ErrorMessage="Please enter a comment"
                            Display="Dynamic"
                            ControlToValidate="tbBlogComment" />
                        </div>
                    </div>
                    <div style="float: right;">
                        <idea:LinkButton
                        runat="server"
                        ID="lbPost"
                        Text="Post"
                        CssClass="button big round sky-blue"
                        OnClick="PostClicked" />
                    </div>
                    <br /><br />
                </div>
            </div>
        </div>
        <br />
        <div style="margin-bottom: 50px;">
            <asp:DataList
            runat="server"
            ID="dlResponses">
                <HeaderTemplate>
                <h3>Comments</h3>
                </HeaderTemplate>
                <ItemTemplate>
                <div class="containerouter">
                    <div class="containerinner">
                       <div style="width: 710px; overflow:hidden;" runat="server" id="divContainer">
                            <div style="float: left; margin-right: 5px;">
                            <telerik:RadBinaryImage ID="rbiProfile"
                            runat="server"
                            Width="50px"
                            Height="50px"
                            ImageUrl='<%# Eval("EnteredByRef.AvatarPath") %>'
                            AutoAdjustImageControlSize="true"
                            style="padding: 0px 0px 5px 0px;"/>
                        </div>
                        <div style="float: left;">
                            <table style="width: 655px; padding: 10px 10px 10px 0px;">
                                <tr style="margin-bottom: 30px;">
                                    <td style="background-color: #30a9de; width: 660px; padding: 5px 5px; color: #ffffff; font-weight: bold; height: 20px;">
                                        <div style="float: right;">
                                             <%# DateTime.Parse(Eval("DateCreated").ToString()).ToShortDateString() %>
                                        </div>
                                        <div style="float: left;">
                                           <a class="topnavlink" href='/People/<%# Eval("EnteredByRef.Email").ToString() %>' > <%# Eval("EnteredByRef.Name") %></a>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 655px;">
                                        <div style="margin-left: 10px;">
                                            <%# Eval("Comment") %>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                       </div>
                    </div>
                </div>
                <br />
                </ItemTemplate>
                <FooterTemplate>
                </FooterTemplate>
            </asp:DataList>
        </div>

        
    </div>
        
</asp:Content>
