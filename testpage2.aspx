<%@ Page Language="C#" AutoEventWireup="true" CodeFile="testpage2.aspx.cs" Inherits="testpage2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Repeater ID="ItemInfoRpt" runat="server" OnItemCommand="ItemInfoRpt_ItemCommand" DataSourceID="SqlDataSource1">
                <ItemTemplate>
                    <asp:HiddenField ID="HiddenField1" Value='<%# Eval("Price") %>' runat="server" />
                    <asp:Label ID="PriceLbl" CssClass="" runat="server" Text='<%#"Pris: " + Eval("Price").ToString() %>'></asp:Label>
                    <asp:Button ID="AddToCartBtn" runat="server" Text="Tilføj til kurv" CommandName="QuickAddToCart" />

                </ItemTemplate>
            </asp:Repeater>

            <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:ConnectionString %>'
                SelectCommand="
                SELECT TOP 1 [Price], [Id] FROM [Products]"></asp:SqlDataSource>
        </div>

    </form>
</body>
</html>
