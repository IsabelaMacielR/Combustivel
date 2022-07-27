using Combustivel.Models;
using Combustivel.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Combustivel.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();

            

            BindingContext = new NewItemViewModel();

            /*var Description = new List<string>
            {
                "Teste1",
                "Teste2",
                "Teste3",
                "Teste4"
            };

            Descriptions.ItemsSource = Description;*/
        }

        private void NewItemPicker_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}