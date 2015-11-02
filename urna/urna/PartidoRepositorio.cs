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
    class PartidoRepositorio : IRepositorio<Partido>
    { 
        public Partido BuscarPorId(int id)
        {
            Partido PartidoEncontrado = null;
            string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();
                comando.CommandText =
                    "SELECT * FROM Partido WHERE IdPartido = @paramIdPartido";

                comando.AddParameter("paramIdPartido", id);

                connection.Open();

                IDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    string nome = reader["Nome"].ToString();
                    string slogan = reader["Slogan"].ToString();
                    string sigla = reader["Sigla"].ToString();

                    PartidoEncontrado = new Partido(nome, slogan, sigla);

                }

                return PartidoEncontrado;
            }
        }

        public void Cadastrar(Partido partido)
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

        public void Atualizar(Partido partido)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
            using (TransactionScope transacao = new TransactionScope())
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();
                comando.AddParameter("@paramNome", partido.Nome);
                comando.AddParameter("@paramSlogan", partido.Slogan);
                comando.AddParameter("@paramSigla", partido.Sigla);


                comando.CommandText =
                    "UPDATE Partido SET Nome=@paramNome,Slogan=@paramSlogan,Sigla=@paramSigla";

                connection.Open();
                comando.ExecuteNonQuery();
                transacao.Complete();
            }
        }

        public void AtualizarPorId(int id, Partido partido)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
            using (TransactionScope transacao = new TransactionScope())
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();
                comando.AddParameter("@paramIDPartido", id);
                comando.AddParameter("@paramNome", partido.Nome);
                comando.AddParameter("@paramSlogan", partido.Slogan);
                comando.AddParameter("@paramSigla", partido.Sigla);


                comando.CommandText =
                    "UPDATE Partido SET Nome=@paramNome,Slogan=@paramSlogan,Sigla=@paramSigla WHERE IDPartido=@paramIDPartido";

                connection.Open();
                comando.ExecuteNonQuery();
                transacao.Complete();
            }
        }

        public void DeletarPorId(int id)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
            using (TransactionScope transacao = new TransactionScope())
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();
                comando.AddParameter("paramIDPartido", id);

                comando.CommandText =
                    "DELETE FROM Partido WHERE IDPartido = @paramIDPartido";

                connection.Open();
                comando.ExecuteNonQuery();
                transacao.Complete();
            }
        }
    }
}
/*DEVE FICAR NA CAMADA DE INTERFACE

        public bool validarSePartidoExiste(string nome, string sigla)
        {
            var partidoNaoExiste = false;
            string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();
                comando.CommandText =
                    "select COUNT(1) as total_partidos from Partido where Nome = @paramNome and Sigla = @paramSigla";

                comando.AddParameter("paramNome", nome);
                comando.AddParameter("paramSigla", sigla);

                connection.Open();

                IDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    var totalPartidos = Convert.ToInt32(reader["total_partidos"]);
                    if ((totalPartidos == 0))
                    {
                        partidoNaoExiste = true;
                    }
                }

                connection.Close();
            }

            return partidoNaoExiste;
        }*/
