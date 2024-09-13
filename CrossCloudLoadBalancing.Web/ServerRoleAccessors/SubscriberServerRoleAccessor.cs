using Umbraco.Cms.Core.Sync;

namespace CrossCloudLoadBalancing.Web.ServerRoleAccessors
{
    public sealed class SubscriberServerRoleAccessor : IServerRoleAccessor
    {
        public ServerRole CurrentServerRole => ServerRole.Subscriber;
    }

}
