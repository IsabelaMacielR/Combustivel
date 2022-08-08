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

<<<<<<< HEAD
    
=======
        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            string cpf, senha;

            cpf = inputCpf.Text;
            senha = inputSenha.Text;

            UserDAO dao = new UserDAO();
            dao.efetuaLogin(cpf, senha);
        }
>>>>>>> b5bf8fe60cdfe7c51539c97ad8af88b0975f2f7c
    }

}
