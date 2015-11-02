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

            Cargo cargo = new Cargo("Presidente do Hue", 'A');

            eleicao.DesativarCargo("Presidente do Hue");
        }
    }
}
