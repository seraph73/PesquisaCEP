using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViaCEP;

namespace Data
{
    public class Database
    {
        readonly SQLiteConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteConnection(dbPath);
            _database.CreateTable<EnderecoCompleto>();
        }

        public List<EnderecoCompleto> ObterEnderecos()
        {
            return (from data in _database.Table<EnderecoCompleto>()
                    select data).ToList();
        }

        public async Task<IEnumerable<EnderecoCompleto>> ObterEnderecosAsync()
        {
            return await Task.FromResult((from data in _database.Table<EnderecoCompleto>()
                                          select data));
        }

        public bool CepJaSalvo(string cep)
        {
            if(_database.Table<EnderecoCompleto>().FirstOrDefault(t => t.CEP == cep) == null)
            {
                return false;
            }
            return true;
        }

        public EnderecoCompleto ObterEndereco(string cep)
        {
            return _database.Table<EnderecoCompleto>().FirstOrDefault(t => t.CEP == cep);
        }

        public int SalvarEndereco(EnderecoCompleto enderecoCompleto)
        {
            return _database.Insert(enderecoCompleto);            
        }
    }
}
