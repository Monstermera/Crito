using Crito.Contexts;
using Crito.Models;

namespace Crito.Services
{
    public class ContactFormService
    {
        private readonly DataContext _context;

        public ContactFormService(DataContext context)
        {
            _context = context;
        }

        public async Task AddContactFormAsync(ContactForm form)
        {
            _context.ContactForms.Add(new ContactFormEntity
            {
                Name = form.Name,
                Email = form.Email,
                Message = form.Message,
            });
            await _context.SaveChangesAsync();
        }
    }
}
