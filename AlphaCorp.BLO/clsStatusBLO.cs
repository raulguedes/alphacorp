using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaCorp.BLO
{
    public class clsStatusBLO
    {
        public enum Timesheet : int
        {
            Aguardando = 1,
            Aprovado = 2,
            Rejeitado = 3
        }
        public enum TipoUser : int
        {
            Administrador = 1,
            Supervisor = 2,
            Comum = 3
        };
        public enum Projeto : int
        {
            Andamento = 1,
            Concluído = 2,
            Cancelado = 3
        };

        public enum Sexo : int
        {
            Masculino = 1,
            Feminino = 2
        };
        public enum EventoConvidado : int
        {
            Vou = 1,
            Nao = 2,
            Convidado = 3
        };

    }
}
