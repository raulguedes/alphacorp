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
    public partial class Timesheet_Aprovar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["User"] != null)
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["Rejeitar"]))
                    {
                        double _Id = double.Parse(Request.QueryString["Rejeitar"].ToString());
                        VerificarSession(_Id, false);
                    }
                    else if (!string.IsNullOrEmpty(Request.QueryString["Aprovar"]))
                    {
                        double _Id = double.Parse(Request.QueryString["Aprovar"].ToString());
                        VerificarSession(_Id, true);
                    }
                    if (!(Session["User"] as clsLoginBLO).Empresa)
                    {
                        if ((Session["User"] as clsLoginBLO).IdTipoUser != (int)clsStatusBLO.TipoUser.Administrador)
                            if ((Session["User"] as clsLoginBLO).IdTipoUser != (int)clsStatusBLO.TipoUser.Supervisor)
                                LiTimesheet_Aprovar.Visible = false;
                    }
                    CriarTudo();
                }
            }
        }
        protected clsWaitsheetBLO PreencherBLO(List<clsWaitsheetBLO> _listBLO, bool Aprovar)
        {
            clsWaitsheetBLO objBLO = new clsWaitsheetBLO();
            clsLoginBLO SessionUser = (Session["User"] as clsLoginBLO);
            foreach (clsWaitsheetBLO item in _listBLO)
            {
                PadraoEmpresa(objBLO);
                objBLO.Id = item.Id;
                objBLO.Data = item.Data;
                objBLO.Duracao = item.Duracao;
                objBLO.Descricao = item.Descricao;
                if (!string.IsNullOrEmpty(item.HoraExtra.ToString()))
                    objBLO.HoraExtra = item.HoraExtra;
                else
                    objBLO.HoraExtra = TimeSpan.Parse("00:00:00");
                if (Aprovar)
                    objBLO.IdStatus = (int)clsStatusBLO.Timesheet.Aprovado;
                else
                    objBLO.IdStatus = (int)clsStatusBLO.Timesheet.Rejeitado;
                objBLO.DescricaoExtra = item.DescricaoExtra;
                objBLO.DataEntrada = item.DataEntrada;
                objBLO.IdFuncionario = item.IdFuncionario;
                objBLO.IdSupervisor = SessionUser.Id;
                objBLO.IdDepartamento = item.IdDepartamento;
                objBLO.IdProjeto = item.IdProjeto;
            }

            return objBLO;
        }
        private void AprovarWait(double Id)
        {
            try
            {
                clsLoginBLO SessionUser = (Session["User"] as clsLoginBLO);
                List<clsWaitsheetBLO> _listBLO = new List<clsWaitsheetBLO>();
                _listBLO = Find(Id);
                if (_listBLO.Count == 1)
                {
                    clsWaitsheetBLO objBLO = new clsWaitsheetBLO();
                    objBLO = PreencherBLO(_listBLO, true);

                    clsWaitsheetBLL objBLL = new clsWaitsheetBLL();
                    objBLL.Transferir(objBLO);
                    modal.Notify.mNotify.Sucesso("Sucesso", "Timesheet aprovado", this);
                    CriarTudo();
                }
            }
            catch (Exception)
            {
                modal.Notify.mNotify.Erro("Erro", "Não foi possível deletar", this);
            }

        }
        private void RejeitarWait(double Id)
        {
            try
            {
                clsLoginBLO SessionUser = (Session["User"] as clsLoginBLO);
                List<clsWaitsheetBLO> _listBLO = new List<clsWaitsheetBLO>();
                _listBLO = Find(Id);
                if (_listBLO.Count == 1)
                {
                    clsWaitsheetBLO objBLO = new clsWaitsheetBLO();
                    objBLO = PreencherBLO(_listBLO, false);

                    clsWaitsheetBLL objBLL = new clsWaitsheetBLL();
                    objBLL.Transferir(objBLO);
                    modal.Notify.mNotify.Sucesso("Sucesso", "Timesheet rejeitado", this);
                    CriarTudo();
                }
            }
            catch (Exception)
            {
                modal.Notify.mNotify.Erro("Erro", "Não foi possível deletar", this);
            }

        }
        private void VerificarSession(double Id, bool Aprovar)
        {
            try
            {
                var ListaTime = (from Time in (List<clsWaitsheetBLO>)HttpContext.Current.Session["ListaAprovar"] where Time.Id == Id select Time).SingleOrDefault();
                if (ListaTime != null)
                {
                    if (Aprovar)
                    {
                        AprovarWait(Id);
                    }
                    else if (!Aprovar)
                    {
                        RejeitarWait(Id);
                    }
                }
                else
                    modal.Notify.mNotify.Erro("Erro", "Timesheet não encontrado", this);
            }
            catch (Exception ex)
            {
                modal.Notify.mNotify.Erro("Erro", "" + ex.Message, this);
            }
        }
        public void PadraoEmpresa(clsWaitsheetBLO objBLO)
        {
            clsLoginBLO SessionUser = (clsLoginBLO)Session["User"];
            if (SessionUser.Empresa)
                objBLO.IdEmpresa = SessionUser.Id;
            else
                objBLO.IdEmpresa = SessionUser.IdEmpresa;
        }
        [WebMethod]
        public static List<clsWaitsheetBLO> Find(string wData)
        {
            List<clsWaitsheetBLO> _listBLO = new List<clsWaitsheetBLO>();
            try
            {
                clsWaitsheetBLO objBLO = new clsWaitsheetBLO();
                new Timesheet_Aprovar().PadraoEmpresa(objBLO);
                clsLoginBLO SessionUser = (clsLoginBLO)HttpContext.Current.Session["User"];
                objBLO.IdSupervisor = SessionUser.Id;


                if (!string.IsNullOrEmpty(wData))
                    objBLO.Data = DateTime.Parse(wData);

                clsWaitsheetBLL objBLL = new clsWaitsheetBLL();
                _listBLO = objBLL.Find(objBLO);
                HttpContext.Current.Session["ListaAprovar"] = _listBLO;
            }
            catch (Exception)
            {

            }
            return _listBLO;
        }
        public List<clsWaitsheetBLO> Find(double Id)
        {
            List<clsWaitsheetBLO> _listBLO = new List<clsWaitsheetBLO>();
            try
            {
                clsWaitsheetBLO objBLO = new clsWaitsheetBLO();
                new Timesheet_Aprovar().PadraoEmpresa(objBLO);
                clsLoginBLO SessionUser = (clsLoginBLO)HttpContext.Current.Session["User"];
                objBLO.Id = Id;
                objBLO.IdSupervisor = SessionUser.Id;
                clsWaitsheetBLL objBLL = new clsWaitsheetBLL();
                _listBLO = objBLL.Find(objBLO);
            }
            catch (Exception)
            {

            }
            return _listBLO;
        }
        //[WebMethod]
        //public static List<clsEventoBLO> BuscarTudo()
        //{
        //    try
        //    {
        //        clsEventoBLL objBLL = new clsEventoBLL();
        //        clsEventoBLO objBLO = new clsEventoBLO();
        //        clsLoginBLO SessionUser = (HttpContext.Current.Session["User"] as clsLoginBLO);
        //        //Verifica se o login é da empresa ou funcionario
        //        if (SessionUser.Empresa == true)
        //            objBLO.IdEmpresa = SessionUser.Id;
        //        else
        //            objBLO.IdEmpresa = SessionUser.IdEmpresa;

        //        objBLO.IdMembroUsuario = SessionUser.Id;

        //        List<clsEventoBLO> _listBLO = new List<clsEventoBLO>();
        //        _listBLO = objBLL.Find(objBLO);


        //        return _listBLO;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        private void CriarTudo()
        {
            try
            {
                string function = string.Format("htmlAprovar('{0}');", txtFindDataAprovar.Value);
                this.Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "Aprovar", function, true);
            }
            catch (Exception ex)
            {
                modal.Notify.mNotify.Erro("", "Erro ao carregar eventos", this);
            }
        }
        protected void btnFindTimesheet_ServerClick(object sender, EventArgs e)
        {
            try
            {
                CriarTudo();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}