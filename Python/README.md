Exemplo webhook NodeJS
=============

Código de exemplo de um webhook em NodeJS para receber notificações do [SINtegre](https://sintegre.ons.org.br).

## Pré-requisito

Instalar o python e o pip e instalar os pacotes abaixo

```
pip install django
pip install djangorestframework
````

## Como executar

```
python manage.py runserver
```

## Exemplo

```Python
# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.shortcuts import render

import json
import urllib

from django.http import HttpResponse
from django.views.decorators.csrf import csrf_exempt
from django.views.decorators.http import require_POST

@csrf_exempt
@require_POST
def webhook(request):
    jsondata = request.body
    data = json.loads(jsondata)
    print jsondata

    try:
        # tenta baixar o arquivo a partir da url recebida
        arquivo = urllib.urlretrieve(data['url'])
    except:
        print "Erro ao recuperar arquivo."
        return HttpResponse(status=500)
    else:
        # abre o arquivo e trata o que fazer com ele
        contents = open(arquivo[0]).read()
        print "sucesso ao recuperar arquivo."

    return HttpResponse(status=201)
```
