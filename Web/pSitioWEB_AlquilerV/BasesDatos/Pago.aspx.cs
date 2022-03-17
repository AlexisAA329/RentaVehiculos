using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using libAlquilerVehiculos.BasesDatos;

namespace pSitioWEB_AlquilerV.BasesDatos
{
    public partial class Pago : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void LlenarGridPago()
        {
            clsPago oPago = new clsPago();
            oPago.grdPago = grdPago;
            if (!oPago.LlenarGrid())
            {
                lblError.Text = oPago.Error;
            }
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            Int32 idPago;
            string Moneda;
            Int32 NumAlquiler;
            Int32 TipoPago;
            Int32 NumReserva;

            idPago = Convert.ToInt32(txtidPago.Text);
            Moneda = txtMoneda.Text;
            NumAlquiler = Convert.ToInt32(txtNumAlquiler.Text);
            TipoPago = Convert.ToInt32(txtTipoPago.Text);
            NumReserva = Convert.ToInt32(txtNumReserva.Text);

            clsPago oPago = new clsPago();
            oPago.idPago = idPago;
            oPago.Moneda = Moneda;
            oPago.NumAlquiler = NumAlquiler;
            oPago.TipoPago = TipoPago;
            oPago.NumReserva = NumReserva;

            if (oPago.Insertar())
            {
                lblError.Text = "Insertó correctamente en la base de datos";
                LlenarGridPago();
            }
            else
            {
                lblError.Text = oPago.Error;
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Int32 idPago;
            string Moneda;
            Int32 NumAlquiler;
            Int32 TipoPago;
            Int32 NumReserva;

            idPago = Convert.ToInt32(txtidPago.Text);
            Moneda = txtMoneda.Text;
            NumAlquiler = Convert.ToInt32(txtNumAlquiler.Text);
            TipoPago = Convert.ToInt32(txtTipoPago.Text);
            NumReserva = Convert.ToInt32(txtNumReserva.Text);

            clsPago oPago = new clsPago();
            oPago.idPago = idPago;
            oPago.Moneda = Moneda;
            oPago.NumAlquiler = NumAlquiler;
            oPago.TipoPago = TipoPago;
            oPago.NumReserva = NumReserva;

            if (oPago.Actualizar())
            {
                lblError.Text = "Se actualizó correctamente en la base de datos el producto de ID: " + idPago;
                LlenarGridPago();
            }
            else
            {
                lblError.Text = oPago.Error;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Int32 idPago;
            string Moneda;
            Int32 NumAlquiler;
            Int32 TipoPago;
            Int32 NumReserva;

            idPago = Convert.ToInt32(txtidPago.Text);
            Moneda = txtMoneda.Text;
            NumAlquiler = Convert.ToInt32(txtNumAlquiler.Text);
            TipoPago = Convert.ToInt32(txtTipoPago.Text);
            NumReserva = Convert.ToInt32(txtNumReserva.Text);

            clsPago oPago = new clsPago();
            oPago.idPago = idPago;
            oPago.Moneda = Moneda;
            oPago.NumAlquiler = NumAlquiler;
            oPago.TipoPago = TipoPago;
            oPago.NumReserva = NumReserva;

            if (oPago.Eliminar())
            {
                lblError.Text = "Se eliminó correctamente en la base de datos el ID: " + idPago;
                LlenarGridPago();
            }
            else
            {
                lblError.Text = oPago.Error;
            }
        }

        protected void grdProducto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}