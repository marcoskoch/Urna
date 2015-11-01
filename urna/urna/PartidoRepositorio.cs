using DbExtensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace urna
{
    class PartidoRepositorio : IRepositorio<Partido>
    {
        public Partido BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void CadastrarPartido(Partido partido)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();
                comando.CommandText =
                    "INSERT INTO Partido (Nome, Slogan, Sigla) VALUES(@paramNome, @paramSlogan, @paramSigla)";

                comando.AddParameter("paramNome", partido.Nome);
                comando.AddParameter("paramSlogan", partido.Slogan);
                comando.AddParameter("paramSigla", partido.Sigla);

                connection.Open();

                IDataReader reader = comando.ExecuteReader();

                connection.Close();
            }
        }
    }
}
