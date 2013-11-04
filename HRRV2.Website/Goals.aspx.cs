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
    public partial class Goals : HRRBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGoals();
            }
        }

        protected void ItemDataBound(object o, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var p = ((HRR.Core.Domain.Person)e.Item.DataItem);
                //var lbl = (IdeaSeed.Web.UI.Label)e.Item.FindControl("lblMessage");
                //var visibleBy = (IdeaSeed.Web.UI.Label)e.Item.FindControl("lblVisibleBy");
                //var delete = (IdeaSeed.Web.UI.LinkButton)e.Item.FindControl("lbDeleteComment");
                //var enteredby = (HyperLink)e.Item.FindControl("lbEnteredBy");
                //var enteredfor = (HyperLink)e.Item.FindControl("lbEnteredFor");
                //var responses = (IdeaSeed.Web.UI.LinkButton)e.Item.FindControl("lbResponseCount");
                //var likebtn = (IdeaSeed.Web.UI.LinkButton)e.Item.FindControl("lbLike");
                var avatar = (Telerik.Web.UI.RadBinaryImage)e.Item.FindControl("rbiProfile");
                //var likes = (HtmlGenericControl)e.Item.FindControl("span_likes");
                //var responsecount = (HtmlGenericControl)e.Item.FindControl("span_responses");
                //var commentRow = (HtmlGenericControl)e.Item.FindControl("divRow");
                //var commentType = (HtmlGenericControl)e.Item.FindControl("comment_type");
                //var responseph = (HtmlGenericControl)e.Item.FindControl("phResponses");
                var content = (HtmlGenericControl)e.Item.FindControl("divcontent");
                var table = (Repeater)e.Item.FindControl("nestedGoalsDataList");

                if (p.AvatarPath.StartsWith("http://"))
                {
                    avatar.ImageUrl = p.AvatarPath + "75";
                }
                else
                {
                    HRR.Web.Utils.ImageResize.ResizeImage(75, ResourceStrings.AvatarBasePath + p.AvatarPath, avatar);
                    avatar.ResizeMode = Telerik.Web.UI.BinaryImageResizeMode.Fit;
                }

                if (p.Goals.Count > 0)
                {
                    table.DataSource = p.Goals;
                    table.DataBind();
                    //foreach (var goal in p.Goals)
                    //{
                    //    content.InnerHtml += goal.Title + "<br />";
                    //}
                }

            }


            //    if (p.EnteredBy != SecurityContextManager.Current.CurrentUser.ID)
            //    {
            //        if (p.IsPrivate)
            //        {
            //            commentRow.Visible = false;
            //        }
            //        else
            //        {
            //            switch (p.CommentType)
            //            {
            //                case -1:
            //                    commentType.Attributes.Add("class", "icon-comment");
            //                    if (p.EnteredForRef.AvatarPath.StartsWith("http://"))
            //                    {
            //                        avatar.ImageUrl = p.EnteredForRef.AvatarPath + "75";
            //                    }
            //                    else
            //                    {
            //                        HRR.Web.Utils.ImageResize.ResizeImage(75, ResourceStrings.AvatarBasePath + p.EnteredForRef.AvatarPath, avatar);
            //                        avatar.ResizeMode = Telerik.Web.UI.BinaryImageResizeMode.Fit;
            //                    }
            //                    break;
            //                case 1:
            //                    commentType.Attributes.Add("class", "icon-heart");
            //                    if (p.EnteredForRef.AvatarPath.StartsWith("http://"))
            //                    {
            //                        avatar.ImageUrl = p.EnteredForRef.AvatarPath + "75";
            //                    }
            //                    else
            //                    {
            //                        HRR.Web.Utils.ImageResize.ResizeImage(75, ResourceStrings.AvatarBasePath + p.EnteredForRef.AvatarPath, avatar);
            //                        avatar.ResizeMode = Telerik.Web.UI.BinaryImageResizeMode.Fit;
            //                    }
            //                    break;
            //                case 2:
            //                    commentType.Attributes.Add("class", "icon-bullhorn");
            //                    avatar.ImageUrl = "http://www.gravatar.com/avatar/b7003aefd647fdc995550ff477d05d08?d=identicon&s=75";
            //                    break;
            //                case 3:
            //                    commentType.Attributes.Add("class", "icon-pencil");
            //                    if (p.EnteredForRef.AvatarPath.StartsWith("http://"))
            //                    {
            //                        avatar.ImageUrl = p.EnteredForRef.AvatarPath + "75";
            //                    }
            //                    else
            //                    {
            //                        HRR.Web.Utils.ImageResize.ResizeImage(75, ResourceStrings.AvatarBasePath + p.EnteredForRef.AvatarPath, avatar);
            //                        avatar.ResizeMode = Telerik.Web.UI.BinaryImageResizeMode.Fit;
            //                    }
            //                    break;
            //            }

            //            switch (p.SecurityType)
            //            {
            //                case 1:
            //                    visibleBy.Text = "all active members of the selected team";
            //                    break;
            //                case 2:
            //                    visibleBy.Text = "";
            //                    var tm = new TeamMemberServices().GetByTeamID(p.TeamID);
            //                    foreach (var m in tm)
            //                    {
            //                        if (m.IsManager && m.IsActive)
            //                        {
            //                            visibleBy.Text += m.PersonRef.Name + ", ";
            //                        }
            //                    }
            //                    visibleBy.Text += " and me.";
            //                    break;
            //                case 3:
            //                    visibleBy.Text = "only me";
            //                    break;
            //                case 4:
            //                    visibleBy.Text = "everyone";
            //                    break;
            //            }

            //            if (p.Likes.Count() > 0)
            //            {
            //                likes.Visible = true;
            //                likes.InnerText = p.Likes.Count().ToString();
            //                if (new CommentLikeServices().GetByCommentIDPersonID(p.ID, SecurityContextManager.Current.CurrentUser.ID) != null)
            //                {
            //                    likebtn.Enabled = false;
            //                }
            //            }
            //            else
            //            {
            //                likes.Visible = false;
            //            }
            //            if (p.IsAnonymous && p.EnteredBy != SecurityContextManager.Current.CurrentUser.ID)
            //            {
            //                enteredby.Text = "<i>Anonymous</i>";
            //            }
            //            else
            //            {
            //                enteredby.NavigateUrl = "/People/" + p.EnteredByRef.Email;
            //                enteredby.Text = "<i>" + p.EnteredByRef.Name + "</i>";
            //            }

            //            if (p.CommentType == 2)
            //            {
            //                enteredfor.NavigateUrl = "#";
            //                enteredfor.Text = "<i>Everyone</i>";
            //            }
            //            else
            //            {
            //                enteredfor.NavigateUrl = "/People/" + p.EnteredForRef.Email;
            //                enteredfor.Text = "<i>" + p.EnteredForRef.Name + "</i>";
            //            }

            //            if (p.CommentType == -1)
            //            {
            //                if (((Person)SecurityContextManager.Current.CurrentUser).RoleID == (int)SecurityRole.ADMIN)
            //                {
            //                    lbl.Text = p.Message;
            //                }
            //                else
            //                {
            //                    if (SecurityContextManager.Current.CurrentUser.ID == p.EnteredFor || SecurityContextManager.Current.CurrentUser.ID == p.EnteredBy)
            //                    {
            //                        lbl.Text = p.Message;
            //                    }
            //                    else
            //                    {
            //                        if (((Person)SecurityContextManager.Current.CurrentUser).RoleID < (int)SecurityRole.MANAGER)
            //                        {
            //                            ((HtmlGenericControl)e.Item.FindControl("divRow")).Visible = false;
            //                            lbl.Text = "<i><b>Contstructive Comment Made</b></i>";
            //                        }
            //                        else
            //                        {
            //                            var member = new TeamMemberServices().GetByPersonIDTeamID(p.EnteredFor, p.TeamID);

            //                            if (member != null &&
            //                                (((Person)SecurityContextManager.Current.CurrentUser).ID == member.PersonID && member.IsManager) ||
            //                                ((Person)SecurityContextManager.Current.CurrentUser).ID == p.EnteredByRef.ManagerID)
            //                            {
            //                                lbl.Text = p.Message;
            //                            }
            //                            else
            //                            {
            //                                ((HtmlGenericControl)e.Item.FindControl("divRow")).Visible = false;
            //                                lbl.Text = "<i><b>Contstructive Comment Made</b></i>";
            //                            }
            //                        }
            //                    }
            //                }
            //                //((HtmlGenericControl)e.Item.FindControl("lblEnteredBy")).Visible = true;
            //            }
            //            else
            //                lbl.Text = p.Message;

            //            if (p.Communication.Count() > 0)
            //            {
            //                responsecount.InnerText = p.Communication.Count().ToString();
            //                responsecount.Visible = true;
            //                foreach (var response in p.Communication.OrderByDescending(a => a.DateCreated))
            //                {
            //                    var eb = new PersonServices().GetByID(response.EnteredBy);
            //                    responseph.InnerHtml += "<li class='";
            //                    if (p.EnteredFor != response.EnteredBy)
            //                        responseph.InnerHtml += "by-user'><a href='#' title=''>";
            //                    else
            //                        responseph.InnerHtml += "by-me'><a href='#' title=''>";
            //                    responseph.InnerHtml += "<img src='";
            //                    if (eb.AvatarPath.StartsWith("http://"))
            //                    {
            //                        responseph.InnerHtml += eb.AvatarPath + "37";
            //                    }
            //                    else
            //                    {
            //                        responseph.InnerHtml += ResourceStrings.AvatarBasePath + eb.AvatarPath;
            //                    }
            //                    responseph.InnerHtml += "'  height='37' width='37' alt=''></a>";
            //                    responseph.InnerHtml += "<div class='area'><span class='arrow'></span><div class='info-row'><span class='pull-left'><strong>";
            //                    responseph.InnerHtml += eb.FirstName;
            //                    responseph.InnerHtml += "</strong> says: </span><span class='pull-right'>";
            //                    responseph.InnerHtml += response.DateCreated.ToString();
            //                    responseph.InnerHtml += "</span></div><p>";
            //                    responseph.InnerHtml += response.Message;
            //                    responseph.InnerHtml += "</p></div></li>";
            //                }
            //            }
            //            else
            //            {
            //                responsecount.Visible = false;
            //            }
            //        }
            //    }
            //    else
            //    {
            //        switch (p.CommentType)
            //        {
            //            case -1:
            //                commentType.Attributes.Add("class", "icon-comment");
            //                if (p.EnteredForRef.AvatarPath.StartsWith("http://"))
            //                {
            //                    avatar.ImageUrl = p.EnteredForRef.AvatarPath + "75";
            //                }
            //                else
            //                {
            //                    HRR.Web.Utils.ImageResize.ResizeImage(75, ResourceStrings.AvatarBasePath + p.EnteredForRef.AvatarPath, avatar);
            //                    avatar.ResizeMode = Telerik.Web.UI.BinaryImageResizeMode.Fit;
            //                }
            //                break;
            //            case 1:
            //                commentType.Attributes.Add("class", "icon-heart");
            //                if (p.EnteredForRef.AvatarPath.StartsWith("http://"))
            //                {
            //                    avatar.ImageUrl = p.EnteredForRef.AvatarPath + "75";
            //                }
            //                else
            //                {
            //                    HRR.Web.Utils.ImageResize.ResizeImage(75, ResourceStrings.AvatarBasePath + p.EnteredForRef.AvatarPath, avatar);
            //                    avatar.ResizeMode = Telerik.Web.UI.BinaryImageResizeMode.Fit;
            //                }
            //                break;
            //            case 2:
            //                commentType.Attributes.Add("class", "icon-bullhorn");
            //                avatar.ImageUrl = "http://www.gravatar.com/avatar/b7003aefd647fdc995550ff477d05d08?d=identicon&s=75";
            //                break;
            //            case 3:
            //                commentType.Attributes.Add("class", "icon-pencil");
            //                if (p.EnteredForRef.AvatarPath.StartsWith("http://"))
            //                {
            //                    avatar.ImageUrl = p.EnteredForRef.AvatarPath + "75";
            //                }
            //                else
            //                {
            //                    HRR.Web.Utils.ImageResize.ResizeImage(75, ResourceStrings.AvatarBasePath + p.EnteredForRef.AvatarPath, avatar);
            //                    avatar.ResizeMode = Telerik.Web.UI.BinaryImageResizeMode.Fit;
            //                }
            //                break;
            //        }

            //        switch (p.SecurityType)
            //        {
            //            case 1:
            //                visibleBy.Text = "all active members of the selected team";
            //                break;
            //            case 2:
            //                visibleBy.Text = "";
            //                var tm = new TeamMemberServices().GetByTeamID(p.TeamID);
            //                foreach (var m in tm)
            //                {
            //                    if (m.IsManager && m.IsActive)
            //                    {
            //                        visibleBy.Text += m.PersonRef.Name + ", ";
            //                    }
            //                }
            //                visibleBy.Text += " and me.";
            //                break;
            //            case 3:
            //                visibleBy.Text = "only me";
            //                break;
            //            case 4:
            //                visibleBy.Text = "everyone";
            //                break;
            //        }

            //        if (p.Likes.Count() > 0)
            //        {
            //            likes.Visible = true;
            //            likes.InnerText = p.Likes.Count().ToString();
            //            if (new CommentLikeServices().GetByCommentIDPersonID(p.ID, SecurityContextManager.Current.CurrentUser.ID) != null)
            //            {
            //                likebtn.Enabled = false;
            //            }
            //        }
            //        else
            //        {
            //            likes.Visible = false;
            //        }
            //        if (p.IsAnonymous && p.EnteredBy != SecurityContextManager.Current.CurrentUser.ID)
            //        {
            //            enteredby.Text = "<i>Anonymous</i>";
            //        }
            //        else
            //        {
            //            enteredby.NavigateUrl = "/People/" + p.EnteredByRef.Email;
            //            enteredby.Text = "<i>" + p.EnteredByRef.Name + "</i>";
            //        }

            //        if (p.CommentType == 2)
            //        {
            //            enteredfor.NavigateUrl = "#";
            //            enteredfor.Text = "<i>Everyone</i>";
            //        }
            //        else
            //        {
            //            enteredfor.NavigateUrl = "/People/" + p.EnteredForRef.Email;
            //            enteredfor.Text = "<i>" + p.EnteredForRef.Name + "</i>";
            //        }

            //        if (p.CommentType == -1)
            //        {
            //            if (((Person)SecurityContextManager.Current.CurrentUser).RoleID == (int)SecurityRole.ADMIN)
            //            {
            //                lbl.Text = p.Message;
            //            }
            //            else
            //            {
            //                if (SecurityContextManager.Current.CurrentUser.ID == p.EnteredFor || SecurityContextManager.Current.CurrentUser.ID == p.EnteredBy)
            //                {
            //                    lbl.Text = p.Message;
            //                }
            //                else
            //                {
            //                    if (((Person)SecurityContextManager.Current.CurrentUser).RoleID < (int)SecurityRole.MANAGER)
            //                    {
            //                        ((HtmlGenericControl)e.Item.FindControl("divRow")).Visible = false;
            //                        lbl.Text = "<i><b>Contstructive Comment Made</b></i>";
            //                    }
            //                    else
            //                    {
            //                        var member = new TeamMemberServices().GetByPersonIDTeamID(p.EnteredFor, p.TeamID);

            //                        if (member != null && (((Person)SecurityContextManager.Current.CurrentUser).ID == member.PersonID && member.IsManager) || ((Person)SecurityContextManager.Current.CurrentUser).ID == p.EnteredByRef.ManagerID)
            //                        {
            //                            lbl.Text = p.Message;
            //                        }
            //                        else
            //                        {
            //                            ((HtmlGenericControl)e.Item.FindControl("divRow")).Visible = false;
            //                            lbl.Text = "<i><b>Contstructive Comment Made</b></i>";
            //                        }
            //                    }
            //                }
            //            }
            //            //((HtmlGenericControl)e.Item.FindControl("lblEnteredBy")).Visible = true;
            //        }
            //        else
            //            lbl.Text = p.Message;
            //        if (p.Communication.Count() > 0)
            //        {
            //            responsecount.InnerText = p.Communication.Count().ToString();
            //            responsecount.Visible = true;
            //            foreach (var response in p.Communication.OrderByDescending(a => a.DateCreated))
            //            {
            //                var eb = new PersonServices().GetByID(response.EnteredBy);
            //                responseph.InnerHtml += "<li class='";
            //                if (p.EnteredFor != response.EnteredBy)
            //                    responseph.InnerHtml += "by-user'><a href='#' title=''>";
            //                else
            //                    responseph.InnerHtml += "by-me'><a href='#' title=''>";
            //                responseph.InnerHtml += "<img src='";
            //                if (eb.AvatarPath.StartsWith("http://"))
            //                {
            //                    responseph.InnerHtml += eb.AvatarPath + "37";
            //                }
            //                else
            //                {
            //                    responseph.InnerHtml += ResourceStrings.AvatarBasePath + eb.AvatarPath;
            //                }
            //                responseph.InnerHtml += "'  height='37' width='37' alt=''></a>";
            //                responseph.InnerHtml += "<div class='area'><span class='arrow'></span><div class='info-row'><span class='pull-left'><strong>";
            //                responseph.InnerHtml += eb.FirstName;
            //                responseph.InnerHtml += "</strong> says: </span><span class='pull-right'>";
            //                responseph.InnerHtml += response.DateCreated.ToString();
            //                responseph.InnerHtml += "</span></div><p>";
            //                responseph.InnerHtml += response.Message;
            //                responseph.InnerHtml += "</p></div></li>";
            //            }
            //        }
            //        else
            //        {
            //            responsecount.Visible = false;
            //        }
            //    }
            //}
        }

        protected void CommentsItemCommand(object o, DataListCommandEventArgs e)
        {
            //if (e.CommandName == "commentresponse")
            //{
            //    var lb = e.Item.FindControl("lbPostReponse") as LinkButton;
            //    var cr = new CommentResponse();
            //    cr.CommentID = Convert.ToInt32(lb.Attributes["postid"]);
            //    cr.DateCreated = DateTime.Now;
            //    cr.EnteredBy = SecurityContextManager.Current.CurrentUser.ID;
            //    cr.Message = ((System.Web.UI.WebControls.TextBox)e.Item.FindControl("tbEnterResponse")).Text;
            //    new CommentResponseServices().Save(cr);
            //    _cache.Remove(SecurityContextManager.Current.CurrentUser.ID.ToString() + "_CommentsFeed");
            //    LoadGoals();
            //}
        }

        protected void DeleteGoalClicked(object o, EventArgs e)
        {
            var item = (IdeaSeed.Web.UI.LinkButton)o;
            var goal = new GoalServices().GetByID(Convert.ToInt32(item.Attributes["itemid"]));
            foreach (var ms in new GoalMilestoneServices().GetByGoalID(goal.ID))
            {
                new GoalMilestoneServices().Delete(ms);
            }

            foreach (var communication in new GoalCommunicationServices().GetByGoalID(goal.ID))
            {
                new GoalCommunicationServices().Delete(communication);
            }

            foreach (var manager in new GoalManagerServices().GetByGoalID(goal.ID))
            {
                new GoalManagerServices().Delete(manager);
            }
            new GoalServices().Delete(goal);
            LoadGoals();
        }

        protected void NestedGoalsItemDataBound(object o, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var delete = e.Item.FindControl("lbDelete") as LinkButton;
                if (((Person)SecurityContextManager.Current.CurrentUser).RoleID > (int)SecurityRole.EMPLOYEE)
                {
                    delete.Visible = true;
                }
                else
                {
                    delete.Visible = false;
                }
            }
        }

        private void LoadGoals()
        {
            IList<Person> people = new List<Person>();
            foreach (var t in SecurityContextManager.Current.CurrentUser.Memberships)
            {
                var members = new TeamMemberServices().GetByTeamID(t.TeamID);
                foreach (var tm in members)
                {
                    people.Add(tm.PersonRef);
                }
            }

            dlComments.DataSource = people.Distinct();
            dlComments.DataBind();
            //var goals = new PersonServices().GetAllActiveAutoSuggestRecipientsByAccount();
            
        }

        
    }
}