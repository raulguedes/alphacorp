using AlphaCorp.BLO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlphaCorp
{
    public partial class Evento1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["User"] != null)
                {
                    if ((Session["User"] as clsLoginBLO).Empresa)
                    {
                        lblUser.InnerText = (Session["User"] as clsLoginBLO).Nome;
                        lblNomeEmpresa.InnerText = (Session["User"] as clsLoginBLO).Nome.ToUpper();
                    }

                    else
                    {
                        lblUser.InnerText = (Session["User"] as clsLoginBLO).Nome;
                        lblNomeEmpresa.InnerText = (Session["User"] as clsLoginBLO).RazaoSocial.ToUpper();
                    }
                    GerenciarMenu();

                }
                else
                {
                    HttpContext.Current.Response.Redirect("Login.aspx?erro=SessionExpirada", false);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        protected void Evento_Click(object sender, EventArgs e)
        {
            try
            {
                modal.Evento.mEvento.criar(this);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        private void GerenciarMenu()
        {
            try
            {
                //Verifica se o login é da empresa ou de algum ADM.
                if ((Session["User"] as clsLoginBLO).Empresa || (Session["User"] as clsLoginBLO).IdTipoUser == (int)clsStatusBLO.TipoUser.Administrador)
                {
                    LiFuncionario.Visible = true;                    
                }
                else
                {
                    LiFuncionario.Visible = false;                    
                }
                if ((Session["User"] as clsLoginBLO).IdTipoUser == (int)clsStatusBLO.TipoUser.Supervisor)
                {                    
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}