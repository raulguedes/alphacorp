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
    public class clsAtividadeDAO
    {
        public bool Insert(clsAtividadeBLO _atividade)
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
                    new SqlParameter("@vcNome", _atividade.Nome),                    
                    new SqlParameter("@dtDataEntrada", _atividade.DataEntrada),
                    new SqlParameter("@IdEmpresa", _atividade.IdEmpresa),
                };
                    con.executeQuery("uspAtividade", listParameter);
                    _retDaBusca = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("clsAtividadeDAO.Insert", ex);
            }

            return _retDaBusca;
        }
        public bool Update(clsAtividadeBLO _atividade)
        {
            bool _ret = false;
            try
            {
                // Cria conexão.

                using (clsConexaoDAO con = new clsConexaoDAO(ConfigurationManager.ConnectionStrings["Alpha"].ConnectionString))
                {
                    List<SqlParameter> listParameter = new List<SqlParameter>() {
                    new SqlParameter("@OperationType",2),
                    new SqlParameter("@IdAtividade", _atividade.Id),
                    new SqlParameter("@vcNome", _atividade.Nome),
                    new SqlParameter("@dtDataEntrada", _atividade.DataEntrada),
                    new SqlParameter("@IdEmpresa", _atividade.IdEmpresa),
                };
                    con.executeQuery("uspAtividade", listParameter);
                    _ret = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("clsUsuarioDAO.Insert", ex);

            }

            return _ret;
        }
        public bool Delete(clsAtividadeBLO _atividade)
        {
            bool _ret = false;
            try
            {
                // Cria conexão.

                using (clsConexaoDAO con = new clsConexaoDAO(ConfigurationManager.ConnectionStrings["Alpha"].ConnectionString))
                {
                    List<SqlParameter> listParameter = new List<SqlParameter>() {
                    new SqlParameter("@OperationType",3),
                    new SqlParameter("@IdAtividade", _atividade.Id),
                    new SqlParameter("@IdEmpresa", _atividade.IdEmpresa),
                };
                    con.executeQuery("uspAtividade", listParameter);
                    _ret = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("clsUsuarioDAO.Insert", ex);

            }

            return _ret;
        }
        /// <summary>
        /// Metodo de busca principal(FindOne,FindAll passam por ele).
        /// Busca feita pelo por quase todos os parametros       
        /// </summary>
        /// <param name="FindOne"></param>
        /// <returns></returns>

        public List<clsAtividadeBLO> Find(clsAtividadeBLO _atividade)
        {
            // Inicializa o objeto de retorno.
            List<clsAtividadeBLO> retorno = new List<clsAtividadeBLO>();
            // DataReader de retorno.
            SqlDataReader dr = null;

            try
            {
                using (clsConexaoDAO con = new clsConexaoDAO(ConfigurationManager.ConnectionStrings["Alpha"].ConnectionString))
                {

                    // Cria lista de parâmetros.
                    List<SqlParameter> param;

                    param = new List<SqlParameter>()
                    {
                        new SqlParameter("@OperationType", 4),
                    };

                    // Verifica quais parâmetros serão utilizados.
                    if (_atividade != null)
                    {
                        param = new List<SqlParameter>();
                        // Verifica se o Nome do Cliente é parâmetro para pesquisa.
                        if (_atividade.Id != 0)
                        {
                            param.Add(new SqlParameter("@IdAtividade", _atividade.Id));
                        }
                        if (_atividade.IdEmpresa != 0)
                        {
                            param.Add(new SqlParameter("@IdEmpresa", _atividade.IdEmpresa));
                        }

                        if (!string.IsNullOrEmpty(_atividade.Nome))
                        {
                            param.Add(new SqlParameter("@vcNome", _atividade.Nome));
                        }
                    }

                    // Obtém dados de retorno.
                    using (dr = con.ReturnDataReader("uspAtividade", param))
                    {
                        // Para cada registro é criado um objeto clsAtividadeBLO.
                        while (dr.Read())
                        {

                            clsAtividadeBLO _atividadeFind = new clsAtividadeBLO();

                            _atividadeFind.Id = (int)dr["IdAtividade"];                            
                            _atividadeFind.Nome = string.IsNullOrEmpty(dr["vcNome"].ToString()) ? string.Empty : dr["vcNome"].ToString();
                            _atividadeFind.DataEntrada = (DateTime)dr["dtDataEntrada"];
                            _atividadeFind.IdEmpresa = (int)dr["IdEmpresa"];
                            retorno.Add(_atividadeFind);
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
        public List<clsAtividadeBLO> FindAll()
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
