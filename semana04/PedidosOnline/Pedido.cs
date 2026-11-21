using System.Collections.Generic;
using System.Linq;

public class Pedido
{
    private List<Produto> _produtos = new List<Produto>();
    private Cliente _cliente;

    public Pedido(Cliente cliente)
    {
        _cliente = cliente;
    }

    public void AdicionarProduto(Produto produto) => _produtos.Add(produto);

    public decimal CalcularPrecoTotal()
    {
        decimal subtotal = _produtos.Sum(produto => produto.CalcularCustoTotal());
        decimal frete = _cliente.MoraNosEua() ? 5m : 35m;
        return subtotal + frete;
    }

    public string ObterEtiquetaEmbalagem()
    {
        return string.Join("\n", _produtos.Select(produto => $"{produto.ObterNome()} - ID: {produto.ObterId()}"));
    }

    public string ObterEtiquetaEnvio()
    {
        return $"{_cliente.ObterNome()}\n{_cliente.ObterEndereco().ObterEnderecoCompleto()}";
    }
}
