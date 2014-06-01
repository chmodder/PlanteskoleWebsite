<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CreateUser.aspx.cs" Inherits="CreateUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <%-- Input felter --%>
    <div class="row">
        <div class="col-xs-6">
            <div class="input-group">
                <asp:Label ID="CreateUserNameLbl" AssociatedControlID="CreateUserNameTbx" class="input-group-addon" runat="server" Text="Brugernavn"></asp:Label>
                <asp:TextBox ID="CreateUserNameTbx" class="form-control" runat="server"></asp:TextBox>
            </div>
            <!-- /input-group -->
        </div>
        <!-- /.col-lg-6 -->
    </div>

    <br />

    <div class="row">
        <div class="col-xs-6">
            <div class="input-group">
                <asp:Label ID="CreateUserPassWordLbl" AssociatedControlID="CreateUserPassWordTbx" class="input-group-addon" runat="server" Text="Password"></asp:Label>
                <asp:TextBox ID="CreateUserPassWordTbx" class="form-control" runat="server"></asp:TextBox>
            </div>
            <!-- /input-group -->
        </div>
        <!-- /.col-lg-6 -->
    </div>

    <br />

    <div class="row">
        <div class="col-xs-6">
            <div class="input-group">
                <asp:Label ID="CreateUserEmailLbl" AssociatedControlID="CreateUserEmailTbx" class="input-group-addon" runat="server" Text="Email"></asp:Label>
                <asp:TextBox ID="CreateUserEmailTbx" class="form-control" runat="server"></asp:TextBox>
            </div>
            <!-- /input-group -->
        </div>
        <!-- /.col-lg-6 -->
    </div>
    
    <br />

    <div class="row">
        <div class="col-xs-6">
            <div class="input-group">
                <asp:Label ID="ConfirmUserEmailLbl" AssociatedControlID="ConfirmUserEmailTbx" class="input-group-addon" runat="server" Text="bekræft email"></asp:Label>
                <asp:TextBox ID="ConfirmUserEmailTbx" class="form-control" runat="server"></asp:TextBox>
            </div>
            <!-- /input-group -->
        </div>
        <!-- /.col-lg-6 -->
    </div>
    
    <br />

    <div class="row">
        <div class="col-xs-6">
            <div class="input-group">
                <asp:Label ID="FirstNameLbl" AssociatedControlID="FirstNameTbx" class="input-group-addon" runat="server" Text="Fornavn"></asp:Label>
                <asp:TextBox ID="FirstNameTbx" class="form-control" runat="server"></asp:TextBox>
            </div>
            <!-- /input-group -->
        </div>
        <!-- /.col-lg-6 -->
    </div>
    
    <br />

    <div class="row">
        <div class="col-xs-6">
            <div class="input-group">
                <asp:Label ID="LastNameLbl" AssociatedControlID="LastNameTbx" class="input-group-addon" runat="server" Text="Efternavn"></asp:Label>
                <asp:TextBox ID="LastNameTbx" class="form-control" runat="server"></asp:TextBox>
            </div>
            <!-- /input-group -->
        </div>
        <!-- /.col-lg-6 -->
    </div>
        
    <br />

    <div class="row">
        <div class="col-xs-6">
            <div class="input-group">
                <asp:Label ID="AddressLbl" AssociatedControlID="AddressTbx" class="input-group-addon" runat="server" Text="Adresse"></asp:Label>
                <asp:TextBox ID="AddressTbx" class="form-control" runat="server"></asp:TextBox>
            </div>
            <!-- /input-group -->
        </div>
        <!-- /.col-lg-6 -->
    </div>
    
    <br />

    <div class="row">
        <div class="col-xs-6">
            <div class="input-group">
                <asp:Label ID="ZipLbl" AssociatedControlID="ZipTbx" class="input-group-addon" runat="server" Text="Postnummer"></asp:Label>
                <asp:TextBox ID="ZipTbx" class="form-control" runat="server"></asp:TextBox>
            </div>
            <!-- /input-group -->
        </div>
        <!-- /.col-lg-6 -->
    </div>
    
    <br />

    <div class="row">
        <div class="col-xs-6">
            <div class="input-group">
                <asp:Label ID="CityLbl" AssociatedControlID="CityTbx" class="input-group-addon" runat="server" Text="By"></asp:Label>
                <asp:TextBox ID="CityTbx" class="form-control" runat="server"></asp:TextBox>
            </div>
            <!-- /input-group -->
        </div>
        <!-- /.col-lg-6 -->
    </div>
    <hr />
    <%-- Knapper --%>
    <%--<asp:Button ID="Discard" class="btn btn-default" runat="server" Text="Annuller" />--%>
    
    <asp:Button ID="CreateUserBtn" runat="server" Text="Opret" OnClick="CreateUserBtn_Click" />
    <asp:Label ID="ErrorLbl" runat="server" Text=""></asp:Label>
</asp:Content>

