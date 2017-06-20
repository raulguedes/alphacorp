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
    public partial class Timesheet_Consultar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {

                    if (!string.IsNullOrEmpty(Request.QueryString["Excluir"]) && !string.IsNullOrEmpty(Request.QueryString["Status"]))
                    {
                        double _Id = double.Parse(Request.QueryString["Excluir"].ToString());
                        int _IdStatus = int.Parse(Request.QueryString["Status"].ToString());
                        VerificarSession(_Id, _IdStatus, false);
                    }
                    else if (!string.IsNullOrEmpty(Request.QueryString["Editar"]) && !string.IsNullOrEmpty(Request.QueryString["Status"]))
                    {
                        double _Id = double.Parse(Request.QueryString["Editar"].ToString());
                        int _IdStatus = int.Parse(Request.QueryString["Status"].ToString());
                        VerificarSession(_Id, _IdStatus, true);
                    }

                    if (Session["User"] != null)
                    {
                        if (!(Session["User"] as clsLoginBLO).Empresa)
                        {
                            if ((Session["User"] as clsLoginBLO).IdTipoUser != (int)clsStatusBLO.TipoUser.Administrador)
                                if ((Session["User"] as clsLoginBLO).IdTipoUser != (int)clsStatusBLO.TipoUser.Supervisor)
                                    LiTimesheet_Aprovar.Visible = false;
                        }
                        CriarTudo();
                    }
                }
                catch (Exception)
                {
                    modal.Notify.mNotify.Erro("Erro", "Alguns dados não foram carregados", this);
                }
            }
        }
        private void ExcluirTime(double Id)
        {
            try
            {
                clsLoginBLO SessionUser = (Session["User"] as clsLoginBLO);
                clsTimesheetBLO objBLO = new clsTimesheetBLO();
                Padrao(objBLO);
                objBLO.Id = Id;
                objBLO.IdFuncionario = SessionUser.Id;

                clsTimesheetBLL objBLL = new clsTimesheetBLL();
                objBLL.Delete(objBLO);
                modal.Notify.mNotify.Sucesso("Sucesso", "Timesheet deletado", this);
            }
            catch (Exception)
            {
                modal.Notify.mNotify.Erro("Erro", "Não foi possível deletar", this);
            }

        }
        private void ExcluirWait(double Id)
        {
            try
            {
                clsLoginBLO SessionUser = (Session["User"] as clsLoginBLO);
                clsWaitsheetBLO objBLO = new clsWaitsheetBLO();
                Padrao(objBLO);
                objBLO.Id = SessionUser.Id;

                clsWaitsheetBLL objBLL = new clsWaitsheetBLL();
                objBLL.Delete(objBLO);
                modal.Notify.mNotify.Sucesso("Sucesso", "Timesheet deletado", this);
            }
            catch (Exception)
            {
                modal.Notify.mNotify.Erro("Erro", "Não foi possível deletar", this);
            }

        }
        private void VerificarSession(double Id, int IdStatus, bool Editar)
        {
            try
            {
                var ListaTime = (from Time in (List<clsTimePadraoBLO>)HttpContext.Current.Session["ListaConsulta"] where Time.Id == Id && Time.IdStatus == IdStatus select Time).SingleOrDefault();
                if (ListaTime != null)
                {
                    if (Editar)
                    {
                        if (IdStatus != (int)clsStatusBLO.Timesheet.Aprovado)
                            Response.Redirect("~/Timesheet.aspx?Editar=" + Id);
                        else
                            modal.Notify.mNotify.Erro("Erro", "Não é possível alterar com o status de APROVADO!!!!", this);
                    }
                    else if (!Editar)
                    {
                        if (IdStatus == (int)clsStatusBLO.Timesheet.Aguardando)
                            ExcluirWait(Id);
                        else
                            ExcluirTime(Id);
                    }
                    CriarTudo();
                }
                else
                    modal.Notify.mNotify.Erro("Erro", "Procadimento não realizado", this);
            }
            catch (Exception ex)
            {
                modal.Notify.mNotify.Erro("Erro", "" + ex.Message, this);
            }


        }
        protected void Padrao(clsTimePadraoBLO objBLO)
        {
            clsLoginBLO SessionUser = (clsLoginBLO)Session["User"];
            if (SessionUser.Empresa)
                objBLO.IdEmpresa = SessionUser.Id;
            else
                objBLO.IdEmpresa = SessionUser.IdEmpresa;
        }
        [WebMethod]
        public static List<clsTimePadraoBLO> Find(string wData)
        {
            List<clsTimePadraoBLO> _listBLO = null;
            string msg = string.Empty;
            try
            {
                clsLoginBLO SessionUser = (clsLoginBLO)HttpContext.Current.Session["User"];
                clsTimePadraoBLO objBLO = new clsTimePadraoBLO();
                new Timesheet_Consultar().Padrao(objBLO);
                objBLO.IdFuncionario = SessionUser.Id;
                if (!string.IsNullOrEmpty(wData))
                    objBLO.Data = DateTime.Parse(wData);
                else
                    objBLO.Data = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                clsTimesheetBLL objBLL = new clsTimesheetBLL();
                _listBLO = new List<clsTimePadraoBLO>();
                _listBLO = objBLL.Find(objBLO);
                HttpContext.Current.Session["ListaConsulta"] = _listBLO;
                if (!SessionUser.Empresa)
                {
                    objBLO = new clsTimePadraoBLO();
                    new Timesheet_Consultar().Padrao(objBLO);
                    objBLO.IdFuncionario = SessionUser.Id;
                    if (SessionUser.Empresa)
                        objBLO.IdSupervisor = SessionUser.Id;
                    else
                        objBLO.IdSupervisor = SessionUser.IdEmpresa;
                    if (!string.IsNullOrEmpty(wData))
                        objBLO.Data = DateTime.Parse(wData);
                    else
                        objBLO.Data = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    clsWaitsheetBLL _waitBLL = new clsWaitsheetBLL();
                    _listBLO.AddRange(_waitBLL.Find(objBLO));
                    //Carregando sessão.
                    HttpContext.Current.Session["ListaConsulta"] = _listBLO;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return _listBLO;
        }
        private void CriarTudo()
        {
            try
            {
                string function = string.Format("htmlConsultar('{0}');", txtFindData.Text);
                this.Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "Aprovar", function, true);
            }
            catch (Exception ex)
            {
                modal.Notify.mNotify.Erro("", "Erro ao carregar o timesheet", this);
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

                modal.Notify.mNotify.Erro("Erro", "Não foi possível carregar o timesheet", this);
            }
        }
    }
}