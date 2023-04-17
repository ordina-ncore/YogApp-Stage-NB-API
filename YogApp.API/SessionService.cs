using YogApp.Domain.Sessions;

namespace YogApp.API
{
    public class SessionService: ISessionService
    {
        public SessionEntity CancelSession(SessionEntity session)
        {
            session.IsCancelled = true;
            return session;
        }
    }
}
