<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <h3 class="ChildContainerHeader">Kassen</h3>
    <article>



        <asp:Label ID="TopH1Lbl" CssClass="HeadersMiddle" runat="server" Text=''></asp:Label>
        <br />
        <asp:Label ID="AboutUsH2Lbl" runat="server" Text=""></asp:Label>
        <br/>
        <asp:Label ID="AboutUsPLbl" runat="server" Text=""></asp:Label>





        <asp:Label ID="AddressH2Lbl" runat="server" Text=""></asp:Label>

        <asp:Repeater ID="AddressRpt" runat="server">
            <ItemTemplate>
                <asp:Label ID="AddressH2" runat="server" Text=""></asp:Label>
                <ul>
                    <li><%# Eval("Address") %></li>
                    <li><%# Eval("ZipCity") %></li>
                    <li><%# Eval("Phone") %></li>
                    <li><a href='"mailto:" + <%# Eval("Email") %>'><%# Eval("Email") %></a></li>
                </ul>
            </ItemTemplate>
        </asp:Repeater>




        <asp:Label ID="OpeningHoursH2" runat="server" Text="opening hours"></asp:Label>




    </article>
</asp:Content>

