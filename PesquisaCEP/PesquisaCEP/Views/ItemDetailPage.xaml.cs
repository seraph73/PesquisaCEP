using System.ComponentModel;
using Xamarin.Forms;
using PesquisaCEP.ViewModels;

namespace PesquisaCEP.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}