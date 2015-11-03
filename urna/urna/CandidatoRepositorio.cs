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
    public class CandidatoRepositorio : IRepositorio<Candidato>
    {
        public Candidato BuscarPorId(int id)
        {
            Candidato CandidatoEncontrado = null;

            string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();
                comando.CommandText =
                    "SELECT * FROM Candidato WHERE IdCandidato = @paramIdCandidato";

                comando.AddParameter("paramIdCandidato", id);

                connection.Open();

                IDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    string nomeC = reader["NomeCompleto"].ToString();
                    string nomeP = reader["NomePopular"].ToString();
                    DateTime dataN = Convert.ToDateTime(reader["DataNascimento"]);
                    string registro = reader["RegistroTRE"].ToString();
                    int idPartido = Convert.ToInt32(reader["IDPartido"]);
                    string foto = reader["Foto"].ToString();
                    int numero = Convert.ToInt32(reader["Numero"]);
                    int idCargo = Convert.ToInt32(reader["IDCargo"]);
                    bool exibe = Convert.ToBoolean(reader["Exibe"]);

                    CandidatoEncontrado = new Candidato(nomeC, nomeP, dataN, registro, idPartido, foto, numero, idCargo, exibe);

                }

                return CandidatoEncontrado;
            }
        }

        public List<Candidato> BuscarPorPartido(int id)
        {
            List<Candidato> CandidatosEncontrado = new List<Candidato>();

            string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();
                comando.CommandText =
                    "SELECT * FROM Candidato WHERE IDPartido = @paramIdPartido";

                comando.AddParameter("paramIdPartido", id);

                connection.Open();

                IDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    string nomeC = reader["NomeCompleto"].ToString();
                    string nomeP = reader["NomePopular"].ToString();
                    DateTime dataN = Convert.ToDateTime(reader["DataNascimento"]);
                    string registro = reader["RegistroTRE"].ToString();
                    int idPartido = Convert.ToInt32(reader["IDPartido"]);
                    string foto = reader["Foto"].ToString();
                    int numero = Convert.ToInt32(reader["Numero"]);
                    int idCargo = Convert.ToInt32(reader["IDCargo"]);
                    bool exibe = Convert.ToBoolean(reader["Exibe"]);

                    CandidatosEncontrado.Add(new Candidato(nomeC, nomeP, dataN, registro, idPartido, foto, numero, idCargo, exibe));

                }

                return CandidatosEncontrado;
            }
        }

        public List<Candidato> BuscarPorCargo(int id)
        {
            List<Candidato> CandidatosEncontrado = new List<Candidato>();

            string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();
                comando.CommandText =
                    "SELECT * FROM Candidato WHERE IDCargo = @paramIdCargo";

                comando.AddParameter("paramIdCargo", id);

                connection.Open();

                IDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    string nomeC = reader["NomeCompleto"].ToString();
                    string nomeP = reader["NomePopular"].ToString();
                    DateTime dataN = Convert.ToDateTime(reader["DataNascimento"]);
                    string registro = reader["RegistroTRE"].ToString();
                    int idPartido = Convert.ToInt32(reader["IDPartido"]);
                    string foto = reader["Foto"].ToString();
                    int numero = Convert.ToInt32(reader["Numero"]);
                    int idCargo = Convert.ToInt32(reader["IDCargo"]);
                    bool exibe = Convert.ToBoolean(reader["Exibe"]);

                    CandidatosEncontrado.Add(new Candidato(nomeC, nomeP, dataN, registro, idPartido, foto, numero, idCargo, exibe));

                }

                return CandidatosEncontrado;
            }
        }

        public Candidato BuscarPorNumero(int numero)
        {
            Candidato CandidatoEncontrado = null;

            string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();
                comando.CommandText =
                    "SELECT * FROM Candidato WHERE Numero = @paramNumero";

                comando.AddParameter("paramNumero", numero);

                connection.Open();

                IDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    string nomeC = reader["NomeCompleto"].ToString();
                    string nomeP = reader["NomePopular"].ToString();
                    DateTime dataN = Convert.ToDateTime(reader["DataNascimento"]);
                    string registro = reader["RegistroTRE"].ToString();
                    int idPartido = Convert.ToInt32(reader["IDPartido"]);
                    string foto = reader["Foto"].ToString();
                    int idCargo = Convert.ToInt32(reader["IDCargo"]);
                    bool exibe = Convert.ToBoolean(reader["Exibe"]);

                    CandidatoEncontrado = new Candidato(nomeC, nomeP, dataN, registro, idPartido, foto, numero, idCargo, exibe);

                }

                return CandidatoEncontrado;
            }
        }
        public void Cadastrar(Candidato candidato)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
            using (TransactionScope transacao = new TransactionScope())
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();
                comando.AddParameter("@paramNomeCompleto", candidato.NomeCompleto);
                comando.AddParameter("@paramNomePopular", candidato.NomePopular);
                comando.AddParameter("@paramDataNascimento", candidato.DataNascimento);
                comando.AddParameter("@paramRegistroTRE", candidato.RegistroTRE);
                comando.AddParameter("@paramIDPartido", candidato.IDPartido);
                comando.AddParameter("@paramFoto", candidato.Foto);
                comando.AddParameter("@paramNumero", candidato.Numero);
                comando.AddParameter("@paramIDCargo", candidato.IDCargo);
                comando.AddParameter("@paramExibe", candidato.Exibe);


                comando.CommandText =
                    "INSERT INTO Candidato(NomeCompleto, NomePopular, DataNascimento, RegistroTRE, IDPartido, Foto, Numero, IDCargo, Exibe)" +
                    " VALUES(@paramNomeCompleto, @paramNomePopular, @paramDataNascimento, @paramRegistroTRE, @paramIDPartido, @paramFoto, @paramNumero, @paramIDCargo, @paramExibe)";

                connection.Open();
                comando.ExecuteNonQuery();
                transacao.Complete();
            }
        }
        public void Atualizar(Candidato candidato)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
            using (TransactionScope transacao = new TransactionScope())
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();
                comando.AddParameter("@paramNomeCompleto", candidato.NomeCompleto);
                comando.AddParameter("@paramNomePopular", candidato.NomePopular);
                comando.AddParameter("@paramDataNascimento", candidato.DataNascimento);
                comando.AddParameter("@paramRegistroTRE", candidato.RegistroTRE);
                comando.AddParameter("@paramIDPartido", candidato.IDPartido);
                comando.AddParameter("@paramFoto", candidato.Foto);
                comando.AddParameter("@paramNumero", candidato.Numero);
                comando.AddParameter("@paramIDCargo", candidato.IDCargo);
                comando.AddParameter("@paramExibe", candidato.Exibe);


                comando.CommandText =
                    "UPDATE Candidato SET NomeCompleto=@paramNomeCompleto, NomePopular=@paramNomePopular, DataNascimento=@paramDataNascimento, RegistroTRE=@paramRegistroTRE, IDPartido=@paramIDPartido, Foto=@paramFoto, Numero=paramNumero, IDCargo=paramIDCargo, Exibe=@paramExibe ";

                connection.Open();
                comando.ExecuteNonQuery();
                transacao.Complete();
            }
        }

        public void AtualizarPorId(int id, Candidato candidato)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
            using (TransactionScope transacao = new TransactionScope())
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();
                comando.AddParameter("@paramIDCandidato", id);
                comando.AddParameter("@paramNomeCompleto", candidato.NomeCompleto);
                comando.AddParameter("@paramNomePopular", candidato.NomePopular);
                comando.AddParameter("@paramDataNascimento", candidato.DataNascimento);
                comando.AddParameter("@paramRegistroTRE", candidato.RegistroTRE);
                comando.AddParameter("@paramIDPartido", candidato.IDPartido);
                comando.AddParameter("@paramFoto", candidato.Foto);
                comando.AddParameter("@paramNumero", candidato.Numero);
                comando.AddParameter("@paramIDCargo", candidato.IDCargo);
                comando.AddParameter("@paramExibe", candidato.Exibe);


                comando.CommandText =
                    "UPDATE Candidato SET NomeCompleto=@paramNomeCompleto, NomePopular=@paramNomePopular, DataNascimento=@paramDataNascimento, RegistroTRE=@paramRegistroTRE, IDPartido=@paramIDPartido, Foto=@paramFoto, Numero=@paramNumero, IDCargo=@paramIDCargo, Exibe=@paramExibe " +
                    "WHERE IDCandidato=@paramIDCandidato";

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
                comando.AddParameter("paramIdCandidato", id);

                comando.CommandText =
                    "DELETE FROM Candidato WHERE IdCandidato = @paramIdCandidato";

                connection.Open();
                comando.ExecuteNonQuery();
                transacao.Complete();
            }
        }

        public void DeletarPorNomePopular(string nomePopular)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
            using (TransactionScope transacao = new TransactionScope())
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();
                comando.AddParameter("paramNome", nomePopular);

                comando.CommandText =
                    "DELETE FROM Candidato WHERE NomePopular = @paramNome";

                connection.Open();
                comando.ExecuteNonQuery();
                transacao.Complete();
            }
        }

        public bool ValidarSeCandidatoExiste(Candidato candidato)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
            using(IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();

                comando.AddParameter("paramNomePopular", candidato.NomePopular);
                comando.AddParameter("paramRegistroTRE", candidato.RegistroTRE);
                comando.AddParameter("paramNumero", candidato.Numero);

                comando.CommandText =
                    "SELECT * FROM Candidato WHERE " 
                    +"NomePopular = @paramNomePopular OR RegistroTRE = @paramRegistroTRE OR Numero = @paramNumero";

                connection.Open();

                IDataReader reader = comando.ExecuteReader();

                return reader.Read();
            }
        }

        public bool ExisteCandidatoAPrefeitoNestePartido(int idCargoPrefeito, int idPartido)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
            using(IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();
                comando.AddParameter("paramIdCargoPrefeito", idCargoPrefeito);
                comando.AddParameter("paramIdPartido", idPartido);

                comando.CommandText =
                    "SELECT * FROM Candidato WHERE IDPartido=@paramIdPartido AND IDCargo = @paramIdCargoPrefeito;";

                connection.Open();

                IDataReader reader = comando.ExecuteReader();

                return reader.Read();
            }
        }
    }
}

        /*TUDO ISSO DEVE FICAR NA CAMADA DE INTERFACE
        
        public bool ValidarPartidoExistente(int idPartido)
        {
            PartidoRepositorio repo = new PartidoRepositorio();
            Partido partido = repo.BuscarPorId(idPartido);

            if(partido != null)
                return true;

            return false;
        }

        public bool ValidarCargoExistente(int idCargo)
        {
            CargoRepositorio repo = new CargoRepositorio();
            Cargo cargo = repo.BuscarPorId(idCargo);

            if(cargo != null)
                return false;

            return true;
            */