<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DIY.aspx.cs" Inherits="part4.DIY" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="com-width">
        <div class="tableContainer">

            <h1>Customize Your Choice</h1>
            <hr />
            <h3>
                <asp:Label ID="ProcessorLabel" runat="server" Text="Processor"></asp:Label>
            </h3>
            <hr style="border: 1px double #555; width: 60%">
            <div class="DIYimg">
                <img src="img/9.jpg" id="DIYimg1" />
            </div>
            <div class="DIYcontent">
                <asp:GridView ID="ProcessorGridView" runat="server" AllowPaging="True" CssClass="DIYgridView" OnSelectedIndexChanged="GridView_SelectedIndexChanged" GridLines="None" AutoGenerateColumns="False" CellSpacing="10" AutoGenerateSelectButton="True">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" />
                        <asp:BoundField DataField="brand" HeaderText="Brand" />
                        <asp:BoundField DataField="model" HeaderText="Model" />
                        <asp:BoundField DataField="clock" HeaderText="Clock" />
                        <asp:BoundField DataField="Core" HeaderText="Core" />
                        <asp:BoundField DataField="price" HeaderText="Price" />
                        <%--<asp:CommandField SelectText="SELECT" ShowSelectButton="True" />--%>
                    </Columns>
                    <HeaderStyle ForeColor="Black" />
                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                </asp:GridView>
            </div>
            <h3>
                <asp:Label ID="RAMLabel" runat="server" Text="RAM"></asp:Label>
            </h3>
            <hr style="border: 1px double #555; width: 60%">
            <div class="DIYimg">
                <img src="img/5.jpg" id="DIYimg2" />
            </div>
            <div class="DIYcontent">
                <asp:GridView ID="RAMGridView" runat="server" AllowPaging="True" CssClass="DIYgridView" OnSelectedIndexChanged="GridView_SelectedIndexChanged" GridLines="None" AutoGenerateColumns="False" CellSpacing="10" AutoGenerateSelectButton="True">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" />
                        <asp:BoundField DataField="Brand" HeaderText="Brand" />
                        <asp:BoundField DataField="Speed" HeaderText="Speed" />
                        <asp:BoundField DataField="MemoryType" HeaderText="Memory Type" />
                        <asp:BoundField DataField="Price" HeaderText="Price" />
                        
                    </Columns>
                    <HeaderStyle ForeColor="Black" />
                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                </asp:GridView>
            </div>
            <h3>
                <asp:Label ID="HardDriveLabel" runat="server" Text="Hard Drive"></asp:Label>
            </h3>
            <hr style="border: 1px double #555; width: 60%">
            <div class="DIYimg">
                <img src="img/10.jpg" id="DIYimg3" />
            </div>
            <div class="DIYcontent">
                <asp:GridView ID="HardDriveGridView" runat="server" AllowPaging="True" CssClass="DIYgridView" OnSelectedIndexChanged="GridView_SelectedIndexChanged" GridLines="None" AutoGenerateColumns="False" CellSpacing="10" AutoGenerateSelectButton="True">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" />
                        <asp:BoundField DataField="Brand" HeaderText="Brand" />
                        <asp:BoundField DataField="Type" HeaderText="Type" />
                        <asp:BoundField DataField="Size" HeaderText="Size" />
                        <asp:BoundField DataField="Price" HeaderText="Price" />
                        
                    </Columns>
                    <HeaderStyle ForeColor="Black" />
                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                </asp:GridView>
            </div>
            <h3>
                <asp:Label ID="OSLabel" runat="server" Text="Operating System"></asp:Label>
            </h3>
            <hr style="border: 1px double #555; width: 60%">
            <div class="DIYimg">
                <img src="img/11.jpg" id="DIYimg4" />
            </div>
            <div class="DIYcontent">
                <asp:GridView ID="OSGridView" runat="server" AllowPaging="True" CssClass="DIYgridView" OnSelectedIndexChanged="GridView_SelectedIndexChanged" GridLines="None" AutoGenerateColumns="False" CellSpacing="10" AutoGenerateSelectButton="True">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" />
                        <asp:BoundField DataField="Brand" HeaderText="Brand" />
                        <asp:BoundField DataField="Version" HeaderText="Version" />
                        <asp:BoundField DataField="Price" HeaderText="Price" />
                       
                    </Columns>
                    <HeaderStyle ForeColor="Black" />
                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                </asp:GridView>
            </div>
            <h3>
                <asp:Label ID="DisplayLabel" runat="server" Text="Display"></asp:Label>
            </h3>
            <hr style="border: 1px double #555; width: 60%">
            <div class="DIYimg">
                <img src="img/12.jpg" id="DIYimg5" />
            </div>
            <div class="DIYcontent">
                <asp:GridView ID="DisplayGridView" runat="server" AllowPaging="True" CssClass="DIYgridView" OnSelectedIndexChanged="GridView_SelectedIndexChanged" GridLines="None" AutoGenerateColumns="False" CellSpacing="10" AutoGenerateSelectButton="True">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" />
                        <asp:BoundField DataField="Brand" HeaderText="Brand" />
                        <asp:BoundField DataField="Size" HeaderText="Size" />
                        <asp:BoundField DataField="Resolution" HeaderText="Resolution" />
                        <asp:BoundField DataField="ResponseTime" HeaderText="Response Time" />
                        <asp:BoundField DataField="Price" HeaderText="Price" />
                       
                    </Columns>
                    <HeaderStyle ForeColor="Black" />
                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                </asp:GridView>
            </div>
        </div>
        <div class="tableContainer">
            <hr style="border: 1px solid #ff7201;" />
            <asp:Button ID="AddToCartButton" runat="server" CssClass="shop-cart" Text="Add to Cart" OnClick="AddToCartButton_Click" />
        </div>

    </div>
</asp:Content>

