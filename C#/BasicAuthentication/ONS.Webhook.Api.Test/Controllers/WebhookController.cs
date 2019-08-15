using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using ONS.Webhook.Api.Test.Models;
using Microsoft.AspNetCore.Authorization;

namespace ONS.Webhook.Api.Test.Controllers
{
    /// <summary>
    /// Controller para rebimento das notificações oriundas do SINtegre.
    /// </summary>
    /// <Author>Jose Mauro da Silva Sandy - Rerum</Author>
    /// <Date>19/07/2019 11:46:07</Date>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public partial class WebhookController : ControllerBase
    {
        #region Api Methods

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

        #endregion  
    }
}
