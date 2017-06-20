using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaCorp.BLO
{
    public class clsTimePadraoBLO
    {
        public double Id { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan Duracao { get; set; }
        public string Descricao { get; set; }
        public string Email { get; set; }
        public DateTime DataEntrada { get; set; }        
        public double IdDepartamento { get; set; }
        public double IdCargo { get; set; }
        public double IdEmpresa { get; set; }
        public double IdProjeto { get; set; }
        public double IdSupervisor { get; set; }
        public string NomeProjeto { get; set; }
        public string NomeFuncionario { get; set; }
        public string NomeSupervisor { get; set; }
        public string NomeCargo { get; set; }
        public string NomeDepartamento { get; set; }
        public string NomeCliente { get; set; }
        public string NomeStatus { get; set; }
        public int IdStatus { get; set; }
        public DateTime DataExtra { get; set; }
        public Nullable<TimeSpan> HoraExtra { get; set; }
        public string DescricaoExtra { get; set; }
        public double IdExtra { get; set; }
        public double IdTimesheet { get; set; }
        public double IdFuncionario { get; set; }
    }
}
