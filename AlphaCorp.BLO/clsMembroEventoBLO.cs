using AlphaCorp.BLO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaCorp.BLO
{
    public class clsMembroEventoBLO : clsMembroBLO
    {
        public double Id { get; set; }
        public string NomeEvento { get; set; }
        public int Confirmar { get; set; }
        public string Departamento { get; set; }
        public string Cargo { get; set; }
    }
}
