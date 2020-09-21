using System;
using System.Collections.Generic;
using PesquisaCEP.ViewModels;
using PesquisaCEP.Views;
using Xamarin.Forms;

namespace PesquisaCEP
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
