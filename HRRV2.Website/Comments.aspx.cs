using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using HRR.Core.Domain;
using HRR.Core.Security;
using HRR.Services;
using HRR.Web.Bases;
using IdeaSeed.Core;
using HRR.Core;
using System.Text;
using HRR.Web.Utils;
using System.Configuration;
using Telerik.Web.UI;

namespace HRRV2.Website
{
    public partial class Comments : HRRBasePage
    {
        ICacheStorage _cache = new MemcacheCacheAdapter();

        public int CurrentPage
        {
            get
            {
                // look for current page in ViewState
                object o = this.ViewState["_CurrentPage"];
                if (o == null)
                    return 0; // default page index of 0
                else
                    return (int)o;
            }

            set
            {
                this.ViewState["_CurrentPage"] = value;
            }
        }

        //public IdeaSeed.Web.UI.DropDownList SortDDL
        //{
        //    get
        //    {
        //        return ddlSort;
        //    }
        //}

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            //divFollowUp.Visible = false;
            if (SecurityContextManager.Current.CurrentTeamID != null)
            {
                ddlTeams.SelectedValue = SecurityContextManager.Current.CurrentTeamID.ToString();
            }
            else
            {
                if (ddlTeams.SelectedIndex == -1)
                {
                    if (ddlTeams.Items.Count > 1)
                    {
                        ddlTeams.SelectedIndex = 1;
                        SecurityContextManager.Current.CurrentTeamID = Convert.ToInt16(ddlTeams.SelectedValue);
                        //ddlCommentFor.LoadUsers();
                    }
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadAutoSuggest();
            if (!IsPostBack)
            {
                LoadComments();

                if (((Person)SecurityContextManager.Current.CurrentUser).RoleID == (int)SecurityRole.READ_ONLY)
                {
                    //divAddComment.Visible = false;
                }
                else
                {
                    //divAddComment.Visible = true;
                }

                if (((Person)SecurityContextManager.Current.CurrentUser).RoleID < (int)SecurityRole.EXECUTIVE_MANAGEMENT)
                {
                    //spanFlagged.Visible = false;
                }
            }
        }

        protected void SortSelectedIndexChanged(object o, EventArgs e)
        {
            LoadComments();
        }

        protected void RateClicked(object o, EventArgs e)
        {
            //if (((RadRating)o).SelectedItem.Value == -1)
            //    divFollowUp.Visible = true;
            //else
            //    divFollowUp.Visible = false;
        }

        protected void PostClicked(object o, EventArgs e)
        {
            SaveComment();
            Response.Redirect(SecurityContextManager.Current.CurrentURL);
        }

        protected void TeamSelectedIndexChanged(object o, EventArgs e)
        {
            _cache.Remove(SecurityContextManager.Current.CurrentUser.ID.ToString() + "_CommentsFeed");
            if (ddlTeams.SelectedIndex > 0)
            {
                SecurityContextManager.Current.CurrentTeamID = Convert.ToInt16(ddlTeams.SelectedValue);
                LoadComments();
                //ddlCommentFor.LoadUsers();
            }
            else
            {
                SecurityContextManager.Current.CurrentTeamID = null;
                LoadComments();
                //ddlCommentFor.LoadUsers();
            }
        }

        private void SaveComment()
        {
            var c = new HRR.Core.Domain.Comment();
            //c.CategoryID = Convert.ToInt16(ddlCommentCategory.SelectedValue);
            //c.CommentType = Convert.ToInt16(ratingBinary.SelectedItem.Value);
            c.DateCreated = DateTime.Now;
            c.EnteredBy = SecurityContextManager.Current.CurrentUser.ID;
            //c.EnteredFor = Convert.ToInt16(ddlCommentFor.SelectedValue);
            c.FlaggedAsInappropriate = false;
            //c.Message = tbNewComment.Text;
            c.TeamID = Convert.ToInt16(ddlTeams.SelectedValue);
            c.FollowUpDate = DateTime.Now.AddDays(7);
            c.SecurityType = 1;
            c.AccountID = SecurityContextManager.Current.CurrentAccount.ID;
            c.LastUpdated = DateTime.Now;
            c.ChangedBy = SecurityContextManager.Current.CurrentUser.ID;
            c.IncludedInReview = true;
            new CommentServices().Save(c);

            var a = new Activity();
            a.AccountID = c.AccountID;
            a.ActivityType = (int)ActivityType.COMMENT;
            a.DateCreated = DateTime.Now;
            a.PerformedBy = c.EnteredBy;
            a.PerformedFor = c.EnteredFor;
            a.URL = "/Comments/" + c.ID.ToString();
            new ActivityServices().Save(a);


            IdeaSeed.Core.Data.NHibernate.NHibernateSessionManager.Instance.CloseSession();


            var nc = new CommentServices().GetByID(c.ID);
            if (new TeamMemberServices().GetByPersonIDTeamID(c.EnteredFor, c.TeamID).RecievesNotifications)
            {
                EmailHelper.SendNewCommentNotification(nc);
            }
            _cache.Remove(SecurityContextManager
                    .Current
                    .CurrentUser.ID.ToString() + "_CommentsFeed");
            LoadComments();
        }

        private void LoadTeams()
        {
            //var list = new List<Team>();
            //foreach (var i in ((Person)SecurityContextManager.Current.CurrentUser).Memberships)
            //{
            //    list.Add(i.TeamRef);
            //}
            //rtvTeams.DataSource = list;
            //rtvTeams.DataTextField = "Name";
            //rtvTeams.DataValueField = "ID";
            //rtvTeams.DataBind();
        }

        protected void LikeClicked(object o, EventArgs e)
        {
            var c = new CommentLike();
            c.CommentID = Convert.ToInt16(((LinkButton)o).Attributes["postid"]);
            c.PersonID = SecurityContextManager.Current.CurrentUser.ID;
            c.DateCreated = DateTime.Now;
            new CommentLikeServices().Save(c);
            _cache.Remove(SecurityContextManager
                    .Current
                    .CurrentUser.ID.ToString() + "_CommentsFeed");
            LoadComments();
        }

        protected void ReportPostClicked(object o, EventArgs e)
        {
            if (SecurityContextManager.Current.CurrentURL.Contains("Flagged"))
            {
                var c = new CommentServices().GetByID(Convert.ToInt16(((LinkButton)o).Attributes["postid"]));
                c.FlaggedAsInappropriate = false;
                new CommentServices().Save(c);
            }
            else
            {
                var c = new CommentServices().GetByID(Convert.ToInt16(((LinkButton)o).Attributes["postid"]));
                c.FlaggedAsInappropriate = true;
                new CommentServices().Save(c);
                IdeaSeed.Core.Data.NHibernate.NHibernateSessionManager.Instance.CloseSession();
                var nc = new CommentServices().GetByID(c.ID);

                var emails = "";
                foreach (var nu in new NotificationSubscriberServices().GetByNotificationIDAccountID((int)Notification.FLAGGED_COMMENT, SecurityContextManager.Current.CurrentAccount.ID))
                {
                    emails += nu.Subscriber.Email + ",";
                }
                EmailHelper.SendFlaggedCommentNotification(nc, emails.Remove(emails.Length - 1, 1));

            }
            _cache.Remove(SecurityContextManager
                    .Current
                    .CurrentUser.ID.ToString() + "_CommentsFeed");
            LoadComments();
        }

        protected void ViewCommentClicked(object o, EventArgs e)
        {
            Response.Redirect("/Comments/" + ((LinkButton)o).Attributes["itemid"]);
        }

        protected void DeleteCommentClicked(object o, EventArgs e)
        {
            var c = new CommentServices().GetByID(Convert.ToInt32(((LinkButton)o).Attributes["itemid"]));
            new CommentServices().Delete(c);
            _cache.Remove(SecurityContextManager.Current.CurrentUser.ID.ToString() + "_CommentsFeed");
            LoadComments();
        }

        protected void ResponseCountClicked(object o, EventArgs e)
        {
            Response.Redirect("/Comments/" + ((LinkButton)o).Attributes["itemid"]);
        }

        protected void PostResponseClicked(object o, EventArgs e)
        { 
            
        }

        protected void ItemDataBound(object o, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var p = ((HRR.Core.Domain.Comment)e.Item.DataItem);
                var lbl = (IdeaSeed.Web.UI.Label)e.Item.FindControl("lblMessage");
                var visibleBy = (IdeaSeed.Web.UI.Label)e.Item.FindControl("lblVisibleBy");
                var delete = (IdeaSeed.Web.UI.LinkButton)e.Item.FindControl("lbDeleteComment");
                var enteredby = (HyperLink)e.Item.FindControl("lbEnteredBy");
                var enteredfor = (HyperLink)e.Item.FindControl("lbEnteredFor");
                var responses = (IdeaSeed.Web.UI.LinkButton)e.Item.FindControl("lbResponseCount");
                var likebtn = (IdeaSeed.Web.UI.LinkButton)e.Item.FindControl("lbLike");
                var avatar = (Telerik.Web.UI.RadBinaryImage)e.Item.FindControl("rbiProfile");
                var likes = (HtmlGenericControl)e.Item.FindControl("span_likes");
                var responsecount = (HtmlGenericControl)e.Item.FindControl("span_responses");
                var commentRow = (HtmlGenericControl)e.Item.FindControl("divRow");
                var commentType = (HtmlGenericControl)e.Item.FindControl("comment_type");
                var responseph = (HtmlGenericControl)e.Item.FindControl("phResponses");


                if (p.EnteredBy != SecurityContextManager.Current.CurrentUser.ID)
                {
                    if (p.IsPrivate)
                    {
                        commentRow.Visible = false;
                    }
                    else
                    {
                        switch (p.CommentType)
                        {
                            case -1:
                                commentType.Attributes.Add("class", "icon-comment");
                                if (p.EnteredForRef.AvatarPath.StartsWith("http://"))
                                {
                                    avatar.ImageUrl = p.EnteredForRef.AvatarPath + "75";
                                }
                                else
                                {
                                    HRR.Web.Utils.ImageResize.ResizeImage(75, ResourceStrings.AvatarBasePath + p.EnteredForRef.AvatarPath, avatar);
                                    avatar.ResizeMode = Telerik.Web.UI.BinaryImageResizeMode.Fit;
                                }
                                break;
                            case 1:
                                commentType.Attributes.Add("class", "icon-heart");
                                if (p.EnteredForRef.AvatarPath.StartsWith("http://"))
                                {
                                    avatar.ImageUrl = p.EnteredForRef.AvatarPath + "75";
                                }
                                else
                                {
                                    HRR.Web.Utils.ImageResize.ResizeImage(75, ResourceStrings.AvatarBasePath + p.EnteredForRef.AvatarPath, avatar);
                                    avatar.ResizeMode = Telerik.Web.UI.BinaryImageResizeMode.Fit;
                                }
                                break;
                            case 2:
                                commentType.Attributes.Add("class", "icon-bullhorn");
                                avatar.ImageUrl = "http://www.gravatar.com/avatar/b7003aefd647fdc995550ff477d05d08?d=identicon&s=75";
                                break;
                            case 3:
                                commentType.Attributes.Add("class", "icon-pencil");
                                if (p.EnteredForRef.AvatarPath.StartsWith("http://"))
                                {
                                    avatar.ImageUrl = p.EnteredForRef.AvatarPath + "75";
                                }
                                else
                                {
                                    HRR.Web.Utils.ImageResize.ResizeImage(75, ResourceStrings.AvatarBasePath + p.EnteredForRef.AvatarPath, avatar);
                                    avatar.ResizeMode = Telerik.Web.UI.BinaryImageResizeMode.Fit;
                                }
                                break;
                        }

                        switch (p.SecurityType)
                        {
                            case 1:
                                visibleBy.Text = "all active members of the selected team";
                                break;
                            case 2:
                                visibleBy.Text = "";
                                var tm = new TeamMemberServices().GetByTeamID(p.TeamID);
                                foreach (var m in tm)
                                {
                                    if (m.IsManager && m.IsActive)
                                    {
                                        visibleBy.Text += m.PersonRef.Name + ", ";
                                    }
                                }
                                visibleBy.Text += " and me.";
                                break;
                            case 3:
                                visibleBy.Text = "only me";
                                break;
                            case 4:
                                visibleBy.Text = "everyone";
                                break;
                        }

                        if (p.Likes.Count() > 0)
                        {
                            likes.Visible = true;
                            likes.InnerText = p.Likes.Count().ToString();
                            if (new CommentLikeServices().GetByCommentIDPersonID(p.ID, SecurityContextManager.Current.CurrentUser.ID) != null)
                            {
                                likebtn.Enabled = false;
                            }
                        }
                        else
                        {
                            likes.Visible = false;
                        }
                        if (p.IsAnonymous && p.EnteredBy != SecurityContextManager.Current.CurrentUser.ID)
                        {
                            enteredby.Text = "<i>Anonymous</i>";
                        }
                        else
                        {
                            enteredby.NavigateUrl = "/People/" + p.EnteredByRef.Email;
                            enteredby.Text = "<i>" + p.EnteredByRef.Name + "</i>";
                        }

                        if (p.CommentType == 2)
                        {
                            enteredfor.NavigateUrl = "#";
                            enteredfor.Text = "<i>Everyone</i>";
                        }
                        else
                        {
                            enteredfor.NavigateUrl = "/People/" + p.EnteredForRef.Email;
                            enteredfor.Text = "<i>" + p.EnteredForRef.Name + "</i>";
                        }

                        if (p.CommentType == -1)
                        {
                            if (((Person)SecurityContextManager.Current.CurrentUser).RoleID == (int)SecurityRole.ADMIN)
                            {
                                lbl.Text = p.Message;
                            }
                            else
                            {
                                if (SecurityContextManager.Current.CurrentUser.ID == p.EnteredFor || SecurityContextManager.Current.CurrentUser.ID == p.EnteredBy)
                                {
                                    lbl.Text = p.Message;
                                }
                                else
                                {
                                    if (((Person)SecurityContextManager.Current.CurrentUser).RoleID < (int)SecurityRole.MANAGER)
                                    {
                                        ((HtmlGenericControl)e.Item.FindControl("divRow")).Visible = false;
                                        lbl.Text = "<i><b>Contstructive Comment Made</b></i>";
                                    }
                                    else
                                    {
                                        var member = new TeamMemberServices().GetByPersonIDTeamID(p.EnteredFor, p.TeamID);

                                        if (member != null && 
                                            (((Person)SecurityContextManager.Current.CurrentUser).ID == member.PersonID && member.IsManager) || 
                                            ((Person)SecurityContextManager.Current.CurrentUser).ID == p.EnteredByRef.ManagerID)
                                        {
                                            lbl.Text = p.Message;
                                        }
                                        else
                                        {
                                            ((HtmlGenericControl)e.Item.FindControl("divRow")).Visible = false;
                                            lbl.Text = "<i><b>Contstructive Comment Made</b></i>";
                                        }
                                    }
                                }
                            }
                            //((HtmlGenericControl)e.Item.FindControl("lblEnteredBy")).Visible = true;
                        }
                        else
                            lbl.Text = p.Message;

                        if (p.Communication.Count() > 0)
                        {
                            responsecount.InnerText = p.Communication.Count().ToString();
                            responsecount.Visible = true;
                            foreach (var response in p.Communication.OrderByDescending(a => a.DateCreated))
                            {
                                var eb = new PersonServices().GetByID(response.EnteredBy);
                                responseph.InnerHtml += "<li class='";
                                if (p.EnteredFor != response.EnteredBy)
                                    responseph.InnerHtml += "by-user'><a href='#' title=''>";
                                else
                                    responseph.InnerHtml += "by-me'><a href='#' title=''>";
                                responseph.InnerHtml += "<img src='";
                                if (eb.AvatarPath.StartsWith("http://"))
                                {
                                    responseph.InnerHtml += eb.AvatarPath + "37";
                                }
                                else
                                {
                                    responseph.InnerHtml += ResourceStrings.AvatarBasePath + eb.AvatarPath;
                                }
                                responseph.InnerHtml += "'  height='37' width='37' alt=''></a>";
                                responseph.InnerHtml += "<div class='area'><span class='arrow'></span><div class='info-row'><span class='pull-left'><strong>";
                                responseph.InnerHtml += eb.FirstName;
                                responseph.InnerHtml += "</strong> says: </span><span class='pull-right'>";
                                responseph.InnerHtml += response.DateCreated.ToString();
                                responseph.InnerHtml += "</span></div><p>";
                                responseph.InnerHtml += response.Message;
                                responseph.InnerHtml += "</p></div></li>";
                            }
                        }
                        else
                        { 
                            responsecount.Visible = false;
                        }
                    }
                }
                else
                {
                    switch (p.CommentType)
                    {
                        case -1:
                            commentType.Attributes.Add("class", "icon-comment");
                            if (p.EnteredForRef.AvatarPath.StartsWith("http://"))
                            {
                                avatar.ImageUrl = p.EnteredForRef.AvatarPath + "75";
                            }
                            else 
                            {
                                HRR.Web.Utils.ImageResize.ResizeImage(75, ResourceStrings.AvatarBasePath + p.EnteredForRef.AvatarPath, avatar);
                                avatar.ResizeMode = Telerik.Web.UI.BinaryImageResizeMode.Fit;
                            }
                            break;
                        case 1:
                            commentType.Attributes.Add("class", "icon-heart");
                            if (p.EnteredForRef.AvatarPath.StartsWith("http://"))
                            {
                                avatar.ImageUrl = p.EnteredForRef.AvatarPath + "75";
                            }
                            else 
                            {
                                HRR.Web.Utils.ImageResize.ResizeImage(75, ResourceStrings.AvatarBasePath + p.EnteredForRef.AvatarPath, avatar);
                                avatar.ResizeMode = Telerik.Web.UI.BinaryImageResizeMode.Fit;
                            }
                            break;
                        case 2:
                            commentType.Attributes.Add("class", "icon-bullhorn");
                            avatar.ImageUrl = "http://www.gravatar.com/avatar/b7003aefd647fdc995550ff477d05d08?d=identicon&s=75";
                            break;
                        case 3:
                            commentType.Attributes.Add("class", "icon-pencil");
                            if (p.EnteredForRef.AvatarPath.StartsWith("http://"))
                            {
                                avatar.ImageUrl = p.EnteredForRef.AvatarPath + "75";
                            }
                            else 
                            {
                                HRR.Web.Utils.ImageResize.ResizeImage(75, ResourceStrings.AvatarBasePath + p.EnteredForRef.AvatarPath, avatar);
                                avatar.ResizeMode = Telerik.Web.UI.BinaryImageResizeMode.Fit;
                            }
                            break;
                    }

                    switch (p.SecurityType)
                    {
                        case 1:
                            visibleBy.Text = "all active members of the selected team";
                            break;
                        case 2:
                            visibleBy.Text = "";
                            var tm = new TeamMemberServices().GetByTeamID(p.TeamID);
                            foreach (var m in tm)
                            {
                                if (m.IsManager && m.IsActive)
                                {
                                    visibleBy.Text += m.PersonRef.Name + ", ";
                                }
                            }
                            visibleBy.Text += " and me.";
                            break;
                        case 3:
                            visibleBy.Text = "only me";
                            break;
                        case 4:
                            visibleBy.Text = "everyone";
                            break;
                    }

                    if (p.Likes.Count() > 0)
                    {
                        likes.Visible = true;
                        likes.InnerText = p.Likes.Count().ToString();
                        if (new CommentLikeServices().GetByCommentIDPersonID(p.ID, SecurityContextManager.Current.CurrentUser.ID) != null)
                        {
                            likebtn.Enabled = false;
                        }
                    }
                    else
                    {
                        likes.Visible = false;
                    }
                    if (p.IsAnonymous && p.EnteredBy != SecurityContextManager.Current.CurrentUser.ID)
                    {
                        enteredby.Text = "<i>Anonymous</i>";
                    }
                    else
                    {
                        enteredby.NavigateUrl = "/People/" + p.EnteredByRef.Email;
                        enteredby.Text = "<i>" + p.EnteredByRef.Name + "</i>";
                    }

                    if (p.CommentType == 2)
                    {
                        enteredfor.NavigateUrl = "#";
                        enteredfor.Text = "<i>Everyone</i>";
                    }
                    else
                    {
                        enteredfor.NavigateUrl = "/People/" + p.EnteredForRef.Email;
                        enteredfor.Text = "<i>" + p.EnteredForRef.Name + "</i>";
                    }

                    if (p.CommentType == -1)
                    {
                        if (((Person)SecurityContextManager.Current.CurrentUser).RoleID == (int)SecurityRole.ADMIN)
                        {
                            lbl.Text = p.Message;
                        }
                        else
                        {
                            if (SecurityContextManager.Current.CurrentUser.ID == p.EnteredFor || SecurityContextManager.Current.CurrentUser.ID == p.EnteredBy)
                            {
                                lbl.Text = p.Message;
                            }
                            else
                            {
                                if (((Person)SecurityContextManager.Current.CurrentUser).RoleID < (int)SecurityRole.MANAGER)
                                {
                                    ((HtmlGenericControl)e.Item.FindControl("divRow")).Visible = false;
                                    lbl.Text = "<i><b>Contstructive Comment Made</b></i>";
                                }
                                else
                                {
                                    var member = new TeamMemberServices().GetByPersonIDTeamID(p.EnteredFor, p.TeamID);

                                    if (member != null && (((Person)SecurityContextManager.Current.CurrentUser).ID == member.PersonID && member.IsManager) || ((Person)SecurityContextManager.Current.CurrentUser).ID == p.EnteredByRef.ManagerID)
                                    {
                                        lbl.Text = p.Message;
                                    }
                                    else
                                    {
                                        ((HtmlGenericControl)e.Item.FindControl("divRow")).Visible = false;
                                        lbl.Text = "<i><b>Contstructive Comment Made</b></i>";
                                    }
                                }
                            }
                        }
                        //((HtmlGenericControl)e.Item.FindControl("lblEnteredBy")).Visible = true;
                    }
                    else
                        lbl.Text = p.Message;
                    if (p.Communication.Count() > 0)
                    {
                        responsecount.InnerText = p.Communication.Count().ToString();
                        responsecount.Visible = true;
                        foreach (var response in p.Communication.OrderByDescending(a => a.DateCreated))
                        {
                            var eb = new PersonServices().GetByID(response.EnteredBy);
                            responseph.InnerHtml += "<li class='";
                            if (p.EnteredFor != response.EnteredBy)
                                responseph.InnerHtml += "by-user'><a href='#' title=''>";
                            else
                                responseph.InnerHtml += "by-me'><a href='#' title=''>";
                            responseph.InnerHtml += "<img src='";
                            if (eb.AvatarPath.StartsWith("http://"))
                            {
                                responseph.InnerHtml += eb.AvatarPath + "37";
                            }
                            else
                            {
                                responseph.InnerHtml += ResourceStrings.AvatarBasePath + eb.AvatarPath;
                            }
                            responseph.InnerHtml += "'  height='37' width='37' alt=''></a>";
                            responseph.InnerHtml += "<div class='area'><span class='arrow'></span><div class='info-row'><span class='pull-left'><strong>";
                            responseph.InnerHtml += eb.FirstName;
                            responseph.InnerHtml += "</strong> says: </span><span class='pull-right'>";
                            responseph.InnerHtml += response.DateCreated.ToString();
                            responseph.InnerHtml += "</span></div><p>";
                            responseph.InnerHtml += response.Message;
                            responseph.InnerHtml += "</p></div></li>";
                        }
                    }
                    else
                    {
                        responsecount.Visible = false;
                    }
                }
            }
        }

