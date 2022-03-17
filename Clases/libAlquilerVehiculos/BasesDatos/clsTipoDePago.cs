using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libComunes.CapaDatos;
using libComunes.CapaObjetos;
using System.Web.UI.WebControls;

namespace libAlquilerVehiculos.BasesDatos
{
    public class clsTipoDePago
    {

        #region Propiedades/Atributos
        public Int32 idTipoPago { get; set; }
        public string Descripcion { get; set; }
        public GridView grdTipoDePago { get; set; }

        private string SQL;
        public string Error { get; private set; }
        #endregion
        #region Metodos
        public bool LlenarGrid()
        {
            //Se crea la instrucción sql
            SQL = "Select idTipoPago, Descripcion " +
                    "from tblTipoPago";

            //Se crea el objeto grid
            clsGrid oGrid = new clsGrid();
            //Paso el sql y el grid vacío
            oGrid.SQL = SQL;
            oGrid.grdGenerico = grdTipoDePago;
            //Invocar el llenado del grid
            if (oGrid.LlenarGridWeb())
            {
                //lee el grid lleno
                grdTipoDePago = oGrid.grdGenerico;
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
            SQL = "insert into tblTipoPago(idTipoPago, Descripcion) " +
                    "Values (@idTipoPago, @Descripcion) ";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@idTipoPago", idTipoPago);
            oConexion.AgregarParametro("@Descripcion", Descripcion);

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
            SQL = "UPDATE tblTipoPago " +
                    "SET = @Descripcion " +
                    "WHERE idTipoPago = @idTipoPago ";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@idTipoPago", idTipoPago);
            oConexion.AgregarParametro("@Descripcion", Descripcion);

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
            SQL = "DELETE FROM tblTipoPago " +
                    "WHERE idTipoPago = @idTipoPago ";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@idTipoPago", idTipoPago);

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
}
