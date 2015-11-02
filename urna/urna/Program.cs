using DbExtensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace urna
{
    class Program
    {
        static void Main(string[] args)
        {


            Eleicoes eleicao = new Eleicoes();
            
            Partido partidoCOL = new Partido("Partido de Medellín", "Nosotros, somos bandidos, no sapos hijo de puta", "CM");

            Console.WriteLine(eleicao.CadastrarPartido(partidoCOL));
            
            
            string nomeCompleto = "Pablo Emilio Escobar Gaviria";
            string nomePop = "RobinHood paisa";
            DateTime dataNasc = new DateTime(1949,12,1);
            string regTRE = "0192874";
            int idPart = 5;
            int numero = 1983;
            int idCargo = 1;
            Candidato cand = new Candidato(nomeCompleto, nomePop, dataNasc, regTRE, 
                idPart, "", numero, idCargo, true);

            Console.WriteLine(eleicao.CadastrarCandidato(cand));

            Console.ReadLine();
        }
    }
}
