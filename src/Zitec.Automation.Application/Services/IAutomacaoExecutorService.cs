namespace Zitec.Automation.Application.Services;

public interface IAutomacaoExecutorService
{
    // TODO: esse é o método que o Worker chama a cada ciclo.
    // Coloque aqui a orquestração da lógica da SUA automação
    // (buscar dados, processar, salvar resultado).
    Task ExecutarCicloAsync(CancellationToken cancellationToken = default);
}
