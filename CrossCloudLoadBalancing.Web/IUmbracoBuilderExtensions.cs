using NeoSmart.Caching.Sqlite.AspNetCore;
using Umbraco.Cms.Core;

namespace CrossCloudLoadBalancing.Web
{
	public static partial class IUmbracoBuilderExtensions
	{
		public static IUmbracoBuilder AddSqliteCache(this IUmbracoBuilder builder)
		{
			string? dataDirectory = AppDomain.CurrentDomain.GetData(Constants.System.DataDirectoryName)?.ToString();
			string cacheDbPath = dataDirectory + "/cache.db";

			builder.Services.AddSqliteCache(options =>
			{
				options.CachePath = cacheDbPath;
			});

			return builder;
		}

		public static IUmbracoBuilder AddSqlServerCache(this IUmbracoBuilder builder)
		{
			string? dataDirectory = AppDomain.CurrentDomain.GetData(Constants.System.DataDirectoryName)?.ToString();

			builder.Services.AddDistributedSqlServerCache(options =>
			{
				options.SchemaName = "dbo";
				options.TableName = "sessionCache";
				options.ConnectionString = builder.Config.GetConnectionString("umbracoDbDSN");
			});

			return builder;
		}
	}
}
