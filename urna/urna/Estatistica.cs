using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace urna
{
    public class Estatistica
    {
        public int NumeroVotos { get; set; }
        public string NomePopular { get; set; }
        public string NomeCargo { get; set; }
        public string SiglaPartido { get; set; }

        public Estatistica(int NumeroVotos, string NomePopular, string NomeCargo, string SiglaPartido)
        {
            this.NumeroVotos = NumeroVotos;
            this.NomePopular = NomePopular;
            this.NomeCargo = NomeCargo;
            this.SiglaPartido = SiglaPartido;
        }

        public override string ToString()
        {
            return string.Format("Numero de votos: {0}, Nome popular: {1}, Cargo: {2}, Sigla partido: {3}\n\r ", 
                                  NumeroVotos, NomePopular, NomeCargo, SiglaPartido);
        }
    }
}
