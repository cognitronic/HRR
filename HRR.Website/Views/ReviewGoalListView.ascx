<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReviewGoalListView.ascx.cs" Inherits="HRR.Website.Views.ReviewGoalListView" %>
<telerik:RadCodeBlock runat="server" ID="rcbGoalListView">
    <script language="javascript" type="text/javascript">
        $(window).load(function () {
            loadProgress();
        });

        function loadProgress() {
            $(".progress").each(function () {
                var v = eval($(this).attr("goalid"));
                if (v == 0)
                    v = 1;
                $(this).progressbar({
                    value: v
                }).children("span").appendTo(this);
                $(this).find(".progresslabelingrid").html($(this).attr("goalid") + "% complete");
            });
        }
    </script>  
</telerik:RadCodeBlock>
    <div class="containerouter">
        <div class="containerinner">
            <h3>Goals</h3>
            <asp:DataList
            runat="server"
            Width="100%"
            OnItemDataBound="ItemDataBound"
            ID="dlComments">
                <ItemTemplate>
                    <div style="padding: 5px;">
                        <span style="font-weight: bolder"><%# Eval("Title") %>  </span><br />
                        <span>
                            <%# Eval("Description") %> <br />
                        </span>
                    </div>
                    <div>
                        <div style="float: left; width: 350px;">
                            <div>
                                <div>Due Date:</div>
                                <span style="color: #267BB1; font-weight: bold; margin-right: 10px;"><%# DateTime.Parse(Eval("DueDate").ToString()).ToShortDateString() %></span>
                            </div>
                            <div>
                                <div>Goal Weight:</div>
                                <span style="color: #267BB1; font-weight: bold; margin-right: 10px;"><%# Eval("Weight") %></span>
                            </div>
                        </div>
                        <div style="float: left;"> 
                            <div>
                                <div>Progress:</div>
                                <div id="progressbar" 
                                class="progress" 
                                goalid="<%# Eval("Progress") %>"
                                title="<%# Eval("Progress") %>  % complete"
                                style="vertical-align: top; margin-left: 0px; 
                                margin-bottom: 5px; 
                                width:200px; 
                                height:2em; ">
                                    <idea:Label
                                        runat="server"
                                        ID="lblProgressText" class="progresslabelingrid"/>
                                </div>
                            </div>
                            <div>
                                <div>Rating:</div>
                                <span style="color: #267BB1; font-weight: bold; margin-right: 10px;"><%# Eval("Score") %></span>
                            </div>
                        </div>
                    </div><br />
                    <div style="clear:left; margin-bottom: 30px;">
                        <a class="button big round sky-blue" href='/Goals/<%# Eval("ID") %>'>View</a>
                    </div>
                    <hr />
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>