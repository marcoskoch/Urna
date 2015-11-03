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
    class EleitorRepositorio
    {
        public bool validarEleitor (string cpf)
        {
            var podeVotar = false;
            string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();
                comando.CommandText =
                    "select COUNT(1) eleitor from Eleitor where CPF = @paramCpf and Votou = 'N'";

                comando.AddParameter("paramCpf", cpf);

                connection.Open();

                IDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    var eleitor = Convert.ToInt32(reader["eleitor"]);
                    if ((eleitor == 1))
                    {
                        podeVotar = true;
                    }
                }

                connection.Close();
            }

            return podeVotar;
        }
    }
}
