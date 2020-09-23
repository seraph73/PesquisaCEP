using PesquisaCEP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PesquisaCEP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaPesquisaLocal : ContentPage
    {
        ViewModelPesquisaLocal _viewModel;
        public PaginaPesquisaLocal()
        {
            InitializeComponent();
            BindingContext = _viewModel = new ViewModelPesquisaLocal();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}