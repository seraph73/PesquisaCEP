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
    public class ViewModelPesquisarCEP : BaseViewModel
    {
        private string cep;
        private string resultadoString;
        private ResultadoConsulta resultadoConsulta;
        public Command ComandoPesquisar { get; }

        public ViewModelPesquisarCEP()
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

        public string ResultadoString
        {
            get => resultadoString;
            set => SetProperty(ref resultadoString, value);
        }

        private async void Pesquisar()
        {
            
            var current = Connectivity.NetworkAccess;
            if (current == NetworkAccess.Internet)
            {
                Consulta consulta = new Consulta();
                try
                {
                    resultadoConsulta = consulta.Buscar(CEP);
                    ResultadoString = resultadoConsulta.ToString();
                }
                catch(Exception ex)
                {
                    ResultadoString = "Ocorreu um erro! Verifique se o CEP está correto e tente novamente.";
                }
                
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
