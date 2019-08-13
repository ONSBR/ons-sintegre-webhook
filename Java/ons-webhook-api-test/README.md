Exemplo webhook java
=============

Código de exemplo de um webhook em Java para receber notificações do [SINtegre](https://sintegre.ons.org.br).


```Java
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
```
