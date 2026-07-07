# Zitec.Automation.Template

Esqueleto pronto pra começar qualquer automação nova em C# (Worker Service),
seguindo o mesmo padrão de arquitetura do `Zitec.Pdf.Classifier`.

## Como usar numa automação nova

1. Copia essa pasta inteira e renomeia pro nome da automação
   (ex: `Zitec.Automation.Template` → `Zitec.Faturamento.Recorrente`)
2. Usa Find & Replace no editor pra trocar `Zitec.Automation` pelo nome novo
   em todos os arquivos (`.csproj`, `.cs`, `.slnx`)
3. Vai nos 3 pontos marcados com `TODO`:
   - `Domain/Entities/ItemProcessado.cs` → adapta pro que a automação realmente processa
   - `Application/Services/AutomacaoExecutorService.cs` → coloca a lógica de negócio de verdade
   - `Worker/Worker.cs` → ajusta o intervalo entre execuções
4. Ajusta a connection string em `appsettings.json`
5. Roda com `dotnet run` dentro da pasta `Worker`

## Onde vai cada coisa

| Camada | Responsabilidade |
|---|---|
| **Domain** | Entidades puras, sem dependência de banco/API externa |
| **Application** | Orquestra o "o que fazer" (o `ExecutarCicloAsync` é chamado a cada ciclo) |
| **Infra** | EF Core, banco de dados, chamadas a serviços externos (S3, Slack, APIs, etc.) |
| **Worker** | Loop contínuo — chama a Application em intervalos definidos |

