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
    public class clsGerenciamentoSupervisorDAO
    {
        public bool Insert(clsGerenciamentoSupervisorBLO _gerenciamento)
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
                    new SqlParameter("@IdEmpresa", _gerenciamento.IdEmpresa),
                    new SqlParameter("@IdUsuario", _gerenciamento.IdFuncionario),
                    new SqlParameter("@IdSupervisor", _gerenciamento.IdSupervisor),
                };
                    con.executeQuery("uspGerenciamentoSupervisor", listParameter);
                    _retDaBusca = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("clsGerenciamentoDAO.Insert", ex);
            }

            return _retDaBusca;
        }
        public bool Update(clsGerenciamentoSupervisorBLO _gerenciamento)
        {
            bool _ret = false;
            try
            {
                // Cria conexão.

                using (clsConexaoDAO con = new clsConexaoDAO(ConfigurationManager.ConnectionStrings["Alpha"].ConnectionString))
                {
                    List<SqlParameter> listParameter = new List<SqlParameter>() {
                    new SqlParameter("@OperationType",2),
                    new SqlParameter("@IdGerenciamento", _gerenciamento.Id),
                    new SqlParameter("@IdEmpresa", _gerenciamento.IdEmpresa),
                    new SqlParameter("@IdUsuario", _gerenciamento.IdFuncionario),
                    new SqlParameter("@IdSupervisor", _gerenciamento.IdSupervisor),
                };
                    con.executeQuery("uspGerenciamentoSupervisor", listParameter);
                    _ret = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("clsGerenciamentoDAO.Insert", ex);

            }

            return _ret;
        }
        public bool Delete(clsGerenciamentoSupervisorBLO _gerenciamento)
        {
            bool _ret = false;
            try
            {
                // Cria conexão.

                using (clsConexaoDAO con = new clsConexaoDAO(ConfigurationManager.ConnectionStrings["Alpha"].ConnectionString))
                {
                    List<SqlParameter> listParameter = new List<SqlParameter>() {
                    new SqlParameter("@OperationType",3),
                    new SqlParameter("@IdGerenciamento", _gerenciamento.Id),
                    new SqlParameter("@IdEmpresa", _gerenciamento.IdEmpresa),
                };
                    con.executeQuery("uspGerenciamentoSupervisor", listParameter);
                    _ret = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("clsGerenciamentoDAO.Insert", ex);

            }

            return _ret;
        }
        /// <summary>
        /// Metodo de busca principal(FindOne,FindAll passam por ele).
        /// Busca feita pelo por quase todos os parametros       
        /// </summary>
        /// <param name="FindOne"></param>
        /// <returns></returns>
        public List<clsGerenciamentoSupervisorBLO> Find(clsGerenciamentoSupervisorBLO _gerenciamento)
        {
            // Inicializa o objeto de retorno.
            List<clsGerenciamentoSupervisorBLO> retorno = new List<clsGerenciamentoSupervisorBLO>();
            // DataReader de retorno.
            SqlDataReader dr = null;

            try
            {
                using (clsConexaoDAO con = new clsConexaoDAO(ConfigurationManager.ConnectionStrings["Alpha"].ConnectionString))
                {

                    // Cria lista de parâmetros.
                    List<SqlParameter> param = new List<SqlParameter>();



                    param.Add(new SqlParameter("@OperationType", 4));

                    // Verifica se o Nome do Cliente é parâmetro para pesquisa.
                    if (_gerenciamento.Id != 0)
                    {
                        param.Add(new SqlParameter("@IdGerenciamento", _gerenciamento.Id));
                    }
                    if (_gerenciamento.IdEmpresa != 0)
                    {
                        param.Add(new SqlParameter("@IdEmpresa", _gerenciamento.IdEmpresa));
                    }
                    if (_gerenciamento.IdFuncionario != 0)
                    {
                        param.Add(new SqlParameter("@IdUsuario", _gerenciamento.IdFuncionario));
                    }
                    if (_gerenciamento.IdSupervisor != 0)
                    {
                        param.Add(new SqlParameter("@IdSupervisor", _gerenciamento.IdSupervisor));
                    }
                    if (!string.IsNullOrEmpty(_gerenciamento.Funcionario))
                    {
                        param.Add(new SqlParameter("@vcUsuario", _gerenciamento.Funcionario));
                    }
                    if (!string.IsNullOrEmpty(_gerenciamento.Supervisor))
                    {
                        param.Add(new SqlParameter("@vcSupervisor", _gerenciamento.Supervisor));
                    }

                    // Obtém dados de retorno.
                    using (dr = con.ReturnDataReader("uspGerenciamentoSupervisor", param))
                    {
                        // Para cada registro é criado um objeto clsGerenciamentoSupervisorBLO.
                        while (dr.Read())
                        {

                            clsGerenciamentoSupervisorBLO _gerenciamentoFind = new clsGerenciamentoSupervisorBLO();

                            _gerenciamentoFind.Id = double.Parse(dr["IdGerenciamento"].ToString());
                            _gerenciamentoFind.IdEmpresa = double.Parse(dr["IdEmpresa"].ToString());
                            _gerenciamentoFind.IdFuncionario = double.Parse(dr["IdUsuario"].ToString());
                            _gerenciamentoFind.Funcionario = string.IsNullOrEmpty(dr["vcUsuario"].ToString()) ? string.Empty : dr["vcUsuario"].ToString();
                            _gerenciamentoFind.IdSupervisor = double.Parse(dr["IdSupervisor"].ToString());
                            _gerenciamentoFind.Supervisor = string.IsNullOrEmpty(dr["vcSupervisor"].ToString()) ? string.Empty : dr["vcSupervisor"].ToString();
                            retorno.Add(_gerenciamentoFind);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("clsGerenciamentoDAO.Find", ex);
            }

            return retorno;
        }
    }
}
