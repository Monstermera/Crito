using Crito.Models;
using Crito.Services;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;

namespace Crito.Controllers
{
    public class ContactsController : SurfaceController
    {

        private readonly ContactFormService _contactFormService;

        public ContactsController(IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider, ContactFormService contactFormService) : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
        {
            _contactFormService = contactFormService;
        }




        [HttpPost]
        public async Task<IActionResult> Index(ContactForm contactForm)
        {
            if (!ModelState.IsValid)
                return CurrentUmbracoPage();

            using var mail = new MailService("no-reply@crito.com", "smtp.crito.com", 587, "contact-form@crito.com", "Bytmig123!");

            await mail.SendAsync(contactForm.Email, "Your contact request was received.", "Hi! Your request was received and we will be in contact you as soon as possible.");

            await mail.SendAsync("umbraco@crito.com", $"{contactForm.Name} sent a contact request.", contactForm.Message);

            await _contactFormService.AddContactFormAsync(contactForm);

            return LocalRedirect(contactForm.RedirectUrl ?? "/");

        }

        //[HttpPost]
        //public async Task<IActionResult> Index(ContactForm contactForm)
        //{
        //    // Anpassade valideringsregler
        //    if (string.IsNullOrEmpty(contactForm.Name) || contactForm.Name.Length < 2)
        //    {
        //        ModelState.AddModelError("Name", "Name must be at least 2 characters long.");
        //    }

        //    if (string.IsNullOrEmpty(contactForm.Message) || contactForm.Message.Length < 5)
        //    {
        //        ModelState.AddModelError("Message", "Message must be at least 5 characters long.");
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        // Om modellen inte är giltig, återvänd till vyn med de anpassade felmeddelandena
        //        return View(contactForm);
        //    }

        //    using var mail = new MailService("no-reply@crito.com", "smtp.crito.com", 587, "contact-form@crito.com", "Bytmig123!");

        //    await mail.SendAsync(contactForm.Email, "Your contact request was received.", "Hi! Your request was received and we will be in contact with you as soon as possible.");

        //    await mail.SendAsync("umbraco@crito.com", $"{contactForm.Name} sent a contact request.", contactForm.Message);

        //    await _contactFormService.AddContactFormAsync(contactForm);

        //    return LocalRedirect(contactForm.RedirectUrl ?? "/");
        //}

    }
}
