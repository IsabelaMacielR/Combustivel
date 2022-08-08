using Combustivel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Threading.Tasks;
using Xamarin.Forms;
using static Android.Util.EventLogTags;
using System.Diagnostics;
using Combustivel.Services;

namespace Combustivel.ViewModels
{
    public class NewDriverViewModel : BaseViewModel
    {
        private string nome;
        private string cpf;
        private string vencimento;
        private string categoria;
        private string veiculo;
        private string secretaria;

        public IList<Item> items { get { return MockDataStore.items; } }

        Item Selecteditem;

        public Item selecteditem
        {
            get { return selecteditem; }
            set
            {
                if (selecteditem != value)
                {
                    selecteditem = value;
                    OnPropertyChanged();
                }
            }
        }

        //public List<Description> DescriptionsList { get; set; }

        public NewDriverViewModel()
        {

            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(nome)
                && !String.IsNullOrWhiteSpace(cpf)
                && !String.IsNullOrWhiteSpace(secretaria);
        }

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

        public string Veiculo
        {
            get => veiculo;
            set => SetProperty(ref veiculo, value);
        }

        public string Secretaria
        {
            get => secretaria;
            set => SetProperty(ref secretaria, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Item newDriver = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                Nome = Nome,
                CPF = CPF,
                Vencimento = Vencimento,
                Categoria = categoria,
                Veiculo = Veiculo,
                Secretaria = Secretaria
            };

            await DataStore.AddDriverAsync(newDriver);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
