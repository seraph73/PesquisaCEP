using System.ComponentModel;
using Xamarin.Forms;
using PesquisaCEP.ViewModels;

namespace PesquisaCEP.Views
{
    public partial class PaginaDetalhesCEP : ContentPage
    {
        public PaginaDetalhesCEP()
        {
            InitializeComponent();
            BindingContext = new ViewModelDetalhesCEP();
        }
    }
}