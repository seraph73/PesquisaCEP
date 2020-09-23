using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ViaCEP
{
    public class Consulta
    {

        /// <summary>
        /// URL do site ViaCEP
        /// </summary>
        private const string UrlViaCEP = "https://viacep.com.br";
        
        /// <summary>
        /// Cliente HTTP.
        /// </summary>
        private readonly HttpClient _clienteHTTP;

        public Consulta()
        {
            _clienteHTTP = HttpClientFactory.Create();
            _clienteHTTP.BaseAddress = new Uri(UrlViaCEP);
        }

        public EnderecoCompleto Buscar(string zipCode)
        {
            return BuscarAssincronamente(zipCode, CancellationToken.None).Result;
        }

        private async Task<EnderecoCompleto> BuscarAssincronamente(string zipCode, CancellationToken cancellationToken)
        {
            var Resposta = await _clienteHTTP.GetAsync($"/ws/{zipCode}/json", cancellationToken).ConfigureAwait(false);
            

            Resposta.EnsureSuccessStatusCode();
            return await Resposta.Content.ReadAsAsync<EnderecoCompleto>(cancellationToken).ConfigureAwait(false);

        }
    }
}
