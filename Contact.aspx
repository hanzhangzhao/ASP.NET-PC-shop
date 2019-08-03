<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="part4.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="com-width">
        <div class="contactContainer">
            <h2>Contact Us</h2>
            <h3>Customer Service</h3>
            <p style="margin: 1em 0; font-size:16px;">Call Us</p>
            <p>If you have any questions call us at <a href="tel:12042309805">1-204-230-9805</a></p>
            <p>We're available 7 days a week from 8:00am to midnight ET.</p>
            <p style="margin: 1em 0; font-size:16px;">Email Us</p>
            <p>If you have any questions email us at:</p>
            <address>
                <strong>Support:</strong>   <a href="mailto:support@tma3.com">support@tma3.com</a><br/>
                <strong>Marketing:</strong> <a href="mailto:marketing@tma3.com">marketing@tma3.com</a>
            </address>
            <p style="margin: 1em 0; font-size:16px;">Visit Us</p>
            <p>Visit us in-store:</p>
            <address>
                172 Bridgeland Dr S<br />
                Winnipeg, MB, Canada<br />
                <abbr title="Phone">Ph:</abbr>
                +12042309805
            </address>

            
        </div>
    </div>
</asp:Content>
