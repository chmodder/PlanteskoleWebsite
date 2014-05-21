<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <h3 class="ChildContainerHeader">Kontakt</h3>
    <article>

        <div class="ContactMiddleContainer100">
            <asp:Label ID="AddressH2Lbl" CssClass="H2Middle" runat="server" Text=""></asp:Label>

            <div class="ContactMiddleContainer50Content">
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

        <div class="ContactMiddleContainer100">
            <asp:Label ID="BusinessHoursH2" CssClass="H2Middle" runat="server" Text=""></asp:Label>
            <div class="ContactMiddleContainer50Content">
                <ul>
                    <asp:Repeater ID="BusinessHoursRpt" runat="server">
                        <ItemTemplate>
                            <li><span class="MoveLeft"><%# Eval("Day") %></span><span class="MoveRight"><%# Eval("Time") %></span></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>

        <div class="ContactMiddleContainer100">
            <asp:Label ID="ContactFormH2" CssClass="H2Middle" runat="server" Text=""></asp:Label>
            <div class="ContactMiddleContainer50Content">
            </div>

        </div>
    </article>

</asp:Content>

