using YogApp.Domain.Sessions;

namespace YogApp.API
{
    [SubscriptionType]
    public class Subscription
    {
        [Subscribe]
        [Topic("sessionChanged")]
        public SessionEntity OnSessionDetailsChanged([EventMessage] SessionEntity changedSession)
            => changedSession;
    }
}
