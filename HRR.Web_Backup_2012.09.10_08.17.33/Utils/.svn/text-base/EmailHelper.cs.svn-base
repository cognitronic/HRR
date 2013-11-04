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
            string s = @"<!DOCTYPE HTML PUBLIC '-//W3C//DTD HTML 4.0 Transitional//EN'>
<HTML>
 <HEAD>
  <TITLE> New Document </TITLE>
  <META NAME='Generator' CONTENT='EditPlus'>
  <META NAME='Author' CONTENT=''>
  <META NAME='Keywords' CONTENT=''>
  <META NAME='Description' CONTENT=''>
  <style>
			.maincontainer
			{
				width: 770px;
				float: left;
				clear:both;
				margin-bottom: 20px;
				margin-left: 20px;
			}

			.maincontent
			{
				padding: 5px 5px 5px 5px;
				border-top: solid 1px #898c95;
				border-right: solid 1px #898c95;
				border-bottom: solid 1px #898c95;
				border-left: solid 1px #898c95;
				background-color: #fff;
				font: 12px 'Trebuchet MS', 'Tahoma', 'Verdana', sans-serif;   
				width: 770px;  
			}

			.maincontent span
			{
				color: #4B86D7;
				font-weight: bold;    
			}

			.maincontainer h2
			{
				font: 16px 'Trebuchet MS', 'Tahoma', 'Verdana', sans-serif;
				font-weight: bold;
				color: #267bb1;
				padding-left: 5px;
				margin-bottom: 2px;
			}
            
            td
            {
                padding: 5px 5px 5px 5px;
            }

			body
            {
                font: 12px 'Trebuchet MS', 'Tahoma', 'Verdana', sans-serif;
				color: #0067B8;
            }

			a:hover
            {
                color: #267bb1;
                text-decoration: underline;
                font-weight: bold;
                font: 12px 'Trebuchet MS', 'Tahoma', 'Verdana', sans-serif;
            }

            a
            {
                color: #0067B8;
                text-decoration: underline;
                font-weight: bold;    
                font: 12px 'Trebuchet MS', 'Tahoma', 'Verdana', sans-serif;
            }
  </style>
 </HEAD>

 <BODY>
	<div class='maincontainer'>
    <table style='width: 770px;'>
        <tr>
            <td style='background-color: #00ccff;'>
		        <img src='" + ConfigurationManager.AppSettings["NOTIFICATIONLOGO"] + @"' width='211px' height='31px' alt='Logo' border='0' />
            </td>
        </tr>
    </table>
	</div>
	
";
            return s;
        }

        public static string EmailHTMLEnd()
        {
            string s = @"
 </BODY>
</HTML>";
            return s;
        }
    }
}
