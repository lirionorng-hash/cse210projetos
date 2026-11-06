namespace DiarioApp;

/// <summary>Escolhe perguntas motivadoras sem repeti-las em sequência.</summary>
public class GeradorDePerguntas
{
    private readonly List<string> _perguntas = new()
    {
        "Qual foi a melhor parte do meu dia?",
        "O que aprendi hoje que gostaria de lembrar?",
        "Quem me ajudou hoje e como posso agradecer?",
        "Que desafio enfrentei hoje e o que fiz para superá-lo?",
        "O que me fez sorrir hoje?",
        "Que atitude minha ajudou outra pessoa hoje?",
        "Que objetivo pequeno posso cumprir amanhã?"
    };

    private int _ultimoIndice = -1;

    public string ObterPerguntaAleatoria()
    {
        int indice;
        do
        {
            indice = Random.Shared.Next(_perguntas.Count);
        } while (_perguntas.Count > 1 && indice == _ultimoIndice);

        _ultimoIndice = indice;
        return _perguntas[indice];
    }
}
