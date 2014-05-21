<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <h3 class="ChildContainerHeader">Kassen</h3>
    <article>

        <asp:Label ID="TopH1Lbl" CssClass="HeadersMiddle" runat="server" Text=''></asp:Label>
        <br />

        <div class="MainContainerBottom100">
            <asp:Label ID="AboutUsH2Lbl" CssClass="FrontpageH2Middle" runat="server" Text=""></asp:Label>
            <div class="MainContainerBottom100Content">
                <asp:Label ID="AboutUsPLbl" CssClass="" runat="server" Text=""></asp:Label>
            </div>
        </div>

        <div class="MainContainerBottom50">
            <asp:Label ID="AddressH2Lbl" CssClass="FrontpageH2Middle" runat="server" Text=""></asp:Label>

            <div class="MainContainerBottom50Content">
                <asp:Repeater ID="AddressRpt" runat="server">
                    <ItemTemplate>
                        <ul>
                            <li><%# Eval("Address") %></li>
                            <li><%# Eval("ZipCity") %></li>
                            <li><%# Eval("Phone") %></li>
                            <li><a href='"mailto:" + <%# Eval("Email") %>'><%# Eval("Email") %></a></li>
                        </ul>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>

        <div class="MainContainerBottom50">
            <asp:Label ID="OpeningHoursH2" CssClass="FrontpageH2Middle" runat="server" Text="opening hours"></asp:Label>


        </div>



    </article>
</asp:Content>

