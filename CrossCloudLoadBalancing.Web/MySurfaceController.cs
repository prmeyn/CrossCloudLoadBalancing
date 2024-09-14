using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;

namespace CrossCloudLoadBalancing.Web
{
	public class MySurfaceController : SurfaceController
	{
		IHttpContextAccessor _httpContextAccessor;
		private readonly string mySessionKey = "mySessionKey";
		public MySurfaceController(IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider, IHttpContextAccessor httpContextAccessor) : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
		{
			_httpContextAccessor = httpContextAccessor;
		}

		// ...

		[HttpGet]
		public IActionResult Index()
		{
			
			var mySessionValue = _httpContextAccessor.HttpContext.Session.GetString(mySessionKey);

			if (string.IsNullOrWhiteSpace(mySessionValue))
			{
				mySessionValue = Guid.NewGuid().ToString();
				_httpContextAccessor.HttpContext.Session.SetString(mySessionKey, mySessionValue);

			}
			return Content(mySessionValue);
		}
	}
}
