using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HRR.Core.Domain;
using HRR.Core.Security;
using HRR.Services;
using HRR.Web.Bases;
using IdeaSeed.Core;
using HRR.Core;
using Telerik.Charting;
using System.Data;
using Telerik.Web.UI;
using System.Drawing;

namespace HRR.Website
{
    public partial class Default : HRRBasePage
    {
        ICacheStorage _cache = new MemcacheCacheAdapter();

        private int PositiveCommentsTotal
        {
            get
            {
                if (ViewState["PositiveComments"] != null)
                    return (int)ViewState["PositiveComments"];
                else
                    return 0;
            }
            set
            {
                ViewState["PositiveComments"] = value;
            }
        }

        private int ConstructiveCommentsTotal
        {
            get
            {
                if (ViewState["ConstructiveComments"] != null)
                    return (int)ViewState["ConstructiveComments"];
                else
                    return 0;
            }
            set
            {
                ViewState["ConstructiveComments"] = value;
            }
        }

        public HRR.Core.Domain.Poll CurrentPoll
        {
            get
            {
                return SessionManager.Current["CurrentPoll"] as HRR.Core.Domain.Poll;
            }
            set
            {
                SessionManager.Current["CurrentPoll"] = value;
            }
        }

        private string _goalprogress = "";
        protected string GoalProgress
        {
            get
            {
                return _goalprogress;
            }
            set
            {
                _goalprogress = value;
            }
        }
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadActivity();
                LoadAlerts();
                LoadEvents();
                LoadBlogs();
                LoadCurrentPoll();
                LoadMyStats();
                LoadCommentCounts();
                UpdateGoalProgress();
            }
        }

        #region Activity Feed
        protected void ItemDataBound(object o, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var p = ((HRR.Core.Domain.Activity)e.Item.DataItem);
                var lbl = (IdeaSeed.Web.UI.Label)e.Item.FindControl("lblMessage");
                switch (p.ActivityType)
                {
                    case (int)ActivityType.COMMENT:
                        if (!string.IsNullOrEmpty(p.URL))
                        {
                            lbl.Text = "entered a <a href='" + p.URL + "'>comment</a> for " + p.PerformedForRef.Name + " at " + p.DateCreated.ToString();
                        }
                        else
                        {
                            lbl.Text = "entered a comment for " + p.PerformedForRef.Name + " at " + p.DateCreated.ToString();
                        }
                        break;
                    case (int)ActivityType.NEW_COMMENT_RESPONSE:
                        if (!string.IsNullOrEmpty(p.URL))
                        {
                            lbl.Text = "responded to a  <a href='" + p.URL + "'>comment</a> for " + p.PerformedForRef.Name + " at " + p.DateCreated.ToString();
                        }
                        else
                        {
                            lbl.Text = "responded to a comment for " + p.PerformedForRef.Name + " at " + p.DateCreated.ToString();
                        }
                        break;
                    case (int)ActivityType.GOAL_UPDATED:
                        if (!string.IsNullOrEmpty(p.URL))
                        {
                            lbl.Text = "updated a <a href='" + p.URL + "'>goal</a> for " + p.PerformedForRef.Name + " at " + p.DateCreated.ToString();
                        }
                        else
                        {
                            lbl.Text = "updated a goal for " + p.PerformedForRef.Name + " at " + p.DateCreated.ToString();
                        }
                        break;
                    case (int)ActivityType.MILESTONE_UPDATED:
                        if (!string.IsNullOrEmpty(p.URL))
                        {
                            lbl.Text = "updated a <a href='" + p.URL + "'>goal milestone</a> for " + p.PerformedForRef.Name + " at " + p.DateCreated.ToString();
                        }
                        else
                        {
                            lbl.Text = "updated a goal milestone for " + p.PerformedForRef.Name + " at " + p.DateCreated.ToString();
                        }
                        break;
                    case (int)ActivityType.NEW_GOAL:
                        if (!string.IsNullOrEmpty(p.URL))
                        {
                            lbl.Text = "entered a new <a href='" + p.URL + "'>goal</a> for " + p.PerformedForRef.Name + " at " + p.DateCreated.ToString();
                        }
                        else
                        {
                            lbl.Text = "entered a new goal for " + p.PerformedForRef.Name + " at " + p.DateCreated.ToString();
                        }
                        break;
                    case (int)ActivityType.NEW_GOAL_COMMENT:
                        if (!string.IsNullOrEmpty(p.URL))
                        {
                            lbl.Text = "entered a <a href='" + p.URL + "'>goal comment</a> for " + p.PerformedForRef.Name + " at " + p.DateCreated.ToString();
                        }
                        else
                        {
                            lbl.Text = "entered a goal comment for " + p.PerformedForRef.Name + " at " + p.DateCreated.ToString();
                        }
                        break;
                    case (int)ActivityType.NEW_MILESTONE:
                        if (!string.IsNullOrEmpty(p.URL))
                        {
                            lbl.Text = "entered a new <a href='" + p.URL + "'>goal milestone</a> for " + p.PerformedForRef.Name + " at " + p.DateCreated.ToString();
                        }
                        else
                        {
                            lbl.Text = "entered a goal milestone for " + p.PerformedForRef.Name + " at " + p.DateCreated.ToString();
                        }
                        break;
                    case (int)ActivityType.NEW_REVIEW:
                        if (!string.IsNullOrEmpty(p.URL))
                        {
                            lbl.Text = "entered a new <a href='" + p.URL + "'>review</a> for " + p.PerformedForRef.Name + " at " + p.DateCreated.ToString();
                        }
                        else
                        {
                            lbl.Text = "entered a new review for " + p.PerformedForRef.Name + " at " + p.DateCreated.ToString();
                        }
                        break;
                    case (int)ActivityType.REVIEW_UPDATED:
                        if (!string.IsNullOrEmpty(p.URL))
                        {
                            lbl.Text = "updated a <a href='" + p.URL + "'>review</a> for " + p.PerformedForRef.Name + " at " + p.DateCreated.ToString();
                        }
                        else
                        {
                            lbl.Text = "updated a review for " + p.PerformedForRef.Name + " at " + p.DateCreated.ToString();
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// Loadds activity by team membership.
        /// </summary>
        private void LoadActivity()
        {
            var results = new List<Activity>();
            if (_cache.Retrieve<List<HRR.Core.Domain.Interfaces.IActivity>>(SecurityContextManager.Current.CurrentUser.ID.ToString() + "_ActivityFeed") == null)
            { 
                
            }
            var list = new ActivityServices().GetByMaxRows(10);
            if (((Person)SecurityContextManager.Current.CurrentUser).RoleID < (int)SecurityRole.EXECUTIVE_MANAGEMENT)
            {
                if (((Person)SecurityContextManager.Current.CurrentUser).Memberships != null && ((Person)SecurityContextManager.Current.CurrentUser).Memberships.Count > 0)
                {
                    foreach (var t in ((Person)SecurityContextManager.Current.CurrentUser).Memberships)
                    {
                        foreach (var m in list)
                        {
                            foreach (var p in m.PerformedForRef.Memberships)
                            {
                                if (p.TeamID == t.TeamID && p.HasAccess)
                                    results.Add(m);
                                break;
                            }
                            foreach (var p in m.PerformedByRef.Memberships)
                            {
                                if (p.PersonID == SecurityContextManager.Current.CurrentUser.ID && p.TeamID == t.TeamID && p.HasAccess)
                                    results.Add(m);
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                results = list.ToList<Activity>();
            }
            if (results.Count() < 1)
                divActivity.Visible = true;
            else
                divActivity.Visible = false;
            dlComments.DataSource = results.OrderByDescending(o => o.DateCreated);
            dlComments.DataBind();
        }

        #endregion

        #region Alerts Feed

        protected void AlertsItemDataBound(object o, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var item = ((HRR.Core.Domain.Interfaces.IAlert)e.Item.DataItem);
                var lbl = (IdeaSeed.Web.UI.Label)e.Item.FindControl("lblMessage");
                var img = (Telerik.Web.UI.RadBinaryImage)e.Item.FindControl("rbiProfile");
                switch (item.ItemType)
                {
                    case AlertType.GOAL:
                        var g = (HRR.Core.Domain.Goal)item;
                        var p = new PersonServices().GetByID(g.EnteredFor);
                        lbl.Text = "<span style='font-size: 10pt;'><a href='/People/" + p.Email + "'>" + p.Name + "'s</a></span> goal: <a href='/Goals/" + g.ID.ToString() + "'>" + g.Title + "</a><br /> is due <span style='color: #ff0000;'>" + g.DueDate.ToShortDateString() + "</span>";
                        //img.DataValue = HRR.Web.Utils.ImageResize.GetImageBytes(p.AvatarPath);
                        img.ImageUrl = ResourceStrings.AvatarBasePath + p.AvatarPath;
                        break;
                    case AlertType.MILESTONE:
                        var m = (HRR.Core.Domain.GoalMilestone)item;
                        p = new PersonServices().GetByID(m.EnteredFor);
                        lbl.Text = "<span style='font-size: 10pt;'><a href='/People/" +p.Email + "'>" + p.Name + "'s</a></span> milestone: <a href='/Goals/" + m.GoalID.ToString() + "'>" + m.Title + "</a><br /> is due <span style='color: #ff0000;'>" + m.DueDate.ToShortDateString() + "</span>";
                        //img.DataValue = HRR.Web.Utils.ImageResize.GetImageBytes(p.AvatarPath);
                        img.ImageUrl = ResourceStrings.AvatarBasePath + p.AvatarPath;
                        break;
                    case AlertType.REVIEW:
                        var r = (HRR.Core.Domain.Review)item;
                        p = new PersonServices().GetByID(r.EnteredFor);
                        lbl.Text = "<span style='font-size: 10pt;'><a href='/People/" + p.Email + "'>" + p.Name + "'s</a></span> review: <a href='/Reviews/" + r.ID.ToString() + "'>" + r.Title + "</a><br /> is due <span style='color: #ff0000;'>" + r.DueDate.ToShortDateString() + "</span>";
                        //img.DataValue = HRR.Web.Utils.ImageResize.GetImageBytes(p.AvatarPath);
                        img.ImageUrl = ResourceStrings.AvatarBasePath + p.AvatarPath;
                        break;

                }
            }
        }

        private void LoadAlerts()
        {
            var list = new List<HRR.Core.Domain.Interfaces.IAlert>();
            if (_cache.Retrieve<List<HRR.Core.Domain.Interfaces.IAlert>>(SecurityContextManager.Current.CurrentUser.ID.ToString() + "_AlertsFeed") == null)
            {
                list = new AlertServices().GetAlertsByDueDate(DateTime.Now.AddDays(21)).ToList<HRR.Core.Domain.Interfaces.IAlert>();
                _cache.Store(SecurityContextManager
                    .Current
                    .CurrentUser.ID.ToString() + "_AlertsFeed", list);
            }
            else
            {
                list = _cache.Retrieve<List<HRR.Core.Domain.Interfaces.IAlert>>(SecurityContextManager
                    .Current
                    .CurrentUser.ID.ToString() + "_AlertsFeed");
            }
            if (list.Count < 1)
                divAlertsMessage.Visible = true;
            else
                divAlertsMessage.Visible = false;

            dlAlerts.DataSource = list;
            dlAlerts.DataBind();
        }

        #endregion

        #region Upcoming Events Feed
        protected void UpcomingEventsItemDataBound(object o, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var item = ((HRR.Core.Domain.Person)e.Item.DataItem);
                var lbl = (IdeaSeed.Web.UI.Label)e.Item.FindControl("lblMessage");
                var img = (Telerik.Web.UI.RadBinaryImage)e.Item.FindControl("rbiProfile");
                if (((DateTime)item.Birthdate).Month.Equals(DateTime.Now.Month))
                {
                    lbl.Text = "<span style='font-size: 10pt;'><a href='/People/" + item.Email + "'>" + item.Name + "'s</a><br /></span> birthday is <span style='color: #ff6600;'>" + ((DateTime)item.Birthdate).Month.ToString() + "/" + ((DateTime)item.Birthdate).Day.ToString() + "</span>";
                }
                else
                {
                    lbl.Text = "<span style='font-size: 10pt;'><a href='/People/" + item.Email + "'>" + item.Name + "'s</a><br /></span> anniversary is <span style='color: #ff6600;'>" + ((DateTime)item.HireDate).Month.ToString() + "/" + ((DateTime)item.HireDate).Day.ToString() + "</span>";
                }
                //img.ImageUrl = item.AvatarPath;
                img.ImageUrl = ResourceStrings.AvatarBasePath + item.AvatarPath;
                //switch (item.ItemType)
                //{
                //    case AlertType.GOAL:
                //        var g = (HRR.Core.Domain.Person)item;
                //        lbl.Text = "<span style='font-size: 10pt;'><a href='/Profile" + g.EnteredForRef.Email + "'>" + g.EnteredForRef.Name + "'s</a></span> birthday is<span style='color: #00ff00;'>" + g.DueDate.ToShortDateString() + "</span>";
                //        img.ImageUrl = g.EnteredForRef.AvatarPath;
                //        break;
                //    case AlertType.MILESTONE:
                //        var m = (HRR.Core.Domain.GoalMilestone)item;
                //        lbl.Text = "<span style='font-size: 10pt;'><a href='/Profile" + m.GoalRef.EnteredForRef.Email + "'>" + m.GoalRef.EnteredForRef.Name + "'s</a></span> milestone: <a href='/Goal/" + m.GoalRef.ID.ToString() + "'>" + m.Title + "</a><br /> is due <span style='color: #ff0000;'>" + m.DueDate.ToShortDateString() + "</span>";
                //        img.ImageUrl = m.GoalRef.EnteredForRef.AvatarPath;
                //        break;
                //    case AlertType.REVIEW:
                //        var r = (HRR.Core.Domain.Review)item;
                //        lbl.Text = "<span style='font-size: 10pt;'><a href='/Profile" + r.EnteredForRef.Email + "'>" + r.EnteredForRef.Name + "'s</a></span> review: <a href='/Review/" + r.ID.ToString() + "'>" + r.Title + "</a><br /> is due <span style='color: #ff0000;'>" + r.DueDate.ToShortDateString() + "</span>";
                //        img.ImageUrl = r.EnteredForRef.AvatarPath;
                //        break;

                //}
            }
        }

        private void LoadEvents()
        {
            var list = new PersonServices().GetByUpcomingEvent(DateTime.Today);
            if (list.Count < 1)
                divUpcomingEvents.Visible = true;
            else
                divUpcomingEvents.Visible = false;
            dlEvents.DataSource = list.OrderBy(b => b.Birthdate);
            dlEvents.DataBind();
        }
        #endregion

        #region Blog

        private void LoadBlogs()
        {
            var list = new BlogServices().GetForFeed();
            if (list.Count < 1)
                divBlog.Visible = true;
            else
                divBlog.Visible = false;
            dlBlog.DataSource = list;
            dlBlog.DataBind();
        }
        #endregion

        protected void SubmitPollClicked(object o, EventArgs e)
        {
            var result = new HRR.Core.Domain.PollResult();
            var option = new PollOptionServices().GetByID(Convert.ToInt32(rblCurrent.SelectedValue));
            option.TotalSelected = option.TotalSelected + 1;
            new PollOptionServices().Save(option);
            result.EnteredBy = SecurityContextManager.Current.CurrentUser.ID;
            result.DateCreated = DateTime.Now;
            result.PollID = CurrentPoll.ID;
            result.PollOptionID = Convert.ToInt32(rblCurrent.SelectedValue);
            new PollResultServices().Save(result);
            CurrentPoll = null;
            LoadCurrentPoll();
        }

        protected void CurrentPollItemDataBound(object sender, ChartItemDataBoundEventArgs e)
        {
            e.SeriesItem.Name = ((DataRowView)e.DataItem)["Title"].ToString();
            if (e.SeriesItem.YValue == 0)
                e.SeriesItem.Label.Appearance.Visible = false;
                //e.SeriesItem.Parent.Items.Remove(e.SeriesItem);
        } 

        private void LoadCurrentPoll()
        {
            if (CurrentPoll == null)
            {
                var list = new PollServices().GetAllByAccount().OrderByDescending(o => o.ID);
                if (list != null & list.Count() > 0)
                {
                    CurrentPoll = list.ElementAt(0);
                }
            }
            if (CurrentPoll != null)
            {
                lblCurrentPollQuestion.Text = CurrentPoll.Question;
                CurrentPoll.Options = new PollOptionServices().GetByPollID(CurrentPoll.ID).OrderBy(o => o.ID).ToList();
                var result = from p in CurrentPoll.Results
                                where
                                    p.EnteredBy == SecurityContextManager.Current.CurrentUser.ID
                                select p;
                if (result.Count() == 0)
                {
                    divCurrentChart.Visible = false;
                    divCurrentOptions.Visible = true;
                    rblCurrent.Items.Clear();
                    foreach (var item in CurrentPoll.Options)
                    {
                        var li = new ListItem(item.Title, item.ID.ToString());
                        li.Attributes.Add("class", "pollitem");
                        rblCurrent.Items.Add(li);
                    }
                }
                else
                {
                    divCurrentChart.Visible = true;
                    divCurrentOptions.Visible = false;
                    rcCurrentPoll.DataSource = CurrentPoll.Options;
                    rcCurrentPoll.Appearance.Corners.RoundSize = 15;
                    rcCurrentPoll.Appearance.Border.Visible = false;
                    rcCurrentPoll.PlotArea.Chart.Legend.Visible = true;
                    rcCurrentPoll.Series[0].DataYColumn = "TotalSelected";
                    rcCurrentPoll.DataBind();

                    //Color[] barColors = new Color[63]{
                    //Color.LightBlue,
                    //Color.Orange,
                    //Color.LawnGreen,
                    //Color.Tomato,
                    //Color.Wheat,
                    //Color.Lavender,
                    //Color.Green,
                    //Color.SteelBlue,
                    //Color.Aqua,
                    //Color.Yellow,
                    //Color.Navy,
                    //Color.Blue,
                    //Color.Purple,
                    //Color.PaleGreen,
                    //Color.Pink,
                    //Color.Orange,
                    //Color.LightPink,
                    //Color.DarkOliveGreen,
                    //Color.Olive,
                    //Color.Pink,
                    //Color.SteelBlue,
                    //Color.Aqua,
                    //Color.Yellow,
                    //Color.Navy,
                    //Color.Green,
                    //Color.Blue,
                    //Color.Red,
                    //Color.Purple,
                    //Color.PowderBlue,
                    //Color.PaleGreen,
                    //Color.LightPink,
                    //Color.DarkOliveGreen,
                    //Color.Olive,
                    //Color.Pink,
                    //Color.SteelBlue,
                    //Color.Aqua,
                    //Color.Yellow,
                    //Color.Navy,
                    //Color.Green,
                    //Color.Blue,
                    //Color.Red,
                    //Color.Purple,
                    //Color.PowderBlue,
                    //Color.PaleGreen,
                    //Color.Orange,
                    //Color.LightPink,
                    //Color.DarkOliveGreen,
                    //Color.Olive,
                    //Color.Pink,
                    //Color.SteelBlue,
                    //Color.Aqua,
                    //Color.Yellow,
                    //Color.Navy,
                    //Color.Green,
                    //Color.Blue,
                    //Color.Red,
                    //Color.Purple,
                    //Color.PowderBlue,
                    //Color.PaleGreen,
                    //Color.Orange,
                    //Color.LightPink,
                    //Color.DarkOliveGreen,
                    //Color.Olive
                    //};
                    //int i = 0;
                    if (rcCurrentPoll.Series.Count > 0)
                    {
                        foreach (var item in rcCurrentPoll.Series[0].Items)
                        {
                            item.Appearance.Border.Color = Color.White;
                            //item.Appearance.FillStyle.MainColor = barColors[i++];
                            //item.Appearance.FillStyle.SecondColor = barColors[i++];
                            //item.Appearance.FillStyle.FillType = Telerik.Charting.Styles.FillType.Solid;
                        }
                    }
                }
            }
            else
            {
                divCurrentChart.Visible = false;
                lbSubmitPoll.Visible = false;
                lblCurrentPollQuestion.Text = "An active poll was not found.";

            }
        }

        protected void LoadMyStats()
        {
            var r = new ReviewServices().GetEmployeeActiveReview(SecurityContextManager.Current.CurrentUser.ID);

            SecurityContextManager.Current.CurrentReview = r;
            lblEmployeeScore.Text = (HRR.Services.ReviewServices.CalculateCommentsScore(r)["Weighted"] + HRR.Services.ReviewServices.CalculateGoalsScore(r)["Weighted"] + HRR.Services.ReviewServices.CalculateQuestionsScore(r)["Weighted"]).ToString() + "%";
        }

        private void LoadCommentCounts()
        {
            var ct = new CommentServices().GetCommentTotalsByEmployeeID(SecurityContextManager.Current.CurrentUser.ID, SecurityContextManager.Current.CurrentReview.StartDate.ToShortDateString(), SecurityContextManager.Current.CurrentReview.DueDate.ToShortDateString());
            if (ct != null)
            {
                PositiveCommentsTotal = ct.LeftForPositive;
                ConstructiveCommentsTotal = ct.LeftForConstructive;
                lblConstructiveLeftFor.InnerHtml = ct.LeftForConstructive.ToString() + " <img src='/images/downh.png' border='0' alt='Constructive' />";
                lblPositiveLeftFor.InnerHtml = ct.LeftForPositive.ToString() + " <img src='/images/uph.png' border='0' alt='Positive' />";
                lblPositiveLeftBy.InnerHtml = ct.LeftByPositive.ToString() + " <img src='/images/uph.png' border='0' alt='Positive' />";
                lblConstructiveLeftBy.InnerHtml = ct.LeftByConstructive.ToString() + " <img src='/images/downh.png' border='0' alt='Constructive' />";
            }
            else
            {
                lblConstructiveLeftFor.InnerHtml = "0 <img src='/images/downh.png' border='0' alt='Constructive' />";
                lblPositiveLeftFor.InnerHtml = "0 <img src='/images/uph.png' border='0' alt='Positive' />";
                lblPositiveLeftBy.InnerHtml = "0 <img src='/images/uph.png' border='0' alt='Positive' />";
                lblConstructiveLeftBy.InnerHtml = "0 <img src='/images/downh.png' border='0' alt='Constructive' />";
            }
        }

        private void UpdateGoalProgress()
        {
            decimal complete = 0;
            decimal total = 0;
            foreach (var g in SecurityContextManager.Current.CurrentReview.Goals)
            {
                complete += g.Progress;
                total += 100;
            }
            if (total > 0)
            {
                GoalProgress = Convert.ToInt16((complete / total) * 100).ToString();
            }
            else
            {
                GoalProgress = "0";
            }
            lblProgressText.Text = GoalProgress + "% complete";
        }
    }
}