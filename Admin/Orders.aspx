<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Orders.aspx.cs" Inherits="Admin_Orders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLeft" Runat="Server">
    <li><a href="../Admin/OrdersAndStock.aspx">Rediger beholdning</a></li>
    <li><a href="../Admin/Orders.aspx">Behandl ordrer</a></li>
    <li><a href="#">Vis lav beholdning</a></li>
    <li><a href="#">Vis udsolgte produkter</a></li>
    <li><a href="#">Vis indgåede ordrer</a></li>
    <li><a href="#">Vis uafhentede ordrer</a></li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <h3 class="ChildContainerHeader">Alle Ordrer</h3>
    <article>

        <div class="ContactMiddleContainer100">
            <asp:GridView ID="AllOrdersGv" runat="server" AutoGenerateColumns="False" DataSourceID="AllOrdersSqlDs" DataKeyNames="OrderId" OnRowCommand="AllOrdersGv_OnRowCommand" AllowPaging="True">
                <Columns>
                    <asp:BoundField DataField="OrderId" HeaderText="OrderId" ReadOnly="True" InsertVisible="False" SortExpression="OrderId"></asp:BoundField>
                    <asp:BoundField DataField="OrderPriceSum" HeaderText="OrderPriceSum" SortExpression="OrderPriceSum"></asp:BoundField>
                    <asp:BoundField DataField="Customer" HeaderText="Customer" ReadOnly="True" SortExpression="Customer"></asp:BoundField>
                    <asp:BoundField DataField="CustomerId" HeaderText="CustomerId" ReadOnly="True" InsertVisible="False" SortExpression="CustomerId"></asp:BoundField>
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"></asp:BoundField>
                    <asp:ButtonField CommandName="More" HeaderText="mere info" Text="Info"></asp:ButtonField>
                </Columns>
            </asp:GridView>

            <asp:SqlDataSource runat="server" ID="AllOrdersSqlDs" ConnectionString='<%$ ConnectionStrings:ConnectionString %>'
                SelectCommand="
                SELECT Orders.Id AS OrderId, Orders.PriceTotal AS OrderPriceSum, CONCAT(Users.FirstName, ' ' , Users.LastName) AS Customer, Users.Id AS CustomerId, OrderState.Name
                FROM Orders
                INNER JOIN Users
	                ON Users.Id = Orders.FkUserId
                LEFT JOIN OrderState
	                ON Orders.FkOrderStateId = OrderState.Id">
            </asp:SqlDataSource>

        </div>
    </article>

</asp:Content>

