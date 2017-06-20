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
    public partial class Cargo : System.Web.UI.Page
    {
        public static bool EditCargo = false;
        public static bool EditCargoExistente = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarGrid();
                CarregarDepartamento();
            }
            if (EditCargo == true)
            {
                EditCargo = false;
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
            if (EditCargoExistente == true)
            {
                EditCargoExistente = false;
                modal.Notify.mNotify.Erro("Erro", "Cargo já existente", this);
            }

        }

        protected void gvCargo_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                DropDownList ddlDepartamento = (DropDownList)gvCargo.HeaderRow.FindControl("ddlDepartamento");
                if (ddlDepartamento != null)
                {
                    clsDepartamentoBLO objBLO = new clsDepartamentoBLO();
                    new Departamento().Padrao(objBLO);
                    clsDepartamentoBLL objBLL = new clsDepartamentoBLL();
                    ddlDepartamento.Items.Clear();
                    //Carrega ddl.
                    ListItem item = new ListItem();
                    item.Selected = true;
                    item.Value = "0";
                    item.Text = "Selecione...";
                    ddlDepartamento.Items.Add(item);
                    ddlDepartamento.DataSource = objBLL.Find(objBLO);
                    ddlDepartamento.DataTextField = "Nome";//nome do departamento
                    ddlDepartamento.DataValueField = "Id";//o valor do seu Id                    
                    ddlDepartamento.DataBind();// carrega os dados na dllDepartamento                    
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

        protected void btnFindDepartamento_ServerClick(object sender, EventArgs e)
        {
            try
            {
                Find();
            }
            catch (Exception)
            {
                modal.Notify.mNotify.Erro("Erro", "Falha no carregamento!!", this);
            }
        }
        /// <summary>
        /// Trás todos os Departamentos de tal usuario
        /// </summary>
        private void Find()
        {
            try
            {
                clsCargoBLO objBLO = new clsCargoBLO();
                Padrao(objBLO);
                clsCargoBLL objBLL = new clsCargoBLL();
                List<clsCargoBLO> _listBLO = new List<clsCargoBLO>();
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
        private void Find(clsCargoBLO objBLO)
        {
            try
            {
                Padrao(objBLO);
                //Instancia Departamento
                List<clsCargoBLO> _listBLO = new List<clsCargoBLO>();
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
        public void Padrao(clsCargoBLO objBLO)
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
        /// Carrega a gridView e a Session["ListaCargo"]
        /// </summary>
        /// <param name="objBLO"></param>
        /// <param name="_listBLO"></param>
        private void CarregarGrid(clsCargoBLO objBLO, List<clsCargoBLO> _listBLO)
        {

            Padrao(objBLO);
            clsCargoBLL objBLL = new clsCargoBLL();
            //Instancia lista de Departamento          

            //A Session rebece a nova busca.
            Session["ListaCargo"] = _listBLO = objBLL.Find(objBLO);
            //Carrega GridView
            gvCargo.DataSource = _listBLO;
            gvCargo.DataBind();

        }
        /// <summary>
        /// Tras todos os dados sem filtro
        /// </summary>
        private void CarregarGrid()
        {
            clsCargoBLO objBLO = new clsCargoBLO();
            List<clsCargoBLO> _listBLO = new List<clsCargoBLO>();
            Padrao(objBLO);
            clsCargoBLL objBLL = new clsCargoBLL();
            //Instancia lista de Departamento          

            //A Session rebece a nova busca.
            Session["ListaCargo"] = _listBLO = objBLL.Find(objBLO);
            //Carrega GridView
            gvCargo.DataSource = _listBLO;
            gvCargo.DataBind();

        }
        private void Criar()
        {
            try
            {
                if (!string.IsNullOrEmpty(txtCadastar.Value) && ddlDepartamento.SelectedValue != "0")
                {
                    var Verificar = (from D in (List<clsCargoBLO>)Session["ListaCargo"] where D.Nome.ToUpper() == txtCadastar.Value.ToUpper() && D.IdDepartamento == double.Parse(ddlDepartamento.SelectedValue) select D).SingleOrDefault();
                    if (Verificar == null)
                    {
                        clsCargoBLO objBLO = new clsCargoBLO();
                        Padrao(objBLO);
                        objBLO.Nome = txtCadastar.Value.ToUpper();
                        objBLO.IdDepartamento = int.Parse(ddlDepartamento.SelectedValue);
                        clsCargoBLL objBLL = new clsCargoBLL();
                        objBLL.Insert(objBLO);
                        txtCadastar.Value = string.Empty;
                        modal.Notify.mNotify.Sucesso("Sucesso", "Cargo cadastrado", this);

                        objBLO = new clsCargoBLO();
                        //Passa o padrão para pesquisa
                        Padrao(objBLO);
                        try
                        {
                            List<clsCargoBLO> listBLO = new List<clsCargoBLO>();
                            CarregarGrid(objBLO, listBLO);
                        }
                        catch (Exception)
                        {
                            modal.Notify.mNotify.Erro("ERRO", "Erro ao carregar os registros", this);
                        }
                    }
                    else
                        modal.Notify.mNotify.Erro("Erro", "Cargo já cadastrado", this);
                }else
                    modal.Notify.mNotify.Erro("Erro", "Campo(s) vazio", this);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        protected void btnCriar_ServerClick(object sender, EventArgs e)
        {
            try
            {
                Criar();
            }
            catch (Exception)
            {
                modal.Notify.mNotify.Erro("Erro", "Não possível cadastrar", this);
            }
        }
        [WebMethod]
        public static string Editar(string mNome, string mId, string mDepartamento)
        {
            string msg = "";
            try
            {
                if (!string.IsNullOrEmpty(mNome) && !string.IsNullOrEmpty(mId) && !string.IsNullOrEmpty(mDepartamento))
                {
                    if ((HttpContext.Current.Session["EditarCargo"] as clsCargoBLO).Nome != mNome || (HttpContext.Current.Session["EditarCargo"] as clsCargoBLO).IdDepartamento != double.Parse(mDepartamento))
                    {
                        if ((HttpContext.Current.Session["EditarCargo"] as clsCargoBLO).Nome != mNome)
                        {
                            var ListaCargo = (from Cargo in (List<clsCargoBLO>)HttpContext.Current.Session["ListaCargo"] where Cargo.Nome.ToUpper() == mNome.ToUpper() && Cargo.IdDepartamento == double.Parse(mDepartamento) select Cargo).SingleOrDefault();

                            if (ListaCargo == null)
                            {
                                clsCargoBLO objBLO = new clsCargoBLO();
                                new Cargo().Padrao(objBLO);
                                objBLO.Id = int.Parse(mId);
                                objBLO.Nome = mNome.ToString().ToUpper();
                                objBLO.IdDepartamento = int.Parse(mDepartamento);
                                clsCargoBLL objBLL = new clsCargoBLL();
                                List<clsCargoBLO> _listBLO = new List<clsCargoBLO>();
                                objBLL.Update(objBLO);


                            }
                            else
                            {
                                EditCargoExistente = true;
                                msg = "já existente";
                            }
                        }

                        else
                        {
                            clsCargoBLO objBLO = new clsCargoBLO();
                            new Cargo().Padrao(objBLO);
                            objBLO.Id = int.Parse(mId.ToString());
                            objBLO.IdDepartamento = int.Parse(mDepartamento);

                            clsCargoBLL objBLL = new clsCargoBLL();
                            List<clsCargoBLO> _listBLO = new List<clsCargoBLO>();
                            objBLL.Update(objBLO);
                        }
                    }
                    EditCargo = true;
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return msg;
        }
        protected void gvDepartamento_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                try
                {
                    //Pega o id da linha ao clicar no botão
                    int IdLinhaSelecionada = int.Parse(e.CommandArgument.ToString());
                    double Id = 0;
                    double IdDepartamento = 0;
                    string Cargo = string.Empty;
                    foreach (GridViewRow row in gvCargo.Rows)
                    {

                        Label idBusca = (Label)row.FindControl("lblId");
                        //Verifica se o Id da linha selecionada do id da busca.
                        if (idBusca.Text == IdLinhaSelecionada.ToString())
                        {
                            Label _Id = (Label)row.FindControl("lblId");
                            Label _IdDepartamento = (Label)row.FindControl("lblIdDepartamento");
                            Label _Cargo = (Label)row.FindControl("lblCargo");
                            Id = int.Parse(_Id.Text);
                            IdDepartamento = int.Parse(_IdDepartamento.Text);
                            Cargo = _Cargo.Text;
                            clsCargoBLO blo = new clsCargoBLO();
                            blo.Nome = _Cargo.Text;
                            blo.IdDepartamento = IdDepartamento;
                            Session["EditarCargo"] = blo;

                            break;
                        }
                    }
                    modal.Cargo.mCargo.Editar(Id, Cargo, IdDepartamento, this);
                }
                catch (Exception)
                {
                    modal.Notify.mNotify.Sucesso("Erro", "Não é possível editar", this);
                }

            }
            else if (e.CommandName == "Excluir")
            {            //Pega o id da linha ao clicar no botão
                try
                {
                    int IdLinhaSelecionada = int.Parse(e.CommandArgument.ToString());
                    string Departamento = string.Empty;
                    foreach (GridViewRow row in gvCargo.Rows)
                    {

                        Label idBusca = (Label)row.FindControl("lblId");
                        //Verifica se o Id da linha selecionada do id da busca.
                        if (idBusca.Text == IdLinhaSelecionada.ToString())
                        {
                            Label _recebeId = (Label)row.FindControl("lblId");
                            clsCargoBLO objBLO = new clsCargoBLO();
                            Padrao(objBLO);
                            objBLO.Id = int.Parse(_recebeId.Text);
                            clsCargoBLL objBLL = new clsCargoBLL();
                            objBLL.Delete(objBLO);
                            CarregarGrid();
                            modal.Notify.mNotify.Sucesso("Sucesso", "Departamento excluído", this);
                            break;
                        }
                    }
                }
                catch (Exception)
                {
                    modal.Notify.mNotify.Erro("Erro", "Não é possível excluir", this);
                }

            }
            else if (e.CommandName == "Buscar")
            {
                try
                {

                    TextBox lblBusca = (TextBox)gvCargo.HeaderRow.FindControl("lblBuscaCargo");
                    DropDownList ddl = (DropDownList)gvCargo.HeaderRow.FindControl("ddlDepartamento");
                    if (!string.IsNullOrEmpty(lblBusca.Text) || ddl.SelectedValue != "0")
                    {
                        clsCargoBLO objBLO = new clsCargoBLO();
                        Padrao(objBLO);
                        if (!string.IsNullOrEmpty(lblBusca.Text))
                            objBLO.Nome = lblBusca.Text;
                        if (ddl.SelectedValue != "0")
                            objBLO.IdDepartamento = double.Parse(ddl.SelectedValue);
                        clsCargoBLL objBLL = new clsCargoBLL();
                        List<clsCargoBLO> _listBLO = new List<clsCargoBLO>();
                        _listBLO = objBLL.Find(objBLO);
                        if (_listBLO.Count != 0)
                        {
                            CarregarGrid(objBLO, _listBLO);
                        }
                        else
                        {
                            modal.Notify.mNotify.Sucesso("Busca concluída", "Nada encontrado", this);
                            CarregarGrid();
                        }
                    }
                    else
                    {
                        CarregarGrid();
                    }
                }
                catch (Exception)
                {
                    modal.Notify.mNotify.Sucesso("Erro", "Erro ao filtrar", this);
                }
            }
        }
        protected void gvCargo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCargo.UseAccessibleHeader = true;
            gvCargo.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvCargo.PageIndex = e.NewPageIndex;
            CarregarGrid();
        }
    }
}