// Guarda uma palavra e controla se ela esta visivel ou oculta.
public class Palavra
{
    private string _texto;
    private bool _estaOculta;

    public Palavra(string texto)
    {
        _texto = texto;
        _estaOculta = false;
    }

    public void Ocultar()
    {
        _estaOculta = true;
    }

    public void Exibir()
    {
        Console.Write(ObterTexto());
    }

    public bool EstaOculta()
    {
        return _estaOculta;
    }

    public string ObterTexto()
    {
        if (!_estaOculta)
        {
            return _texto;
        }

        // Mantem a pontuacao, mas troca letras e numeros por sublinhados.
        return new string(_texto.Select(caractere =>
            char.IsLetterOrDigit(caractere) ? '_' : caractere).ToArray());
    }
}
