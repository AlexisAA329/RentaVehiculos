using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libComunes.CapaDatos;
using libComunes.CapaObjetos;
using System.Web.UI.WebControls;

    public class clsPago
    {
        #region Propiedades/Atributos
        public Int32 idPago { get; set; }
        public string Moneda { get; set; }
        public Int32 NumAlquiler { get; set; }
        public Int32 TipoPago { get; set; }
        public Int32 NumReserva { get; set; }
        public GridView grdPago { get; set; }
        private string SQL;
        public string Error { get; private set; }
        #endregion
        #region Metodos
        public bool LlenarGrid()
        {
            //Se crea la instrucción sql
            SQL = "Select idPago, Moneda, NumAlquiler, TipoPago, NumReserva " +
                    "From tblPago ";
            //Se crea el objeto grid
            clsGrid oGrid = new clsGrid();
            //Paso el sql y el grid vacío
            oGrid.SQL = SQL;
            oGrid.grdGenerico = grdPago;
            //Invocar el llenado del grid
            if (oGrid.LlenarGridWeb())
            {
                //lee el grid lleno
                grdPago = oGrid.grdGenerico;
                return true;
            }
            else
            {
                Error = oGrid.Error;
                return false;
            }
        }
        public bool Insertar()
        {
            SQL = "insert into tblSubasta (idPago, Moneda, NumAlquiler, TipoPago, NumReserva) " +
                    "values (@idPago, @Moneda, @NumAlquiler, @TipoPago, @NumReserva) ";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;

            oConexion.AgregarParametro("@idPago", idPago);
            oConexion.AgregarParametro("@Moneda", Moneda);
            oConexion.AgregarParametro("@NumAlquiler", NumAlquiler);
            oConexion.AgregarParametro("@TipoPago", TipoPago);
            oConexion.AgregarParametro("@NumReserva", NumReserva);

            if (oConexion.EjecutarSentencia())
            {
                return true;
            }
            else
            {
                Error = oConexion.Error;
                return false;
            }
        }
        public bool Actualizar()
        {
            SQL = "UPDATE tblSubasta " +
                    "SET Moneda = @Moneda " +
                        "NumAlquiler = @NumAlquiler " +
                        "TipoPago = @TipoPago " +
                        "NumReserva = @NumReserva " +
                    "WHERE idPago = @idPago ";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@idPago", idPago);
            oConexion.AgregarParametro("@Moneda", Moneda);
            oConexion.AgregarParametro("@NumAlquiler", NumAlquiler);
            oConexion.AgregarParametro("@TipoPago", TipoPago);
            oConexion.AgregarParametro("@NumReserva", NumReserva);
            if (oConexion.EjecutarSentencia())
            {
                return true;
            }
            else
            {
                Error = oConexion.Error;
                return false;
            }
        }
        public bool Eliminar()
        {
            SQL = "DELETE FROM tblPago " +
                    "WHERE idPago = @idPago ";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@idPago", idPago);

            if (oConexion.EjecutarSentencia())
            {
                return true;
            }
            else
            {
                Error = oConexion.Error;
                return false;
            }
        }
        #endregion
    }

