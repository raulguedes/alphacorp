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
    public class clsDepartamentoDAO
    {
        public bool Insert(clsDepartamentoBLO _departamento)
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
                    new SqlParameter("@vcNome", _departamento.Nome),
                    new SqlParameter("@IdEmpresa", _departamento.IdEmpresa),
                };
                    con.executeQuery("uspDepartamento", listParameter);
                    _retDaBusca = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("clsDepartamentoDAO.Insert", ex);
            }

            return _retDaBusca;
        }
        public bool Update(clsDepartamentoBLO _departamento)
        {
            bool _ret = false;
            try
            {
                // Cria conexão.

                using (clsConexaoDAO con = new clsConexaoDAO(ConfigurationManager.ConnectionStrings["Alpha"].ConnectionString))
                {
                    List<SqlParameter> listParameter = new List<SqlParameter>() {
                    new SqlParameter("@OperationType",2),
                    new SqlParameter("@IdDepartamento", _departamento.Id),
                    new SqlParameter("@vcNome", _departamento.Nome),
                    new SqlParameter("@IdEmpresa", _departamento.IdEmpresa),
                };
                    con.executeQuery("uspDepartamento", listParameter);
                    _ret = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("clsDepartamentoDAO.Insert", ex);

            }

            return _ret;
        }
        public bool Delete(clsDepartamentoBLO _departamento)
        {
            bool _ret = false;
            try
            {
                // Cria conexão.

                using (clsConexaoDAO con = new clsConexaoDAO(ConfigurationManager.ConnectionStrings["Alpha"].ConnectionString))
                {
                    List<SqlParameter> listParameter = new List<SqlParameter>() {
                    new SqlParameter("@OperationType",3),
                    new SqlParameter("@IdDepartamento", _departamento.Id),
                    new SqlParameter("@IdEmpresa", _departamento.IdEmpresa),
                };
                    con.executeQuery("uspDepartamento", listParameter);
                    _ret = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("clsDepartamentoDAO.Insert", ex);

            }

            return _ret;
        }
        /// <summary>
        /// Metodo de busca principal(FindOne,FindAll passam por ele).
        /// Busca feita pelo por quase todos os parametros       
        /// </summary>
        /// <param name="FindOne"></param>
        /// <returns></returns>
        public List<clsDepartamentoBLO> Find(clsDepartamentoBLO _departamento)
        {
            // Inicializa o objeto de retorno.
            List<clsDepartamentoBLO> retorno = new List<clsDepartamentoBLO>();
            // DataReader de retorno.
            SqlDataReader dr = null;

            try
            {
                using (clsConexaoDAO con = new clsConexaoDAO(ConfigurationManager.ConnectionStrings["Alpha"].ConnectionString))
                {

                    // Cria lista de parâmetros.
                    List<SqlParameter> param = new List<SqlParameter>();

                    param.Add(new SqlParameter("@OperationType", 4));
                    if (_departamento.Id != 0)
                    {
                        param.Add(new SqlParameter("@IdDepartamento", _departamento.Id));
                    }
                    if (_departamento.IdEmpresa != 0)
                    {
                        param.Add(new SqlParameter("@IdEmpresa", _departamento.IdEmpresa));
                    }

                    if (!string.IsNullOrEmpty(_departamento.Nome))
                    {
                        param.Add(new SqlParameter("@vcNome", _departamento.Nome));
                    }

                    // Obtém dados de retorno.
                    using (dr = con.ReturnDataReader("uspDepartamento", param))
                    {
                        // Para cada registro é criado um objeto clsDepartamentoBLO.
                        while (dr.Read())
                        {
                            clsDepartamentoBLO _departamentoFind = new clsDepartamentoBLO();
                            _departamentoFind.Id = double.Parse(dr["IdDepartamento"].ToString());
                            _departamentoFind.Nome = string.IsNullOrEmpty(dr["vcNome"].ToString()) ? string.Empty : dr["vcNome"].ToString();
                            _departamentoFind.IdEmpresa = double.Parse(dr["IdEmpresa"].ToString());
                            retorno.Add(_departamentoFind);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("clsDepartamentoDAO.Find", ex);
            }

            return retorno;
        }
        /// <summary>
        /// Retorna uma lista.
        /// Esse metodo faz a busca pelo metodo Find.
        /// </summary>
        /// <returns></returns>
        public List<clsDepartamentoBLO> FindAll()
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
