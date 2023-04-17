using YogApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using YogApp.Infrastructure.Repositories;
using YogApp.Domain.SessionParticipants;
using YogApp.Domain.Rooms;
using HotChocolate.Authorization;

namespace YogApp.API.Schema.Queries;

[QueryType]
public static class SessionParticipantQueries
{

    [UsePaging]
    [UseSorting]
    [UseFiltering]
    [Authorize(Roles = new[] {"Teacher"})]
    public static List<SessionParticipantEntity> GetSessionParticipants([Service] ISessionParticipantRepository repo)
    {
        return repo.GetAll();
    }
    [Authorize(Roles = new[] {"Teacher"})]
    public static SessionParticipantEntity? GetSessionParticipant([Service] ISessionParticipantRepository repo, Guid id)
    {
        return repo.GetById(id);
    }
}
