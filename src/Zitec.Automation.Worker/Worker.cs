using Zitec.Automation.Application.Services;

namespace Zitec.Automation.Worker;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IServiceScopeFactory _scopeFactory;

    // TODO: ajuste o intervalo entre execuções conforme a necessidade da automação
    private static readonly TimeSpan Intervalo = TimeSpan.FromMinutes(5);

    public Worker(ILogger<Worker> logger, IServiceScopeFactory scopeFactory)
    {
        _logger = logger;
        _scopeFactory = scopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Zitec.Automation.Worker iniciado. Intervalo entre ciclos: {Intervalo}", Intervalo);

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                // Escopo novo a cada ciclo — importante porque o DbContext é Scoped,
                // e o Worker em si vive como Singleton durante toda a execução do serviço.
                using var scope = _scopeFactory.CreateScope();
                var executor = scope.ServiceProvider.GetRequiredService<IAutomacaoExecutorService>();

                await executor.ExecutarCicloAsync(stoppingToken);
            }
            catch (Exception ex)
            {
                // Log e segue pro próximo ciclo — uma falha isolada não deve derrubar o Worker inteiro
                _logger.LogError(ex, "Erro não tratado durante o ciclo de execução.");
            }

            await Task.Delay(Intervalo, stoppingToken);
        }
    }
}
