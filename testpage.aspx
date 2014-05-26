<%@ Page Language="C#" AutoEventWireup="true" CodeFile="testpage.aspx.cs" Inherits="testpage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        <asp:Repeater ID="Repeater1" OnItemCommand="repAddress_OnItemCommand" runat="server">
            <ItemTemplate>
                    <asp:Label runat="server" ID="lblFloat">11.11</asp:Label><asp:Button ID="Button1" runat="server" Text="Button" />
            </ItemTemplate>
        </asp:Repeater>


    </div>
    </form>
</body>
</html>
