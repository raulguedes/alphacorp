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
    public partial class Cliente : System.Web.UI.Page
    {
        public static bool EditCliente = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                    Find();
                if (EditCliente == true)
                {
                    EditCliente = false;
                    Page.Response.Redirect(Page.Request.Url.ToString(), true);
                }
            }
            catch (Exception)
            {
                modal.Notify.mNotify.Erro("Erro", "Falha no carregamento!!", this);
            }
        }

        protected void btnFindCliente_ServerClick(object sender, EventArgs e)
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
        /// Trás todos os Clientes de tal usuario
        /// </summary>
        private void Find()
        {
            try
            {
                clsClienteBLO objBLO = new clsClienteBLO();
                Padrao(objBLO);
                clsClienteBLL objBLL = new clsClienteBLL();
                List<clsClienteBLO> _listBLO = new List<clsClienteBLO>();
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
        private void Find(clsClienteBLO objBLO)
        {
            try
            {
                Padrao(objBLO);
                //Instancia Cliente
                List<clsClienteBLO> _listBLO = new List<clsClienteBLO>();
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
        public void Padrao(clsClienteBLO objBLO)
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
        /// Carrega a gridView e a Session["ListaCliente"]
        /// </summary>
        /// <param name="objBLO"></param>
        /// <param name="_listBLO"></param>
        private void CarregarGrid(clsClienteBLO objBLO, List<clsClienteBLO> _listBLO)
        {

            Padrao(objBLO);
            clsClienteBLL objBLL = new clsClienteBLL();
            //Instancia lista de Cliente          

            //A Session rebece a nova busca.
            Session["ListaCliente"] = _listBLO = objBLL.Find(objBLO);
            //Carrega GridView
            gvCliente.DataSource = _listBLO;
            gvCliente.DataBind();

        }
        /// <summary>
        /// Tras todos os dados sem filtro
        /// </summary>
        private void CarregarGrid()
        {
            clsClienteBLO objBLO = new clsClienteBLO();
            List<clsClienteBLO> _listBLO = new List<clsClienteBLO>();
            Padrao(objBLO);

            clsClienteBLL objBLL = new clsClienteBLL();
            //Instancia lista de Cliente          

            //A Session rebece a nova busca.
            Session["ListaCliente"] = _listBLO = objBLL.Find(objBLO);
            //Carrega GridView
            gvCliente.DataSource = _listBLO;
            gvCliente.DataBind();

        }
        private void Criar()
        {
            try
            {
                if (txtNome.Value != null)
                {
                    var Verificar = (from D in (List<clsClienteBLO>)Session["ListaCliente"] where D.Nome.ToUpper() == txtNome.Value.ToUpper() select D).SingleOrDefault();
                    if (Verificar == null)
                    {
                        clsClienteBLO objBLO = new clsClienteBLO();
                        Padrao(objBLO);
                        objBLO.Nome = txtNome.Value.ToUpper();
                        objBLO.Email = txtEmail.Value;
                        objBLO.Telefone = double.Parse(txtTelefone.Text);
                        clsClienteBLL objBLL = new clsClienteBLL();
                        objBLL.Insert(objBLO);
                        txtNome.Value = string.Empty;
                        txtEmail.Value = string.Empty;
                        txtTelefone.Text = string.Empty;
                        modal.Notify.mNotify.Sucesso("Sucesso", "Cliente cadastrado", this);

                        objBLO = new clsClienteBLO();
                        //Passa o padrão para pesquisa
                        Padrao(objBLO);
                        try
                        {
                            List<clsClienteBLO> listBLO = new List<clsClienteBLO>();
                            CarregarGrid(objBLO, listBLO);
                        }
                        catch (Exception)
                        {
                            modal.Notify.mNotify.Erro("ERRO", "Erro ao carregar os registros", this);
                        }
                    }
                    else
                        modal.Notify.mNotify.Erro("Erro", "Cliente ja cadastrado", this);
                }
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
        public static string Editar(string mNome, string mId, string mEmail, string mTelefone)
        {
            try
            {
                if (!string.IsNullOrEmpty(mNome))
                {
                    if ((HttpContext.Current.Session["EditarCliente"] as clsClienteBLO).Nome != mNome)
                    {
                        var ListaCliente = (from Cliente in (List<clsClienteBLO>)HttpContext.Current.Session["ListaCliente"] where Cliente.Nome.ToUpper() == mNome.ToUpper() select Cliente).SingleOrDefault();

                        if (ListaCliente == null)
                        {
                            clsClienteBLO objBLO = new clsClienteBLO();
                            objBLO.Id = int.Parse(mId);
                            objBLO.Nome = mNome.ToUpper();
                            objBLO.Email = mEmail;
                            objBLO.Telefone = double.Parse(mTelefone.ToString().Replace("(", "").Replace(")", "").Replace("-", ""));
                            new Cliente().Padrao(objBLO);

                            clsClienteBLL objBLL = new clsClienteBLL();
                            List<clsClienteBLO> _listBLO = new List<clsClienteBLO>();
                            objBLL.Update(objBLO);
                        }
                    }
                    else
                    {
                        clsClienteBLO objBLO = new clsClienteBLO();
                        objBLO.Id = int.Parse(mId);
                        objBLO.Email = mEmail;
                        objBLO.Telefone = double.Parse(mTelefone.ToString().Replace("(", "").Replace(")", "").Replace("-", ""));
                        new Cliente().Padrao(objBLO);

                        clsClienteBLL objBLL = new clsClienteBLL();
                        List<clsClienteBLO> _listBLO = new List<clsClienteBLO>();
                        objBLL.Update(objBLO);
                    }
                    EditCliente = true;


                }
                else
                    throw new Exception();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return "";
        }
        protected void gvCliente_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                try
                {
                    //Pega o id da linha ao clicar no botão
                    int IdLinhaSelecionada = int.Parse(e.CommandArgument.ToString());
                    double _Id = 0;
                    string _Nome = string.Empty;
                    string _Email = string.Empty;
                    string _Telefone = string.Empty;
                    foreach (GridViewRow row in gvCliente.Rows)
                    {

                        Label idBusca = (Label)row.FindControl("lblId");
                        //Verifica se o Id da linha selecionada do id da busca.
                        if (idBusca.Text == IdLinhaSelecionada.ToString())
                        {
                            Label _recebeId = (Label)row.FindControl("lblId");
                            Label _nome = (Label)row.FindControl("lblNome");
                            Label _email = (Label)row.FindControl("lblEmail");
                            Label _telefone = (Label)row.FindControl("lblTelefone");
                            _Id = double.Parse(_recebeId.Text);
                            _Nome = _nome.Text;
                            _Email = _email.Text;
                            _Telefone = _telefone.Text;
                            clsClienteBLO blo = new clsClienteBLO();
                            blo.Nome = _Nome;
                            blo.Email = _Email;
                            Session["EditarCliente"] = blo;
                            break;
                        }
                    }
                    modal.Cliente.mCliente.Editar(_Id, _Nome, _Email, _Telefone, this);
                }
                catch (Exception)
                {
                    modal.Notify.mNotify.Erro("Erro", "Não foi possível excluir", this);
                }
            }
            else if (e.CommandName == "Excluir")
            {            //Pega o id da linha ao clicar no botão
                try
                {
                    int IdLinhaSelecionada = int.Parse(e.CommandArgument.ToString());
                    string Cliente = string.Empty;
                    foreach (GridViewRow row in gvCliente.Rows)
                    {

                        Label idBusca = (Label)row.FindControl("lblId");
                        //Verifica se o Id da linha selecionada do id da busca.
                        if (idBusca.Text == IdLinhaSelecionada.ToString())
                        {
                            Label _recebeId = (Label)row.FindControl("lblId");
                            clsClienteBLO objBLO = new clsClienteBLO();
                            Padrao(objBLO);
                            objBLO.Id = int.Parse(_recebeId.Text);
                            clsClienteBLL objBLL = new clsClienteBLL();
                            objBLL.Delete(objBLO);
                            CarregarGrid();
                            modal.Notify.mNotify.Sucesso("Sucesso", "Cliente excluído", this);
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
                    TextBox lblBusca = (TextBox)gvCliente.HeaderRow.FindControl("lblBusca");
                    //string headerRowText = gvCliente.HeaderRow.Cells[1].Text;
                    if (!string.IsNullOrEmpty(lblBusca.Text))
                    {
                        clsClienteBLO objBLO = new clsClienteBLO();
                        Padrao(objBLO);
                        objBLO.Nome = lblBusca.Text;
                        clsClienteBLL objBLL = new clsClienteBLL();
                        List<clsClienteBLO> _listBLO = new List<clsClienteBLO>();
                        _listBLO = objBLL.Find(objBLO);
                        if (_listBLO.Count != 0)
                        {
                            CarregarGrid(objBLO, _listBLO);
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
                    }
                }
                catch (Exception)
                {
                    modal.Notify.mNotify.Erro("Erro", "Não foi possível editar", this);
                }
            }
        }
        protected void gvCliente_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCliente.UseAccessibleHeader = true;
            gvCliente.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvCliente.PageIndex = e.NewPageIndex;
            CarregarGrid();
        }
    }
}