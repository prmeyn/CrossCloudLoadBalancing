using NeoSmart.Caching.Sqlite.AspNetCore;
using Umbraco.Cms.Core;

namespace CrossCloudLoadBalancing.Web
{
	public static partial class IUmbracoBuilderExtensions
	{
		public static IUmbracoBuilder AddSqlServerCache(this IUmbracoBuilder builder)
		{
			builder.Services.AddDistributedSqlServerCache(options =>
			{
				options.SchemaName = "dbo";
				options.TableName = "SessionCache";
				options.ConnectionString = builder.Config.GetConnectionString(Constants.System.UmbracoConnectionName);
			});

			return builder;
		}
	}
}
