using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Web;
using IdeaSeed.Core;
using HRR.Core.Domain;
using Telerik.Web.UI;
using System.Configuration;
using System.Web;
using System.Web.UI;
using HRR.Core.Security;

namespace HRR.Web.Utils
{
    public class HttpPageHelper
    {

        public static bool IsValidRequest
        {
            get { return HttpContextHelper.Get<bool>("SQ_IS_VALID_REQUEST"); }
            set { HttpContextHelper.Set("SQ_IS_VALID_REQUEST", value); }
        }

        public static IBaseItem CurrentItem
        {
            get { return HttpContextHelper.Get<IBaseItem>("SQ_CURRENTITEM"); }
            set { HttpContextHelper.Set("SQ_CURRENTITEM", value); }
        }

        public static Person CurrentUser
        {
            get { return HttpContextHelper.Get<Person>("SQ_CURRENTUSER"); }
            set { HttpContextHelper.Set("SQ_CURRENTUSER", value); }
        }

        public static Person CurrentProfile
        {
            get { return HttpContextHelper.Get<Person>("SQ_CURRENTPROFILE"); }
            set { HttpContextHelper.Set("SQ_CURRENTPROFILE", value); }
        }

        public static Documentation CurrentDocumentation
        {
            get { return HttpContextHelper.Get<Documentation>("SQ_CURRENTDOCUMENTATION"); }
            set { HttpContextHelper.Set("SQ_CURRENTDOCUMENTATION", value); }
        }

        public static void SetImagesPath(RadEditor re)
        {
            string[] viewImages;
            string[] uploadImages;
            string[] deleteImages;
            viewImages = new string[] { ConfigurationManager.AppSettings["IMAGEURL"] };
            uploadImages = new string[] { ConfigurationManager.AppSettings["IMAGEURL"] };
            deleteImages = new string[] { ConfigurationManager.AppSettings["IMAGEURL"] };
            re.ImageManager.ViewPaths = viewImages;
            re.ImageManager.UploadPaths = uploadImages;
            re.ImageManager.DeletePaths = deleteImages;
        }

        static string DateFormat
        {
            get
            {
                return "yyyyMMddTHHmmssZ"; // 20060215T092000Z
            }
        }

        public static void ExportToCalendar(DateTime startdate, DateTime enddate, string location, string description, string summary)
        {
            HttpContext.Current.Response.ContentType = "text/calendar";
            HttpContext.Current.Response.AddHeader("Content-disposition", "attachment; filename=appointment.ics");

            HttpContext.Current.Response.Write("BEGIN:VCALENDAR");
            HttpContext.Current.Response.Write("\nVERSION:2.0");
            HttpContext.Current.Response.Write("\nMETHOD:PUBLISH");
            HttpContext.Current.Response.Write("\nBEGIN:VEVENT");
            HttpContext.Current.Response.Write("\nORGANIZER:MAILTO:" + ((Person)SecurityContextManager.Current.CurrentUser).Email);
            HttpContext.Current.Response.Write("\nDTSTART:" + startdate.ToUniversalTime().ToString(DateFormat));
            HttpContext.Current.Response.Write("\nDTEND:" + enddate.ToUniversalTime().ToString(DateFormat));
            HttpContext.Current.Response.Write("\nLOCATION:" + location);
            HttpContext.Current.Response.Write("\nUID:" + DateTime.Now.ToUniversalTime().ToString(DateFormat) + "@" + SecurityContextManager.Current.CurrentAccount.Domain.Replace("http://www.", "").Replace("www.", ""));
            HttpContext.Current.Response.Write("\nDTSTAMP:" + DateTime.Now.ToUniversalTime().ToString(DateFormat));
            HttpContext.Current.Response.Write("\nSUMMARY:" + summary);
            HttpContext.Current.Response.Write("\nDESCRIPTION:" + description);
            HttpContext.Current.Response.Write("\nPRIORITY:5");
            HttpContext.Current.Response.Write("\nCLASS:PUBLIC");
            HttpContext.Current.Response.Write("\nEND:VEVENT");
            HttpContext.Current.Response.Write("\nEND:VCALENDAR");
            HttpContext.Current.Response.End();
        }
    }
}
