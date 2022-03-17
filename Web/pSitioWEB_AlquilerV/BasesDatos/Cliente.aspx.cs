using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using libAlquilerVehiculos.BasesDatos;

namespace pSitioWEB_AlquilerV.BaseDatos
{
    public partial class Cliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                if (!Page.IsPostBack)
                {

                    LlenarComboTipoLicencias();

                    LlenarGridCliente();
                }

            }
        }
        private void LlenarComboTipoLicencias()
        {

            //Creamos el objeto tipo producto, pasamos el combo vacío e invocamos el método
            clsTipoLicencia oTipoLicencia = new clsTipoLicencia();
            oTipoLicencia.cboTipoLicencia = cboTipoLicencia;
            if (!oTipoLicencia.LlenarCombo())
            {
                lblError.Text = oTipoLicencia.Error;
            }

        }

        private void LlenarGridCliente()
        {
            clsCliente oCliente = new clsCliente();
            oCliente.grdCliente = grdCliente;
            if (!oCliente.LlenarGrid())
            {
                lblError.Text = oCliente.Error;
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            string Nombre, PrimerApellido, SegundoApellido, Direccion;
            Int32 Documento, TipoLicencia;
            Int64 Telefono;
            DateTime FechaNacimiento;

            Nombre = txtNombre.Text;
            PrimerApellido = txtPrimerApellido.Text;
            SegundoApellido = txtSegundoApellido.Text;
            Direccion = txtDireccion.Text;
            Documento = Convert.ToInt32(txtDocumento.Text);
            TipoLicencia = Convert.ToInt32(cboTipoLicencia.SelectedValue);
            Telefono = Convert.ToInt64(txtTelefono.Text);
            FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text);

            clsCliente oCliente = new clsCliente();

            oCliente.Nombre = Nombre;
            oCliente.PrimerApellido = PrimerApellido;
            oCliente.SegundoApellido = SegundoApellido;
            oCliente.Direccion = Direccion;
            oCliente.Documento = Documento;
            oCliente.TipoLicencia = TipoLicencia;
            oCliente.Telefono = Telefono;
            oCliente.FechaNacimiento = FechaNacimiento;

            if (oCliente.Insertar())
            {
                lblError.Text = "Se insertó correctamente en la base de datos el cliente con documento: " + Documento;
                LlenarGridCliente();
            }
            else
            {
                lblError.Text = oCliente.Error;
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            string Nombre, PrimerApellido, SegundoApellido, Direccion;
            Int32 Documento, TipoLicencia, Telefono;
            DateTime FechaNacimiento;

            Nombre = txtNombre.Text;
            PrimerApellido = txtPrimerApellido.Text;
            SegundoApellido = txtSegundoApellido.Text;
            Direccion = txtDireccion.Text;
            Documento = Convert.ToInt32(txtDocumento.Text);
            TipoLicencia = Convert.ToInt32(cboTipoLicencia.SelectedValue);
            Telefono = Convert.ToInt32(txtTelefono.Text);
            FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text);

            clsCliente oCliente = new clsCliente();

            oCliente.Nombre = Nombre;
            oCliente.PrimerApellido = PrimerApellido;
            oCliente.SegundoApellido = SegundoApellido;
            oCliente.Direccion = Direccion;
            oCliente.Documento = Documento;
            oCliente.TipoLicencia = TipoLicencia;
            oCliente.Telefono = Telefono;
            oCliente.FechaNacimiento = FechaNacimiento;

            if (oCliente.Actualizar())
            {
                lblError.Text = "Se actualizó correctamente en la base el cliente con documento: " + Documento;
                LlenarGridCliente();
            }
            else
            {
                lblError.Text = oCliente.Error;
            }
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            Int32 Documento;

            Documento = Convert.ToInt32(txtDocumento.Text);

            clsCliente oCliente = new clsCliente();

            oCliente.Documento = Documento;

            if (oCliente.Eliminar())
            {
                lblError.Text = "Se eliminó correctamente en la base de datos el cliente con documento: " + Documento;
                LlenarGridCliente();
            }
            else
            {
                lblError.Text = oCliente.Error;
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            Int32 Documento;

            Documento = Convert.ToInt32(txtDocumento.Text);

            clsCliente oCliente = new clsCliente();

            oCliente.Documento = Documento;

            if (oCliente.Consultar())
            {
                txtNombre.Text = oCliente.Nombre;
                txtPrimerApellido.Text = oCliente.PrimerApellido;
                txtSegundoApellido.Text = oCliente.SegundoApellido;
                txtDireccion.Text = oCliente.Direccion;
                cboTipoLicencia.SelectedValue = oCliente.TipoLicencia.ToString();
                txtTelefono.Text = oCliente.Telefono.ToString();
                txtFechaNacimiento.Text = oCliente.FechaNacimiento.ToString("yyyy-MM-dd");
                lblError.Text = "";

            }
            else
            {
                lblError.Text = oCliente.Error;

                txtNombre.Text = "";
                txtPrimerApellido.Text = "";
                txtSegundoApellido.Text = "";
                txtDireccion.Text = "";
                txtTelefono.Text = "";
                txtFechaNacimiento.Text = "";

            }
        }


        protected void grdCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtDocumento.Text = grdCliente.SelectedRow.Cells[1].Text;
            txtNombre.Text = grdCliente.SelectedRow.Cells[2].Text;
            txtPrimerApellido.Text = grdCliente.SelectedRow.Cells[6].Text;
            txtSegundoApellido.Text = grdCliente.SelectedRow.Cells[7].Text;
            txtNombre.Text = grdCliente.SelectedRow.Cells[2].Text;
            txtDireccion.Text = grdCliente.SelectedRow.Cells[4].Text;
            cboTipoLicencia.SelectedValue = grdCliente.SelectedRow.Cells[6].Text;
            txtTelefono.Text = grdCliente.SelectedRow.Cells[8].Text;
            String Fecha = grdCliente.SelectedRow.Cells[3].Text.Substring(0,10);
            txtFechaNacimiento.Text = Convert.ToDateTime(Fecha).ToString("yyyy-MM-dd");

            lblError.Text = "";

        }
    }
    
}