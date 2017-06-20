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
    public class clsMembroEventoDAO
    {
        public bool Insert(clsMembroEventoBLO _membroEvento)
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
                    new SqlParameter("@IdEvento", _membroEvento.IdEvento),
                    new SqlParameter("@IdTipoUser", _membroEvento.IdTipoUsuario),
                    new SqlParameter("@IdEmpresa", _membroEvento.IdEmpresa),
                    new SqlParameter("@IdUsuario", _membroEvento.IdUsuario),
                };
                    con.executeQuery("uspMembroEvento", listParameter);
                    _retDaBusca = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("clsMembroEventoDAO.Insert", ex);
            }

            return _retDaBusca;
        }
        public bool Update(clsMembroEventoBLO _membroEvento)
        {
            bool _ret = false;
            try
            {
                // Cria conexão.

                using (clsConexaoDAO con = new clsConexaoDAO(ConfigurationManager.ConnectionStrings["Alpha"].ConnectionString))
                {
                    List<SqlParameter> listParameter = new List<SqlParameter>() {
                    new SqlParameter("@OperationType",2),
                    new SqlParameter("@IdMembroUsuario", _membroEvento.IdMembroUsuario),
                    new SqlParameter("@IdEvento", _membroEvento.IdEvento),
                    new SqlParameter("@IdTipoUser", _membroEvento.IdTipoUsuario),
                    new SqlParameter("@IdEmpresa", _membroEvento.IdEmpresa),
                    new SqlParameter("@IdUsuario", _membroEvento.IdUsuario),
                };
                    con.executeQuery("uspMembroEvento", listParameter);
                    _ret = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("clsMembroEventoDAO.Insert", ex);

            }

            return _ret;
        }
        public bool Delete(clsMembroEventoBLO _membroEvento)
        {
            bool _ret = false;
            try
            {
                // Cria conexão.

                using (clsConexaoDAO con = new clsConexaoDAO(ConfigurationManager.ConnectionStrings["Alpha"].ConnectionString))
                {
                    List<SqlParameter> listParameter = new List<SqlParameter>() {
                    new SqlParameter("@OperationType",3),
                    new SqlParameter("@IdMembroEvento", _membroEvento.IdMembroUsuario),
                    new SqlParameter("@IdEvento", _membroEvento.IdEvento),
                    new SqlParameter("@IdEmpresa", _membroEvento.IdEmpresa),
                    new SqlParameter("@IdUsuario", _membroEvento.IdUsuario),
                };
                    con.executeQuery("uspMembroEvento", listParameter);
                    _ret = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("clsMembroEventoDAO.Insert", ex);

            }

            return _ret;
        }
        /// <summary>
        /// Metodo de busca principal(FindOne,FindAll passam por ele).
        /// Busca feita pelo por quase todos os parametros       
        /// </summary>
        /// <param name="FindOne"></param>
        /// <returns></returns>
        public List<clsMembroEventoBLO> Find(clsMembroEventoBLO _membroEvento)
        {
            // Inicializa o objeto de retorno.
            List<clsMembroEventoBLO> retorno = new List<clsMembroEventoBLO>();
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
                    if (_membroEvento != null)
                    {
                        // Verifica se o Nome do Cliente é parâmetro para pesquisa.
                        if (_membroEvento.IdMembroUsuario != 0)
                        {
                            param.Add(new SqlParameter("@IdMembroEvento", _membroEvento.IdMembroUsuario));
                        }
                        if (_membroEvento.IdEmpresa != 0)
                        {
                            param.Add(new SqlParameter("@IdEmpresa", _membroEvento.IdEmpresa));
                        }
                        if (_membroEvento.IdEvento != 0)
                        {
                            param.Add(new SqlParameter("@IdEvento", _membroEvento.IdEvento));
                        }
                        if (_membroEvento.IdUsuario != 0)
                        {
                            param.Add(new SqlParameter("@IdUsuario", _membroEvento.IdUsuario));
                        }
                        if (_membroEvento.IdTipoUsuario != 0)
                        {
                            param.Add(new SqlParameter("@IdTipoUsuario", _membroEvento.IdTipoUsuario));
                        }
                    }

                    // Obtém dados de retorno.
                    using (dr = con.ReturnDataReader("uspEvento", param))
                    {
                        // Para cada registro é criado um objeto clsMembroEventoBLO.
                        while (dr.Read())
                        {

                            clsMembroEventoBLO _membroEventoFind = new clsMembroEventoBLO();                            

                            //D.vcNome as "vcDepartamento",
                            //CA.vcNome as "vcCargo"
                            _membroEventoFind.Id = double.Parse(dr["IdMembroEvento"].ToString());
                            _membroEventoFind.IdEvento = double.Parse(dr["IdEvento"].ToString());                            
                            _membroEventoFind.IdMembroEvento = double.Parse(dr["IdMembroEvento"].ToString());                            
                            _membroEventoFind.NomeMembro = string.IsNullOrEmpty(dr["vcNomeMembro"].ToString()) ? string.Empty : dr["vcNomeMembro"].ToString();
                            _membroEventoFind.IdEmpresa = double.Parse(dr["IdEmpresa"].ToString());
                            _membroEventoFind.Confirmar = int.Parse(dr["IdConfirmar"].ToString());
                            _membroEventoFind.IdTipoUsuario = int.Parse(dr["IdTipoUsuario"].ToString());
                            _membroEventoFind.Departamento = string.IsNullOrEmpty(dr["vcDepartamento"].ToString()) ? string.Empty : dr["vcDepartamento"].ToString();
                            _membroEventoFind.Cargo = string.IsNullOrEmpty(dr["vcCargo"].ToString()) ? string.Empty : dr["vcCargo"].ToString();
                            retorno.Add(_membroEventoFind);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("clsMembroEventoDAO.Find", ex);
            }

            return retorno;
        }
        /// <summary>
        /// Retorna uma lista.
        /// Esse metodo faz a busca pelo metodo Find.
        /// </summary>
        /// <returns></returns>
        public List<clsMembroEventoBLO> FindAll()
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
