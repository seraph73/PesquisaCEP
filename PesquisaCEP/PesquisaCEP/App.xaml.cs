﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PesquisaCEP.Views;

namespace PesquisaCEP
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            DependencyService.Register<ViewModels.Services.IMessageService, Views.Services.MessageService>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
