using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace urna
{
    public class Candidato
    {
        public int IdCandidato { get; set; }
        public string NomeCompleto { get; private set; }
        public string NomePopular { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string RegistroTRE { get; private set; }
        public int IDPartido { get; private set; }
        public string Foto { get; private set; }
        public int Numero { get; private set; }
        public int IDCargo { get; private set; }
        public bool Exibe { get; private set; }

        public Candidato(string NomeCompleto, string NomePopular, DateTime DataNascimento, string RegistroTRE, int IDPartido,
                         string Foto, int Numero, int IDCargo, bool Exibe)
        {
            this.NomeCompleto = NomeCompleto;
            this.NomePopular = NomePopular;
            this.DataNascimento = DataNascimento;
            this.RegistroTRE = RegistroTRE;
            this.IDPartido = IDPartido;
            this.Foto = Foto;
            this.Numero = Numero;
            this.IDCargo = IDCargo;
            this.Exibe = Exibe;
        }

    }
}
