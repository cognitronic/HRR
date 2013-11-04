<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="ImportStaff.aspx.cs" Inherits="HRRV2.Website.ImportStaff" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        setCurrentMenuItem("nav-people", "");
    </script>
    <div class="page-header">
        <h5><i class="icon-th-large"></i>Import Employees</h5>
    </div>
    <div class="body">
        <div>
            <div style="float: left;">
                <span>Upload a comma separated list (.csv) of employees</span><br />
                <telerik:RadUpload
                runat="server"
                ID="ruImport"
                AllowedFileExtensions=".txt,.csv"
                ControlObjectsVisibility="None"
                MaxFileInputsCount="1"
                MaxFileSize="1002400">
                </telerik:RadUpload>
                <div>
                    <asp:Button
                    runat="server"
                    ID="btnImport"
                    CssClass="btn btn-small btn-info"
                    Text="Import Subscribers"
                    Height="30px"
                    OnClick="ImportClicked" /><br /><br />
                    <telerik:RadProgressManager  
                    id="Radprogressmanager1" 
                    runat="server" />
                    <telerik:RadProgressArea 
                    id="RadProgressArea1" 
                    Skin="Metro"
                    runat="server" />
                </div>
            </div>
            <div runat="server" id="divImportLabels" style="float: left; ">
                <div>
                    <span>
                        # Employees Ready For Import:
                    </span>
                    <span>
                        <idea:Label
                        runat="server"
                        ForeColor="Green"
                        ID="lblReadyForImport">
                        </idea:Label>
                    </span>
                </div>
                <div>
                    <span>
                        # Employees Imported:
                    </span>
                    <span>
                        <idea:Label
                        runat="server"
                        ForeColor="#0067B8"
                        ID="lblEmailsImported">
                        </idea:Label>
                    </span>
                </div>
                <div>
                    <span>
                        # Employees Skipped (Invalid or Duplicate):
                    </span>
                    <span>
                        <idea:Label
                        ForeColor="Red"
                        runat="server"
                        ID="lblEmailsSkipped">
                        </idea:Label>
                    </span>
                </div>
            </div>
            <div class="clear"></div>
        </div>
    </div>
</asp:Content>
