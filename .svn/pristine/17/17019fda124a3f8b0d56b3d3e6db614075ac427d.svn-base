using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlphaCorp.modal.Cargo
{
    public partial class mCargo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public static void Editar(double id, string cargo, double idDepartamento, MasterPage pagina)
        {
            try
            {
                pagina.Page.Form.Controls.Add(pagina.Page.LoadControl("~/modal/Cargo/ucCargo.ascx"));



                string function = string.Format("Show('{0}','{1}','{2}');", id, cargo, idDepartamento);
                pagina.Page.ClientScript.RegisterStartupScript(pagina.Page.GetType(), "Cargo", function, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void Editar(double id, string cargo, double idDepartamento, Page pagina)
        {
            try
            {
                pagina.Form.Controls.Add(pagina.LoadControl("~/modal/Cargo/ucCargo.ascx"));

                string function = string.Format("Show('{0}','{1}','{2}');", id, cargo,idDepartamento);
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Cargo", function, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}