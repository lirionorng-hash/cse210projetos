using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numeros = new List<int>();
        Console.WriteLine("Insira uma lista de números e digite 0 quando terminar.");

        while (true)
        {
            Console.Write("Insira o número: ");
            int numero = int.Parse(Console.ReadLine() ?? "0");
            if (numero == 0) { break; }
            numeros.Add(numero);
        }

        if (numeros.Count == 0)
        {
            Console.WriteLine("Nenhum número foi inserido.");
            return;
        }

        int soma = 0;
        int maior = numeros[0];
        int? menorPositivo = null;

        foreach (int numero in numeros)
        {
            soma += numero;
            if (numero > maior) { maior = numero; }
            if (numero > 0 && (menorPositivo == null || numero < menorPositivo.Value))
            {
                menorPositivo = numero;
            }
        }

        double media = (double)soma / numeros.Count;
        Console.WriteLine($"A soma é: {soma}");
        Console.WriteLine($"A média é: {media}");
        Console.WriteLine($"O maior número é: {maior}");

        if (menorPositivo != null)
        {
            Console.WriteLine($"O menor número positivo é: {menorPositivo}");
        }
        else
        {
            Console.WriteLine("Não há números positivos na lista.");
        }

        numeros.Sort();
        Console.WriteLine("A lista reordenada é:");
        foreach (int numero in numeros) { Console.WriteLine(numero); }
    }
}
