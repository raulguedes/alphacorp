using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlphaCorp.modal.Cliente
{
    public partial class mCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public static void Editar(double id, string nome, string email, string telefone, MasterPage pagina)
        {
            try
            {
                pagina.Page.Form.Controls.Add(pagina.Page.LoadControl("~/modal/Cliente/ucCliente.ascx"));



                string function = string.Format("Show('{0}','{1}','{2}','{3}');", id, nome, email, telefone);
                pagina.Page.ClientScript.RegisterStartupScript(pagina.Page.GetType(), "Cliente", function, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void Editar(double id, string nome, string email, string telefone, Page pagina)
        {
            try
            {
                pagina.Form.Controls.Add(pagina.LoadControl("~/modal/Cliente/ucCliente.ascx"));

                string function = string.Format("Show('{0}','{1}','{2}','{3}');", id, nome, email, telefone);
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Cliente", function, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}