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
    public class clsWaitsheetDAO
    {
        public bool Insert(clsWaitsheetBLO _waitsheet)
        {
            bool _ret = false;
            try
            {
                // Cria conexão.

                using (clsConexaoDAO con = new clsConexaoDAO(ConfigurationManager.ConnectionStrings["Alpha"].ConnectionString))
                {
                    List<SqlParameter> listParameter = new List<SqlParameter>() {
                    new SqlParameter("@OperationType", 1),     /* 1: Insert */
                    new SqlParameter("@dtData", _waitsheet.Data),
                    new SqlParameter("@dtDuracao", _waitsheet.Duracao),
                    new SqlParameter("@vcDescricao", _waitsheet.Descricao),
                    new SqlParameter("@dtHoraExtra", _waitsheet.HoraExtra),
                    new SqlParameter("@IdStatus",_waitsheet.IdStatus),
                    new SqlParameter("@vcDescricaoExtra",_waitsheet.DescricaoExtra),
                    new SqlParameter("@dtDataEntrada", DateTime.Now),
                    new SqlParameter("@IdUsuario", _waitsheet.IdFuncionario),
                    new SqlParameter("@IdDepartamento",_waitsheet.IdDepartamento),
                    new SqlParameter("@IdEmpresa",_waitsheet.IdEmpresa),
                    new SqlParameter("@IdProjeto",_waitsheet.IdProjeto),
                };
                    con.executeQuery("uspWaitsheet", listParameter);
                    _ret = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("clsWaitsheetDAO.Insert", ex);
            }

            return _ret;
        }
        public bool Transferir(clsWaitsheetBLO _waitsheet)
        {
            bool _ret = false;
            try
            {
                // Cria conexão.

                using (clsConexaoDAO con = new clsConexaoDAO(ConfigurationManager.ConnectionStrings["Alpha"].ConnectionString))
                {
                    List<SqlParameter> listParameter = new List<SqlParameter>() {
                    new SqlParameter("@OperationType", 2),
                    new SqlParameter("@IdWaitsheet", _waitsheet.Id),
                    new SqlParameter("@dtData", _waitsheet.Data),
                    new SqlParameter("@dtDuracao", _waitsheet.Duracao),
                    new SqlParameter("@vcDescricao", _waitsheet.Descricao),
                    new SqlParameter("@dtHoraExtra", _waitsheet.HoraExtra),
                    new SqlParameter("@IdStatus",_waitsheet.IdStatus),
                    new SqlParameter("@vcDescricaoExtra",_waitsheet.DescricaoExtra),
                    new SqlParameter("@dtDataEntrada", DateTime.Now),
                    new SqlParameter("@IdUsuario", _waitsheet.IdFuncionario),
                    new SqlParameter("@IdSupervisor",_waitsheet.IdSupervisor),
                    new SqlParameter("@IdDepartamento",_waitsheet.IdDepartamento),
                    new SqlParameter("@IdEmpresa",_waitsheet.IdEmpresa),
                    new SqlParameter("@IdProjeto",_waitsheet.IdProjeto),
                };
                    con.executeQuery("uspWaitsheet", listParameter);
                    _ret = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("clsWaitsheetDAO.Update", ex);
            }

            return _ret;
        }
        public bool Delete(clsWaitsheetBLO _waitsheet)
        {
            bool _ret = false;
            try
            {
                // Cria conexão.

                using (clsConexaoDAO con = new clsConexaoDAO(ConfigurationManager.ConnectionStrings["Alpha"].ConnectionString))
                {
                    List<SqlParameter> listParameter = new List<SqlParameter>() {
                    new SqlParameter("@OperationType", 3),     /* 2: Update */
                    new SqlParameter("@IdTimesheet", _waitsheet.Id),
                    new SqlParameter("@IdEmpresa", _waitsheet.IdEmpresa),
                };
                    con.executeQuery("uspWaitsheet", listParameter);
                    _ret = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("clsUsuarioDAO.Update", ex);

            }

            return _ret;
        }
        public List<clsWaitsheetBLO> Find(clsWaitsheetBLO _waitsheet)
        {
            // Inicializa o objeto de retorno.
            List<clsWaitsheetBLO> retorno = new List<clsWaitsheetBLO>();
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
                    if (_waitsheet != null)
                    {

                        // Verifica se o Nome do Cliente é parâmetro para pesquisa.

                        if (_waitsheet.Id != 0)
                        {
                            param.Add(new SqlParameter("@IdWaitsheet", _waitsheet.Id));
                        }
                        if (_waitsheet.IdFuncionario != 0)
                        {
                            param.Add(new SqlParameter("@IdFuncioinario", _waitsheet.IdFuncionario));
                        }
                        if (_waitsheet.IdSupervisor != 0)
                        {
                            param.Add(new SqlParameter("@IdSupervisor", _waitsheet.IdSupervisor));
                        }
                        if (_waitsheet.IdEmpresa != 0)
                        {
                            param.Add(new SqlParameter("@IdEmpresa", _waitsheet.IdEmpresa));
                        }
                        if (_waitsheet.Data != DateTime.MinValue)
                        {
                            param.Add(new SqlParameter("@dtData", _waitsheet.Data));
                        }
                        if (_waitsheet.IdDepartamento != 0)
                        {
                            param.Add(new SqlParameter("@IdDepartamento", _waitsheet.IdDepartamento));
                        }
                        if (_waitsheet.IdProjeto != 0)
                        {
                            param.Add(new SqlParameter("@IdProjeto", _waitsheet.IdProjeto));
                        }
                    }

                    // Obtém dados de retorno.
                    using (dr = con.ReturnDataReader("uspWaitsheet", param))
                    {
                        // Para cada registro é criado um objeto clsWaitsheetBLO.
                        while (dr.Read())
                        {

                            clsWaitsheetBLO _usuarioFind = new clsWaitsheetBLO();

                            _usuarioFind.Id = double.Parse(dr["IdWaitsheet"].ToString());
                            _usuarioFind.Data = DateTime.Parse(dr["dtData"].ToString());
                            _usuarioFind.Duracao = TimeSpan.Parse(dr["dtDuracao"].ToString());
                            _usuarioFind.Descricao = string.IsNullOrEmpty(dr["vcDescricao"].ToString()) ? string.Empty : dr["vcDescricao"].ToString();
                            _usuarioFind.HoraExtra = TimeSpan.Parse(dr["dtHoraExtra"].ToString());
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
                            _usuarioFind.NomeCargo = string.IsNullOrEmpty(dr["vcNomeCargo"].ToString()) ? string.Empty : dr["vcNomeCargo"].ToString();
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
        public List<clsTimePadraoBLO> Find(clsTimePadraoBLO _waitsheet)
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
                    if (_waitsheet != null)
                    {

                        // Verifica se o Nome do Cliente é parâmetro para pesquisa.
                        if (_waitsheet.IdFuncionario != 0)
                        {
                            param.Add(new SqlParameter("@IdFuncioinario", _waitsheet.IdFuncionario));
                        }
                        if (_waitsheet.IdSupervisor != 0)
                        {
                            param.Add(new SqlParameter("@IdSupervisor", _waitsheet.IdSupervisor));
                        }
                        if (_waitsheet.IdEmpresa != 0)
                        {
                            param.Add(new SqlParameter("@IdEmpresa", _waitsheet.IdEmpresa));
                        }
                        if (_waitsheet.Data != DateTime.MinValue)
                        {
                            param.Add(new SqlParameter("@dtData", _waitsheet.Data));
                        }
                        if (_waitsheet.IdDepartamento != 0)
                        {
                            param.Add(new SqlParameter("@IdDepartamento", _waitsheet.IdDepartamento));
                        }
                        if (_waitsheet.IdProjeto != 0)
                        {
                            param.Add(new SqlParameter("@IdProjeto", _waitsheet.IdProjeto));
                        }
                    }

                    // Obtém dados de retorno.
                    using (dr = con.ReturnDataReader("uspWaitsheet", param))
                    {
                        // Para cada registro é criado um objeto clsWaitsheetBLO.
                        while (dr.Read())
                        {

                            clsTimePadraoBLO _usuarioFind = new clsTimePadraoBLO();

                            _usuarioFind.Id = double.Parse(dr["IdWaitsheet"].ToString());
                            _usuarioFind.Data = DateTime.Parse(dr["dtData"].ToString());
                            _usuarioFind.Duracao = TimeSpan.Parse(dr["dtDuracao"].ToString());
                            _usuarioFind.Descricao = string.IsNullOrEmpty(dr["vcDescricao"].ToString()) ? string.Empty : dr["vcDescricao"].ToString();
                            _usuarioFind.HoraExtra = TimeSpan.Parse(dr["dtHoraExtra"].ToString());
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
                            _usuarioFind.NomeCargo = string.IsNullOrEmpty(dr["vcNomeCargo"].ToString()) ? string.Empty : dr["vcNomeCargo"].ToString();
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
    }
}
