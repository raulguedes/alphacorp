using AlphaCorp.BLO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlphaCorp.modal.Departamento
{
    public partial class mDepartamento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public static void Editar(string id, string departamento, MasterPage pagina)
        {
            try
            {
                pagina.Page.Form.Controls.Add(pagina.Page.LoadControl("~/modal/Departamento/ucDepartamento.ascx"));



                string function = string.Format("Show('{0}','{1}');", id, departamento);
                pagina.Page.ClientScript.RegisterStartupScript(pagina.Page.GetType(), "Departamento", function, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void Editar(string id, string departamento, Page pagina)
        {
            try
            {
                pagina.Form.Controls.Add(pagina.LoadControl("~/modal/Departamento/ucDepartamento.ascx"));

                string function = string.Format("Show('{0}','{1}');", id, departamento);
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Departamento", function, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}