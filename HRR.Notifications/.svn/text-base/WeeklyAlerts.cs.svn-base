using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRR.Core.Domain;
using HRR.Core;
using HRR.Services;
using IdeaSeed.Core.Mail;
using IdeaSeed.Core;
using System.IO;


namespace HRR.Notifications
{
    class WeeklyAlerts
    {
        private void SendWeeklyReport()
        {
            var list = new PersonServices().GetEntirePersonList();
            foreach (var person in list)
            {
                try
                {
                    if (person.ReceiveCommentNotifications && person.IsActive)
                        EmailHelper.SendWeeklyUpdateNotification(person);
                }
                catch (Exception exc)
                {
                    try
                    {
                        IdeaSeed.Core.Utils.Utilities.WriteXMLErrorToDisc(exc.Message, "", exc.StackTrace, "Auto", "HR River", "", "SendingWeeklyUpdateError", "person: " + person.Name);

                    }
                    catch (Exception ex)
                    {
                        StreamWriter wr = new StreamWriter(@"sendingweeklyupdate.log");
                        wr.WriteLine(ex.Message);
                        wr.WriteLine("<br /><br />");
                        wr.WriteLine(ex.StackTrace);
                        wr.Close();
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            var wa = new WeeklyAlerts();
            wa.SendWeeklyReport();
        }
    }
}
