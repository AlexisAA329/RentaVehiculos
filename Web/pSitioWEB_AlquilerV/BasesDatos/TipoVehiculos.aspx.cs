using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using libAlquilerVehiculos.BasesDatos;

namespace pSitioWEB_AlquilerV.BasesDatos
{
    public partial class TipoVehiculos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {

            string Nombre;
            bool Activo;

            Nombre = txtNombre.Text;
            Activo = chkActivo.Checked;

            clsTopoVehiculo oTipoVehiculo = new clsTopoVehiculo();
            oTipoVehiculo.Nombre = Nombre;
            oTipoVehiculo.Activo = Activo;

            if (oTipoVehiculo.Insertar())
            {
                lblError.Text = "Insertó correctamente en la base de datos";
            }
            else
            {
                lblError.Text = oTipoVehiculo.Error;
            }
        }
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Int32 Codigo;
            string Nombre;
            bool Activo;

            Codigo = Convert.ToInt32(txtCodigo.Text);
            Nombre = txtNombre.Text;
            Activo = chkActivo.Checked;

            clsTopoVehiculo oTipoVehiculo = new clsTopoVehiculo();
            oTipoVehiculo.Codigo = Codigo;
            oTipoVehiculo.Nombre = Nombre;
            oTipoVehiculo.Activo = Activo;

            if (oTipoVehiculo.Actualizar())
            {
                lblError.Text = "Actualizó correctamente en la base de datos el código: " + Codigo;
            }
            else
            {
                lblError.Text = oTipoVehiculo.Error;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Int32 Codigo;

            Codigo = Convert.ToInt32(txtCodigo.Text);

            clsTopoVehiculo oTipoVehiculo = new clsTopoVehiculo();
            oTipoVehiculo.Codigo = Codigo;

            if (oTipoVehiculo.Borrar())
            {
                lblError.Text = "Se eliminó correctamente de la base de datos el código: " + Codigo;
            }
            else
            {
                lblError.Text = oTipoVehiculo.Error;
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            Int32 Codigo;

            Codigo = Convert.ToInt32(txtCodigo.Text);

            clsTopoVehiculo oTipoVehiculo = new clsTopoVehiculo();
            oTipoVehiculo.Codigo = Codigo;

            if (oTipoVehiculo.Consultar())
            {
                lblError.Text = "";
                txtNombre.Text = oTipoVehiculo.Nombre;
                chkActivo.Checked = oTipoVehiculo.Activo;
            }
            else
            {
                lblError.Text = oTipoVehiculo.Error;
            }
        }
    }
}