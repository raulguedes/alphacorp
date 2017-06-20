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
    public class clsClienteDAO
    {
        public bool Insert(clsClienteBLO _cliente)
        {
            bool _ret = false;
            try
            {
                // Cria conexão.

                using (clsConexaoDAO con = new clsConexaoDAO(ConfigurationManager.ConnectionStrings["Alpha"].ConnectionString))
                {
                    List<SqlParameter> listParameter = new List<SqlParameter>() {
                    new SqlParameter("@OperationType", 1),     /* 1: Insert */
                    new SqlParameter("@vcNome", _cliente.Nome),
                    new SqlParameter("@vcEmail", _cliente.Email),
                    new SqlParameter("@nmTelefone", _cliente.Telefone),
                    new SqlParameter("@IdEmpresa", _cliente.IdEmpresa),
                };
                    con.executeQuery("uspCliente", listParameter);

                    _ret = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("clsClienteDAO.Insert", ex);

            }

            return _ret;
        }
        public bool Update(clsClienteBLO _cliente)
        {
            bool _ret = false;
            try
            {
                // Cria conexão.

                using (clsConexaoDAO con = new clsConexaoDAO(ConfigurationManager.ConnectionStrings["Alpha"].ConnectionString))
                {
                    List<SqlParameter> listParameter = new List<SqlParameter>() {
                    new SqlParameter("@OperationType", 2),     /* 1: Insert */
                    new SqlParameter("@IdCliente", _cliente.Id),
                    new SqlParameter("@vcNome", _cliente.Nome),
                    new SqlParameter("@vcEmail", _cliente.Email),
                    new SqlParameter("@nmTelefone", _cliente.Telefone),
                    new SqlParameter("@IdEmpresa", _cliente.IdEmpresa),
                };
                    con.executeQuery("uspCliente", listParameter);

                    _ret = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("clsClienteDAO.Insert", ex);

            }

            return _ret;
        }
        public bool Delete(clsClienteBLO _cliente)
        {
            bool _ret = false;
            try
            {
                // Cria conexão.

                using (clsConexaoDAO con = new clsConexaoDAO(ConfigurationManager.ConnectionStrings["Alpha"].ConnectionString))
                {
                    List<SqlParameter> listParameter = new List<SqlParameter>() {
                    new SqlParameter("@OperationType", 3),     /* 1: Insert */
                    new SqlParameter("@IdCliente", _cliente.Id),
                    new SqlParameter("@IdEmpresa", _cliente.IdEmpresa),
                };
                    con.executeQuery("uspCliente", listParameter);

                    _ret = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("clsClienteDAO.Insert", ex);

            }

            return _ret;
        }
        /// <summary>
        /// Metodo de busca principal(FindOne,FindAll passam por ele).
        /// Busca feita pelo por quase todos os parametros       
        /// </summary>
        /// <param name="FindOne"></param>
        /// <returns></returns>
        public List<clsClienteBLO> Find(clsClienteBLO _cliente)
        {
            // Inicializa o objeto de retorno.
            List<clsClienteBLO> retorno = new List<clsClienteBLO>();
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
                        if (_cliente.Id != 0)
                        {
                            param.Add(new SqlParameter("@IdCliente", _cliente.Id));
                        }
                        if (_cliente.IdEmpresa != 0)
                        {
                            param.Add(new SqlParameter("@IdEmpresa", _cliente.IdEmpresa));
                        }
                        if (!string.IsNullOrEmpty(_cliente.Nome))
                        {
                            param.Add(new SqlParameter("@vcNome", _cliente.Nome));
                        }
                        if (_cliente.Telefone != 0)
                        {
                            param.Add(new SqlParameter("@nmTelefone", _cliente.Telefone));
                        }                    

                    // Obtém dados de retorno.
                    using (dr = con.ReturnDataReader("uspCliente", param))
                    {
                        // Para cada registro é criado um objeto clsClienteBLO.
                        while (dr.Read())
                        {

                            clsClienteBLO _Cliente = new clsClienteBLO();

                            _Cliente.Id = double.Parse(dr["IdCliente"].ToString());
                            _Cliente.IdEmpresa = double.Parse(dr["IdEmpresa"].ToString());
                            _Cliente.Nome = string.IsNullOrEmpty(dr["vcNome"].ToString()) ? string.Empty : dr["vcNome"].ToString();
                            _Cliente.Email = string.IsNullOrEmpty(dr["vcEmail"].ToString()) ? string.Empty : dr["vcEmail"].ToString();
                            _Cliente.Telefone = double.Parse(dr["nmTelefone"].ToString());
                            retorno.Add(_Cliente);
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
        /// <summary>
        /// Retorna uma lista.
        /// Esse metodo faz a busca pelo metodo Find.
        /// </summary>
        /// <returns></returns>
        public List<clsClienteBLO> FindAll()
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
