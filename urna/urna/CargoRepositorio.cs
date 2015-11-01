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
    public class CargoRepositorio : IRepositorio<Cargo>
    {
        public Cargo BuscarPorId(int id)
        {
            Cargo cargoEncontrado = null;

            string connectionString = @"Server = USUARIO-PC\SQLEXPRESS; Database = Urna_local; Trusted_Connection = True";
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();
                comando.CommandText =
                    "SELECT IDCargo, Nome, Situacao FROM Cargo WHERE IDCargo = @paramIdCargo";

                comando.AddParameter("paramIdCargo", id);

                connection.Open();

                IDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    int idDb = Convert.ToInt32(reader["IDCargo"]);
                    string nome = reader["Nome"].ToString();
                    char situacao = Convert.ToChar(reader["Situacao"]);

                    cargoEncontrado = new Cargo(nome)
                    {
                        IDCargo = idDb,
                        Situacao = situacao
                    };
                }

                connection.Close();
            }

            return cargoEncontrado;
        }

        public void Cadastrar(Cargo cargo)
        {
            string connectionString = @"Server = USUARIO-PC\SQLEXPRESS; Database = Urna_local; Trusted_Connection = True";
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();

                comando.CommandText =
                    "INSERT INTO Cargo (Nome, Situacao) VALUES (@paramNomeCargo, @SituacaoCargo);";
                comando.AddParameter("paramNomeCargo", cargo.Nome);
                comando.AddParameter("SituacaoCargo", cargo.Situacao);

                connection.Open();
                comando.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Editar(Cargo cargo)
        {
            string connectionString = @"Server = USUARIO-PC\SQLEXPRESS; Database = Urna_local; Trusted_Connection = True";
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();
                comando.CommandText =
                    "UPDATE Cargo SET Nome = @paramNome, Situacao = @paramSituacao WHERE IDCargo = @paramIDCargo";

                comando.AddParameter("paramNome", cargo.Nome);
                comando.AddParameter("paramSituacao", cargo.Situacao);
                comando.AddParameter("paramIDCargo", cargo.IDCargo);

                connection.Open();
                comando.ExecuteNonQuery();
                connection.Close();
            }
        }

        public bool ValidarExistencia(Cargo cargo)
        {
            string connectionString = @"Server = USUARIO-PC\SQLEXPRESS; Database = Urna_local; Trusted_Connection = True";
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();
                comando.CommandText =
                    "SELECT * FROM Cargo WHERE Nome = @paramNome";
                comando.AddParameter("paramNome", cargo.Nome);

                connection.Open();

                IDataReader reader = comando.ExecuteReader();

                return reader.Read();
            }
        }
    }
}
