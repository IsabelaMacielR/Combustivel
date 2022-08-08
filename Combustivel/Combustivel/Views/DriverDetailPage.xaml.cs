using Combustivel.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace Combustivel.Views
{
    public partial class DriverDetailPage : ContentPage
    {
        public DriverDetailPage()
        {
            InitializeComponent();
            BindingContext = new DriverDetailViewModel();
        }
    }
}