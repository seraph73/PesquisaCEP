using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PesquisaCEP.ViewModels;
using System.Text.RegularExpressions;
using Xamarin.Essentials;
using System.Runtime.CompilerServices;

namespace PesquisaCEP.Views
{
    public partial class PaginaPesquisarCEP : ContentPage
    {
        public PaginaPesquisarCEP()
        {
            InitializeComponent();
            var current = Connectivity.NetworkAccess;
            if (current != NetworkAccess.Internet)
            {
                EsconderPesquisa();
            }            
            BindingContext = new ViewModelPesquisarCEP();
            BindingContextChanged += (object sender, EventArgs e) => { MessagingCenter.Send<Page>(this, "BindingContextChanged.ViewModelPesquisarCEP"); };
        }

        private void EntryCep_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(e.NewTextValue.Length != 8 || string.IsNullOrEmpty(e.NewTextValue))
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
            if (!double.TryParse(e.NewTextValue, out _) || e.NewTextValue[e.NewTextValue.Length - 1] == '.' || e.NewTextValue.Length > 8)
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

        private void LabelResultado_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(!string.IsNullOrEmpty(LabelResultado.Text))
            {
                ButtonSalvar.IsEnabled = true;
            }
            else
            {
                ButtonSalvar.IsEnabled = false;
            }
        }
    }
}