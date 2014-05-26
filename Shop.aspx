<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Shop.aspx.cs" Inherits="Shop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <h3 class="ChildContainerHeader">Butikken</h3>
    <article>

        <div class="ContactMiddleContainer100">

            <asp:SqlDataSource runat="server" ID="ProductListSqlDataSource" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' SelectCommand="SELECT [Id], [Name], [Price] FROM [Products] WHERE ([FkCategoryId] = @FkCategoryId)">
                <SelectParameters>
                    <asp:QueryStringParameter QueryStringField="CatId" Name="FkCategoryId" Type="Int32"></asp:QueryStringParameter>
                </SelectParameters>
            </asp:SqlDataSource>

            <asp:GridView ID="ProductsGv" runat="server" AutoGenerateColumns="False" DataSourceID="ProductListSqlDataSource" DataKeyNames="Id, Name, Price" OnRowCommand="ProductsGv_OnRowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="Stk">
                        <ItemTemplate>
                            <asp:HiddenField ID="HiddenFieldId" Value='<%# Eval("Id") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Tilføj">
                        <ItemTemplate>
                            <asp:CheckBox ID="IdChb" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Stk">
                        <ItemTemplate>
                            <asp:TextBox ID="AmountTbx" Text="1" runat="server"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="Name" HeaderText="Produkt navn" SortExpression="Name"></asp:BoundField>
                    <asp:BoundField DataField="Price" HeaderText="Pris" SortExpression="Price"></asp:BoundField>

                    <asp:ButtonField CommandName="More" HeaderText="mere info" Text="Info"></asp:ButtonField>
                    
                </Columns>
            </asp:GridView>

            <asp:Button ID="UpdateCartBtn" runat="server" Text="Opdater Kurv" OnClick="UpdateCartBtn_Click" />
            <hr/>
            <asp:Label ID="TestLbl" runat="server" Text="test"></asp:Label>

        </div>
    </article>

</asp:Content>

