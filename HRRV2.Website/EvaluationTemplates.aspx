<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="EvaluationTemplates.aspx.cs" Inherits="HRRV2.Website.EvaluationTemplates" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="/Scripts/HRR.Domain.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<div class="page-header"><!-- Page header -->
    <h5><i class="icon-th-large"></i>Evaluation Templates</h5>
</div><!-- /page header -->
<div class="body">
    <telerik:RadListView
    runat="server"
    OnItemDataBound="ItemDataBound"
    OnItemCommand="EvaluationTemplateItemCommand"
    style="width: 100%;"
    AllowPaging="true"
    DataKeyNames="ID"
    ID="dlEvaluationTemplates">
        <LayoutTemplate>
            <div class="block well">
            	<div class="navbar">
                	<div class="navbar-inner">
                    	<h5>Templates</h5>
                        <div class="nav pull-right">
                            <a data-toggle="modal" 
                            href="#newTextQuestion" 
                            class="btn btn-normal btn-success" 
                            title="New Text Question">
                                <i class="icon-plus"></i> Add New Template
                            </a>
                        </div>
                    </div>
                </div>
                <div class="table-overflow">
                    <table class="table table-striped">
                        <thead>
                            <tr>
                                <th>Title</th>
                                <th>Description</th>
                                <th>Instructions</th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr id="itemPlaceholder" runat="server"></tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%# Eval("Title") %>
                </td>
                <td>
                    <%# Eval("Description") %>
                </td>
                <td>
                    <%# Eval("Instructions") %>
                </td>
                <td style="min-width: 75px;">
                    
                    <idea:LinkButton
                    runat="server"
                    ID="lbEditTemplate"
                    OnClick="EditTemplateClicked"
                    ToolTip="Edit Template"
                    itemid='<%# Eval("ID") %>'
                    CssClass="btn btn-small btn-success btn-block" >
                        <i class="icon-pencil"></i> Edit
                    </idea:LinkButton>
                    <idea:LinkButton
                    runat="server"
                    ID="lbDeleteTemplate"
                    OnClick="DeleteTemplateClicked"
                    ToolTip="Delete Template"
                    CssClass="btn btn-small btn-danger btn-block" >
                        <i class="icon-remove"></i> Delete
                    </idea:LinkButton>
                </td>
            </tr>
        </ItemTemplate>
        <EmptyDataTemplate>
            <tr>
                <td colspan="4">
                    <span>
                        <h6>No Records Found</h6>
                    </span>
                </td>
            </tr>
        </EmptyDataTemplate>

    </telerik:RadListView>
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
<div id="newTextQuestion" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myTextQuestionLabel" aria-hidden="true">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
            <h5 id="myTextQuestionLabel"><i class="icon-th-large"></i> Create a new evaluation template</h5>
        </div>
        <div class="modal-body">
        <div id="div3" class="row-fluid">
                <div class="control-group clearfix">
                    <div class="span12">
                        <label class="control-label">
                            Title:
                        </label>
                        <div class="controls">
                            <idea:TextBox
                            runat="server"
                            ID="tbTitle"
                            Width="100%"
                            Skin="Metro" />
                        </div>
                    </div>
                </div>
                <div class="control-group clearfix">
                    <div class="span12">
                        <label class="control-label">
                            Description:
                        </label>
                        <div class="controls">
                            <idea:TextBox
                            runat="server"
                            ID="tbDescription"
                            Width="100%"
                            TextMode="MultiLine"
                            Height="40px"
                            Skin="Metro" />
                        </div>
                    </div>
                </div>
                <div class="control-group clearfix">
                    <div class="span12">
                        <label class="control-label">
                            Instructions:
                        </label>
                        <div class="controls">
                            <idea:TextBox
                            runat="server"
                            ID="tbInstructions"
                            Width="100%"
                            TextMode="MultiLine"
                            Height="40px"
                            Skin="Metro" />
                        </div>
                    </div>
                </div>
                <div class="form-actions modal-footer">
                    <button id="btnSaveTemplate" title="Save Question" class="btn btn-small btn-success">
                        <i class="icon-plus"></i> Save 
                    </button>
                    <a href='' title="Cancel" data-dismiss="modal" class="btn btn-small btn-danger">
                        <i class="icon-remove"></i> Cancel
                    </a>               
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">

        $("#btnSaveTemplate").click(function (e) {

            e.preventDefault();  //prevent default form submit behaviour
            var label = "";
            var _template = new PerformanceEvaluationTemplate();
            _template.Title = $("#ctl00_MainContent_tbTitle").val();
            _template.Description = $("#ctl00_MainContent_tbDescription").val();
            _template.Instructions = $("#ctl00_MainContent_tbInstructions").val();
            $.ajax({
                url: 'http://hrrv2.localhost/api/Evaluation/CreateTemplate',
                type: 'POST',
                data: JSON.stringify(_template),
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                success: function (data) {
                    window.location = data.split(':')[2];
                    $('#mainwrapper').effect("highlight", { color: "#7fd658" }, 1000);
                },
                error: function (x, y, z) {
                    alert(x + '\n' + y + '\n' + z);
                }
            });
        });

    </script>
</asp:Content>
