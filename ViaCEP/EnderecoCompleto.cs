using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViaCEP
{
    /// <summary>
    /// Esta classe encapsula o resultado das consultas de CEP, 
    /// de forma que todas as informações sejam contidas em uma
    /// instância da mesma.
    /// </summary>
    public class EnderecoCompleto
    {
        /// <summary>
        /// Recupera ou Insere o número do CEP.
        /// </summary>
        [JsonProperty("cep")]
        public string CEP { get; set; }

        /// <summary>
        /// Recupera ou Insere o nome da Rua.
        /// </summary>
        [JsonProperty("logradouro")]
        public string Rua { get; set; }

        /// <summary>
        /// Recupera ou Insere um Complemento.
        /// </summary>
        [JsonProperty("complemento")]
        public string Complemento { get; set; }

        /// <summary>
        /// Recupera ou Insere o nome do Bairro.
        /// </summary>
        [JsonProperty("bairro")]
        public string Bairro { get; set; }

        /// <summary>
        /// Recupera ou Insere o nome da Cidade.
        /// </summary>
        [JsonProperty("localidade")]
        public string Cidade { get; set; }

        /// <summary>
        /// Recupera ou Insere as iniciais do Estado (Unidade Federativa).
        /// </summary>
        [JsonProperty("uf")]
        public string Estado { get; set; }

        /// <summary>
        /// Recupera ou Insere o código do IBGE.
        /// </summary>
        [JsonProperty("ibge")]
        public int CodigoIBGE { get; set; }

        /// <summary>
        /// Recupera ou Insere o código de GIA.
        /// </summary>
        [JsonProperty("gia")]
        public int? CodigoGIA { get; set; }

        /// <summary>
        /// Recupera ou Insere o DDD.
        /// </summary>
        [JsonProperty("ddd")]
        public int DDD { get; set; }

        /// <summary>
        /// Recupera ou Insere o código de SIAFI.
        /// </summary>
        [JsonProperty("siafi")]
        public int? CodigoSIAFI { get; set; }

        public override string ToString()
        {
            return $"CEP: {CEP}{Environment.NewLine}" +
                $"Rua: {Rua}{Environment.NewLine}" +
                $"Complemento: {Complemento}{Environment.NewLine}" +
                $"Bairro: {Bairro}{Environment.NewLine}" +
                $"Cidade: {Cidade}{Environment.NewLine}" +
                $"Estado: {Estado}{Environment.NewLine}" +
                $"Código do IBGE: {CodigoIBGE}{Environment.NewLine}" +
                $"Código do GIA: {CodigoGIA}{Environment.NewLine}" +
                $"Código do SIAFI: {CodigoSIAFI}{Environment.NewLine}" +
                $"DDD: {DDD}";
        }
    }
}
