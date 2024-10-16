<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VisualizarUsuarios.aspx.cs" Inherits="WebApplicationTeste2.VisualizarUsuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Visualizar Usuários</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Cadastro de usuários"></asp:Label>
            <br /><br />
            <asp:GridView ID="GridViewUsuarios" runat="server" AutoGenerateColumns="False" 
            OnRowEditing="GridViewUsuarios_RowEditing" 
            OnRowCancelingEdit="GridViewUsuarios_RowCancelingEdit"
            OnRowUpdating="GridViewUsuarios_RowUpdating"
            OnRowDeleting="GridViewUsuarios_RowDeleting"
            OnRowCommand="GridViewUsuarios_RowCommand"
            DataKeyNames="id" >
        <Columns>
        <asp:BoundField DataField="id" HeaderText="ID" ReadOnly="True" />
        <asp:BoundField DataField="name" HeaderText="Nome" />
        <asp:BoundField DataField="lastname" HeaderText="Sobrenome" />
        <asp:BoundField DataField="mail" HeaderText="Email" />
        <asp:ButtonField ButtonType="Link" Text="Selecionar" CommandName="SelecionarUser" />
        <asp:TemplateField>
            <ItemTemplate>
                <asp:ImageButton ImageUrl="~/Images/edit.png" runat="server" CommandName="Edit" ToolTip="Edit" Width="20px" Height="20px" />
                <asp:ImageButton ImageUrl="~/Images/delete.png" runat="server" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px" />
            </ItemTemplate>
            <EditItemTemplate>
                <asp:ImageButton ImageUrl="~/Images/update.png" runat="server" CommandName="Update" ToolTip="Update" Width="20px" Height="20px" />
                <asp:ImageButton ImageUrl="~/Images/cancel.png" runat="server" CommandName="Cancel" ToolTip="Cancel" Width="20px" Height="20px" />
            </EditItemTemplate>
        </asp:TemplateField>
        </Columns>


        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />


    </asp:GridView>
        </div>
    </form>
</body>
</html>
