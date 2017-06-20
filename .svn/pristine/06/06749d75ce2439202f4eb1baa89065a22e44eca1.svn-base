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
    public partial class Evento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    try
                    {
                        if (Request.QueryString["Id"] != null)
                        {
                            double _Id = double.Parse(Request.QueryString["Id"].ToString());
                            CarregarMembros(_Id);
                            CarregarEvento(_Id);
                        }
                    }
                    catch (Exception)
                    {
                        divEvento.Visible = false;
                        divErro.Visible = true;
                    }
                }
                catch (Exception)
                {

                    modal.Notify.mNotify.Erro("Erro", "Evento não encontrado", this);
                }
            }
        }
        public void Padrao(clsEventoBLO objBLO)
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
        public void Padrao(clsMembroEventoBLO objBLO)
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
        private void CarregarMembros(double IdEvento)
        {
            try
            {
                clsMembroEventoBLO membroBLO = new clsMembroEventoBLO();
                Padrao(membroBLO);
                membroBLO.IdEvento = IdEvento;
                clsMembroEventoBLL membroBLL = new clsMembroEventoBLL();
                List<clsMembroEventoBLO> _listBLO = new List<clsMembroEventoBLO>();
                _listBLO = membroBLL.Find(membroBLO);
                int _vou = 0, _nao = 0, _convidado = 0;
                foreach (clsMembroEventoBLO item in _listBLO)
                {
                    if (item.Confirmar == (int)clsStatusBLO.EventoConvidado.Vou)
                    {
                        _vou++;
                        _convidado++;
                        lblTodalVai.InnerText = _vou.ToString();
                    }
                    else if (item.Confirmar == (int)clsStatusBLO.EventoConvidado.Nao)
                    {
                        _nao++;
                        _convidado++;
                        lblTodalNaoVai.InnerText = _nao.ToString();
                    }
                    else if (item.Confirmar == (int)clsStatusBLO.EventoConvidado.Convidado)
                    {
                        _convidado++;
                    }
                    lblTodalConvidados.InnerText = _convidado.ToString();
                }
            }
            catch (Exception)
            {
                modal.Notify.mNotify.Erro("Erro", "Não foi possível carrregar a qualtidade de membros", this);
            }
        }
        public void CarregarCampos(List<clsEventoBLO> _listBLO)
        {
            try
            {
                foreach (clsEventoBLO item in _listBLO)
                {
                    if (item.IdTipoUsuario == (int)clsStatusBLO.TipoUser.Administrador)
                    {
                        idEventoMembros.Visible = false;
                        idEventoMembros2.Visible = true;
                        idEventoConvidar.Visible = true;
                    }
                    else
                    {
                        idEventoConvidar.Visible = false;
                        idEventoMembros.Visible = true;
                        idEventoMembros2.Visible = false;
                    }
                    if (item.Confirmar == (int)clsStatusBLO.EventoConvidado.Vou)
                    {
                        ddlConvite.SelectedValue = "1";
                        if (item.IdMembroUsuario == item.IdCriador)
                            ddlConvite.Enabled = false;
                        idEventoStatus.Visible = true;
                        idEventoStatusVou.Visible = false;
                        idEventoStatusNaoVou.Visible = false;
                    }
                    else if (item.Confirmar == (int)clsStatusBLO.EventoConvidado.Nao)
                    {
                        ddlConvite.SelectedValue = "2";
                        idEventoStatus.Visible = true;
                        idEventoStatusVou.Visible = false;
                        idEventoStatusNaoVou.Visible = false;
                    }
                    else if (item.Confirmar == (int)clsStatusBLO.EventoConvidado.Convidado)
                    {
                        idEventoStatus.Visible = false;
                        idEventoStatusVou.Visible = true;
                        idEventoStatusNaoVou.Visible = true;
                    }
                    lblNomeEvento.InnerText = item.Nome;
                    string FormatarDetalhes = string.Empty;
                    if (item.Privacidade)
                        FormatarDetalhes += "Evento privado - Criado por ";
                    else
                        FormatarDetalhes += "Evento publico - Criado por ";
                    lblDetalhesDoEvento.InnerText = FormatarDetalhes;
                    lblCriador.InnerText = item.NomeCriador;
                    if (!string.IsNullOrEmpty(item.Local))
                        lblLocal.InnerText = item.Local;
                    else
                        lblLocal.InnerText = "Não definido";
                    lblDescricao.InnerText = item.Descricao;
                    string FormatarHora = string.Empty;
                    if (item.DataInicio != DateTime.MinValue)
                    {
                        FormatarHora += item.DataInicio.Value.ToString("dd");
                        FormatarHora += " de " + item.DataInicio.Value.ToString("MMMM").ToUpper();
                        if (item.DataInicio.Value.ToString("yyyy") != DateTime.Now.Year.ToString())
                            FormatarHora += " de " + item.DataInicio.Value.ToString("yyyy");
                    }
                    if (!string.IsNullOrEmpty(item.HoraInicio.ToString()))
                        FormatarHora += " ás " + item.HoraInicio.Value.Hours;
                    if (!string.IsNullOrEmpty(item.HoraInicio.ToString()))
                        FormatarHora += ":" + item.HoraInicio.Value.Minutes;

                    if (!string.IsNullOrEmpty(item.HoraTermino.ToString()))
                        FormatarHora += " - " + item.HoraTermino.Value.Hours;
                    if (!string.IsNullOrEmpty(item.HoraTermino.ToString()))
                        FormatarHora += ":" + item.HoraTermino.Value.Minutes;
                    lblHorario.InnerText = FormatarHora;

                    if (item.DataInicio == DateTime.MinValue && item.DataTermino == DateTime.MinValue &
                        !string.IsNullOrEmpty(item.HoraInicio.ToString()) && !string.IsNullOrEmpty(item.HoraTermino.ToString()))
                    {
                        lblHorario.InnerText = "Data e hora não definida";
                        lblSubHorario.Visible = false;
                    }
                    else
                    {
                        string SubHora = string.Empty;
                        if (item.DataInicio != DateTime.MinValue)
                        {
                            SubHora += item.DataInicio.Value.ToString("dd");
                            SubHora += " / " + item.DataInicio.Value.ToString("MM").ToUpper();
                            if (item.DataInicio.Value.ToString("yyyy") != DateTime.Now.Year.ToString())
                                FormatarHora += item.DataInicio.Value.ToString("yyyy");
                        }
                        if (!string.IsNullOrEmpty(item.HoraInicio.ToString()))
                            SubHora += " ás " + item.HoraInicio.Value.Hours;
                        if (!string.IsNullOrEmpty(item.HoraInicio.ToString()))
                            SubHora += ":" + item.HoraInicio.Value.Minutes;

                        if (item.DataTermino != DateTime.MinValue)
                        {
                            SubHora += "  até " + item.DataTermino.Value.ToString("dd");
                            SubHora += " / " + item.DataInicio.Value.ToString("MM").ToUpper();
                            if (item.DataInicio.Value.ToString("yyyy") != DateTime.Now.Year.ToString())
                                FormatarHora += item.DataInicio.Value.ToString("yyyy");
                        }

                        if (!string.IsNullOrEmpty(item.HoraTermino.ToString()))
                            SubHora += " " + item.HoraTermino.Value.Hours;
                        if (!string.IsNullOrEmpty(item.HoraTermino.ToString()))
                            SubHora += ":" + item.HoraTermino.Value.Minutes;
                        lblSubHorario.InnerText = SubHora;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void CarregarEvento(double Id)
        {
            try
            {
                clsEventoBLO objBLO = new clsEventoBLO();
                List<clsEventoBLO> _listBLO = new List<clsEventoBLO>();
                Padrao(objBLO);
                objBLO.IdEvento = Id;
                objBLO.IdMembroUsuario = (Session["User"] as clsLoginBLO).Id;
                clsEventoBLL objBLL = new clsEventoBLL();
                _listBLO = objBLL.FindEvento(objBLO);
                if (_listBLO.Count == 1)
                    CarregarCampos(_listBLO);
                else
                {
                    divEvento.Visible = false;
                    divErro.Visible = true;
                }
            }
            catch (Exception)
            {
                modal.Notify.mNotify.Erro("Erro", "Não foi possivel carregar esse evento", this);
            }

        }
        [System.Web.Services.WebMethod]
        public static List<clsEventoBLO> Explorar()
        {
            clsEventoBLO _objBLO = new clsEventoBLO();

            _objBLO.DataInicio = DateTime.Now;
            _objBLO.DataTermino = DateTime.Now;
            _objBLO.Nome = "Raul teste";

            List<clsEventoBLO> _listBLO = new List<clsEventoBLO>();
            _listBLO.Add(_objBLO);

            return _listBLO;
        }
        [System.Web.Services.WebMethod]
        public static string CriarEvento(string[] mEvento)
        {
            string msg = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(mEvento[0]))
                {
                    clsEventoBLO _eventoBLO = new clsEventoBLO();
                    _eventoBLO.Nome = mEvento[0];
                    _eventoBLO.Descricao = mEvento[1];
                    if ((HttpContext.Current.Session["User"] as clsLoginBLO).Empresa)
                    {
                        _eventoBLO.IdEmpresa = (HttpContext.Current.Session["User"] as clsLoginBLO).Id;
                        _eventoBLO.IdUsuario = (HttpContext.Current.Session["User"] as clsLoginBLO).Id;
                    }
                    else
                    {
                        _eventoBLO.IdEmpresa = (HttpContext.Current.Session["User"] as clsLoginBLO).IdEmpresa;
                        _eventoBLO.IdUsuario = (HttpContext.Current.Session["User"] as clsLoginBLO).Id;
                    }
                    _eventoBLO.Local = mEvento[2];
                    if (!string.IsNullOrEmpty(mEvento[3]))
                        _eventoBLO.DataInicio = Convert.ToDateTime(mEvento[3]);

                    if (!string.IsNullOrEmpty(mEvento[4]))
                        _eventoBLO.HoraInicio = TimeSpan.Parse(mEvento[4]);

                    if (!string.IsNullOrEmpty(mEvento[5]))
                        _eventoBLO.DataTermino = Convert.ToDateTime(mEvento[5]);

                    if (!string.IsNullOrEmpty(mEvento[6]))
                        _eventoBLO.HoraTermino = TimeSpan.Parse(mEvento[6]);

                    if (mEvento[7] == "0")
                        _eventoBLO.Privacidade = false;
                    else if (mEvento[7] == "1")
                        _eventoBLO.Privacidade = true;

                    _eventoBLO.IdTipoUsuario = (int)clsStatusBLO.TipoUser.Administrador;
                    _eventoBLO.Confirmar = (int)clsStatusBLO.EventoConvidado.Vou;


                    clsEventoBLL _eventoBLL = new clsEventoBLL();
                    _eventoBLL.Insert(_eventoBLO);
                }
                else
                    msg = "Nome do evento está vazio !!!";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }


        void Excluir(double Id)
        {

        }
    }
}