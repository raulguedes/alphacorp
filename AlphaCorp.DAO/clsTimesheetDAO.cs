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
    public class clsTimesheetDAO
    {
        public bool Insert(clsTimesheetBLO _timesheet)
        {
            bool _ret = false;
            try
            {
                // Cria conexão.

                using (clsConexaoDAO con = new clsConexaoDAO(ConfigurationManager.ConnectionStrings["Alpha"].ConnectionString))
                {
                    List<SqlParameter> listParameter = new List<SqlParameter>() {
                    new SqlParameter("@OperationType", 1),     /* 1: Insert */
                    new SqlParameter("@dtData", _timesheet.Data),
                    new SqlParameter("@dtDuracao", _timesheet.Duracao),
                    new SqlParameter("@vcDescricao", _timesheet.Descricao),
                    new SqlParameter("@dtDuracaoExtra", _timesheet.HoraExtra),
                    new SqlParameter("@IdStatus",_timesheet.IdStatus),
                    new SqlParameter("@vcDescricaoExtra",_timesheet.DescricaoExtra),
                    new SqlParameter("@dtDataEntrada", DateTime.Now),
                    new SqlParameter("@IdUsuario", _timesheet.IdFuncionario),
                    new SqlParameter("@IdSupervisor", _timesheet.IdSupervisor),
                    new SqlParameter("@IdDepartamento",_timesheet.IdDepartamento),
                    new SqlParameter("@IdEmpresa",_timesheet.IdEmpresa),
                    new SqlParameter("@IdProjeto",_timesheet.IdProjeto),
                };
                    con.executeQuery("uspTimesheet", listParameter);
                    _ret = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("clsWaitsheetDAO.Insert", ex);
            }

            return _ret;
        }
        public bool Delete(clsTimesheetBLO _timesheet)
        {
            bool _ret = false;
            try
            {
                // Cria conexão.

                using (clsConexaoDAO con = new clsConexaoDAO(ConfigurationManager.ConnectionStrings["Alpha"].ConnectionString))
                {
                    List<SqlParameter> listParameter = new List<SqlParameter>() {
                    new SqlParameter("@OperationType", 3),     /* 3: Delete */
                    new SqlParameter("@IdTimesheet", _timesheet.Id),
                    new SqlParameter("@IdEmpresa", _timesheet.IdEmpresa),
                    new SqlParameter("@IdUsuario", _timesheet.IdFuncionario),
                };
                    con.executeQuery("uspTimesheet", listParameter);
                    _ret = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("clsTimesheetDAO.Delete", ex);

            }

            return _ret;
        }
        public List<clsTimePadraoBLO> Find(clsTimePadraoBLO _timesheet)
        {
            // Inicializa o objeto de retorno.
            List<clsTimePadraoBLO> retorno = new List<clsTimePadraoBLO>();
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
                    if (_timesheet != null)
                    {

                        if (_timesheet.Id != 0)
                        {
                            param.Add(new SqlParameter("@IdTimesheet", _timesheet.Id));
                        }
                        if (_timesheet.IdFuncionario != 0)
                        {
                            param.Add(new SqlParameter("@IdUsuario", _timesheet.IdFuncionario));
                        }
                        if (_timesheet.IdSupervisor != 0)
                        {
                            param.Add(new SqlParameter("@IdSupervisor", _timesheet.IdSupervisor));
                        }
                        if (_timesheet.IdEmpresa != 0)
                        {
                            param.Add(new SqlParameter("@IdEmpresa", _timesheet.IdEmpresa));
                        }
                        if (_timesheet.Data != DateTime.MinValue)
                        {
                            param.Add(new SqlParameter("@dtData", _timesheet.Data));
                        }
                        if (_timesheet.IdDepartamento != 0)
                        {
                            param.Add(new SqlParameter("@IdDepartamento", _timesheet.IdDepartamento));
                        }
                        if (_timesheet.IdProjeto != 0)
                        {
                            param.Add(new SqlParameter("@IdProjeto", _timesheet.IdProjeto));
                        }
                    }

                    // Obtém dados de retorno.
                    using (dr = con.ReturnDataReader("uspTimesheet", param))
                    {
                        // Para cada registro é criado um objeto clsWaitsheetBLO.
                        while (dr.Read())
                        {

                            clsTimePadraoBLO _usuarioFind = new clsTimePadraoBLO();

                            _usuarioFind.Id = double.Parse(dr["IdTimesheet"].ToString());
                            _usuarioFind.Data = DateTime.Parse(dr["dtData"].ToString());
                            _usuarioFind.Duracao = TimeSpan.Parse(dr["dtDuracao"].ToString());
                            _usuarioFind.Descricao = string.IsNullOrEmpty(dr["vcDescricao"].ToString()) ? string.Empty : dr["vcDescricao"].ToString();
                            _usuarioFind.HoraExtra = TimeSpan.Parse(dr["dtDuracaoExtra"].ToString());
                            _usuarioFind.IdStatus = int.Parse(dr["IdStatus"].ToString());
                            _usuarioFind.DescricaoExtra = string.IsNullOrEmpty(dr["vcDescricaoExtra"].ToString()) ? string.Empty : dr["vcDescricaoExtra"].ToString();
                            _usuarioFind.DataEntrada = DateTime.Parse(dr["dtDataEntrada"].ToString());
                            _usuarioFind.IdDepartamento = double.Parse(dr["IdDepartamento"].ToString());
                            _usuarioFind.IdEmpresa = double.Parse(dr["IdEmpresa"].ToString());
                            _usuarioFind.IdProjeto = double.Parse(dr["IdProjeto"].ToString());
                            _usuarioFind.IdFuncionario = double.Parse(dr["IdUsuario"].ToString());
                            _usuarioFind.IdSupervisor = double.Parse(dr["IdSupervisor"].ToString());

                            _usuarioFind.Email = string.IsNullOrEmpty(dr["vcEmail"].ToString()) ? string.Empty : dr["vcEmail"].ToString();
                            _usuarioFind.NomeSupervisor = string.IsNullOrEmpty(dr["vcNomeSupervisor"].ToString()) ? string.Empty : dr["vcNomeSupervisor"].ToString();
                            _usuarioFind.NomeFuncionario = string.IsNullOrEmpty(dr["vcNomeFuncionario"].ToString()) ? string.Empty : dr["vcNomeFuncionario"].ToString();
                            _usuarioFind.NomeDepartamento = string.IsNullOrEmpty(dr["vcNomeDepartamento"].ToString()) ? string.Empty : dr["vcNomeDepartamento"].ToString();
                            _usuarioFind.NomeProjeto = string.IsNullOrEmpty(dr["vcNomeProjeto"].ToString()) ? string.Empty : dr["vcNomeProjeto"].ToString();
                            _usuarioFind.NomeCliente = string.IsNullOrEmpty(dr["vcNomeCliente"].ToString()) ? string.Empty : dr["vcNomeCliente"].ToString();
                            _usuarioFind.NomeStatus = string.IsNullOrEmpty(dr["vcNomeStatus"].ToString()) ? string.Empty : dr["vcNomeStatus"].ToString();

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
        public bool Transferir(clsTimePadraoBLO _timesheet)
        {
            bool _ret = false;
            try
            {
                // Cria conexão.

                using (clsConexaoDAO con = new clsConexaoDAO(ConfigurationManager.ConnectionStrings["Alpha"].ConnectionString))
                {
                    List<SqlParameter> listParameter = new List<SqlParameter>() {
                    new SqlParameter("@OperationType", 2),
                    new SqlParameter("@IdTimesheet", _timesheet.Id),
                    new SqlParameter("@dtData", _timesheet.Data),
                    new SqlParameter("@dtDuracao", _timesheet.Duracao),
                    new SqlParameter("@vcDescricao", _timesheet.Descricao),
                    new SqlParameter("@dtDuracaoExtra", _timesheet.HoraExtra),
                    new SqlParameter("@IdStatus",_timesheet.IdStatus),
                    new SqlParameter("@vcDescricaoExtra",_timesheet.DescricaoExtra),
                    new SqlParameter("@dtDataEntrada", DateTime.Now),
                    new SqlParameter("@IdUsuario", _timesheet.IdFuncionario),                    
                    new SqlParameter("@IdDepartamento",_timesheet.IdDepartamento),
                    new SqlParameter("@IdEmpresa",_timesheet.IdEmpresa),
                    new SqlParameter("@IdProjeto",_timesheet.IdProjeto),
                };
                    con.executeQuery("uspTimesheet", listParameter);
                    _ret = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("clsWaitsheetDAO.Update", ex);
            }

            return _ret;
        }
    }
}
