using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlphaCorp.modal.Funcionario
{
    public partial class mFuncionario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public static void Criar(Page pagina) {
            try
            {
                pagina.Form.Controls.Add(pagina.LoadControl("~/modal/Funcionario/ucFuncionario.ascx"));


                string function = string.Format("ShowFuncionario();");

                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "funcionario", function, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}