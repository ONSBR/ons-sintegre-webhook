package br.org.ons.ons.sintegre.controller;

import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.Consumes;
import javax.ws.rs.core.Response;
import javax.ws.rs.client.Client;
import javax.ws.rs.client.ClientBuilder;
import br.org.ons.ons.sintegre.model.WebhookRequestModel;

/**
 * Controller para rebimento das notificações oriundas do SINtegre.
 * 
 * @author Jose Mauro da Silva Sandy - Rerum
 * @date 24/07/2019 13:04:41
 */
@Path("/webhook")
public class WebhookController {

    /**
     * Recebe o POST do ONS informando a existência de novas informações para um determinado produto.
     * @param request informações referentes ao produto.
     */
    @POST
    @Consumes("application/json; charset=UTF-8")
    @Produces("application/json; charset=UTF-8")
    public void post(WebhookRequestModel request) {
        // Retornar StatusCode 20X em caso de processamento com sucesso. Qualquer outro código será considerado erro e a mensagem reenviada.
        
        Client client = ClientBuilder.newClient();
        Response response = client.target(request.getUrl()).request().get();
        
        if (response.getStatus() == 200) {
            // Processar salvamento do arquivo.
        } else {
            // Processar retorno de erro.
        }
    }
}
