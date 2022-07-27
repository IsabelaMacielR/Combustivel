using Combustivel.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Combustivel.Views
{
    public partial class UserDetailPage : ContentPage
    {
        public UserDetailPage()
        {
            InitializeComponent();
            BindingContext = new UserDetailViewModel();
        }
    }
}