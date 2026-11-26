using System;
using System.Collections.Generic;
using System.Text;

// CSE 210 S05 — Programa de Introspecção.
// Criatividade e melhorias além dos requisitos básicos:
// 1. As perguntas de reflexão não se repetem até esgotar todas as disponíveis.
//    As instâncias são mantidas entre sessões, preservando esse controle no menu.
// 2. O menu conta as sessões concluídas por atividade durante esta execução.
//    Sessões canceladas por falta de entrada não são contadas. Não há histórico em disco.
// 3. A listagem termina no prazo tanto no terminal interativo quanto com stdin
//    redirecionado, inclusive quando um pipe permanece aberto sem enviar dados.
//    Uma única leitura pendente é compartilhada para evitar leituras concorrentes.
// 4. A respiração divide o tempo entre Inspire e Expire, inclusive em sessões de 1 s.
// 5. Validação de opções e duração, tratamento do fim da entrada e UTF-8 explícito.
// A herança concentra nome, descrição, duração, início, fim e animações em Atividade.

public class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        var atividades = new Dictionary<string, Atividade>
        {
            ["1"] = new AtividadeDeRespiracao(),
            ["2"] = new AtividadeDeReflexao(),
            ["3"] = new AtividadeDeListagem()
        };
        var concluidas = new Dictionary<string, int>
        {
            ["Respiração"] = 0,
            ["Reflexão"] = 0,
            ["Listagem"] = 0
        };

        while (true)
        {
            Console.WriteLine("\nMenu de atividades:");
            Console.WriteLine("  1. Iniciar atividade de respiração");
            Console.WriteLine("  2. Iniciar atividade de reflexão");
            Console.WriteLine("  3. Iniciar atividade de listagem");
            Console.WriteLine("  4. Sair");
            Console.Write("Escolha uma opção: ");
            string? opcao = EntradaConsole.LerLinha()?.Trim();

            if (opcao is null || opcao == "4")
            {
                Console.WriteLine("Até a próxima!");
                break;
            }

            if (atividades.TryGetValue(opcao, out Atividade? atividade))
            {
                if (atividade.Executar())
                {
                    concluidas[atividade.Nome]++;
                }
            }
            else
            {
                Console.WriteLine("Opção inválida. Escolha entre 1 e 4.");
            }

            Console.WriteLine($"Sessões nesta execução: Respiração {concluidas["Respiração"]} | Reflexão {concluidas["Reflexão"]} | Listagem {concluidas["Listagem"]}");
            Console.WriteLine("Pressione Enter para continuar...");
            if (EntradaConsole.LerLinha() is null)
            {
                Console.WriteLine("Até a próxima!");
                break;
            }
        }
    }
}
