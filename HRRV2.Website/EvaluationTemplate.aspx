<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="EvaluationTemplate.aspx.cs" Inherits="HRRV2.Website.EvaluationTemplate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="/Scripts/HRR.Domain.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        setCurrentMenuItem("nav-evaluations", "subnav-evaluationtemplates");
        loadEvaluationTemplateQuestions(window.location.pathname.split('/').pop());
    </script>
    <div class="page-header"><!-- Page header -->
        <h5><i class="icon-th-large"></i>Evaluation Template</h5>
    </div><!-- /page header -->
    <div class="body">
        <div class="row-fluid form-horizontal">
            <div class="control-group clearfix">
                <div class="span12">
                    <label class="control-label">
                        Title:
                        <span class="req">*</span>
                    </label>
                    <div class="controls">
                        <idea:TextBox
                        runat="server"
                        ID="tbTitle"
                        Width="100%"/>
                        <asp:RequiredFieldValidator
                        runat="server"
                        ID="RequiredFieldValidator3"
                        Display="Dynamic"
                        CssClass="error"
                        ErrorMessage="Enter title."
                        InitialValue=""
                        ControlToValidate="tbTitle" />
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
                        TextMode="MultiLine"
                        Height="50px"
                        ID="tbDescription"
                        Width="100%" />
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
                        TextMode="MultiLine"
                        Height="50px"
                        ID="tbInstructions"
                        Width="100%" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="page-header"><!-- Page header -->
        <h5><i class="icon-th-large"></i>Questions</h5>
    </div><!-- /page header -->
    <div class="body">
        <div class="block well">
            <div class="navbar">
                <div class="navbar-inner">
                    <h5>Questions</h5>
                    <div class="nav pull-right">
                        <span>
                            <a data-toggle="modal" 
                            href="#newTextQuestionModal" 
                            class="btn btn-normal btn-success" 
                            title="New Text Question">
                                <i class="icon-italic"></i> New Text Question
                            </a>
                        </span>
                        <span>
                            <a data-toggle="modal" 
                            href="#newSliderModal" 
                            class="btn btn-normal btn-success" 
                            title="New Slider Question">
                                <i class="icon-list"></i> New Slider Question
                            </a>
                        </span>
                    </div>
                </div>
            </div>
            <div class="table-overflow">
                <table class="table table-striped">
                    <thead>
                        <tr>
                            <th>#</th>
                            <th>Question Text</th>
                            <th>Is Slider</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody id="divQuestions">
                        <tr></tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>

    <div id="newTextQuestionModal" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myTextQuestionLabel" aria-hidden="true">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
            <h5 id="myTextQuestionLabel"><i class="icon-italic"></i> Create a new text question</h5>
        </div>
        <div class="modal-body">
            <div id="div3" class="row-fluid">
                <div class="control-group clearfix">
                    <div class="span12">
                        <label class="control-label">
                            <strong>Question:</strong>
                        </label>
                        <div class="controls">
                            <idea:TextBox
                            runat="server"
                            ID="text_Question"
                            Width="100%"
                            TextMode="MultiLine"
                            Height="40px"
                            Skin="Metro" />
                        </div>
                    </div>
                </div>
                <div class="form-actions modal-footer">
                    <button id="btnSaveTextQuestion" title="Save Question" data-toggle="modal" class="btn btn-small btn-success" href="#newTextQuestionModal" >
                        <i class="icon-plus"></i> Save 
                    </button>
                    <a href='' title="Cancel" data-dismiss="modal" class="btn btn-small btn-danger">
                        <i class="icon-remove"></i> Cancel
                    </a>               
                </div>
            </div>
        </div>
    </div>

    <div id="newSliderModal" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="mySliderLabel" aria-hidden="true">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
            <h5 id="mySliderLabel"><i class="icon-list"></i> Create a new rating question</h5>
        </div>
        <div class="modal-body">
            <div id="div2" class="row-fluid">
                <div class="control-group clearfix">
                    <div class="span12">
                        <label class="control-label">
                            <strong>Question:</strong>
                        </label>
                        <div class="controls">
                            <idea:TextBox
                            runat="server"
                            ID="slider_Question"
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
                            <strong>Enter up to 5 rating options</strong>
                        </label>
                        <div class="controls">
                            <table>
                                <tbody>
                                    <tr>
                                        <td>
                                            <idea:TextBox
                                            runat="server"
                                            ID="tbSliderLabel1"
                                            Width="500px"
                                            Skin="Metro" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <idea:TextBox
                                            runat="server"
                                            ID="tbSliderLabel2"
                                            Width="500px"
                                            Skin="Metro" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <idea:TextBox
                                            runat="server"
                                            ID="tbSliderLabel3"
                                            Width="500px"
                                            Skin="Metro" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <idea:TextBox
                                            runat="server"
                                            ID="tbSliderLabel4"
                                            Width="500px"
                                            Skin="Metro" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <idea:TextBox
                                            runat="server"
                                            ID="tbSliderLabel5"
                                            Width="500px"
                                            Skin="Metro" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
                <div class="form-actions modal-footer">
                    <button id="btnSaveSliderQuestion" title="Save Question" data-toggle="modal" class="btn btn-small btn-success" href="#newSliderModal" >
                        <i class="icon-plus"></i> Save 
                    </button>
                    <a href='' title="Cancel" data-dismiss="modal" class="btn btn-small btn-danger">
                        <i class="icon-remove"></i> Cancel
                    </a>               
                </div>
            </div>
        </div>
    </div>

    <script>
        $("#btnSaveTextQuestion").click(function (e) {

            e.preventDefault();  //prevent default form submit behaviour
            var label = "";
            var _question = new PerformanceEvaluationTemplateQuestion();
            _question.Question = $("#ctl00_MainContent_text_Question").val();
            _question.PerformanceEvaluationTemplateID = $("#ctl00_MainContent_text_Question").attr("templateID");
            saveEvaluationQuestion(_question, $("#divQuestions"));
        });

        $("#btnSaveSliderQuestion").click(function (e) {

            e.preventDefault();  //prevent default form submit behaviour
            var label = "";
            var _slidervals = [];
            var valcount = 0;
            var _question = new PerformanceEvaluationTemplateQuestion();
            _question.Question = $("#ctl00_MainContent_slider_Question").val();
            _question.PerformanceEvaluationTemplateID = $("#ctl00_MainContent_slider_Question").attr("templateID");

            if ($("#ctl00_MainContent_tbSliderLabel1").val() != "") {
                valcount++;
                var slider = new PerformanceEvaluationSliderValue();
                slider.Title = $("#ctl00_MainContent_tbSliderLabel1").val();
                _slidervals.push(slider);
            }
            if ($("#ctl00_MainContent_tbSliderLabel2").val() != "") {
                valcount++;
                var slider = new PerformanceEvaluationSliderValue();
                slider.Title = $("#ctl00_MainContent_tbSliderLabel2").val();
                _slidervals.push(slider);
            }
            if ($("#ctl00_MainContent_tbSliderLabel3").val() != "") {
                valcount++;
                var slider = new PerformanceEvaluationSliderValue();
                slider.Title = $("#ctl00_MainContent_tbSliderLabel3").val();
                _slidervals.push(slider);
            }
            if ($("#ctl00_MainContent_tbSliderLabel4").val() != "") {
                valcount++;
                var slider = new PerformanceEvaluationSliderValue();
                slider.Title = $("#ctl00_MainContent_tbSliderLabel4").val();
                _slidervals.push(slider);
            }
            if ($("#ctl00_MainContent_tbSliderLabel5").val() != "") {
                valcount++;
                var slider = new PerformanceEvaluationSliderValue();
                slider.Title = $("#ctl00_MainContent_tbSliderLabel5").val();
                _slidervals.push(slider);
            }
            _question.SliderValues = _slidervals;
            saveEvaluationSliderQuestion(_question, $("#divQuestions"));
        });
    </script>
</asp:Content>
