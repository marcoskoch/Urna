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



        public IList<Estatistica> BuscarEstatistica()
        {
            IList<Estatistica> lista = new List<Estatistica>();

            string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();
                comando.CommandText =
                    "SELECT votos.count(1) As [Numero de Votos],candidato.NomePopular,cargo.Nome ,partido.Sigla FROM Voto votos" +
                    " INNER JOIN Candidato candidato ON votos.IDCandidato = candidato.IDCandidato" +
                    " INNER JOIN Cargo cargo ON candidato.IDCargo = cargo.IDCargo" +
                    " INNER JOIN Partido partido ON candidato.IDPartido = partido.IDPartido" +
                    " GROUP BY votos.IDCandidato, candidato.NomePopular, cargo.Nome, partido.Sigla ORDER BY votos";

                connection.Open();

                IDataReader reader = comando.ExecuteReader();

                int NumVotos = 0;
                string NomePopular = null;
                string NomeCargo = null;
                string SiglaPartido = null;

                while (reader.Read())
                {
                    NumVotos = Convert.ToInt32(reader["Numero de Votos"]);
                    NomePopular = reader["NomePopular"].ToString();
                    NomeCargo = reader["Nome"].ToString();
                    SiglaPartido = reader["SiglaPartido"].ToString();
                    lista.Add(new Estatistica(NumVotos, NomePopular, NomeCargo, SiglaPartido));

                }
            }
            return lista;
        }

        /*public int BuscarNumeroDeVotosPorCandidato(int idCandidato)
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
        }*/
    }
}
