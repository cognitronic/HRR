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

namespace HRR.Website
{
    public partial class Default : HRRBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { }
                //LoadCommentType();
        }

        //private void LoadCommentType()
        //{
        //    var list = new CommentServices().GetAllAppropriate();
        //    var lst = new List<HRR.Core.Charting.Comment>();

        //    if (list != null && list.Count > 0)
        //    {
        //        foreach (var l in list.GroupBy(p => p.EnteredFor))
        //        { 
        //            if(l.Count() > 0)
        //            {
        //                lst.Add(new Core.Charting.Comment(
        //                    l.First().EnteredForRef.Name, 
        //                    "Positive", 
        //                    l.Select(o => 
        //                        (o.EnteredFor == l.First().EnteredFor) 
        //                        && (o.CommentType == 1)).Count()
        //                        ,l.Select(o => 
        //                            (o.EnteredFor == l.First().EnteredFor) 
        //                            && (o.CommentType == -1)).Count()));
        //            }
        //            //if(l.CommentType == 1)
        //            //    lst.Add(new Core.Charting.Comment(l.EnteredForRef.Name, "Positive", list.Select(o => (o.EnteredFor == l.EnteredFor) && (o.CommentType == 1)).Count()));
        //            //else
        //            //    lst.Add(new Core.Charting.Comment(l.EnteredForRef.Name, "Negative", list.Select(o => (o.EnteredFor == l.EnteredFor) && (o.CommentType == -1)).Count()));
        //        }
        //        rcCommentTypes.DataSource = lst;
        //        rcCommentTypes.Appearance.Corners.RoundSize = 15;
        //        rcCommentTypes.Appearance.Border.Visible = false;
        //        rcCommentTypes.DataGroupColumn = "CommentType";

        //        switch (rcCommentTypes.Series.Count)
        //        {
        //            case 1:
        //                rcCommentTypes.Series[0].Type = Telerik.Charting.ChartSeriesType.Pie;
        //                break;
        //            case 2:
        //                rcCommentTypes.Series[0].Type = Telerik.Charting.ChartSeriesType.Pie;
        //                rcCommentTypes.Series[0].DataXColumn = "PositiveCount";
        //                rcCommentTypes.Series[1].DataXColumn = "NegativeCount";
        //                rcCommentTypes.Series[0].DataLabelsColumn = "Name";
        //                rcCommentTypes.Series[1].Type = Telerik.Charting.ChartSeriesType.Pie;
        //                break;
        //        }

        //        rcCommentTypes.DataBind();
        //    }
        //}
    }
}