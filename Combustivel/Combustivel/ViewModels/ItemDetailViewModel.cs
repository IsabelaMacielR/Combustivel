using Combustivel.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Combustivel.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private string itemId;
        private string text;
        private string description;
        private string placa;
        private string chassi;
        private string ano;
        private string cor;
        private string horimetro;
        private string km;
        private string combustivel;
        private string secretaria;
        public string Id { get; set; }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public string Placa
        {
            get => placa;
            set => SetProperty(ref placa, value);
        }

        public string Chassi
        {
            get => chassi;
            set => SetProperty(ref chassi, value);
        }

        public string Ano
        {
            get => ano;
            set => SetProperty(ref ano, value);
        }

        public string Cor
        {
            get => cor;
            set => SetProperty(ref cor, value);
        }

        public string Horimetro
        {
            get => horimetro;
            set => SetProperty(ref horimetro, value);
        }

        public string Km
        {
            get => km;
            set => SetProperty(ref km, value);
        }

        public string Combustivel
        {
            get => combustivel;
            set => SetProperty(ref combustivel, value);
        }

        public string Secretaria
        {
            get => secretaria;
            set => SetProperty(ref secretaria, value);
        }

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                Text = item.Text;
                Description = item.Description;
                Placa = item.Placa;
                Chassi = item.Chassi;
                Ano = item.Ano;
                Cor = item.Cor;
                Horimetro = item.Horimetro;
                Km = item.Km;
                Combustivel = item.Combustivel;
                Secretaria = item.Secretaria;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
