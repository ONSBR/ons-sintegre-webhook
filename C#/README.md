Exemplo webhook .Net Core (C#)
=============

Código de exemplo de um webhook em C# para receber notificações do [SINtegre](https://sintegre.ons.org.br).

````C#
        /// <summary>
        /// Recebe o POST do ONS informando a existência de novas informações para um determinado produto.
        /// </summary>
        /// <param name="request">informações referentes ao produto.</param>
        [HttpPost]
        public async void Post([FromBody] WebhookRequestModel request)
        {
            // Retornar StatusCode 20X em caso de processamento com sucesso. Qualquer outro código será considerado erro e a mensagem reenviada.
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(request.Url);
                if (response.IsSuccessStatusCode)
                {
                    // Processar salvamento do arquivo.
                }
                else
                {
                    // Processar retorno de erro.
                }
            }
        }
```
