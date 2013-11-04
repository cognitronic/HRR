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
    public partial class Staff : HRRBasePage
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
                LoadPeople(true);
                if (((Person)SecurityContextManager.Current.CurrentUser).RoleID < (int)SecurityRole.ADMIN)
                {
                    //lbAddEmployee.Visible = false;
                    //lbInactiveEmployees.Visible = false;
                }
            }
        }

        protected void AddEmployeeClicked(object o, EventArgs e)
        {
            Response.Redirect("/People/New");
        }

        protected void InactiveEmployeeClicked(object o, EventArgs e)
        {
            Response.Redirect("/People/Inactive");
        }

        protected void StatusSelectedIndexChanged(object o, EventArgs e)
        {

            LoadPeople(Convert.ToBoolean(ddlStatus.SelectedValue));
        }

        private void LoadPeople(bool status)
        {
            PagedDataSource pd = new PagedDataSource();

            var list = new List<Person>();
            if (_cache.Retrieve<List<Person>>(SecurityContextManager.Current.CurrentUser.ID.ToString() + "_DepartmentsList") == null)
            {

                list = new PersonServices().GetByAccountID(SecurityContextManager.Current.CurrentAccount.ID).OrderBy(o => o.LastName).ToList<Person>();
                _cache.Store(SecurityContextManager
                     .Current
                     .CurrentUser.AccountID.ToString() + "_DepartmentsList", list);
            }
            else
            {
                list = _cache.Retrieve<List<Person>>(SecurityContextManager
                    .Current
                    .CurrentUser.AccountID.ToString() + "_DepartmentsList");
            }

            list = list.Where(o => o.IsActive == status).ToList<Person>();

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
            LoadPeople(Convert.ToBoolean(ddlStatus.SelectedValue));
        }

        protected void NextClicked(object sender, System.EventArgs e)
        {
            // Set viewstate variable to the next page
            CurrentPage += 1;

            // Reload control
            LoadPeople(Convert.ToBoolean(ddlStatus.SelectedValue));
        }
    }
}