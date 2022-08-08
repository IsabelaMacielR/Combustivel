using Combustivel.Models;
using Combustivel.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Combustivel.Views
{
    public partial class NewDriverPage : ContentPage
    {

        public Item Driver { get; set; }

        public NewDriverPage()
        {
            InitializeComponent();

 
            BindingContext = new NewDriverViewModel();


        }
    }
}