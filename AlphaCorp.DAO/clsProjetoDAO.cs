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
    public class clsProjetoDAO
    {
        public bool Insert(clsProjetoBLO _Projeto)
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
                    new SqlParameter("@vcNome", _Projeto.Nome),
                    new SqlParameter("@IdStatus", _Projeto.IdStatus),
                    new SqlParameter("@IdCliente", _Projeto.IdCliente),
                    new SqlParameter("@IdResponsavel", _Projeto.IdResponsavel),
                    new SqlParameter("@IdEmpresa", _Projeto.IdEmpresa),
                    new SqlParameter("@IdDepartamento", _Projeto.IdDepartamento),
                };
                    con.executeQuery("uspProjeto", listParameter);
                    _retDaBusca = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("clsProjetoDAO.Insert", ex);
            }

            return _retDaBusca;
        }
        public bool Update(clsProjetoBLO _Projeto)
        {
            bool _ret = false;
            try
            {
                // Cria conexão.

                using (clsConexaoDAO con = new clsConexaoDAO(ConfigurationManager.ConnectionStrings["Alpha"].ConnectionString))
                {
                    List<SqlParameter> listParameter = new List<SqlParameter>() {
                    new SqlParameter("@OperationType",2),
                    new SqlParameter("@IdProjeto", _Projeto.Id),
                    new SqlParameter("@vcNome", _Projeto.Nome),
                    new SqlParameter("@IdStatus", _Projeto.IdStatus),
                    new SqlParameter("@IdCliente", _Projeto.IdCliente),
                    new SqlParameter("@IdResponsavel", _Projeto.IdResponsavel),
                    new SqlParameter("@IdEmpresa", _Projeto.IdEmpresa),
                    new SqlParameter("@IdDepartamento", _Projeto.IdDepartamento),
                };
                    con.executeQuery("uspProjeto", listParameter);
                    _ret = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("clsProjetoDAO.Insert", ex);
            }

            return _ret;
        }
        public bool Delete(clsProjetoBLO _Projeto)
        {
            bool _ret = false;
            try
            {
                // Cria conexão.

                using (clsConexaoDAO con = new clsConexaoDAO(ConfigurationManager.ConnectionStrings["Alpha"].ConnectionString))
                {
                    List<SqlParameter> listParameter = new List<SqlParameter>() {
                    new SqlParameter("@OperationType",3),
                    new SqlParameter("@IdProjeto", _Projeto.Id),
                    new SqlParameter("@IdEmpresa", _Projeto.IdEmpresa),
                };
                    con.executeQuery("uspProjeto", listParameter);
                    _ret = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("clsProjetoDAO.Insert", ex);

            }

            return _ret;
        }
        /// <summary>
        /// Metodo de busca principal(FindOne,FindAll passam por ele).
        /// Busca feita pelo por quase todos os parametros       
        /// </summary>
        /// <param name="FindOne"></param>
        /// <returns></returns>
        public List<clsProjetoBLO> Find(clsProjetoBLO _Projeto)
        {
            // Inicializa o objeto de retorno.
            List<clsProjetoBLO> retorno = new List<clsProjetoBLO>();
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
                    if (_Projeto.Id != 0)
                    {
                        param.Add(new SqlParameter("@IdProjeto", _Projeto.Id));
                    }
                    if (_Projeto.IdEmpresa != 0)
                    {
                        param.Add(new SqlParameter("@IdEmpresa", _Projeto.IdEmpresa));
                    }
                    if (_Projeto.IdDepartamento != 0)
                    {
                        param.Add(new SqlParameter("@IdDepartamento", _Projeto.IdDepartamento));
                    }
                    if (_Projeto.IdCliente != 0)
                    {
                        param.Add(new SqlParameter("@IdCliente", _Projeto.IdCliente));
                    }
                    if (!string.IsNullOrEmpty(_Projeto.Nome))
                    {
                        param.Add(new SqlParameter("@vcNome", _Projeto.Nome));
                    }
                    if (_Projeto.IdStatus != 0)
                    {
                        param.Add(new SqlParameter("@IdStatus", _Projeto.IdStatus));
                    }
                    // Obtém dados de retorno.
                    using (dr = con.ReturnDataReader("uspProjeto", param))
                    {
                        // Para cada registro é criado um objeto clsProjetoBLO.
                        while (dr.Read())
                        {

                            clsProjetoBLO _ProjetoFind = new clsProjetoBLO();

                            _ProjetoFind.Id = double.Parse(dr["IdProjeto"].ToString());
                            _ProjetoFind.IdStatus = (int)dr["IdStatus"];
                            _ProjetoFind.Nome = string.IsNullOrEmpty(dr["vcNome"].ToString()) ? string.Empty : dr["vcNome"].ToString();
                            _ProjetoFind.IdEmpresa = double.Parse(dr["IdEmpresa"].ToString());
                            _ProjetoFind.IdCliente = double.Parse(dr["IdCliente"].ToString());
                            _ProjetoFind.Cliente = string.IsNullOrEmpty(dr["vcCliente"].ToString()) ? string.Empty : dr["vcCliente"].ToString();
                            _ProjetoFind.IdDepartamento = double.Parse(dr["IdDepartamento"].ToString());
                            _ProjetoFind.Departamento = string.IsNullOrEmpty(dr["vcDepartamento"].ToString()) ? string.Empty : dr["vcDepartamento"].ToString();
                            _ProjetoFind.IdResponsavel = double.Parse(dr["IdResponsavel"].ToString());
                            _ProjetoFind.Responsavel = string.IsNullOrEmpty(dr["vcResponsavel"].ToString()) ? string.Empty : dr["vcResponsavel"].ToString();
                            _ProjetoFind.Status = string.IsNullOrEmpty(dr["vcStatus"].ToString()) ? string.Empty : dr["vcStatus"].ToString();
                            retorno.Add(_ProjetoFind);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("clsProjetoDAO.Find", ex);
            }

            return retorno;
        }
    }
}
