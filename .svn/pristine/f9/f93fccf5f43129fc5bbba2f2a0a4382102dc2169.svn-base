using AlphaCorp.BLL;
using AlphaCorp.BLO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlphaCorp
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["User"] = null;
                AlertErro.Visible = false;
                string _parametro = Request.QueryString["erro"];
                if (!string.IsNullOrEmpty(_parametro))
                {
                    switch (_parametro)
                    {
                        case "SessionExpirada":
                            AlertErro.Visible = true;
                            lblAviso.Text = "Sessão Expirada";
                            break;
                    }
                }
            }
        }
        private void Acessar()
        {
            AlertErro.Visible = false;
            try
            {
                List<clsLoginBLO> _ListBLO = new List<clsLoginBLO>();

                clsLoginBLO UserBLO = new clsLoginBLO();
                UserBLO.Email = txtEmail.Value.ToLower();
                //Encriptando a senha
                UserBLO.Senha = txtSenha.Value;

                clsLoginBLL _UserBLL = new clsLoginBLL();

                //Verifica se existe mais de um usuario com os mesmos dados
                _ListBLO = _UserBLL.Find(UserBLO);
                if (_ListBLO.Count == 1)
                {
                    UserBLO = _ListBLO[0];
                    //Carrega a session.                    
                    Session["User"] = UserBLO;

                    //Status igual a Ativo ele redireciona para a tela seguinte.
                    if ((Session["User"] as clsLoginBLO).Status == true)
                    {
                        if (!(Session["User"] as clsLoginBLO).Empresa)
                        {
                            clsEmpresaBLO empresaBLO = new clsEmpresaBLO();
                            List<clsEmpresaBLO> _ListEmpresaBLO = new List<clsEmpresaBLO>();

                            empresaBLO.Id = (Session["User"] as clsLoginBLO).IdEmpresa;

                            clsEmpresaBLL empresaBLL = new clsEmpresaBLL();

                            _ListEmpresaBLO = empresaBLL.Find(empresaBLO);
                            (Session["User"] as clsLoginBLO).RazaoSocial = _ListEmpresaBLO[0].Nome;
                        }
                        HttpContext.Current.Response.Redirect("~/Home.aspx");


                    }
                    else
                    {
                        //Mensagem de erro para status igual a false.
                        AlertErro.Visible = true;
                        lblAviso.Text = clsUtilBLL.TipoMensagem("ErroLoginDesativado");
                    }
                }
                else
                {
                    //Mensagem caso seja encontrado mais de um registro com o mesmo usuario.
                    AlertErro.Visible = true;
                    lblAviso.Text = clsUtilBLL.TipoMensagem("ErroLogin");
                }
            }
            catch (Exception)
            {
                AlertErro.Visible = true;
                lblAviso.Text = clsUtilBLL.TipoMensagem("ErroLoginDesativado");
            }
        }
        private void Criar()
        {
            try
            {
                List<clsEmpresaBLO> _ListBLO = new List<clsEmpresaBLO>();

                clsEmpresaBLO _UserBLO = new clsEmpresaBLO();
                _UserBLO.Email = txtrEmail.Value.ToLower();
                //Encriptando a senha
                _UserBLO.Senha = txtrSenha.Value;

                _UserBLO.Nome = txtrNome.Value;
                /*
                     Verifica se o usuario é fisico(funcionario) ou juridico(Empresa)
                     true - empresa
                     false - funcionario
                 */
                _UserBLO.Empresa = true;
                _UserBLO.IdTipoUser = (int)clsStatusBLO.TipoUser.Administrador;
                _UserBLO.Status = true;
                //clsEmailBLL email = new clsEmailBLL();
                //email.Enviar("raul_guedes2010@hotmail.com ", _UserBLO, "Alpha Corp", "Apenas teste");

                clsEmpresaBLL _UserBLL = new clsEmpresaBLL();
                _UserBLL.Insert(_UserBLO);
                AlertErro.Visible = true;
                lblAviso.Text = "Cadastrado";

            }
            catch (Exception)
            {
                AlertErro.Visible = true;
                lblAviso.Text = clsUtilBLL.TipoMensagem("ErroLoginDesativado");
            }
        }
        protected void btnAcessar_Click(object sender, EventArgs e)
        {
            Acessar();
        }
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Criar();
        }
    }
}