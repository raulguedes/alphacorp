using AlphaCorp.BLL;
using AlphaCorp.BLO;
using AlphaCorp.BLO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlphaCorp
{
    public partial class Site : System.Web.UI.MasterPage
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
                    Response.Redirect("~/Login.aspx?erro=SessionExpirada", false);
                }

            }
            catch (Exception ex)
            {
                modal.Notify.mNotify.Erro("Erro", "Não foi possível presseguir!!!", this);
            }
        }
        protected void Evento_Click(object sender, EventArgs e)
        {
            try
            {
                modal.Evento.mEvento.criar(this);
            }
            catch (Exception)
            {
                modal.Notify.mNotify.Erro("Erro", "Não foi possível presseguir!!!", this);
            }

        }
        private void GerenciarMenu()
        {
            try
            {
                clsLoginBLO SessionUser = (clsLoginBLO)(Session["User"]);
                //Verifica se o login é da empresa ou de algum ADM.
                if (SessionUser.IdTipoUser == (int)clsStatusBLO.TipoUser.Administrador || SessionUser.Empresa)
                {
                    LiCargo.Visible = true;                    
                    LiDepartamento.Visible = true;
                    LiGerenciamento.Visible = true;
                    LiFuncionario.Visible = true;                    
                }
                if (SessionUser.IdTipoUser == (int)clsStatusBLO.TipoUser.Supervisor || SessionUser.IdTipoUser == (int)clsStatusBLO.TipoUser.Administrador || SessionUser.Empresa)
                {
                    LiProjeto.Visible = true;
                    LiCliente.Visible = true;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}