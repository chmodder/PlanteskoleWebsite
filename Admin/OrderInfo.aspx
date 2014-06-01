<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" EnableViewState="true" AutoEventWireup="true" CodeFile="OrderInfo.aspx.cs" Inherits="Admin_OrderInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLeft" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <h2>Ordre info</h2>
    <asp:GridView ID="OrderDetailsGv" runat="server" AutoGenerateColumns="False" DataKeyNames="OrderId" DataSourceID="OrdreInfo">
        <Columns>
            <asp:BoundField DataField="OrderId" HeaderText="OrderId" ReadOnly="True" InsertVisible="False" SortExpression="OrderId"></asp:BoundField>
            <asp:BoundField DataField="OrderPriceSum" HeaderText="OrderPriceSum" SortExpression="OrderPriceSum"></asp:BoundField>
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"></asp:BoundField>
        </Columns>
    </asp:GridView>

    <asp:SqlDataSource runat="server" ID="OrdreInfo" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' SelectCommand="SELECT Orders.Id AS OrderId, Orders.PriceTotal AS OrderPriceSum, OrderState.Name
FROM Orders
LEFT JOIN OrderState
	ON Orders.FkOrderStateId = OrderState.Id
WHERE Orders.Id = @OrderId">
        <SelectParameters>
            <asp:QueryStringParameter QueryStringField="OrderId" Name="OrderId"></asp:QueryStringParameter>
        </SelectParameters>
    </asp:SqlDataSource>
    
    <br />
    
    <h2>Produkter i ordre</h2>
    <asp:GridView ID="OrderItemsGv" runat="server" AutoGenerateColumns="False" DataSourceID="OrderItemsSqlDs">
        <Columns>
            <asp:BoundField DataField="ProductNumber" HeaderText="ProductNumber" SortExpression="ProductNumber"></asp:BoundField>
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"></asp:BoundField>
            <asp:BoundField DataField="PriceEach" HeaderText="PriceEach" SortExpression="PriceEach"></asp:BoundField>
            <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount"></asp:BoundField>
            <asp:BoundField DataField="PriceTotal" HeaderText="PriceTotal" SortExpression="PriceTotal"></asp:BoundField>
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource runat="server" ID="OrderItemsSqlDs" ConnectionString='<%$ ConnectionStrings:ConnectionString %>'
        SelectCommand="
        SELECT Products.ProductNumber, Products.Name, OrderDetails.PriceEach, OrderDetails.Amount, OrderDetails.PriceTotal 
        FROM OrderDetails
        INNER JOIN Products
	        ON Products.Id = OrderDetails.FkProductId
        WHERE FkOrderId = @OrderId">
        <SelectParameters>
            <asp:QueryStringParameter QueryStringField="OrderId" Name="OrderId"></asp:QueryStringParameter>
        </SelectParameters>
    </asp:SqlDataSource>
    
    <br />
    
    <h2>Kunde info</h2>
    <asp:GridView ID="CustomerGv" runat="server" AutoGenerateColumns="False" DataKeyNames="CustomerId" DataSourceID="CustomerInfoSqlDs">

        <Columns>
            <asp:BoundField DataField="CustomerId" HeaderText="CustomerId" ReadOnly="True" InsertVisible="False" SortExpression="CustomerId"></asp:BoundField>
            <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName"></asp:BoundField>
            <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName"></asp:BoundField>
            <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address"></asp:BoundField>
            <asp:BoundField DataField="City" HeaderText="City" SortExpression="City"></asp:BoundField>
            <asp:BoundField DataField="ZipCode" HeaderText="ZipCode" SortExpression="ZipCode"></asp:BoundField>
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email"></asp:BoundField>
        </Columns>
    </asp:GridView>


    <asp:SqlDataSource runat="server" ID="CustomerInfoSqlDs" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' SelectCommand="
                SELECT Users.Id AS CustomerId, Users.FirstName, Users.LastName, Users.Address,Users.City, Users.ZipCode, Users.Email
                FROM Orders
                INNER JOIN Users
	                ON Users.Id = Orders.FkUserId
                WHERE Orders.Id = @OrderId">
        <SelectParameters>
            <asp:QueryStringParameter QueryStringField="OrderId" Name="OrderId"></asp:QueryStringParameter>
        </SelectParameters>
    </asp:SqlDataSource>
    <br />
    
    <h2>Ordre status</h2>

    <asp:DropDownList ID="OrderStateDdl" runat="server" DataSourceID="OrderStateSqlDs" DataTextField="Name" DataValueField="Id">
    </asp:DropDownList>

    <asp:SqlDataSource runat="server" ID="OrderStateSqlDs" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' 
        SelectCommand="SELECT OrderState.* FROM OrderState">
        
    </asp:SqlDataSource>
    <asp:Button ID="Button1" runat="server" Text="test" OnClick="Button1_Click" />
    <asp:Label ID="Label1" runat="server" Text="test"></asp:Label>
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    <hr/>
    <asp:Button ID="LastPageBtn" runat="server" Text="Tilbage" OnClick="LastPageBtn_Click" />
</asp:Content>

