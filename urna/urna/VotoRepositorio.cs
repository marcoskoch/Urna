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
        public void RegistrarVoto(int idCandidato)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();
                comando.CommandText =
                    "INSERT INTO Voto (IDCandidato) VALUES (@paramIdCandidato)";

                comando.AddParameter("paramIdCandidato", idCandidato);

                connection.Open();
                comando.ExecuteNonQuery();
                connection.Close();
            }
        }

        public int BuscarNumeroDeVotosPorCandidato(int idCandidato)
        {
            int quantVotos = 0;

            string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();
                comando.CommandText =
                    "Select COUNT(1) AS Numero_Votos FROM Voto WHERE IDCandidato=@paramIdCandidato";

                comando.AddParameter("paramIdCandidato", idCandidato);

                connection.Open();

                IDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    quantVotos = Convert.ToInt32(reader["Numero_Votos"]);
                }
            }
            return quantVotos;
        }
    }
}
