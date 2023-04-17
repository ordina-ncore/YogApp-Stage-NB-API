using GraphQL.Types;

namespace YogApp.API
{
    public class MsGraphConfiguration
    {
        public string TenantId { get; set; } = "";
        public string ClientId { get; set; } = "";
        public string ClientSecret { get; set; } = "";
        public string Scope { get; set; } = "";
    }
}
