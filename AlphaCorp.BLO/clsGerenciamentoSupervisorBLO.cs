using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaCorp.BLO
{
    public class clsGerenciamentoSupervisorBLO
    {
        public double Id            { get; set; }
        public double IdEmpresa     { get; set; }
        public double IdSupervisor  { get; set; }
        public double IdFuncionario { get; set; }
        
        public string Supervisor { get; set; }
        public string Funcionario { get; set; }
    }
}
