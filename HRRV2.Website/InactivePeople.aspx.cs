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
    public partial class InactivePeople : HRRBasePage
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

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (((Person)SecurityContextManager.Current.CurrentUser).RoleID < (int)SecurityRole.EXECUTIVE_MANAGEMENT)
            //{
            //    Response.Redirect("/Overview");
            //}
            if (!IsPostBack)
            {
                IdeaSeed.Core.Data.NHibernate.NHibernateSessionManager.Instance.CloseSession();
                LoadPeople();
                if (((Person)SecurityContextManager.Current.CurrentUser).RoleID < (int)SecurityRole.ADMIN)
                {
                    //lbAddEmployee.Visible = false;
                    //lbInactiveEmployees.Visible = false;
                }
            }
        }

        private void LoadPeople()
        {
            PagedDataSource pd = new PagedDataSource();

            var list = new List<Person>();
            list = new PersonServices().GetByStatus(false).ToList<Person>();

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

            dlPeople.DataSource = pd;
            dlPeople.DataBind();
        }

        protected void ItemDataBound(object o, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var p = ((HRR.Core.Domain.Person)e.Item.DataItem);
                var avatar = (Telerik.Web.UI.RadBinaryImage)e.Item.FindControl("rbiProfile");
                var commentRow = (HtmlGenericControl)e.Item.FindControl("divRow");
                //var responseph = (HtmlGenericControl)e.Item.FindControl("phResponses");
                var info = (IdeaSeed.Web.UI.Label)e.Item.FindControl("lblMissingInfo");

                if (p.DepartmentID < 1)
                    info.Text = "<font color='red'>Department</font>&nbsp;&nbsp; ";
                if (p.ManagerID < 1)
                    info.Text += "<font color='blue'>Manager</font>&nbsp;&nbsp; ";
                if (p.RoleID < 1)
                    info.Text += "<font color='black'>Security_Role</font>&nbsp;&nbsp; ";
                if (p.HireDate == null || p.HireDate < DateTime.Today.AddYears(-50))
                    info.Text += "<font color='green'>Hire_Date</font>&nbsp;&nbsp;";

                if (p.AvatarPath.StartsWith("http://"))
                {
                    avatar.ImageUrl = p.AvatarPath + "25";
                }
                else
                {
                    HRR.Web.Utils.ImageResize.ResizeImage(25, ResourceStrings.AvatarBasePath + p.AvatarPath, avatar);
                    avatar.ResizeMode = Telerik.Web.UI.BinaryImageResizeMode.Fit;
                }
            }
        }

        protected void StaffItemCommand(object o, DataListCommandEventArgs e)
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
            //    LoadComments();
            //}
        }

        protected void PrevClicked(object sender, System.EventArgs e)
        {
            // Set viewstate variable to the previous page
            CurrentPage -= 1;

            // Reload control
            LoadPeople();
        }

        protected void NextClicked(object sender, System.EventArgs e)
        {
            // Set viewstate variable to the next page
            CurrentPage += 1;

            // Reload control
            LoadPeople();
        }

        protected void SaveClicked(object o, EventArgs e)
        {
            foreach (DataListItem row in dlPeople.Items)
            {
                if (row.ItemType == ListItemType.Item || row.ItemType == ListItemType.AlternatingItem)
                {
                    if (((IdeaSeed.Web.UI.CheckBox)row.FindControl("cbSelected")).Checked)
                    {
                        var p = new PersonServices().GetByID(Convert.ToInt32(((IdeaSeed.Web.UI.CheckBox)row.FindControl("cbSelected")).Attributes["itemid"]));

                        if (cbIsManagerFilter.Checked)
                            p.IsManager = true;
                        if (ddlManagerFilter.SelectedIndex > 0)
                            p.ManagerID = Convert.ToInt32(ddlManagerFilter.SelectedValue);
                        if (ddlDepartmentFilter.SelectedIndex > 0)
                            p.DepartmentID = Convert.ToInt32(ddlDepartmentFilter.SelectedValue);
                        if (ddlSecurityRoleFilter.SelectedIndex > 0)
                            p.RoleID = Convert.ToInt32(ddlSecurityRoleFilter.SelectedValue);
                        if (tbHireDateFilter.SelectedDate != null)
                            p.HireDate = tbHireDateFilter.SelectedDate;
                        if (ddlTeamFilter.SelectedIndex > 0)
                        {
                            var tm = new TeamMember();
                            tm.HasAccess = true;
                            tm.IsActive = true;
                            tm.IsManager = false;
                            tm.PersonID = p.ID;
                            tm.TeamID = Convert.ToInt32(ddlTeamFilter.SelectedValue);
                            new TeamMemberServices().Save(tm);
                        }

                        if (
                            (p.DepartmentID != 0) &&
                            (p.HireDate != null) &&
                            (p.RoleID != 0) &&
                            (p.ManagerID != 0))
                        {

                            p.IsActive = true;
                        }
                        new PersonServices().Save(p);
                    }
                }
            }
            var _cache = new MemcacheCacheAdapter();
            _cache.Remove(SecurityContextManager
                 .Current
                 .CurrentUser.AccountID.ToString() + "_DepartmentsList");
            var list = new PersonServices().GetByAccountID(SecurityContextManager.Current.CurrentAccount.ID).OrderBy(l => l.LastName).ToList<Person>();
            _cache.Store(SecurityContextManager
                 .Current
                 .CurrentUser.AccountID.ToString() + "_DepartmentsList", list);
            LoadPeople();
        }

        protected void CancelClicked(object o, EventArgs e)
        { 
            
        }
    }
}