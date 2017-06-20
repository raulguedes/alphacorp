using AlphaCorp.BLL;
using AlphaCorp.BLO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlphaCorp.modal.Funcionario
{
    public partial class ucFuncionario : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                FindDepartamento();
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
                //Passa o resultado pra uma lista.
                listBLO = objBLL.Find(objBLO);                
                ddlmDepartamento.ClearSelection();
                ddlmDepartamento.DataSource = listBLO;
                ddlmDepartamento.DataTextField = "Nome";
                ddlmDepartamento.DataValueField = "Id";
                ddlmDepartamento.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}