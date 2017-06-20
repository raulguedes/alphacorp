using AlphaCorp.BLO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaCorp.DAO
{
    public class clsPessoaFisicaDAO
    {
        public bool Insert(clsPessoaFisicaBLO _usuario)
        {
            bool _ret = false;
            try
            {
                // Cria conexão.
                using (clsConexaoDAO con = new clsConexaoDAO(ConfigurationManager.ConnectionStrings["Alpha"].ConnectionString))
                {
                    List<SqlParameter> listParameter = new List<SqlParameter>() {
                    new SqlParameter("@OperationType", 1),     /* 1: Insert */
                    new SqlParameter("@vcNome", _usuario.Nome),
                    new SqlParameter("@vcEmail", _usuario.Email),
                    new SqlParameter("@vcSenha", _usuario.Senha),
                    new SqlParameter("@btStatus", _usuario.Status),
                    new SqlParameter("@btEmpresa",_usuario.Empresa),
                    new SqlParameter("@IdTipoUser",_usuario.IdTipoUser),
                    new SqlParameter("@vcSexo",_usuario.Sexo),

                    new SqlParameter("@IdEmpresa", _usuario.IdEmpresa),
                    new SqlParameter("@nmCPF", _usuario.CPF),
                    new SqlParameter("@nmRG", _usuario.RG),
                    new SqlParameter("@nmResidencial", _usuario.Residencial),
                    new SqlParameter("@nmCelular", _usuario.Celular),
                    new SqlParameter("@dtHoraDiaria", _usuario.HoraDiaria),
                    new SqlParameter("@IdDepartamento", _usuario.IdDepartamento),
                    new SqlParameter("@IdCargo", _usuario.IdCargo),
                    new SqlParameter("@btPermitirHoraExtra", _usuario.PermitirHoraExtra),
                };
                    con.executeQuery("uspPessoaFisica", listParameter);
                    _ret = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("clsUsuarioDAO.Insert", ex);

            }

            return _ret;
        }
        public bool Update(clsPessoaFisicaBLO _usuario)
        {
            bool _ret = false;
            try
            {
                // Cria conexão.

                using (clsConexaoDAO con = new clsConexaoDAO(ConfigurationManager.ConnectionStrings["Alpha"].ConnectionString))
                {
                    List<SqlParameter> listParameter = new List<SqlParameter>() {
                        /*tblUsuario*/
                    new SqlParameter("@OperationType", 2),
                    new SqlParameter("@vcNome", _usuario.Nome),
                    new SqlParameter("@IdEndereco", _usuario.IdEndereco),
                    new SqlParameter("@vcSexo", _usuario.Sexo),

                    new SqlParameter("@nmRG", _usuario.RG),
                    new SqlParameter("@nmCPF", _usuario.CPF),
                    new SqlParameter("@nmResidencial", _usuario.Residencial),
                    new SqlParameter("@nmCelular", _usuario.Celular),
                    new SqlParameter("@dtHoraDiaria", _usuario.HoraDiaria),
                    new SqlParameter("@btPermitirHoraExtra", _usuario.PermitirHoraExtra),
                    new SqlParameter("@IdCargo", _usuario.IdCargo),
                    new SqlParameter("@IdDepartamento", _usuario.IdDepartamento),
                    new SqlParameter("@IdEmpresa", _usuario.IdEmpresa),

                    new SqlParameter("@vcEndereco", _usuario.Endereco),
                    new SqlParameter("@nmCEP", _usuario.CEP),
                    new SqlParameter("@nmNumeroEndereco", _usuario.NumeroEndereco),
                    new SqlParameter("@vcComplementoEndereco", _usuario.ComplementoEndereco),
                    new SqlParameter("@vcBairro", _usuario.Bairro),
                    new SqlParameter("@vcUF", _usuario.UF),
                    new SqlParameter("@vcCidade", _usuario.Cidade),
                };
                    con.executeQuery("uspPessoaFisica", listParameter);
                    _ret = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("clsPessoaFisicaDAO.Update", ex);

            }

            return _ret;
        }
        public bool Delete(clsPessoaFisicaBLO _usuario)
        {
            bool _ret = false;
            try
            {
                // Cria conexão.

                using (clsConexaoDAO con = new clsConexaoDAO(ConfigurationManager.ConnectionStrings["Alpha"].ConnectionString))
                {
                    List<SqlParameter> listParameter = new List<SqlParameter>() {
                    new SqlParameter("@OperationType", 3),     /* 2: Update */
                    new SqlParameter("@IdPessoaFisica", _usuario.Id),
                    new SqlParameter("@IdEmpresa", _usuario.IdEmpresa),
                };
                    con.executeQuery("uspPessoaFisica", listParameter);
                    _ret = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("clsUsuarioDAO.Update", ex);

            }

            return _ret;
        }
        /// <summary>
        /// Metodo de busca principal(FindOne,FindAll passam por ele).
        /// Busca feita pelo por quase todos os parametros       
        /// </summary>
        /// <param name="FindOne"></param>
        /// <returns></returns>

        public List<clsPessoaFisicaBLO> Find(clsPessoaFisicaBLO _usuario)
        {
            // Inicializa o objeto de retorno.
            List<clsPessoaFisicaBLO> retorno = new List<clsPessoaFisicaBLO>();
            // DataReader de retorno.
            SqlDataReader dr = null;

            try
            {
                using (clsConexaoDAO con = new clsConexaoDAO(ConfigurationManager.ConnectionStrings["Alpha"].ConnectionString))
                {

                    // Cria lista de parâmetros.
                    List<SqlParameter> param = new List<SqlParameter>();

                    param.Add(new SqlParameter("@OperationType", 4));

                    // Verifica quais parâmetros serão utilizados.
                    if (_usuario != null)
                    {

                        // Verifica se o Nome do Cliente é parâmetro para pesquisa.
                        if (_usuario.Id != 0)
                        {
                            param.Add(new SqlParameter("@IdUsuario", _usuario.Id));
                        }
                        if (_usuario.IdEmpresa != 0)
                        {
                            param.Add(new SqlParameter("@IdEmpresa", _usuario.IdEmpresa));
                        }
                        if (_usuario.IdTipoUser != 0)
                        {
                            param.Add(new SqlParameter("@IdTipoUser", _usuario.IdTipoUser));
                        }
                        if (_usuario.IdCargo != 0)
                        {
                            param.Add(new SqlParameter("@IdCargo", _usuario.IdCargo));
                        }
                        if (_usuario.IdDepartamento != 0)
                        {
                            param.Add(new SqlParameter("@IdDepartamento", _usuario.IdDepartamento));
                        }
                        if (!string.IsNullOrEmpty(_usuario.Nome))
                        {
                            param.Add(new SqlParameter("@vcNome", _usuario.Nome));
                        }
                        if (_usuario.RG != 0)
                        {
                            param.Add(new SqlParameter("@nmRG", _usuario.RG));
                        }
                        if (_usuario.Status != null)
                            param.Add(new SqlParameter("@btStatus", _usuario.Status));


                    }

                    // Obtém dados de retorno.
                    using (dr = con.ReturnDataReader("uspPessoaFisica", param))
                    {
                        // Para cada registro é criado um objeto clsPessoaFisicaBLO.
                        while (dr.Read())
                        {

                            clsPessoaFisicaBLO _usuarioFind = new clsPessoaFisicaBLO();
                            _usuarioFind.Id = double.Parse(dr["IdUsuario"].ToString());
                            _usuarioFind.Nome = string.IsNullOrEmpty(dr["vcNome"].ToString()) ? string.Empty : dr["vcNome"].ToString();
                            _usuarioFind.Senha = string.IsNullOrEmpty(dr["vcSenha"].ToString()) ? string.Empty : dr["vcSenha"].ToString();
                            _usuarioFind.DataNascimento = Convert.ToDateTime(string.IsNullOrEmpty(dr["dtDataNascimento"].ToString()) ? DateTime.MinValue : DateTime.Parse(dr["dtDataNascimento"].ToString()));
                            _usuarioFind.Sexo = string.IsNullOrEmpty(dr["vcSexo"].ToString()) ? string.Empty : dr["vcSexo"].ToString();
                            _usuarioFind.RG = Convert.ToDouble(string.IsNullOrEmpty(dr["nmRG"].ToString()) ? double.MinValue : double.Parse(dr["nmRG"].ToString()));
                            _usuarioFind.CPF = Convert.ToDouble(string.IsNullOrEmpty(dr["nmCPF"].ToString()) ? double.MinValue : double.Parse(dr["nmCPF"].ToString()));
                            _usuarioFind.Email = string.IsNullOrEmpty(dr["vcEmail"].ToString()) ? string.Empty : dr["vcEmail"].ToString();
                            _usuarioFind.Residencial = Convert.ToDouble(string.IsNullOrEmpty(dr["nmResidencial"].ToString()) ? double.MinValue : double.Parse(dr["nmResidencial"].ToString()));
                            _usuarioFind.Celular = Convert.ToDouble(string.IsNullOrEmpty(dr["nmCelular"].ToString()) ? double.MinValue : double.Parse(dr["nmCelular"].ToString()));
                            if (!string.IsNullOrEmpty(dr["IdEndereco"].ToString()))
                            {
                                _usuarioFind.IdEndereco = int.Parse(dr["IdEndereco"].ToString());
                                _usuarioFind.CEP = int.Parse(dr["nmCEP"].ToString());
                                _usuarioFind.Endereco = string.IsNullOrEmpty(dr["vcEndereco"].ToString()) ? string.Empty : dr["vcEndereco"].ToString();
                                if (!string.IsNullOrEmpty(dr["nmNumeroEndereco"].ToString()))
                                    _usuarioFind.NumeroEndereco = int.Parse(dr["nmNumeroEndereco"].ToString());
                                _usuarioFind.ComplementoEndereco = string.IsNullOrEmpty(dr["vcComplementoEndereco"].ToString()) ? string.Empty : dr["vcComplementoEndereco"].ToString();
                                _usuarioFind.Bairro = string.IsNullOrEmpty(dr["vcBairro"].ToString()) ? string.Empty : dr["vcBairro"].ToString();
                                _usuarioFind.Cidade = string.IsNullOrEmpty(dr["vcCidade"].ToString()) ? string.Empty : dr["vcCidade"].ToString();
                                _usuarioFind.UF = string.IsNullOrEmpty(dr["vcUF"].ToString()) ? string.Empty : dr["vcUF"].ToString();
                            }
                            _usuarioFind.HoraDiaria = TimeSpan.Parse(dr["dtHoraDiaria"].ToString());
                            _usuarioFind.Status = Convert.ToBoolean(dr["btStatus"]);
                            _usuarioFind.IdTipoUser = int.Parse(dr["IdTipoUser"].ToString());
                            _usuarioFind.IdCargo = double.Parse(dr["IdCargo"].ToString());
                            _usuarioFind.IdDepartamento = double.Parse(dr["IdDepartamento"].ToString());
                            _usuarioFind.IdEmpresa = double.Parse(dr["IdEmpresa"].ToString());
                            _usuarioFind.vcTipoUser = string.IsNullOrEmpty(dr["vcTipoUser"].ToString()) ? string.Empty : dr["vcTipoUser"].ToString();

                            retorno.Add(_usuarioFind);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("clsClienteDAO.Find", ex);
            }

            return retorno;
        }
        public List<clsPessoaFisicaBLO> FindSupervisor(clsPessoaFisicaBLO _usuario)
        {
            // Inicializa o objeto de retorno.
            List<clsPessoaFisicaBLO> retorno = new List<clsPessoaFisicaBLO>();
            // DataReader de retorno.
            SqlDataReader dr = null;

            try
            {
                using (clsConexaoDAO con = new clsConexaoDAO(ConfigurationManager.ConnectionStrings["Alpha"].ConnectionString))
                {

                    // Cria lista de parâmetros.
                    List<SqlParameter> param = new List<SqlParameter>();

                    param.Add(new SqlParameter("@OperationType", 5));

                    // Verifica quais parâmetros serão utilizados.
                    if (_usuario != null)
                    {

                        // Verifica se o Nome do Cliente é parâmetro para pesquisa.
                        if (_usuario.Id != 0)
                        {
                            param.Add(new SqlParameter("@IdUsuario", _usuario.Id));
                        }
                        if (_usuario.IdEmpresa != 0)
                        {
                            param.Add(new SqlParameter("@IdEmpresa", _usuario.IdEmpresa));
                        }
                        if (_usuario.IdTipoUser != 0)
                        {
                            param.Add(new SqlParameter("@IdTipoUser", _usuario.IdTipoUser));
                        }
                        if (_usuario.IdCargo != 0)
                        {
                            param.Add(new SqlParameter("@IdCargo", _usuario.IdCargo));
                        }
                        if (_usuario.IdDepartamento != 0)
                        {
                            param.Add(new SqlParameter("@IdDepartamento", _usuario.IdDepartamento));
                        }
                        if (!string.IsNullOrEmpty(_usuario.Nome))
                        {
                            param.Add(new SqlParameter("@vcNome", _usuario.Nome));
                        }
                        if (_usuario.RG != 0)
                        {
                            param.Add(new SqlParameter("@nmRG", _usuario.RG));
                        }
                        param.Add(new SqlParameter("@btStatus", _usuario.Status));


                    }

                    // Obtém dados de retorno.
                    using (dr = con.ReturnDataReader("uspPessoaFisica", param))
                    {
                        // Para cada registro é criado um objeto clsPessoaFisicaBLO.
                        while (dr.Read())
                        {

                            clsPessoaFisicaBLO _usuarioFind = new clsPessoaFisicaBLO();
                            _usuarioFind.Id = double.Parse(dr["IdUsuario"].ToString());
                            _usuarioFind.Nome = string.IsNullOrEmpty(dr["vcNome"].ToString()) ? string.Empty : dr["vcNome"].ToString();
                            _usuarioFind.Status = (bool)dr["btStatus"];
                            _usuarioFind.IdTipoUser = int.Parse(dr["IdTipoUser"].ToString());
                            _usuarioFind.IdEmpresa = double.Parse(dr["IdEmpresa"].ToString());
                            retorno.Add(_usuarioFind);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("clsClienteDAO.Find", ex);
            }

            return retorno;
        }
        public List<clsPessoaFisicaBLO> FindFuncionario(clsPessoaFisicaBLO _usuario)
        {
            // Inicializa o objeto de retorno.
            List<clsPessoaFisicaBLO> retorno = new List<clsPessoaFisicaBLO>();
            // DataReader de retorno.
            SqlDataReader dr = null;

            try
            {
                using (clsConexaoDAO con = new clsConexaoDAO(ConfigurationManager.ConnectionStrings["Alpha"].ConnectionString))
                {

                    // Cria lista de parâmetros.
                    List<SqlParameter> param = new List<SqlParameter>();

                    param.Add(new SqlParameter("@OperationType", 6));

                    // Verifica quais parâmetros serão utilizados.
                    if (_usuario != null)
                    {

                        // Verifica se o Nome do Cliente é parâmetro para pesquisa.
                        if (_usuario.Id != 0)
                        {
                            param.Add(new SqlParameter("@IdUsuario", _usuario.Id));
                        }
                        if (_usuario.IdEmpresa != 0)
                        {
                            param.Add(new SqlParameter("@IdEmpresa", _usuario.IdEmpresa));
                        }
                        if (_usuario.IdTipoUser != 0)
                        {
                            param.Add(new SqlParameter("@IdTipoUser", _usuario.IdTipoUser));
                        }
                        if (_usuario.IdCargo != 0)
                        {
                            param.Add(new SqlParameter("@IdCargo", _usuario.IdCargo));
                        }
                        if (_usuario.IdDepartamento != 0)
                        {
                            param.Add(new SqlParameter("@IdDepartamento", _usuario.IdDepartamento));
                        }
                        if (!string.IsNullOrEmpty(_usuario.Nome))
                        {
                            param.Add(new SqlParameter("@vcNome", _usuario.Nome));
                        }
                        if (_usuario.RG != 0)
                        {
                            param.Add(new SqlParameter("@nmRG", _usuario.RG));
                        }
                        param.Add(new SqlParameter("@btStatus", _usuario.Status));


                    }

                    // Obtém dados de retorno.
                    using (dr = con.ReturnDataReader("uspPessoaFisica", param))
                    {
                        // Para cada registro é criado um objeto clsPessoaFisicaBLO.
                        while (dr.Read())
                        {

                            clsPessoaFisicaBLO _usuarioFind = new clsPessoaFisicaBLO();
                            _usuarioFind.Id = double.Parse(dr["IdUsuario"].ToString());
                            _usuarioFind.Nome = string.IsNullOrEmpty(dr["vcNome"].ToString()) ? string.Empty : dr["vcNome"].ToString();
                            _usuarioFind.Status = (bool)dr["btStatus"];
                            _usuarioFind.IdTipoUser = int.Parse(dr["IdTipoUser"].ToString());
                            _usuarioFind.IdEmpresa = double.Parse(dr["IdEmpresa"].ToString());
                            retorno.Add(_usuarioFind);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("clsClienteDAO.Find", ex);
            }

            return retorno;
        }
    }
}
