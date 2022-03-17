using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libComunes.CapaObjetos;
using System.Web.UI.WebControls;

namespace libAlquilerVehiculos.BasesDatos
{
    public class clsTipoCombustible
    {


        #region Constructor
        public clsTipoCombustible()
        {
        }

        #endregion


        #region Propiedades y atributos
       
     
        public string Error { get; set; }
        public DropDownList cboTipoCombustible { get; set; }

        private string SQL;
        #endregion


        #region Metodos 

        public bool LlenarCombo()
        {
            SQL = "SELECT		idTipoCombustible AS ColumnaValor, Descripcion AS ColumnaTexto " +
                 "FROM         tblTipoCombustible " +
                 "ORDER BY     Descripcion; ";

            clsCombos oCombo = new clsCombos();
            //Se pasa el SQL
            oCombo.SQL = SQL;
            //Se pasa el combo vacío
            oCombo.cboGenericoWeb = cboTipoCombustible;
            oCombo.ColumnaTexto = "ColumnaTexto";
            oCombo.ColumnaValor = "ColumnaValor";

            if (oCombo.LlenarComboWeb())
            {
                //Capturo el combo lleno
                cboTipoCombustible = oCombo.cboGenericoWeb;
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
