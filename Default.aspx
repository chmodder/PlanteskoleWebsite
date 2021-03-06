﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <h3 class="ChildContainerHeader">Kassen</h3>
    <article>

        <asp:Label ID="TopH1Lbl" CssClass="HeadersMiddle" runat="server" Text=''></asp:Label>
        <br />

        <div class="DefaultMiddleContainer100">
            <asp:Label ID="AboutUsH2Lbl" CssClass="H2Middle" runat="server" Text=""></asp:Label>
            <div class="DefaultMiddleContainer100Content">
                <asp:Label ID="AboutUsPLbl" CssClass="" runat="server" Text=""></asp:Label>
            </div>
        </div>

        <div class="DefaultMiddleContainer50">
            <asp:Label ID="AddressH2Lbl" CssClass="H2Middle" runat="server" Text=""></asp:Label>

            <div class="DefaultMiddleContainer50Content">
                <ul>
                    <asp:Repeater ID="AddressRpt" runat="server">
                        <ItemTemplate>
                            <li><%# Eval("Address") %></li>
                            <li><%# Eval("ZipCity") %></li>
                            <li><%# Eval("Phone") %></li>
                            <li><a href='"mailto:" + <%# Eval("Email") %>'><%# Eval("Email") %></a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>

        <div class="DefaultMiddleContainer50">
            <asp:Label ID="BusinessHoursH2" CssClass="H2Middle" runat="server" Text=""></asp:Label>

            <div class="DefaultMiddleContainer50Content">
                <ul>
                    <asp:Repeater ID="BusinessHoursRpt" runat="server">
                        <ItemTemplate>
                            <li><span class="MoveLeft"><%# Eval("Day") %></span><span class="MoveRight"><%# Eval("Time") %></span></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>

        </div>



    </article>
</asp:Content>

