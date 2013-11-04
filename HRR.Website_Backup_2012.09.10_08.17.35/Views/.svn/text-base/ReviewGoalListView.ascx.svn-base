<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReviewGoalListView.ascx.cs" Inherits="HRR.Website.Views.ReviewGoalListView" %>
    <div class="containerouter">
        <div class="containerinner">
            <h3>Goals</h3>
            <asp:DataList
            runat="server"
            OnItemDataBound="ItemDataBound"
            ID="dlComments">
                <ItemTemplate>
                    <div style="padding: 5px;">
                        <span style="font-weight: bolder"><%# Eval("Title") %>  </span><br />
                        <span style="color: #000000;">Status: <span style="color: #0000ff; margin-right: 10px;"><%# Enum.GetName(typeof(HRR.Core.Domain.GoalStatus), Eval("StatusID")) %></span></span>
                        <span style="color: #000000;">Due: <span style="color: #0000ff; margin-right: 10px;"><%# DateTime.Parse(Eval("DueDate").ToString()).ToShortDateString() %></span></span><br />
                        <%# Eval("Description") %> <br /><a href='/Goals/<%# Eval("ID") %>'>View</a>
                    </div>
                    <hr />
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>