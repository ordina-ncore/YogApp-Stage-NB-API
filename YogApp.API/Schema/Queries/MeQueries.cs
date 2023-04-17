using HotChocolate.Authorization;
using YogApp.Domain.Users;
using YogApp.Infrastructure.Repositories;

namespace YogApp.API.Schema.Queries
{
    [QueryType]
    public static class MeQueries
    {

        [Authorize(Roles = new[] { "User", "Teacher" })]
        public static Task<User> GetMe([Service] IAzureService azureService, string azureId)
        {
            return azureService.ResolveUser(azureId);
        }

    }

}
