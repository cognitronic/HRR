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
<table width='100%' border='0' cellspacing='0' cellpadding='0' bgcolor='#1ea2db' style='border:solid 1px #1ea2db;-moz-border-radius:5px;-webkit-border-radius:5px;border-radius:5px;'>
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
            foreach(var response in blog.Responses)
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
                              <div style='font-family: Arial; font-size: 11px; color: #666666'>Michael Scott</div>
                            </td>
                          </tr>
                        </tbody></table>
                      </td>
                    </tr>";   
            }
            return s;
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
                
                <td valign='top' width='100'>
                  <img src='" + ConfigurationManager.AppSettings["BASEURL"] + HRR.Core.ResourceStrings.AvatarBasePath + "thumb_" + comment.EnteredByRef.AvatarPath + @"' border='0' alt='" + comment.EnteredByRef.Name + @"'>
                </td>
                
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
            var sb = new StringBuilder();
            sb.Append(EmailHTMLStart());
            sb.Append(BuildNewCommentNotification(comment));
            sb.Append(BuildBlogForNotification());
            sb.Append(EmailHTMLEnd());
            try
            {
                IdeaSeed.Core.Mail.EmailUtils.SendEmail(comment.EnteredForRef.Email, "noreply@hrrriver.com", "", ConfigurationManager.AppSettings["NEWCOMMENTNOTIFICATION"], "You Have A New Comment", sb.ToString(), false, "");
            }
            catch (Exception exc)
            {
                SecurityContextManager.Current.LogEvent(SecurityContextManager
                    .Current
                    .CurrentUser
                    .ID, DateTime.Now, (int)ApplicationLogTypes.EMAIL_SUCCESS, SecurityContextManager.Current.CurrentAccount.ID, "<b>Sending New Comment Notification Failed</b><br /><br /><b>Message:</b><br /><span" + exc.Message + "</span><br /><br /><b>Stack:</b><br /><span>" + exc.StackTrace + "</span>", "", "");
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
                
                <td valign='top' width='100'>
                  <img src='" + ConfigurationManager.AppSettings["BASEURL"] + HRR.Core.ResourceStrings.AvatarBasePath + "thumb_" + response.EnteredByRef.AvatarPath + @"' border='0' alt='" + response.EnteredByRef.Name + @"'>
                </td>
                
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
                IdeaSeed.Core.Mail.EmailUtils.SendEmail(nr.CommentRef.EnteredForRef.Email, "noreply@hrrriver.com", "", emails + ConfigurationManager.AppSettings["NEWCOMMENTNOTIFICATION"], "You Have A New Comment", sb.ToString(), false, "");
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
                
                <td valign='top' width='100'>
                  <img src='" + ConfigurationManager.AppSettings["BASEURL"] + HRR.Core.ResourceStrings.AvatarBasePath + "thumb_" + ((Person)SecurityContextManager.Current.CurrentUser).AvatarPath + @"' border='0' alt='" + SecurityContextManager.Current.CurrentUser.Name + @"'>
                </td>
                
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

                IdeaSeed.Core.Mail.EmailUtils.SendEmail(emails, "noreply@hrrriver.com", "", ConfigurationManager.AppSettings["NEWCOMMENTNOTIFICATION"], "A Comment Has Been Flagged As Inappropriate", sb.ToString(), false, "");
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
                
                <td valign='top' width='100'>
                  <img src='" + ConfigurationManager.AppSettings["BASEURL"] + HRR.Core.ResourceStrings.AvatarBasePath + "thumb_" + goal.EnteredByRef.AvatarPath + @"' border='0' alt='" + goal.EnteredByRef.Name + @"'>
                </td>
                
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
                IdeaSeed.Core.Mail.EmailUtils.SendEmail(nr.EnteredForRef.Email, "noreply@hrrriver.com", "", emails + ConfigurationManager.AppSettings["NEWCOMMENTNOTIFICATION"], "You Have A New Goal", sb.ToString(), false, "");
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
                
                <td valign='top' width='100'>
                  <img src='" + ConfigurationManager.AppSettings["BASEURL"] + HRR.Core.ResourceStrings.AvatarBasePath + "thumb_" + goal.EnteredByRef.AvatarPath + @"' border='0' alt='" + goal.EnteredByRef.Name + @"'>
                </td>
                
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
                IdeaSeed.Core.Mail.EmailUtils.SendEmail(nr.EnteredForRef.Email, "noreply@hrrriver.com", "", emails + ConfigurationManager.AppSettings["NEWCOMMENTNOTIFICATION"], "Your Goal Has Been Updated", sb.ToString(), false, "");
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
                  " + review.ChangedByRef.Name + @" Has Updated Your Goal
                  <table width='1' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><div style='height:15px;font-size:15px;line-height:15px;'>&nbsp;</div></td></tr></tbody></table>
                </td>
  </tr>
  <tr>
                
                <td valign='top' width='100'>
                  <img src='" + ConfigurationManager.AppSettings["BASEURL"] + HRR.Core.ResourceStrings.AvatarBasePath + "thumb_" + review.ChangedByRef.AvatarPath + @"' border='0' alt='" + review.ChangedByRef.Name + @"'>
                </td>
                
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
                IdeaSeed.Core.Mail.EmailUtils.SendEmail(nr.EnteredForRef.Email, "noreply@hrrriver.com", "", emails + ConfigurationManager.AppSettings["NEWCOMMENTNOTIFICATION"], "You Have Review Activity", sb.ToString(), false, "");
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
                
                <td valign='top' width='100'>
                  <img src='" + ConfigurationManager.AppSettings["BASEURL"] + HRR.Core.ResourceStrings.AvatarBasePath + "thumb_" + message.SentByRef.AvatarPath + @"' width='50' height='50' border='0' alt='" + message.SentByRef.Name + @"'>
                </td>
                
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
                IdeaSeed.Core.Mail.EmailUtils.SendEmail(sendto.Email, "noreply@hrrriver.com", "", ConfigurationManager.AppSettings["NEWCOMMENTNOTIFICATION"], "You Have New Message Activity", sb.ToString(), false, "");
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


    }
}
