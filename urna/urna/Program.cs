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


            PartidoRepositorio repo = new PartidoRepositorio();
            Partido part = new Partido("Partido das Exatas Tensas", "Deixando o mundo mais tenso!", "PET");

            repo.DeletarPorId(1005);
        }
    }
}
