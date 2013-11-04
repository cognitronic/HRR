<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BlogFeedView.ascx.cs" Inherits="HRR.Website.Views.BlogFeedView" %>
<div style="float: left; width: 540px;  margin-bottom: 30px;">
    <div class="widgetouter">
        <div class="widgetinner">
            <h3 style="margin-left: 5px; margin-bottom: 10px;">Blog</h3> 
            <div runat="server" id="divBlog" style='margin-bottom: 20px; margin-left: 7px; margin-right: 15px;'>
                No Posts Found
            </div>
            <asp:DataList
            runat="server"
            OnItemDataBound="ItemDataBound"
            ID="dlList">
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
                                    <%--<div class="blog-post-image-wrapper">
                                        <a href="images/blog-post1-huge.jpg" rel="prettyPhoto" title="">
                                        <img src="images/blog-post1.jpg" alt="Audi R8: History" />
                                        <div class="zoom" style="background: url(images/zoom-image.png)"></div></a>
                                    </div>
                                    <div class="three-fourth-image-shadow"></div>--%>
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