// A classe de redação reutiliza os dados comuns da classe Tarefa.
public class TarefaDeRedacao : Tarefa
{
    private string _titulo;

    public TarefaDeRedacao(string nomeEstudante, string topico,
        string titulo) : base(nomeEstudante, topico)
    {
        _titulo = titulo;
    }

    public string ObterInformacaoDaRedacao()
    {
        // O nome é privado na classe Tarefa: acessamos pelo método público.
        return $"{_titulo}, por {ObterNomeEstudante()}";
    }

    // Nome alternativo usado no enunciado da atividade.
    public string ObterInformacoesDaRedacao()
    {
        return ObterInformacaoDaRedacao();
    }
}
