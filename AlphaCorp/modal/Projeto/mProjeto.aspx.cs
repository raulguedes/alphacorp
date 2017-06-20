using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlphaCorp.modal.Projeto
{
    public partial class mProjeto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public static void Criar(MasterPage pagina)
        {
            try
            {
                pagina.Page.Form.Controls.Add(pagina.Page.LoadControl("~/modal/Projeto/ucProjeto.ascx"));



                string function = string.Format("ShowCriar();");
                pagina.Page.ClientScript.RegisterStartupScript(pagina.Page.GetType(), "Projeto", function, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void Criar(Page pagina)
        {
            try
            {
                pagina.Form.Controls.Add(pagina.LoadControl("~/modal/Projeto/ucProjeto.ascx"));

                string function = string.Format("ShowCriar();");
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Projeto", function, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Editar(double id, string projeto, double idDepartamento, double idCliente, int idStatus, Page pagina)
        {
            try
            {
                pagina.Form.Controls.Add(pagina.LoadControl("~/modal/Projeto/ucProjeto.ascx"));

                string function = string.Format("ShowEditar('{0}','{1}','{2}','{3}','{4}');", id, projeto, idDepartamento, idCliente, idStatus);
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Projeto", function, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void Editar(double id, string projeto, double idDepartamento, double idCliente, int idStatus, MasterPage pagina)
        {
            try
            {
                pagina.Page.Form.Controls.Add(pagina.Page.LoadControl("~/modal/Projeto/ucProjeto.ascx"));

                string function = string.Format("ShowEditar('{0}','{1}','{2}','{3}','{4}');", id, projeto, idDepartamento, idCliente, idStatus);
                pagina.Page.ClientScript.RegisterStartupScript(pagina.Page.GetType(), "Projeto", function, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}