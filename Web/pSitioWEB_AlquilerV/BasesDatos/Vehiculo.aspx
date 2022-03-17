<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Vehiculo.aspx.cs" Inherits="pSitioWEB_AlquilerV.BasesDatos.Vehiculo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <table class="nav-justified">
            <tr>
                <td colspan="2" style="font-size: large" class="text-center"><strong><span style="font-size: x-large">ADMINISTRACIÓN DE PRODUCTOS</span></strong></td>
            </tr>
            <tr>
                <td class="text-left" style="font-weight: bold; font-size: large;">PLACA:</td>
                <td class="text-center">
                    <asp:TextBox ID="txtPlaca" runat="server" style="font-size: large"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text-left" style="font-weight: bold; font-size: large;">MODELO:</td>
                <td class="text-center">
                    <asp:TextBox ID="txtModelo" runat="server" style="font-size: large"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text-left" style="font-weight: bold; font-size: large;">MARCA:</td>
                <td class="text-center">
                    <asp:TextBox ID="txtMarca" runat="server" style="font-size: large"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text-left" style="font-weight: bold; font-size: large;">COLOR:</td>
                <td class="text-center">
                    <asp:TextBox ID="txtColor" runat="server" style="font-size: large"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text-left" style="font-weight: bold; font-size: large;">KILOMETRAJE:</td>
                <td class="text-center">
                    <asp:TextBox ID="txtKilometraje" runat="server" style="font-size: large" TextMode="Number"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text-left" style="font-weight: bold; font-size: large;">TIPO DE VEHICULO</td>
                <td class="text-center">
                    
                    <asp:DropDownList ID="cboTipoVehiculo" runat="server" style="font-size: large">
                    </asp:DropDownList>
                    
                </td>
            </tr>
            <tr>
                <td class="text-left" style="font-weight: bold; font-size: large;">TIPO DE COMBUSTIBLE</td>
                <td class="text-center">
                    
                    <asp:DropDownList ID="cboTipoCombustible" runat="server" style="font-size: large">
                    </asp:DropDownList>
                    
                </td>
            </tr>
            <tr>
                <td class="text-left" style="font-weight: bold; font-size: large;">CATEGORIA DE CONDUCION:</td>
                <td class="text-center">
                    
                    <asp:DropDownList ID="cboCategoria" runat="server" style="font-size: large">
                    </asp:DropDownList>
                    
                </td>
            </tr>
            <tr>
                <td class="text-center" style="font-size: x-large">
                    <strong>
                    <asp:Button ID="btnInsertar" runat="server" Width="250px" BackColor="#0000CC" Font-Bold="True" ForeColor="White" OnClick="btnInsertar_Click" style="font-size: x-large" Text="INSERTAR" />
                    </strong>
                </td>
                <td class="text-center">
                    <strong>
                    <asp:Button ID="btnActualizar" runat="server" Text="ACTUALIZAR" Width="250px" BackColor="#0000CC" Font-Bold="True" ForeColor="White" OnClick="btnActualizar_Click" style="font-size: x-large"  />
                    </strong>
                </td>
            </tr>
            <tr>
                <td class="text-center" style="font-size: x-large">
                    <strong>
                    <asp:Button ID="btnEliminar" runat="server" Text="ELIMINAR" Width="250px" BackColor="#0000CC" Font-Bold="True" ForeColor="White" OnClick="btnEliminar_Click" style="font-size: x-large"  />
                    </strong>
                </td>
                <td class="text-center">
                    <strong>
                    <asp:Button ID="btnConsultar" runat="server" Text="CONSULTAR" Width="250px" BackColor="#0000CC" Font-Bold="True" ForeColor="White" OnClick="btnConsultar_Click" style="font-size: x-large" />
                    </strong>
                </td>
            </tr>
            <tr>
                <td class="text-left">
                    <em>
                    <asp:Label ID="lblError" runat="server" style="font-size: large"></asp:Label>
                    </em>
                </td>
                <td class="text-left">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2" class="text-center">
                    
                    <asp:GridView ID="grdVehiculo" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" style="font-size: large" OnSelectedIndexChanged="grdProducto_SelectedIndexChanged">
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
    </p>
</asp:Content>