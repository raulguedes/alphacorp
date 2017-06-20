using AlphaCorp.BLO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaCorp.BLO
{
    public class clsPessoaBLO : clsEnderecoBLO
    {

        /// <summary>
        /// Id - seria um IdUsuario se tratando da Session["User"]
        /// </summary>
        public double Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public string vcTipoUser { get; set; }
        /// <summary>
        /// Serve para identificar se a pessoa é Ativa ou Desativada.
        /// </summary>
        ///<value>btStatus</value>
        public bool Status { get; set; }
        /// <summary>
        /// Serve para identificar se o tipo de usuario é um Usuário comum , Supervisor ou Administrador.
        /// 1- Administrador
        /// 2- Supervisor
        /// 3- Comum.
        /// </summary>
        ///<value>IdTipoUser</value>
        public int IdTipoUser { get; set; }
        /// <summary>
        /// Verifica se o cadastro é do tipo juridico ou do tipo fisico
        /// </summary>
        public bool Empresa { get; set; }

    }
}

