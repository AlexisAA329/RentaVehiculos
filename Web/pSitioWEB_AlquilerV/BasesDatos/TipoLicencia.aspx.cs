using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using libAlquilerVehiculos.BasesDatos;

namespace pSitioWEB_AlquilerV.BasesDatos
{
    public partial class TipoLicencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            string Categoria;


            Categoria = txtCategoria.Text;


            clsTipoLicencia oTipoLicencia = new clsTipoLicencia();
            oTipoLicencia.Categoria = Categoria;


            if (oTipoLicencia.Insertar())
            {
                lblError.Text = "Se Ingreso correctamente en la base de datos";
            }
            else
            {
                lblError.Text = oTipoLicencia.Error;
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Int32 idTipoLicencia;
            string Categoria;


            idTipoLicencia = Convert.ToInt32(txtCodigo.Text);
            Categoria = txtCategoria.Text;


            clsTipoLicencia oTipoLicencia = new clsTipoLicencia();

            oTipoLicencia.idTipoLicencia = idTipoLicencia;
            oTipoLicencia.Categoria = Categoria;

            if (oTipoLicencia.Actualizar())
            {
                lblError.Text = "Actualizó correctamente en la base de datos la licencia código: " + idTipoLicencia;
            }
            else
            {
                lblError.Text = oTipoLicencia.Error;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Int32 idTipoLicencia;

            idTipoLicencia = Convert.ToInt32(txtCodigo.Text);

            clsTipoLicencia oTipoLicencia = new clsTipoLicencia();
            oTipoLicencia.idTipoLicencia = idTipoLicencia;

            if (oTipoLicencia.Borrar())
            {
                lblError.Text = "Se eliminó correctamente de la base de datos la licencia con el código: " + idTipoLicencia;
            }
            else
            {
                lblError.Text = oTipoLicencia.Error;
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            Int32 idTipoLicencia;

            idTipoLicencia = Convert.ToInt32(txtCodigo.Text);

            clsTipoLicencia oTipoLicencia = new clsTipoLicencia();
            oTipoLicencia.idTipoLicencia = idTipoLicencia;

            if (oTipoLicencia.Consultar())
            {
                lblError.Text = "";
                txtCategoria.Text = oTipoLicencia.Categoria;
            }
            else
            {
                lblError.Text = oTipoLicencia.Error;
            }
        }
    }
}