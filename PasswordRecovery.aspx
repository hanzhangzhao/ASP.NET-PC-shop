<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PasswordRecovery.aspx.cs" Inherits="part4.PasswordRecovery" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <div class="login-box">
        <div class="login-cont">
            <h1>Password Recovery
    </h1>
            <p>
                <asp:ScriptManager ID="ScriptManager" runat="server">
                </asp:ScriptManager>
            </p>
            <p>
                <asp:Label ID="PasswordRecoveryLabel" runat="server"></asp:Label>
            </p>
            <ul class="login">
                <li class="l-tit">
                    <asp:Label ID="UsernameLabel" runat="server" Text="Username:"></asp:Label>
                </li>
                <li class="mb-10">
                    <asp:TextBox ID="UsernameTextbox" runat="server" CssClass="login-input"></asp:TextBox>
                    &nbsp;</li>
                <li class="l-tit">
                    <asp:Label ID="PasswordLabel" runat="server" Text="New Password:"></asp:Label>
                </li>
                <li class="mb-10">
                    <asp:TextBox ID="PasswordTextBox" runat="server" CssClass="login-input" TextMode="Password"></asp:TextBox>
                </li>
                <li class="l-tit">
                    <asp:Label ID="SecurityAnswerLabel" runat="server" Text="Your Nickname is:"></asp:Label>
                </li>
                <li class="mb-10">
                    <asp:TextBox ID="SecurityAnswerTextBox" runat="server" CssClass="login-input"></asp:TextBox>
                </li>
                <li>
                    <asp:Button ID="RecoveryButton" runat="server" CssClass="shop-cart" Text="Submit" OnClick="RecoveryButton_Click"  />
                    <br />
                    <asp:Label ID="PasswordRecoveryErrorLabel" runat="server" CssClass="validationErr" Visible="False"></asp:Label>
                </li>
            </ul>
        </div>
    </div>
</asp:Content>
