using Microsoft.EntityFrameworkCore;
using SYSMCTD.Interfaces;
using SYSMCTD.Models;
using System.Formats.Tar;
using System.Linq;
using System.Linq.Expressions;

namespace SYSMCTD.Repositories
{
    public class CustomerRepository : IRepository<Customers>
    {
        public readonly Context _context;
        public CustomerRepository(Context ctx)
        {
            _context = ctx;
        }
        public async Task<Customers> Create(Customers customer)
        {
            customer.Created = DateTime.Now;
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<bool> Delete(int id)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.Id == id);
            if (customer != null)
            {
                customer.IsDeleted = true;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Customers> Edit(Customers customer)
        {
            var editedcustomer = await _context.Customers.Where(x => x.Id == customer.Id).
                ExecuteUpdateAsync(x => x.SetProperty(x => x.Name, customer.Name)
                .SetProperty(x => x.CustomerNumber, customer.CustomerNumber)
                );
            return customer;
        }

        //public async Task<List<Customers>> Get()
        //{
        //    //TODO DTO
        //    return await _context.Customers.Include(p => p.Contacts).Include(p => p.Addresses).ToListAsync();
        //}

        public async Task<List<Customers>> Get(Expression<Func<Customers, bool>> predicate)
        {
            //TODO DTO
            return await _context.Customers.Where(predicate).Include(p => p.Contacts).Include(p => p.Addresses).ToListAsync();
        }
    }
}
