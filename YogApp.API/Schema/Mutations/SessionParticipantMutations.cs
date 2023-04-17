using YogApp.API.Schema.Mutations.Inputs;
using YogApp.Domain.SessionParticipants;
using YogApp.Domain.Users;
using YogApp.Infrastructure.Repositories;
using HotChocolate.Authorization;
using YogApp.Domain.Sessions;
using Realms;
using YogApp.Domain.Exceptions;
using HotChocolate.Subscriptions;

namespace YogApp.API.Schema.Mutations;

[MutationType]
public static class SessionParticipantMutations
{
    public static string sessionChanged = "sessionChanged";

    [Authorize(Roles = new[] { "User", "Teacher" })]
    public static async Task<SessionParticipantEntity> CreateSessionParticipant(
        [Service] ISessionParticipantRepository repo,
        [Service] ISessionRepository sessionRepo,
        CreateSessionParticipantInput input,
        CancellationToken ct,
        [Service] ITopicEventSender eventSender)// Inject the IServiceProvider for resolving the session entity after it has been updated
    {
        SessionEntity session = sessionRepo.GetById(input.SessionId);
        SessionParticipantDomain sessionParticipant = SessionParticipantDomain.Create(input.MatNumber, input.UserAzureId);
        foreach (SessionParticipantEntity participant in session.Participants)
        {
            if (participant.MatNumber == input.MatNumber) throw new CanotNotSignUpForTakenMatException();
        }
        session.Participants.Add(sessionParticipant.entity);
        repo.AppendChanges(sessionParticipant.entity);
        await repo.SaveAsync(ct);

        // Resolve a new instance of the session entity from the session repository after it has been updated
        // This is necessary to ensure that the session entity returned by the event sender contains the latest changes
        var updatedSession = sessionRepo.GetById(session.Id);

        await eventSender.SendAsync(sessionChanged, updatedSession, ct);
        return sessionParticipant.entity;
    }

    [Authorize(Roles = new[] { "User", "Teacher" })]
    public static async Task<SessionParticipantEntity?> RemoveSessionParticipant([Service] ISessionParticipantRepository repo, [Service] ISessionRepository sessionRepo, int matNumber, Guid sessionId , CancellationToken ct, [Service] ITopicEventSender eventSender)
    {
        SessionEntity session = sessionRepo.GetById(sessionId);
        SessionParticipantEntity sessionParticipant = session.Participants.FirstOrDefault(x => x.MatNumber == matNumber);
        session.Participants.Remove(sessionParticipant);
        repo.SaveAsync(ct);
        await eventSender.SendAsync(sessionChanged, session, ct);
        return sessionParticipant;
    }

}