<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pago.aspx.cs" Inherits="pSitioWEB_AlquilerV.BasesDatos.Pago" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<table class="nav-justified" style="height: 461px">
        <tr>
            <td class="text-center" colspan="2" style="font-size: x-large">&nbsp;</td>
        </tr>
        <tr>
            <td class="text-center" colspan="2" style="font-size: x-large"><strong>Pago</strong></td>
        </tr>
        <tr>
            <td style="font-size: large; width: 405px">ID del pago</td>
            <td class="text-center">
                <asp:TextBox ID="txtidPago" runat="server" style="font-size: large" Width="374px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 405px; font-size: large">Moneda</td>
            <td class="text-center">
                <asp:TextBox ID="txtMoneda" runat="server" Width="374px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 405px; font-size: large">Número de Alquiler</td>
            <td class="text-center">
                <asp:TextBox ID="txtNumAlquiler" runat="server" Width="373px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 405px; font-size: large">Tipo de Pago</td>
            <td class="text-center">
                <asp:TextBox ID="txtTipoPago" runat="server" Width="373px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 405px; font-size: large">Número de Reserva</td>
            <td class="text-center">
                <asp:TextBox ID="txtNumReserva" runat="server" Width="376px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="text-center" colspan="2">
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="text-center" style="width: 405px">
                <asp:Button ID="btnInsertar" runat="server" OnClick="btnInsertar_Click" style="font-size: x-large" Text="Insertar" />
            </td>
            <td class="text-center">
                <asp:Button ID="btnActualizar" runat="server" OnClick="btnActualizar_Click" style="font-size: x-large" Text="Actualizar" />
            </td>
        </tr>
        <tr>
            <td class="text-center" style="width: 405px">
                <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" style="font-size: x-large" Text="Eliminar" />
            </td>
            <td class="text-center">&nbsp;</td>
        </tr>
        <tr>
            <td class="text-center" colspan="2">
                <asp:GridView ID="grdPago" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" OnSelectedIndexChanged="grdProducto_SelectedIndexChanged" style="font-size: large">
                    <AlternatingRowStyle BackColor="#DCDCDC" />
                    <Columns>
                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/Editar.png" ShowSelectButton="True" />
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#0000A9" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#000065" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
