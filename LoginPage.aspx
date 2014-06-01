<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LoginPage.aspx.cs" Inherits="LoginPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <%-- Input felter --%>
    <div class="row">
        <div class="col-xs-6">
            <div class="input-group">
                <asp:Label ID="UserNameLbl" AssociatedControlID="UserNameTbx" class="input-group-addon" runat="server" Text="Brugernavn"></asp:Label>
                <asp:TextBox ID="UserNameTbx" class="form-control" runat="server"></asp:TextBox>
            </div>
            <!-- /input-group -->
        </div>
        <!-- /.col-lg-6 -->
    </div>

    <br />

    <div class="row">
        <div class="col-xs-6">
            <div class="input-group">
                <asp:Label ID="PassWordLbl" AssociatedControlID="PassWordTbx" class="input-group-addon" runat="server" Text="Password"></asp:Label>
                <asp:TextBox ID="PassWordTbx" class="form-control" runat="server"></asp:TextBox>
            </div>
            <!-- /input-group -->
        </div>
        <!-- /.col-lg-6 -->
    </div>

    <%-- Knapper --%>
    <asp:Button ID="LoginBtn" runat="server" Text="Log ind" OnClick="LoginBtn_Click" />
</asp:Content>

