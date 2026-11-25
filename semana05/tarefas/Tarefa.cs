// Classe base: os dados e comportamentos comuns ficam aqui.
public class Tarefa
{
    private string _nomeEstudante;
    private string _topico;

    public Tarefa(string nomeEstudante, string topico)
    {
        _nomeEstudante = nomeEstudante;
        _topico = topico;
    }

    public string ObterNomeEstudante()
    {
        return _nomeEstudante;
    }

    public string ObterTopico()
    {
        return _topico;
    }

    public string ObterResumo()
    {
        return $"{_nomeEstudante} - {_topico}";
    }
}
