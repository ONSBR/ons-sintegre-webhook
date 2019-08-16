# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.shortcuts import render

import json
import urllib

from django.http import HttpResponse
from django.views.decorators.csrf import csrf_exempt
from django.views.decorators.http import require_POST

import re

@csrf_exempt
@require_POST
def webhook(request):

    # imprime valores do body
    jsondata = request.body
    print jsondata
    body = json.loads(jsondata)
    
    # imprime valores do header http
    regex = re.compile('^HTTP_')
    header = dict((regex.sub('', header), value) for (header, value) 
       in request.META.items() if header.startswith('HTTP_'))
    print header

    try:
        # tenta baixar o arquivo a partir da url recebida
        arquivo = urllib.urlretrieve(body['url'])
    except:
        print "Erro ao recuperar arquivo."
        return HttpResponse("Erro ao recuperar arquivo",status=500)
    else:
        # abre o arquivo e trata o que fazer com ele
        contents = open(arquivo[0]).read()
        print "sucesso ao recuperar arquivo."

    return HttpResponse("Ok",status=201)