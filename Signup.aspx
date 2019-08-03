<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="part4.Signup" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="login-box">
        <div class="login-cont">

            <h1>User Signup</h1>
            <p>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </p>

            <ul class="login">

                <li class="l-tit">
                    <asp:Label ID="UsernameLabel" runat="server" Text="Username:"></asp:Label>
                </li>
                <li class="mb-10">
                    <asp:TextBox ID="UsernameTextbox" runat="server" CssClass="login-input"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter your username." ControlToValidate="UsernameTextbox" CssClass="validationErr"></asp:RequiredFieldValidator>
                </li>

                <li class="l-tit">
                    <asp:Label ID="PasswordLabel" runat="server" Text="Password:"></asp:Label>
                </li>
                <li class="mb-10">
                    <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password" CssClass="login-input"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter your password." ControlToValidate="PasswordTextBox" CssClass="validationErr"></asp:RequiredFieldValidator>
                </li>
                <li class="l-tit">
                    <asp:Label ID="SecurityQLabel" runat="server" Text="Your Nickname (used as pw recovery question):"></asp:Label>
                </li>
                <li class="mb-10">
                    <asp:TextBox ID="SecurityQTextBox" runat="server" CssClass="login-input"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please enter your security answer." ControlToValidate="PasswordTextBox" CssClass="validationErr"></asp:RequiredFieldValidator>
                </li>
                <li>
                    <asp:Button ID="SignupButton" runat="server" CssClass="shop-cart" Text="Sign Up" OnClick="SignupButton_Click" />
                    <br />
                    <asp:Label ID="SignupErrorLabel" runat="server" CssClass="validationErr" Visible="False"></asp:Label>
                </li>

            </ul>
        
        </div>
    </div>
</asp:Content>

