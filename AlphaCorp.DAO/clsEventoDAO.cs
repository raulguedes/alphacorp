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
    public class clsEventoDAO
    {
        public bool Insert(clsEventoBLO _Evento)
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
                    new SqlParameter("@vcNome", _Evento.Nome),
                    new SqlParameter("@vcDescricao", _Evento.Descricao),
                    new SqlParameter("@vcLocal", _Evento.Local),
                    new SqlParameter("@dtDataInicio", _Evento.DataInicio),
                    new SqlParameter("@dtDataTermino", _Evento.DataTermino),
                    new SqlParameter("@dtHoraInicio", _Evento.HoraInicio),
                    new SqlParameter("@dtHoraTermino", _Evento.HoraTermino),
                    new SqlParameter("@btPrivacidade", _Evento.Privacidade),
                    new SqlParameter("@IdEmpresa", _Evento.IdEmpresa),
                    new SqlParameter("@IdUsuario", _Evento.IdUsuario),
                    new SqlParameter("@IdTipoUsuario", _Evento.IdTipoUsuario),
                    new SqlParameter("@IdConfirmar", _Evento.Confirmar),

                };
                    con.executeQuery("uspEvento", listParameter);
                    _retDaBusca = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("clsEventoDAO.Insert", ex);
            }

            return _retDaBusca;
        }
        public bool Update(clsEventoBLO _Evento)
        {
            bool _ret = false;
            try
            {
                // Cria conexão.

                using (clsConexaoDAO con = new clsConexaoDAO(ConfigurationManager.ConnectionStrings["Alpha"].ConnectionString))
                {
                    List<SqlParameter> listParameter = new List<SqlParameter>() {
                    new SqlParameter("@OperationType",2),
                    new SqlParameter("@IdEvento", _Evento.IdEvento),
                    new SqlParameter("@vcNome", _Evento.Nome),
                    new SqlParameter("@vcDescricao", _Evento.Descricao),
                    new SqlParameter("@vcLocal", _Evento.Local),
                    new SqlParameter("@dtDataInicio", _Evento.DataInicio),
                    new SqlParameter("@dtDataTermino", _Evento.DataTermino),
                    new SqlParameter("@dtHoraInicio", _Evento.HoraInicio),
                    new SqlParameter("@dtHoraTermino", _Evento.HoraTermino),
                    new SqlParameter("@dtHoraTermino", _Evento.Privacidade),
                    new SqlParameter("@IdEmpresa", _Evento.IdEmpresa),
                    new SqlParameter("@IdUsuario", _Evento.IdUsuario)
                };
                    con.executeQuery("uspEvento", listParameter);
                    _ret = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("clsEventoDAO.Insert", ex);

            }

            return _ret;
        }
        public bool Delete(clsEventoBLO _Evento)
        {
            bool _ret = false;
            try
            {
                // Cria conexão.

                using (clsConexaoDAO con = new clsConexaoDAO(ConfigurationManager.ConnectionStrings["Alpha"].ConnectionString))
                {
                    List<SqlParameter> listParameter = new List<SqlParameter>() {
                    new SqlParameter("@OperationType",3),
                    new SqlParameter("@IdEvento", _Evento.IdEvento),
                    new SqlParameter("@IdEmpresa", _Evento.IdEmpresa),
                };
                    con.executeQuery("uspEvento", listParameter);
                    _ret = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("clsEventoDAO.Insert", ex);

            }

            return _ret;
        }
        public List<clsEventoBLO> Find(clsEventoBLO _Evento)
        {
            // Inicializa o objeto de retorno.
            List<clsEventoBLO> retorno = new List<clsEventoBLO>();
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
                    if (_Evento != null)
                    {
                        // Verifica se o Nome do Cliente é parâmetro para pesquisa.
                        if (_Evento.IdEvento != 0)
                        {
                            param.Add(new SqlParameter("@IdEvento", _Evento.IdEvento));
                        }
                        if (_Evento.IdMembroUsuario != 0)
                        {
                            param.Add(new SqlParameter("@IdMembroUsuario", _Evento.IdMembroUsuario));
                        }
                        if (_Evento.IdEmpresa != 0)
                        {
                            param.Add(new SqlParameter("@IdEmpresa", _Evento.IdEmpresa));
                        }
                        if (!string.IsNullOrEmpty(_Evento.Nome))
                        {
                            param.Add(new SqlParameter("@vcNome", _Evento.Nome));
                        }
                    }

                    // Obtém dados de retorno.
                    using (dr = con.ReturnDataReader("uspEvento", param))
                    {
                        // Para cada registro é criado um objeto clsEventoBLO.
                        while (dr.Read())
                        {

                            clsEventoBLO _EventoFind = new clsEventoBLO();

                            _EventoFind.IdEvento = double.Parse(dr["IdEvento"].ToString());
                            _EventoFind.Nome = string.IsNullOrEmpty(dr["vcNomeEvento"].ToString()) ? string.Empty : dr["vcNomeEvento"].ToString();
                            _EventoFind.IdCriador = double.Parse(dr["IdCriador"].ToString());
                            _EventoFind.NomeCriador = string.IsNullOrEmpty(dr["vcNomeCriador"].ToString()) ? string.Empty : dr["vcNomeCriador"].ToString();
                            _EventoFind.Descricao = string.IsNullOrEmpty(dr["vcDescricao"].ToString()) ? string.Empty : dr["vcDescricao"].ToString();
                            _EventoFind.Local = string.IsNullOrEmpty(dr["vcLocal"].ToString()) ? string.Empty : dr["vcLocal"].ToString();
                            _EventoFind.DataInicio = Convert.ToDateTime(string.IsNullOrEmpty(dr["dtDataInicio"].ToString()) ? DateTime.MinValue : Convert.ToDateTime(dr["dtDataInicio"].ToString()));
                            _EventoFind.DataTermino = Convert.ToDateTime(string.IsNullOrEmpty(dr["dtDataTermino"].ToString()) ? DateTime.MinValue : Convert.ToDateTime(dr["dtDataTermino"].ToString()));
                            if (!string.IsNullOrEmpty(dr["dtHoraInicio"].ToString()))
                                _EventoFind.HoraInicio = TimeSpan.Parse(dr["dtHoraInicio"].ToString());
                            if (!string.IsNullOrEmpty(dr["dtHoraTermino"].ToString()))
                                _EventoFind.HoraTermino = TimeSpan.Parse(dr["dtHoraTermino"].ToString());
                            _EventoFind.Privacidade = Convert.ToBoolean(dr["btPrivacidade"].ToString());
                            _EventoFind.IdEmpresa = double.Parse(dr["IdEmpresa"].ToString());
                            _EventoFind.IdMembroUsuario = double.Parse(dr["IdMembro"].ToString());
                            _EventoFind.IdMembroEvento = double.Parse(dr["IdMembroEvento"].ToString());
                            _EventoFind.Confirmar = int.Parse(dr["IdConfirmar"].ToString());
                            _EventoFind.IdTipoUsuario = int.Parse(dr["IdTipoUsuario"].ToString());

                            retorno.Add(_EventoFind);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("clsEventoDAO.Find", ex);
            }

            return retorno;
        }
        public List<clsEventoBLO> FindEvento(clsEventoBLO _Evento)
        {
            // Inicializa o objeto de retorno.
            List<clsEventoBLO> retorno = new List<clsEventoBLO>();
            // DataReader de retorno.
            SqlDataReader dr = null;

            try
            {
                using (clsConexaoDAO con = new clsConexaoDAO(ConfigurationManager.ConnectionStrings["Alpha"].ConnectionString))
                {

                    // Cria lista de parâmetros.
                    List<SqlParameter> param = new List<SqlParameter>();



                    param.Add(new SqlParameter("@OperationType", 5));


                    // Verifica quais parâmetros serão utilizados.
                    if (_Evento != null)
                    {
                        // Verifica se o Nome do Cliente é parâmetro para pesquisa.
                        if (_Evento.IdEvento != 0)
                        {
                            param.Add(new SqlParameter("@IdEvento", _Evento.IdEvento));
                        }
                        if (_Evento.IdMembroUsuario != 0)
                        {
                            param.Add(new SqlParameter("@IdUsuario", _Evento.IdMembroUsuario));
                        }
                        if (_Evento.IdEmpresa != 0)
                        {
                            param.Add(new SqlParameter("@IdEmpresa", _Evento.IdEmpresa));
                        }
                        if (!string.IsNullOrEmpty(_Evento.Nome))
                        {
                            param.Add(new SqlParameter("@vcNome", _Evento.Nome));
                        }
                    }

                    // Obtém dados de retorno.
                    using (dr = con.ReturnDataReader("uspEvento", param))
                    {
                        // Para cada registro é criado um objeto clsEventoBLO.
                        while (dr.Read())
                        {

                            clsEventoBLO _EventoFind = new clsEventoBLO();

                            _EventoFind.IdEvento = double.Parse(dr["IdEvento"].ToString());
                            _EventoFind.Nome = string.IsNullOrEmpty(dr["vcNomeEvento"].ToString()) ? string.Empty : dr["vcNomeEvento"].ToString();
                            _EventoFind.IdCriador = double.Parse(dr["IdCriador"].ToString());
                            _EventoFind.IdMembroUsuario = double.Parse(dr["IdMembro"].ToString());
                            _EventoFind.NomeCriador = string.IsNullOrEmpty(dr["vcNomeCriador"].ToString()) ? string.Empty : dr["vcNomeCriador"].ToString();
                            _EventoFind.Descricao = string.IsNullOrEmpty(dr["vcDescricao"].ToString()) ? string.Empty : dr["vcDescricao"].ToString();
                            _EventoFind.Local = string.IsNullOrEmpty(dr["vcLocal"].ToString()) ? string.Empty : dr["vcLocal"].ToString();
                            _EventoFind.DataInicio = Convert.ToDateTime(string.IsNullOrEmpty(dr["dtDataInicio"].ToString()) ? DateTime.MinValue : Convert.ToDateTime(dr["dtDataInicio"].ToString()));
                            _EventoFind.DataTermino = Convert.ToDateTime(string.IsNullOrEmpty(dr["dtDataTermino"].ToString()) ? DateTime.MinValue : Convert.ToDateTime(dr["dtDataTermino"].ToString()));
                            if (!string.IsNullOrEmpty(dr["dtHoraInicio"].ToString()))
                                _EventoFind.HoraInicio = TimeSpan.Parse(dr["dtHoraInicio"].ToString());
                            if (!string.IsNullOrEmpty(dr["dtHoraTermino"].ToString()))
                                _EventoFind.HoraTermino = TimeSpan.Parse(dr["dtHoraTermino"].ToString());
                            _EventoFind.Privacidade = Convert.ToBoolean(dr["btPrivacidade"].ToString());
                            _EventoFind.IdEmpresa = double.Parse(dr["IdEmpresa"].ToString());                            
                            _EventoFind.Confirmar = int.Parse(dr["IdConfirmar"].ToString());
                            _EventoFind.IdTipoUsuario = int.Parse(dr["IdTipoUsuario"].ToString());
                                                                                                                                                                                                                                                            
                            
                            retorno.Add(_EventoFind);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("clsEventoDAO.Find", ex);
            }

            return retorno;
        }
        /// <summary>
        /// Retorna uma lista.
        /// Esse metodo faz a busca pelo metodo Find.
        /// </summary>
        /// <returns></returns>
        public List<clsEventoBLO> FindAll()
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
