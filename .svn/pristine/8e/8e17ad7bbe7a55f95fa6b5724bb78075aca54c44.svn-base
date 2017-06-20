using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlphaCorp.modal.Notify
{
    public partial class mNotify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public static void Sucesso(string titulo, string mensagem, MasterPage pagina)
        {

            try
            {
                // buscando o "html" load da pagina ucNotify para a pagina.Page 
                pagina.Page.Form.Controls.Add(pagina.Page.LoadControl("~/modal/Notify/ucNotify.ascx"));
                //Manda o formato do scrpit que será chamado
                string function = string.Format("ShowSucesso('{0}','{1}');" , titulo, mensagem);
                //Agregando o html e o js na pagina.Page.
                pagina.Page.ClientScript.RegisterStartupScript(pagina.GetType(), "alert", function, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static void Sucesso(string titulo, string mensagem, Page pagina)
        {

            try
            {
                // buscando o "html" load da pagina ucNotify para a pagina.Page 
                pagina.Form.Controls.Add(pagina.LoadControl("~/modal/Notify/ucNotify.ascx"));
                //Manda o formato do scrpit que será chamado
                string function = string.Format("ShowSucesso('{0}','{1}');" , titulo, mensagem);
                //Agregando o html e o js na pagina.Page.
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "alert", function, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static void Erro(string titulo, string mensagem, MasterPage pagina)
        {

            try
            {
                // buscando o "html" load da pagina ucNotify para a pagina.Page 
                pagina.Page.Form.Controls.Add(pagina.Page.LoadControl("~/modal/Notify/ucNotify.ascx"));
                //Manda o formato do scrpit que será chamado
                string function = string.Format("ShowErro('{0}','{1}');" , titulo, mensagem);
                //Agregando o html e o js na pagina.Page.
                pagina.Page.ClientScript.RegisterStartupScript(pagina.GetType(), "alert", function, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static void Erro(string titulo, string mensagem, Page pagina)
        {

            try
            {
                // buscando o "html" load da pagina ucNotify para a pagina.Page 
                pagina.Form.Controls.Add(pagina.LoadControl("~/modal/Notify/ucNotify.ascx"));
                //Manda o formato do scrpit que será chamado
                string function = string.Format("ShowErro('{0}','{1}');", titulo, mensagem);
                //Agregando o html e o js na pagina.Page.
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "alert", function, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}