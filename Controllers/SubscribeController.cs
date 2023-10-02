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
    public class SubscribeController : SurfaceController
    {
        private readonly SubscribeService _subscribeService;

        public SubscribeController(IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider, SubscribeService subscribeService) : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
        {
            _subscribeService = subscribeService;
        }




        [HttpPost]
        public async Task<IActionResult> Index(NewsletterForm form)
        {
            if (!ModelState.IsValid)
            {
                // Återställ scrollpositionen innan du returnerar sidan
                TempData["RestoreScrollPosition"] = true;
                return CurrentUmbracoPage();
            }

            await _subscribeService.AddSubscriberAsync(form);
            TempData["SuccessMessage"] = "Tack för att du prenumererar på vårt nyhetsbrev!";
            TempData["RestoreScrollPosition"] = true;
            return LocalRedirect(form.RedirectUrl ?? "/");

        }
    }
}
