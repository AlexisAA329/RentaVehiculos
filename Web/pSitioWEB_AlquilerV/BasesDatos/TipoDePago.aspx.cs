using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using libAlquilerVehiculos.BasesDatos;

namespace pSitioWEB_AlquilerV.BasesDatos
{
    public partial class TipoDePago : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LlenarGridTipoDePago();
            }
        }

        private void LlenarGridTipoDePago()
        {
            clsTipoDePago oTipoDePago = new clsTipoDePago();
            oTipoDePago.grdTipoDePago = grdTipoDePago;
            if (!oTipoDePago.LlenarGrid())
            {
                lblError.Text = oTipoDePago.Error;
            }
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            Int32 idTipoPago;
            string Descripcion;

            idTipoPago = Convert.ToInt32(txtidTipoPago.Text);
            Descripcion = txtDescripcion.Text;

            clsTipoDePago oTipoDePago = new clsTipoDePago();
            oTipoDePago.idTipoPago = idTipoPago;
            oTipoDePago.Descripcion = Descripcion;

            if (oTipoDePago.Insertar())
            {
                lblError.Text = "Insertó correctamente en la base de datos";
                LlenarGridTipoDePago();
            }
            else
            {
                lblError.Text = oTipoDePago.Error;
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Int32 idTipoPago;
            string Descripcion;

            idTipoPago = Convert.ToInt32(txtidTipoPago.Text);
            Descripcion = txtDescripcion.Text;

            clsTipoDePago oTipoDePago = new clsTipoDePago();
            oTipoDePago.idTipoPago = idTipoPago;
            oTipoDePago.Descripcion = Descripcion;

            if (oTipoDePago.Actualizar())
            {
                lblError.Text = "Actualizó correctamente en la base de datos el ID: " + idTipoPago;
                LlenarGridTipoDePago();
            }
            else
            {
                lblError.Text = oTipoDePago.Error;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Int32 idTipoPago;

            idTipoPago = Convert.ToInt32(txtidTipoPago.Text);

            clsTipoDePago oTipoDePago = new clsTipoDePago();
            oTipoDePago.idTipoPago = idTipoPago;

            if (oTipoDePago.Eliminar())
            {
                lblError.Text = "Se eliminó correctamente de la base de datos el id: " + idTipoPago;
                LlenarGridTipoDePago();
            }
            else
            {
                lblError.Text = oTipoDePago.Error;
            }
        }

        protected void grdProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtidTipoPago.Text = grdTipoDePago.SelectedRow.Cells[1].Text;
            txtDescripcion.Text = grdTipoDePago.SelectedRow.Cells[2].Text;

            lblError.Text = "";
        }
    }
}