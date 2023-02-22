using YogApp.API.Schema.Mutations.Inputs;
using YogApp.Domain.Sessions;
using YogApp.Domain.Users;
using YogApp.Infrastructure.Repositories;

namespace YogApp.API.Schema.Mutations
{
    [MutationType]
    public class SessionMutations
    {
        public SessionEntity? CreateSession([Service] ISessionRepository repo, CreateSessionInput input, CancellationToken ct)
        {
            SessionDomain session = SessionDomain.Create(input.Title, input.StartDateTime, input.EndDateTime, input.Capacity, input.Teacher, input.Room);
            repo.AppendChanges(session.entity);
            repo.SaveAsync(ct);
            return session.entity;
        }
    }
}
