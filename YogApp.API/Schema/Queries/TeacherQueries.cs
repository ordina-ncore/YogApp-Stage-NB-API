using HotChocolate.Authorization;
using YogApp.Domain.Users;
using YogApp.Infrastructure.Repositories;

namespace YogApp.API.Schema.Queries
{
    [QueryType]
    public static class TeacherQueries
    {
        [Authorize(Roles = new[] {"Teacher" })]
        public static Task<List<User>> GetTeachers([Service] IAzureService azureService)
        {
            return azureService.GetTeachers();
        }
    }

}
