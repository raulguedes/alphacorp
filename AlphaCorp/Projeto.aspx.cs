using AlphaCorp.BLL;
using AlphaCorp.BLO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlphaCorp
{
    public partial class Projeto : System.Web.UI.Page
    {
        public static bool EditProjeto = false;
        public static bool EditarErroProjeto = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarGrid();
                CarregarDepartamento();
                CarregarCliente();
            }
            if (EditProjeto == true)
            {
                EditProjeto = false;
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
            if (EditarErroProjeto == true)
            {
                try
                {
                    EditarErroProjeto = false;
                    modal.Notify.mNotify.Erro("Erro", "Projeto ja existente", this);
                }
                catch (Exception)
                {

                    modal.Notify.mNotify.Erro("Erro", "Projeto ja existente", this);
                }
            }
        }
        public void CarregarDepartamento()
        {

            clsDepartamentoBLO objBLO = new clsDepartamentoBLO();
            new Departamento().Padrao(objBLO);
            clsDepartamentoBLL objBLL = new clsDepartamentoBLL();
            ddlDepartamento.ClearSelection();
            //Carrega ddl.

            ddlDepartamento.DataSource = objBLL.Find(objBLO);
            ddlDepartamento.DataTextField = "Nome";//nome do departamento
            ddlDepartamento.DataValueField = "Id";//o valor do seu Id
            ddlDepartamento.DataBind();// carrega os dados na dllDepartamento

        }
        public void CarregarCliente()
        {

            clsClienteBLO objBLO = new clsClienteBLO();
            new Cliente().Padrao(objBLO);
            clsClienteBLL objBLL = new clsClienteBLL();
            ddlCliente.ClearSelection();
            //Carrega ddl.

            ddlCliente.DataSource = objBLL.Find(objBLO);
            ddlCliente.DataTextField = "Nome";//nome do Cliente
            ddlCliente.DataValueField = "Id";//o valor do seu Id
            ddlCliente.DataBind();// carrega os dados na dllCliente

        }

        /// <summary>
        /// Trás todos os Departamentos de tal usuario
        /// </summary>
        private void Find()
        {
            try
            {
                clsProjetoBLO objBLO = new clsProjetoBLO();
                Padrao(objBLO);
                clsProjetoBLL objBLL = new clsProjetoBLL();
                List<clsProjetoBLO> _listBLO = new List<clsProjetoBLO>();
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
        private void Find(clsProjetoBLO objBLO)
        {
            try
            {
                Padrao(objBLO);
                //Instancia Departamento
                List<clsProjetoBLO> _listBLO = new List<clsProjetoBLO>();
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
        public void Padrao(clsProjetoBLO objBLO)
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
        /// Carrega a gridView e a Session["ListaProjeto"]
        /// </summary>
        /// <param name="objBLO"></param>
        /// <param name="_listBLO"></param>
        private void CarregarGrid(clsProjetoBLO objBLO, List<clsProjetoBLO> _listBLO)
        {

            Padrao(objBLO);
            clsProjetoBLL objBLL = new clsProjetoBLL();
            //Instancia lista de Departamento          

            //A Session rebece a nova busca.
            Session["ListaProjeto"] = _listBLO = objBLL.Find(objBLO);
            //Carrega GridView
            gvProjeto.DataSource = _listBLO;
            gvProjeto.DataBind();

        }
        /// <summary>
        /// Tras todos os dados sem filtro
        /// </summary>
        private void CarregarGrid()
        {
            clsProjetoBLO objBLO = new clsProjetoBLO();
            List<clsProjetoBLO> _listBLO = new List<clsProjetoBLO>();
            Padrao(objBLO);
            clsProjetoBLL objBLL = new clsProjetoBLL();
            //Instancia lista de Departamento          

            //A Session rebece a nova busca.
            Session["ListaProjeto"] = _listBLO = objBLL.Find(objBLO);
            //Carrega GridView
            gvProjeto.DataSource = _listBLO;
            gvProjeto.DataBind();

        }
        [WebMethod]
        public static string Criar(string mNome, string mDepartamento, string mCliente)
        {
            string msg = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(mNome) && !string.IsNullOrEmpty(mDepartamento))
                {
                    var Verificar = (from D in (List<clsProjetoBLO>)HttpContext.Current.Session["ListaProjeto"] where D.Nome.ToUpper() == mNome.ToUpper() && D.IdDepartamento == double.Parse(mDepartamento) select D).SingleOrDefault();
                    if (Verificar == null)
                    {
                        clsProjetoBLO objBLO = new clsProjetoBLO();
                        new Projeto().Padrao(objBLO);
                        objBLO.Nome = mNome.ToUpper();
                        objBLO.IdDepartamento = double.Parse(mDepartamento);
                        if (!string.IsNullOrEmpty(mCliente))
                            objBLO.IdCliente = double.Parse(mCliente);
                        objBLO.IdResponsavel = (HttpContext.Current.Session["User"] as clsLoginBLO).Id;
                        objBLO.IdStatus = (int)clsStatusBLO.Projeto.Andamento;
                        clsProjetoBLL objBLL = new clsProjetoBLL();
                        objBLL.Insert(objBLO);
                        EditProjeto = true;
                    }
                    else
                    {
                        EditarErroProjeto = true;
                        msg = "Projeto já cadastrado";
                    }
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }
        protected void btnCriar_ServerClick(object sender, EventArgs e)
        {
            try
            {
                modal.Projeto.mProjeto.Criar(this);
            }
            catch (Exception)
            {
                modal.Notify.mNotify.Erro("Erro", "Não possível cadastrar", this);
            }
        }
        [WebMethod]
        public static string Editar(string mNome, string mId, string mDepartamento, string mCliente, string mStatus)
        {
            string msg = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(mNome) && !string.IsNullOrEmpty(mId) && !string.IsNullOrEmpty(mDepartamento))
                {
                    if ((HttpContext.Current.Session["EditarProjeto"] as clsProjetoBLO).Nome != mNome ||
                        (HttpContext.Current.Session["EditarProjeto"] as clsProjetoBLO).IdDepartamento != double.Parse(mDepartamento) ||
                        (HttpContext.Current.Session["EditarProjeto"] as clsProjetoBLO).IdCliente != double.Parse(mCliente) ||
                        (HttpContext.Current.Session["EditarProjeto"] as clsProjetoBLO).IdStatus != double.Parse(mStatus))
                    {

                        if ((HttpContext.Current.Session["EditarProjeto"] as clsProjetoBLO).Nome != mNome)
                        {
                            //Verifica se tem algo cadastro com o mesmo nome, departamento e cliente.
                            var ListaProjeto = (from Projeto in (List<clsProjetoBLO>)HttpContext.Current.Session["ListaProjeto"]
                                                where Projeto.Nome.ToUpper() == mNome.ToUpper() && Projeto.IdDepartamento == double.Parse(mDepartamento) && Projeto.IdCliente == double.Parse(mCliente)
                                                select Projeto).SingleOrDefault();
                            //Se não existir cadastra.
                            if (ListaProjeto == null)
                            {
                                clsProjetoBLO objBLO = new clsProjetoBLO();
                                new Projeto().Padrao(objBLO);
                                objBLO.Id = int.Parse(mId);
                                objBLO.Nome = mNome.ToString().ToUpper();
                                objBLO.IdDepartamento = int.Parse(mDepartamento);
                                if (mCliente != "0")
                                    objBLO.IdCliente = int.Parse(mCliente);
                                objBLO.IdResponsavel = (HttpContext.Current.Session["User"] as clsLoginBLO).Id;
                                objBLO.IdStatus = int.Parse(mStatus);
                                clsProjetoBLL objBLL = new clsProjetoBLL();
                                List<clsProjetoBLO> _listBLO = new List<clsProjetoBLO>();
                                objBLL.Update(objBLO);
                                EditProjeto = true;

                            }
                            else
                            {
                                EditarErroProjeto = true;
                                msg = "Projeto já cadastrado";
                            }
                        }
                        else
                        {
                            clsProjetoBLO objBLO = new clsProjetoBLO();
                            new Projeto().Padrao(objBLO);
                            objBLO.Id = int.Parse(mId.ToString());
                            objBLO.IdDepartamento = int.Parse(mDepartamento);
                            if (mCliente != "0")
                                objBLO.IdCliente = int.Parse(mCliente);
                            objBLO.IdResponsavel = (HttpContext.Current.Session["User"] as clsLoginBLO).Id;
                            objBLO.IdStatus = int.Parse(mStatus);
                            clsProjetoBLL objBLL = new clsProjetoBLL();
                            List<clsProjetoBLO> _listBLO = new List<clsProjetoBLO>();
                            objBLL.Update(objBLO);
                            EditProjeto = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return msg;
        }
        protected void gvProjeto_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                try
                {
                    //Pega o id da linha ao clicar no botão
                    int IdLinhaSelecionada = int.Parse(e.CommandArgument.ToString());
                    clsProjetoBLO blo = null;
                    foreach (GridViewRow row in gvProjeto.Rows)
                    {

                        Label idBusca = (Label)row.FindControl("lblId");
                        //Verifica se o Id da linha selecionada do id da busca.
                        if (idBusca.Text == IdLinhaSelecionada.ToString())
                        {
                            #region Pegar valor da grid
                            //Id do projeto
                            Label _Id = (Label)row.FindControl("lblId");
                            //Id do departamento
                            Label _IdDepartamento = (Label)row.FindControl("lblIdDepartamento");
                            //Nome do projeto
                            Label _nomeProjeto = (Label)row.FindControl("lblNome");
                            //Id do cliente
                            Label _IdCliente = (Label)row.FindControl("lblIdCliente");
                            //Id do status    
                            Label _IdStatus = (Label)row.FindControl("lblIdStatus");
                            #endregion
                            #region Passar os valor para os objetos
                            blo = new clsProjetoBLO();
                            //Passando Id
                            blo.Id = double.Parse(_Id.Text);
                            //Passando nome
                            blo.Nome = _nomeProjeto.Text;
                            //Passando Departamento
                            blo.IdDepartamento = double.Parse(_IdDepartamento.Text);
                            //IdCliente
                            if (_IdCliente.Text != "0")
                                blo.IdCliente = double.Parse(_IdCliente.Text);
                            //IdStatus
                            blo.IdStatus = int.Parse(_IdStatus.Text);
                            Session["EditarProjeto"] = blo;
                            #endregion

                            break;
                        }
                    }
                    if (blo.IdStatus != (int)clsStatusBLO.Projeto.Cancelado)
                        modal.Projeto.mProjeto.Editar(blo.Id, blo.Nome, blo.IdDepartamento, blo.IdCliente, blo.IdStatus, this);
                    else
                        modal.Notify.mNotify.Erro("Erro", "Esse projeto foi cancelado", this);
                }
                catch (Exception)
                {
                    modal.Notify.mNotify.Erro("Erro", "Não foi Possível alterar", this);
                }
            }
            else if (e.CommandName == "Excluir")
            {            //Pega o id da linha ao clicar no botão
                try
                {
                    int IdLinhaSelecionada = int.Parse(e.CommandArgument.ToString());
                    string Departamento = string.Empty;
                    foreach (GridViewRow row in gvProjeto.Rows)
                    {
                        Label idBusca = (Label)row.FindControl("lblId");
                        //Verifica se o Id da linha selecionada do id da busca.
                        if (idBusca.Text == IdLinhaSelecionada.ToString())
                        {
                            Label _recebeId = (Label)row.FindControl("lblId");
                            clsProjetoBLO objBLO = new clsProjetoBLO();
                            Padrao(objBLO);
                            objBLO.Id = int.Parse(_recebeId.Text);
                            clsProjetoBLL objBLL = new clsProjetoBLL();
                            objBLL.Delete(objBLO);
                            CarregarGrid();
                            break;
                        }
                    }
                    modal.Notify.mNotify.Sucesso("Sucesso", "Projeto excluído", this);
                }
                catch (Exception)
                {
                    modal.Notify.mNotify.Erro("Erro", "Esse projeto não pode ser excluído", this);
                }
            }
        }
        protected void btnConsultar_ServerClick(object sender, EventArgs e)
        {
            try
            {
                clsProjetoBLO obj = new clsProjetoBLO();
                if (ddlDepartamento.SelectedValue != "0")
                    obj.IdDepartamento = int.Parse(ddlDepartamento.SelectedValue);
                if (ddlCliente.SelectedValue != "0")
                    obj.IdCliente = int.Parse(ddlCliente.SelectedValue);
                if (ddlStatus.SelectedValue != "0")
                    obj.IdStatus = int.Parse(ddlStatus.SelectedValue);
                if (!string.IsNullOrEmpty(txtNome.Value))
                    obj.Nome = txtNome.Value;
                Find(obj);
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void gvProjeto_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProjeto.UseAccessibleHeader = true;
            gvProjeto.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvProjeto.PageIndex = e.NewPageIndex;
            CarregarGrid();
        }
    }
}