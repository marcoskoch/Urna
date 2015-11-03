using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace urna
{
    public class Eleitor
    {
        public int IdEleitor { get; set; }
        public string Nome { get; set; }
        public string TituloEleitoral { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string ZonaEleitoral { get; set; }
        public string Secao { get; set; }
        public string Situacao { get; set; }
        public char Votou { get; set; }

    }
}
