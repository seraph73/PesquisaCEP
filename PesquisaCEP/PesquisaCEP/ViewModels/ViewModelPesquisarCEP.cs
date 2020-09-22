using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Input;
using Data;
using PesquisaCEP.Models;
using PesquisaCEP.Services;
using PesquisaCEP.ViewModels.Services;
using PesquisaCEP.Views;
using ViaCEP;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PesquisaCEP.ViewModels
{
    public class ViewModelPesquisarCEP : BaseViewModel
    {
        private string cep;
        private string resultadoString;
        private EnderecoCompleto resultadoConsulta;
        public Command ComandoPesquisar { get; }
        public Command ComandoSalvar { get; }
        private readonly IMessageService messageService;
        public ViewModelPesquisarCEP()
        {
            ComandoPesquisar = new Command(Pesquisar, Validate);
            ComandoSalvar = new Command(Salvar);
            resultadoConsulta = new EnderecoCompleto();
            messageService = DependencyService.Get<IMessageService>();
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
        
        private void Salvar()
        {
            Database db = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PesquisaCEP.db3"));
            if (db.CepJaSalvo(resultadoConsulta.CEP))
            {
                messageService.ShowAsync("Este CEP já está salvo.");
            }
            else
            {
                int result = db.SalvarEndereco(resultadoConsulta);
                if (result >= 1)
                {
                    messageService.ShowAsync("CEP salvo com sucesso.");
                }
                else
                {
                    messageService.ShowAsync("Ocorreu um erro e por isso o CEP não foi salvo.");
                }
            }
        }

        private void Pesquisar()
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
        }
    }
}
