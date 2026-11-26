using System;
using System.Threading;

/// <summary>
/// Classe base de todas as atividades de introspecção.
/// Guarda o nome, a descrição e a duração e concentra os comportamentos comuns:
/// mensagem inicial, mensagem final, pausas e animações com retrocesso.
/// </summary>
public abstract class Atividade
{
    private readonly string _nome;
    private readonly string _descricao;
    private int _duracao;

    protected Atividade(string nome, string descricao)
    {
        _nome = nome;
        _descricao = descricao;
    }

    public string Nome => _nome;

    protected int ObterDuracao() => _duracao;

    /// <summary>Executa o roteiro completo da atividade escolhida.</summary>
    public abstract bool Executar();

    /// <summary>
    /// Cada atividade pode impor um limite próprio de duração.
    /// Retorna null quando o valor é aceito ou a mensagem que explica a correção.
    /// </summary>
    protected virtual string? ValidarDuracao(int segundos) => null;

    /// <summary>
    /// Mostra o nome e a descrição, pede a duração e faz a preparação.
    /// Retorna false apenas quando a entrada de dados termina antes da resposta.
    /// </summary>
    public bool ExibirMensagemInicial()
    {
        LimparTela();
        Console.WriteLine($"Bem-vindo à atividade de {_nome}!\n");
        Console.WriteLine(_descricao);
        Console.WriteLine();

        while (true)
        {
            Console.Write("Por quantos segundos deseja realizar esta atividade? ");
            string? entrada = EntradaConsole.LerLinha();

            if (entrada is null)
            {
                Console.WriteLine();
                Console.WriteLine("Entrada de dados encerrada. Voltando ao menu.");
                return false;
            }

            if (!int.TryParse(entrada, out int duracao) || duracao <= 0 || duracao > 3600)
            {
                Console.WriteLine("Digite um número inteiro entre 1 e 3600.");
                continue;
            }

            string? aviso = ValidarDuracao(duracao);
            if (aviso is not null)
            {
                Console.WriteLine(aviso);
                continue;
            }

            _duracao = duracao;
            break;
        }

        LimparTela();
        Console.WriteLine("Prepare-se para começar...");
        ExibirProgresso(3);
        Console.WriteLine();
        return true;
    }

    /// <summary>Elogia o usuário e informa a atividade concluída e a duração.</summary>
    public void ExibirMensagemFinal()
    {
        Console.WriteLine("\nMuito bem! Você concluiu a atividade.");
        ExibirProgresso(2);
        Console.WriteLine($"\nVocê completou {_duracao} segundo(s) da atividade de {_nome}.");
        ExibirProgresso(2);
        Console.WriteLine();
    }

    /// <summary>Animação com retrocesso: desenha, apaga e redesenha o mesmo ponto.</summary>
    protected void ExibirProgresso(int segundos)
    {
        ExibirProgressoEmMilissegundos(segundos * 1000);
    }

    protected void ExibirProgressoEmMilissegundos(int milissegundos)
    {
        char[] quadros = { '|', '/', '-', '\\' };
        int restante = Math.Max(0, milissegundos);
        int i = 0;

        while (restante > 0)
        {
            Console.Write(quadros[i % quadros.Length]);
            int pausa = Math.Min(200, restante);
            Thread.Sleep(pausa);
            restante -= pausa;
            i++;
            Console.Write("\b \b");
        }
    }

    protected void ExibirContagemRegressiva(int segundos)
    {
        ExibirContagemEmMilissegundos(segundos * 1000);
    }

    // A última fração de segundo também é animada, sem ultrapassar o orçamento.
    protected void ExibirContagemEmMilissegundos(int milissegundos)
    {
        while (milissegundos > 0)
        {
            string texto = (milissegundos / 1000.0).ToString("0.#");
            Console.Write(texto);
            int pausa = Math.Min(1000, milissegundos);
            Thread.Sleep(pausa);
            Console.Write(new string('\b', texto.Length) + new string(' ', texto.Length) + new string('\b', texto.Length));
            milissegundos -= pausa;
        }

        Console.WriteLine();
    }

    /// <summary>Console.Clear falha quando a saída está redirecionada; nesse caso, não limpa.</summary>
    protected static void LimparTela()
    {
        try
        {
            Console.Clear();
        }
        catch (System.IO.IOException)
        {
            // Sem terminal interativo, seguir sem limpar é o comportamento correto.
        }
    }
}
