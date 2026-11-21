using System;

public class Endereco
{
    private string _rua;
    private string _cidade;
    private string _estado;
    private string _pais;

    public Endereco(string rua, string cidade, string estado, string pais)
    {
        _rua = rua;
        _cidade = cidade;
        _estado = estado;
        _pais = pais;
    }

    public bool EstaNosEua()
    {
        string pais = _pais.Trim().ToUpperInvariant();
        return pais == "USA" || pais == "US" || pais == "UNITED STATES" ||
               pais == "UNITED STATES OF AMERICA" || pais == "ESTADOS UNIDOS" ||
               pais == "EUA";
    }

    public string ObterEnderecoCompleto() => $"{_rua}\n{_cidade}, {_estado}\n{_pais}";
}
