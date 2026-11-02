using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Qual é a sua nota percentual? ");
        int nota = int.Parse(Console.ReadLine() ?? "0");

        string letra;
        if (nota >= 90) { letra = "A"; }
        else if (nota >= 80) { letra = "B"; }
        else if (nota >= 70) { letra = "C"; }
        else if (nota >= 60) { letra = "D"; }
        else { letra = "F"; }

        string sinal = "";
        if (letra != "F")
        {
            int ultimoDigito = nota % 10;
            if (ultimoDigito >= 7) { sinal = "+"; }
            else if (ultimoDigito < 3) { sinal = "-"; }
        }
        if (letra == "A" && sinal == "+") { sinal = ""; }

        Console.WriteLine($"Sua nota conceitual é: {letra}{sinal}");

        if (nota >= 70)
        {
            Console.WriteLine("Parabéns! Você foi aprovado no curso.");
        }
        else
        {
            Console.WriteLine("Continue estudando! Você poderá conseguir na próxima vez.");
        }
    }
}
