using AlphaCorp.BLO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaCorp.BLO
{
   public class clsPessoaFisicaBLO : clsPessoaBLO
    {
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public bool PermitirHoraExtra { get; set; }        
        public double RG { get; set; }
        public double CPF { get; set; }
        public double Residencial { get; set; }
        public double Celular { get; set; }
        public TimeSpan HoraDiaria { get; set; }
        public double IdDepartamento { get; set; }
        public double IdEmpresa { get; set; }
        public double IdCargo { get; set; }
    }
}
