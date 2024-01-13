using Microsoft.EntityFrameworkCore;
using SYSMCTD.Interfaces;
using SYSMCTD.Models;
using System.Linq.Expressions;

namespace SYSMCTD.Repositories
{
    public class ContactRepository : IRepository<Contacts>
    {
        public readonly Context _context;
        public ContactRepository(Context ctx)
        {
            _context = ctx;
        }
        public async Task<Contacts> Create(Contacts contact)
        {
            contact.Created = DateTime.Now;
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
            return contact;
        }

        public async Task<bool> Delete(int id)
        {
            var contact = _context.Contacts.FirstOrDefault(x => x.Id == id);
            if (contact != null)
            {
                contact.IsDeleted = true;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Contacts> Edit(Contacts contact)
        {
            var editedContact = await _context.Contacts.Where(x => x.Id == contact.Id).
                ExecuteUpdateAsync(x => x.SetProperty(x => x.Emai, contact.Emai)
                .SetProperty(x => x.OfficeNumber, contact.OfficeNumber)
                .SetProperty(x => x.FullName, contact.FullName)
                );
            return contact;
        }

        public async Task<List<Contacts>> Get(Expression<Func<Contacts, bool>> predicate = null)
        {
           //TODO DTO
           return await _context.Contacts.Where(predicate).Include(p=>p.Customer).ToListAsync();
        }
    }
}
