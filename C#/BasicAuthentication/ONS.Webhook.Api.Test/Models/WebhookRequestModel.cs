using System;

namespace ONS.Webhook.Api.Test.Models
{
    /// <summary>
    /// Model com as informações relativas a requisição recebida para processamento do webhook.
    /// </summary>
    /// <Author>Jose Mauro da Silva Sandy - Rerum</Author>
    /// <Date>19/07/2019 11:50:34</Date>
    public partial class WebhookRequestModel
    {
        public string Url { get; set; }

        public string Nome { get; set; }

        public string DataProduto { get; set; }

        public string Processo { get; set; }

        public string MacroProcesso { get; set; }

        public DateTime Periodicidade { get; set; }

        public DateTime PeriodicidadeFinal { get; set; }
    }
}
