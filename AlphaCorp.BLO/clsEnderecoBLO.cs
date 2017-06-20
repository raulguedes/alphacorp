using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaCorp.BLO
{
    public class clsEnderecoBLO
    {
        public int    IdEndereco          { get; set; }
        public int    CEP                 { get; set; }
        public string Endereco            { get; set; }
        public int    NumeroEndereco      { get; set; }
        public string ComplementoEndereco { get; set; }
        public string Bairro              { get; set; }
        public string UF                  { get; set; }
        public string Cidade              { get; set; }

    }
}
