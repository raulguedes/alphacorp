using AlphaCorp.BLL;
using AlphaCorp.BLO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlphaCorp
{
    public partial class Funcionario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarGrid();
                CarregarDepartamento();
            }
        }
        [System.Web.Services.WebMethod]
        public static string Register(string[] mFuncionario)
        {
            //mFuncionario = {0-Nome, 1-E-mail, 2-Senha, 3-ConfirmarSenha, 4-HoraDiaria,5-Sexo 6-IdDepartamento ,7-IdCargo,8-TipoUsuario, 9-PermitirHoraExtra}
            string msg = string.Empty;
            try
            {
                bool vazio = false;
                foreach (string item in mFuncionario)
                {
                    if (string.IsNullOrEmpty(item))
                        vazio = true;
                }
                if (vazio != true)
                {
                    clsLoginBLO SessionUser = (HttpContext.Current.Session["User"] as clsLoginBLO);

                    clsLoginBLO _loginBLO = new clsLoginBLO();

                    if (SessionUser.Empresa)
                        _loginBLO.IdEmpresa = SessionUser.Id;
                    else
                        _loginBLO.IdEmpresa = SessionUser.IdEmpresa;

                    if (mFuncionario[2] == mFuncionario[3])
                    {
                        List<clsPessoaFisicaBLO> _listBLO = new List<clsPessoaFisicaBLO>();
                        clsPessoaFisicaBLO _UserBLO = new clsPessoaFisicaBLO();
                        _UserBLO.Nome = mFuncionario[0];
                        _UserBLO.Email = mFuncionario[1].ToLower();
                        _UserBLO.Senha = mFuncionario[2];
                        _UserBLO.HoraDiaria = TimeSpan.Parse(string.Format("{0:hh:mm}", mFuncionario[4]));
                        _UserBLO.Sexo = mFuncionario[5] == "1" ? clsStatusBLO.Sexo.Masculino.ToString() : clsStatusBLO.Sexo.Feminino.ToString();
                        if (mFuncionario[6] != "0")
                            _UserBLO.IdDepartamento = double.Parse(mFuncionario[6]);
                        if (mFuncionario[7] != "0")
                            _UserBLO.IdCargo = double.Parse(mFuncionario[7]);
                        _UserBLO.IdTipoUser = int.Parse(mFuncionario[8]);
                        if (mFuncionario[9] == "0")
                            _UserBLO.PermitirHoraExtra = false;
                        else if (mFuncionario[9] == "1")
                            _UserBLO.PermitirHoraExtra = true;

                        if (SessionUser.Empresa)
                            _UserBLO.IdEmpresa = SessionUser.Id;
                        if (!SessionUser.Empresa)
                            _UserBLO.IdEmpresa = SessionUser.IdEmpresa;
                        //Usuario ativo = true;
                        _UserBLO.Status = true;

                        /*
                            usuario é fisico(funcionario)
                             true - empresa
                             false - funcionario
                         */
                        _UserBLO.Empresa = false;

                        //clsEmailBLL email = new clsEmailBLL();
                        //email.Enviar("raul_guedes2010@hotmail.com ", _UserBLO, "Alpha Corp", "Apenas teste");
                        clsPessoaFisicaBLL _UserBLL = new clsPessoaFisicaBLL();
                        _UserBLL.Insert(_UserBLO);
                    }
                    else msg = "As senhas são diferentes!!";
                }
                else msg = "Algum campo esta vazio!!";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }
        [System.Web.Services.WebMethod]
        public static List<clsCargoBLO> CarregarCargo(string mId)
        {
            List<clsCargoBLO> list = new List<clsCargoBLO>();
            if (!string.IsNullOrEmpty(mId) && mId != "0")
            {
                clsCargoBLO objBLO = new clsCargoBLO();
                objBLO.IdDepartamento = double.Parse(mId);
                clsCargoBLL objBLL = new clsCargoBLL();
                list = objBLL.Find(objBLO);

            }
            return list;
        }
        protected void btnCriar_ServerClick(object sender, EventArgs e)
        {
            try
            {
                modal.Funcionario.mFuncionario.Criar(this);
            }
            catch (Exception)
            {
                modal.Notify.mNotify.Erro("Erro", "Erro ao cadastrar", this);
            }
        }
        public void Padrao(clsPessoaFisicaBLO objBLO)
        {
            try
            {
                if (Session["User"] != null)
                {
                    clsLoginBLO SessionUser = (clsLoginBLO)Session["User"];
                    if (SessionUser.Empresa)
                        objBLO.IdEmpresa = SessionUser.Id;
                    else
                        objBLO.IdEmpresa = SessionUser.IdEmpresa;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void CarregarGrid(clsPessoaFisicaBLO objBLO, List<clsPessoaFisicaBLO> _listBLO)
        {
            objBLO = new clsPessoaFisicaBLO();
            Padrao(objBLO);
            clsPessoaFisicaBLL objBLL = new clsPessoaFisicaBLL();
            _listBLO = new List<clsPessoaFisicaBLO>();
            //Instancia lista de Cliente          

            //A Session rebece a nova busca.
            Session["ListaFuncionario"] = _listBLO = objBLL.Find(objBLO);
            //Carrega GridView
            gvFuncionario.DataSource = _listBLO;
            gvFuncionario.DataBind();
        }
        private void CarregarGrid()
        {
            clsPessoaFisicaBLO objBLO = new clsPessoaFisicaBLO();
            List<clsPessoaFisicaBLO> _listBLO = new List<clsPessoaFisicaBLO>();
            Padrao(objBLO);
            objBLO.Status = true;
            clsPessoaFisicaBLL objBLL = new clsPessoaFisicaBLL();
            //Instancia lista de Cliente          

            //A Session rebece a nova busca.
            Session["ListaFuncionario"] = _listBLO = objBLL.Find(objBLO);
            //Carrega GridView
            gvFuncionario.DataSource = _listBLO;
            gvFuncionario.DataBind();

        }

        protected void gvFuncionario_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
        protected void gvFuncionario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvFuncionario.UseAccessibleHeader = true;
            gvFuncionario.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvFuncionario.PageIndex = e.NewPageIndex;
            CarregarGrid();
        }

        protected void btnConsultar_ServerClick(object sender, EventArgs e)
        {
            try
            {
                Find();
            }
            catch (Exception)
            {

                modal.Notify.mNotify.Erro("", "Erro", this);
            }
        }
        protected ListItem ListItem()
        {
            ListItem item = new ListItem();
            item.Value = "0";
            item.Text = "Selecione...";
            item.Selected = true;

            return item;
        }
        private void CarregarDepartamento()
        {
            try
            {
                clsLoginBLO SessionUser = (clsLoginBLO)Session["User"];
                clsDepartamentoBLO objBLO = new clsDepartamentoBLO();
                new Departamento().Padrao(objBLO);
                clsDepartamentoBLL objBLL = new clsDepartamentoBLL();


                ddlDepartamento.ClearSelection();
                ddlDepartamento.Items.Clear();
                ddlDepartamento.Items.Add(ListItem());
                ddlDepartamento.DataSource = objBLL.Find(objBLO);
                ddlDepartamento.DataTextField = "Nome";//nome do departamento
                ddlDepartamento.DataValueField = "Id";//o valor do seu Id
                ddlDepartamento.DataBind();// carrega os dados na dllDepartamento
            }
            catch (Exception)
            {
                modal.Notify.mNotify.Erro("Erro", "Não foi possível carregar os departamentos", this);
            }
        }
        private void CarregarCargo(clsCargoBLO objBLO, bool supervisor)
        {
            try
            {
                clsLoginBLO SessionUser = (clsLoginBLO)Session["User"];
                if (SessionUser.Empresa)
                    objBLO.IdEmpresa = SessionUser.Id;
                else
                    objBLO.IdEmpresa = SessionUser.IdEmpresa;
                clsCargoBLL objBLL = new clsCargoBLL();
                if (supervisor == true)
                {
                    ddlCargo.ClearSelection();
                    ddlCargo.Items.Clear();
                    ddlCargo.Items.Add(ListItem());
                    ddlCargo.DataSource = objBLL.Find(objBLO);
                    ddlCargo.DataTextField = "Nome";//nome do departamento
                    ddlCargo.DataValueField = "Id";//o valor do seu Id
                    ddlCargo.DataBind();// carrega os dados na dllDepartamento
                }
            }
            catch (Exception)
            {
                modal.Notify.mNotify.Erro("Erro", "Não foi possível carregar os departamentos", this);
            }
        }
        protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlDepartamento.SelectedValue != "0")
                {
                    clsCargoBLO BLO = new clsCargoBLO();
                    BLO.IdDepartamento = double.Parse(ddlDepartamento.SelectedValue);
                    CarregarCargo(BLO, true);
                }
            }
            catch (Exception)
            {
                modal.Notify.mNotify.Erro("Tente mais tarde.", "Cargo não carregado!!!,", this);
            }
        }

        public void Find()
        {
            clsPessoaFisicaBLO objBLO = new clsPessoaFisicaBLO();
            Padrao(objBLO);
            if (!string.IsNullOrEmpty(txtNome.Value))
                objBLO.Nome = txtNome.Value;
            if (ddlDepartamento.SelectedValue != "0")
                objBLO.IdDepartamento = double.Parse(ddlDepartamento.SelectedValue);
            if (ddlCargo.SelectedValue != "0")
                objBLO.IdCargo = double.Parse(ddlCargo.SelectedValue);
            if (ddlStatus.SelectedValue == "2")
                objBLO.Status = false;
            else
                objBLO.Status = true;
            clsPessoaFisicaBLL objBLL = new clsPessoaFisicaBLL();
            List<clsPessoaFisicaBLO> _listBLO = new List<clsPessoaFisicaBLO>();
            _listBLO = objBLL.Find(objBLO);
            if (_listBLO.Count != 0)
            {
                Session["ListaFuncionario"] = _listBLO = objBLL.Find(objBLO);
                //Carrega GridView
                gvFuncionario.DataSource = _listBLO;
                gvFuncionario.DataBind();
                modal.Notify.mNotify.Sucesso("Sucesso", "Busca concluída", this);
            }
            else
            {
                modal.Notify.mNotify.Sucesso("Busca concluída", "Nenhum dado encontrado", this);
                CarregarGrid();
            }
        }
    }
}