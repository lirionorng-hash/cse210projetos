public class Produto
{
    private string _nome;
    private string _id;
    private decimal _precoUnitario;
    private int _quantidade;

    public Produto(string nome, string id, decimal precoUnitario, int quantidade)
    {
        _nome = nome;
        _id = id;
        _precoUnitario = precoUnitario;
        _quantidade = quantidade;
    }

    public string ObterNome() => _nome;
    public string ObterId() => _id;
    public decimal CalcularCustoTotal() => _precoUnitario * _quantidade;
}
