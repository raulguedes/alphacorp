using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlphaCorp.modal.Senha
{
    public partial class mSenha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public static void Alterar(Page pagina)
        {
            try
            {
                pagina.Form.Controls.Add(pagina.LoadControl("~/modal/Senha/ucSenha.ascx"));

                string function = string.Format("ShowSenha();");
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Senha", function, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}