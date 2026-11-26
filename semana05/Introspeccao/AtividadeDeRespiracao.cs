using System;
using System.Diagnostics;

/// <summary>Divide cada ciclo entre inspiração e expiração, inclusive em sessões de 1 s.</summary>
public class AtividadeDeRespiracao : Atividade
{
    public AtividadeDeRespiracao()
        : base("Respiração", "Esta atividade ajudará você a relaxar, inspirando e expirando lentamente. Limpe sua mente e concentre-se na sua respiração.")
    {
    }

    public override bool Executar()
    {
        if (!ExibirMensagemInicial())
        {
            return false;
        }

        int totalMilissegundos = ObterDuracao() * 1000;
        var relogio = Stopwatch.StartNew();
        while (true)
        {
            int restante = totalMilissegundos - (int)relogio.ElapsedMilliseconds;
            if (restante <= 1)
            {
                break;
            }

            // Cada ciclo tem no máximo 8 s: metade para cada fase.
            // Em uma sessão de 1 s, cada fase recebe aproximadamente 0,5 s.
            int ciclo = Math.Min(8000, restante);
            int inspiracao = ciclo / 2;
            int expiracao = ciclo - inspiracao;
            Console.Write("Inspire... ");
            ExibirContagemEmMilissegundos(inspiracao);
            Console.Write("Expire... ");
            ExibirContagemEmMilissegundos(expiracao);
            Console.WriteLine();
        }

        ExibirMensagemFinal();
        return true;
    }
}
