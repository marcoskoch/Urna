using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace urna
{
    public class Voto
    {
        public int IdVoto { get; }
        public int IdCandidato { get; }

        public Voto(int idVoto, int idCandidato)
        {
            IdVoto = idVoto;
            IdCandidato = idCandidato;
        }
    }
}
