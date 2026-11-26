using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

public class AtividadeDeListagem : Atividade
{
    private int _contador;
    private readonly List<string> _perguntas = new()
    {
        "Quem são as pessoas que você aprecia?",
        "Quais são seus pontos fortes pessoais?",
        "Quem são as pessoas que você ajudou esta semana?",
        "Quando você sentiu o Espírito Santo neste mês?",
        "Quem são alguns dos seus heróis pessoais?"
    };

    private readonly Random _aleatorio = new();

    public AtividadeDeListagem()
        : base("Listagem", "Esta atividade ajudará você a refletir sobre as coisas boas da sua vida, fazendo com que liste o máximo de coisas que puder em uma determinada área.")
    {
    }

    private void ContarItem(string item)
    {
        if (!string.IsNullOrWhiteSpace(item))
        {
            _contador++;
        }
    }

    private void LerListaInterativa()
    {
        var texto = new StringBuilder();
        var relogio = Stopwatch.StartNew();
        Console.WriteLine("Digite um item por linha e pressione Enter:");
        Console.Write("> ");

        while (relogio.Elapsed.TotalSeconds < ObterDuracao())
        {
            if (!Console.KeyAvailable)
            {
                Thread.Sleep(10);
                continue;
            }

            ConsoleKeyInfo tecla = Console.ReadKey(intercept: true);
            if (tecla.Key == ConsoleKey.Enter)
            {
                ContarItem(texto.ToString());
                texto.Clear();
                Console.Write("\n> ");
            }
            else if (tecla.Key == ConsoleKey.Backspace && texto.Length > 0)
            {
                texto.Length--;
                Console.Write("\b \b");
            }
            else if (!char.IsControl(tecla.KeyChar))
            {
                texto.Append(tecla.KeyChar);
                Console.Write(tecla.KeyChar);
            }
        }

        // Conta também um último item não vazio ainda sem Enter ao acabar o tempo.
        ContarItem(texto.ToString());
        Console.WriteLine();
    }

    private void LerListaRedirecionada()
    {
        Console.WriteLine("Digite itens, um por linha. A sessão encerra ao atingir a duração.");
        var relogio = Stopwatch.StartNew();
        bool fimDaEntrada = false;

        while (relogio.Elapsed.TotalSeconds < ObterDuracao())
        {
            TimeSpan restante = TimeSpan.FromSeconds(ObterDuracao()) - relogio.Elapsed;
            if (fimDaEntrada)
            {
                // Mesmo que o arquivo termine cedo, mantém a duração solicitada.
                ExibirProgressoEmMilissegundos(Math.Max(1, (int)Math.Ceiling(restante.TotalMilliseconds)));
                continue;
            }

            if (!EntradaConsole.TentarLerLinha(restante, out string? item))
            {
                break;
            }

            if (string.IsNullOrWhiteSpace(item))
            {
                fimDaEntrada = true;
            }
            else
            {
                ContarItem(item);
            }
        }
    }

    public override bool Executar()
    {
        _contador = 0;
        if (!ExibirMensagemInicial())
        {
            return false;
        }

        Console.WriteLine($"--- {_perguntas[_aleatorio.Next(_perguntas.Count)]} ---");
        Console.Write("Você pode começar em: ");
        ExibirContagemRegressiva(3);
        Console.WriteLine("Comece sua lista!");

        if (Console.IsInputRedirected)
        {
            LerListaRedirecionada();
        }
        else
        {
            LerListaInterativa();
        }

        Console.WriteLine($"Você listou {_contador} item(ns)!");
        ExibirMensagemFinal();
        return true;
    }
}
