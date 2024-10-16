<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="WebApplicationTeste2.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Label ID="lblCadastro" runat="server" Text="REGISTER"></asp:Label>
            <br><br><br>
            <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
            <br>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            <br>
            <asp:Label ID="lblLastname" runat="server" Text="Lastname"></asp:Label>
            <br>
            <asp:TextBox ID="txtLastname" runat="server"></asp:TextBox>
            <br><br>
            <asp:Label ID="lblMailC" runat="server" Text="Mail"></asp:Label>
            <br>
            <asp:TextBox ID="txtMailC" runat="server"></asp:TextBox>
            <br><br>
            <asp:Label ID="lblPasswordC" runat="server" Text="Password"></asp:Label>
            <br>
            <asp:TextBox ID="txtPasswordC" runat="server" TextMode="Password"></asp:TextBox> 
            <br>
            <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password"></asp:Label> 
            <br>
            <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox> 
            <br><br>
            <asp:DropDownList ID="ddlCidades" runat="server" DataTextField="nome" DataValueField="pk_cidade" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="ddlCidades_SelectedIndexChanged" >
            </asp:DropDownList>
            <br><br>
            <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" style="height: 26px" />
            <br><br>
            <asp:HyperLink ID="Login" runat="server" NavigateUrl="Login.aspx" Text="Entrar" />          
            <br><br>
            <asp:Label ID="lblMessageC" runat="server" Text=""></asp:Label>

            <%--<select name="ddlUF" id="ddlUF">
	        <option value="0">Selecione uma UF</option>
	        <option value="1">BA</option>
	        <option value="2">RN</option>
            </select>--%>

        </div>
        
    </form>
</body>
</html>
