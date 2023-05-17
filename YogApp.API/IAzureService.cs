using YogApp.Domain.Users;

namespace YogApp.API
{
    public interface IAzureService
    {
        public Task<List<User>> GetTeachers();
        public Task<User> ResolveUser(string azureId);
        public Task<bool> AddEventToCalendar(string azureId, string subject, string body, DateTime start, DateTime end);
        public Task<string> CreateCalendar();
    }
}
