using System;
using System.Collections.Generic;
using System.Diagnostics;

public class AtividadeDeReflexao : Atividade
{
    private readonly List<string> _reflexoes = new()
    {
        "Pense em uma ocasião em que você defendeu outra pessoa.",
        "Pense em uma ocasião em que fez algo realmente difícil.",
        "Pense em uma ocasião em que ajudou alguém necessitado.",
        "Pense em uma ocasião em que demonstrou coragem.",
        "Pense em uma ocasião em que superou um desafio."
    };

    private readonly List<string> _perguntas = new()
    {
        "Por que essa experiência foi significativa para você?",
        "Como você começou?",
        "Como você se sentiu quando terminou?",
        "O que você aprendeu sobre si mesmo?",
        "O que tornou esse momento diferente?",
        "O que pode aplicar dessa experiência em outras situações?",
        "Como pode lembrar dessa experiência no futuro?",
        "Quem contribuiu para esse resultado?"
    };

    private readonly Random _aleatorio = new();
    private readonly List<string> _perguntasDisponiveis = new();

    public AtividadeDeReflexao()
        : base("Reflexão", "Esta atividade ajudará você a lembrar momentos em que demonstrou força e resiliência.")
    {
    }

    private string ObterReflexoesAleatorias()
    {
        return _reflexoes[_aleatorio.Next(_reflexoes.Count)];
    }

    private string ObterPerguntasAleatorias()
    {
        // Criatividade: nenhuma pergunta se repete antes de todas terem sido usadas.
        if (_perguntasDisponiveis.Count == 0) _perguntasDisponiveis.AddRange(_perguntas);
        int indice = _aleatorio.Next(_perguntasDisponiveis.Count);
        string pergunta = _perguntasDisponiveis[indice];
        _perguntasDisponiveis.RemoveAt(indice);
        return pergunta;
    }

    public override bool Executar()
    {
        if (!ExibirMensagemInicial()) return false;
        Console.WriteLine("Considere esta experiência:");
        Console.WriteLine($"--- {ObterReflexoesAleatorias()} ---");
        Console.WriteLine("Pense nela por alguns segundos:");
        ExibirContagemRegressiva(3);
        Console.WriteLine("Agora reflita sobre estas perguntas:");

        var relogio = Stopwatch.StartNew();
        while (relogio.Elapsed.TotalSeconds < ObterDuracao())
        {
            Console.Write($"> {ObterPerguntasAleatorias()}  ");
            int restante = Math.Max(1, ObterDuracao() - (int)relogio.Elapsed.TotalSeconds);
            ExibirProgresso(Math.Min(4, restante));
            Console.WriteLine();
        }

        ExibirMensagemFinal();
        return true;
    }
}
