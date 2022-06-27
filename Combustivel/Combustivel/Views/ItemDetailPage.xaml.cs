using Combustivel.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Combustivel.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}