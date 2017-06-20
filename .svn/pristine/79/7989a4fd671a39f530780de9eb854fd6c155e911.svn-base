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
    public class clsCargoDAO
    {
        public bool Insert(clsCargoBLO _cargo)
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
                    new SqlParameter("@vcNome", _cargo.Nome),
                    new SqlParameter("@IdEmpresa", _cargo.IdEmpresa),
                    new SqlParameter("@IdDepartamento", _cargo.IdDepartamento),
                };
                    con.executeQuery("uspCargo", listParameter);
                    _retDaBusca = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("clsCargoDAO.Insert", ex);
            }

            return _retDaBusca;
        }
        public bool Update(clsCargoBLO _cargo)
        {
            bool _ret = false;
            try
            {
                // Cria conexão.

                using (clsConexaoDAO con = new clsConexaoDAO(ConfigurationManager.ConnectionStrings["Alpha"].ConnectionString))
                {
                    List<SqlParameter> listParameter = new List<SqlParameter>() {
                    new SqlParameter("@OperationType",2),
                    new SqlParameter("@IdCargo", _cargo.Id),
                    new SqlParameter("@vcNome", _cargo.Nome),
                    new SqlParameter("@IdEmpresa", _cargo.IdEmpresa),
                    new SqlParameter("@IdDepartamento", _cargo.IdDepartamento),
                };
                    con.executeQuery("uspCargo", listParameter);
                    _ret = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("clsCargoDAO.Insert", ex);
            }

            return _ret;
        }
        public bool Delete(clsCargoBLO _cargo)
        {
            bool _ret = false;
            try
            {
                // Cria conexão.

                using (clsConexaoDAO con = new clsConexaoDAO(ConfigurationManager.ConnectionStrings["Alpha"].ConnectionString))
                {
                    List<SqlParameter> listParameter = new List<SqlParameter>() {
                    new SqlParameter("@OperationType",3),
                    new SqlParameter("@IdCargo", _cargo.Id),
                    new SqlParameter("@IdEmpresa", _cargo.IdEmpresa),
                };
                    con.executeQuery("uspCargo", listParameter);
                    _ret = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("clsCargoDAO.Insert", ex);

            }

            return _ret;
        }
        /// <summary>
        /// Metodo de busca principal(FindOne,FindAll passam por ele).
        /// Busca feita pelo por quase todos os parametros       
        /// </summary>
        /// <param name="FindOne"></param>
        /// <returns></returns>
        public List<clsCargoBLO> Find(clsCargoBLO _cargo)
        {
            // Inicializa o objeto de retorno.
            List<clsCargoBLO> retorno = new List<clsCargoBLO>();
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
                    if (_cargo.Id != 0)
                    {
                        param.Add(new SqlParameter("@IdCargo", _cargo.Id));
                    }
                    if (_cargo.IdEmpresa != 0)
                    {
                        param.Add(new SqlParameter("@IdEmpresa", _cargo.IdEmpresa));
                    }
                    if (_cargo.IdDepartamento != 0)
                    {
                        param.Add(new SqlParameter("@IdDepartamento", _cargo.IdDepartamento));
                    }
                    if (!string.IsNullOrEmpty(_cargo.Nome))
                    {
                        param.Add(new SqlParameter("@vcNome", _cargo.Nome));
                    }
                    // Obtém dados de retorno.
                    using (dr = con.ReturnDataReader("uspCargo", param))
                    {
                        // Para cada registro é criado um objeto clsCargoBLO.
                        while (dr.Read())
                        {

                            clsCargoBLO _cargoFind = new clsCargoBLO();

                            _cargoFind.Id = (int)dr["IdCargo"];
                            _cargoFind.Nome = string.IsNullOrEmpty(dr["vcNome"].ToString()) ? string.Empty : dr["vcNome"].ToString();
                            _cargoFind.IdEmpresa = (int)dr["IdEmpresa"];
                            _cargoFind.IdDepartamento = (int)dr["IdDepartamento"];
                            _cargoFind.Departamento = string.IsNullOrEmpty(dr["vcDepartamento"].ToString()) ? string.Empty : dr["vcDepartamento"].ToString();
                            retorno.Add(_cargoFind);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("clsCargoDAO.Find", ex);
            }

            return retorno;
        }

    }
}
