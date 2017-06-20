using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlphaCorp.modal.Evento
{
    public partial class mEvento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public static void criar(MasterPage pagina)
        {
            pagina.Page.Form.Controls.Add(pagina.Page.LoadControl("~/modal/Evento/ucEvento.ascx"));
            //string titulo = title;
            //string mensagem = body;

            string function = string.Format("Show();");
            pagina.Page.ClientScript.RegisterStartupScript(pagina.GetType(), "alert", function, true);
        }
    }
}