using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== CSE 210 - S05: Herança ===");
        Console.WriteLine();

        // Primeiro testamos a classe base.
        Tarefa tarefaSimples = new Tarefa("Samuel Silva", "Multiplicação");
        Console.WriteLine(tarefaSimples.ObterResumo());
        Console.WriteLine();

        // Esta classe herda o método ObterResumo() de Tarefa.
        TarefaDeMatematica tarefaMatematica = new TarefaDeMatematica(
            "Roberto Rodriguez", "Frações", "7.3", "8-19");
        Console.WriteLine(tarefaMatematica.ObterResumo());
        Console.WriteLine(tarefaMatematica.ObterListaDeTarefas());
        Console.WriteLine();

        // Esta classe também herda ObterResumo() e utiliza o nome da classe base.
        TarefaDeRedacao tarefaRedacao = new TarefaDeRedacao(
            "Maria Antunes", "História da Europa",
            "As Causas da Segunda Guerra Mundial");
        Console.WriteLine(tarefaRedacao.ObterResumo());
        Console.WriteLine(tarefaRedacao.ObterInformacaoDaRedacao());
    }
}
