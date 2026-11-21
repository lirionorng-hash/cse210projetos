using System;
using System.Collections.Generic;
using System.Globalization;

List<Pedido> pedidos = new List<Pedido>();

Endereco endereco1 = new Endereco("123 Main Street", "Provo", "Utah", "USA");
Cliente cliente1 = new Cliente("Maria Smith", endereco1);
Pedido pedido1 = new Pedido(cliente1);
pedido1.AdicionarProduto(new Produto("Notebook", "P001", 12.50m, 2));
pedido1.AdicionarProduto(new Produto("Caneta", "P002", 3.00m, 5));
pedidos.Add(pedido1);

Endereco endereco2 = new Endereco("Rua das Flores, 100", "Curitiba", "Parana", "Brasil");
Cliente cliente2 = new Cliente("Joao Silva", endereco2);
Pedido pedido2 = new Pedido(cliente2);
pedido2.AdicionarProduto(new Produto("Livro", "P003", 20.00m, 2));
pedido2.AdicionarProduto(new Produto("Mochila", "P004", 35.00m, 1));
pedido2.AdicionarProduto(new Produto("Caderno", "P005", 4.50m, 4));
pedidos.Add(pedido2);

int numero = 1;
foreach (Pedido pedido in pedidos)
{
    Console.WriteLine($"========== PEDIDO {numero} ==========");
    Console.WriteLine("ETIQUETA DE EMBALAGEM:");
    Console.WriteLine(pedido.ObterEtiquetaEmbalagem());
    Console.WriteLine();
    Console.WriteLine("ETIQUETA DE ENVIO:");
    Console.WriteLine(pedido.ObterEtiquetaEnvio());
    Console.WriteLine();
    Console.WriteLine($"TOTAL: {pedido.CalcularPrecoTotal().ToString("C", CultureInfo.GetCultureInfo("en-US"))}");
    Console.WriteLine();
    numero++;
}
