<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PreBuiltComp.aspx.cs" Inherits="part4.PreBuiltComp" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="com-width">
        <div class="tableContainer">
            <h1>Pre-Built Computers</h1>
            <hr />
            <div class="tableImg">
                <img src="img/1.jpg" class="prebuiltImg" />
                <img src="img/2.jpg" class="prebuiltImg" />
                <img src="img/6.jpg" class="prebuiltImg" />
                <img src="img/7.jpg" class="prebuiltImg" />
                <img src="img/8.jpg" class="prebuiltImg" />
            </div>
            <div class="tableContent">
                <asp:GridView ID="PreBuiltComputersGridView" runat="server" CssClass="gridView" OnSelectedIndexChanged="PreBuiltComputersGridView_SelectedIndexChanged" GridLines="None" AutoGenerateColumns="False" CellSpacing="5">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" />
                        <asp:BoundField DataField="System" HeaderText="Configuration of The Build" HtmlEncode="false" />
                        <asp:BoundField DataField="Price" HeaderText="Price" ItemStyle-HorizontalAlign="Center" />
                        <asp:CommandField SelectText="SELECT" ShowSelectButton="True" />
                    </Columns>
                    <HeaderStyle ForeColor="Black" />
                    <RowStyle Height="100px" Width="800px" />
                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                </asp:GridView>
            </div>
        </div>
        <div class="tableContainer">
            <hr style="border: 1px solid #ff7201;" />
            <asp:Button ID="DIYButton" runat="server" Text="Customize Your Choice" PostBackUrl="~/DIY.aspx" CssClass="shop-cart" />
            <asp:Button ID="AddCartButton" runat="server" Text="Add to Cart" OnClick="AddCartButton_Click" CssClass="shop-cart" />
        </div>
    </div>
</asp:Content>
