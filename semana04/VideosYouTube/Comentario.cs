public class Comentario
{
    private string _nome;
    private string _texto;

    public Comentario(string nome, string texto)
    {
        _nome = nome;
        _texto = texto;
    }

    public string ObterNome() => _nome;
    public string ObterTexto() => _texto;
}
