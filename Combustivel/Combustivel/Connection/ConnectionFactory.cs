using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Combustivel.Connection
{
    public class ConnectionFactory
    {
        //metodo para conectar o banco de dados

        public static MySqlConnection getConnection() 
        {
            //acessando a string de conexão

            string connection = ConfigurationManager.ConnectionStrings["combustivel"].ConnectionString;

            return new MySqlConnection(connection);
        }
    }
}
