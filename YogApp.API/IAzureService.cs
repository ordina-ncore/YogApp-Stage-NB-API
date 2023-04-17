using YogApp.Domain.Users;

namespace YogApp.API
{
    public interface IAzureService
    {
        public Task<List<User>> GetTeachers();
        public Task<User> ResolveUser(string azureId);
    }
}
