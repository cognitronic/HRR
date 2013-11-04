using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HRR.Core.Domain;
using HRR.Services;
using HRR.Core.Security;
using HRR.Web.Bases;
using HRR.Web.Utils;
using Telerik.Web.UI;
using System.Configuration;
using IdeaSeed.Core;
using System.Text;

namespace HRR.Web.Utils
{
    public class CommentUtils
    {
        public IList<Comment> GetTeamsComments()
        {
            var list = new List<Comment>();
            var results = new List<Comment>();
            var temp = new List<Comment>();
            var temp2 = new List<Comment>();
            foreach (var memberships in ((Person)SecurityContextManager.Current.CurrentUser).Memberships)
            {
                var team = memberships.TeamRef;
                bool ismanager = false;
                list = new CommentServices().GetByTeamID(team.ID).OrderByDescending(o => o.DateCreated).ToList<Comment>();

                foreach (var m in team.Members)
                {
                    if (m.PersonID == SecurityContextManager.Current.CurrentUser.ID)
                    {
                        if (m.IsManager)
                            ismanager = true;
                    }
                }
                if (!ismanager)
                {

                    temp = list;
                    temp.RemoveAll(o => (o.CommentType == -1 &&
                        o.EnteredBy != SecurityContextManager.Current.CurrentUser.ID));
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
            }
            return results;
        }
    }
}
