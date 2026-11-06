using System.Text.Json;

namespace DiarioApp;

/// <summary>Administra a coleção de registros e sua persistência.</summary>
public class Diario
{
    private List<Registro> _registros = new();

    public void AdicionarRegistro(Registro novoRegistro)
    {
        ArgumentNullException.ThrowIfNull(novoRegistro);
        _registros.Add(novoRegistro);
    }

    public void ExibirTodos()
    {
        if (_registros.Count == 0)
        {
            Console.WriteLine("O diário está vazio. Escreva um registro primeiro.");
            return;
        }

        Console.WriteLine($"\n--- Meu diário: {_registros.Count} registro(s) ---");
        foreach (Registro registro in _registros)
        {
            registro.Exibir();
        }
    }

    public void SalvarNoArquivo(string arquivo)
    {
        // JSON preserva textos contendo vírgulas, aspas, | e quebras de linha.
        var opcoes = new JsonSerializerOptions { WriteIndented = true };
        string conteudo = JsonSerializer.Serialize(_registros, opcoes);

        using (StreamWriter arquivoSaida = new(arquivo, false))
        {
            arquivoSaida.Write(conteudo);
        }
    }

    public void CarregarDoArquivo(string arquivo)
    {
        string conteudo = File.ReadAllText(arquivo);
        List<Registro>? registrosCarregados =
            JsonSerializer.Deserialize<List<Registro>>(conteudo);

        if (registrosCarregados is null ||
            registrosCarregados.Any(registro => registro is null ||
                string.IsNullOrWhiteSpace(registro.Data) ||
                string.IsNullOrWhiteSpace(registro.Pergunta)))
        {
            throw new InvalidDataException("O arquivo não contém um diário válido.");
        }

        // Substituir a lista somente depois de verificar a leitura.
        _registros = registrosCarregados;
    }
}
