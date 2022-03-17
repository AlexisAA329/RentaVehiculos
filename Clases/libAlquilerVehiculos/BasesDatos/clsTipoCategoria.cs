using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libComunes.CapaObjetos;
using System.Web.UI.WebControls;

namespace libAlquilerVehiculos.BasesDatos
{
   public class clsTipoCategoria
    {

        #region Constructor
        public clsTipoCategoria()
        {
        }

        #endregion


        #region Propiedades y atributos


        public string Error { get; set; }
        public DropDownList cboCategoria { get; set; }

        private string SQL;
        #endregion


        #region Metodos 

        public bool LlenarCombo()
        {
            SQL = "SELECT		idCategoria AS ColumnaValor, Nombre AS ColumnaTexto " +
                 "FROM         tblCategoriaConduccion " +
                 "ORDER BY     Nombre; ";

            clsCombos oCombo = new clsCombos();
            //Se pasa el SQL
            oCombo.SQL = SQL;
            //Se pasa el combo vacío
            oCombo.cboGenericoWeb = cboCategoria;
            oCombo.ColumnaTexto = "ColumnaTexto";
            oCombo.ColumnaValor = "ColumnaValor";

            if (oCombo.LlenarComboWeb())
            {
                //Capturo el combo lleno
                cboCategoria = oCombo.cboGenericoWeb;
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
