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
    public class clsTipoLicencia
    {
        #region Constructor
        public clsTipoLicencia()
        {

        }
        #endregion

        #region Propiedades y atributos
        public Int32 idTipoLicencia { get; set; }
        public string Categoria { get; set; }
        public DropDownList cboTipoLicencia { get; set; }

        private string SQL;
        public string Error { get; private set; }
        #endregion

        #region Metodos 
        public bool Insertar()
        {

            SQL = "INSERT INTO tblTipoLicencia (Categoria) " +
                  "VALUES (@prCategoria)";


            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;

            oConexion.AgregarParametro("@prCategoria", Categoria);

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
            SQL = "UPDATE   tblTipoLicencia " +
                  "SET      Categoria = @prCategoria " +
                  "WHERE    idTipoLicencia = @pridTipoLicencia";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prCategoria", Categoria);
            oConexion.AgregarParametro("@pridTipoLicencia", idTipoLicencia);


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
        public bool Borrar()
        {
            SQL = "DELETE FROM  tblTipoLicencia " +
                  "WHERE        idTipoLicencia = @pridTipoLicencia";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@pridTipoLicencia", idTipoLicencia);

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
        public bool Consultar()
        {
            SQL = "SELECT       Categoria " +
                  "FROM         tblTipoLicencia " +
                  "WHERE        idTipoLicencia = @pridTipoLicencia";

            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@pridTipoLicencia", idTipoLicencia);

            if (oConexion.Consultar())
            {
                if (oConexion.Reader.HasRows)
                {

                    oConexion.Reader.Read();

                    Categoria = oConexion.Reader.GetString(0);

                    oConexion.CerrarConexion();
                    return true;

                }
                else
                {
                    Error = "No se encontraron datos para el código: " + idTipoLicencia;
                    return false;
                }
            }
            else
            {
                Error = oConexion.Error;
                return false;
            }
        }
        public bool LlenarCombo()
        {
            SQL = "SELECT	   idTipoLicencia AS ColumnaValor, Categoria AS ColumnaTexto " +
                  "FROM        tblTipoLicencia " +
                  "ORDER BY    idTipoLicencia; ";

            clsCombos oCombo = new clsCombos();
            oCombo.SQL = SQL;
            oCombo.cboGenericoWeb = cboTipoLicencia;
            oCombo.ColumnaTexto = "ColumnaTexto";
            oCombo.ColumnaValor = "ColumnaValor";

            if (oCombo.LlenarComboWeb())
            {
                cboTipoLicencia = oCombo.cboGenericoWeb;
                return true;
            }
            else
            {
                Error = oCombo.Error;
                return false;
            }
        }
        # endregion
    }
}
