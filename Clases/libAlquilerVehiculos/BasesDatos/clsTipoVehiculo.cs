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
    public class clsTopoVehiculo
    {

        #region Constructor
        public clsTopoVehiculo()
        {

        }
        #endregion 

        #region Atributos/Propiedades
        public Int32 Codigo { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }

        public DropDownList cboTipoVehiculo { get; set; }
        private string SQL;
        public string Error { get; private set; }
        #endregion

        #region Metodos
        public bool Insertar()
        {

            SQL = "INSERT INTO tblTipoVehiculo (Nombre, Activo) " +
                  "VALUES (@prNombre, @prActivo)";


            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;


            oConexion.AgregarParametro("@prNombre", Nombre);
            oConexion.AgregarParametro("@prActivo", Activo);

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
            SQL = "UPDATE   tblTipoVehiculo " +
                  "SET      Nombre = @prNombre, " +
                           "Activo = @prActivo " +
                  "WHERE    idTipoVehiculo = @prCodigo";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prNombre", Nombre);
            oConexion.AgregarParametro("@prActivo", Activo);
            oConexion.AgregarParametro("@prCodigo", Codigo);

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
            SQL = "DELETE FROM  tblTipoVehiculo " +
                  "WHERE        idTipoVehiculo = @prCodigo";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prCodigo", Codigo);

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
            SQL = "SELECT       Nombre, Activo " +
                  "FROM         tblTipoVehiculo " +
                  "WHERE        idTipoVehiculo = @prCodigo";

            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prCodigo", Codigo);
     
            if (oConexion.Consultar())
            {
                if (oConexion.Reader.HasRows)
                {
                    
                    oConexion.Reader.Read();
    
                    Nombre = oConexion.Reader.GetString(0);
                    Activo = oConexion.Reader.GetBoolean(1);
                  
                    oConexion.CerrarConexion();
                    return true;
                 
                }
                else
                {
                    Error = "No se encontraron datos para el código: " + Codigo;
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
            SQL = "SELECT	    idTipoVehiculo AS ColumnaValor, Nombre AS ColumnaTexto " +
                  "FROM         tblTipoVehiculo " +
                  "ORDER BY     Nombre; ";

            clsCombos oCombo = new clsCombos();
            oCombo.cboGenericoWeb = cboTipoVehiculo;
            oCombo.SQL = SQL;
            oCombo.ColumnaTexto = "ColumnaTexto";
            oCombo.ColumnaValor = "ColumnaValor";

            if (oCombo.LlenarComboWeb())
            {
                cboTipoVehiculo = oCombo.cboGenericoWeb;
                return true;
            }
            else
            {
                Error = oCombo.Error;
                return false;
            }
        }
        #endregion
    }
}
