using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PesquisaCEP.Views.Services
{
    public class MessageService : ViewModels.Services.IMessageService
    {
        public async Task ShowAsync(string message)
        {
            await App.Current.MainPage.DisplayAlert("Alerta", message, "OK");
        }
    }
}
