<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="InactivePeople.aspx.cs" Inherits="HRRV2.Website.InactivePeople" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:RadAjaxManagerProxy ID="rampComments" runat="server" >
        <AjaxSettings>
            <%--<telerik:AjaxSetting AjaxControlID="ddlTeams">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="divComments" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ddlSort">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="divComments" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="divComments">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="divComments" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>--%>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Simple" Transparency="15" />
   
   <script type="text/javascript">
       setCurrentMenuItem("nav-people", "subnav-inactivestaff");
    </script>
    <div class="page-header">
        <h5><i class="icon-th-large"></i>These Employees Are Missing Required Setup Information</h5>
    </div>
    <div class="body">

        <div class="row-fluid">
            <div class="span12">
                <div class="block well">
                    <div class="navbar">
                        <div class="navbar-inner">
                            <h5>
                                Select the appropriate values and assign to employees
                            </h5>
                        </div>
                    </div>
                    <div id="employeefilters" class="collapse in">
                        <div class="span12">
                            <div class="row-fluid">
                                <div class="clearfix" />
                                <div class="body">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td>
                                                Is Manager:
                                            </td>
                                            <td> 
                                                <idea:CheckBox
                                                runat="server"
                                                ID="cbIsManagerFilter" />
                                            </td>
                                            <td>
                                                Hire Date:
                                            </td>
                                            <td> 
                                                <telerik:RadDatePicker 
                                                ID="tbHireDateFilter"
                                                Skin="Metro"
                                                MinDate="1/1/1970"
                                                runat="server">
                                                    <DateInput ID="diHireDateFilter" runat="server"
                                                        DateFormat="MM/dd/yyyy"></DateInput>
                                                </telerik:RadDatePicker>
                                            </td>
                                            <td>
                                                Security Role:
                                            </td>
                                            <td> 
                                                <idea:SecurityRolesDDL
                                                runat="server"
                                                ID="ddlSecurityRoleFilter" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                               Manager:
                                            </td>
                                            <td> 
                                               <idea:ManagersDDL
                                               runat="server"
                                               ID="ddlManagerFilter" />
                                            </td>
                                            <td>
                                                Department:
                                            </td>
                                            <td>  
                                                <idea:DepartmentsDDL
                                                runat="server"
                                                ID="ddlDepartmentFilter" />
                                            </td>
                                            <td>
                                                Team: 
                                            </td>
                                            <td> 
                                                <idea:TeamsDDL
                                                runat="server"
                                                ID="ddlTeamFilter" />
                                            </td>
                                        </tr>
                                    </table>
                                    <div class="form-actions">
                                        <span>
                                            <idea:LinkButton
                                            runat="server"
                                            OnClick="SaveClicked"
                                            ID="lbSave"
                                            CssClass="btn btn-small btn-info">
                                                Save
                                            </idea:LinkButton>
                                        </span>&nbsp;
                                        <span>
                                            <idea:LinkButton
                                            runat="server"
                                            OnClick="CancelClicked"
                                            CausesValidation="false"
                                            ID="lbCancel"
                                            CssClass="btn btn-small btn-danger">
                                                Cancel
                                            </idea:LinkButton>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="page-header">
        <h5><i class="icon-th-large"></i>Staff List</h5>
    </div>
    <div class="body">
        <div>
            <div runat="server" id="divStaff">
                <asp:DataList
                runat="server"
                OnItemDataBound="ItemDataBound"
                OnItemCommand="StaffItemCommand"
                style="width: 100%;"
                ID="dlPeople">
                    <ItemTemplate>
                        <div class="media" style=" border-bottom: 1px solid #dadada; margin-bottom: 20px;" runat="server" id="divRow">
                            <div style="float: left; margin-right: 5px;">
                                <idea:CheckBox
                                runat="server"
                                itemid='<%# Eval("ID") %>'
                                ID="cbSelected" />
                            </div>
                            <div class="pull-left">
                                <a href="#" title="">
                                    <telerik:RadBinaryImage ID="rbiProfile"
                                    runat="server"
                                    AutoAdjustImageControlSize="true"
                                    ResizeMode="Fit"
                                    Height="25"
                                    Width="25"
                                    style="padding: 0px 0px 0px 0px;"/>
                            
                                </a>
                            </div>
                            <div class="media-body">
                                <div style="float:left; width: 400px;">
                                    <b class="media-heading">
                                        <%# Eval("Name") %>
                                    </b> 
                                </div>
                                <div >
                                    <b>Missing Info:</b> 
                                    <idea:Label
                                    runat="server"
                                    ID="lblMissingInfo" />
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>

                </asp:DataList>
                <h6 class="subtitle">
                    <asp:label id="lblCurrentPage" runat="server"></asp:label>
                </h6>
                <div class="well-smoke well-small body">
                    <ul class="pager" runat="server" id="commentsPager">
                    <li class="previous">
                        <idea:LinkButton
                        runat="server"
                        OnClick="PrevClicked"
                        ID="cmdPrev">
                            Previous
                        </idea:LinkButton>
                    </li>
                    <li class="next">
                        <idea:LinkButton
                        OnClick="NextClicked"
                        runat="server"
                        ID="cmdNext">
                            Next
                        </idea:LinkButton>
                    </li>
                </ul>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

