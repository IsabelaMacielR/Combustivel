using Combustivel.Models;
using Combustivel.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Combustivel.ViewModels
{
    [QueryProperty(nameof(DriverId), nameof(DriverId))]
    public class DriverDetailViewModel : BaseViewModel
    {
        private string driverId;
        private string nome;
        private string cpf;
        private string vencimento;
        private string categoria;
        private string veiculo;
        private string secretaria;

        public Command DelDriverCommand { get; }
        public IList<Item> drivers { get { return MockDataStore.drivers; } }

        public DriverDetailViewModel()
        {
            DelDriverCommand = new Command(OnDelDriver);
        }

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

        public string DriverId
        {
            get
            {
                return driverId;
            }
            set
            {
                driverId = value;
                LoadDriverId(value);
            }
        }

        public async void LoadDriverId(string driverId)
        {
            try
            {
                var driver = await DataStore.GetDriverAsync(driverId);
                Id = driver.Id;
                Nome = driver.Nome;
                CPF = driver.CPF;
                Vencimento = driver.Vencimento;
                Categoria = driver.Categoria;
                Veiculo = driver.Veiculo;
                Secretaria = driver.Secretaria;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        public void OnDelDriver(object obj)
        {
            if (MockDataStore.drivers.Remove((Item)drivers))

                return;
        }

    }
}
