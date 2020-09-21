using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using PesquisaCEP.Models;
using PesquisaCEP.ViewModels;
using System.Text.RegularExpressions;
using Xamarin.Essentials;

namespace PesquisaCEP.Views
{
    public partial class PaginaPesquisarCEP : ContentPage
    {
        public Item Item { get; set; }

        public PaginaPesquisarCEP()
        {
            InitializeComponent();
            var current = Connectivity.NetworkAccess;
            if (current != NetworkAccess.Internet)
            {
                EsconderPesquisa();
            }
            BindingContext = new ViewModelPesquisarCEP();
        }
        
        private void EntryCep_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(String.IsNullOrWhiteSpace(e.NewTextValue))
            {
                ButtonPesquisar.IsEnabled = false;
            }
            else
            {
                ButtonPesquisar.IsEnabled = true;
            }

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

        private void Button_Clicked(object sender, EventArgs e)
        {
            var current = Connectivity.NetworkAccess;
            if (current == NetworkAccess.Internet)
            {
                EsconderConexao();
            }
        }

        private void ButtonPesquisar_Clicked(object sender, EventArgs e)
        {
            var current = Connectivity.NetworkAccess;
            if (current != NetworkAccess.Internet)
            {
                EsconderPesquisa();
            }
        }

        public void EsconderConexao()
        {
            StackLayoutPesquisa.IsVisible = true;
            StackLayoutConexaoInternet.IsVisible = false;
        }

        public void EsconderPesquisa()
        {
            StackLayoutPesquisa.IsVisible = false;
            StackLayoutConexaoInternet.IsVisible = true;
        }
    }
}