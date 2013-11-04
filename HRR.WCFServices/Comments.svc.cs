using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using HRR.Core.Domain;
using HRR.Services;

namespace HRR.WCFServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class Comments : IComments
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public string GetCommentListByFilters(string userID)
        {
            var list = new CommentServices().GetByEnteredBy(Convert.ToInt16(userID));
            string s = "";
            foreach (var item in list)
            {
                s += "{\"name\":\"" + item.EnteredForRef.FirstName + " " + item.EnteredForRef.LastName + "\",\"commentType\":\"" + item.CommentType.ToString() + "\",\"message\":\"" + item.Message + "\",\"enteredBy\":\"" + item.EnteredByRef.FirstName + " " + item.EnteredByRef.LastName + "\",\"commentDate\":\"" + item.DateCreated.ToShortDateString() + "\"}";
            }
            return "";
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
