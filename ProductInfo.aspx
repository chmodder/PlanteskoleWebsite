<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProductInfo.aspx.cs" Inherits="ProductInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <h3 class="ChildContainerHeader">Butikken</h3>
    <asp:Repeater ID="ItemInfoRpt" runat="server" OnItemCommand="ItemInfoRpt_ItemCommand">
        <ItemTemplate>

            <asp:HiddenField ID="hfId" Value='<%# Eval("ProductId")%>' runat="server" />

            <div class="ContactMiddleContainer100">

                <asp:Label ID="NameLbl" CssClass="H2Middle" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
            </div>

            <div class="DefaultMiddleContainer100">
                <asp:Repeater ID="ImageRpt" runat="server" DataSourceID="ProductImagesODS">
                    <ItemTemplate>
                        <img width="120" height="90" src='<%#"Img/Products/" + Eval("FileName") %>' />
                    </ItemTemplate>
                </asp:Repeater>
                <asp:ObjectDataSource runat="server" ID="ProductImagesODS" SelectMethod="GetProductImages" TypeName="DataAccessLayer">
                    <SelectParameters>
                        <asp:QueryStringParameter QueryStringField="ItemId" Name="productId" Type="Int32"></asp:QueryStringParameter>
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>

            <div class="DefaultMiddleContainer100">
                <asp:Label ID="ItemDescLbl" CssClass="" runat="server" Text='<%#Eval("Description") %>'></asp:Label>
            </div>

            <div class="DefaultMiddleContainer100">
                <div>
                    <asp:Label ID="SoilTypeLbl" CssClass="" runat="server" Text='<%#Eval("SoilType") %>'></asp:Label>
                    <asp:Label ID="CultivationTimeLbl" CssClass="" runat="server" Text='<%#Eval("CultivationTime") %>'></asp:Label>
                    <asp:Label ID="ProductnumberLbl" CssClass="" runat="server" Text='<%#Eval("ProductNumber") %>'></asp:Label>
                </div>
                <div>

                    <asp:Label ID="BuyNowLbl" CssClass="" runat="server" Text='<%#"Køb nu" %>'></asp:Label>

                    <asp:Label ID="PriceLbl" CssClass="" runat="server" Text='<%#"Pris: " + Eval("Price", "{0:0.00}") %>'></asp:Label>

                    <asp:Label ID="AmountLbl" CssClass="" runat="server" Text='<%#"Antal: "%>'></asp:Label><asp:TextBox ID="AmountTbx" Text="1" runat="server"></asp:TextBox>

                    <asp:Button ID="AddToCartBtn" runat="server" Text="Tilføj til kurv" CommandName="QuickAddToCart" />
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>

    <asp:LinkButton ID="LastPageLnkBtn" runat="server" OnClick="LinkButton1_Click">Tilbage</asp:LinkButton>
    <asp:Label ID="TestLbl" runat="server" Text="TestLabel"></asp:Label>
</asp:Content>

