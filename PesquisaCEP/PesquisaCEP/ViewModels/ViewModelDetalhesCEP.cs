using Data;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PesquisaCEP.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ViewModelDetalhesCEP : BaseViewModel
    {
        private string itemId;
        private string resultadostring;
        public string Id { get; set; }

        public string ResultadoString
        {
            get => resultadostring;
            set => SetProperty(ref resultadostring, value);
        }

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public void LoadItemId(string itemId)
        {
            try
            {
                Database db = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PesquisaCEP.db3"));
                var item =  db.ObterEndereco(itemId);
                ResultadoString = item.ToString();
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
