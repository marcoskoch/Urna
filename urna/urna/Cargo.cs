using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace urna
{
    class Cargo
    {
        public string Nome { get; private set; }
        public char Situacao { get; set; }

        public Cargo(string Nome, char Situacao)
        {
            this.Nome = Nome;
            this.Situacao = Situacao;
        }
    }
}
