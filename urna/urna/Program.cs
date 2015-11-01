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

            PartidoRepositorio partidoRepositorio = new PartidoRepositorio();

            if (partidoRepositorio.validarSePartidoExiste("Partido HelloWorld", "PH"))
            {
                partidoRepositorio.CadastrarPartido(new Partido("Partido HelloWorld", "bla bla bla", "PH"));
            }            

            Console.Read();
        }
    }
}
