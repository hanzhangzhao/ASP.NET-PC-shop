<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Feedback.aspx.cs" Inherits="part4.Feedback" %>

<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="com-width">
        <div class="contactContainer">
            <h1>Feedback</h1>
            <hr />
            <div>
                <div style="width: 300px; display: inline-block; vertical-align: top">Your Name:</div>
                <asp:TextBox ID="FeedbackName" runat="server" Height="20px" Width="500px" OnTextChanged="TextChanged" BorderStyle="Solid"></asp:TextBox>
            </div>
            <br />
            <div>
                <div style="width: 300px; display: inline-block; vertical-align: top">Please leave your feedbacks here:</div>
                <asp:TextBox ID="FeedbackContent" runat="server" Height="150px" TextMode="MultiLine" Width="500px" OnTextChanged="FeedbackTextChanged" BorderStyle="Solid"></asp:TextBox>
            </div>
            <hr />
            <asp:Button OnClick="FeedbackSubmit" Text="Submit" runat="server" CssClass="shop-cart" />
            <div>
                <asp:Label ID="FeedbackErrorLabel" runat="server" Text="Please fill in all the forms then submit." ForeColor="Red"></asp:Label>
            </div>

            <hr />
            <%--<asp:GridView ID="FeedbackGridView" runat="server" CssClass="gridView" AutoGenerateColumns="False" Width="50px">
                <Columns>
                    <asp:BoundField DataField="Username" HeaderText="Username" />
                    <asp:BoundField DataField="feedbackText" HeaderText="Comment" HtmlEncode="false" />
                </Columns>
            </asp:GridView>--%>
        </div>
        <div>
            <asp:Repeater ID="FeedbackDisp" runat="server">
                <HeaderTemplate>
                    <table style="border-bottom: 4px double black;margin-left:0">
                        <tr>
                            <td style="width:10vw"><b>Username</b></td>
                            <td style="width:36vw"><b>Feedback</b></td>
                        </tr>
                    </table>
                </HeaderTemplate>
                <ItemTemplate>
                    <table style="margin-left:0">
                        <tr>
                            <td style="width:10vw"><%# DataBinder.Eval(Container.DataItem, "username") %></td>
                            <td style="width:36vw"><%# DataBinder.Eval(Container.DataItem, "feedbackText") %></td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>

</asp:Content>

