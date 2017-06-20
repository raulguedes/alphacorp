using AlphaCorp.BLO;
using System.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaCorp.BLL
{
    public class clsUtilBLL
    {
        public clsEnderecoBLO BuscaCEP(string _campoCep)
        {

            clsEnderecoBLO Address = new clsEnderecoBLO();
            try
            {
                using (var consulta = new BuscarCEP.AtendeClienteClient("AtendeClientePort"))
                {
                    var _resultado = consulta.consultaCEP(_campoCep);
                    Address.Endereco = _resultado.end;
                    Address.ComplementoEndereco = _resultado.complemento;
                    Address.Bairro = _resultado.bairro;
                    Address.CEP = int.Parse(_resultado.cep);
                    Address.UF = _resultado.uf;
                    Address.Cidade = _resultado.cidade;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return Address;
        }
        public static string TipoMensagem(string mensagem)
        {
            string _parametro = mensagem;
            switch (mensagem)
            {
                case "SucessoCadastro":
                    _parametro = "Cadastrado concluído !";
                    break;
                case "SucessoAlterado":
                    _parametro = "Alteração concluída !";
                    break;
                case "SucessoDelete":
                    _parametro = "Excluído com sucesso!";
                    break;
                case "DadosCarregados":
                    _parametro = "Dados carregados com succeso.";
                    break;
                case "CampoBranco":
                    _parametro = "Campo(s) em branco!";
                    break;
                case "ErroDeleteBanco":
                    _parametro = "Não foi possível excluir!<br/> Este banco esta cadastrado em alguma range.";
                    break;
                case "ErroDeleteUsuario":
                    _parametro = "Não foi possível excluir!<br/> Esse usuário tem alguma range cadastrada.";
                    break;
                case "Erro":
                    _parametro = "Dados não encontrado.";
                    break;
                case "ErroLogin":
                    _parametro = "Erro ao Fazer Login!<br/> Usuário ou Senha inválido";
                    break;
                case "ErroLoginDesativado":
                    _parametro = "Esse usuário esta desativado!";
                    break;
                case "ErroExistenteUser":
                    _parametro = "Usuário já existente!";
                    break;
                case "ErroCadastro":
                    _parametro = "Não foi possível cadastrar!";
                    break;
                case "ErroAlterar":
                    _parametro = "Não foi possível alterar!";
                    break;
                case "ErroDelete":
                    _parametro = "Não foi possível excluir!";
                    break;
                default:
                    _parametro = "" + mensagem;
                    break;
            }
            return _parametro;
        }
    }
}
