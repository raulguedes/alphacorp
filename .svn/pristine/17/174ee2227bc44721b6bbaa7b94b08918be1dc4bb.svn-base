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
    public partial class Gerenciamento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarDepartamento();
                Find();
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

                ddlFDepartamento.ClearSelection();
                ddlFDepartamento.Items.Clear();
                ddlFDepartamento.Items.Add(ListItem());
                ddlFDepartamento.DataSource = objBLL.Find(objBLO);
                ddlFDepartamento.DataTextField = "Nome";//nome do departamento
                ddlFDepartamento.DataValueField = "Id";//o valor do seu Id
                ddlFDepartamento.DataBind();// carrega os dados na dllDepartamento
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
                else
                {
                    ddlFCargo.ClearSelection();
                    ddlFCargo.Items.Clear();
                    ddlFCargo.Items.Add(ListItem());
                    ddlFCargo.DataSource = objBLL.Find(objBLO);
                    ddlFCargo.DataTextField = "Nome";//nome do departamento
                    ddlFCargo.DataValueField = "Id";//o valor do seu Id
                    ddlFCargo.DataBind();// carrega os dados na dllDepartamento
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
        protected void ddlFDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlFDepartamento.SelectedValue != "0")
                {
                    clsCargoBLO BLO = new clsCargoBLO();
                    BLO.IdDepartamento = double.Parse(ddlFDepartamento.SelectedValue);
                    CarregarCargo(BLO, false);
                }
            }
            catch (Exception)
            {
                modal.Notify.mNotify.Erro("Tente mais tarde.", "Cargo não carregado!!!,", this);
            }
        }
        /// <summary>
        /// Trás todos os Departamentos de tal usuario
        /// </summary>
        private void Find()
        {
            try
            {
                clsGerenciamentoSupervisorBLO objBLO = new clsGerenciamentoSupervisorBLO();
                Padrao(objBLO);
                clsGerenciamentoSupervisorBLL objBLL = new clsGerenciamentoSupervisorBLL();
                List<clsGerenciamentoSupervisorBLO> _listBLO = new List<clsGerenciamentoSupervisorBLO>();
                CarregarGrid(objBLO, _listBLO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Ultiliazado para passar parametro
        /// </summary>
        /// <param name="objBLO"></param>
        private void Find(clsGerenciamentoSupervisorBLO objBLO)
        {
            try
            {
                Padrao(objBLO);
                //Instancia Departamento
                List<clsGerenciamentoSupervisorBLO> _listBLO = new List<clsGerenciamentoSupervisorBLO>();
                CarregarGrid(objBLO, _listBLO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Passa o id da Empresa
        /// </summary>
        /// <param name="objBLO"></param>
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
        /// <summary>
        /// Carrega a gridView e a Session["ListaGerenciamentoSupervisor"]
        /// </summary>
        /// <param name="objBLO"></param>
        /// <param name="_listBLO"></param>
        private void CarregarGrid(clsGerenciamentoSupervisorBLO objBLO, List<clsGerenciamentoSupervisorBLO> _listBLO)
        {

            Padrao(objBLO);
            clsGerenciamentoSupervisorBLL objBLL = new clsGerenciamentoSupervisorBLL();
            //Instancia lista de Departamento          
            //A Session rebece a nova busca.
            Session["ListaGerenciamentoSupervisor"] = _listBLO = objBLL.Find(objBLO);
            //Carrega GridView
            gvGerenciamento.DataSource = _listBLO;
            gvGerenciamento.DataBind();

        }
        /// <summary>
        /// Tras todos os dados sem filtro
        /// </summary>
        private void CarregarGrid()
        {
            clsGerenciamentoSupervisorBLO objBLO = new clsGerenciamentoSupervisorBLO();
            List<clsGerenciamentoSupervisorBLO> _listBLO = new List<clsGerenciamentoSupervisorBLO>();
            Padrao(objBLO);
            clsGerenciamentoSupervisorBLL objBLL = new clsGerenciamentoSupervisorBLL();
            //Instancia lista de Departamento          

            //A Session rebece a nova busca.
            Session["ListaGerenciamentoSupervisor"] = _listBLO = objBLL.Find(objBLO);
            //Carrega GridView
            gvGerenciamento.DataSource = _listBLO;
            gvGerenciamento.DataBind();

        }
        private void CarregarDDLSupervisor()
        {
            clsPessoaFisicaBLO objBLO = new clsPessoaFisicaBLO();
            clsLoginBLO SessionUser = (clsLoginBLO)Session["User"];
            if (SessionUser.Empresa)
                objBLO.IdEmpresa = SessionUser.Id;
            else
                objBLO.IdEmpresa = SessionUser.IdEmpresa;

            if (ddlDepartamento.SelectedValue != "0")
                objBLO.IdDepartamento = int.Parse(ddlDepartamento.SelectedValue);
            if (ddlCargo.SelectedValue != "0")
                objBLO.IdCargo = int.Parse(ddlCargo.SelectedValue);
            objBLO.Status = true;

            clsPessoaFisicaBLL objBLL = new clsPessoaFisicaBLL();
            ddlSupervisor.ClearSelection();
            ddlSupervisor.Items.Clear();
            ddlSupervisor.Items.Add(ListItem());
            ddlSupervisor.DataSource = objBLL.FindSupervisor(objBLO);
            ddlSupervisor.DataTextField = "Nome";//nome do departamento
            ddlSupervisor.DataValueField = "Id";//o valor do seu Id
            ddlSupervisor.DataBind();// carrega os dados na dllDepartamento



        }
        private void CarregarDDLFuncionario()
        {
            clsPessoaFisicaBLO objBLO = new clsPessoaFisicaBLO();
            clsLoginBLO SessionUser = (clsLoginBLO)Session["User"];
            if (SessionUser.Empresa)
                objBLO.IdEmpresa = SessionUser.Id;
            else
                objBLO.IdEmpresa = SessionUser.IdEmpresa;

            if (ddlFDepartamento.SelectedValue != "0")
                objBLO.IdDepartamento = int.Parse(ddlFDepartamento.SelectedValue);
            if (ddlFCargo.SelectedValue != "0")
                objBLO.IdCargo = int.Parse(ddlFCargo.SelectedValue);
            objBLO.Status = true;

            clsPessoaFisicaBLL objBLL = new clsPessoaFisicaBLL();
            ddlFuncionario.ClearSelection();
            ddlFuncionario.Items.Clear();
            ddlFuncionario.Items.Add(ListItem());
            ddlFuncionario.DataSource = objBLL.FindFuncionario(objBLO);
            ddlFuncionario.DataTextField = "Nome";//nome do departamento
            ddlFuncionario.DataValueField = "Id";//o valor do seu Id
            ddlFuncionario.DataBind();// carrega os dados na dllDepartamento


        }
        protected void btnFiltrar_ServerClick(object sender, EventArgs e)
        {
            try
            {
                CarregarDDLSupervisor();
            }
            catch (Exception)
            {
                modal.Notify.mNotify.Erro("Erro", "Não foi possível filtrar", this);
            }
        }
        public void Padrao(clsGerenciamentoSupervisorBLO objBLO)
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
        protected void btnSalvar_ServerClick(object sender, EventArgs e)
        {
            try
            {
                if (ddlSupervisor.SelectedValue != "0" && ddlFuncionario.SelectedValue != "0")
                {
                    clsGerenciamentoSupervisorBLO objBLO = new clsGerenciamentoSupervisorBLO();
                    Padrao(objBLO);
                    objBLO.IdSupervisor = double.Parse(ddlSupervisor.SelectedValue);
                    objBLO.IdFuncionario = double.Parse(ddlFuncionario.SelectedValue);

                    clsGerenciamentoSupervisorBLL objBLL = new clsGerenciamentoSupervisorBLL();
                    objBLL.Insert(objBLO);
                    modal.Notify.mNotify.Sucesso("Sucesso", "Gerenciamento concluído", this);
                }
            }
            catch (Exception ex)
            {
                modal.Notify.mNotify.Erro("Erro", "Tente mais tarde", this);
            }
        }
        protected void btnFiltrarFuncionario_ServerClick(object sender, EventArgs e)
        {
            try
            {
                CarregarDDLFuncionario();
            }
            catch (Exception)
            {
                modal.Notify.mNotify.Erro("Erro", "Não foi possível filtrar", this);
            }
        }
        protected void gvGerenciamento_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Excluir")
            {            //Pega o id da linha ao clicar no botão
                int IdLinhaSelecionada = int.Parse(e.CommandArgument.ToString());
                string Cliente = string.Empty;
                foreach (GridViewRow row in gvGerenciamento.Rows)
                {

                    Label idBusca = (Label)row.FindControl("lblIdGerenciamento");
                    //Verifica se o Id da linha selecionada do id da busca.
                    if (idBusca.Text == IdLinhaSelecionada.ToString())
                    {
                        Label _recebeId = (Label)row.FindControl("lblIdGerenciamento");
                        clsGerenciamentoSupervisorBLO objBLO = new clsGerenciamentoSupervisorBLO();
                        Padrao(objBLO);
                        objBLO.Id = int.Parse(_recebeId.Text);
                        clsGerenciamentoSupervisorBLL objBLL = new clsGerenciamentoSupervisorBLL();
                        objBLL.Delete(objBLO);
                        CarregarGrid();
                        modal.Notify.mNotify.Sucesso("Sucesso", "Gerenciamento excluído", this);
                        break;
                    }
                }

            }
            else if (e.CommandName == "Buscar")
            {
                TextBox txtBSupervisor = (TextBox)gvGerenciamento.HeaderRow.FindControl("txtBSupervisor");
                TextBox txtBFuncionario = (TextBox)gvGerenciamento.HeaderRow.FindControl("txtBFuncionario");
                //string headerRowText = gvCliente.HeaderRow.Cells[1].Text;
                if (!string.IsNullOrEmpty(txtBSupervisor.Text) || !string.IsNullOrEmpty(txtBFuncionario.Text))
                {
                    clsGerenciamentoSupervisorBLO objBLO = new clsGerenciamentoSupervisorBLO();
                    Padrao(objBLO);
                    if (!string.IsNullOrEmpty(txtBSupervisor.Text))
                        objBLO.Supervisor = txtBSupervisor.Text;
                    if (!string.IsNullOrEmpty(txtBFuncionario.Text))
                        objBLO.Funcionario = txtBFuncionario.Text;
                    clsGerenciamentoSupervisorBLL objBLL = new clsGerenciamentoSupervisorBLL();
                    List<clsGerenciamentoSupervisorBLO> _listBLO = new List<clsGerenciamentoSupervisorBLO>();
                    _listBLO = objBLL.Find(objBLO);
                    if (_listBLO.Count != 0)
                    {
                        CarregarGrid(objBLO, _listBLO);
                        modal.Notify.mNotify.Sucesso("Sucesso", "Busca concluída", this);
                    }
                    else
                    {
                        modal.Notify.mNotify.Sucesso("Busca concluída", "Nenhum dado encontrado", this);
                        CarregarGrid();
                    }
                }
                else
                {
                    CarregarGrid();
                    modal.Notify.mNotify.Sucesso("Sucesso", "Busca concluída", this);
                }
            }
        }
        protected void gvGerenciamento_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvGerenciamento.UseAccessibleHeader = true;
            gvGerenciamento.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvGerenciamento.PageIndex = e.NewPageIndex;
            CarregarGrid();
        }
    }
}
