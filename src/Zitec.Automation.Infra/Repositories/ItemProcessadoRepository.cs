using Microsoft.EntityFrameworkCore;
using Zitec.Automation.Domain.Entities;
using Zitec.Automation.Infra.DataContext;

namespace Zitec.Automation.Infra.Repositories;

public class ItemProcessadoRepository : IItemProcessadoRepository
{
    private readonly AutomationDbContext _context;

    public ItemProcessadoRepository(AutomationDbContext context)
    {
        _context = context;
    }

    public async Task AdicionarAsync(ItemProcessado item, CancellationToken cancellationToken = default)
    {
        await _context.ItensProcessados.AddAsync(item, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<ItemProcessado>> ListarTodosAsync(CancellationToken cancellationToken = default)
    {
        return await _context.ItensProcessados
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}
