using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace urna
{
    class Partido
    {
        public int IdPartido { get; set; }
        public string Nome { get; set; }
        public string Slogan { get; set; }
        public string Sigla { get; set; }

        public Partido (string nome, string slogan, string sigla)
        {
            Nome = nome;
            Slogan = slogan;
            Sigla = sigla;
        }
    }
}
