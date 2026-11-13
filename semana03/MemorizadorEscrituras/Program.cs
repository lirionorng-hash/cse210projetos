// CSE 210 - Semana 03: Memorizador de Escrituras
// Criatividade alem dos requisitos basicos:
// 1. O programa possui uma pequena biblioteca com tres escrituras e escolhe uma
//    aleatoriamente a cada execucao, permitindo variar a pratica.
// 2. O metodo de ocultacao seleciona apenas palavras ainda visiveis. Assim,
//    cada Enter esconde novas palavras e evita repeticoes desnecessarias.
// 3. A pontuacao e preservada ao ocultar palavras, facilitando a leitura.

class Program
{
    static void Main(string[] args)
    {
        List<Escritura> biblioteca = new List<Escritura>
        {
            new Escritura(
                new Referencia("Proverbios", 3, 5, 6),
                "Confia no Senhor de todo o teu coracao, e nao te estribes no teu proprio entendimento. Reconhece-o em todos os teus caminhos, e ele endireitara as tuas veredas."),
            new Escritura(
                new Referencia("Joao", 11, 35),
                "Jesus chorou."),
            new Escritura(
                new Referencia("Salmos", 23, 1),
                "O Senhor e o meu pastor, nada me faltara.")
        };

        Escritura escritura = biblioteca[Random.Shared.Next(biblioteca.Count)];

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== MEMORIZADOR DE ESCRITURAS ===");
            Console.WriteLine();
            Console.WriteLine(escritura.ObterTexto());
            Console.WriteLine();

            if (escritura.EstaCompletamenteOculta())
            {
                Console.WriteLine("Parabens! Todas as palavras foram ocultadas.");
                break;
            }

            Console.Write("Pressione Enter para ocultar palavras ou digite 'sair': ");
            string? resposta = Console.ReadLine();

            if (resposta == null || resposta.Trim().Equals("sair", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Programa encerrado. Ate a proxima!");
                break;
            }

            escritura.OcultarPalavrasAleatorias(3);
        }
    }
}
