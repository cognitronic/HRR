using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
using HRR.Core.Domain;
using HRR.Core.Security;
//using HRR.Web.Bases;
//using HRR.Web.Utils;
//using Telerik.Web.UI;
using System.Configuration;
using IdeaSeed.Core;
using System.Text;
using System.IO;
using HRR.Core;

namespace HRR.Services
{
    public class EmailHelper
    {
        public static string EmailHTMLStart()
        {
            string s = @"<html><head>
<style type='text/css'>
            html {-webkit-text-size-adjust:none;}
            body {background-color: #1ea2db; padding:0; margin:0; width:100%; margin:0 auto;}
            *[class].tdwrap{display: inline-block !important;}
            *[class].vspacer{ margin-left: 50px; }
            *[class].responsive-50per{ width: 50% !important; }
            @media all and (max-width: 590px){
              *[class].responsive{width:320px !important;}
              *[class].responsive-spacer table{width: 20px !important; }
              *[class].vspacer{ margin-top: 10px !important; margin-bottom: 15px !important; margin-left: 0 !important; }
              *[class].res-font16{font-size:16px !important;}
              *[class].res-font12{font-size:12px !important;}
              *[class].res-font18{font-size:18px !important;}
              *[class].res-font18 span{font-size: 18px !important;}
              *[class].responsive-50per{ width: 100% !important;}
              *[class].responsive-spacer70{ width: 70px !important; }
              *[class].hideIMG{ height: 0px !important; width: 0px !important; }
              *[class].res-width25{ width: 25px !important; };
              *[class].res-padding{ width: 0 !important; }
              *[class].res-padding table{ width: 0 !important; }
              *[class].cellpadding-none{ width: 0px !important; }
              *[class].cellpadding-none table{ border: collapse !important; }
              *[class].cellpadding-none table td{ padding: 0 !important; }
              *[class].display-none{ display: none !important; }
            }
            @media only screen and (max-device-width: 480px) {
              p[class=anet-digest-activity],
              span[class=anet-digest-count],
              td[class=anet-digest-right-rail] {
                display:none;
              }
            }
            
          </style>
        </head>
        <body style='background-image: none; background-color: white; color: black; '>
<table width='750px' border='0' align='center' cellspacing='0' cellpadding='0' bgcolor='#1ea2db' style='border:solid 1px #1ea2db;-moz-border-radius:5px;-webkit-border-radius:5px;border-radius:5px;'>
  <tbody><tr><td><table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:10px;font-size:10px;line-height:10px;'>&nbsp;</div></td></tr></tbody></table></td></tr>
  <tr align='center'>
    <td>
      <table width='700' border='0' cellspacing='0' cellpadding='0'>
        <tbody><tr align='left'>
          <td>
            <a href='" + ConfigurationManager.AppSettings["BASEURL"] + @"'><img src='" + ConfigurationManager.AppSettings["NOTIFICATIONLOGO"] + @"' height='39' width='193' alt='HR River Logo' border='0'></a>
          </td>
        </tr>
      </tbody></table>
    </td>
  </tr>
  <tr><td><table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:10px;font-size:10px;line-height:10px;'>&nbsp;</div></td></tr></tbody></table></td></tr>
	
";
            return s;
        }

        public static string EmailHTMLEnd()
        {
            string s = @"</tbody></table>
                </td>
              </tr>
            </tbody></table>
          </td>
          <td width='1%'><table width='20' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:0px;font-size:0px;line-height:0px;'>&nbsp;</div></td></tr></tbody></table></td><!-- RIGHT PADDING - 1% with a min-width of 20px -->
        </tr>
        <tr><td colspan='3'><table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:20px;font-size:20px;line-height:20px;'>&nbsp;</div></td></tr></tbody></table></td></tr>
      </tbody></table>
    </td>
  </tr><tr>
    <td align='center'>
      


<table border='0' cellspacing='0' cellpadding='0' style='font-family:Arial;' width='700' class='responsive'>
  <tbody><tr><td><table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:10px;font-size:10px;line-height:10px;'>&nbsp;</div></td></tr></tbody></table></td></tr>
  <tr>
    <td align='center' style='font-size:11px; font-family:Arial,sans-serif; color:#ffffff;'>
             <a style='color:#ffffff;text-decoration:underline;' href='" + ConfigurationManager.AppSettings["BASEURL"] + "/Help/FAQ" + @"'>Help &amp; Documentation</a>&nbsp;&nbsp;&nbsp;&nbsp;
             <a style='color:#ffffff;text-decoration:underline;' href='mailto:support@hrriver.com'>Support</a>&nbsp;&nbsp;&nbsp;&nbsp;
             <a style='color:#ffffff;text-decoration:underline;' href='mailto:feedback@hrriver.com'>Feedback</a>&nbsp;&nbsp;&nbsp;&nbsp;
        <table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:10px;font-size:10px;line-height:10px; color: #ffffff;'>&nbsp;</div></td></tr></tbody></table>

            All information within is regarded as private and confidential. © " + DateTime.Now.Year.ToString() + @", <a style='color:#ffffff;text-decoration:underline;' href='http://www.hrriver.com/'>HR River, LLC.</a> 
    </td>
  </tr>
  <tr><td><table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:10px;font-size:10px;line-height:10px;'>&nbsp;</div></td></tr></tbody></table></td></tr>
</tbody></table>


    </td>
  </tr>
  

  <tr><td><table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:10px;font-size:10px;line-height:10px;'>&nbsp;</div></td></tr></tbody></table></td></tr>
</tbody></table>

      </body></html>";
            return s;
        }

        private static string BuildBlogForNotification()
        {
            var blog = new BlogServices().GetLastestPost();
            if (blog != null)
            {
                var s = @"<tr align='center'>
    <td>
      <table width='700' border='0' cellspacing='0' cellpadding='0' bgcolor='#FFFFFF' style='border:solid 1px #DDDDDD;-moz-border-radius:5px;-webkit-border-radius:5px;border-radius:5px;'>
        <tbody><tr><td colspan='3'><table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:20px;font-size:20px;line-height:20px;'>&nbsp;</div></td></tr></tbody></table></td></tr>
        <tr>
          <td width='1%'><table width='20' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:0px;font-size:0px;line-height:0px;'>&nbsp;</div></td></tr></tbody></table></td><!-- LEFT PADDING - 1% with a min-width of 20px -->
          <td width='98%'>
            
            <table width='100%' border='0' cellspacing='0' cellpadding='0'>
              <tbody><tr>
                <td align='left' colspan='3' style='font-family: Arial; font-size: 16px; color: #333333'>Latest Blog Post</td>
              </tr>
              <tr><td colspan='3'><table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:15px;font-size:15px;line-height:15px;'>&nbsp;</div></td></tr></tbody></table></td></tr>
              <tr>
                <td width='52' valign='top'>";

                if (blog.EnteredByRef.AvatarPath.StartsWith("http://"))
                {
                    s += "<a href='" + ConfigurationManager.AppSettings["BASEURL"] + "/People/" + blog.EnteredByRef.Email + @"'>
                      <img src='" + blog.EnteredByRef.AvatarPath + @"50' border='0' style='display: block;'>
                      </a>";
                }
                else
                {
                     s += "<a href='" + ConfigurationManager.AppSettings["BASEURL"] + "/People/" + blog.EnteredByRef.Email + @"'>
                      <img src='" + ConfigurationManager.AppSettings["BASEURL"] + HRR.Core.ResourceStrings.AvatarBasePath + blog.EnteredByRef.AvatarPath + @"' border='0' width='50' height='50' style='display: block; width: 50px !important; height: 50px !important;'>
                      </a>";
                }
                      
                s += @"</td>
                <td width='5'></td>
                <td align='left' valign='top'>
                  <table width='100%' border='0' cellspacing='0' cellpadding='0'>
                    <tbody><tr>
                      <td width='390'>
                        <div>
                          
                          <a href='" + ConfigurationManager.AppSettings["BASEURL"] + "/Blogs/" + blog.ID.ToString() + @"' style='text-decoration:none;'>
                            <span style='font-family:Arial;font-size:14px;color:#006699;'>" + blog.Title + @"</span>
                          </a>
                            
                        </div>
                        <div style='font-family: Arial; font-size: 11px; color: #666666'>
                          entered by <span style='color: #ff6600;'>" + blog.EnteredByRef.Name + @"</span> on " + blog.StartDate.ToShortDateString() + @"
                        </div>
                      </td>
                    </tr>
                    <tr><td colspan='2'><table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:5px;font-size:5px;line-height:5px;'>&nbsp;</div></td></tr></tbody></table></td></tr>
                
";
                foreach (var response in blog.Responses)
                {
                    s += @"<tr>
                      <td colspan='2'>
                        <table width='100%' border='0' cellspacing='10' cellpadding='0' bgcolor='#f0f0f0' style='border: 1px solid #ffffff;'>
                          <tbody><tr>
                            <td width='30' valign='top'>";

                    if (blog.EnteredByRef.AvatarPath.StartsWith("http://"))
                    {
                        s += "<a href='" + ConfigurationManager.AppSettings["BASEURL"] + "/People/" + response.EnteredByRef.Email + @"'>
                      <img src='" + response.EnteredByRef.AvatarPath + @"30' border='0' style='display: block;'>
                      </a>";
                    }
                    else
                    {
                        s += "<a href='" + ConfigurationManager.AppSettings["BASEURL"] + "/People/" + response.EnteredByRef.Email + @"'>
                      <img src='" + ConfigurationManager.AppSettings["BASEURL"] + HRR.Core.ResourceStrings.AvatarBasePath + response.EnteredByRef.AvatarPath + @"' border='0' style='display: block; width: 30px !important; height: 30px !important;'  width='30' height='30'/>
                      </a>";
                    }

                    s += @"</td>
                            <td>
                              <div style='font-family: Arial; font-size: 11px; color: #333333'>
                                " + IdeaSeed.Core.Utils.Utilities.FormatTextForCondensedDisplay(response.Comment, 75) + @"...
                                
                                  
                                  <a href='" + ConfigurationManager.AppSettings["BASEURL"] + "/Blogs/" + blog.ID.ToString() + @"' style='text-decoration:none;'>
                                    <span style='font-family:Arial;font-size:11px;color:#006699;'>more »</span>
                                  </a>
                              </div>
                            </td>
                          </tr>
                        </tbody></table>
                      </td>
                    </tr>";
                }
                return s;
            }
            else
            {
                var s = @"<tr align='center'>
    <td>
      <table width='700' border='0' cellspacing='0' cellpadding='0' bgcolor='#FFFFFF' style='border:solid 1px #DDDDDD;-moz-border-radius:5px;-webkit-border-radius:5px;border-radius:5px;'>
        <tbody><tr><td colspan='3'><table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:20px;font-size:20px;line-height:20px;'>&nbsp;</div></td></tr></tbody></table></td></tr>
        <tr>
          <td width='1%'><table width='20' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:0px;font-size:0px;line-height:0px;'>&nbsp;</div></td></tr></tbody></table></td><!-- LEFT PADDING - 1% with a min-width of 20px -->
          <td width='98%'>
            
            <table width='100%' border='0' cellspacing='0' cellpadding='0'>
              <tbody><tr>
                <td align='left' colspan='3' style='font-family: Arial; font-size: 16px; color: #333333'>Latest Blog Post</td>
              </tr>
              <tr><td colspan='3'><table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:15px;font-size:15px;line-height:15px;'>&nbsp;</div></td></tr></tbody></table></td></tr>
              <tr>
                <td width='300' style='font-family: Arial;' valign='top'>
                  
                      
                      No Blog Posts Found
                    
                </td>
                <td width='5'></td>
                <td align='left' valign='top'>
                  <table width='100%' border='0' cellspacing='0' cellpadding='0'>
                    <tbody><tr>
                      <td width='390'>
                        
                      </td>
                    </tr>
                    <tr><td colspan='2'><table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:5px;font-size:5px;line-height:5px;'>&nbsp;</div></td></tr></tbody></table></td></tr>
                
";

                return s;
            }
        }

        private static string BuildBlogForNotification(int accountid)
        {
            var blog = new BlogServices().GetLastestPost(accountid);
            if (blog != null)
            {
                var s = @"<tr align='center'>
    <td>
      <table width='700' border='0' cellspacing='0' cellpadding='0' bgcolor='#FFFFFF' style='border:solid 1px #DDDDDD;-moz-border-radius:5px;-webkit-border-radius:5px;border-radius:5px;'>
        <tbody><tr><td colspan='3'><table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:20px;font-size:20px;line-height:20px;'>&nbsp;</div></td></tr></tbody></table></td></tr>
        <tr>
          <td width='1%'><table width='20' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:0px;font-size:0px;line-height:0px;'>&nbsp;</div></td></tr></tbody></table></td><!-- LEFT PADDING - 1% with a min-width of 20px -->
          <td width='98%'>
            
            <table width='100%' border='0' cellspacing='0' cellpadding='0'>
              <tbody><tr>
                <td align='left' colspan='3' style='font-family: Arial; font-size: 16px; color: #333333'>Latest Blog Post</td>
              </tr>
              <tr><td colspan='3'><table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:15px;font-size:15px;line-height:15px;'>&nbsp;</div></td></tr></tbody></table></td></tr>
              <tr>
                <td width='52' valign='top'>
                  
                      
                      <a href='" + ConfigurationManager.AppSettings["BASEURL"] + "/People/" + blog.EnteredByRef.Email + @"'>
                      <img src='" + ConfigurationManager.AppSettings["BASEURL"] + HRR.Core.ResourceStrings.AvatarBasePath + "thumb_" + blog.EnteredByRef.AvatarPath + @"' border='0' style='display: block;'>
                      </a>
                        
                    
                </td>
                <td width='5'></td>
                <td align='left' valign='top'>
                  <table width='100%' border='0' cellspacing='0' cellpadding='0'>
                    <tbody><tr>
                      <td width='390'>
                        <div>
                          
                          <a href='" + ConfigurationManager.AppSettings["BASEURL"] + "/Blogs/" + blog.ID.ToString() + @"' style='text-decoration:none;'>
                            <span style='font-family:Arial;font-size:14px;color:#006699;'>" + blog.Title + @"</span>
                          </a>
                            
                        </div>
                        <div style='font-family: Arial; font-size: 11px; color: #666666'>
                          entered by <span style='color: #ff6600;'>" + blog.EnteredByRef.Name + @"</span> on " + blog.StartDate.ToShortDateString() + @"
                        </div>
                      </td>
                    </tr>
                    <tr><td colspan='2'><table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:5px;font-size:5px;line-height:5px;'>&nbsp;</div></td></tr></tbody></table></td></tr>
                
";
                foreach (var response in blog.Responses)
                {
                    s += @"<tr>
                      <td colspan='2'>
                        <table width='100%' border='0' cellspacing='10' cellpadding='0' bgcolor='#f0f0f0' style='border: 1px solid #ffffff;'>
                          <tbody><tr>
                            <td width='30' valign='top'>
                              
                                 
                                  <img src='" + ConfigurationManager.AppSettings["BASEURL"] + HRR.Core.ResourceStrings.AvatarBasePath + "thumb_" + response.EnteredByRef.AvatarPath + @"' width='30' height='30' border='0' style='display: block;'>
                                  
                                    
                                
                            </td>
                            <td>
                              <div style='font-family: Arial; font-size: 11px; color: #333333'>
                                " + IdeaSeed.Core.Utils.Utilities.FormatTextForCondensedDisplay(response.Comment, 75) + @"...
                                
                                  
                                  <a href='" + ConfigurationManager.AppSettings["BASEURL"] + "/Blogs/" + blog.ID.ToString() + @"' style='text-decoration:none;'>
                                    <span style='font-family:Arial;font-size:11px;color:#006699;'>more »</span>
                                  </a>
                              </div>
                            </td>
                          </tr>
                        </tbody></table>
                      </td>
                    </tr>";
                }
                return s;
            }
            else
            {
                var s = @"<tr align='center'>
    <td>
      <table width='700' border='0' cellspacing='0' cellpadding='0' bgcolor='#FFFFFF' style='border:solid 1px #DDDDDD;-moz-border-radius:5px;-webkit-border-radius:5px;border-radius:5px;'>
        <tbody><tr><td colspan='3'><table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:20px;font-size:20px;line-height:20px;'>&nbsp;</div></td></tr></tbody></table></td></tr>
        <tr>
          <td width='1%'><table width='20' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:0px;font-size:0px;line-height:0px;'>&nbsp;</div></td></tr></tbody></table></td><!-- LEFT PADDING - 1% with a min-width of 20px -->
          <td width='98%'>
            
            <table width='100%' border='0' cellspacing='0' cellpadding='0'>
              <tbody><tr>
                <td align='left' colspan='3' style='font-family: Arial; font-size: 16px; color: #333333'>Latest Blog Post</td>
              </tr>
              <tr><td colspan='3'><table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:15px;font-size:15px;line-height:15px;'>&nbsp;</div></td></tr></tbody></table></td></tr>
              <tr>
                <td width='300' style='font-family: Arial;' valign='top'>
                  
                      
                      No Blog Posts Found
                    
                </td>
                <td width='5'></td>
                <td align='left' valign='top'>
                  <table width='100%' border='0' cellspacing='0' cellpadding='0'>
                    <tbody><tr>
                      <td width='390'>
                        
                      </td>
                    </tr>
                    <tr><td colspan='2'><table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:5px;font-size:5px;line-height:5px;'>&nbsp;</div></td></tr></tbody></table></td></tr>
                
";
                
                return s;
            }
            
        }

        private static string BuildActivityFeedForNotification(Person person)
        {
            var feed = new ActivityServices().GetTeamsActivityByPerson(DateTime.Now.AddDays(-7), DateTime.Now, person);
            if (feed != null && feed.Count > 0)
            {
                var s = @"<tr align='center'>
    <td>
      <table width='700' border='0' cellspacing='0' cellpadding='0' bgcolor='#FFFFFF' style='border:solid 1px #30A9DE;-moz-border-radius:5px;-webkit-border-radius:5px;border-radius:5px;'>
        <tbody><tr><td colspan='3'><table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:20px;font-size:20px;line-height:20px;'>&nbsp;</div></td></tr></tbody></table></td></tr>
        <tr>
          <td width='1%'><table width='20' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:0px;font-size:0px;line-height:0px;'>&nbsp;</div></td></tr></tbody></table></td><!-- LEFT PADDING - 1% with a min-width of 20px -->
          <td width='98%'>
            
            <table width='100%' border='0' cellspacing='0' cellpadding='0'>
              <tbody><tr>
                <td align='left' colspan='3' style='font-family: Arial; font-size: 24px; color: #333333'>Weekly Team Activity For " + DateTime.Now.AddDays(-7).ToShortDateString() + @" to " + DateTime.Now.ToShortDateString() + @"<table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:15px;font-size:15px;line-height:15px;'>&nbsp;</div></td></tr></tbody></table></td></tr>
              <tr>
                <td width='100' valign='top'>";

                if (person.AvatarPath.StartsWith("http://"))
                {
                    s += "<a href='" + ConfigurationManager.AppSettings["BASEURL"] + "/People/" + person.Email + @"'>
                      <img src='" + person.AvatarPath + @"30' border='0' style='display: block;'>
                      </a>";
                }
                else
                {
                    s += "<a href='" + ConfigurationManager.AppSettings["BASEURL"] + "/People/" + person.Email + @"'>
                      <img src='" + ConfigurationManager.AppSettings["BASEURL"] + HRR.Core.ResourceStrings.AvatarBasePath + person.AvatarPath + @"' border='0' style='display: block; width: 30px !important; height: 30px !important;'>
                      </a>";
                }

                s += @"</td>
                <td width='10'></td>
                <td align='left' valign='top'>
                  <table width='100%' border='0' cellspacing='0' cellpadding='0'>
                    <tbody><tr>
                      <td width='390'>
                        <div style='font-family: Arial; font-size: 14px; color: #333333'>See all the goal, milestone, comment, and review activity for your teams this week!</div>
                      </td>
                    </tr>
                    <tr>
                        <td colspan='2'>
                            &nbsp;
                        </td>
                    </tr>
                
";
                foreach (var a in feed)
                {
                    s += @"<tr>
                            <td colspan='2'>
                                <table width='100%' border='0' cellspacing='10' cellpadding='0' bgcolor='#fefefe' style='border: 1px solid #ffffff;'>
                                    <tbody>
                                        <tr>
                                            <td width='30' valign='top'>";

                    if (a.PerformedByRef.AvatarPath.StartsWith("http://"))
                    {
                        s += "<a href='" + ConfigurationManager.AppSettings["BASEURL"] + "/People/" + a.PerformedByRef.Email + @"'>
                      <img src='" + a.PerformedByRef.AvatarPath + @"30' border='0' style='display: block;'>
                      </a>";
                    }
                    else
                    {
                        s += "<a href='" + ConfigurationManager.AppSettings["BASEURL"] + "/People/" + a.PerformedByRef.Email + @"'>
                      <img src='" + ConfigurationManager.AppSettings["BASEURL"] + HRR.Core.ResourceStrings.AvatarBasePath + a.PerformedByRef.AvatarPath + @"' border='0' style='display: block; width: 30px !important; height: 30px !important;'>
                      </a>";
                    }

                    s += @"</td>
                                            <td>
                                                <div style='font-family: Arial; font-size: 14px; color: #333333'>
                                "; 
                switch (a.ActivityType)
                {
                    case (int)ActivityType.COMMENT:
                        if (!string.IsNullOrEmpty(a.URL))
                        {
                            s += "entered a <a href='" + ConfigurationManager.AppSettings["BASEURL"] + a.URL + "'>comment</a> for " + a.PerformedForRef.Name + " at " + a.DateCreated.ToString();
                        }
                        else
                        {
                            s += "entered a comment for " + a.PerformedForRef.Name + " at " + a.DateCreated.ToString();
                        }
                        break;
                    case (int)ActivityType.NEW_COMMENT_RESPONSE:
                        if (!string.IsNullOrEmpty(a.URL))
                        {
                            s += "responded to a  <a href='" + ConfigurationManager.AppSettings["BASEURL"] + a.URL + "'>comment</a> for " + a.PerformedForRef.Name + " at " + a.DateCreated.ToString();
                        }
                        else
                        {
                            s += "responded to a comment for " + a.PerformedForRef.Name + " at " + a.DateCreated.ToString();
                        }
                        break;
                    case (int)ActivityType.GOAL_UPDATED:
                        if (!string.IsNullOrEmpty(a.URL))
                        {
                            s += "updated a <a href='" + ConfigurationManager.AppSettings["BASEURL"] + a.URL + "'>goal</a> for " + a.PerformedForRef.Name + " at " + a.DateCreated.ToString();
                        }
                        else
                        {
                            s += "updated a goal for " + a.PerformedForRef.Name + " at " + a.DateCreated.ToString();
                        }
                        break;
                    case (int)ActivityType.MILESTONE_UPDATED:
                        if (!string.IsNullOrEmpty(a.URL))
                        {
                            s += "updated a <a href='" + ConfigurationManager.AppSettings["BASEURL"] + a.URL + "'>goal milestone</a> for " + a.PerformedForRef.Name + " at " + a.DateCreated.ToString();
                        }
                        else
                        {
                            s += "updated a goal milestone for " + a.PerformedForRef.Name + " at " + a.DateCreated.ToString();
                        }
                        break;
                    case (int)ActivityType.NEW_GOAL:
                        if (!string.IsNullOrEmpty(a.URL))
                        {
                            s += "entered a new <a href='" + ConfigurationManager.AppSettings["BASEURL"] + a.URL + "'>goal</a> for " + a.PerformedForRef.Name + " at " + a.DateCreated.ToString();
                        }
                        else
                        {
                            s += "entered a new goal for " + a.PerformedForRef.Name + " at " + a.DateCreated.ToString();
                        }
                        break;
                    case (int)ActivityType.NEW_GOAL_COMMENT:
                        if (!string.IsNullOrEmpty(a.URL))
                        {
                            s += "entered a <a href='" + ConfigurationManager.AppSettings["BASEURL"] + a.URL + "'>goal comment</a> for " + a.PerformedForRef.Name + " at " + a.DateCreated.ToString();
                        }
                        else
                        {
                            s += "entered a goal comment for " + a.PerformedForRef.Name + " at " + a.DateCreated.ToString();
                        }
                        break;
                    case (int)ActivityType.NEW_MILESTONE:
                        if (!string.IsNullOrEmpty(a.URL))
                        {
                            s += "entered a new <a href='" + ConfigurationManager.AppSettings["BASEURL"] + a.URL + "'>goal milestone</a> for " + a.PerformedForRef.Name + " at " + a.DateCreated.ToString();
                        }
                        else
                        {
                            s += "entered a goal milestone for " + a.PerformedForRef.Name + " at " + a.DateCreated.ToString();
                        }
                        break;
                    case (int)ActivityType.NEW_REVIEW:
                        if (!string.IsNullOrEmpty(a.URL))
                        {
                            s += "entered a new <a href='" + ConfigurationManager.AppSettings["BASEURL"] + a.URL + "'>review</a> for " + a.PerformedForRef.Name + " at " + a.DateCreated.ToString();
                        }
                        else
                        {
                            s += "entered a new review for " + a.PerformedForRef.Name + " at " + a.DateCreated.ToString();
                        }
                        break;
                    case (int)ActivityType.REVIEW_UPDATED:
                        if (!string.IsNullOrEmpty(a.URL))
                        {
                            s += "updated a <a href='" + ConfigurationManager.AppSettings["BASEURL"] + a.URL + "'>review</a> for " + a.PerformedForRef.Name + " at " + a.DateCreated.ToString();
                        }
                        else
                        {
                            s += "updated a review for " + a.PerformedForRef.Name + " at " + a.DateCreated.ToString();
                        }
                        break;
                } 
                        s += @"
                              </div>
                            </td>
                          </tr>
                        </tbody></table>
                      </td>
                    </tr>
                    
";
                }
                s += @"
                        </tbody></table>
                      </td>
                    </tr><tr>
                <td width='110' colspan='2'></td>
                <td>
                  <table border='0' cellspacing='0' cellpadding='0'>
                    <tbody><tr>
                      <td>
                        <table border='0' cellpadding='6' cellspacing='1' align=''><tbody><tr><td align='center' valign='middle' bgcolor='#DEEEF5' background='http://www.linkedin.com/scds/common/u/img/bg/blue_button_back.png' style='background:url(http://www.linkedin.com/scds/common/u/img/bg/blue_button_back.png) repeat-x scroll 100% 0 #DEEEF5;background-color:#DEEEF5;border:1px solid #A3CFE4;-moz-border-radius:4px;-webkit-border-radius:4px;border-radius:4px;'><div style='padding-right:10px;padding-left:10px;'><a href='" + ConfigurationManager.AppSettings["BASEURL"] + @"/People/" + person.Email + @"' style='text-decoration:none;'><span style='font-size:12px;font-family:Arial;color:#006699;white-space:nowrap;display:block;'>View Profile</span></a></div></td></tr></tbody></table>
                      </td>
                      <td width='15'></td>
                      <td>
                        <table border='0' cellpadding='6' cellspacing='1' align=''><tbody><tr><td align='center' valign='middle' bgcolor='#EBEBEB' background='http://www.linkedin.com/scds/common/u/img/bg/gray_button_back.png' style='background:url(http://www.linkedin.com/scds/common/u/img/bg/gray_button_back.png) repeat-x scroll 100% 0 #EBEBEB;background-color:#EBEBEB;border:1px solid #CCCCCC;-moz-border-radius:4px;-webkit-border-radius:4px;border-radius:4px;'><div style='padding-right:10px;padding-left:10px;'><a href='" + ConfigurationManager.AppSettings["BASEURL"] + @"/Help/FAQ" + @"' style='text-decoration:none;'><span style='font-size:12px;font-family:Arial;color:#666666;white-space:nowrap;display:block;'>View Help</span></a></div></td></tr></tbody></table>
                      </td>
                    </tr>
                  </tbody></table>
                </td>
              </tr>
            </tbody></table>
          </td>
          <td width='1%'><table width='20' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:0px;font-size:0px;line-height:0px;'>&nbsp;</div></td></tr></tbody></table></td><!-- RIGHT PADDING - 1% with a min-width of 20px -->
        </tr>
        <tr><td colspan='3'><table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:20px;font-size:20px;line-height:20px;'>&nbsp;</div></td></tr></tbody></table></td></tr>
      </tbody></table>
    </td>
  </tr>
  
  
  
  
  <tr><td><table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:15px;font-size:15px;line-height:15px;'>&nbsp;</div></td></tr></tbody></table></td></tr>";
                return s;
            }
            else
            {
                var s = @"<tr align='center'>
    <td>
      <table width='700' border='0' cellspacing='0' cellpadding='0' bgcolor='#FFFFFF' style='border:solid 1px #DDDDDD;-moz-border-radius:5px;-webkit-border-radius:5px;border-radius:5px;'>
        <tbody><tr><td colspan='3'><table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:20px;font-size:20px;line-height:20px;'>&nbsp;</div></td></tr></tbody></table></td></tr>
        <tr>
          <td width='1%'><table width='20' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:0px;font-size:0px;line-height:0px;'>&nbsp;</div></td></tr></tbody></table></td><!-- LEFT PADDING - 1% with a min-width of 20px -->
          <td width='98%'>
            
            <table width='100%' border='0' cellspacing='0' cellpadding='0'>
              <tbody><tr>
                <td align='left' colspan='3' style='font-family: Arial; font-size: 24px; color: #333333'>Weekly Team Activity For " + DateTime.Now.AddDays(-7).ToShortDateString() + @" to " + DateTime.Now.ToShortDateString() + @"</td>
              </tr>
              <tr><td colspan='3'><table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:15px;font-size:15px;line-height:15px;'>&nbsp;</div></td></tr></tbody></table></td></tr>
              <tr>
                <td width='300' style='font-family: Arial;' valign='top'>
                  
                      
                      No Activity Found
                    
                </td>
                <td width='5'></td>
                <td align='left' valign='top'>
                  <table width='100%' border='0' cellspacing='0' cellpadding='0'>
                    <tbody><tr>
                      <td width='390'>
                        
                      </td>
                    </tr>
                    <tr><td colspan='2'><table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:5px;font-size:5px;line-height:5px;'>&nbsp;</div></td></tr></tbody></table></td></tr>

</tbody></table>
                      </td>
                    </tr><tr>
                <td width='110' colspan='2'></td>
                <td>
                  <table border='0' cellspacing='0' cellpadding='0'>
                    <tbody><tr>
                      <td>
                        <table border='0' cellpadding='6' cellspacing='1' align=''><tbody><tr><td align='center' valign='middle' bgcolor='#DEEEF5' background='http://www.linkedin.com/scds/common/u/img/bg/blue_button_back.png' style='background:url(http://www.linkedin.com/scds/common/u/img/bg/blue_button_back.png) repeat-x scroll 100% 0 #DEEEF5;background-color:#DEEEF5;border:1px solid #A3CFE4;-moz-border-radius:4px;-webkit-border-radius:4px;border-radius:4px;'><div style='padding-right:10px;padding-left:10px;'><a href='" + ConfigurationManager.AppSettings["BASEURL"] + @"/People/" + person.Email + @"' style='text-decoration:none;'><span style='font-size:12px;font-family:Arial;color:#006699;white-space:nowrap;display:block;'>View Profile</span></a></div></td></tr></tbody></table>
                      </td>
                      <td width='15'></td>
                      <td>
                        <table border='0' cellpadding='6' cellspacing='1' align=''><tbody><tr><td align='center' valign='middle' bgcolor='#EBEBEB' background='http://www.linkedin.com/scds/common/u/img/bg/gray_button_back.png' style='background:url(http://www.linkedin.com/scds/common/u/img/bg/gray_button_back.png) repeat-x scroll 100% 0 #EBEBEB;background-color:#EBEBEB;border:1px solid #CCCCCC;-moz-border-radius:4px;-webkit-border-radius:4px;border-radius:4px;'><div style='padding-right:10px;padding-left:10px;'><a href='" + ConfigurationManager.AppSettings["BASEURL"] + @"/Help/FAQ" + @"' style='text-decoration:none;'><span style='font-size:12px;font-family:Arial;color:#666666;white-space:nowrap;display:block;'>View Help</span></a></div></td></tr></tbody></table>
                      </td>
                    </tr>
                  </tbody></table>
                </td>
              </tr>
            </tbody></table>
          </td>
          <td width='1%'><table width='20' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:0px;font-size:0px;line-height:0px;'>&nbsp;</div></td></tr></tbody></table></td><!-- RIGHT PADDING - 1% with a min-width of 20px -->
        </tr>
        <tr><td colspan='3'><table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:20px;font-size:20px;line-height:20px;'>&nbsp;</div></td></tr></tbody></table></td></tr>
      </tbody></table>
    </td>
  </tr>
  
  
  
  
  <tr><td><table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:15px;font-size:15px;line-height:15px;'>&nbsp;</div></td></tr></tbody></table></td></tr>
                
";

                return s;
            }
        }

        #region Comments

        private static string BuildNewCommentNotification(Comment comment)
        {
            var s = @"<tr align='center'>
    <td>
      <table width='700' border='0' cellspacing='0' cellpadding='0' bgcolor='#FFFFFF' style='border:solid 1px #30A9DE;-moz-border-radius:5px;-webkit-border-radius:5px;border-radius:5px;'>
        <tbody><tr><td colspan='3'><table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:20px;font-size:20px;line-height:20px;'>&nbsp;</div></td></tr></tbody></table></td></tr>
  <tr>
          <td width='1%'><table width='20' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:0px;font-size:0px;line-height:0px;'>&nbsp;</div></td></tr></tbody></table></td><!-- LEFT PADDING - 1% with a min-width of 20px -->
          <td width='98%'>
            
            <table width='100%' border='0' cellspacing='0' cellpadding='0'>
              <tbody><tr align='left' valign='top'>
                <td colspan='3' style='font-family: Arial; font-size: 18px; color: #333333'>
                  " + comment.EnteredByRef.Name + @" Has Entered A Comment For You
                  <table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:15px;font-size:15px;line-height:15px;'>&nbsp;</div></td></tr></tbody></table>
                </td>
  </tr>
  <tr>
                
                <td valign='top' width='100'>";

            if (comment.EnteredByRef.AvatarPath.StartsWith("http://"))
            {
                s += "<a href='" + ConfigurationManager.AppSettings["BASEURL"] + "/People/" + comment.EnteredByRef.Email + @"'>
                      <img src='" + comment.EnteredByRef.AvatarPath + @"50' border='0' style='display: block;'>
                      </a>";
            }
            else
            {
                s += "<a href='" + ConfigurationManager.AppSettings["BASEURL"] + "/People/" + comment.EnteredByRef.Email + @"'>
                      <img src='" + ConfigurationManager.AppSettings["BASEURL"] + HRR.Core.ResourceStrings.AvatarBasePath + comment.EnteredByRef.AvatarPath + @"' width='50' height='50' border='0' style='display: block; width: 50px !important; height: 50px !important;' >
                      </a>";
            }

            s += @"</td>
                
                <td width='10'></td>
                <td align='left' valign='top' style='font-family: Arial; font-size: 12px; color: #333333;'>
                  
                      Looks like you're doing things and getting noticed! 
                      <table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:5px;font-size:5px;line-height:5px;'>&nbsp;</div></td></tr></tbody></table>
                      <ul style='margin: 0; padding-left: 15px;'>
                        <li>This comment was entered under the category<span style='color: #ff6600;'> " + comment.Category.Name + @"</span></li>
                        <li>For the team <span style='color: #ff6600;'> " + comment.TeamRef.Name + @"</span></li>
      </ul>
                    
                  <table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:15px;font-size:15px;line-height:15px;'>&nbsp;</div></td></tr></tbody></table>
                </td>
              </tr>
              <tr>
                <td width='110' colspan='2'></td>
                <td>
                  <table border='0' cellspacing='0' cellpadding='0'>
                    <tbody><tr>
                      <td>
                        <table border='0' cellpadding='6' cellspacing='1' align=''><tbody><tr><td align='center' valign='middle' bgcolor='#DEEEF5' background='http://www.linkedin.com/scds/common/u/img/bg/blue_button_back.png' style='background:url(http://www.linkedin.com/scds/common/u/img/bg/blue_button_back.png) repeat-x scroll 100% 0 #DEEEF5;background-color:#DEEEF5;border:1px solid #A3CFE4;-moz-border-radius:4px;-webkit-border-radius:4px;border-radius:4px;'><div style='padding-right:10px;padding-left:10px;'><a href='" + ConfigurationManager.AppSettings["BASEURL"] + @"/Comments/" + comment.ID.ToString() + @"' style='text-decoration:none;'><span style='font-size:12px;font-family:Arial;color:#006699;white-space:nowrap;display:block;'>View Comment</span></a></div></td></tr></tbody></table>
                      </td>
                      <td width='15'></td>
                      <td>
                        <table border='0' cellpadding='6' cellspacing='1' align=''><tbody><tr><td align='center' valign='middle' bgcolor='#EBEBEB' background='http://www.linkedin.com/scds/common/u/img/bg/gray_button_back.png' style='background:url(http://www.linkedin.com/scds/common/u/img/bg/gray_button_back.png) repeat-x scroll 100% 0 #EBEBEB;background-color:#EBEBEB;border:1px solid #CCCCCC;-moz-border-radius:4px;-webkit-border-radius:4px;border-radius:4px;'><div style='padding-right:10px;padding-left:10px;'><a href='" + ConfigurationManager.AppSettings["BASEURL"] + @"/People/" + comment.EnteredForRef.Email + @"' style='text-decoration:none;'><span style='font-size:12px;font-family:Arial;color:#666666;white-space:nowrap;display:block;'>View Profile</span></a></div></td></tr></tbody></table>
                      </td>
                      <td width='15'></td>
                      <td>
                        <table border='0' cellpadding='6' cellspacing='1' align=''><tbody><tr><td align='center' valign='middle' bgcolor='#EBEBEB' background='http://www.linkedin.com/scds/common/u/img/bg/gray_button_back.png' style='background:url(http://www.linkedin.com/scds/common/u/img/bg/gray_button_back.png) repeat-x scroll 100% 0 #EBEBEB;background-color:#EBEBEB;border:1px solid #CCCCCC;-moz-border-radius:4px;-webkit-border-radius:4px;border-radius:4px;'><div style='padding-right:10px;padding-left:10px;'><a href='" + ConfigurationManager.AppSettings["BASEURL"] + @"/Help/FAQ" + @"' style='text-decoration:none;'><span style='font-size:12px;font-family:Arial;color:#666666;white-space:nowrap;display:block;'>View Help</span></a></div></td></tr></tbody></table>
                      </td>
                    </tr>
                  </tbody></table>
                </td>
              </tr>
            </tbody></table>
          </td>
          <td width='1%'><table width='20' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:0px;font-size:0px;line-height:0px;'>&nbsp;</div></td></tr></tbody></table></td><!-- RIGHT PADDING - 1% with a min-width of 20px -->
        </tr>
        <tr><td colspan='3'><table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:20px;font-size:20px;line-height:20px;'>&nbsp;</div></td></tr></tbody></table></td></tr>
      </tbody></table>
    </td>
  </tr>
  
  
  
  
  <tr><td><table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:15px;font-size:15px;line-height:15px;'>&nbsp;</div></td></tr></tbody></table></td></tr>";

            return s;
        }

        public static void SendNewCommentNotification(Comment comment)
        {
            if (comment.EnteredForRef.ReceiveCommentNotifications)
            {
                var sb = new StringBuilder();
                sb.Append(EmailHTMLStart());
                sb.Append(BuildNewCommentNotification(comment));
                sb.Append(BuildBlogForNotification());
                sb.Append(EmailHTMLEnd());
                try
                {
                    IdeaSeed.Core.Mail.EmailUtils.SendEmail(comment.EnteredForRef.Email, "noreply@hrriver.com", "", ConfigurationManager.AppSettings["NEWCOMMENTNOTIFICATION"], "New Comment", sb.ToString(), false, "");
                }
                catch (Exception exc)
                {
                    SecurityContextManager.Current.LogEvent(SecurityContextManager
                        .Current
                        .CurrentUser
                        .ID, DateTime.Now, (int)ApplicationLogTypes.EMAIL_SUCCESS, SecurityContextManager.Current.CurrentAccount.ID, "<b>Sending New Comment Notification Failed</b><br /><br /><b>Message:</b><br /><span" + exc.Message + "</span><br /><br /><b>Stack:</b><br /><span>" + exc.StackTrace + "</span>", "", "");
                }
            }
        }

        private static string BuildCommentResponseNotification(CommentResponse response)
        {
            
            var s = @"<tr align='center'>
    <td>
      <table width='700' border='0' cellspacing='0' cellpadding='0' bgcolor='#FFFFFF' style='border:solid 1px #30A9DE;-moz-border-radius:5px;-webkit-border-radius:5px;border-radius:5px;'>
        <tbody><tr><td colspan='3'><table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:20px;font-size:20px;line-height:20px;'>&nbsp;</div></td></tr></tbody></table></td></tr>
  <tr>
          <td width='1%'><table width='20' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:0px;font-size:0px;line-height:0px;'>&nbsp;</div></td></tr></tbody></table></td><!-- LEFT PADDING - 1% with a min-width of 20px -->
          <td width='98%'>
            
            <table width='100%' border='0' cellspacing='0' cellpadding='0'>
              <tbody><tr align='left' valign='top'>
                <td colspan='3' style='font-family: Arial; font-size: 18px; color: #333333'>
                  " + response.EnteredByRef.Name + @" Has Posted A Response To Your Comment
                  <table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:15px;font-size:15px;line-height:15px;'>&nbsp;</div></td></tr></tbody></table>
                </td>
  </tr>
  <tr>
                
                <td valign='top' width='100'>";

            if (response.EnteredByRef.AvatarPath.StartsWith("http://"))
            {
                s += "<a href='" + ConfigurationManager.AppSettings["BASEURL"] + "/People/" + response.EnteredByRef.Email + @"'>
                      <img src='" + response.EnteredByRef.AvatarPath + @"50' border='0' style='display: block;'>
                      </a>";
            }
            else
            {
                s += "<a href='" + ConfigurationManager.AppSettings["BASEURL"] + "/People/" + response.EnteredByRef.Email + @"'>
                      <img src='" + ConfigurationManager.AppSettings["BASEURL"] + HRR.Core.ResourceStrings.AvatarBasePath + response.EnteredByRef.AvatarPath + @"' width='50' height='50' border='0' style='display: block; width: 50px !important; height: 50px !important;'>
                      </a>";
            }

            s += @"</td>
                
                <td width='10'></td>
                <td align='left' valign='top' style='font-family: Arial; font-size: 12px; color: #333333;'>
                  
                      Login and see what the buzz is all about!! 
                      <table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:5px;font-size:5px;line-height:5px;'>&nbsp;</div></td></tr></tbody></table>
                      
                    
                  <table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:15px;font-size:15px;line-height:15px;'>&nbsp;</div></td></tr></tbody></table>
                </td>
              </tr>
              <tr>
                <td width='110' colspan='2'></td>
                <td>
                  <table border='0' cellspacing='0' cellpadding='0'>
                    <tbody><tr>
                      <td>
                        <table border='0' cellpadding='6' cellspacing='1' align=''><tbody><tr><td align='center' valign='middle' bgcolor='#DEEEF5' background='http://www.linkedin.com/scds/common/u/img/bg/blue_button_back.png' style='background:url(http://www.linkedin.com/scds/common/u/img/bg/blue_button_back.png) repeat-x scroll 100% 0 #DEEEF5;background-color:#DEEEF5;border:1px solid #A3CFE4;-moz-border-radius:4px;-webkit-border-radius:4px;border-radius:4px;'><div style='padding-right:10px;padding-left:10px;'><a href='" + ConfigurationManager.AppSettings["BASEURL"] + @"/Comments/" + response.CommentRef.ID.ToString() + @"' style='text-decoration:none;'><span style='font-size:12px;font-family:Arial;color:#006699;white-space:nowrap;display:block;'>View Comment</span></a></div></td></tr></tbody></table>
                      </td>
                      <td width='15'></td>
                      <td>
                        <table border='0' cellpadding='6' cellspacing='1' align=''><tbody><tr><td align='center' valign='middle' bgcolor='#EBEBEB' background='http://www.linkedin.com/scds/common/u/img/bg/gray_button_back.png' style='background:url(http://www.linkedin.com/scds/common/u/img/bg/gray_button_back.png) repeat-x scroll 100% 0 #EBEBEB;background-color:#EBEBEB;border:1px solid #CCCCCC;-moz-border-radius:4px;-webkit-border-radius:4px;border-radius:4px;'><div style='padding-right:10px;padding-left:10px;'><a href='" + ConfigurationManager.AppSettings["BASEURL"] + @"/People/" + response.EnteredByRef.Email + @"' style='text-decoration:none;'><span style='font-size:12px;font-family:Arial;color:#666666;white-space:nowrap;display:block;'>View Profile</span></a></div></td></tr></tbody></table>
                      </td>
                      <td width='15'></td>
                      <td>
                        <table border='0' cellpadding='6' cellspacing='1' align=''><tbody><tr><td align='center' valign='middle' bgcolor='#EBEBEB' background='http://www.linkedin.com/scds/common/u/img/bg/gray_button_back.png' style='background:url(http://www.linkedin.com/scds/common/u/img/bg/gray_button_back.png) repeat-x scroll 100% 0 #EBEBEB;background-color:#EBEBEB;border:1px solid #CCCCCC;-moz-border-radius:4px;-webkit-border-radius:4px;border-radius:4px;'><div style='padding-right:10px;padding-left:10px;'><a href='" + ConfigurationManager.AppSettings["BASEURL"] + @"/Help/FAQ" + @"' style='text-decoration:none;'><span style='font-size:12px;font-family:Arial;color:#666666;white-space:nowrap;display:block;'>View Help</span></a></div></td></tr></tbody></table>
                      </td>
                    </tr>
                  </tbody></table>
                </td>
              </tr>
            </tbody></table>
          </td>
          <td width='1%'><table width='20' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:0px;font-size:0px;line-height:0px;'>&nbsp;</div></td></tr></tbody></table></td><!-- RIGHT PADDING - 1% with a min-width of 20px -->
        </tr>
        <tr><td colspan='3'><table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:20px;font-size:20px;line-height:20px;'>&nbsp;</div></td></tr></tbody></table></td></tr>
      </tbody></table>
    </td>
  </tr>
  
  
  
  
  <tr><td><table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:15px;font-size:15px;line-height:15px;'>&nbsp;</div></td></tr></tbody></table></td></tr>";

            return s;
        }

        public static void SendCommentResponseNotification(CommentResponse response, string emails)
        {
            var nr = IdeaSeed.Core.Data.NHibernate.NHibernateSessionManager.Instance.ReGet<CommentResponse>(response);
            var sb = new StringBuilder();
            sb.Append(EmailHTMLStart());
            sb.Append(BuildCommentResponseNotification(nr));
            sb.Append(BuildBlogForNotification());
            sb.Append(EmailHTMLEnd());
            try
            {
                IdeaSeed.Core.Mail.EmailUtils.SendEmail(nr.CommentRef.EnteredForRef.Email, "noreply@hrriver.com", "", emails + ConfigurationManager.AppSettings["NEWCOMMENTNOTIFICATION"], "New Comment Response", sb.ToString(), false, "");
            }
            catch (Exception exc)
            {
                SecurityContextManager.Current.LogEvent(SecurityContextManager
                    .Current
                    .CurrentUser
                    .ID, DateTime.Now, (int)ApplicationLogTypes.EMAIL_SUCCESS, SecurityContextManager.Current.CurrentAccount.ID, "<b>Sending New Comment Notification Failed</b><br /><br /><b>Message:</b><br /><span" + exc.Message + "</span><br /><br /><b>Stack:</b><br /><span>" + exc.StackTrace + "</span>", "", "");
            }
        }

        private static string BuildFlaggedCommentNotification(Comment comment)
        {

            var s = @"<tr align='center'>
    <td>
      <table width='700' border='0' cellspacing='0' cellpadding='0' bgcolor='#FFFFFF' style='border:solid 1px #30A9DE;-moz-border-radius:5px;-webkit-border-radius:5px;border-radius:5px;'>
        <tbody><tr><td colspan='3'><table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:20px;font-size:20px;line-height:20px;'>&nbsp;</div></td></tr></tbody></table></td></tr>
  <tr>
          <td width='1%'><table width='20' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:0px;font-size:0px;line-height:0px;'>&nbsp;</div></td></tr></tbody></table></td><!-- LEFT PADDING - 1% with a min-width of 20px -->
          <td width='98%'>
            
            <table width='100%' border='0' cellspacing='0' cellpadding='0'>
              <tbody><tr align='left' valign='top'>
                <td colspan='3' style='font-family: Arial; font-size: 18px; color: #333333'>
                  " + SecurityContextManager.Current.CurrentUser.Name + @" Has Flagged A Comment As Inappropriate
                  <table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:15px;font-size:15px;line-height:15px;'>&nbsp;</div></td></tr></tbody></table>
                </td>
  </tr>
  <tr>
                
                <td valign='top' width='100'>";

            if (((Person)SecurityContextManager.Current.CurrentUser).AvatarPath.StartsWith("http://"))
            {
                s += "<a href='" + ConfigurationManager.AppSettings["BASEURL"] + "/People/" + ((Person)SecurityContextManager.Current.CurrentUser).Email + @"'>
                      <img src='" + ((Person)SecurityContextManager.Current.CurrentUser).AvatarPath + @"30' border='0' style='display: block;'>
                      </a>";
            }
            else
            {
                s += "<a href='" + ConfigurationManager.AppSettings["BASEURL"] + "/People/" + ((Person)SecurityContextManager.Current.CurrentUser).Email + @"'>
                      <img src='" + ConfigurationManager.AppSettings["BASEURL"] + HRR.Core.ResourceStrings.AvatarBasePath + ((Person)SecurityContextManager.Current.CurrentUser).AvatarPath + @"' width='50' height='50' border='0' style='display: block; width: 30px !important; height: 30px !important;'>
                      </a>";
            }

            s += @"</td>
                
                <td width='10'></td>
                <td align='left' valign='top' style='font-family: Arial; font-size: 12px; color: #333333;'>
                  
                      Honest disagreement is often a good sign of progress. 
                      <table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:5px;font-size:5px;line-height:5px;'>&nbsp;</div></td></tr></tbody></table>
                      
                    
                  <table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:15px;font-size:15px;line-height:15px;'>&nbsp;</div></td></tr></tbody></table>
                </td>
              </tr>
              <tr>
                <td width='110' colspan='2'></td>
                <td>
                  <table border='0' cellspacing='0' cellpadding='0'>
                    <tbody><tr>
                      <td>
                        <table border='0' cellpadding='6' cellspacing='1' align=''><tbody><tr><td align='center' valign='middle' bgcolor='#DEEEF5' background='http://www.linkedin.com/scds/common/u/img/bg/blue_button_back.png' style='background:url(http://www.linkedin.com/scds/common/u/img/bg/blue_button_back.png) repeat-x scroll 100% 0 #DEEEF5;background-color:#DEEEF5;border:1px solid #A3CFE4;-moz-border-radius:4px;-webkit-border-radius:4px;border-radius:4px;'><div style='padding-right:10px;padding-left:10px;'><a href='" + ConfigurationManager.AppSettings["BASEURL"] + @"/Comments/" + comment.ID.ToString() + @"' style='text-decoration:none;'><span style='font-size:12px;font-family:Arial;color:#006699;white-space:nowrap;display:block;'>View Comment</span></a></div></td></tr></tbody></table>
                      </td>
                      <td width='15'></td>
                      <td>
                        <table border='0' cellpadding='6' cellspacing='1' align=''><tbody><tr><td align='center' valign='middle' bgcolor='#EBEBEB' background='http://www.linkedin.com/scds/common/u/img/bg/gray_button_back.png' style='background:url(http://www.linkedin.com/scds/common/u/img/bg/gray_button_back.png) repeat-x scroll 100% 0 #EBEBEB;background-color:#EBEBEB;border:1px solid #CCCCCC;-moz-border-radius:4px;-webkit-border-radius:4px;border-radius:4px;'><div style='padding-right:10px;padding-left:10px;'><a href='" + ConfigurationManager.AppSettings["BASEURL"] + @"/People/" + ((Person)SecurityContextManager.Current.CurrentUser).Email + @"' style='text-decoration:none;'><span style='font-size:12px;font-family:Arial;color:#666666;white-space:nowrap;display:block;'>View Profile</span></a></div></td></tr></tbody></table>
                      </td>
                      <td width='15'></td>
                      <td>
                        <table border='0' cellpadding='6' cellspacing='1' align=''><tbody><tr><td align='center' valign='middle' bgcolor='#EBEBEB' background='http://www.linkedin.com/scds/common/u/img/bg/gray_button_back.png' style='background:url(http://www.linkedin.com/scds/common/u/img/bg/gray_button_back.png) repeat-x scroll 100% 0 #EBEBEB;background-color:#EBEBEB;border:1px solid #CCCCCC;-moz-border-radius:4px;-webkit-border-radius:4px;border-radius:4px;'><div style='padding-right:10px;padding-left:10px;'><a href='" + ConfigurationManager.AppSettings["BASEURL"] + @"/Help/FAQ" + @"' style='text-decoration:none;'><span style='font-size:12px;font-family:Arial;color:#666666;white-space:nowrap;display:block;'>View Help</span></a></div></td></tr></tbody></table>
                      </td>
                    </tr>
                  </tbody></table>
                </td>
              </tr>
            </tbody></table>
          </td>
          <td width='1%'><table width='20' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:0px;font-size:0px;line-height:0px;'>&nbsp;</div></td></tr></tbody></table></td><!-- RIGHT PADDING - 1% with a min-width of 20px -->
        </tr>
        <tr><td colspan='3'><table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:20px;font-size:20px;line-height:20px;'>&nbsp;</div></td></tr></tbody></table></td></tr>
      </tbody></table>
    </td>
  </tr>
  
  
  
  
  <tr><td><table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:15px;font-size:15px;line-height:15px;'>&nbsp;</div></td></tr></tbody></table></td></tr>";

            return s;
        }

        public static void SendFlaggedCommentNotification(Comment comment, string emails)
        {
            var nr = IdeaSeed.Core.Data.NHibernate.NHibernateSessionManager.Instance.ReGet<Comment>(comment);
            var sb = new StringBuilder();
            sb.Append(EmailHTMLStart());
            sb.Append(BuildFlaggedCommentNotification(nr));
            sb.Append(BuildBlogForNotification());
            sb.Append(EmailHTMLEnd());
            try
            {

                IdeaSeed.Core.Mail.EmailUtils.SendEmail(emails, "noreply@hrriver.com", "", ConfigurationManager.AppSettings["NEWCOMMENTNOTIFICATION"], "A Comment Has Been Flagged As Inappropriate", sb.ToString(), false, "");
            }
            catch (Exception exc)
            {
                SecurityContextManager.Current.LogEvent(SecurityContextManager
                    .Current
                    .CurrentUser
                    .ID, DateTime.Now, (int)ApplicationLogTypes.EMAIL_SUCCESS, SecurityContextManager.Current.CurrentAccount.ID, "<b>Sending Flagged Comment Notification Failed</b><br /><br /><b>Message:</b><br /><span" + exc.Message + "</span><br /><br /><b>Stack:</b><br /><span>" + exc.StackTrace + "</span>", "", "");
            }
        }
        #endregion

        #region Goals & Milestones

        private static string BuildNewGoalNotification(Goal goal)
        {
            var s = @"<tr align='center'>
    <td>
      <table width='700' border='0' cellspacing='0' cellpadding='0' bgcolor='#FFFFFF' style='border:solid 1px #30A9DE;-moz-border-radius:5px;-webkit-border-radius:5px;border-radius:5px;'>
        <tbody><tr><td colspan='3'><table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:20px;font-size:20px;line-height:20px;'>&nbsp;</div></td></tr></tbody></table></td></tr>
  <tr>
          <td width='1%'><table width='20' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:0px;font-size:0px;line-height:0px;'>&nbsp;</div></td></tr></tbody></table></td><!-- LEFT PADDING - 1% with a min-width of 20px -->
          <td width='98%'>
            
            <table width='100%' border='0' cellspacing='0' cellpadding='0'>
              <tbody><tr align='left' valign='top'>
                <td colspan='3' style='font-family: Arial; font-size: 18px; color: #333333'>
                  " + goal.EnteredByRef.Name + @" Has Entered A Goal For You
                  <table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:15px;font-size:15px;line-height:15px;'>&nbsp;</div></td></tr></tbody></table>
                </td>
  </tr>
  <tr>
                
                <td valign='top' width='100'>";

            if (goal.EnteredByRef.AvatarPath.StartsWith("http://"))
            {
                s += "<a href='" + ConfigurationManager.AppSettings["BASEURL"] + "/People/" + goal.EnteredByRef.Email + @"'>
                      <img src='" + goal.EnteredByRef.AvatarPath + @"50' border='0' style='display: block;'>
                      </a>";
            }
            else
            {
                s += "<a href='" + ConfigurationManager.AppSettings["BASEURL"] + "/People/" + goal.EnteredByRef.Email + @"'>
                      <img src='" + ConfigurationManager.AppSettings["BASEURL"] + HRR.Core.ResourceStrings.AvatarBasePath + goal.EnteredByRef.AvatarPath + @"' width='50' height='50' border='0' style='display: block; width: 50px !important; height: 50px !important;'>
                      </a>";
            }

            s += @"</td>
                
                <td width='10'></td>
                <td align='left' valign='top' style='font-family: Arial; font-size: 12px; color: #333333;'>
                  
                      A good goal is like a strenuous exercise - it makes you stretch! 
                      <table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:5px;font-size:5px;line-height:5px;'>&nbsp;</div></td></tr></tbody></table>
                      <ul style='margin: 0; padding-left: 15px;'>
                        <li><span style='color: #ff6600;'> Title: </span>" + goal.Title + @"</li>
                        <li><span style='color: #ff6600;'>Due Date: </span>" + goal.DueDate.ToShortDateString() + @"</li>
      </ul>
                    
                  <table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:15px;font-size:15px;line-height:15px;'>&nbsp;</div></td></tr></tbody></table>
                </td>
              </tr>
              <tr>
                <td width='110' colspan='2'></td>
                <td>
                  <table border='0' cellspacing='0' cellpadding='0'>
                    <tbody><tr>
                      <td>
                        <table border='0' cellpadding='6' cellspacing='1' align=''><tbody><tr><td align='center' valign='middle' bgcolor='#DEEEF5' background='http://www.linkedin.com/scds/common/u/img/bg/blue_button_back.png' style='background:url(http://www.linkedin.com/scds/common/u/img/bg/blue_button_back.png) repeat-x scroll 100% 0 #DEEEF5;background-color:#DEEEF5;border:1px solid #A3CFE4;-moz-border-radius:4px;-webkit-border-radius:4px;border-radius:4px;'><div style='padding-right:10px;padding-left:10px;'><a href='" + ConfigurationManager.AppSettings["BASEURL"] + @"/Goals/" + goal.ID.ToString() + @"' style='text-decoration:none;'><span style='font-size:12px;font-family:Arial;color:#006699;white-space:nowrap;display:block;'>View Goal</span></a></div></td></tr></tbody></table>
                      </td>
                      <td width='15'></td>
                      <td>
                        <table border='0' cellpadding='6' cellspacing='1' align=''><tbody><tr><td align='center' valign='middle' bgcolor='#EBEBEB' background='http://www.linkedin.com/scds/common/u/img/bg/gray_button_back.png' style='background:url(http://www.linkedin.com/scds/common/u/img/bg/gray_button_back.png) repeat-x scroll 100% 0 #EBEBEB;background-color:#EBEBEB;border:1px solid #CCCCCC;-moz-border-radius:4px;-webkit-border-radius:4px;border-radius:4px;'><div style='padding-right:10px;padding-left:10px;'><a href='" + ConfigurationManager.AppSettings["BASEURL"] + @"/People/" + goal.EnteredForRef.Email + @"' style='text-decoration:none;'><span style='font-size:12px;font-family:Arial;color:#666666;white-space:nowrap;display:block;'>View Profile</span></a></div></td></tr></tbody></table>
                      </td>
                      <td width='15'></td>
                      <td>
                        <table border='0' cellpadding='6' cellspacing='1' align=''><tbody><tr><td align='center' valign='middle' bgcolor='#EBEBEB' background='http://www.linkedin.com/scds/common/u/img/bg/gray_button_back.png' style='background:url(http://www.linkedin.com/scds/common/u/img/bg/gray_button_back.png) repeat-x scroll 100% 0 #EBEBEB;background-color:#EBEBEB;border:1px solid #CCCCCC;-moz-border-radius:4px;-webkit-border-radius:4px;border-radius:4px;'><div style='padding-right:10px;padding-left:10px;'><a href='" + ConfigurationManager.AppSettings["BASEURL"] + @"/Help/FAQ" + @"' style='text-decoration:none;'><span style='font-size:12px;font-family:Arial;color:#666666;white-space:nowrap;display:block;'>View Help</span></a></div></td></tr></tbody></table>
                      </td>
                    </tr>
                  </tbody></table>
                </td>
              </tr>
            </tbody></table>
          </td>
          <td width='1%'><table width='20' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:0px;font-size:0px;line-height:0px;'>&nbsp;</div></td></tr></tbody></table></td><!-- RIGHT PADDING - 1% with a min-width of 20px -->
        </tr>
        <tr><td colspan='3'><table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:20px;font-size:20px;line-height:20px;'>&nbsp;</div></td></tr></tbody></table></td></tr>
      </tbody></table>
    </td>
  </tr>
  
  
  
  
  <tr><td><table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:15px;font-size:15px;line-height:15px;'>&nbsp;</div></td></tr></tbody></table></td></tr>";

            return s;
        }

        public static void SendNewGoalNotification(Goal goal, string emails)
        {
            var nr = IdeaSeed.Core.Data.NHibernate.NHibernateSessionManager.Instance.ReGet<Goal>(goal);
            var sb = new StringBuilder();
            sb.Append(EmailHTMLStart());
            sb.Append(BuildNewGoalNotification(nr));
            sb.Append(BuildBlogForNotification());
            sb.Append(EmailHTMLEnd());
            try
            {
                IdeaSeed.Core.Mail.EmailUtils.SendEmail(nr.EnteredForRef.Email, "noreply@hrriver.com", "", emails + ConfigurationManager.AppSettings["NEWCOMMENTNOTIFICATION"], "New Goal", sb.ToString(), false, "");
            }
            catch (Exception exc)
            {
                SecurityContextManager.Current.LogEvent(SecurityContextManager
                    .Current
                    .CurrentUser
                    .ID, DateTime.Now, (int)ApplicationLogTypes.EMAIL_SUCCESS, SecurityContextManager.Current.CurrentAccount.ID, "<b>Sending New Goal Notification Failed</b><br /><br /><b>Message:</b><br /><span" + exc.Message + "</span><br /><br /><b>Stack:</b><br /><span>" + exc.StackTrace + "</span>", "", "");
            }
        }


        private static string BuildGoalUpdateNotification(Goal goal)
        {
            var s = @"<tr align='center'>
    <td>
      <table width='700' border='0' cellspacing='0' cellpadding='0' bgcolor='#FFFFFF' style='border:solid 1px #30A9DE;-moz-border-radius:5px;-webkit-border-radius:5px;border-radius:5px;'>
        <tbody><tr><td colspan='3'><table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:20px;font-size:20px;line-height:20px;'>&nbsp;</div></td></tr></tbody></table></td></tr>
  <tr>
          <td width='1%'><table width='20' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:0px;font-size:0px;line-height:0px;'>&nbsp;</div></td></tr></tbody></table></td><!-- LEFT PADDING - 1% with a min-width of 20px -->
          <td width='98%'>
            
            <table width='100%' border='0' cellspacing='0' cellpadding='0'>
              <tbody><tr align='left' valign='top'>
                <td colspan='3' style='font-family: Arial; font-size: 18px; color: #333333'>
                  " + goal.EnteredByRef.Name + @" Has Updated Your Goal
                  <table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:15px;font-size:15px;line-height:15px;'>&nbsp;</div></td></tr></tbody></table>
                </td>
  </tr>
  <tr>
                
                <td valign='top' width='100'>";

            if (goal.EnteredByRef.AvatarPath.StartsWith("http://"))
            {
                s += "<a href='" + ConfigurationManager.AppSettings["BASEURL"] + "/People/" + goal.EnteredByRef.Email + @"'>
                      <img src='" + goal.EnteredByRef.AvatarPath + @"50' border='0' style='display: block;'>
                      </a>";
            }
            else
            {
                s += "<a href='" + ConfigurationManager.AppSettings["BASEURL"] + "/People/" + goal.EnteredByRef.Email + @"'>
                      <img src='" + ConfigurationManager.AppSettings["BASEURL"] + HRR.Core.ResourceStrings.AvatarBasePath + goal.EnteredByRef.AvatarPath + @"' width='50' height='50' border='0' style='display: block; width: 50px !important; height: 50px !important;'>
                      </a>";
            }

            s += @"</td>
                
                <td width='10'></td>
                <td align='left' valign='top' style='font-family: Arial; font-size: 12px; color: #333333;'>
                  
                      A good goal is like a strenuous exercise - it makes you stretch! 
                      <table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:5px;font-size:5px;line-height:5px;'>&nbsp;</div></td></tr></tbody></table>
                      <ul style='margin: 0; padding-left: 15px;'>
                        <li><span style='color: #ff6600;'> Title: </span>" + goal.Title + @"</li>
                        <li><span style='color: #ff6600;'>Due Date: </span>" + goal.DueDate.ToShortDateString() + @"</li>
      </ul>
                    
                  <table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:15px;font-size:15px;line-height:15px;'>&nbsp;</div></td></tr></tbody></table>
                </td>
              </tr>
              <tr>
                <td width='110' colspan='2'></td>
                <td>
                  <table border='0' cellspacing='0' cellpadding='0'>
                    <tbody><tr>
                      <td>
                        <table border='0' cellpadding='6' cellspacing='1' align=''><tbody><tr><td align='center' valign='middle' bgcolor='#DEEEF5' background='http://www.linkedin.com/scds/common/u/img/bg/blue_button_back.png' style='background:url(http://www.linkedin.com/scds/common/u/img/bg/blue_button_back.png) repeat-x scroll 100% 0 #DEEEF5;background-color:#DEEEF5;border:1px solid #A3CFE4;-moz-border-radius:4px;-webkit-border-radius:4px;border-radius:4px;'><div style='padding-right:10px;padding-left:10px;'><a href='" + ConfigurationManager.AppSettings["BASEURL"] + @"/Goals/" + goal.ID.ToString() + @"' style='text-decoration:none;'><span style='font-size:12px;font-family:Arial;color:#006699;white-space:nowrap;display:block;'>View Goal</span></a></div></td></tr></tbody></table>
                      </td>
                      <td width='15'></td>
                      <td>
                        <table border='0' cellpadding='6' cellspacing='1' align=''><tbody><tr><td align='center' valign='middle' bgcolor='#EBEBEB' background='http://www.linkedin.com/scds/common/u/img/bg/gray_button_back.png' style='background:url(http://www.linkedin.com/scds/common/u/img/bg/gray_button_back.png) repeat-x scroll 100% 0 #EBEBEB;background-color:#EBEBEB;border:1px solid #CCCCCC;-moz-border-radius:4px;-webkit-border-radius:4px;border-radius:4px;'><div style='padding-right:10px;padding-left:10px;'><a href='" + ConfigurationManager.AppSettings["BASEURL"] + @"/People/" + goal.EnteredForRef.Email + @"' style='text-decoration:none;'><span style='font-size:12px;font-family:Arial;color:#666666;white-space:nowrap;display:block;'>View Profile</span></a></div></td></tr></tbody></table>
                      </td>
                      <td width='15'></td>
                      <td>
                        <table border='0' cellpadding='6' cellspacing='1' align=''><tbody><tr><td align='center' valign='middle' bgcolor='#EBEBEB' background='http://www.linkedin.com/scds/common/u/img/bg/gray_button_back.png' style='background:url(http://www.linkedin.com/scds/common/u/img/bg/gray_button_back.png) repeat-x scroll 100% 0 #EBEBEB;background-color:#EBEBEB;border:1px solid #CCCCCC;-moz-border-radius:4px;-webkit-border-radius:4px;border-radius:4px;'><div style='padding-right:10px;padding-left:10px;'><a href='" + ConfigurationManager.AppSettings["BASEURL"] + @"/Help/FAQ" + @"' style='text-decoration:none;'><span style='font-size:12px;font-family:Arial;color:#666666;white-space:nowrap;display:block;'>View Help</span></a></div></td></tr></tbody></table>
                      </td>
                    </tr>
                  </tbody></table>
                </td>
              </tr>
            </tbody></table>
          </td>
          <td width='1%'><table width='20' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:0px;font-size:0px;line-height:0px;'>&nbsp;</div></td></tr></tbody></table></td><!-- RIGHT PADDING - 1% with a min-width of 20px -->
        </tr>
        <tr><td colspan='3'><table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:20px;font-size:20px;line-height:20px;'>&nbsp;</div></td></tr></tbody></table></td></tr>
      </tbody></table>
    </td>
  </tr>
  
  
  
  
  <tr><td><table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:15px;font-size:15px;line-height:15px;'>&nbsp;</div></td></tr></tbody></table></td></tr>";

            return s;
        }

        public static void SendGoalUpdateNotification(Goal goal, string emails)
        {
            var nr = IdeaSeed.Core.Data.NHibernate.NHibernateSessionManager.Instance.ReGet<Goal>(goal);
            var sb = new StringBuilder();
            sb.Append(EmailHTMLStart());
            sb.Append(BuildGoalUpdateNotification(nr));
            sb.Append(BuildBlogForNotification());
            sb.Append(EmailHTMLEnd());
            try
            {
                IdeaSeed.Core.Mail.EmailUtils.SendEmail(nr.EnteredForRef.Email, "noreply@hrriver.com", "", emails + ConfigurationManager.AppSettings["NEWCOMMENTNOTIFICATION"], "Goal Update", sb.ToString(), false, "");
            }
            catch (Exception exc)
            {
                SecurityContextManager.Current.LogEvent(SecurityContextManager
                    .Current
                    .CurrentUser
                    .ID, DateTime.Now, (int)ApplicationLogTypes.EMAIL_SUCCESS, SecurityContextManager.Current.CurrentAccount.ID, "<b>Sending Goal Update Notification Failed</b><br /><br /><b>Message:</b><br /><span" + exc.Message + "</span><br /><br /><b>Stack:</b><br /><span>" + exc.StackTrace + "</span>", "", "");
            }
        }

        private static string BuildReviewNotification(Review review)
        {
            var s = @"<tr align='center'>
    <td>
      <table width='700' border='0' cellspacing='0' cellpadding='0' bgcolor='#FFFFFF' style='border:solid 1px #30A9DE;-moz-border-radius:5px;-webkit-border-radius:5px;border-radius:5px;'>
        <tbody><tr><td colspan='3'><table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:20px;font-size:20px;line-height:20px;'>&nbsp;</div></td></tr></tbody></table></td></tr>
  <tr>
          <td width='1%'><table width='20' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:0px;font-size:0px;line-height:0px;'>&nbsp;</div></td></tr></tbody></table></td><!-- LEFT PADDING - 1% with a min-width of 20px -->
          <td width='98%'>
            
            <table width='100%' border='0' cellspacing='0' cellpadding='0'>
              <tbody><tr align='left' valign='top'>
                <td colspan='3' style='font-family: Arial; font-size: 18px; color: #333333'>
                  " + review.ChangedByRef.Name + @" Has Updated Your Review
                  <table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:15px;font-size:15px;line-height:15px;'>&nbsp;</div></td></tr></tbody></table>
                </td>
  </tr>
  <tr>
                
                <td valign='top' width='100'>";

            if (review.ChangedByRef.AvatarPath.StartsWith("http://"))
            {
                s += "<a href='" + ConfigurationManager.AppSettings["BASEURL"] + "/People/" + review.ChangedByRef.Email + @"'>
                      <img src='" + review.ChangedByRef.AvatarPath + @"50' border='0' style='display: block;'>
                      </a>";
            }
            else
            {
                s += "<a href='" + ConfigurationManager.AppSettings["BASEURL"] + "/People/" + review.ChangedByRef.Email + @"'>
                      <img src='" + ConfigurationManager.AppSettings["BASEURL"] + HRR.Core.ResourceStrings.AvatarBasePath + review.ChangedByRef.AvatarPath + @"' width='50' height='50' border='0' style='display: block; width: 50px !important; height: 50px !important;'>
                      </a>";
            }

            s += @"</td>
                
                <td width='10'></td>
                <td align='left' valign='top' style='font-family: Arial; font-size: 12px; color: #333333;'>
                  
                      Twice and thrice over, as they say, good is it to repeat and review what is good. 
                      <table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:5px;font-size:5px;line-height:5px;'>&nbsp;</div></td></tr></tbody></table>
                      <ul style='margin: 0; padding-left: 15px;'>
                        <li><span style='color: #ff6600;'> Title: </span>" + review.Title + @"</li>
                        <li><span style='color: #ff6600;'>Due Date: </span>" + review.DueDate.ToShortDateString() + @"</li>
      </ul>
                    
                  <table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:15px;font-size:15px;line-height:15px;'>&nbsp;</div></td></tr></tbody></table>
                </td>
              </tr>
              <tr>
                <td width='110' colspan='2'></td>
                <td>
                  <table border='0' cellspacing='0' cellpadding='0'>
                    <tbody><tr>
                      <td>
                        <table border='0' cellpadding='6' cellspacing='1' align=''><tbody><tr><td align='center' valign='middle' bgcolor='#DEEEF5' background='http://www.linkedin.com/scds/common/u/img/bg/blue_button_back.png' style='background:url(http://www.linkedin.com/scds/common/u/img/bg/blue_button_back.png) repeat-x scroll 100% 0 #DEEEF5;background-color:#DEEEF5;border:1px solid #A3CFE4;-moz-border-radius:4px;-webkit-border-radius:4px;border-radius:4px;'><div style='padding-right:10px;padding-left:10px;'><a href='" + ConfigurationManager.AppSettings["BASEURL"] + @"/Reviews/" + review.ID.ToString() + @"' style='text-decoration:none;'><span style='font-size:12px;font-family:Arial;color:#006699;white-space:nowrap;display:block;'>View Review</span></a></div></td></tr></tbody></table>
                      </td>
                      <td width='15'></td>
                      <td>
                        <table border='0' cellpadding='6' cellspacing='1' align=''><tbody><tr><td align='center' valign='middle' bgcolor='#EBEBEB' background='http://www.linkedin.com/scds/common/u/img/bg/gray_button_back.png' style='background:url(http://www.linkedin.com/scds/common/u/img/bg/gray_button_back.png) repeat-x scroll 100% 0 #EBEBEB;background-color:#EBEBEB;border:1px solid #CCCCCC;-moz-border-radius:4px;-webkit-border-radius:4px;border-radius:4px;'><div style='padding-right:10px;padding-left:10px;'><a href='" + ConfigurationManager.AppSettings["BASEURL"] + @"/People/" + review.EnteredForRef.Email + @"' style='text-decoration:none;'><span style='font-size:12px;font-family:Arial;color:#666666;white-space:nowrap;display:block;'>View Profile</span></a></div></td></tr></tbody></table>
                      </td>
                      <td width='15'></td>
                      <td>
                        <table border='0' cellpadding='6' cellspacing='1' align=''><tbody><tr><td align='center' valign='middle' bgcolor='#EBEBEB' background='http://www.linkedin.com/scds/common/u/img/bg/gray_button_back.png' style='background:url(http://www.linkedin.com/scds/common/u/img/bg/gray_button_back.png) repeat-x scroll 100% 0 #EBEBEB;background-color:#EBEBEB;border:1px solid #CCCCCC;-moz-border-radius:4px;-webkit-border-radius:4px;border-radius:4px;'><div style='padding-right:10px;padding-left:10px;'><a href='" + ConfigurationManager.AppSettings["BASEURL"] + @"/Help/FAQ" + @"' style='text-decoration:none;'><span style='font-size:12px;font-family:Arial;color:#666666;white-space:nowrap;display:block;'>View Help</span></a></div></td></tr></tbody></table>
                      </td>
                    </tr>
                  </tbody></table>
                </td>
              </tr>
            </tbody></table>
          </td>
          <td width='1%'><table width='20' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:0px;font-size:0px;line-height:0px;'>&nbsp;</div></td></tr></tbody></table></td><!-- RIGHT PADDING - 1% with a min-width of 20px -->
        </tr>
        <tr><td colspan='3'><table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:20px;font-size:20px;line-height:20px;'>&nbsp;</div></td></tr></tbody></table></td></tr>
      </tbody></table>
    </td>
  </tr>
  
  
  
  
  <tr><td><table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:15px;font-size:15px;line-height:15px;'>&nbsp;</div></td></tr></tbody></table></td></tr>";

            return s;
        }

        public static void SendReviewNotification(Review review, string emails)
        {
            var nr = IdeaSeed.Core.Data.NHibernate.NHibernateSessionManager.Instance.ReGet<Review>(review);
            var sb = new StringBuilder();
            sb.Append(EmailHTMLStart());
            sb.Append(BuildReviewNotification(nr));
            sb.Append(BuildBlogForNotification());
            sb.Append(EmailHTMLEnd());
            try
            {
                IdeaSeed.Core.Mail.EmailUtils.SendEmail(nr.EnteredForRef.Email, "noreply@hrriver.com", "", emails + ConfigurationManager.AppSettings["NEWCOMMENTNOTIFICATION"], "New Review Activity", sb.ToString(), false, "");
            }
            catch (Exception exc)
            {
                SecurityContextManager.Current.LogEvent(SecurityContextManager
                    .Current
                    .CurrentUser
                    .ID, DateTime.Now, (int)ApplicationLogTypes.EMAIL_SUCCESS, SecurityContextManager.Current.CurrentAccount.ID, "<b>Sending Review Activity Notification Failed</b><br /><br /><b>Message:</b><br /><span" + exc.Message + "</span><br /><br /><b>Stack:</b><br /><span>" + exc.StackTrace + "</span>", "", "");
            }
        }

        private static string BuildGoalCommentUpdateNotification(Goal goal)
        {
            var s = @"<tr align='center'>
    <td>
      <table width='700' border='0' cellspacing='0' cellpadding='0' bgcolor='#FFFFFF' style='border:solid 1px #30A9DE;-moz-border-radius:5px;-webkit-border-radius:5px;border-radius:5px;'>
        <tbody><tr><td colspan='3'><table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:20px;font-size:20px;line-height:20px;'>&nbsp;</div></td></tr></tbody></table></td></tr>
  <tr>
          <td width='1%'><table width='20' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:0px;font-size:0px;line-height:0px;'>&nbsp;</div></td></tr></tbody></table></td><!-- LEFT PADDING - 1% with a min-width of 20px -->
          <td width='98%'>
            
            <table width='100%' border='0' cellspacing='0' cellpadding='0'>
              <tbody><tr align='left' valign='top'>
                <td colspan='3' style='font-family: Arial; font-size: 18px; color: #333333'>
                  " + goal.EnteredByRef.Name + @" Has Added A Comment To This Goal
                  <table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:15px;font-size:15px;line-height:15px;'>&nbsp;</div></td></tr></tbody></table>
                </td>
  </tr>
  <tr>
                
                <td valign='top' width='100'>";

            if (goal.EnteredByRef.AvatarPath.StartsWith("http://"))
            {
                s += "<a href='" + ConfigurationManager.AppSettings["BASEURL"] + "/People/" + goal.EnteredByRef.Email + @"'>
                      <img src='" + goal.EnteredByRef.AvatarPath + @"50' border='0' style='display: block;'>
                      </a>";
            }
            else
            {
                s += "<a href='" + ConfigurationManager.AppSettings["BASEURL"] + "/People/" + goal.EnteredByRef.Email + @"'>
                      <img src='" + ConfigurationManager.AppSettings["BASEURL"] + HRR.Core.ResourceStrings.AvatarBasePath + goal.EnteredByRef.AvatarPath + @"' width='50' height='50' border='0' style='display: block; width: 50px !important; height: 50px !important;'>
                      </a>";
            }

            s += @"</td>
                
                <td width='10'></td>
                <td align='left' valign='top' style='font-family: Arial; font-size: 12px; color: #333333;'>
                  
                      Communication - the human connection - is the key to personal and career success! 
                      <table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:5px;font-size:5px;line-height:5px;'>&nbsp;</div></td></tr></tbody></table>
                      <ul style='margin: 0; padding-left: 15px;'>
                        <li><span style='color: #ff6600;'> Title: </span>" + goal.Title + @"</li>
                        <li><span style='color: #ff6600;'>Due Date: </span>" + goal.DueDate.ToShortDateString() + @"</li>
      </ul>
                    
                  <table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:15px;font-size:15px;line-height:15px;'>&nbsp;</div></td></tr></tbody></table>
                </td>
              </tr>
              <tr>
                <td width='110' colspan='2'></td>
                <td>
                  <table border='0' cellspacing='0' cellpadding='0'>
                    <tbody><tr>
                      <td>
                        <table border='0' cellpadding='6' cellspacing='1' align=''><tbody><tr><td align='center' valign='middle' bgcolor='#DEEEF5' background='http://www.linkedin.com/scds/common/u/img/bg/blue_button_back.png' style='background:url(http://www.linkedin.com/scds/common/u/img/bg/blue_button_back.png) repeat-x scroll 100% 0 #DEEEF5;background-color:#DEEEF5;border:1px solid #A3CFE4;-moz-border-radius:4px;-webkit-border-radius:4px;border-radius:4px;'><div style='padding-right:10px;padding-left:10px;'><a href='" + ConfigurationManager.AppSettings["BASEURL"] + @"/Goals/" + goal.ID.ToString() + @"' style='text-decoration:none;'><span style='font-size:12px;font-family:Arial;color:#006699;white-space:nowrap;display:block;'>View Goal</span></a></div></td></tr></tbody></table>
                      </td>
                      <td width='15'></td>
                      <td>
                        <table border='0' cellpadding='6' cellspacing='1' align=''><tbody><tr><td align='center' valign='middle' bgcolor='#EBEBEB' background='http://www.linkedin.com/scds/common/u/img/bg/gray_button_back.png' style='background:url(http://www.linkedin.com/scds/common/u/img/bg/gray_button_back.png) repeat-x scroll 100% 0 #EBEBEB;background-color:#EBEBEB;border:1px solid #CCCCCC;-moz-border-radius:4px;-webkit-border-radius:4px;border-radius:4px;'><div style='padding-right:10px;padding-left:10px;'><a href='" + ConfigurationManager.AppSettings["BASEURL"] + @"/People/" + goal.EnteredForRef.Email + @"' style='text-decoration:none;'><span style='font-size:12px;font-family:Arial;color:#666666;white-space:nowrap;display:block;'>View Profile</span></a></div></td></tr></tbody></table>
                      </td>
                      <td width='15'></td>
                      <td>
                        <table border='0' cellpadding='6' cellspacing='1' align=''><tbody><tr><td align='center' valign='middle' bgcolor='#EBEBEB' background='http://www.linkedin.com/scds/common/u/img/bg/gray_button_back.png' style='background:url(http://www.linkedin.com/scds/common/u/img/bg/gray_button_back.png) repeat-x scroll 100% 0 #EBEBEB;background-color:#EBEBEB;border:1px solid #CCCCCC;-moz-border-radius:4px;-webkit-border-radius:4px;border-radius:4px;'><div style='padding-right:10px;padding-left:10px;'><a href='" + ConfigurationManager.AppSettings["BASEURL"] + @"/Help/FAQ" + @"' style='text-decoration:none;'><span style='font-size:12px;font-family:Arial;color:#666666;white-space:nowrap;display:block;'>View Help</span></a></div></td></tr></tbody></table>
                      </td>
                    </tr>
                  </tbody></table>
                </td>
              </tr>
            </tbody></table>
          </td>
          <td width='1%'><table width='20' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:0px;font-size:0px;line-height:0px;'>&nbsp;</div></td></tr></tbody></table></td><!-- RIGHT PADDING - 1% with a min-width of 20px -->
        </tr>
        <tr><td colspan='3'><table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:20px;font-size:20px;line-height:20px;'>&nbsp;</div></td></tr></tbody></table></td></tr>
      </tbody></table>
    </td>
  </tr>
  
  
  
  
  <tr><td><table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:15px;font-size:15px;line-height:15px;'>&nbsp;</div></td></tr></tbody></table></td></tr>";

            return s;
        }

        public static void SendGoalCommentUpdateNotification(Goal goal, string emails)
        {
            var nr = IdeaSeed.Core.Data.NHibernate.NHibernateSessionManager.Instance.ReGet<Goal>(goal);
            var sb = new StringBuilder();
            sb.Append(EmailHTMLStart());
            sb.Append(BuildGoalCommentUpdateNotification(nr));
            sb.Append(BuildBlogForNotification());
            sb.Append(EmailHTMLEnd());
            try
            {
                IdeaSeed.Core.Mail.EmailUtils.SendEmail(nr.EnteredForRef.Email, "noreply@hrriver.com", "", emails + ConfigurationManager.AppSettings["NEWCOMMENTNOTIFICATION"], "New Goal Comment Activity", sb.ToString(), false, "");
            }
            catch (Exception exc)
            {
                SecurityContextManager.Current.LogEvent(SecurityContextManager
                    .Current
                    .CurrentUser
                    .ID, DateTime.Now, (int)ApplicationLogTypes.EMAIL_SUCCESS, SecurityContextManager.Current.CurrentAccount.ID, "<b>Sending Goal Comment Update Notification Failed</b><br /><br /><b>Message:</b><br /><span" + exc.Message + "</span><br /><br /><b>Stack:</b><br /><span>" + exc.StackTrace + "</span>", "", "");
            }
        }

        #endregion

        #region Polls & Surveys

        private static string BuildPollNotification(Message message, Person sendto)
        {
            var s = @"<tr align='center'>
    <td>
      <table width='700' border='0' cellspacing='0' cellpadding='0' bgcolor='#FFFFFF' style='border:solid 1px #30A9DE;-moz-border-radius:5px;-webkit-border-radius:5px;border-radius:5px;'>
        <tbody><tr><td colspan='3'><table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:20px;font-size:20px;line-height:20px;'>&nbsp;</div></td></tr></tbody></table></td></tr>
  <tr>
          <td width='1%'><table width='20' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:0px;font-size:0px;line-height:0px;'>&nbsp;</div></td></tr></tbody></table></td><!-- LEFT PADDING - 1% with a min-width of 20px -->
          <td width='98%'>
            
            <table width='100%' border='0' cellspacing='0' cellpadding='0'>
              <tbody><tr align='left' valign='top'>
                <td colspan='3' style='font-family: Arial; font-size: 18px; color: #333333'>
                  A New Employee Poll Is Waiting For Your Response!
                  <table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:15px;font-size:15px;line-height:15px;'>&nbsp;</div></td></tr></tbody></table>
                </td>
  </tr>
  <tr>
                
                <td valign='top' width='100'>";

            if (sendto.AvatarPath.StartsWith("http://"))
            {
                s += "<a href='" + ConfigurationManager.AppSettings["BASEURL"] + "/People/" + sendto.Email + @"'>
                      <img src='" + sendto.AvatarPath + @"50' border='0' style='display: block;'>
                      </a>";
            }
            else
            {
                s += "<a href='" + ConfigurationManager.AppSettings["BASEURL"] + "/People/" + sendto.Email + @"'>
                      <img src='" + ConfigurationManager.AppSettings["BASEURL"] + HRR.Core.ResourceStrings.AvatarBasePath + sendto.AvatarPath + @"' width='50' height='50' border='0' style='display: block; width: 50px !important; height: 50px !important;'>
                      </a>";
            }

            s += @"</td>
                
                <td width='10'></td>
                <td align='left' valign='top' style='font-family: Arial; font-size: 12px; color: #333333;'>
                  
                      There is no index of character so sure as the voice. 
                      <table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:5px;font-size:5px;line-height:5px;'>&nbsp;</div></td></tr></tbody></table>
                      <ul style='margin: 0; padding-left: 15px;'>
                        <li><span style='color: #ff6600;'> Subject: </span>" + message.Subject + @"</li>
                        <li><span style='color: #ff6600;'>Date Sent: </span>" + message.DateCreated.ToShortDateString() + @"</li>
<li><span style='color: #ff6600;'>Message: </span>" + message.Body + @"</li>
      </ul>
                    
                  <table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:15px;font-size:15px;line-height:15px;'>&nbsp;</div></td></tr></tbody></table>
                </td>
              </tr>
              <tr>
                <td width='110' colspan='2'></td>
                <td>
                  <table border='0' cellspacing='0' cellpadding='0'>
                    <tbody><tr>
                      <td>
                        <table border='0' cellpadding='6' cellspacing='1' align=''><tbody><tr><td align='center' valign='middle' bgcolor='#DEEEF5' background='http://www.linkedin.com/scds/common/u/img/bg/blue_button_back.png' style='background:url(http://www.linkedin.com/scds/common/u/img/bg/blue_button_back.png) repeat-x scroll 100% 0 #DEEEF5;background-color:#DEEEF5;border:1px solid #A3CFE4;-moz-border-radius:4px;-webkit-border-radius:4px;border-radius:4px;'><div style='padding-right:10px;padding-left:10px;'><a href='" + ConfigurationManager.AppSettings["BASEURL"] + @"/Overview' style='text-decoration:none;'><span style='font-size:12px;font-family:Arial;color:#006699;white-space:nowrap;display:block;'>View Poll</span></a></div></td></tr></tbody></table>
                      </td>
                      <td width='15'></td>
                      <td>
                        <table border='0' cellpadding='6' cellspacing='1' align=''><tbody><tr><td align='center' valign='middle' bgcolor='#EBEBEB' background='http://www.linkedin.com/scds/common/u/img/bg/gray_button_back.png' style='background:url(http://www.linkedin.com/scds/common/u/img/bg/gray_button_back.png) repeat-x scroll 100% 0 #EBEBEB;background-color:#EBEBEB;border:1px solid #CCCCCC;-moz-border-radius:4px;-webkit-border-radius:4px;border-radius:4px;'><div style='padding-right:10px;padding-left:10px;'><a href='" + ConfigurationManager.AppSettings["BASEURL"] + @"/People/" + sendto.Email + @"' style='text-decoration:none;'><span style='font-size:12px;font-family:Arial;color:#666666;white-space:nowrap;display:block;'>View Profile</span></a></div></td></tr></tbody></table>
                      </td>
                      <td width='15'></td>
                      <td>
                        <table border='0' cellpadding='6' cellspacing='1' align=''><tbody><tr><td align='center' valign='middle' bgcolor='#EBEBEB' background='http://www.linkedin.com/scds/common/u/img/bg/gray_button_back.png' style='background:url(http://www.linkedin.com/scds/common/u/img/bg/gray_button_back.png) repeat-x scroll 100% 0 #EBEBEB;background-color:#EBEBEB;border:1px solid #CCCCCC;-moz-border-radius:4px;-webkit-border-radius:4px;border-radius:4px;'><div style='padding-right:10px;padding-left:10px;'><a href='" + ConfigurationManager.AppSettings["BASEURL"] + @"/Help/FAQ" + @"' style='text-decoration:none;'><span style='font-size:12px;font-family:Arial;color:#666666;white-space:nowrap;display:block;'>View Help</span></a></div></td></tr></tbody></table>
                      </td>
                    </tr>
                  </tbody></table>
                </td>
              </tr>
            </tbody></table>
          </td>
          <td width='1%'><table width='20' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:0px;font-size:0px;line-height:0px;'>&nbsp;</div></td></tr></tbody></table></td><!-- RIGHT PADDING - 1% with a min-width of 20px -->
        </tr>
        <tr><td colspan='3'><table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:20px;font-size:20px;line-height:20px;'>&nbsp;</div></td></tr></tbody></table></td></tr>
      </tbody></table>
    </td>
  </tr>
  
  
  
  
  <tr><td><table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:15px;font-size:15px;line-height:15px;'>&nbsp;</div></td></tr></tbody></table></td></tr>";

            return s;
        }

        public static void SendPollNotification(Message message, Person sendto)
        {
            var nr = IdeaSeed.Core.Data.NHibernate.NHibernateSessionManager.Instance.ReGet<Message>(message);
            var sb = new StringBuilder();
            sb.Append(EmailHTMLStart());
            sb.Append(BuildPollNotification(nr, sendto));
            sb.Append(BuildBlogForNotification());
            sb.Append(EmailHTMLEnd());
            try
            {
                IdeaSeed.Core.Mail.EmailUtils.SendEmail(sendto.Email, "noreply@hrriver.com", "", ConfigurationManager.AppSettings["NEWCOMMENTNOTIFICATION"], message.Subject, sb.ToString(), false, "");
            }
            catch (Exception exc)
            {
                SecurityContextManager.Current.LogEvent(SecurityContextManager
                    .Current
                    .CurrentUser
                    .ID, DateTime.Now, (int)ApplicationLogTypes.EMAIL_SUCCESS, SecurityContextManager.Current.CurrentAccount.ID, "<b>Sending Poll Failed</b><br /><br /><b>Message:</b><br /><span" + exc.Message + "</span><br /><br /><b>Stack:</b><br /><span>" + exc.StackTrace + "</span>", "", "");
            }
        }

        #endregion

        #region Messaging

        private static string BuildMessageNotification(Message message)
        {
            var s = @"<tr align='center'>
    <td>
      <table width='700' border='0' cellspacing='0' cellpadding='0' bgcolor='#FFFFFF' style='border:solid 1px #30A9DE;-moz-border-radius:5px;-webkit-border-radius:5px;border-radius:5px;'>
        <tbody><tr><td colspan='3'><table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:20px;font-size:20px;line-height:20px;'>&nbsp;</div></td></tr></tbody></table></td></tr>
  <tr>
          <td width='1%'><table width='20' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:0px;font-size:0px;line-height:0px;'>&nbsp;</div></td></tr></tbody></table></td><!-- LEFT PADDING - 1% with a min-width of 20px -->
          <td width='98%'>
            
            <table width='100%' border='0' cellspacing='0' cellpadding='0'>
              <tbody><tr align='left' valign='top'>
                <td colspan='3' style='font-family: Arial; font-size: 18px; color: #333333'>
                  " + message.SentByRef.Name + @" Has Sent You A Message
                  <table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:15px;font-size:15px;line-height:15px;'>&nbsp;</div></td></tr></tbody></table>
                </td>
  </tr>
  <tr>
                
                <td valign='top' width='100'>";

            if (message.SentByRef.AvatarPath.StartsWith("http://"))
            {
                s += "<a href='" + ConfigurationManager.AppSettings["BASEURL"] + "/People/" + message.SentByRef.Email + @"'>
                      <img src='" + message.SentByRef.AvatarPath + @"50' border='0' style='display: block;'>
                      </a>";
            }
            else
            {
                s += "<a href='" + ConfigurationManager.AppSettings["BASEURL"] + "/People/" + message.SentByRef.Email + @"'>
                      <img src='" + ConfigurationManager.AppSettings["BASEURL"] + HRR.Core.ResourceStrings.AvatarBasePath + message.SentByRef.AvatarPath + @"' width='50' height='50' border='0' style='display: block; width: 50px !important; height: 50px !important;'>
                      </a>";
            }

            s += @"</td>
                
                <td width='10'></td>
                <td align='left' valign='top' style='font-family: Arial; font-size: 12px; color: #333333;'>
                  
                      The art of communication is the language of leadership. 
                      <table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:5px;font-size:5px;line-height:5px;'>&nbsp;</div></td></tr></tbody></table>
                      <ul style='margin: 0; padding-left: 15px;'>
                        <li><span style='color: #ff6600;'> Subject: </span>" + message.Subject + @"</li>
                        <li><span style='color: #ff6600;'>Date Sent: </span>" + message.DateCreated.ToShortDateString() + @"</li>
      </ul>
                    
                  <table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:15px;font-size:15px;line-height:15px;'>&nbsp;</div></td></tr></tbody></table>
                </td>
              </tr>
              <tr>
                <td width='110' colspan='2'></td>
                <td>
                  <table border='0' cellspacing='0' cellpadding='0'>
                    <tbody><tr>
                      <td>
                        <table border='0' cellpadding='6' cellspacing='1' align=''><tbody><tr><td align='center' valign='middle' bgcolor='#DEEEF5' background='http://www.linkedin.com/scds/common/u/img/bg/blue_button_back.png' style='background:url(http://www.linkedin.com/scds/common/u/img/bg/blue_button_back.png) repeat-x scroll 100% 0 #DEEEF5;background-color:#DEEEF5;border:1px solid #A3CFE4;-moz-border-radius:4px;-webkit-border-radius:4px;border-radius:4px;'><div style='padding-right:10px;padding-left:10px;'><a href='" + ConfigurationManager.AppSettings["BASEURL"] + @"/Messages/" + message.ID.ToString() + @"' style='text-decoration:none;'><span style='font-size:12px;font-family:Arial;color:#006699;white-space:nowrap;display:block;'>View Message</span></a></div></td></tr></tbody></table>
                      </td>
                      <td width='15'></td>
                      <td>
                        <table border='0' cellpadding='6' cellspacing='1' align=''><tbody><tr><td align='center' valign='middle' bgcolor='#EBEBEB' background='http://www.linkedin.com/scds/common/u/img/bg/gray_button_back.png' style='background:url(http://www.linkedin.com/scds/common/u/img/bg/gray_button_back.png) repeat-x scroll 100% 0 #EBEBEB;background-color:#EBEBEB;border:1px solid #CCCCCC;-moz-border-radius:4px;-webkit-border-radius:4px;border-radius:4px;'><div style='padding-right:10px;padding-left:10px;'><a href='" + ConfigurationManager.AppSettings["BASEURL"] + @"/People/" + message.SentByRef.Email + @"' style='text-decoration:none;'><span style='font-size:12px;font-family:Arial;color:#666666;white-space:nowrap;display:block;'>View Profile</span></a></div></td></tr></tbody></table>
                      </td>
                      <td width='15'></td>
                      <td>
                        <table border='0' cellpadding='6' cellspacing='1' align=''><tbody><tr><td align='center' valign='middle' bgcolor='#EBEBEB' background='http://www.linkedin.com/scds/common/u/img/bg/gray_button_back.png' style='background:url(http://www.linkedin.com/scds/common/u/img/bg/gray_button_back.png) repeat-x scroll 100% 0 #EBEBEB;background-color:#EBEBEB;border:1px solid #CCCCCC;-moz-border-radius:4px;-webkit-border-radius:4px;border-radius:4px;'><div style='padding-right:10px;padding-left:10px;'><a href='" + ConfigurationManager.AppSettings["BASEURL"] + @"/Help/FAQ" + @"' style='text-decoration:none;'><span style='font-size:12px;font-family:Arial;color:#666666;white-space:nowrap;display:block;'>View Help</span></a></div></td></tr></tbody></table>
                      </td>
                    </tr>
                  </tbody></table>
                </td>
              </tr>
            </tbody></table>
          </td>
          <td width='1%'><table width='20' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:0px;font-size:0px;line-height:0px;'>&nbsp;</div></td></tr></tbody></table></td><!-- RIGHT PADDING - 1% with a min-width of 20px -->
        </tr>
        <tr><td colspan='3'><table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:20px;font-size:20px;line-height:20px;'>&nbsp;</div></td></tr></tbody></table></td></tr>
      </tbody></table>
    </td>
  </tr>
  
  
  
  
  <tr><td><table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:15px;font-size:15px;line-height:15px;'>&nbsp;</div></td></tr></tbody></table></td></tr>";

            return s;
        }

        public static void SendMessageNotification(Message message, Person sendto)
        {
            var nr = IdeaSeed.Core.Data.NHibernate.NHibernateSessionManager.Instance.ReGet<Message>(message);
            var sb = new StringBuilder();
            sb.Append(EmailHTMLStart());
            sb.Append(BuildMessageNotification(nr));
            sb.Append(BuildBlogForNotification());
            sb.Append(EmailHTMLEnd());
            try
            {
                IdeaSeed.Core.Mail.EmailUtils.SendEmail(sendto.Email, "noreply@hrriver.com", "", ConfigurationManager.AppSettings["NEWCOMMENTNOTIFICATION"], "New Message Activity", sb.ToString(), false, "");
            }
            catch (Exception exc)
            {
                SecurityContextManager.Current.LogEvent(SecurityContextManager
                    .Current
                    .CurrentUser
                    .ID, DateTime.Now, (int)ApplicationLogTypes.EMAIL_SUCCESS, SecurityContextManager.Current.CurrentAccount.ID, "<b>Sending Review Activity Notification Failed</b><br /><br /><b>Message:</b><br /><span" + exc.Message + "</span><br /><br /><b>Stack:</b><br /><span>" + exc.StackTrace + "</span>", "", "");
            }
        }

        #endregion


        #region Employees

        private static string BuildNewEmployeeNotification(Person person)
        {
            var s = @"<tr align='center'>
    <td>
      <table width='700' border='0' cellspacing='0' cellpadding='0' bgcolor='#FFFFFF' style='border:solid 1px #30A9DE;-moz-border-radius:5px;-webkit-border-radius:5px;border-radius:5px;'>
        <tbody><tr><td colspan='3'><table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:20px;font-size:20px;line-height:20px;'>&nbsp;</div></td></tr></tbody></table></td></tr>
  <tr>
          <td width='1%'><table width='20' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:0px;font-size:0px;line-height:0px;'>&nbsp;</div></td></tr></tbody></table></td><!-- LEFT PADDING - 1% with a min-width of 20px -->
          <td width='98%'>
            
            <table width='100%' border='0' cellspacing='0' cellpadding='0'>
              <tbody><tr align='left' valign='top'>
                <td colspan='3' style='font-family: Arial; font-size: 18px; color: #333333'>
                  Welcome To The Team!!
                  <table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:15px;font-size:15px;line-height:15px;'>&nbsp;</div></td></tr></tbody></table>
                </td>
  </tr>
  <tr>
                
                <td valign='top' width='100'>";

            if (person.AvatarPath.StartsWith("http://"))
            {
                s += "<a href='" + ConfigurationManager.AppSettings["BASEURL"] + "/People/" + person.Email + @"'>
                      <img src='" + person.AvatarPath + @"50' border='0' style='display: block;'>
                      </a>";
            }
            else
            {
                s += "<a href='" + ConfigurationManager.AppSettings["BASEURL"] + "/People/" + person.Email + @"'>
                      <img src='" + ConfigurationManager.AppSettings["BASEURL"] + HRR.Core.ResourceStrings.AvatarBasePath + person.AvatarPath + @"' width='50' height='50' border='0' style='display: block; width: 50px !important; height: 50px !important;'>
                      </a>";
            }

            s += @"</td>
                
                <td width='10'></td>
                <td align='left' valign='top' style='font-family: Arial; font-size: 12px; color: #333333;'>
                  
                      Here is your account information and a few links to help get you started. First things first...click on the Change Password button below and supply the proper info.  
                      <table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:5px;font-size:5px;line-height:5px;'>&nbsp;</div></td></tr></tbody></table>
                      <ul style='margin: 0; padding-left: 15px;'>
                        <li><span style='color: #ff6600;'> Username: </span>" + person.Email + @"</li>
                        <li><span style='color: #ff6600;'>Answer To Security Question: </span>" + person.PasswordAnswer + @"</li>
      </ul>
                    
                  <table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:15px;font-size:15px;line-height:15px;'>&nbsp;</div></td></tr></tbody></table>
                </td>
              </tr>
              <tr>
                <td width='110' colspan='2'></td>
                <td>
                  <table border='0' cellspacing='0' cellpadding='0'>
                    <tbody><tr>
                      <td>
                        <table border='0' cellpadding='6' cellspacing='1' align=''><tbody><tr><td align='center' valign='middle' bgcolor='#DEEEF5' background='http://www.linkedin.com/scds/common/u/img/bg/blue_button_back.png' style='background:url(http://www.linkedin.com/scds/common/u/img/bg/blue_button_back.png) repeat-x scroll 100% 0 #DEEEF5;background-color:#DEEEF5;border:1px solid #A3CFE4;-moz-border-radius:4px;-webkit-border-radius:4px;border-radius:4px;'><div style='padding-right:10px;padding-left:10px;'><a href='" + ConfigurationManager.AppSettings["BASEURL"] + @"/ForgotPassword.aspx' style='text-decoration:none;'><span style='font-size:12px;font-family:Arial;color:#006699;white-space:nowrap;display:block;'>Change Password</span></a></div></td></tr></tbody></table>
                      </td>
                      <td width='15'></td>
                      
                      <td>
                        <table border='0' cellpadding='6' cellspacing='1' align=''><tbody><tr><td align='center' valign='middle' bgcolor='#EBEBEB' background='http://www.linkedin.com/scds/common/u/img/bg/gray_button_back.png' style='background:url(http://www.linkedin.com/scds/common/u/img/bg/gray_button_back.png) repeat-x scroll 100% 0 #EBEBEB;background-color:#EBEBEB;border:1px solid #CCCCCC;-moz-border-radius:4px;-webkit-border-radius:4px;border-radius:4px;'><div style='padding-right:10px;padding-left:10px;'><a href='" + ConfigurationManager.AppSettings["BASEURL"] + @"/Help/FAQ" + @"' style='text-decoration:none;'><span style='font-size:12px;font-family:Arial;color:#666666;white-space:nowrap;display:block;'>View Help</span></a></div></td></tr></tbody></table>
                      </td>
                    </tr>
                  </tbody></table>
                </td>
              </tr>
            </tbody></table>
          </td>
          <td width='1%'><table width='20' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:0px;font-size:0px;line-height:0px;'>&nbsp;</div></td></tr></tbody></table></td><!-- RIGHT PADDING - 1% with a min-width of 20px -->
        </tr>
        <tr><td colspan='3'><table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:20px;font-size:20px;line-height:20px;'>&nbsp;</div></td></tr></tbody></table></td></tr>
      </tbody></table>
    </td>
  </tr>
  
  
  
  
  <tr><td><table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:15px;font-size:15px;line-height:15px;'>&nbsp;</div></td></tr></tbody></table></td></tr>";

            return s;
        }

        public static void SendNewEmployeeNotification(Person person, string emails)
        {
            var nr = IdeaSeed.Core.Data.NHibernate.NHibernateSessionManager.Instance.ReGet<Person>(person);
            var sb = new StringBuilder();
            sb.Append(EmailHTMLStart());
            sb.Append(BuildNewEmployeeNotification(nr));
            sb.Append(BuildBlogForNotification());
            sb.Append(EmailHTMLEnd());
            try
            {
                IdeaSeed.Core.Mail.EmailUtils.SendEmail(nr.Email, "noreply@hrriver.com", "", emails + ConfigurationManager.AppSettings["NEWCOMMENTNOTIFICATION"], "Welcome To HR River", sb.ToString(), false, "");
            }
            catch (Exception exc)
            {
                SecurityContextManager.Current.LogEvent(SecurityContextManager
                    .Current
                    .CurrentUser
                    .ID, DateTime.Now, (int)ApplicationLogTypes.EMAIL_SUCCESS, SecurityContextManager.Current.CurrentAccount.ID, "<b>Sending New Employee Notification Failed</b><br /><br /><b>Message:</b><br /><span" + exc.Message + "</span><br /><br /><b>Stack:</b><br /><span>" + exc.StackTrace + "</span>", "", "");
            }
        }
        #endregion

        #region Weekly Update
        private static string BuildWeeklyUpdateNotification(Person person)
        {
            var s = "";
            try
            {
                var ct = new CommentServices().GetCommentTotalsByEmployeeID(person.ID, DateTime.Now.AddDays(-8).ToShortDateString(), DateTime.Now.AddDays(1).ToShortDateString());
                int positivefor = 0;
                int positiveby = 0;
                int constructivefor = 0;
                int constructiveby = 0;
                if (ct != null)
                {
                    positiveby = ct.LeftByPositive;
                    positivefor = ct.LeftForPositive;
                    constructiveby = ct.LeftByConstructive;
                    constructivefor = ct.LeftForConstructive;
                }
                s += @"<tr align='center'>
    <td>
      <table width='700' border='0' cellspacing='0' cellpadding='0' bgcolor='#FFFFFF' style='border:solid 1px #30A9DE;-moz-border-radius:5px;-webkit-border-radius:5px;border-radius:5px;'>
        <tbody><tr><td colspan='3'><table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:20px;font-size:20px;line-height:20px;'>&nbsp;</div></td></tr></tbody></table></td></tr>
  <tr>
          <td width='1%'><table width='20' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:0px;font-size:0px;line-height:0px;'>&nbsp;</div></td></tr></tbody></table></td><!-- LEFT PADDING - 1% with a min-width of 20px -->
          <td width='98%'>
            
            <table width='100%' border='0' cellspacing='0' cellpadding='0'>
              <tbody><tr align='left' valign='top'>
                <td colspan='3' style='font-family: Arial; font-size: 24px; color: #333333'>
                  Comment & Goal Activity For " + DateTime.Now.AddDays(-7).ToShortDateString() + @" to " + DateTime.Now.ToShortDateString() + @"
                  <table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:15px;font-size:15px;line-height:15px;'>&nbsp;</div></td></tr></tbody></table>
                </td>
  </tr>
  <tr>
                
                <td valign='top' width='50'>";

                if (person.AvatarPath.StartsWith("http://"))
                {
                    s += "<a href='" + ConfigurationManager.AppSettings["BASEURL"] + "/People/" + person.Email + @"'>
                      <img src='" + person.AvatarPath + @"50' border='0' style='display: block;'>
                      </a>";
                }
                else
                {
                    s += "<a href='" + ConfigurationManager.AppSettings["BASEURL"] + "/People/" + person.Email + @"'>
                      <img src='" + ConfigurationManager.AppSettings["BASEURL"] + HRR.Core.ResourceStrings.AvatarBasePath + person.AvatarPath + @"' width='50' height='50' border='0' style='display: block; width: 50px !important; height: 50px !important;'>
                      </a>";
                }

                s += @"</td>
                
                <td width='5'>&nbsp;</td>
                <td align='left' valign='top' style='font-family: Arial; font-size: 18px; font-weight: bold; color: #333333; margin-left: 5px;'>
                  Comment Activity
                      <table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:5px;font-size:5px;line-height:5px;'>&nbsp;</div></td></tr></tbody></table>
                      <ul style='margin: 0; padding-left: 15px; '>
                        <li style='list-style-type: none;'><span style='color: #ff6600;'> Left for: </span>" + positivefor.ToString() + " <img src='" + ConfigurationManager.AppSettings["BASEURL"] + @"/images/uph.png' border='0' alt='Positive' />&nbsp;&nbsp;" + constructivefor.ToString() + " <img src='" + ConfigurationManager.AppSettings["BASEURL"] + @"/images/downh.png' border='0' alt='Constructive' />" + @"</li>
                        <li style='list-style-type: none;'><span style='color: #ff6600;'>Left by&nbsp;: </span>" + positiveby.ToString() + " <img src='" + ConfigurationManager.AppSettings["BASEURL"] + @"/images/uph.png' border='0' alt='Positive' />&nbsp;&nbsp;" + constructiveby.ToString() + " <img src='" + ConfigurationManager.AppSettings["BASEURL"] + @"/images/downh.png' border='0' alt='Constructive' />" + @"</li>
      </ul>
                    
                  <table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:15px;font-size:15px;line-height:15px;'>&nbsp;</div></td></tr></tbody></table>
                </td>
              </tr>


              <tr>
                
                <td valign='top' width='100'>
                  &nbsp;
                </td>
                
                <td width='10'></td>
                <td align='left' valign='top' style='font-family: Arial; font-size: 18px; font-weight: bold; color: #333333;'> Goal Activity
                      <table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:5px;font-size:5px;line-height:5px;'>&nbsp;</div></td></tr></tbody></table>";
                if (person.Goals != null && person.Goals.Count > 0)
                {
                    //s += "<table width='600px' cellspacing='2' cellpadding='2' style='font-family: Arial; font-size: 16px;color: #333333;'><tbody><tr style='background-color: #1ea2db;'><td style='font-weight: bold; color: #ffffff; width: 425px; padding: 5px;'>Title</td><td style='font-weight: bold; color: #ffffff; width: 75px; padding: 5px;'>% complete</td><td style='font-weight: bold; color: #ffffff; width: 50px; padding: 5px;'>Weight</td><td style='font-weight: bold; color: #ffffff; width: 100px; padding: 5px;'>Due Date</td></tr>";
                    foreach (var g in person.Goals)
                    {
                        s += "<table width='600px' cellspacing='2' cellpadding='2' style='font-family: Arial; font-size: 16px;color: #333333;'><tbody><tr style='background-color: #1ea2db;'><td style='font-weight: bold; color: #ffffff; width: 425px; padding: 5px; font-size: 14px;'>Title</td><td style='font-weight: bold; color: #ffffff; width: 75px; padding: 5px; font-size: 14px;'>Progress</td><td style='font-weight: bold; color: #ffffff; width: 50px; padding: 5px; font-size: 14px;'>Weight</td><td style='font-weight: bold; color: #ffffff; width: 100px; padding: 5px; font-size: 14px;'>Due Date</td></tr><tr rowspan='2' height='30px'><td><b>" + g.Title + @"</b></td><td align='center'><b>" + g.StatusID.ToString() + "%</b></td><td align='center'><b>" + g.Weight.ToString() + "</b></td><td><b>" + g.DueDate.ToShortDateString() + "</b></td></tr><tr><td></td><td></td><td></td><td></td></tr>";
                        if (g.Milestones != null && g.Milestones.Count > 0)
                        {
                            s += "<tr><td colspan='4'><table style='width: 550px; margin-left: 25px; margin-bottom: 10px; font-family: Arial; font-size: 14px;'><tr style='background-color: #51C9FF;'><td style='font-weight: bold; color: #ffffff; width: 400px; padding: 5px;'>Milestone</td><td style='font-weight: bold; color: #ffffff; width: 75px; padding: 5px;'>Status</td><td style='font-weight: bold; color: #ffffff; width: 90px; padding: 5px;'>Due Date</td></tr>";
                            foreach (var m in g.Milestones)
                            {
                                s += "<tr><td>" + m.Title + "</td><td align='center'>";
                                if (m.IsComplete)
                                    s += "Complete</td>";
                                else
                                    s += "Incomplete</td>";
                                s += "<td align='center'>" + m.DueDate.ToShortDateString() + "</td></tr>";
                            }
                            s += "</table></td></tr>";
                        }
                        s += "</tbody></table>";
                    }
                    //s += "</tbody></table>";
                }
                else
                {
                    s += "<div style='width: 200px; font-family: Arial; font-size: 14px;'>No Goals Found</div>";
                }

                s += @"<table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:15px;font-size:15px;line-height:15px;'>&nbsp;</div></td></tr></tbody></table>
                </td>
              </tr>
              <tr>
                <td width='110' colspan='2'></td>
                <td>
                  <table border='0' cellspacing='0' cellpadding='0'>
                    <tbody><tr>
                      <td>
                        <table border='0' cellpadding='6' cellspacing='1' align=''><tbody><tr><td align='center' valign='middle' bgcolor='#DEEEF5' background='http://www.linkedin.com/scds/common/u/img/bg/blue_button_back.png' style='background:url(http://www.linkedin.com/scds/common/u/img/bg/blue_button_back.png) repeat-x scroll 100% 0 #DEEEF5;background-color:#DEEEF5;border:1px solid #A3CFE4;-moz-border-radius:4px;-webkit-border-radius:4px;border-radius:4px;'><div style='padding-right:10px;padding-left:10px;'><a href='" + ConfigurationManager.AppSettings["BASEURL"] + @"/People/" + person.Email + @"' style='text-decoration:none;'><span style='font-size:12px;font-family:Arial;color:#666666;white-space:nowrap;display:block;'>View Profile</span></a></div></td></tr></tbody></table>
                      </td>
                      <td width='15'></td>
                      
                      <td>
                        <table border='0' cellpadding='6' cellspacing='1' align=''><tbody><tr><td align='center' valign='middle' bgcolor='#EBEBEB' background='http://www.linkedin.com/scds/common/u/img/bg/gray_button_back.png' style='background:url(http://www.linkedin.com/scds/common/u/img/bg/gray_button_back.png) repeat-x scroll 100% 0 #EBEBEB;background-color:#EBEBEB;border:1px solid #CCCCCC;-moz-border-radius:4px;-webkit-border-radius:4px;border-radius:4px;'><div style='padding-right:10px;padding-left:10px;'><a href='" + ConfigurationManager.AppSettings["BASEURL"] + @"/Help/FAQ" + @"' style='text-decoration:none;'><span style='font-size:12px;font-family:Arial;color:#666666;white-space:nowrap;display:block;'>View Help</span></a></div></td></tr></tbody></table>
                      </td>
                    </tr>
                  </tbody></table>
                </td>
              </tr>
            </tbody></table>
          </td>
          <td width='1%'><table width='20' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:0px;font-size:0px;line-height:0px;'>&nbsp;</div></td></tr></tbody></table></td><!-- RIGHT PADDING - 1% with a min-width of 20px -->
        </tr>
        <tr><td colspan='3'><table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:20px;font-size:20px;line-height:20px;'>&nbsp;</div></td></tr></tbody></table></td></tr>
      </tbody></table>
    </td>
  </tr>
  
  
  
  
  <tr><td><table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:15px;font-size:15px;line-height:15px;'>&nbsp;</div></td></tr></tbody></table></td></tr>";

                return s;
            }
            catch (Exception exc)
            {
                SecurityContextManager.Current.LogEvent(SecurityContextManager
                    .Current
                    .CurrentUser
                    .ID, DateTime.Now, (int)ApplicationLogTypes.EXCEPTION_UNHANDLED, SecurityContextManager.Current.CurrentAccount.ID, "<b>Building Weekly Update Failed</b><br /><br /><b>Message:</b><br /><span" + exc.Message + "</span><br /><br /><b>Stack:</b><br /><span>" + exc.StackTrace + "</span>", "", "");

                try
                {
                    IdeaSeed.Core.Utils.Utilities.WriteXMLErrorToDisc(exc.Message, "", exc.StackTrace, "Auto", "HR River", "", "BuildingWeeklyUpdateError", "person: " + person.Name);

                }
                catch (Exception ex)
                {
                    StreamWriter wr = new StreamWriter(@"buildingweeklyupdate.log");
                    wr.WriteLine(ex.Message);
                    wr.WriteLine("<br /><br />");
                    wr.WriteLine(ex.StackTrace);
                    wr.Close();
                }
            }
            return s;
        }

        public static void SendWeeklyUpdateNotification(Person person)
        {
            var nr = IdeaSeed.Core.Data.NHibernate.NHibernateSessionManager.Instance.ReGet<Person>(person);
            var sb = new StringBuilder();
            sb.Append(EmailHTMLStart());
            sb.Append(BuildActivityFeedForNotification(nr));
            sb.Append(BuildWeeklyUpdateNotification(nr));
            sb.Append(BuildBlogForNotification(person.AccountID));
            sb.Append(EmailHTMLEnd());
            try
            {
                IdeaSeed.Core.Mail.EmailUtils.SendEmail(nr.Email, "noreply@hrriver.com", "", ConfigurationManager.AppSettings["NEWCOMMENTNOTIFICATION"], "HR River Weekly Update", sb.ToString(), false, "");
            }
            catch (Exception exc)
            {
                SecurityContextManager.Current.LogEvent(SecurityContextManager
                    .Current
                    .CurrentUser
                    .ID, DateTime.Now, (int)ApplicationLogTypes.EMAIL_SUCCESS, SecurityContextManager.Current.CurrentAccount.ID, "<b>Sending Weekly Update Failed</b><br /><br /><b>Message:</b><br /><span" + exc.Message + "</span><br /><br /><b>Stack:</b><br /><span>" + exc.StackTrace + "</span>", "", "");

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
        #endregion

    }
}
