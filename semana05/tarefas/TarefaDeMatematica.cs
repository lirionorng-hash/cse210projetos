// A classe de matemática herda nome e tópico da classe Tarefa.
public class TarefaDeMatematica : Tarefa
{
    private string _capitulo;
    private string _problemas;

    public TarefaDeMatematica(string nomeEstudante, string topico,
        string capitulo, string problemas) : base(nomeEstudante, topico)
    {
        _capitulo = capitulo;
        _problemas = problemas;
    }

    public string ObterListaDeTarefas()
    {
        return $"Capítulo {_capitulo} Problemas {_problemas}";
    }
}
