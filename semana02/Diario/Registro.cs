namespace DiarioApp;

/// <summary>Representa uma única entrada do diário.</summary>
public class Registro
{
    private string _data;
    private string _textoPergunta;
    private string _textoResposta;

    // As propriedades públicas permitem que System.Text.Json salve e recupere
    // os dados sem expor diretamente as variáveis membro privadas.
    public string Data
    {
        get => _data;
        set => _data = value ?? string.Empty;
    }

    public string Pergunta
    {
        get => _textoPergunta;
        set => _textoPergunta = value ?? string.Empty;
    }

    public string Resposta
    {
        get => _textoResposta;
        set => _textoResposta = value ?? string.Empty;
    }

    // Necessário para recuperar um registro a partir do JSON.
    public Registro()
    {
        _data = string.Empty;
        _textoPergunta = string.Empty;
        _textoResposta = string.Empty;
    }

    public Registro(string data, string textoPergunta, string textoResposta)
    {
        _data = data;
        _textoPergunta = textoPergunta;
        _textoResposta = textoResposta;
    }

    public void Exibir()
    {
        Console.WriteLine($"Data: {_data}");
        Console.WriteLine($"Pergunta: {_textoPergunta}");
        Console.WriteLine($"Resposta: {_textoResposta}");
        Console.WriteLine(new string('-', 48));
    }
}
