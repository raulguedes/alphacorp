using AlphaCorp.BLL;
using AlphaCorp.BLO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlphaCorp.modal.Projeto
{
    public partial class ucProjeto : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {                
                FindCliente();
                FindDepartamento();
            }

        }
        private void FindDepartamento()
        {
            try
            {
                //Instancia obj
                clsDepartamentoBLO objBLO = new clsDepartamentoBLO();
                //Preenche objBLO
                new AlphaCorp.Departamento().Padrao(objBLO);
                clsDepartamentoBLL objBLL = new clsDepartamentoBLL();
                List<clsDepartamentoBLO> listBLO = new List<clsDepartamentoBLO>();

                ListItem item = new ListItem();
                item.Text = "Selecione...";
                item.Value = "0";
                item.Selected = true;

                //Passa o resultado pra uma lista.
                listBLO = objBLL.Find(objBLO);
                ddlmDepartamento.ClearSelection();
                ddlmDepartamento.Items.Clear();
                ddlmDepartamento.Items.Add(item);
                ddlmDepartamento.DataSource = listBLO;
                ddlmDepartamento.DataTextField = "Nome";
                ddlmDepartamento.DataValueField = "Id";
                ddlmDepartamento.DataBind();

                ddlmDepartamento2.ClearSelection();
                ddlmDepartamento2.Items.Clear();
                ddlmDepartamento2.Items.Add(item);
                ddlmDepartamento2.DataSource = listBLO;
                ddlmDepartamento2.DataTextField = "Nome";
                ddlmDepartamento2.DataValueField = "Id";
                ddlmDepartamento2.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void FindCliente()
        {
            try
            {
                //Instancia obj
                clsClienteBLO objBLO = new clsClienteBLO();
                //Preenche objBLO
                new AlphaCorp.Cliente().Padrao(objBLO);
                clsClienteBLL objBLL = new clsClienteBLL();
                List<clsClienteBLO> listBLO = new List<clsClienteBLO>();

                ListItem item = new ListItem();
                item.Text = "Selecione...";
                item.Value = "0";
                item.Selected = true;

                //Passa o resultado pra uma lista.
                listBLO = objBLL.Find(objBLO);
                ddlmCliente.ClearSelection();
                ddlmCliente.Items.Clear();
                ddlmCliente.Items.Add(item);
                ddlmCliente.DataSource = listBLO;
                ddlmCliente.DataTextField = "Nome";
                ddlmCliente.DataValueField = "Id";
                ddlmCliente.DataBind();

                ddlmCliente2.ClearSelection();
                ddlmCliente2.Items.Clear();
                ddlmCliente2.Items.Add(item);
                ddlmCliente2.DataSource = listBLO;
                ddlmCliente2.DataTextField = "Nome";
                ddlmCliente2.DataValueField = "Id";
                ddlmCliente2.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}