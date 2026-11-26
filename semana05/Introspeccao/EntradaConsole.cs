using System;
using System.Threading.Tasks;

/// <summary>
/// Centraliza a leitura redirecionada para que exista somente uma leitura pendente.
/// Uma leitura que ultrapassa o prazo permanece disponível para a próxima chamada;
/// não são criadas várias tarefas concorrentes disputando Console.In.
/// </summary>
public static class EntradaConsole
{
    private static Task<string?>? _leituraPendente;

    private static Task<string?> ObterLeituraPendente()
    {
        _leituraPendente ??= Task.Run(() => Console.ReadLine());
        return _leituraPendente;
    }

    public static string? LerLinha()
    {
        if (!Console.IsInputRedirected)
        {
            return Console.ReadLine();
        }

        string? linha = ObterLeituraPendente().GetAwaiter().GetResult();
        _leituraPendente = null;
        return linha;
    }

    /// <summary>
    /// Retorna false quando o prazo acaba. Retorna true e null quando chega EOF.
    /// Usado somente na listagem com entrada redirecionada.
    /// </summary>
    public static bool TentarLerLinha(TimeSpan prazo, out string? linha)
    {
        linha = null;
        if (prazo <= TimeSpan.Zero)
        {
            return false;
        }

        Task<string?> leitura = ObterLeituraPendente();
        if (!leitura.Wait(prazo))
        {
            return false;
        }

        linha = leitura.GetAwaiter().GetResult();
        _leituraPendente = null;
        return true;
    }
}
