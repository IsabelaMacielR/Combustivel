using Combustivel.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Combustivel.ViewModels
{
    [QueryProperty(nameof(UserId), nameof(UserId))]
    public class UserDetailViewModel : BaseViewModel
    {
        private string userId;
        private string nome;
        private string cpf;
        private string vencimento;
        private string categoria;
        private string secretaria;
        public string Id { get; set; }

        public string Nome
        {
            get => nome;
            set => SetProperty(ref nome, value);
        }

        public string CPF
        {
            get => cpf;
            set => SetProperty(ref cpf, value);
        }

        public string Vencimento
        {
            get => vencimento;
            set => SetProperty(ref vencimento, value);
        }

        public string Categoria
        {
            get => categoria;
            set => SetProperty(ref categoria, value);
        }

        public string Secretaria
        {
            get => secretaria;
            set => SetProperty(ref secretaria, value);
        }

        public string UserId
        {
            get
            {
                return userId;
            }
            set
            {
                userId = value;
                LoadUserId(value);
            }
        }

        public async void LoadUserId(string userId)
        {
            try
            {
                var user = await DataStore.GetUserAsync(userId);
                Id = user.Id;
                Nome = user.Nome;
                CPF = user.CPF;
                Vencimento = user.Vencimento;
                Categoria = user.Categoria;
                Secretaria = user.Secretaria;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
