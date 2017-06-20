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
    public partial class Historia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CriarEventoTudo();
        }
        public void CarregarFeed()
        {
            try
            {
                clsEventoBLL objBLL = new clsEventoBLL();
                clsEventoBLO objBLO = new clsEventoBLO();
                //Id do usuario
                objBLO.IdEvento = (Session["User"] as clsLoginBLO).Id;
                //Verifica se o login é da empresa ou funcionario
                if ((Session["User"] as clsLoginBLO).Empresa == true)
                    objBLO.IdEmpresa = (Session["User"] as clsLoginBLO).Id;
                else
                    objBLO.IdEmpresa = (Session["User"] as clsLoginBLO).IdEmpresa;

                List<clsEventoBLO> _listBLO = new List<clsEventoBLO>();
                _listBLO = objBLL.Find(objBLO);


            }
            catch (Exception)
            {

                throw;
            }


        }
        public List<clsEventoBLO>  Find()
        {
            List<clsEventoBLO> _listBLO = new List<clsEventoBLO>();
            try
            {
                clsEventoBLL objBLL = new clsEventoBLL();
                clsEventoBLO objBLO = new clsEventoBLO();
                clsLoginBLO SessionUser = (HttpContext.Current.Session["User"] as clsLoginBLO);
                //Verifica se o login é da empresa ou funcionario
                if (SessionUser.Empresa == true)
                    objBLO.IdEmpresa = SessionUser.Id;
                else
                    objBLO.IdEmpresa = SessionUser.IdEmpresa;

                objBLO.IdMembroUsuario = SessionUser.Id;


                _listBLO = objBLL.Find(objBLO);

            }
            catch (Exception)
            {

                throw;
            }
            return _listBLO;
        }
        [WebMethod]
        public static List<clsEventoBLO> BuscarTudo()
        {
            List<clsEventoBLO> _listBLO;
            try
            {
                _listBLO = new List<clsEventoBLO>();
                _listBLO = new Historia().Find();

            }
            catch (Exception)
            {

                throw;
            }

            return _listBLO;

        }
        public void CriarEventoTudo()
        {
            try
            {
                string function = string.Format("CreateEventoTudo();");
                this.Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "EventoTudo", function, true);
            }
            catch (Exception ex)
            {
                modal.Notify.mNotify.Erro("", "Erro ao carregar eventos", this);
            }
        }
    }
}