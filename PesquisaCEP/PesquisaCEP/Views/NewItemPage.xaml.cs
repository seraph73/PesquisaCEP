using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using PesquisaCEP.Models;
using PesquisaCEP.ViewModels;
using System.Text.RegularExpressions;

namespace PesquisaCEP.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
        
        private void EntryCep_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                (sender as Entry).Text = "";
                return;
            }

            double _;
            if (!double.TryParse(e.NewTextValue, out _) || e.NewTextValue[e.NewTextValue.Length - 1] == '.')
            {
                (sender as Entry).Text = e.OldTextValue;
                ShakeItOff();
            }
        }
        async void ShakeItOff()
        {
            uint timeout = 50;

            await EntryCep.TranslateTo(-15, 0, timeout);

            await EntryCep.TranslateTo(15, 0, timeout);

            await EntryCep.TranslateTo(-10, 0, timeout);

            await EntryCep.TranslateTo(10, 0, timeout);

            await EntryCep.TranslateTo(-5, 0, timeout);

            await EntryCep.TranslateTo(5, 0, timeout);

            EntryCep.TranslationX = 0;

        }
    }
}