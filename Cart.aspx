<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="part4.Cart" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="com-width">
        <div class="tableContainer">
            <h1>Your Cart</h1>
            <hr />
            <h3>
                <asp:Label ID="EmptyCartLabel" runat="server" Text="Looks like it's empty, why not go to Pre-Built and add something." Visible="False"></asp:Label>
            </h3>
 
            <asp:GridView ID="CartGridView" runat="server" CssClass="CartgridView" OnRowDeleting="CartGridView_RowDeleting" AutoGenerateColumns="False" OnRowEditing="CartGridView_RowEditing" GridLines="None" CellSpacing="10">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" />
                    <asp:BoundField DataField="System" HeaderText="Configuration of The Build" HtmlEncode="false" />
                    <asp:BoundField DataField="Price" HeaderText="Price" ItemStyle-HorizontalAlign="Center" />
<%--                    <asp:CommandField ShowEditButton="True" EditText="Modify" ItemStyle-Font-Bold="true" ItemStyle-ForeColor="Green"/>--%>
                    <asp:CommandField ShowDeleteButton="True" DeleteText="Remove" ItemStyle-Font-Bold="true" ItemStyle-ForeColor="Red" ItemStyle-Wrap="true"/>
                </Columns>
                <HeaderStyle ForeColor="Black" />
                <SelectedRowStyle BackColor="#33CC33" BorderColor="#003300" ForeColor="Black" />
            </asp:GridView>
            <hr style="border: 1px solid #ff7201;" />
            <h2>
                <asp:Label ID="TotalCartPriceLabel" runat="server"></asp:Label>
            </h2>
        </div>
    </div>
</asp:Content>



