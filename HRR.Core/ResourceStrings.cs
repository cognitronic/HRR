using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace HRR.Core
{
    public class ResourceStrings
    {
        #region Session
        public static string Session_CurrentItem = "CurrentItem";
        public static string Session_CurrentPoll = "CurrentPoll";
        public static string Session_CurrentBaseURL = "Current_BaseURL";
        public static string Session_CurrentPreviousURL = "Current_PreviousURL";
        public static string Session_CurrentPage = "Current_Page";
        public static string Session_CurrentCustomer = "Current_Customer";
        public static string Session_CurrentProfile = "Current_Profile";
        public static string Session_CurrentShoppingCart = "Current_ShoppingCart";
        public static string Session_CurrentUser = "Current_User";
        public static string Session_CurrentAccessLevel = "Current_AccessLevel";
        public static string Session_IsAuthenticated = "Is_Authenticated";
        public static string Session_MasterPageContext = "MasterPageContext";
        public static string Session_ApplicationContext = "ApplicationContext";
        public static string Session_DisplayLoggedOnUser = "DisplayLoggedOnUser";
        public static string Session_DisplaySearch = "DisplaySearch";
        public static string Session_DisplayLogo = "DisplayLogo";
        public static string Session_DisplaySettingsLinks = "DisplaySettingsLinks";
        public static string Session_DisplayPrimaryNav = "DisplayPrimaryNav";
        public static string Session_DisplaySubNav = "DisplaySubNav";
        public static string Session_DisplayMainToolBar = "DisplayMainToolBar";
        public static string Session_Comments = "CommentsList";
        public static string Session_AdminNavText = "AdminNavText";
        public static string Session_SubNavText = "SubNavText";
        public static string Session_MainContentContainer = "MainContentContainer";
        public static string Session_SideBarContainer = "SideBarContainer";
        public static string Session_ToolBarContainer = "ToolBarContainer";
        public static string Session_CurrentPageSize = "CurrentPageSize";
        public static string Session_CurrentSortOrder = "CurrentSortOrder";
        public static string Session_BannerImageData = "BannerImageData";
        public static string Session_HomeBlogListData = "HomeBlogListData";
        public static string Session_Account = "CurrentAccount";
        public static string Session_CurrentBlogPostType = "CurrentBlogPostType";
        public static string Session_CurrentBlog = "CurrentBlog";
        public static string Session_CurrentTeamID = "CurrentTeamID";
        public static string Session_CurrentReview = "CurrentReview";

        #endregion

        #region Cache
        public static string Cache_Comments = "Comments";
        public static string Cache_AdminNavData = "AdminNavData";
        public static string Cache_HomeBlogData = "HomeBlogData";
        public static string Cache_BannerImagesData = "BannerImagesData";
        public static string Cache_HomeSideBarData = "HomeSideBarData";
        public static string CouchbaseCache_ActivityFeed = "_ActivityFeed";
        public static string CouchbaseCache_AlertsFeed = "_AlertsFeed";
        public static string CouchbaseCache_CommentsFeed = "_CommentsFeed";
        public static string CouchbaseCache_DepartmentsList = "_DepartmentsList";
        #endregion

        #region Page Paths
        public static string Page_FullWidthPath = "~/FullWidth.aspx";
        public static string Page_Documentation = "~/Documentation.aspx";
        public static string Page_FullWidthUnsecuredPath = "~/FullWidthUnsecured.aspx";
        public static string Page_TwoColumnPath = "~/TwoColumn.aspx";
        public static string Page_ThreeColumnPath = "~/ThreeColumn.aspx";
        public static string Page_Default = "/Overview";
        public static string Page_Login = "/Login";
        public static string Page_Logout = "/Logout";
        public static string Page_ForgotPassword = "~/ForgotPassword.aspx";
        public static string Page_AdminLanding = "/Pages.aspx";
        public static string Page_MyAccount = "/Account";
        public static string Page_MyWishlist = "/Wishlist";
        public static string Page_MyCart = "/Cart";
        public static string Page_Checkout = "/Checkout";
        public static string Page_Users = "/Users";
        public static string Page_ManagedLists = "/Managed-Lists";
        public static string Page_Settings = "/Settings";
        public static string Page_Profile_ReadOnly = "~/Profile.aspx";
        public static string Page_Profile_Edit = "~/EditProfile.aspx";
        public static string Page_Evaluation_Template_Edit = "/Evaluations/Templates/"; 

        #region Admin Pages
        public static string Page_Admin_Default = "Pages";
        public static string Page_Admin_Default_Path = "~/Default.aspx";
        public static string Page_Admin_FullWidthPath = "~/FullWidth.aspx";
        #endregion

        #endregion

        #region Accounts
        public static string Contact_AvatarPath = ConfigurationManager.AppSettings["CONTACT_PROFILEIMAGEPATH"];
        #endregion

        #region Icons
        public static string Icon_HistoryLink = "/Images/page_white_star.png";
        #endregion

        #region Global
        public static string NoImageFound = ConfigurationManager.AppSettings["NOPHOTOIMAGE"];
        public static string AppResourcePath = ConfigurationManager.AppSettings["APP_RESOURCE_PATH"];
        public static string BaseURL = ConfigurationManager.AppSettings["BASEURL"];
        public static string ProductCategoryImagePath = "~/Images/ProductCategory/";
        public static string ProductImagePath = "~/Images/Product/";
        public static string DummyImagePath = "/Images/avatars/notavailable.png";
        public static string DefaultImageNotFound = "notavailable.png";
        public static string DefaultTeamThumbImage = "team.png";
        public static string Cookie_Name = "IdeaseedCart";
        public static string AvatarBasePath = "/Images/Avatars/";
        public static string GravatarBasePath = "http://www.gravatar.com/avatar/";
        #endregion
    }
}
