using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using PesquisaCEP.Views;
using ViaCEP;
using Data;
using System.IO;

namespace PesquisaCEP.ViewModels
{
    public class ViewModelPesquisaLocal : BaseViewModel
    {
        private EnderecoCompleto _selectedItem;
        public ObservableCollection<EnderecoCompleto> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command<EnderecoCompleto> ItemTapped { get; }

        public ViewModelPesquisaLocal()
        {
            Title = "Browse";
            Items = new ObservableCollection<EnderecoCompleto>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<EnderecoCompleto>(OnItemSelected);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                Database db = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PesquisaCEP.db3"));
                var items = await db.ObterEnderecosAsync();
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public EnderecoCompleto SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }
        async void OnItemSelected(EnderecoCompleto item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(PaginaDetalhesCEP)}?{nameof(ViewModelDetalhesCEP.ItemId)}={item.CEP}");
        }
    }
}