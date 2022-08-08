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
        private string tipo;

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

        public string Tipo
        {
            get => tipo;
            set => SetProperty(ref tipo, value);
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
                Tipo = user.Tipo;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
