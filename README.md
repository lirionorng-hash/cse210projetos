# CSE 210 — S02: Programa de Diário (Abstração)

Projeto independente de console C# dentro de `semana02/Diario`, sem interferir nos demais exercícios do repositório `cse210projetos`.

## Arquivos
- `semana02/Diario/Diario.csproj`: projeto .NET 8
- `Program.cs`: menu, fluxo e comentários sobre criatividade
- `Diario.cs`: coleção de registros; salvar/carregar JSON
- `Registro.cs`: dados e exibição de uma entrada
- `GeradorDePerguntas.cs`: sorteio de sete perguntas, evitando repetição consecutiva

## Como enviar ao GitHub
No repositório `https://github.com/lirionorng-hash/cse210projetos`, entre na pasta `semana02` e carregue a **pasta interna `Diario`**, preservando todos os arquivos. Se a pasta `Diario` já tiver os mesmos arquivos, substitua-os; não envie outros projetos nem um segundo `Program.cs` para a raiz do repositório.

Caso faça o upload pela raiz do repositório, envie a pasta `semana02` deste pacote (sem duplicar a pasta `semana02`).

## Compilação / execução
Com .NET SDK 8 ou superior instalado, na raiz do repositório:

```bash
dotnet build semana02/Diario/Diario.csproj
dotnet run --project semana02/Diario/Diario.csproj
```

No menu: 1 escreve com pergunta sorteada e data; 2 exibe todas; 3 salva em `diario.json` (ou outro nome escolhido); 4 carrega substituindo os registros atuais; 5 sai. Faça teste com 1, 3, 5 e inicie novamente usando 4 e 2.

O arquivo JSON é criado no diretório de trabalho a partir do qual o programa é executado. `diario.json` é um dado pessoal e não deve ser enviado ao GitHub. O `.gitignore` incluso neste pacote ignora exemplos de diário, `bin/` e `obj/`.

## Avaliação
Inclui as dez categorias da rubrica (100 pontos possíveis). Os comentários de criatividade exigidos estão em `Program.cs`. Não foi possível executar `dotnet build` neste ambiente porque o SDK .NET não está disponível; **execute os dois comandos acima antes do envio ao Canvas**.
