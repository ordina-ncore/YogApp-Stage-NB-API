using YogApp.Domain.Sessions;

namespace YogApp.API
{
    public interface ISessionService
    {
        public SessionEntity CancelSession(SessionEntity session);
    }
}
