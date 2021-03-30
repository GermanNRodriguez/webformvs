<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ProductosWebForm.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 109px;
        }
        .auto-style2 {
            width: 109px;
            height: 26px;
        }
        .auto-style3 {
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width:100%;">
                <tr>
                    <td id="nombre" class="auto-style1">Nombre</td>
                    <td>
                        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td id="descripcion" class="auto-style2">Descripción</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txtDesc" runat="server" EnableTheming="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td id="precio" class="auto-style1">Precio</td>
                    <td>
                        <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td id="stock" class="auto-style1">Stock</td>
                    <td>
                        <asp:TextBox ID="txtStock" runat="server"></asp:TextBox>
                     </td>
                </tr>
            </table>
        </div>
        <asp:GridView ID="gvProductos" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="GridView1_RowCommand" OnSelectedIndexChanged="gvProductos_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Selección" ShowHeader="True" Text="Seleccionar" />
            </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
        
        <asp:Button ID="botonGuardar" runat="server" OnClick="botonGuardar_Click" Text="Guardar" />
        <asp:Button ID="botonBorrar" runat="server" Text="Borrar" OnClick="botonBorrar_Click" />
        <asp:Button ID="botonCancelar" runat="server" Text="Cancelar" OnClick="botonCancelar_Click" />
        
    </form>
</body>
</html>
