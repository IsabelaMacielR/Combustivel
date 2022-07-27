using Combustivel.Models;
using Combustivel.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Combustivel.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        private Item _selectedUser;

        public ObservableCollection<Item> Users { get; }
        public Command LoadUserCommand { get; }
        public Command AddUserCommand { get; }
        public Command<Item> UserTapped { get; }

        public UserViewModel()
        {
            Title = "Usuários";
            Users = new ObservableCollection<Item>();
            LoadUserCommand = new Command(async () => await ExecuteLoadUserCommand());

            UserTapped = new Command<Item>(OnUserSelected);

            AddUserCommand = new Command(OnAddUser);
        }

        async Task ExecuteLoadUserCommand()
        {
            IsBusy = true;

            try
            {
                Users.Clear();
                var users = await DataStore.GetUserAsync(true);
                foreach (var user in users)
                {
                    Users.Add(user);
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
            SelectedUser = null;
        }

        public Item SelectedUser
        {
            get => _selectedUser;
            set
            {
                SetProperty(ref _selectedUser, value);
                OnUserSelected(value);
            }
        }

        private async void OnAddUser(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewUserPage));
        }

        async void OnUserSelected(Item user)
        {
            if (user == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(UserDetailPage)}?{nameof(UserDetailViewModel.UserId)}={user.Id}");
        }
    }
}