        protected void CommentsItemCommand(object o, DataListCommandEventArgs e)
        {
            if (e.CommandName == "commentresponse")
            {
                var lb = e.Item.FindControl("lbPostReponse") as LinkButton;
                var cr = new CommentResponse();
                cr.CommentID = Convert.ToInt32(lb.Attributes["postid"]);
                cr.DateCreated = DateTime.Now;
                cr.EnteredBy = SecurityContextManager.Current.CurrentUser.ID;
                cr.Message = ((System.Web.UI.WebControls.TextBox)e.Item.FindControl("tbEnterResponse")).Text;
                new CommentResponseServices().Save(cr);
                _cache.Remove(SecurityContextManager.Current.CurrentUser.ID.ToString() + "_CommentsFeed");
                LoadComments();
            }
        }

        public void LoadComments()
        {
            PagedDataSource pd = new PagedDataSource();

            if (SecurityContextManager.Current.CurrentTeamID != null)
            {
                // _cache.Remove(SecurityContextManager.Current.CurrentAccount.ID.ToString() + "_CommentsFeed");
                var list = new List<Comment>();
                if (_cache.Retrieve<List<Comment>>(SecurityContextManager.Current.CurrentUser.ID.ToString() + "_CommentsFeed") == null)
                {
                    list = new CommentServices().GetByTeamID((int)SecurityContextManager.Current.CurrentTeamID).ToList<Comment>();
                    _cache.Store(SecurityContextManager
                    .Current
                    .CurrentUser.ID.ToString() + "_CommentsFeed", list);
                }
                else
                {
                    list = _cache.Retrieve<List<Comment>>(SecurityContextManager
                        .Current
                        .CurrentUser.ID.ToString() + "_CommentsFeed");
                }
                var team = new TeamServices().GetByID((int)SecurityContextManager.Current.CurrentTeamID);

                //var page = (HRRV2.Website.Comments)this.Parent.Page;
                switch (ddlSort.SelectedValue)
                {
                    case "0":
                        list = list.OrderByDescending(o => o.DateCreated).ToList<Comment>();
                        break;
                    case "1":
                        list = list.OrderBy(o => o.EnteredByRef.LastName).ToList<Comment>();
                        break;
                    case "2":
                        list = list.OrderBy(o => o.EnteredForRef.LastName).ToList<Comment>();
                        break;
                    case "3":
                        list = list.OrderBy(o => o.Category.Name).ToList<Comment>();
                        break;
                    case "4":
                        list = list.OrderBy(o => o.CommentType).ToList<Comment>();
                        break;
                    default:
                        list = list.OrderByDescending(o => o.DateCreated).ToList<Comment>();
                        break;
                }
                bool ismanager = false;

                if (SecurityContextManager.Current.CurrentURL.Contains("All"))
                {
                    foreach (var m in team.Members)
                    {
                        if (m.PersonID == SecurityContextManager.Current.CurrentUser.ID)
                        {
                            if (m.IsManager)
                                ismanager = true;
                        }
                    }
                    var results = new List<Comment>();
                    var temp = new List<Comment>();
                    var temp2 = new List<Comment>();
                    if (!ismanager)
                    {

                        temp = list;
                        temp.RemoveAll(o => (o.CommentType == -1 &&
                            o.EnteredBy != SecurityContextManager.Current.CurrentUser.ID) && (o.CommentType == -1 &&
                            o.EnteredFor != SecurityContextManager.Current.CurrentUser.ID));
                        results.AddRange(temp);

                        temp2 = list;
                        temp2.RemoveAll(o => (o.CommentType == -1 &&
                            o.EnteredFor != SecurityContextManager.Current.CurrentUser.ID));
                        results.AddRange(temp2);
                    }
                    else
                    {
                        results = list;
                    }


                    pd.DataSource = results.Distinct();
                    pd.AllowPaging = true;
                    pd.PageSize = 20;
                    pd.CurrentPageIndex = CurrentPage;
                    lblCurrentPage.Text = "Page: "
                        + (CurrentPage + 1).ToString()
                        + " of "
                        + pd.PageCount.ToString();
                    cmdPrev.Enabled = !pd.IsFirstPage;
                    cmdNext.Enabled = !pd.IsLastPage;

                    dlComments.DataSource = pd;
                    dlComments.DataBind();

                    #region Oldstuff
                    //var team = new List<TeamMember>();
                    //foreach (var t in ((Person)SecurityContextManager.Current.CurrentUser).Memberships)
                    //{
                    //    foreach (var m in t.TeamRef.Members)
                    //    {
                    //        if (SecurityContextManager.Current.CurrentUser.ID == m.PersonID)
                    //        {
                    //            if (m.IsManager)
                    //                ismanager = true;
                    //        }

                    //        team.Add(m);
                    //    }
                    //}
                    //((Person)SecurityContextManager.Current.CurrentUser).DepartmentRef.People;
                    //var comments = new List<Comment>();
                    //foreach (var member in team.Distinct())
                    //{
                    //if (member.PersonID == SecurityContextManager.Current.CurrentUser.ID && member.IsManager)
                    //{
                    //    var mine = from l in list
                    //               where l.EnteredBy == member.PersonRef.ID ||
                    //               l.EnteredFor == member.PersonRef.ID 
                    //               orderby l.DateCreated descending
                    //               select l;
                    //    comments.AddRange(mine);
                    //}
                    //else
                    //{
                    //    var mine = from l in list
                    //               where 
                    //               (l.CommentType == -1 && (l.EnteredBy == SecurityContextManager.Current.CurrentUser.ID || l.EnteredFor == SecurityContextManager.Current.CurrentUser.ID))
                    //               orderby l.DateCreated descending
                    //               select l;
                    //    comments.AddRange(mine);

                    //    mine = from i in list
                    //           where
                    //           (i.EnteredBy == member.PersonRef.ID ||
                    //               i.EnteredFor == member.PersonRef.ID) &&
                    //               i.CommentType != -1
                    //           orderby i.DateCreated descending
                    //           select i;
                    //    comments.AddRange(mine);
                    //}
                    //    var mine = from l in list
                    //               where l.EnteredBy == member.PersonRef.ID ||
                    //               l.EnteredFor == member.PersonRef.ID
                    //               orderby l.DateCreated descending
                    //               select l;
                    //    comments.AddRange(mine);
                    //}
                    //var results = new List<Comment>();
                    //var temp = new List<Comment>();
                    //var temp2 = new List<Comment>();
                    //if (!ismanager)
                    //{

                    //    temp = comments;
                    //    temp.RemoveAll(o => (o.CommentType == -1 &&
                    //        o.EnteredBy != SecurityContextManager.Current.CurrentUser.ID));
                    //    temp2 = comments;
                    //    temp2.RemoveAll(o => (o.CommentType == -1 &&
                    //        o.EnteredFor != SecurityContextManager.Current.CurrentUser.ID));
                    //}
                    //results.AddRange(temp);
                    //results.AddRange(temp2);
                    //dlComments.DataSource = results.Distinct().OrderByDescending(o => o.DateCreated);
                    //dlComments.DataBind();
                    #endregion
                }
                else if (SecurityContextManager.Current.CurrentURL.Contains("Flagged"))
                {
                    if (((Person)SecurityContextManager.Current.CurrentUser).RoleID < (int)SecurityRole.ADMIN)
                    {
                        Response.Redirect("/Comments/Mine");
                    }
                    dlComments.DataSource = new CommentServices().GetFlaggedByTeamID((int)SecurityContextManager.Current.CurrentTeamID);
                    dlComments.DataBind();
                }
                else if (SecurityContextManager.Current.CurrentURL.Contains("Mine"))
                {
                    var mine = from l in list
                               where l.EnteredBy == SecurityContextManager.Current.CurrentUser.ID ||
                               l.EnteredFor == SecurityContextManager.Current.CurrentUser.ID
                               select l;

                    pd.DataSource = mine;
                    pd.AllowPaging = true;
                    pd.PageSize = 20;
                    pd.CurrentPageIndex = CurrentPage;
                    lblCurrentPage.Text = "Page: "
                        + (CurrentPage + 1).ToString()
                        + " of "
                        + pd.PageCount.ToString();
                    cmdPrev.Enabled = !pd.IsFirstPage;
                    cmdNext.Enabled = !pd.IsLastPage;

                    dlComments.DataSource = pd;
                    dlComments.DataBind();

                }
                else if (SecurityContextManager.Current.CurrentURL.Contains("Profile"))
                {
                    switch (((Person)SecurityContextManager.Current.CurrentUser).RoleID)
                    {
                        case (int)SecurityRole.ADMIN:
                        case (int)SecurityRole.EXECUTIVE_MANAGEMENT:
                            var mine = from l in list
                                       where l.EnteredBy == SecurityContextManager.Current.CurrentProfile.ID ||
                                       l.EnteredFor == SecurityContextManager.Current.CurrentProfile.ID
                                       select l;
                            pd.DataSource = mine;
                            pd.AllowPaging = true;
                            pd.PageSize = 20;
                            pd.CurrentPageIndex = CurrentPage;
                            lblCurrentPage.Text = "Page: "
                                + (CurrentPage + 1).ToString()
                                + " of "
                                + pd.PageCount.ToString();
                            cmdPrev.Enabled = !pd.IsFirstPage;
                            cmdNext.Enabled = !pd.IsLastPage;

                            dlComments.DataSource = pd;
                            dlComments.DataBind();
                            break;
                        case (int)SecurityRole.MANAGER:
                            var t = ((Person)SecurityContextManager.Current.CurrentUser).DepartmentRef.People;
                            var comments = new List<Comment>();
                            foreach (var member in t)
                            {
                                mine = from l in list
                                       where l.EnteredBy == member.ID ||
                                       l.EnteredFor == member.ID
                                       select l;
                                comments.AddRange(mine);
                            }
                            pd.DataSource = comments.Distinct();
                            pd.AllowPaging = true;
                            pd.PageSize = 20;
                            pd.CurrentPageIndex = CurrentPage;
                            lblCurrentPage.Text = "Page: "
                                + (CurrentPage + 1).ToString()
                                + " of "
                                + pd.PageCount.ToString();
                            cmdPrev.Enabled = !pd.IsFirstPage;
                            cmdNext.Enabled = !pd.IsLastPage;

                            dlComments.DataSource = pd;
                            dlComments.DataBind();
                            break;
                        default:
                            mine = from l in list
                                   where l.EnteredBy == SecurityContextManager.Current.CurrentUser.ID ||
                                   l.EnteredFor == SecurityContextManager.Current.CurrentUser.ID
                                   select l;
                            pd.DataSource = mine;
                            pd.AllowPaging = true;
                            pd.PageSize = 20;
                            pd.CurrentPageIndex = CurrentPage;
                            lblCurrentPage.Text = "Page: "
                                + (CurrentPage + 1).ToString()
                                + " of "
                                + pd.PageCount.ToString();
                            cmdPrev.Enabled = !pd.IsFirstPage;
                            cmdNext.Enabled = !pd.IsLastPage;

                            dlComments.DataSource = pd;
                            dlComments.DataBind();
                            break;
                    }

                }
                else
                {

                    //foreach (var m in team.Members)
                    //{
                    //    if (m.PersonID == SecurityContextManager.Current.CurrentUser.ID)
                    //    {
                    //        if (m.IsManager)
                    //            ismanager = true;
                    //    }
                    //}
                    //var results = new List<Comment>();
                    //var temp = new List<Comment>();
                    //var temp2 = new List<Comment>();
                    //if (!ismanager)
                    //{

                    //    temp = list;
                    //    temp.RemoveAll(o => (o.CommentType == -1 &&
                    //        o.EnteredBy != SecurityContextManager.Current.CurrentUser.ID) && (o.CommentType == -1 && o.EnteredFor != SecurityContextManager.Current.CurrentUser.ID));//
                    //    results.AddRange(temp);

                    //    temp2 = list;
                    //    temp2.RemoveAll(o => (o.CommentType == -1 &&
                    //        o.EnteredFor != SecurityContextManager.Current.CurrentUser.ID));
                    //    results.AddRange(temp2);
                    //}
                    //else
                    //{
                    //    results = list;
                    //}
                    pd.DataSource = list;
                    pd.AllowPaging = true;
                    pd.PageSize = 20;
                    pd.CurrentPageIndex = CurrentPage;
                    lblCurrentPage.Text = "Page: "
                        + (CurrentPage + 1).ToString()
                        + " of "
                        + pd.PageCount.ToString();
                    cmdPrev.Enabled = !pd.IsFirstPage;
                    cmdNext.Enabled = !pd.IsLastPage;

                    dlComments.DataSource = pd;
                    dlComments.DataBind();
                }
            }
            else
            {
                dlComments.DataSource = null;
                dlComments.DataBind();
            }
        }

        protected void PrevClicked(object sender, System.EventArgs e)
        {
            // Set viewstate variable to the previous page
            CurrentPage -= 1;

            // Reload control
            LoadComments();
        }

        protected void NextClicked(object sender, System.EventArgs e)
        {
            // Set viewstate variable to the next page
            CurrentPage += 1;

            // Reload control
            LoadComments();
        }

        private void LoadAutoSuggest()
        {
            List<HRR.Core.Domain.Interfaces.IAutoSuggestRecipient> list = new TeamMemberServices().GetAutoSuggestRecipientsByTeam();
            praise_name.DataSource = list;
            praise_name.DataTextField = "Name";
            praise_name.DataValueField = "ID";

            feedback_name.DataSource = list;
            feedback_name.DataTextField = "Name";
            feedback_name.DataValueField = "ID";

            note_name.DataSource = list;
            note_name.DataTextField = "Name";
            note_name.DataValueField = "ID";
        }

    }
}