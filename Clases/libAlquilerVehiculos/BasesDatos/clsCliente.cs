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
    public class clsCliente
    {
        #region Constructor
        public clsCliente()
        {

        }
        #endregion
        #region Propiedades/Atributos
        public Int32 Documento { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public Int64 Telefono { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public Int32 TipoLicencia { get; set; }
        public string NombreApellidos
        {
            get { return Nombre + " " + PrimerApellido + " " + SegundoApellido; }
        }
        public string ApellidosNombre
        {
            get { return PrimerApellido + " " + SegundoApellido + " " + Nombre; }
        }
        public GridView grdCliente { get; set; }
        public GridView grdTipoLicencia { get; set; }
        public DropDownList cboTipoLicencia { get; set; }

        private string SQL;
        public string Error { get; private set; }

        #endregion

        #region Metodos


        public bool Insertar()
        {
            SQL = "INSERT INTO tblCliente (Documento, Nombre, fechaNacimiento, Direccion, " +
                                           "TipoLicencia, Telefono, PrimerApellido, SegundoApellido) " +
                  "VALUES (@Documento, @Nombre, @fechaNacimiento, @Direccion, @TipoLicencia, @Telefono, @PrimerApellido, @SegundoApellido)";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@Documento", Documento);
            oConexion.AgregarParametro("@Nombre", Nombre);
            oConexion.AgregarParametro("@FechaNacimiento", FechaNacimiento);
            oConexion.AgregarParametro("@Direccion", Direccion);
            oConexion.AgregarParametro("@TipoLicencia", TipoLicencia);
            oConexion.AgregarParametro("@Telefono", Telefono);
            oConexion.AgregarParametro("@PrimerApellido", PrimerApellido);
            oConexion.AgregarParametro("@SegundoApellido", SegundoApellido);

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
            SQL = "UPDATE       tblCliente " +
                  "SET          Nombre=@Nombre, " +
                                "FechaNacimiento=@FechaNacimiento, " +
                                "Direccion=@Direccion, " +
                                "TipoLicencia=@TipoLicencia, " +
                                "Telefono=@Telefono, " +
                                "PrimerApellido=@PrimerApellido, " +
                                "SegundoApellido=@SegundoApellido " +
                 "WHERE         Documento=@Documento";



            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@Documento", Documento);
            oConexion.AgregarParametro("@Nombre", Nombre);
            oConexion.AgregarParametro("@FechaNacimiento", FechaNacimiento);
            oConexion.AgregarParametro("@Direccion", Direccion);
            oConexion.AgregarParametro("@TipoLicencia", TipoLicencia);
            oConexion.AgregarParametro("@Telefono", Telefono);
            oConexion.AgregarParametro("@PrimerApellido", PrimerApellido);
            oConexion.AgregarParametro("@SegundoApellido", SegundoApellido);

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
            SQL = "DELETE FROM tblCliente WHERE Documento=@Documento";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@Documento", Documento);

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

            SQL = " SELECT      Nombre, fechaNacimiento, Direccion, TipoLicencia, Telefono, PrimerApellido, SegundoApellido " +
                  " FROM        tblCliente " +
                  " WHERE       Documento = @Documento";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@Documento", Documento);

            if (oConexion.Consultar())
            {
                if (oConexion.Reader.HasRows)
                {
                    oConexion.Reader.Read();
                    Nombre = oConexion.Reader.GetString(0);
                    FechaNacimiento = oConexion.Reader.GetDateTime(1);
                    Direccion = oConexion.Reader.GetString(2);
                    TipoLicencia = oConexion.Reader.GetInt32(3);
                    Telefono = oConexion.Reader.GetInt64(4);
                    PrimerApellido = oConexion.Reader.GetString(5);
                    SegundoApellido = oConexion.Reader.GetString(6);


                    oConexion.CerrarConexion();
                    return true;
                }
                else
                {
                    Error = "No existen datos para el cliente de documento: " + Documento;
                    return false;
                }
            }
            else
            {
                Error = oConexion.Error;
                return false;
            }
        }

        public bool LlenarGrid()
        {

            SQL = "SELECT         dbo.tblCliente.documento AS DOCUMENTO, dbo.tblCliente.Nombre AS NOMBRE, dbo.tblCliente.PrimerApellido AS[PRIMER APELLIDO], " +
                                    "dbo.tblCliente.SegundoApellido AS[SEGUNDO APELLIDO], dbo.tblCliente.fechaNacimiento AS[FECHA DE NACIMIENTO], " +
                                    "dbo.tblCliente.Direccion AS DIRECCION, dbo.tblCliente.Telefono AS TELEFONO, dbo.tblTipoLicencia.Categoria AS[CATEGORIA LICENCIA] " +
                    "FROM           dbo.tblCliente LEFT OUTER JOIN " +
                                    "dbo.tblTipoLicencia ON dbo.tblCliente.TipoLicencia = dbo.tblTipoLicencia.idTipoLicencia " +
                                    "AND dbo.tblCliente.TipoLicencia = dbo.tblTipoLicencia.idTipoLicencia " +
                    "GROUP BY       dbo.tblCliente.documento, dbo.tblCliente.Nombre, dbo.tblCliente.PrimerApellido, dbo.tblCliente.SegundoApellido, " +
                                    "dbo.tblCliente.fechaNacimiento, dbo.tblCliente.Direccion, dbo.tblCliente.Telefono, dbo.tblTipoLicencia.Categoria " +
                    "ORDER BY        DOCUMENTO";






            clsGrid oGrid = new clsGrid();
            oGrid.grdGenerico = grdCliente;
            oGrid.SQL = SQL;

            if (oGrid.LlenarGridWeb())
            {
                grdCliente = oGrid.grdGenerico;
                return true;
            }
            else
            {
                Error = oGrid.Error;
                return false;
            }
        }



        public bool LlenarCombo()
         {
             //Hay que crear la instrución SQL
             SQL =   "SELECT		documento AS ColumnaValor, Nombre AS ColumnaTexto " +
                     "FROM          dbo.tblCliente " +
                     "WHERE         TipoLicencia = @TipoLicencia " +
                     "ORDER BY      ColumnaTexto ";

             //Crear el objeto combo
             clsCombos oCombo = new clsCombos();
             //Se pasa el combo vacío
             oCombo.cboGenericoWeb = cboTipoLicencia;
             //Hay que agregar el parámetro a la clase de combos
             oCombo.AgregarParametro("@TipoLicencia", TipoLicencia);
             //Se pasa el sql
             oCombo.SQL = SQL;
             //Se pasan los nombres de las columnas
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
        

        #endregion
    }
}
