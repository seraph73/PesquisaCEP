using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using PesquisaCEP.Models;
using ViaCEP;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PesquisaCEP.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string cep;
        private ResultadoConsulta resultadoConsulta;
        public Command ComandoPesquisar { get; }

        public NewItemViewModel()
        {
            ComandoPesquisar = new Command(Pesquisar, Validate);
            resultadoConsulta = new ResultadoConsulta();
            this.PropertyChanged +=
                (_, __) => ComandoPesquisar.ChangeCanExecute();
        }

        private bool Validate()
        {
            return false;
        }

        public string CEP
        {
            get => cep;
            set => SetProperty(ref cep, value);
        }

        private async void Pesquisar()
        {
            var current = Connectivity.NetworkAccess;
            if (current == NetworkAccess.Internet)
            {
                Consulta consulta = new Consulta();
                resultadoConsulta = consulta.Buscar(CEP);
            }            

            /*
            Item newItem = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                Text = Text
            };

            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");*/
        }
    }
}
