using AlphaCorp.BLL;
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
    public partial class Timesheet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User"] != null)
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["Editar"]))
                    {
                        double _Id = double.Parse(Request.QueryString["Editar"].ToString());
                        btnSalvarTimesheet.CommandArgument = "Editar";
                        VerificarSession(_Id);
                    }
                    else
                        btnSalvarTimesheet.CommandArgument = "";

                    if (!(Session["User"] as clsLoginBLO).Empresa)
                    {
                        if ((Session["User"] as clsLoginBLO).IdTipoUser != (int)clsStatusBLO.TipoUser.Administrador)
                            if ((Session["User"] as clsLoginBLO).IdTipoUser != (int)clsStatusBLO.TipoUser.Supervisor)
                                LiTimesheet_Aprovar.Visible = false;
                    }
                }
                CarregarDepartamento();
            }
        }
        #region Editar
        private void VerificarSession(double Id)
        {
            try
            {
                //Session carregada na pagina anterior (Timesheet_Consulta)
                var ListaTime = (from Time in (List<clsTimePadraoBLO>)HttpContext.Current.Session["ListaConsulta"] where Time.Id == Id select Time).SingleOrDefault();
                if (ListaTime != null)
                    PreencherCampo(Id);
                else
                    modal.Notify.mNotify.Erro("Erro", "Timesheet não encontrado", this);
            }
            catch (Exception ex)
            {
                modal.Notify.mNotify.Erro("Erro", "" + ex.Message, this);
            }
        }
        protected clsTimePadraoBLO PreencherCampo(double Id)
        {
            clsTimePadraoBLO objBLO = new clsTimePadraoBLO();
            clsLoginBLO SessionUser = (Session["User"] as clsLoginBLO);

            List<clsTimePadraoBLO> _listBLO = new List<clsTimePadraoBLO>();
            _listBLO = Find(Id);
            if (_listBLO.Count == 1)
            {
                foreach (clsTimePadraoBLO item in _listBLO)
                {
                    Session["IdTimesheet"] = item.Id;
                    txtData.Value = string.Format("{0:00/00/0000}", item.Data.ToString());
                    txtDuracao.Value = item.Duracao.ToString();
                    txtDescricao.Text = item.Descricao;
                    txtDuracaoExtra.Value = item.HoraExtra.ToString();
                    txtDescricaoExtra.Text = item.DescricaoExtra;
                    ddlDepartamento.SelectedValue = item.IdDepartamento.ToString();
                    ddlDepartamento_SelectedIndexChanged(this,new EventArgs());
                    ddlProjeto.SelectedValue = item.IdProjeto.ToString();
                }
            }
            return objBLO;
        }
        protected clsTimePadraoBLO PreencherBLO()
        {
            clsTimePadraoBLO objBLO = new clsTimePadraoBLO();
            clsLoginBLO SessionUser = (Session["User"] as clsLoginBLO);
            if (Session["IdTimesheet"] != null)
            {                
                Padrao(objBLO);
                objBLO.Id = double.Parse(Session["IdTimesheet"].ToString());
                objBLO.DataEntrada = DateTime.Now;

                if (!string.IsNullOrEmpty(txtData.Value))
                    objBLO.Data = Convert.ToDateTime(txtData.Value);

                if (!string.IsNullOrEmpty(txtDuracao.Value))
                    objBLO.Duracao = TimeSpan.Parse(txtDuracao.Value.ToString());

                objBLO.Descricao = txtDescricao.Text;
                //objBLO.IdAtividade = ddlAtividade.SelectedIndex;
                objBLO.IdDepartamento = double.Parse(ddlDepartamento.SelectedValue);
                objBLO.IdFuncionario = SessionUser.Id;
                if (ddlProjeto.SelectedValue != "0")
                    objBLO.IdProjeto = double.Parse(ddlProjeto.SelectedValue);
                objBLO.IdStatus = (int)clsStatusBLO.Timesheet.Aguardando;
                if (!string.IsNullOrEmpty(txtDuracaoExtra.Value))
                    objBLO.HoraExtra = TimeSpan.Parse(txtDuracaoExtra.Value);
                else
                    objBLO.HoraExtra = TimeSpan.Parse("00:00:00");
                objBLO.DescricaoExtra = txtDescricaoExtra.Text;
            }

            return objBLO;
        }
        private void Editar()
        {
            try
            {
                clsLoginBLO SessionUser = (Session["User"] as clsLoginBLO);
                clsTimePadraoBLO objBLO = new clsTimePadraoBLO();
                objBLO = PreencherBLO();

                clsTimesheetBLL objBLL = new clsTimesheetBLL();
                objBLL.Transferir(objBLO);
                modal.Notify.mNotify.Sucesso("Sucesso", "Timesheet editado", this);
            }
            catch (Exception ex)
            {
                modal.Notify.mNotify.Erro("Erro", "Não foi possível editar", this);
            }

        }
        public List<clsTimePadraoBLO> Find(double Id)
        {
            List<clsTimePadraoBLO> _listBLO = new List<clsTimePadraoBLO>();
            try
            {
                clsTimePadraoBLO objBLO = new clsTimePadraoBLO();
                Padrao(objBLO);
                clsLoginBLO SessionUser = (clsLoginBLO)HttpContext.Current.Session["User"];
                objBLO.Id = Id;
                objBLO.IdSupervisor = SessionUser.Id;
                clsTimesheetBLL objBLL = new clsTimesheetBLL();
                _listBLO = objBLL.Find(objBLO);
            }
            catch (Exception)
            {

            }
            return _listBLO;
        }
        #endregion
        #region Insert
        private void InsertVerificar()
        {
            clsLoginBLO SessionUser = (clsLoginBLO)Session["User"];
            if (SessionUser.Empresa)
                InsertParaEmpresa();
            else
            {
                if (TimeSpan.Parse(txtDuracao.Value) <= SessionUser.HoraDiaria)
                    Insert();
                else
                    modal.Notify.mNotify.Erro("Erro", "Número de horas excedida.Maxima diaria " + SessionUser.HoraDiaria, this);
            }
        }
        private void Insert()
        {
            try
            {
                if (ddlDepartamento.SelectedValue != "0" && ddlProjeto.SelectedValue != "0")
                {
                    clsLoginBLO SessionUser = (clsLoginBLO)Session["User"];
                    clsWaitsheetBLO objBLO = new clsWaitsheetBLO();
                    objBLO.DataEntrada = DateTime.Now;

                    if (!string.IsNullOrEmpty(txtData.Value))
                        objBLO.Data = Convert.ToDateTime(txtData.Value);

                    if (!string.IsNullOrEmpty(txtDuracao.Value))
                        objBLO.Duracao = TimeSpan.Parse(txtDuracao.Value.ToString());

                    objBLO.Descricao = txtDescricao.Text;
                    //objBLO.IdAtividade = ddlAtividade.SelectedIndex;
                    objBLO.IdDepartamento = double.Parse(ddlDepartamento.SelectedValue);
                    //Verifica se é login da empresa
                    if (SessionUser.Empresa)
                        objBLO.IdEmpresa = SessionUser.Id;
                    else
                        objBLO.IdEmpresa = SessionUser.IdEmpresa;
                    objBLO.IdFuncionario = SessionUser.Id;
                    if (ddlProjeto.SelectedValue != "0")
                        objBLO.IdProjeto = double.Parse(ddlProjeto.SelectedValue);
                    objBLO.IdStatus = (int)clsStatusBLO.Timesheet.Aguardando;
                    if (!string.IsNullOrEmpty(txtDuracaoExtra.Value))
                        objBLO.HoraExtra = TimeSpan.Parse(txtDuracaoExtra.Value);
                    else
                        objBLO.HoraExtra = TimeSpan.Parse("00:00:00");
                    objBLO.DescricaoExtra = txtDescricaoExtra.Text;

                    clsWaitsheetBLL waitBLL = new clsWaitsheetBLL();
                    waitBLL.Insert(objBLO);
                    modal.Notify.mNotify.Sucesso("Sucesso", "Cadastrado", this);
                }
                else
                    modal.Notify.mNotify.Erro("Erro", "Campo(s) ainda não selecionado(s)", this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void InsertParaEmpresa()
        {
            try
            {
                if (ddlDepartamento.SelectedValue != "0" && ddlProjeto.SelectedValue != "0")
                {
                    clsLoginBLO SessionUser = (clsLoginBLO)Session["User"];
                    clsTimesheetBLO objBLO = new clsTimesheetBLO();
                    objBLO.DataEntrada = DateTime.Now;

                    if (!string.IsNullOrEmpty(txtData.Value))
                        objBLO.Data = Convert.ToDateTime(txtData.Value);

                    if (!string.IsNullOrEmpty(txtDuracao.Value))
                        objBLO.Duracao = TimeSpan.Parse(txtDuracao.Value.ToString());

                    objBLO.Descricao = txtDescricao.Text;
                    objBLO.IdDepartamento = double.Parse(ddlDepartamento.SelectedValue);
                    objBLO.IdEmpresa = SessionUser.Id;
                    objBLO.IdFuncionario = SessionUser.Id;
                    if (ddlProjeto.SelectedValue != "0")
                        objBLO.IdProjeto = double.Parse(ddlProjeto.SelectedValue);
                    objBLO.IdStatus = (int)clsStatusBLO.Timesheet.Aprovado;
                    if (!string.IsNullOrEmpty(txtDuracaoExtra.Value))
                        objBLO.HoraExtra = TimeSpan.Parse(txtDuracaoExtra.Value);
                    else
                        objBLO.HoraExtra = TimeSpan.Parse("00:00:00");
                    objBLO.DescricaoExtra = txtDescricaoExtra.Text;
                    objBLO.IdSupervisor = SessionUser.Id;
                    clsTimesheetBLL timeBLL = new clsTimesheetBLL();
                    timeBLL.Insert(objBLO);
                    modal.Notify.mNotify.Sucesso("Sucesso", "Cadastrado", this);
                }
                else
                    modal.Notify.mNotify.Erro("Erro", "Campo(s) ainda não selecionado(s)", this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        protected void Padrao(clsProjetoBLO objBLO)
        {
            clsLoginBLO SessionUser = (clsLoginBLO)Session["User"];
            if (SessionUser.Empresa)
                objBLO.IdEmpresa = SessionUser.Id;
            else
                objBLO.IdEmpresa = SessionUser.IdEmpresa;
        }
        protected void Padrao(clsDepartamentoBLO objBLO)
        {
            clsLoginBLO SessionUser = (clsLoginBLO)Session["User"];
            if (SessionUser.Empresa)
                objBLO.IdEmpresa = SessionUser.Id;
            else
                objBLO.IdEmpresa = SessionUser.IdEmpresa;
        }
        protected void Padrao(clsWaitsheetBLO objBLO)
        {
            clsLoginBLO SessionUser = (clsLoginBLO)Session["User"];
            if (SessionUser.Empresa)
                objBLO.IdEmpresa = SessionUser.Id;
            else
                objBLO.IdEmpresa = SessionUser.IdEmpresa;
        }
        protected void Padrao(clsTimePadraoBLO objBLO)
        {
            clsLoginBLO SessionUser = (clsLoginBLO)Session["User"];
            if (SessionUser.Empresa)
                objBLO.IdEmpresa = SessionUser.Id;
            else
                objBLO.IdEmpresa = SessionUser.IdEmpresa;
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
                Padrao(objBLO);
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
        private void CarregarProjeto(clsProjetoBLO objBLO)
        {
            try
            {
                Padrao(objBLO);
                clsProjetoBLL objBLL = new clsProjetoBLL();
                ddlProjeto.ClearSelection();
                ddlProjeto.Items.Clear();
                ddlProjeto.Items.Add(ListItem());
                ddlProjeto.DataSource = objBLL.Find(objBLO);
                ddlProjeto.DataTextField = "Nome";//nome do departamento
                ddlProjeto.DataValueField = "Id";//o valor do seu Id
                ddlProjeto.DataBind();// carrega os dados na dllDepartamento
            }
            catch (Exception)
            {
                modal.Notify.mNotify.Erro("Erro", "Não foi possível carregar os departamentos", this);
            }
        }
        protected void btnSalvarTimesheet_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnSalvarTimesheet.CommandArgument == "Editar")
                    Editar();
                else
                    InsertVerificar();
            }
            catch (Exception)
            {
                modal.Notify.mNotify.Erro("Erro", "Erro ao cadastrar timesheet!!", this);
            }
        }
        protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlDepartamento.SelectedValue != "0")
                {
                    clsProjetoBLO projetoBLO = new clsProjetoBLO();
                    projetoBLO.IdStatus = (int)clsStatusBLO.Projeto.Andamento;
                    projetoBLO.IdDepartamento = double.Parse(ddlDepartamento.SelectedValue);
                    CarregarProjeto(projetoBLO);
                }
            }
            catch (Exception)
            {

                modal.Notify.mNotify.Erro("Tente mais tarde.", "Cargo não carregado!!!,", this);
            }
        }
    }
}