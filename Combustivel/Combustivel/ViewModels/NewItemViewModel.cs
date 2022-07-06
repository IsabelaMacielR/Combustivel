using Combustivel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Combustivel.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
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

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(text)
                && !String.IsNullOrWhiteSpace(description)
                && !String.IsNullOrWhiteSpace(placa)
                && !String.IsNullOrWhiteSpace(chassi)
                && !String.IsNullOrWhiteSpace(ano)
                && !String.IsNullOrWhiteSpace(cor)
                && !String.IsNullOrWhiteSpace(horimetro)
                && !String.IsNullOrWhiteSpace(km)
                && !String.IsNullOrWhiteSpace(combustivel)
                && !String.IsNullOrWhiteSpace(secretaria);
        }

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

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Item newItem = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                Text = Text,
                Description = Description,
                Placa = Placa,
                Chassi = Chassi,
                Ano = Ano,
                Cor = Cor,
                Horimetro = Horimetro,
                Km = Km,
                Combustivel = Combustivel,
                Secretaria = Secretaria
            };

            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
