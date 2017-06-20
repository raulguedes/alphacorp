
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
    public class clsEmpresaDAO
    {
        public bool Insert(clsEmpresaBLO _empresa)
        {
            bool _retDaBusca = false;
            try
            {
                // Cria conexão.
                using (clsConexaoDAO con = new clsConexaoDAO(ConfigurationManager.ConnectionStrings["Alpha"].ConnectionString))
                {
                    //Cria lista de parametros.
                    List<SqlParameter> listParameter = new List<SqlParameter>() {
                    new SqlParameter("@OperationType", 1),     /* 1: Insert */
                    new SqlParameter("@vcNome", _empresa.Nome),
                    new SqlParameter("@vcEmail", _empresa.Email),
                    new SqlParameter("@vcSenha", _empresa.Senha),
                    new SqlParameter("@btStatus", _empresa.Status),
                    new SqlParameter("@btEmpresa",_empresa.Empresa),
                    new SqlParameter("@IdTipoUser",_empresa.IdTipoUser),

                };
                    con.executeQuery("uspEmpresa", listParameter);
                    _retDaBusca = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("clsEmpresaDAO.Insert", ex);
            }

            return _retDaBusca;
        }

        public bool Update(clsEmpresaBLO _empresa)
        {
            bool _ret = false;
            try
            {
                // Cria conexão.

                using (clsConexaoDAO con = new clsConexaoDAO(ConfigurationManager.ConnectionStrings["Alpha"].ConnectionString))
                {
                    List<SqlParameter> listParameter = new List<SqlParameter>() {
                    new SqlParameter("@OperationType",2),     /* 1: Insert */
                    new SqlParameter("@IdUsuario", _empresa.Id),
                    new SqlParameter("@IdEmpresa", _empresa.Id),
                    new SqlParameter("@vcNome", _empresa.Nome),
                    new SqlParameter("@vcEmail", _empresa.Email),
                    new SqlParameter("@vcSenha", _empresa.Senha),
                    new SqlParameter("@btStatus", _empresa.Status),
                    new SqlParameter("@btEmpresa", _empresa.Empresa),
                    new SqlParameter("@IdEndereco", _empresa.IdEndereco),

                    new SqlParameter("@nmCNPJ", _empresa.CNPJ),
                    new SqlParameter("@nmTelefone", _empresa.Telefone),

                    new SqlParameter("@vcEndereco", _empresa.Endereco),
                    new SqlParameter("@nmCEP", _empresa.CEP),
                    new SqlParameter("@nmNumeroEndereco", _empresa.NumeroEndereco),
                    new SqlParameter("@vcComplementoEndereco", _empresa.ComplementoEndereco),
                    new SqlParameter("@vcBairro", _empresa.Bairro),
                    new SqlParameter("@vcUF", _empresa.UF),
                    new SqlParameter("@vcCidade", _empresa.Cidade),

                };
                    con.executeQuery("uspEmpresa", listParameter);
                    _ret = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("clsUsuarioDAO.Insert", ex);

            }

            return _ret;
        }

        public bool Delete(clsEmpresaBLO _usuario)
        {
            bool _ret = false;
            try
            {
                // Cria conexão.

                using (clsConexaoDAO con = new clsConexaoDAO(ConfigurationManager.ConnectionStrings["Alpha"].ConnectionString))
                {
                    List<SqlParameter> listParameter = new List<SqlParameter>() {
                    new SqlParameter("@OperationType", 3),     /* 2: Update */
                    new SqlParameter("@IdEmpresa", _usuario.Id),
                    new SqlParameter("@btStatus", _usuario.Status),
                };
                    con.executeQuery("uspUsuario", listParameter);
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
        /// <param name="Find"></param>
        /// <returns></returns>

        public List<clsEmpresaBLO> Find(clsEmpresaBLO _empresa)
        {
            // Inicializa o objeto de retorno.
            List<clsEmpresaBLO> retorno = new List<clsEmpresaBLO>();
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
                    if (_empresa != null)
                    {

                        // Verifica se o Nome do Cliente é parâmetro para pesquisa.
                        if (_empresa.Id != 0)
                        {
                            param.Add(new SqlParameter("@IdUsuario", _empresa.Id));
                        }

                        if (!string.IsNullOrEmpty(_empresa.Nome))
                        {
                            param.Add(new SqlParameter("@vcNome", _empresa.Nome));
                        }
                        if (_empresa.Empresa)
                        {
                            param.Add(new SqlParameter("@btEmpresa", _empresa.Empresa));
                        }
                        if (_empresa.Status)
                        {
                            param.Add(new SqlParameter("@btStatus", _empresa.Status));
                        }
                    }
                    // Obtém dados de retorno.
                    using (dr = con.ReturnDataReader("uspEmpresa", param))
                    {
                        // Para cada registro é criado um objeto clsEmpresaBLO.
                        while (dr.Read())
                        {

                            clsEmpresaBLO _empresaFind = new clsEmpresaBLO();

                            _empresaFind.Id = double.Parse(dr["IdUsuario"].ToString());                            
                            _empresaFind.Nome = string.IsNullOrEmpty(dr["vcNome"].ToString()) ? string.Empty : dr["vcNome"].ToString();
                            _empresaFind.Senha = string.IsNullOrEmpty(dr["vcSenha"].ToString()) ? string.Empty : dr["vcSenha"].ToString();
                            _empresaFind.CNPJ = double.Parse(dr["nmCNPJ"].ToString());
                            _empresaFind.Email = string.IsNullOrEmpty(dr["vcEmail"].ToString()) ? string.Empty : dr["vcEmail"].ToString();
                            _empresaFind.Telefone = double.Parse((dr["nmTelefone"]).ToString());
                            _empresaFind.IdTipoUser = int.Parse(dr["IdTipoUser"].ToString());
                            _empresaFind.Empresa = (bool)(dr["btEmpresa"]);
                            _empresaFind.CEP = int.Parse(dr["nmCEP"].ToString());
                            _empresaFind.IdEndereco = int.Parse(dr["IdEndereco"].ToString());
                            _empresaFind.Endereco = string.IsNullOrEmpty(dr["vcEndereco"].ToString()) ? string.Empty : dr["vcEndereco"].ToString();
                            _empresaFind.NumeroEndereco = int.Parse(dr["nmNumeroEndereco"].ToString());
                            _empresaFind.ComplementoEndereco = string.IsNullOrEmpty(dr["vcComplementoEndereco"].ToString()) ? string.Empty : dr["vcComplementoEndereco"].ToString();
                            _empresaFind.Bairro = string.IsNullOrEmpty(dr["vcBairro"].ToString()) ? string.Empty : dr["vcBairro"].ToString();
                            _empresaFind.UF = string.IsNullOrEmpty(dr["vcUF"].ToString()) ? string.Empty : dr["vcUF"].ToString();
                            _empresaFind.Cidade = string.IsNullOrEmpty(dr["vcCidade"].ToString()) ? string.Empty : dr["vcCidade"].ToString();
                            _empresaFind.Status = (bool)dr["btStatus"];
                            retorno.Add(_empresaFind);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("clsEmpresaDAO.Find", ex);
            }

            return retorno;
        }

        /// <summary>
        /// Retorna uma lista.
        /// Esse metodo faz a busca pelo metodo Find.
        /// </summary>
        /// <returns></returns>
        public List<clsEmpresaBLO> FindAll()
        {
            try
            {
                //Executa a pesquisa sem parâmetros.
                return this.Find(null);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}