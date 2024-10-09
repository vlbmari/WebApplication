<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplicationTeste2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        

        <div>
            <asp:Label ID="lblLogin" runat="server" Text="LOGIN"></asp:Label>
            <br><br><br>
            <asp:Label ID="lblMail" runat="server" Text="Mail"></asp:Label>
            <br>
            <asp:TextBox ID="txtMail" runat="server"></asp:TextBox>
            <br><br>
            <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
            <br>
            <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
            <br><br>
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="Button1_Click" />
            <br><br>
            <asp:HyperLink ID="cadastro" runat="server" NavigateUrl="Cadastro.aspx" Text="Cadastre-se" />
            <br><br>
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>

        </div>
    </form>
</body>
</html>
