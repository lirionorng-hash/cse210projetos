// Encapsula a referencia e a lista de palavras de uma escritura.
public class Escritura
{
    private Referencia _referencia;
    private List<Palavra> _palavras;

    public Escritura(Referencia referencia, string texto)
    {
        _referencia = referencia;
        _palavras = texto.Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(palavra => new Palavra(palavra))
            .ToList();
    }

    public void OcultarPalavrasAleatorias(int numeroParaOcultar)
    {
        // Criatividade: escolhe somente palavras que ainda estao visiveis.
        List<Palavra> visiveis = _palavras.Where(p => !p.EstaOculta()).ToList();

        for (int i = 0; i < numeroParaOcultar && visiveis.Count > 0; i++)
        {
            int indice = Random.Shared.Next(visiveis.Count);
            visiveis[indice].Ocultar();
            visiveis.RemoveAt(indice);
        }
    }

    public string ObterTexto()
    {
        return $"{_referencia.ObterTexto()} {string.Join(" ", _palavras.Select(p => p.ObterTexto()))}";
    }

    public bool EstaCompletamenteOculta()
    {
        return _palavras.All(p => p.EstaOculta());
    }
}
