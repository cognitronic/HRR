<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="Documentation.aspx.cs" Inherits="HRR.Website.Documentation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div style="float: right;">
            <div style="float: right; width: 200px; margin-right: 0px !important; padding-right: 0px !important; margin-bottom: 30px;  margin-top: 0px; margin-left: 5px;">
                <div style="background-color: #fff; border-left: 1px solid #d0d0d0; border-bottom: 1px solid #d0d0d0;">
                <h3 style="margin-left: 5px;">Documentation</h3> 
                    <asp:DataList
                    runat="server"
                    Width="199px"
                    CssClass="documentationnav"
                    ID="dlNav">
                        <ItemTemplate>
                            <div runat="server" id="divContainer" style="width: 173px;  margin-left: 5px;">
                            <div style="float: left; padding: 10px 10px; height: 20px; text-align: left; ">
                                <span style="font-size: 12pt;">
                                    <a href='<%# "/Help/" + Eval("Name").ToString().Replace(" ", "-") %>'><%#Eval("Name") %></a>                 
                                </span>
                            </div>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
            </div>
        </div>
        <div style="float: left;">
            <div style="margin-top: 5px;">
                <div style="float: left; width: 540px;  margin-bottom: 30px;">
                    <div class="widgetouter">
                        <div class="widgetinner">
                            <div runat="server" id="divContent" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <br />
    </div>
</asp:Content>
