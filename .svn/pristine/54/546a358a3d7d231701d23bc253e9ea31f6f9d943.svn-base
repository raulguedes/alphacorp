using AlphaCorp.BLL;
using AlphaCorp.BLO;
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
    public partial class Conta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "Configurações";
            if (!IsPostBack)
            {                
                clsLoginBLO SessionLogin = (clsLoginBLO)Session["User"];
                //Se o usuario for jurico(empresa)
                if ((Session["User"] as clsLoginBLO).Empresa)
                {

                    clsEmpresaBLO _objBLO = new clsEmpresaBLO();
                    _objBLO.Id = SessionLogin.Id;
                    _objBLO.Empresa = SessionLogin.Empresa;
                    _objBLO.Status = SessionLogin.Status;
                    List<clsEmpresaBLO> _listBLO = new List<clsEmpresaBLO>();
                    clsEmpresaBLL _objBLL = new clsEmpresaBLL();
                    _listBLO = _objBLL.Find(_objBLO);
                    CarregarSession(_listBLO, null);
                }
                else
                {

                    clsPessoaFisicaBLO _objBLO = new clsPessoaFisicaBLO();
                    _objBLO.Id = SessionLogin.Id;
                    _objBLO.IdEmpresa = SessionLogin.IdEmpresa;
                    _objBLO.Empresa = SessionLogin.Empresa;
                    _objBLO.Status = SessionLogin.Status;
                    List<clsPessoaFisicaBLO> _listBLO = new List<clsPessoaFisicaBLO>();
                    clsPessoaFisicaBLL _objBLL = new clsPessoaFisicaBLL();
                    _listBLO = _objBLL.Find(_objBLO);
                    CarregarSession(null, _listBLO);
                }

                CarregarCampos();
            }
        }
        private void CarregarCampos()
        {
            try
            {
                clsLoginBLO SessionLogin = (clsLoginBLO)Session["User"];
                txtNome.Value = SessionLogin.Nome;
                txtEmail.Value = SessionLogin.Email;

                if (SessionLogin.CEP > 0)
                {
                    if (SessionLogin.CEP.ToString().Length == 8)
                        txtCEP.Text = SessionLogin.CEP.ToString();
                    else
                        txtCEP.Text = "0" + SessionLogin.CEP.ToString();
                }

                txtEndereco.Value = SessionLogin.Endereco;

                if (SessionLogin.NumeroEndereco != 0)
                    txtNumeroEndereco.Value = SessionLogin.NumeroEndereco.ToString();

                txtComplementoEndereco.Value = SessionLogin.ComplementoEndereco;
                txtBairro.Value = SessionLogin.Bairro;
                txtUF.Value = SessionLogin.UF;
                txtCidade.Value = SessionLogin.Cidade;

                if (SessionLogin.Empresa)
                {
                    ContaE.Visible = true;
                    ContaP.Visible = false;
                    if (SessionLogin.Telefone != 0)
                        txtContato.Value = SessionLogin.Telefone.ToString();
                    if (SessionLogin.CNPJ != 0)
                        txtCNPJ.Value = SessionLogin.CNPJ.ToString();
                }
                else
                {
                    ContaP.Visible = true;
                    ContaE.Visible = false;
                    if (SessionLogin.RG != 0)
                        txtRG.Value = SessionLogin.RG.ToString();
                    if (SessionLogin.CPF != 0)
                        txtCPF.Value = SessionLogin.CPF.ToString();

                    if (SessionLogin.Residencial != 0)
                        txtResidencial.Value = SessionLogin.Residencial.ToString();
                    if (SessionLogin.Celular != 0)
                        txtCelular.Value = SessionLogin.Celular.ToString();
                    if (SessionLogin.DataNascimento != DateTime.MinValue)
                        txtData.Value = SessionLogin.DataNascimento.ToString();
                    //true -Masculino
                    if (SessionLogin.Sexo == clsStatusBLO.Sexo.Masculino.ToString())
                        //true -Masculino                
                        ddlSexo.SelectedValue = "1";
                    else
                        //feminino
                        ddlSexo.SelectedValue = "0";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        private void Empresa()
        {
            try
            {
                clsLoginBLO SessionLogin = (clsLoginBLO)Session["User"];
                clsEmpresaBLO _objBLO = new clsEmpresaBLO();
                _objBLO.Id = SessionLogin.Id;
                _objBLO.Empresa = SessionLogin.Empresa;
                _objBLO.Status = true;

                _objBLO.Nome = txtNome.Value;
                _objBLO.Email = txtEmail.Value;

                if (!string.IsNullOrEmpty(txtCNPJ.Value))
                    _objBLO.CNPJ = double.Parse(txtCNPJ.Value.ToString());

                if (!string.IsNullOrEmpty(txtContato.Value))
                    _objBLO.Telefone = double.Parse(txtContato.Value.ToString());

                //Campos do Form Endereco
                if (SessionLogin.IdEndereco != 0)
                    _objBLO.IdEndereco = SessionLogin.IdEndereco;

                if (!string.IsNullOrEmpty(txtCEP.Text))
                    _objBLO.CEP = int.Parse(txtCEP.Text.ToString());

                if (!string.IsNullOrEmpty(txtNumeroEndereco.Value))
                    _objBLO.NumeroEndereco = int.Parse(txtNumeroEndereco.Value.ToString());
                _objBLO.ComplementoEndereco = txtComplementoEndereco.Value;
                _objBLO.Bairro = txtBairro.Value;
                _objBLO.UF = txtUF.Value;
                _objBLO.Cidade = txtCidade.Value;

                clsEmpresaBLL _objBLL = new clsEmpresaBLL();
                _objBLL.Update(_objBLO);
                List<clsEmpresaBLO> _listBLO = new List<clsEmpresaBLO>();
                _listBLO = _objBLL.Find(_objBLO);
                CarregarSession(_listBLO, null);

                CarregarCampos();
                modal.Notify.mNotify.Sucesso("Sucesso", "Dados alterados!!", this);
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private void PessoaFisica()
        {
            try
            {
                clsLoginBLO SessionLogin = (clsLoginBLO)Session["User"];
                clsPessoaFisicaBLO _objBLO = new clsPessoaFisicaBLO();
                _objBLO.Id = SessionLogin.Id;
                _objBLO.IdEmpresa = SessionLogin.IdEmpresa;

                _objBLO.Nome = txtNome.Value;                

                if (!string.IsNullOrEmpty(txtData.Value.ToString()))
                    _objBLO.DataNascimento = Convert.ToDateTime(txtData.Value.ToString());
                else
                    _objBLO.DataNascimento = DateTime.MinValue;

                //true -Masculino                                
                //false-Feminino
                _objBLO.Sexo = ddlSexo.SelectedValue == "1" ? clsStatusBLO.Sexo.Masculino.ToString() : clsStatusBLO.Sexo.Feminino.ToString();
                if (!string.IsNullOrEmpty(txtRG.Value))
                    _objBLO.RG = double.Parse(txtRG.Value.ToString());

                if (!string.IsNullOrEmpty(txtResidencial.Value))
                    _objBLO.Residencial = double.Parse(txtResidencial.Value.ToString());

                if (!string.IsNullOrEmpty(txtCelular.Value))
                    _objBLO.Celular = double.Parse(txtCelular.Value.ToString());

                if (SessionLogin.IdEndereco != 0)
                    _objBLO.IdEndereco = SessionLogin.IdEndereco;

                if (!string.IsNullOrEmpty(txtCEP.Text))
                    _objBLO.CEP = int.Parse(txtCEP.Text.ToString());

                if (!string.IsNullOrEmpty(txtNumeroEndereco.Value))
                    _objBLO.NumeroEndereco = int.Parse(txtNumeroEndereco.Value.ToString());

                _objBLO.IdDepartamento = SessionLogin.IdDepartamento;
                _objBLO.IdCargo = SessionLogin.IdCargo;
                _objBLO.IdTipoUser = SessionLogin.IdTipoUser;
                _objBLO.ComplementoEndereco = txtComplementoEndereco.Value;
                _objBLO.Endereco = txtEndereco.Value;
                _objBLO.Bairro = txtBairro.Value;
                _objBLO.UF = txtUF.Value;
                _objBLO.Cidade = txtCidade.Value;

                clsPessoaFisicaBLL _objBLL = new clsPessoaFisicaBLL();
                _objBLL.Update(_objBLO);
                modal.Notify.mNotify.Sucesso("Sucesso", "Dados alterados!!", this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_listEmpresa">List<clsEmpresaBLO></param>
        /// <param name="_listPessoa">List<clsPessoaFisicaBLO></param>
        private void CarregarSession(List<clsEmpresaBLO> _listEmpresa, List<clsPessoaFisicaBLO> _listPessoa)
        {
            clsLoginBLO SessionLogin = (clsLoginBLO)Session["User"];
            if (_listEmpresa != null)
                foreach (clsEmpresaBLO item in _listEmpresa)
                {
                    SessionLogin.Id = item.Id;
                    SessionLogin.IdEmpresa = item.Id;
                    SessionLogin.IdTipoUser = item.IdTipoUser;
                    SessionLogin.IdEndereco = item.IdEndereco;

                    SessionLogin.Nome = item.Nome;
                    SessionLogin.CNPJ = item.CNPJ;
                    SessionLogin.Telefone = item.Telefone;
                    SessionLogin.Email = item.Email;
                    SessionLogin.Empresa = item.Empresa;
                    SessionLogin.Senha = item.Senha;
                    SessionLogin.Status = item.Status;
                    if (item.CEP.ToString().Length == 8)
                        SessionLogin.CEP = item.CEP;
                    else
                        SessionLogin.CEP = int.Parse("0" + item.CEP.ToString());
                    SessionLogin.Endereco = item.Endereco;
                    SessionLogin.NumeroEndereco = item.NumeroEndereco;
                    SessionLogin.ComplementoEndereco = item.ComplementoEndereco;
                    SessionLogin.Bairro = item.Bairro;
                    SessionLogin.Cidade = item.Cidade;
                    SessionLogin.UF = item.UF;
                }
            else
                foreach (clsPessoaFisicaBLO item in _listPessoa)
                {
                    SessionLogin.Id = item.Id;
                    SessionLogin.IdEmpresa = item.IdEmpresa;
                    SessionLogin.IdTipoUser = item.IdTipoUser;
                    SessionLogin.IdEndereco = item.IdEndereco;

                    SessionLogin.Nome = item.Nome;
                    SessionLogin.DataNascimento = item.DataNascimento;
                    SessionLogin.RG = item.RG;
                    SessionLogin.CPF = item.CPF;
                    SessionLogin.Sexo = item.Sexo;
                    SessionLogin.Celular = item.Celular;
                    SessionLogin.Residencial = item.Residencial;
                    SessionLogin.Email = item.Email;
                    SessionLogin.Empresa = item.Empresa;
                    SessionLogin.Senha = item.Senha;
                    SessionLogin.Status = item.Status;
                    SessionLogin.HoraDiaria = item.HoraDiaria;
                    if (item.CEP.ToString().Length == 8)
                        SessionLogin.CEP = item.CEP;
                    else
                        SessionLogin.CEP = int.Parse("0" + item.CEP.ToString());
                    SessionLogin.Endereco = item.Endereco;
                    SessionLogin.NumeroEndereco = item.NumeroEndereco;
                    SessionLogin.ComplementoEndereco = item.ComplementoEndereco;
                    SessionLogin.Bairro = item.Bairro;
                    SessionLogin.Cidade = item.Cidade;
                    SessionLogin.UF = item.UF;
                }
        }
        private void Salvar()
        {
            try
            {
                clsLoginBLO SessionLogin = (clsLoginBLO)Session["User"];
                //Verifica se o usuario é Empresa(true) ou pessoa(false)
                if (SessionLogin.Empresa)
                    Empresa();
                else
                    PessoaFisica();
            }
            catch (Exception)
            {

                modal.Notify.mNotify.Erro("Erro", "Não foi possível realizar a alteração", this);
            }



        }
        protected void btnBuscarCep_Click(object sender, EventArgs e)
        {
            try
            {
                clsEnderecoBLO _enderecoBLO = new clsEnderecoBLO();
                clsUtilBLL _utilBLL = new clsUtilBLL();
                _enderecoBLO = _utilBLL.BuscaCEP(txtCEP.Text);
                txtEndereco.Value = _enderecoBLO.Endereco;
                txtBairro.Value = _enderecoBLO.Bairro;
                txtComplementoEndereco.Value = _enderecoBLO.ComplementoEndereco;
                txtUF.Value = _enderecoBLO.UF;
                txtCidade.Value = _enderecoBLO.Cidade;
            }
            catch (Exception ex)
            {
                modal.Notify.mNotify.Erro("Erro",ex.Message,this);
            }
        }
        [System.Web.Services.WebMethod]
        public static string RefS(string Atual, string Nova, string Confirmar)
        {
            string msn = string.Empty;
            try
            {
                clsLoginBLO SessionLogin = (clsLoginBLO)HttpContext.Current.Session["User"];
                if (Atual == SessionLogin.Senha)
                {

                    if (!string.IsNullOrEmpty(Nova) && Nova == Confirmar)
                    {
                        if (SessionLogin.Empresa)
                        {
                            clsEmpresaBLO _empresaBLO = new clsEmpresaBLO();
                            _empresaBLO.Id = (SessionLogin.Id);
                            _empresaBLO.IdEndereco = (SessionLogin.IdEndereco);
                            _empresaBLO.Empresa = (SessionLogin.Empresa);
                            _empresaBLO.Empresa = (SessionLogin.Empresa);
                            _empresaBLO.Status = (SessionLogin.Status);
                            _empresaBLO.Senha = Nova;

                            clsEmpresaBLL _empresaBLL = new clsEmpresaBLL();
                            _empresaBLL.Update(_empresaBLO);

                        }
                        else
                        {
                            clsPessoaFisicaBLO _objBLO = new clsPessoaFisicaBLO();

                            _objBLO.Id = SessionLogin.Id;
                            _objBLO.IdEmpresa = SessionLogin.IdEmpresa;
                            _objBLO.Senha = Nova;

                            clsPessoaFisicaBLL _objBLL = new clsPessoaFisicaBLL();
                            _objBLL.Update(_objBLO);
                        }
                        msn = "Senha alterada";
                    }
                    else
                        throw new Exception("Não foi possível alterar a senha!!!<br/>Tente novamente.");
                }
                else
                    throw new Exception("Senha atual incorreta.");
            }
            catch (Exception ex)
            {
                msn = ex.Message;
            }
            return msn;
        }
        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            Salvar();
        }
        protected void SenhaAlterar_ServerClick(object sender, EventArgs e)
        {
            try
            {
                modal.Senha.mSenha.Alterar(this);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}