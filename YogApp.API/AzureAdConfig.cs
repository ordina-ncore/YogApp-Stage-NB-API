using Microsoft.IdentityModel.Tokens;

namespace YogApp.API
{
    public class AzureAdConfig
    {
        public string Instance { get; set; }
        public string TenantId { get; set; }
        public string Domain { get; set; }
        public string ClientId { get; set; }
        public TokenValidationParameters TokenValidationParameters { get; set; }
    }
    public class TokenValidationParameters
    {
        public bool ValidateIssuer { get; set; }
        public string ValidIssuer { get; set; }
        public bool ValidateAudience { get; set; }
        public string ValidAudiences { get; set; }
    }
}
