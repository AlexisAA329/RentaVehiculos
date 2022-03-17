using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using libAlquilerVehiculos.BasesDatos;

namespace pSitioWEB_AlquilerV.BasesDatos
{
    public partial class Vehiculo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Es la primera vez, se invoca el llenao del combo
                LlenarComboTipoVehiculo();
                LlenarComboCategoria();
                LlenarComboTipoCombustible();

                //Lleno el grid
                LlenarGridVehiculo();
            }
        }


        private void LlenarComboTipoVehiculo()
        {
            //Creamos el objeto tipo producto, pasamos el combo vacío e invocamos el método
            clsTopoVehiculo oTipoV = new clsTopoVehiculo();
            oTipoV.cboTipoVehiculo = cboTipoVehiculo;
            if (!oTipoV.LlenarCombo())
            {
                lblError.Text = oTipoV.Error;
            }
        }
        private void LlenarComboTipoCombustible()
        {
            //Creamos el objeto tipo producto, pasamos el combo vacío e invocamos el método
            clsTipoCombustible oTipoCombus = new clsTipoCombustible();
            oTipoCombus.cboTipoCombustible = cboTipoCombustible;
            if (!oTipoCombus.LlenarCombo())
            {
                lblError.Text = oTipoCombus.Error;
            }
        }
        private void LlenarComboCategoria()
        {
            //Creamos el objeto tipo producto, pasamos el combo vacío e invocamos el método
            clsTipoCategoria oCategoria = new clsTipoCategoria();
            oCategoria.cboCategoria = cboCategoria;
            if (!oCategoria.LlenarCombo())
            {
                lblError.Text = oCategoria.Error;
            }
        }
        private void LlenarGridVehiculo()
        {
            clsVehiculo oVehiculo = new clsVehiculo();
            oVehiculo.grdVehiculo = grdVehiculo;
            if (!oVehiculo.LlenarGrid())
            {
                lblError.Text = oVehiculo.Error;
            }
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            string Placa, Marca, Color, Modelo;
            Int32 CodigoTipoVehiculo, CodigoTipoCombustible, CodigoCategoria;
            double Kilometraje;

            Placa = txtPlaca.Text;
            Marca = txtMarca.Text;
            Modelo = txtModelo.Text;
            Color = txtColor.Text;
            Kilometraje = Convert.ToDouble(txtKilometraje.Text);
            CodigoTipoVehiculo = Convert.ToInt32(cboTipoVehiculo.SelectedValue);
            CodigoTipoCombustible = Convert.ToInt32(cboTipoCombustible.SelectedValue);
            CodigoCategoria = Convert.ToInt32(cboCategoria.SelectedValue);

            clsVehiculo oVehiculo = new clsVehiculo();

            oVehiculo.Placa = Placa;
            oVehiculo.Marca = Marca;
            oVehiculo.Modelo = Modelo;
            oVehiculo.Color = Color;
            oVehiculo.Kilometraje = Kilometraje;
            oVehiculo.CodigoTipoCombustible = CodigoTipoCombustible;
            oVehiculo.CodigoTipoCategoria = CodigoCategoria;
            oVehiculo.CodigoTipoVehiculo = CodigoTipoVehiculo;

            if (oVehiculo.Insertar())
            {
                lblError.Text = "Se insertó correctamente en la base de datos el vehiculo: " + Placa;
                LlenarGridVehiculo();
            }
            else
            {
                lblError.Text = oVehiculo.Error;
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            string Placa, Marca, Color, Modelo;
            Int32 CodigoTipoVehiculo, CodigoTipoCombustible, CodigoCategoria;
            double Kilometraje;

            Placa = txtPlaca.Text;
            Marca = txtMarca.Text;
            Modelo = txtModelo.Text;
            Color = txtColor.Text;
            Kilometraje = Convert.ToDouble(txtKilometraje.Text);
            CodigoTipoVehiculo = Convert.ToInt32(cboTipoVehiculo.SelectedValue);
            CodigoTipoCombustible = Convert.ToInt32(cboTipoCombustible.SelectedValue);
            CodigoCategoria = Convert.ToInt32(cboCategoria.SelectedValue);

            clsVehiculo oVehiculo = new clsVehiculo();

            oVehiculo.Placa = Placa;
            oVehiculo.Marca = Marca;
            oVehiculo.Modelo = Modelo;
            oVehiculo.Color = Color;
            oVehiculo.Kilometraje = Kilometraje;
            oVehiculo.CodigoTipoCombustible = CodigoTipoCombustible;
            oVehiculo.CodigoTipoCategoria = CodigoCategoria;
            oVehiculo.CodigoTipoVehiculo = CodigoTipoVehiculo;

            if (oVehiculo.Actualizar())
            {
                lblError.Text = "Se actualizó correctamente en la base de datos el producto de código: " + Placa;
                LlenarGridVehiculo();
            }
            else
            {
                lblError.Text = oVehiculo.Error;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            String Codigo;

            Codigo = txtPlaca.Text;

            clsVehiculo oVehiiculo = new clsVehiculo();

            oVehiiculo.Placa = Codigo;

            if (oVehiiculo.Eliminar())
            {
                lblError.Text = "Se eliminó correctamente en la base de datos el producto de código: " + Codigo;
                LlenarGridVehiculo();
            }
            else
            {
                lblError.Text = oVehiiculo.Error;
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            string Codigo;

            Codigo = txtPlaca.Text;

            clsVehiculo oVehiculo = new clsVehiculo();

            oVehiculo.Placa = Codigo;

            if (oVehiculo.Consultar())
            {
               

                txtPlaca.Text = oVehiculo.Placa;
                txtMarca.Text = oVehiculo.Marca;
                txtModelo.Text = oVehiculo.Modelo;
                txtColor.Text = oVehiculo.Color;
                txtKilometraje.Text = oVehiculo.Kilometraje.ToString();
                cboTipoVehiculo.SelectedValue = oVehiculo.CodigoTipoVehiculo.ToString();
                cboCategoria.SelectedValue = oVehiculo.CodigoTipoCategoria.ToString();
                cboTipoCombustible.SelectedValue = oVehiculo.CodigoTipoCombustible.ToString();

                lblError.Text = "";

            }
            else
            {
                lblError.Text = oVehiculo.Error;
                txtPlaca.Text = "";
                txtMarca.Text = "";
                txtModelo.Text = "";
                txtColor.Text = "";
                txtKilometraje.Text = "";
            }
            }

        protected void grdProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPlaca.Text = grdVehiculo.SelectedRow.Cells[3].Text;
            txtModelo.Text = grdVehiculo.SelectedRow.Cells[4].Text;
            txtMarca.Text = grdVehiculo.SelectedRow.Cells[5].Text;
            txtColor.Text = grdVehiculo.SelectedRow.Cells[6].Text;
            txtKilometraje.Text = grdVehiculo.SelectedRow.Cells[7].Text;
            cboTipoVehiculo.SelectedValue = grdVehiculo.SelectedRow.Cells[1].Text;
            cboTipoCombustible.SelectedValue = grdVehiculo.SelectedRow.Cells[10].Text;
            cboCategoria.SelectedValue = grdVehiculo.SelectedRow.Cells[8].Text;

            lblError.Text = "";
        }
    }
    } 
