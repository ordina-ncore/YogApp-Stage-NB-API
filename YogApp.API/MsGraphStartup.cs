using Azure.Identity;
using Microsoft.Graph;

namespace YogApp.API
{
    public static class MsGraphStartup
    {
        public static IServiceCollection AddMsGraphConfiguration(this IServiceCollection services, IConfiguration configuration) 
        {
            var msGraphConfig = configuration.GetSection(nameof(MsGraphConfiguration)).Get<MsGraphConfiguration>()!;
            services.AddScoped(x =>
            {
                var scopes = new[] { msGraphConfig.Scope };
                var options = new TokenCredentialOptions
                {
                    AuthorityHost = AzureAuthorityHosts.AzurePublicCloud
                };
                var clientSecretCredential = new ClientSecretCredential(
                    msGraphConfig.TenantId, msGraphConfig.ClientId, msGraphConfig.ClientSecret, options);
                var graphclient = new GraphServiceClient(clientSecretCredential, scopes);
                return graphclient;
            });
            return services;
        }
    }

}
