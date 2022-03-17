<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TipoLicencia.aspx.cs" Inherits="pSitioWEB_AlquilerV.BasesDatos.TipoLicencia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <table class="nav-justified">
            <tr>
                <td colspan="2" style="font-size: xx-large" class="text-center"><strong>ADMINISTRACIÓN DE TIPO DE LICENCIAS</strong></td>
            </tr>
            <tr>
                <td class="text-left" style="font-weight: bold; font-size: x-large;">CÓDIGO:</td>
                <td>
                    <asp:TextBox ID="txtCodigo" runat="server" style="font-size: x-large"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text-left" style="font-weight: bold; height: 22px; font-size: x-large;">CATEGORIA:</td>
                <td style="height: 22px">
                    <asp:TextBox ID="txtCategoria" runat="server" style="font-size: x-large"></asp:TextBox>
                </td>
            </tr>
            <tr style="font-size: x-large">
                <td class="text-left" style="font-weight: bold">&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
           <tr>
                <td class="text-center">
                    <strong>
                    <asp:Button ID="btnInsertar" runat="server" Text="INSERTAR" OnClick="btnInsertar_Click" Width="280px" style="font-size: x-large; height: 41px; font-weight: bold; color: #FFFFFF; background-color: #336699;" />
                    </strong>
                </td>
                <td class="text-center">
                    <strong>
                    <asp:Button ID="btnActualizar" runat="server" Text="ACTUALIZAR" OnClick="btnActualizar_Click" Width="280px" style="font-size: x-large; font-weight: bold; color: #FFFFFF; background-color: #336699;" />
                    </strong>
                </td>
            </tr>
            <tr>
                <td class="text-center">
                    <strong>
                    <asp:Button ID="btnEliminar" runat="server" Text="ELIMINAR" OnClick="btnEliminar_Click" Width="280px" style="font-size: x-large; font-weight: bold; color: #FFFFFF; background-color: #336699;" />
                    </strong>
                </td>
                <td class="text-center">
                    <strong>
                    <asp:Button ID="btnConsultar" runat="server" Text="CONSULTAR" Width="280px" style="font-size: x-large; font-weight: bold; color: #FFFFFF; background-color: #336699;" OnClick="btnConsultar_Click" />
                    </strong>
                </td>
            </tr>
            <tr>
                <td class="text-left" colspan="2">
                    <asp:Label ID="lblError" runat="server" style="font-size: x-large"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    
                </td>
            </tr>
        </table>
    </p>
</asp:Content>
