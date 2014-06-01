<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="OrdersAndStock.aspx.cs" Inherits="Admin_OrdersAndStock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderLeft" Runat="Server">
    <li><a href="../Admin/OrdersAndStock.aspx">Rediger beholdning</a></li>
    <li><a href="../Admin/Orders.aspx">Behandl ordrer</a></li>
    <li><a href="#">Vis lav beholdning</a></li>
    <li><a href="#">Vis udsolgte produkter</a></li>
    <li><a href="#">Vis indgåede ordrer</a></li>
    <li><a href="#">Vis afhentede ordrer</a></li>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>

