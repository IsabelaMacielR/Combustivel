using System;
using System.Collections.Generic;
using System.Text;
using Combustivel.Connection;
using Combustivel.Models;
using Combustivel.Views;
using System.Data;
using MySql.Data.MySqlClient;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Android;

namespace Combustivel.DAO
{
    internal class UserDAO
    {
        MySqlConnection connection = ConnectionFactory.getConnection();

        public UserDAO()
        {
            //abre a conexao
            connection.Open();
        }


        #region executa login

        public void efetuaLogin(string cpf, string senha)
        {
            try
            {
                string sql = "SELECT * FROM usuario WHERE cpf = @cpf AND senha = @senha";

                MySqlCommand executaCmdSql = new MySqlCommand(sql, connection);


                executaCmdSql.Parameters.AddWithValue("@cpf", cpf);
                executaCmdSql.Parameters.AddWithValue("@senha", senha);

                connection.Open();

                MySqlDataReader dados = executaCmdSql.ExecuteReader();

                if (dados.Read())
                {
                    ItemsPage tela = new ItemsPage();
                    tela.Show();

                connection.Close();
                }
                else
                {
                    DisplayAlert ("Dados Incorretos", "Algo está errado.", "OK");
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show("ERRO: " + erro);
            }
        }

        #endregion
    }
}
