using YogApp.API.Schema.Mutations.Inputs;
using YogApp.Domain.SessionParticipants;
using YogApp.Domain.Users;
using YogApp.Infrastructure.Repositories;

namespace YogApp.API.Schema.Mutations;

[MutationType]
public class SessionParticipantMutations
{
    public SessionParticipantEntity? CreateSessionParticipant([Service] ISessionParticipantRepository repo, CreateSessionParticipantInput input, CancellationToken ct)
    {
        SessionParticipantDomain sessionParticipant = SessionParticipantDomain.Create(input.MatNumber, input.User);
        repo.AppendChanges(sessionParticipant.entity);
        repo.SaveAsync(ct);
        return sessionParticipant.entity;
    }
}