using Crito.Contexts;
using Crito.Models;

namespace Crito.Services
{
    public class SubscribeService
    {
        private readonly DataContext _context;

        public SubscribeService(DataContext context)
        {
            _context = context;
        }

        public async Task AddSubscriberAsync(NewsletterForm form)
        {
            _context.Subscribers.Add(new SubscriberEntity { Email = form.Email });
            await _context.SaveChangesAsync();
        }

 
    }
}
