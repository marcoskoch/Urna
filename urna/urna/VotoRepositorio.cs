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
    public class VotoRepositorio
    {
        public void RegistrarVoto(int numeroCandidato)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();
                comando.CommandText =
                    "INSERT INTO Voto (IDCandidato) VALUES (@paramIdCandidato)";

                comando.AddParameter("paramIdCandidato", numeroCandidato);

                connection.Open();
                comando.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
