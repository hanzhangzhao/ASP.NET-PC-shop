<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="part4.Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="login-box">
        <div class="login-cont">

            <h1>User Login</h1>
            <p>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </p>

             <asp:Panel ID="Panel1" runat="server" DefaultButton="LoginButton">
            <ul class="login">

                <li class="l-tit">
                    <asp:Label ID="UsernameLabel" runat="server" Text="Username:"></asp:Label>
                </li>
                <li class="mb-10">
                    <asp:TextBox ID="UsernameTextbox" runat="server" CssClass="login-input"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter your username" ControlToValidate="UsernameTextbox" CssClass="validationErr"></asp:RequiredFieldValidator>
                </li>
                <li class="l-tit">
                    <asp:Label ID="PasswordLabel" runat="server" Text="Password:"></asp:Label>
                </li>
                <li class="mb-10">
                    <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password" CssClass="login-input"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter your password" ControlToValidate="PasswordTextBox" CssClass="validationErr"></asp:RequiredFieldValidator>
                </li>

                <li>
                    <asp:HyperLink ID="PasswordRecoveryLink" runat="server" EnableViewState="False" NavigateUrl="~/PasswordRecovery.aspx">Forgot Password?</asp:HyperLink>
                </li>
                <li>
                    <asp:Button ID="LoginButton" runat="server" CssClass="shop-cart" Text="Login" OnClick="LoginButton_Click" />
                    <br />
                    <asp:Label ID="LoginErrorLabel" runat="server" CssClass="validationErr" Visible="False"></asp:Label>
                </li>

            </ul>
                 </asp:Panel>
            <div class="auto-login">
                <asp:HyperLink ID="RegisterHyperLink" runat="server" EnableViewState="False" NavigateUrl="~/Signup.aspx">Not a member? Sign up now</asp:HyperLink>
            </div>
        </div>
    </div>
</asp:Content>
