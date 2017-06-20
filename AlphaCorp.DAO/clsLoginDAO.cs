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
    public class clsLoginDAO
    {

        public List<clsLoginBLO> Find(clsLoginBLO _empresa)
        {
            // Inicializa o objeto de retorno.
            List<clsLoginBLO> retorno = new List<clsLoginBLO>();
            // DataReader de retorno.
            SqlDataReader dr = null;

            try
            {
                using (clsConexaoDAO con = new clsConexaoDAO(ConfigurationManager.ConnectionStrings["Alpha"].ConnectionString))
                {

                    // Cria lista de parâmetros.
                    List<SqlParameter> param = new List<SqlParameter>();


                    param.Add(new SqlParameter("@OperationType", 1));


                    // Verifica quais parâmetros serão utilizados.
                    if (_empresa != null)
                    {
                        // Verifica se o Nome do Cliente é parâmetro para pesquisa.
                        if (!string.IsNullOrEmpty(_empresa.Email))
                        {
                            param.Add(new SqlParameter("@vcEmail", _empresa.Email));
                        }

                        if (!string.IsNullOrEmpty(_empresa.Senha))
                        {
                            param.Add(new SqlParameter("@vcSenha", _empresa.Senha));
                        }
                    }
                    // Obtém dados de retorno.
                    using (dr = con.ReturnDataReader("uspUsuario", param))
                    {
                        // Para cada registro é criado um objeto clsLoginBLO.
                        while (dr.Read())
                        {

                            clsLoginBLO _loginFind = new clsLoginBLO();
                            _loginFind.Id = (int)dr["IdUsuario"];
                            _loginFind.Nome = string.IsNullOrEmpty(dr["vcNome"].ToString()) ? string.Empty : dr["vcNome"].ToString();
                            _loginFind.Senha = string.IsNullOrEmpty(dr["vcSenha"].ToString()) ? string.Empty : dr["vcSenha"].ToString();
                            _loginFind.Email = string.IsNullOrEmpty(dr["vcEmail"].ToString()) ? string.Empty : dr["vcEmail"].ToString();
                            _loginFind.Status = (bool)dr["btStatus"];
                            _loginFind.Empresa = (bool)dr["btEmpresa"];
                            _loginFind.IdTipoUser = int.Parse(dr["IdTipoUser"].ToString());
                            if (!_loginFind.Empresa)
                            {
                                _loginFind.IdEmpresa = int.Parse(dr["IdEmpresa"].ToString());
                                _loginFind.PermitirHoraExtra = (bool)dr["btPermitirHoraExtra"];
                                _loginFind.HoraDiaria = TimeSpan.Parse(dr["dtHoraDiaria"].ToString());
                            }

                            retorno.Add(_loginFind);
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
    }
}
