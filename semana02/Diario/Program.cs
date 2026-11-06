using System.Globalization;
using System.Text;

namespace DiarioApp;

public class Program
{
    /*
     * CRIATIVIDADE - ALÉM DOS REQUISITOS BÁSICOS:
     * 1) O diário é salvo em JSON, em vez de usar um separador como '|'. Assim,
     *    perguntas/respostas podem incluir vírgulas, aspas e quebras de linha
     *    sem corromper o arquivo. O formato é legível e fácil de manter.
     * 2) O gerador evita repetir imediatamente a pergunta anterior e dispõe de
     *    sete perguntas originais, ultrapassando o mínimo de cinco.
     * 3) O carregamento valida o arquivo antes de substituir os registros;
     *    se o arquivo for inexistente ou inválido, mantém o diário atual.
     * 4) O programa aceita opções inválidas sem travar e oferece um nome de
     *    arquivo padrão para tornar mais rápido registrar e salvar o dia.
     */

    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Diario diario = new();
        GeradorDePerguntas gerador = new();
        bool continuar = true;

        while (continuar)
        {
            ExibirMenu();
            Console.Write("Escolha uma opção (1-5): ");
            string? opcao = Console.ReadLine()?.Trim();

            switch (opcao)
            {
                case "1":
                    EscreverRegistro(diario, gerador);
                    break;
                case "2":
                    diario.ExibirTodos();
                    break;
                case "3":
                    SalvarDiario(diario);
                    break;
                case "4":
                    CarregarDiario(diario);
                    break;
                case "5":
                    continuar = false;
                    Console.WriteLine("Até logo! Continue registrando suas experiências.");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Digite um número de 1 a 5.");
                    break;
            }
        }
    }

    private static void ExibirMenu()
    {
        Console.WriteLine("\n===== PROGRAMA DE DIÁRIO =====");
        Console.WriteLine("1. Escrever um novo registro");
        Console.WriteLine("2. Exibir o diário");
        Console.WriteLine("3. Salvar o diário em arquivo");
        Console.WriteLine("4. Carregar o diário de arquivo");
        Console.WriteLine("5. Sair");
    }

    private static void EscreverRegistro(Diario diario, GeradorDePerguntas gerador)
    {
        string pergunta = gerador.ObterPerguntaAleatoria();
        Console.WriteLine($"\n{pergunta}");
        Console.Write("> ");
        string? resposta = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(resposta))
        {
            Console.WriteLine("Registro cancelado: a resposta está vazia.");
            return;
        }

        string data = DateTime.Now.ToString("dd/MM/yyyy", new CultureInfo("pt-BR"));
        Registro registro = new(data, pergunta, resposta.Trim());
        diario.AdicionarRegistro(registro);
        Console.WriteLine("Registro adicionado ao diário!");
    }

    private static string SolicitarArquivo()
    {
        Console.Write("Nome do arquivo [diario.json]: ");
        string? nome = Console.ReadLine()?.Trim();
        return string.IsNullOrWhiteSpace(nome) ? "diario.json" : nome;
    }

    private static void SalvarDiario(Diario diario)
    {
        string arquivo = SolicitarArquivo();
        try
        {
            diario.SalvarNoArquivo(arquivo);
            Console.WriteLine($"Diário salvo em: {Path.GetFullPath(arquivo)}");
        }
        catch (Exception erro) when (erro is IOException or UnauthorizedAccessException or ArgumentException)
        {
            Console.WriteLine($"Não foi possível salvar: {erro.Message}");
        }
    }

    private static void CarregarDiario(Diario diario)
    {
        string arquivo = SolicitarArquivo();
        try
        {
            diario.CarregarDoArquivo(arquivo);
            Console.WriteLine("Diário carregado! Os registros anteriores foram substituídos.");
        }
        catch (Exception erro) when (erro is IOException or UnauthorizedAccessException or
            ArgumentException or System.Text.Json.JsonException)
        {
            Console.WriteLine($"Não foi possível carregar: {erro.Message}");
        }
    }
}
