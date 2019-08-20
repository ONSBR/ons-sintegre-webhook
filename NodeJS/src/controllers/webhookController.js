exports.post = (req, res, next) => {

    console.log(req.headers["authorization"]);
    // // valida token (neste exemplo, uma string simples "ninguemsabe" mas pode ser JWT ou qualquer código sendo enviado no header authorization)
    // if ("ninguemsabe" !== req.headers["authorization"]) {
    //     console.log('Requisição recebida com autenticação inválida!');
    //     res.sendStatus(401);
    //     return;
    // }

    console.log("Requisição recebida com sucesso.")

    // imprime os parâmetros recebidos
    console.log(req.body);
    console.log(req.headers);
    // busca o arquivo recebido do SINtegre no parâmetro url
    const http = require('https');
    http.get(req.body.url, (resp) => {

        console.log(resp.statusCode);
        if (resp.statusCode == "200") {
            let arquivo = '';

            // A chunk of data has been recieved.
            resp.on('data', (chunk) => {
                arquivo += chunk;
                console.log("baixando..." + arquivo.length);
            });
    
            // The whole response has been received. Print out the result.
            resp.on('end', () => {
                console.log("Arquivo baixado com sucesso! Tamanho em bytes: " + arquivo.length);
            });    
        } else {
            console.error("Erro ao baixar arquivo! " + resp.statusCode + " - " + resp.statusMessage);
        }

    }).on("error", (err) => {
            console.log("Error: " + err.message);
    });

    res.sendStatus(200);

};