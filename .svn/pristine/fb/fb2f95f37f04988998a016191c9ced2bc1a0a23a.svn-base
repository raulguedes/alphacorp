using AlphaCorp.BLL;
using AlphaCorp.BLO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlphaCorp
{
    public partial class Departamento : System.Web.UI.Page
    {
        public static bool EditDepartamento = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                    Find();
                if (EditDepartamento == true)
                {
                    EditDepartamento = false;
                    Page.Response.Redirect(Page.Request.Url.ToString(), true);
                }
            }
            catch (Exception)
            {
                modal.Notify.mNotify.Erro("Erro", "Falha no carregamento!!", this);
            }
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
                clsDepartamentoBLO objBLO = new clsDepartamentoBLO();
                Padrao(objBLO);
                clsDepartamentoBLL objBLL = new clsDepartamentoBLL();
                List<clsDepartamentoBLO> _listBLO = new List<clsDepartamentoBLO>();
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
        private void Find(clsDepartamentoBLO objBLO)
        {
            try
            {
                Padrao(objBLO);
                //Instancia Departamento
                List<clsDepartamentoBLO> _listBLO = new List<clsDepartamentoBLO>();
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
        public void Padrao(clsDepartamentoBLO objBLO)
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
        /// Carrega a gridView e a Session["ListaDepartamento"]
        /// </summary>
        /// <param name="objBLO"></param>
        /// <param name="_listBLO"></param>
        private void CarregarGrid(clsDepartamentoBLO objBLO, List<clsDepartamentoBLO> _listBLO)
        {

            Padrao(objBLO);
            clsDepartamentoBLL objBLL = new clsDepartamentoBLL();
            //Instancia lista de Departamento          

            //A Session rebece a nova busca.
            Session["ListaDepartamento"] = _listBLO = objBLL.Find(objBLO);
            //Carrega GridView
            gvDepartamento.DataSource = _listBLO;
            gvDepartamento.DataBind();

        }
        /// <summary>
        /// Tras todos os dados sem filtro
        /// </summary>
        private void CarregarGrid()
        {
            clsDepartamentoBLO objBLO = new clsDepartamentoBLO();
            List<clsDepartamentoBLO> _listBLO = new List<clsDepartamentoBLO>();
            Padrao(objBLO);
            clsDepartamentoBLL objBLL = new clsDepartamentoBLL();
            //Instancia lista de Departamento          

            //A Session rebece a nova busca.
            Session["ListaDepartamento"] = _listBLO = objBLL.Find(objBLO);
            //Carrega GridView
            gvDepartamento.DataSource = _listBLO;
            gvDepartamento.DataBind();

        }
        private void Criar()
        {
            try
            {
                if (txtCadastar.Value != null)
                {
                    var Verificar = (from D in (List<clsDepartamentoBLO>)Session["ListaDepartamento"] where D.Nome.ToUpper() == txtCadastar.Value.ToUpper() select D).SingleOrDefault();
                    if (Verificar == null)
                    {
                        clsDepartamentoBLO objBLO = new clsDepartamentoBLO();
                        Padrao(objBLO);
                        objBLO.Nome = txtCadastar.Value.ToUpper();
                        clsDepartamentoBLL objBLL = new clsDepartamentoBLL();
                        objBLL.Insert(objBLO);
                        txtCadastar.Value = string.Empty;
                        modal.Notify.mNotify.Sucesso("Sucesso", "Departamento cadastrado", this);

                        objBLO = new clsDepartamentoBLO();
                        //Passa o padrão para pesquisa
                        Padrao(objBLO);
                        try
                        {
                            List<clsDepartamentoBLO> listBLO = new List<clsDepartamentoBLO>();
                            CarregarGrid(objBLO, listBLO);
                        }
                        catch (Exception)
                        {
                            modal.Notify.mNotify.Erro("ERRO", "Erro ao carregar os registros", this);
                        }
                    }
                    else
                        modal.Notify.mNotify.Erro("Erro", "Departamento ja cadastrado", this);
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
        public static string Editar(string mNome, string mId)
        {
            string msg = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(mNome))
                {
                    var ListaDepartamento = (from Departamento in (List<clsDepartamentoBLO>)HttpContext.Current.Session["ListaDepartamento"] where Departamento.Nome.ToUpper(new CultureInfo("pt-BR")) == mNome.ToUpper() select Departamento).SingleOrDefault();

                    if (ListaDepartamento == null)
                    {
                        clsDepartamentoBLO objBLO = new clsDepartamentoBLO();
                        objBLO.Id = int.Parse(mId.ToString().ToUpper());
                        objBLO.Nome = mNome.ToString().ToUpper();
                        new Departamento().Padrao(objBLO);

                        clsDepartamentoBLL objBLL = new clsDepartamentoBLL();
                        List<clsDepartamentoBLO> _listBLO = new List<clsDepartamentoBLO>();
                        objBLL.Update(objBLO);

                    }else
                    {
                        msg = "Já existente";

                    }
                    EditDepartamento = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return "";
        }
        protected void gvDepartamento_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            if (e.CommandName == "Editar")
            {
                try
                {
                    //Pega o id da linha ao clicar no botão
                    int IdLinhaSelecionada = int.Parse(e.CommandArgument.ToString());
                    int Id = 0;
                    string Departamento = string.Empty;
                    foreach (GridViewRow row in gvDepartamento.Rows)
                    {

                        Label idBusca = (Label)row.FindControl("lblId");
                        //Verifica se o Id da linha selecionada do id da busca.
                        if (idBusca.Text == IdLinhaSelecionada.ToString())
                        {
                            Label _recebeId = (Label)row.FindControl("lblId");
                            Label _recebeDepartamento = (Label)row.FindControl("lblDepartamento");
                            Id = int.Parse(_recebeId.Text);
                            Departamento = _recebeDepartamento.Text;
                            break;
                        }
                    }
                    modal.Departamento.mDepartamento.Editar(Id.ToString(), Departamento, this);
                }
                catch (Exception)
                {
                    modal.Notify.mNotify.Erro("Erro","Erro no editar",this);                    
                }
            }
            else if (e.CommandName == "Excluir")
            {
                try
                {
                    //Pega o id da linha ao clicar no botão
                    int IdLinhaSelecionada = int.Parse(e.CommandArgument.ToString());
                    string Departamento = string.Empty;
                    foreach (GridViewRow row in gvDepartamento.Rows)
                    {

                        Label idBusca = (Label)row.FindControl("lblId");
                        //Verifica se o Id da linha selecionada do id da busca.
                        if (idBusca.Text == IdLinhaSelecionada.ToString())
                        {
                            Label _recebeId = (Label)row.FindControl("lblId");
                            clsDepartamentoBLO objBLO = new clsDepartamentoBLO();
                            Padrao(objBLO);
                            objBLO.Id = int.Parse(_recebeId.Text);
                            clsDepartamentoBLL objBLL = new clsDepartamentoBLL();
                            objBLL.Delete(objBLO);
                            CarregarGrid();
                            modal.Notify.mNotify.Sucesso("Sucesso", "Departamento excluído", this);
                            break;
                        }
                    }
                }
                catch (Exception)
                {
                    modal.Notify.mNotify.Erro("Erro","Processo não concluído",this);
                }

            }
            else if (e.CommandName == "Buscar")
            {
                try
                {
                    TextBox lblBusca = (TextBox)gvDepartamento.HeaderRow.FindControl("lblBusca");
                    //string headerRowText = gvDepartamento.HeaderRow.Cells[1].Text;
                    if (!string.IsNullOrEmpty(lblBusca.Text))
                    {
                        clsDepartamentoBLO objBLO = new clsDepartamentoBLO();
                        Padrao(objBLO);
                        objBLO.Nome = lblBusca.Text;
                        clsDepartamentoBLL objBLL = new clsDepartamentoBLL();
                        List<clsDepartamentoBLO> _listBLO = new List<clsDepartamentoBLO>();
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
                    modal.Notify.mNotify.Erro("Erro","Erro na busca",this);
                }
            }
        }
        protected void gvDepartamento_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDepartamento.UseAccessibleHeader = true;
            gvDepartamento.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvDepartamento.PageIndex = e.NewPageIndex;
            CarregarGrid();
        }

        //Type t = typeof(AlphaCorp.Departamento);

        //t.InvokeMember("teste", BindingFlags.InvokeMethod | BindingFlags.Public |
        //            BindingFlags.Static,
        //            null,
        //            null,
        //            new object[] { });

    }
}