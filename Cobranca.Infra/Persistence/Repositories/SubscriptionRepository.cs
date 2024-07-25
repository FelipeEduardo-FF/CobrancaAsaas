using Cobrancas.Domain.Enum;
using Cobrancas.Domain.Models;
using Cobrancas.Domain.Repositories;
using Cobrancas.Infra.Persistence.Data;
using Microsoft.EntityFrameworkCore;


public class SubscriptionRepository : ISubscriptionRepository
{
    private readonly ApplicationDbContext _context; 

    public SubscriptionRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Create(Subscription subscription)
    {
        await _context.Subscriptions.AddAsync(subscription); 
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Subscription subscription)
    {
        subscription.Delete();
        await this.Update(subscription);
    }

    public async Task<Subscription?> Get(int id)
    {
        return await _context.Subscriptions.Include(sub => sub.Customer).FirstOrDefaultAsync(sub => sub.Id ==id); 
    }

    public async Task<List<Subscription>> Get()
    {
        return await _context.Subscriptions.Include(sub=>sub.Customer).Where(sub=>sub.Status!= SubscriptionStatus.Deleted).ToListAsync(); 
    }

    public async Task<Subscription> GetByIdPayment(string id)
    {
        return await _context.Subscriptions.Include(sub => sub.Customer).FirstOrDefaultAsync(sub => sub.IdSubscription == id);
    }

    public async Task Update(Subscription subscription)
    {

        _context.Subscriptions.Update(subscription);
        await _context.SaveChangesAsync();
    }
}
