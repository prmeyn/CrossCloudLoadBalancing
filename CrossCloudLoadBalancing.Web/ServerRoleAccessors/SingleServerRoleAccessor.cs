using Umbraco.Cms.Core.Sync;

namespace CrossCloudLoadBalancing.Web.ServerRoleAccessors
{
    public sealed class SingleServerRoleAccessor : IServerRoleAccessor
    {
        public ServerRole CurrentServerRole => ServerRole.Single;
    }

}
