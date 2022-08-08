using Combustivel.DAO;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Combustivel.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            string cpf, senha;

            cpf = inputCpf.Text;
            senha = inputSenha.Text;

            UserDAO dao = new UserDAO();
            dao.efetuaLogin(cpf, senha);
        }
    }
}