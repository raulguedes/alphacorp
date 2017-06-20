using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaCorp.DAO
{
    public class clsConexaoDAO : IDisposable
    {
        private SqlConnection PegarConexao;

        public clsConexaoDAO(string connString)
        {
            // representa a conexão com o banco
            PegarConexao = new SqlConnection(connString);

        }
        // método que permite obter a conexão
        private SqlConnection obterConexao(SqlConnection PegarConexao)
        {
            // Tente conectar ao banco.
            try
            {
                // abre a conexão e a devolve ao chamador do método               
                PegarConexao.Open();
            }
            catch (SqlException Errosql)
            {
                PegarConexao = null;

                throw Errosql;

            }

            return PegarConexao;
        }
        /// <summary>
        /// Realiza ExecuteNonQuery
        /// Necessario passar nome da Procedure e uma lista de Parametros
        /// </summary>
        /// <param name="nomeProcedure">string</param>
        /// <param name="listParameter">List SqlParameter</param>
        public void executeQuery(string nomeProcedure, List<SqlParameter> listParameter)
        {
            try
            {
                //Pessando a proc e a conexao para o SqlCommand
                SqlCommand ComandoSQL = new SqlCommand(nomeProcedure, PegarConexao);
                //Dizendo qual é o tipo de comando.
                ComandoSQL.CommandType = System.Data.CommandType.StoredProcedure;
                //Passando a lista de parametros.
                ComandoSQL.Parameters.AddRange(listParameter.ToArray());
                //Abrindo a conexão com o banco.
                obterConexao(PegarConexao);
                //Executando no banco.
                ComandoSQL.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //Fechando a conexão.
                fecharConexao();
            }
        }
        private SqlConnection fecharConexao()
        {
            try
            {
                if (PegarConexao != null)
                {
                    PegarConexao.Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return PegarConexao;
        }
        /// <summary>
        /// Necessario passar nome da Procedure e uma lista de Parametros
        /// 
        /// </summary>
        /// <param name="nomeProcedure"></param>
        /// <param name="listParameter"></param>
        /// <returns></returns>
        public SqlDataReader ReturnDataReader(string nomeProcedure, List<SqlParameter> listParameter)
        {
            SqlDataReader reader = null;
            try
            {

                //Pessando a proc e a conexao para o SqlCommand
                SqlCommand ComandoSQL = new SqlCommand(nomeProcedure, PegarConexao);
                //Dizendo qual é o tipo de comando.
                ComandoSQL.CommandType = System.Data.CommandType.StoredProcedure;
                //Passando a lista de parametros.                
                ComandoSQL.Parameters.AddRange(listParameter.ToArray());
                //Abrindo a conexão com o banco.
                obterConexao(PegarConexao);
                // Executando o commando e obtendo o resultado
                reader = ComandoSQL.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return reader;
        }

        public void Dispose()
        {
            PegarConexao.Dispose();
        }
    }
}

