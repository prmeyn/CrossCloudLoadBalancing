using CrossCloudLoadBalancing.Web.ServerRoleAccessors;
using Umbraco.Cms.Infrastructure.DependencyInjection;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

var umbracoBuilder = builder.CreateUmbracoBuilder()
    .AddBackOffice()
    .AddWebsite()
    .AddDeliveryApi()
    .AddComposers();

if (builder.Environment.EnvironmentName.Equals("Subscriber"))
{
    umbracoBuilder.SetServerRegistrar<SubscriberServerRoleAccessor>()
        .AddAzureBlobMediaFileSystem()
        .AddAzureBlobImageSharpCache();
}
else if (builder.Environment.IsProduction())
{
    umbracoBuilder.SetServerRegistrar<SchedulingPublisherServerRoleAccessor>();

}
else
{
    umbracoBuilder.SetServerRegistrar<SingleServerRoleAccessor>();
}

umbracoBuilder.Build();

WebApplication app = builder.Build();

await app.BootUmbracoAsync();

app.UseHttpsRedirection();

app.UseUmbraco()
    .WithMiddleware(u =>
    {
        u.UseBackOffice();
        u.UseWebsite();
    })
    .WithEndpoints(u =>
    {
        u.UseBackOfficeEndpoints();
        u.UseWebsiteEndpoints();
    });

await app.RunAsync();
