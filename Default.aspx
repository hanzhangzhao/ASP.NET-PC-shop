<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="part4.Default" %>
<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="com-width">
        <div class="shop-class fl">
            <div class="shop-class-show">
                <dl class="shop-class-title">
                    <dd>
                        <a href="DIY.aspx">Choose Component</a>
                    </dd>
                </dl>
                <dl class="shop-class-item">
                    <dt>

                        <a href="DIY.aspx" class="b">RAM</a>
                    </dt>
                </dl>
                <dl class="shop-class-item">
                    <dt>
                        <a href="DIY.aspx" class="b">Hard Drive</a>
                    </dt>
                </dl>
                <dl class="shop-class-item">
                    <dt>
                        <a href="DIY.aspx" class="b">CPU</a>
                    </dt>
                </dl>
                <dl class="shop-class-item">
                    <dt>
                        <a href="DIY.aspx" class="b">Display</a>
                    </dt>
                </dl>
                <dl class="shop-class-item">
                    <dt>
                        <a href="DIY.aspx" class="b">OS</a>
                    </dt>
                </dl>
            </div>
        </div>

        <div class="banner com-width clearfix">
            <div id="banner" class="banner-bar banner-big">
                <div id="banner_list" class="img-box">
                    <a href="PreBuiltComp.aspx">
                        <img src="img/banner/banner_01.jpg" alt="banner"></a>
                    <a href="PreBuiltComp.aspx">
                        <img src="img/banner/banner_02.jpg" alt="banner"></a>
                    <a href="PreBuiltComp.aspx">
                        <img src="img/banner/banner_03.jpg" alt="banner"></a>
                    <a href="PreBuiltComp.aspx">
                        <img src="img/banner/banner_04.jpg" alt="banner"></a>
                </div>
                <div class="img-num">
                    <a href="#" class="active">1</a>
                    <a href="#">2</a>
                    <a href="#">3</a>
                    <a href="#">4</a>
                </div>
            </div>
        </div>

        <div class="shop-title com-width">
            <h3>Deal of the Week</h3>

        </div>
        <div class="shop-list com-width clearfix">
            <div class="right-area">
                <div class="shop-list-main clearfix">
                    <div class="shop-item">
                        <div class="shop-img">
                            <a href="../PreBuiltComp.aspx">
                                <img src="~/img/1.jpg" alt="Door Crasher" runat=server></a>
                        </div>
                        <h3>Door Crasher i3/16G/250G/Win10/23'</h3>
                        <p>$731.95</p>
                    </div>
                    <div class="shop-item">
                        <div class="shop-img">
                            <a href="../PreBuiltComp.aspx">
                                <img src="img/2.jpg" alt="Office Computer"></a>
                        </div>
                        <h3>Office Computer i5/32G/2T/Win10/21'</h3>
                        <p>$1125.95</p>
                    </div>
                    <div class="shop-item">
                        <div class="shop-img">
                            <a href="../PreBuiltComp.aspx">
                                <img src="img/8.jpg" alt="Gaming PC"></a>
                        </div>
                        <h3>Gaming PC i7/16G/500G/Win10/27'</h3>
                        <p>$2335.95</p>
                    </div>
                    <div class="shop-item">
                        <div class="shop-img">
                            <a href="../DIY.aspx">
                                <img src="img/4.jpg" alt="Ryzen5"></a>
                        </div>
                        <h3>AMD Ryzen 5 2600 Processor</h3>
                        <p>$299.99</p>
                    </div>
                    <div class="shop-item">
                        <div class="shop-img">
                            <a href="../DIY.aspx">
                                <img src="img/5.jpg" alt="RAM16G"></a>
                        </div>
                        <h3>Corsair 2x8GB DDR4 3000MHz RAM</h3>
                        <p>$104.99</p>
                    </div>
                </div>
            </div>
        </div>

        <p>
            Please enjoy your shopping..
        </p>
    </div>
    <script src='<%=ResolveClientUrl("~/Scripts/default.js") %>' type="text/javascript"></script>
</asp:Content>
