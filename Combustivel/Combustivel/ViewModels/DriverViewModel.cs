using Combustivel.Models;
using Combustivel.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Combustivel.ViewModels
{
    public class DriverViewModel : BaseViewModel
    {
        private Item _selectedDriver;

        public ObservableCollection<Item> Drivers { get; }
        public Command LoadDriverCommand { get; }
        public Command AddDriverCommand { get; }
        public Command<Item> DriverTapped { get; }

        public DriverViewModel()
        {
            Title = "Motoristas";
            Drivers = new ObservableCollection<Item>();
            LoadDriverCommand = new Command(async () => await ExecuteLoadDriverCommand());

            DriverTapped = new Command<Item>(OnDriverSelected);

            AddDriverCommand = new Command(OnAddDriver);
        }

        async Task ExecuteLoadDriverCommand()
        {
            IsBusy = true;

            try
            {
                Drivers.Clear();
                var drivers = await DataStore.GetDriverAsync(true);
                foreach (var driver in drivers)
                {
                    Drivers.Add(driver);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedDriver = null;
        }

        public Item SelectedDriver
        {
            get => _selectedDriver;
            set
            {
                SetProperty(ref _selectedDriver, value);
                OnDriverSelected(value);
            }
        }

        private async void OnAddDriver(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewDriverPage));
        }

        async void OnDriverSelected(Item driver)
        {
            if (driver == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(DriverDetailPage)}?{nameof(DriverDetailViewModel.DriverId)}={driver.Id}");
        }
    }
}