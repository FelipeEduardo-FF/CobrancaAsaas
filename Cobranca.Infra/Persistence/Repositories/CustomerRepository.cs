using Cobrancas.Domain.Models;
using Cobrancas.Domain.Repositories;
using Cobrancas.Infra.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class CustomerRepository : ICustomerRepository
{
    private readonly ApplicationDbContext _context; 

    public CustomerRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Create(Customer costumer)
    {

        await _context.Customers.AddAsync(costumer); 
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Customer costumer)
    {
        costumer.Delete();
        await this.Update(costumer);
    }

    public async Task<Customer?> Get(int id)
    {
        return await _context.Customers.FindAsync(id); 
    }

    public async Task<List<Customer>> Get()
    {
        return await _context.Customers.Where(ct=>!ct.IsDeleted).ToListAsync(); 
    }

    public async Task Update(Customer costumer)
    {

        _context.Customers.Update(costumer); 
        await _context.SaveChangesAsync();
    }
}
