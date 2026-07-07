using Zitec.Automation.Domain.Entities;

namespace Zitec.Automation.Infra.Repositories;

public interface IItemProcessadoRepository
{
    Task AdicionarAsync(ItemProcessado item, CancellationToken cancellationToken = default);
    Task<List<ItemProcessado>> ListarTodosAsync(CancellationToken cancellationToken = default);
}
