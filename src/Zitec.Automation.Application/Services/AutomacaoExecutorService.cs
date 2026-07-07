using Microsoft.Extensions.Logging;
using Zitec.Automation.Domain.Entities;
using Zitec.Automation.Infra.Repositories;

namespace Zitec.Automation.Application.Services;

public class AutomacaoExecutorService : IAutomacaoExecutorService
{
    private readonly IItemProcessadoRepository _repository;
    private readonly ILogger<AutomacaoExecutorService> _logger;

    public AutomacaoExecutorService(
        IItemProcessadoRepository repository,
        ILogger<AutomacaoExecutorService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task ExecutarCicloAsync(CancellationToken cancellationToken = default)
    {
        var item = new ItemProcessado
        {
            Identificador = Guid.NewGuid().ToString("N")[..8],
            ProcessadoEm = DateTime.UtcNow
        };

        try
        {
            // TODO: substitua esse bloco pela lógica real da sua automação.
            // Ex: buscar arquivo no Slack/S3, processar, chamar API externa, etc.
            _logger.LogInformation("Processando item {Identificador}...", item.Identificador);

            await Task.Delay(500, cancellationToken); // placeholder de trabalho

            item.Sucesso = true;
            _logger.LogInformation("Item {Identificador} processado com sucesso.", item.Identificador);
        }
        catch (Exception ex)
        {
            item.Sucesso = false;
            item.MensagemErro = ex.Message;
            _logger.LogError(ex, "Falha ao processar item {Identificador}.", item.Identificador);
        }
        finally
        {
            await _repository.AdicionarAsync(item, cancellationToken);
        }
    }
}
