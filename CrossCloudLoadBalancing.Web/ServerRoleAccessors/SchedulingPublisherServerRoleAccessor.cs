using Umbraco.Cms.Core.Sync;

namespace CrossCloudLoadBalancing.Web.ServerRoleAccessors
{
    public sealed class SchedulingPublisherServerRoleAccessor : IServerRoleAccessor
    {
        public ServerRole CurrentServerRole => ServerRole.SchedulingPublisher;
    }

}
