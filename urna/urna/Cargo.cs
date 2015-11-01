using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace urna
{
    public class Cargo
    {
        public int IDCargo { get; set; }
        public string Nome { get; set; }
        public char Situacao { get; set; }

        public Cargo(string nome)
        {
            Nome = nome;
        }
    }
}
