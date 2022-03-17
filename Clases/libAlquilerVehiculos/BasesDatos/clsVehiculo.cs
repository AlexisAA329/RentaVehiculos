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
   public class clsVehiculo
    {
        #region Constructor
        public clsVehiculo()
        {

        }
        #endregion


        #region Propiedades/Atributos
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string Color { get; set; }
        public Double Kilometraje { get; set; }
        public Int32 CodigoTipoVehiculo { get; set; }
        public Int32 CodigoTipoCombustible{ get; set; }
        public Int32 CodigoTipoCategoria { get; set; }

        public GridView grdVehiculo { get; set; }
        public DropDownList cboVehiculo { get; set; }
        public DropDownList cboCombustible { get; set; }

        public DropDownList cboCategoria { get; set; }

        private string SQL;
        public string Error { get; private set; }


        #endregion

        #region Metodos
        public bool Insertar()
        {
            SQL = "INSERT INTO tblVehiculo (Placa, Modelo, Marca, Color, Kilometraje , TipoCombustible, TipoVehiculo, codCategoria) " +
                  "VALUES (@Placa, @Modelo, @Marca, @Color, @Kilometraje, @TipoCombustible, @TipoVehiculo, @codCategoria)";

            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;
   
            oConexion.AgregarParametro("@Placa", Placa);
            oConexion.AgregarParametro("@Modelo", Modelo);
            oConexion.AgregarParametro("@Marca", Marca);
            oConexion.AgregarParametro("@Color", Color);
            oConexion.AgregarParametro("@Kilometraje", Kilometraje);
            oConexion.AgregarParametro("@TipoCombustible", CodigoTipoCombustible);
            oConexion.AgregarParametro("@TipoVehiculo", CodigoTipoVehiculo);
            oConexion.AgregarParametro("@codCategoria", CodigoTipoCategoria);



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
            SQL = "UPDATE   tblVehiculo " +
                  "SET      Modelo           = @Modelo, " +                          
                           "Marca = @Marca,  " +
                           "color = @Color, " +
                           "Kilometraje = @Kilometraje, " +
                           "TipoCombustible = @TipoCombustible, " +
                           "TipoVehiculo = @TipoVehiculo, " +
                           "codCategoria = @codCategoria " +
                  "WHERE    Placa = @Placa";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@Placa", Placa);
            oConexion.AgregarParametro("@Modelo", Modelo);
            oConexion.AgregarParametro("@Marca", Marca);
            oConexion.AgregarParametro("@Color", Color);
            oConexion.AgregarParametro("@Kilometraje", Kilometraje);
            oConexion.AgregarParametro("@TipoCombustible", CodigoTipoCombustible);
            oConexion.AgregarParametro("@TipoVehiculo", CodigoTipoVehiculo);
            oConexion.AgregarParametro("@codCategoria", CodigoTipoCategoria);

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
            SQL = "DELETE FROM   tblVehiculo " +
                  "WHERE    Placa = @Placa";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@Placa", Placa);

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

            SQL = " SELECT      Modelo, Marca, Color, Kilometraje, TipoCombustible, TipoVehiculo, codCategoria " +
                  " FROM        tblVehiculo " +
                  " WHERE       Placa = @Placa";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@Placa", Placa);

            if (oConexion.Consultar())
            {
                if (oConexion.Reader.HasRows)
                {
                    oConexion.Reader.Read();
                    Modelo = oConexion.Reader.GetString(0);
                    Marca = oConexion.Reader.GetString(1);
                    Color = oConexion.Reader.GetString(2);
                    Kilometraje = oConexion.Reader.GetDouble(3);
                    CodigoTipoCombustible = oConexion.Reader.GetInt32(4);
                    CodigoTipoVehiculo = oConexion.Reader.GetInt32(5);
                    CodigoTipoCategoria = oConexion.Reader.GetInt32(6);

                    oConexion.CerrarConexion();
                    return true;
                }
                else
                {
                    Error = "No existen datos para el cliente de documento: " + Placa;
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
            //Primero se crea el SQL
            SQL = "SELECT			dbo.tblTipoVehiculo.idTipoVehiculo AS [Cod Tipo Vehiculo], dbo.tblTipoVehiculo.Nombre AS [Tipo Vehiculo], " +
                                    "dbo.tblVehiculo.Placa, dbo.tblVehiculo.Modelo, dbo.tblVehiculo.Marca, dbo.tblVehiculo.Color, " +
                                    "dbo.tblVehiculo.Kilometraje, dbo.tblCategoriaConduccion.idCategoria AS [Cod Categoria Conduccion], " +
                                    "dbo.tblCategoriaConduccion.Nombre AS [Categoria Conduccion], " +
                                    "dbo.tblTipoCombustible.IdTipoCombustible AS [Cod Tipo Combustible], " +
                                    "dbo.tblTipoCombustible.Descripcion AS [Tipo Combustible] " +
                    "FROM           dbo.tblVehiculo INNER JOIN dbo.tblTipoVehiculo " +
                                    "ON dbo.tblVehiculo.TipoVehiculo = dbo.tblTipoVehiculo.idTipoVehiculo INNER JOIN " +
                                    "dbo.tblCategoriaConduccion ON dbo.tblVehiculo.CodCategoria = dbo.tblCategoriaConduccion.idCategoria INNER JOIN " +                                   
                                    "dbo.tblTipoCombustible ON dbo.tblVehiculo.TipoVehiculo = dbo.tblTipoCombustible.IdTipoCombustible " +
                    "ORDER BY       [Tipo Vehiculo], dbo.tblVehiculo.Modelo, dbo.tblVehiculo.Placa; ";

            //Se crea la clase grid
            clsGrid oGrid = new clsGrid();
            //Se pasa el grid vacío
            oGrid.grdGenerico = grdVehiculo;
            //Se pasa el sql
            oGrid.SQL = SQL;
            //Se invoca el método para llenar el grid
            if (oGrid.LlenarGridWeb())
            {
                //Se pasa el grid lleno
                grdVehiculo = oGrid.grdGenerico;
                return true;
            }
            else
            {
                Error = oGrid.Error;
                return false;
            }
        }
        public bool LlenarComboVehiculo()
        {
            //Hay que crear la instrución SQL
            SQL = "SELECT		Placa AS ColumnaValor, Marca AS ColumnaTexto " +
                    "FROM       dbo.tblVehiculo " +
                    "WHERE       TipoVehiculo = @prTipoVehiculo " +
                    "ORDER BY    ColumnaTexto ";

            //Crear el objeto combo
            clsCombos oCombo = new clsCombos();
            //Se pasa el combo vacío
            oCombo.cboGenericoWeb = cboVehiculo;
            //Hay que agregar el parámetro a la clase de combos
            oCombo.AgregarParametro("@prTipoVehiculo", CodigoTipoVehiculo);
            //Se pasa el sql
            oCombo.SQL = SQL;
            //Se pasan los nombres de las columnas
            oCombo.ColumnaTexto = "ColumnaTexto";
            oCombo.ColumnaValor = "ColumnaValor";

            if (oCombo.LlenarComboWeb())
            {
                cboVehiculo = oCombo.cboGenericoWeb;
                return true;
            }
            else
            {
                Error = oCombo.Error;
                return false;
            }
        }

        public bool LlenarComboCombustible()
        {
            //Hay que crear la instrución SQL
            SQL = "SELECT		Placa AS ColumnaValor, Marca AS ColumnaTexto " +
                    "FROM       dbo.tblVehiculo " +
                    "WHERE       TipoCombustible = @prTipoCombustible " +
                    "ORDER BY    ColumnaTexto ";

            //Crear el objeto combo
            clsCombos oCombo = new clsCombos();
            //Se pasa el combo vacío
            oCombo.cboGenericoWeb = cboCombustible;
            //Hay que agregar el parámetro a la clase de combos
            oCombo.AgregarParametro("@prTipoCombustible", CodigoTipoCombustible);
            //Se pasa el sql
            oCombo.SQL = SQL;
            //Se pasan los nombres de las columnas
            oCombo.ColumnaTexto = "ColumnaTexto";
            oCombo.ColumnaValor = "ColumnaValor";

            if (oCombo.LlenarComboWeb())
            {
                cboCombustible = oCombo.cboGenericoWeb;
                return true;
            }
            else
            {
                Error = oCombo.Error;
                return false;
            }
        }

        public bool LlenarComboCategoria()
        {
            //Hay que crear la instrución SQL
            SQL = "SELECT		Placa AS ColumnaValor, Marca AS ColumnaTexto " +
                    "FROM       dbo.tblVehiculo " +
                    "WHERE       CodCategoria = @prCodCategoria " +
                    "ORDER BY    ColumnaTexto ";

            //Crear el objeto combo
            clsCombos oCombo = new clsCombos();
            //Se pasa el combo vacío
            oCombo.cboGenericoWeb = cboCategoria;
            //Hay que agregar el parámetro a la clase de combos
            oCombo.AgregarParametro("@prCodCategoria", CodigoTipoCategoria);
            //Se pasa el sql
            oCombo.SQL = SQL;
            //Se pasan los nombres de las columnas
            oCombo.ColumnaTexto = "ColumnaTexto";
            oCombo.ColumnaValor = "ColumnaValor";

            if (oCombo.LlenarComboWeb())
            {
                cboCategoria = oCombo.cboGenericoWeb;
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
