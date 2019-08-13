package br.org.ons.ons.sintegre.model;

import java.util.Date;
import javax.xml.bind.annotation.XmlAttribute;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;

/**
 * Model com as informações relativas a requisição recebida para processamento
 * do webhook.
 *
 * @author Jose Mauro da Silva Sandy - Rerum
 * @date 24/07/2019 14:16:39
 */
public class WebhookRequestModel {

    private String url;

    private String nome;

    private String dataProduto;

    private String processo;

    private String macroProcesso;

    private Date periodicidade;

    private Date periodicidadeFinal;

    /**
     * @return the url
     */
    public String getUrl() {
        return url;
    }

    /**
     * @param url the url to set
     */
    public void setUrl(String url) {
        this.url = url;
    }

    /**
     * @return the nome
     */
    public String getNome() {
        return nome;
    }

    /**
     * @param nome the nome to set
     */
    public void setNome(String nome) {
        this.nome = nome;
    }

    /**
     * @return the dataProduto
     */
    public String getDataProduto() {
        return dataProduto;
    }

    /**
     * @param dataProduto the dataProduto to set
     */
    public void setDataProduto(String dataProduto) {
        this.dataProduto = dataProduto;
    }

    /**
     * @return the processo
     */
    public String getProcesso() {
        return processo;
    }

    /**
     * @param processo the processo to set
     */
    public void setProcesso(String processo) {
        this.processo = processo;
    }

    /**
     * @return the macroProcesso
     */
    public String getMacroProcesso() {
        return macroProcesso;
    }

    /**
     * @param macroProcesso the macroProcesso to set
     */
    public void setMacroProcesso(String macroProcesso) {
        this.macroProcesso = macroProcesso;
    }

    /**
     * @return the periodicidade
     */
    public Date getPeriodicidade() {
        return periodicidade;
    }

    /**
     * @param periodicidade the periodicidade to set
     */
    public void setPeriodicidade(Date periodicidade) {
        this.periodicidade = periodicidade;
    }

    /**
     * @return the periodicidadeFinal
     */
    public Date getPeriodicidadeFinal() {
        return periodicidadeFinal;
    }

    /**
     * @param periodicidadeFinal the periodicidadeFinal to set
     */
    public void setPeriodicidadeFinal(Date periodicidadeFinal) {
        this.periodicidadeFinal = periodicidadeFinal;
    }
}
