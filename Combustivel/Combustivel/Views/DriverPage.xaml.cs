using Combustivel.Models;
using Combustivel.ViewModels;
using Combustivel.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Combustivel.Views
{
    public partial class DriverPage : ContentPage
    {
        DriverViewModel _viewModel;

        public DriverPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new DriverViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}