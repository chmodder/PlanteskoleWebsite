<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Checkout.aspx.cs" Inherits="Checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <asp:GridView ID="CheckoutGv" OnRowCommand="CheckoutGv_OnRowCommand" DataKeyNames="Id" AutoGenerateColumns="False" runat="server">
        <Columns>
            <asp:BoundField HeaderText="Stk." DataField="Amount"></asp:BoundField>
            <asp:BoundField HeaderText="Produkt" DataField="Name"></asp:BoundField>
            <asp:BoundField HeaderText="Pr. stk." DataField="Price"></asp:BoundField>
            <asp:BoundField HeaderText="I alt" DataField="PriceTotal"></asp:BoundField>
            <asp:ButtonField Text="slet"></asp:ButtonField>
        </Columns>
    </asp:GridView>

    <asp:Button ID="OrderBtn" runat="server" Text="Bestil" OnClick="OrderBtn_Click" />
</asp:Content>

