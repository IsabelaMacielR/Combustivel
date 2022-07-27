using Combustivel.Models;
using Combustivel.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Combustivel.Views
{
    public partial class NewUserPage : ContentPage
    {

        public Item User { get; set; }

        public NewUserPage()
        {
            InitializeComponent();

            

            BindingContext = new NewUserViewModel();

            /*var Description = new List<string>();
            Description.Add("Teste1");
            Description.Add("Teste2");
            Description.Add("Teste3");
            Description.Add("Teste4");

            Descriptions.ItemsSource = Description;*/
        }

        /*private void NewUserPicker_SelectedIndexChanged(object sender, EventArgs e)
        {

        }*/
    }
}